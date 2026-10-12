"""Decide whether an explicit package version changed in a push to master."""
import os
import re
import subprocess
import xml.etree.ElementTree as ET
from pathlib import Path

PROJECT = "src/IqOptionApiDotNet/IqOptionApiDotNet.csproj"


def metadata(xml):
    root = ET.fromstring(xml)
    values = {node.tag: (node.text or "").strip()
              for group in root.findall("PropertyGroup") if not group.get("Condition")
              for node in group if not node.get("Condition")}
    version = values.get("PackageVersion") or values.get("Version", "")
    package_id = values.get("PackageId", "")
    if not re.fullmatch(r"\d+\.\d+\.\d+(?:\.\d+)?(?:-[0-9A-Za-z.-]+)?(?:\+[0-9A-Za-z.-]+)?", version):
        raise ValueError("Specify a literal NuGet version in Version or PackageVersion.")
    if not re.fullmatch(r"[A-Za-z0-9_.-]+", package_id):
        raise ValueError("Specify a literal PackageId.")
    return package_id, version


def changed(current, previous):
    return metadata(current) != metadata(previous)


def main():
    current = Path(PROJECT).read_bytes()
    package_id, version = metadata(current)
    event = os.environ["EVENT_NAME"]
    if event == "workflow_dispatch":
        publish = True
    elif event == "push":
        before = os.environ["BEFORE_SHA"]
        if not re.fullmatch(r"[0-9a-f]{40}", before) or before == "0" * 40:
            raise ValueError("A valid previous commit is required to compare versions.")
        previous = subprocess.check_output(["git", "show", f"{before}:{PROJECT}"])
        publish = changed(current, previous)
    else:
        raise ValueError(f"Unsupported event: {event}")
    with open(os.environ["GITHUB_OUTPUT"], "a", encoding="utf-8") as output:
        output.write(f"publish={str(publish).lower()}\nversion={version}\npackage_id={package_id}\n")
    print(f"{package_id} {version}: {'publish' if publish else 'version unchanged; skip'}")


if __name__ == "__main__":
    main()
