#!/usr/bin/env bash
set -euo pipefail

: "${GH_TOKEN:?GitHub token required}"
: "${GITHUB_REPOSITORY:?Repository required}"
: "${GITHUB_SHA:?Commit required}"
: "${PACKAGE_ID:?Package ID required}"
: "${PACKAGE_VERSION:?Package version required}"

release_tag="v${PACKAGE_VERSION}"
package_name="${PACKAGE_ID}.${PACKAGE_VERSION}.nupkg"
package_file="artifacts/${package_name}"
mkdir -p artifacts

# For backfilling a release, fetch the exact package already served by NuGet.
if [[ ! -f "$package_file" ]]; then
  package_id_lower="${PACKAGE_ID,,}"
  package_version_lower="${PACKAGE_VERSION,,}"
  curl --fail --show-error --silent --location \
    "https://api.nuget.org/v3-flatcontainer/${package_id_lower}/${package_version_lower}/${package_id_lower}.${package_version_lower}.nupkg" \
    --output "$package_file"
fi

# Never move an existing tag. Confirm it contains the requested package version.
if git rev-parse "refs/tags/${release_tag}" >/dev/null 2>&1; then
  tag_project="$(git show "${release_tag}:src/IqOptionApiDotNet/IqOptionApiDotNet.csproj")"
  TAG_PROJECT="$tag_project" python3 - <<'PY'
import importlib.util
import os
spec = importlib.util.spec_from_file_location("version", ".github/scripts/nuget-version.py")
module = importlib.util.module_from_spec(spec)
spec.loader.exec_module(module)
assert module.metadata(os.environ["TAG_PROJECT"]) == (os.environ["PACKAGE_ID"], os.environ["PACKAGE_VERSION"]), "Existing tag points to a different package version"
PY
fi

# A failed API request must not be mistaken for a missing release.
release_json="$(gh api "repos/${GITHUB_REPOSITORY}/releases?per_page=100")"
release_exists="$(RELEASE_JSON="$release_json" RELEASE_TAG="$release_tag" python3 - <<'PY'
import json, os
print("true" if any(r["tag_name"] == os.environ["RELEASE_TAG"] for r in json.loads(os.environ["RELEASE_JSON"])) else "false")
PY
)"
if [[ "$release_exists" == "false" ]]; then
  release_flags=()
  if [[ "$PACKAGE_VERSION" == *-* ]]; then release_flags+=(--prerelease); fi
  gh release create "$release_tag" --repo "$GITHUB_REPOSITORY" \
    --target "$GITHUB_SHA" --title "Version ${PACKAGE_VERSION}" \
    --generate-notes "${release_flags[@]}"
fi

# Retry safely: preserve an existing asset only if it has the same bytes.
asset_exists="$(gh release view "$release_tag" --repo "$GITHUB_REPOSITORY" \
  --json assets --jq ".assets[] | select(.name == \"${package_name}\") | .name")"
if [[ -n "$asset_exists" ]]; then
  compare_dir="$(mktemp -d)"
  trap 'rm -rf "$compare_dir"' EXIT
  gh release download "$release_tag" --repo "$GITHUB_REPOSITORY" \
    --pattern "$package_name" --dir "$compare_dir"
  cmp "$package_file" "$compare_dir/$package_name"
  echo "Release asset already matches: ${package_name}"
else
  gh release upload "$release_tag" "$package_file" --repo "$GITHUB_REPOSITORY"
fi
