import importlib.util
import unittest
from pathlib import Path

spec = importlib.util.spec_from_file_location("nuget_version", Path(__file__).with_name("nuget-version.py"))
module = importlib.util.module_from_spec(spec)
spec.loader.exec_module(module)


def project(version="3.0.2", extra=""):
    return f'<Project><PropertyGroup><PackageId>IqOptionApiDotNet</PackageId><Version>{version}</Version>{extra}</PropertyGroup></Project>'


class VersionTests(unittest.TestCase):
    def test_changed_version(self):
        self.assertTrue(module.changed(project("3.0.3"), project()))

    def test_other_changes_do_not_publish(self):
        self.assertFalse(module.changed(project(extra='<Description>Changed</Description>'), project()))

    def test_package_version_takes_precedence(self):
        self.assertEqual(module.metadata(project(extra='<PackageVersion>4.0.0-beta.1</PackageVersion>'))[1], "4.0.0-beta.1")

    def test_rejects_expressions(self):
        with self.assertRaises(ValueError):
            module.metadata(project("$(ReleaseVersion)"))

    def test_real_project(self):
        package_id, version = module.metadata(Path(module.PROJECT).read_bytes())
        self.assertEqual(package_id, "IqOptionApiDotNet")
        self.assertRegex(version, r"^\d+\.\d+\.\d+")


if __name__ == '__main__':
    unittest.main()
