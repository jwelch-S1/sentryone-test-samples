# Sets user environment variables for package locations. The Visual Studio environment will need to be
# restarted after executing this so that it can see the variables.
# [Your local repo folder here] should be replaced with the local folder for the solution.
# Example: C:\Repos\sentryone-test\Samples\SsisSample\EmptyPackage.dtsx

[Environment]::SetEnvironmentVariable("PackageFileLocation", "[Your local repo folder here]\Samples\SsisSample\EmptyPackage.dtsx", "User")
[Environment]::SetEnvironmentVariable("IspacFileLocation", "[Your local repo folder here]\Samples\SsisSample\bin\Development\EmptyPackage.dtsx", "User")
