  
# https://www.appveyor.com/docs/environment-variables/

# Script static variables
$buildDir = $env:APPVEYOR_BUILD_FOLDER # e.g. C:\projects\rn-common\
$buildNumber = $env:APPVEYOR_BUILD_VERSION # e.g. 1.0.17


# C:\projects\rn-common\src\Rn.Common
$projectDir = $buildDir + "\src\IqOptionApi.NET";
# C:\projects\rn-common\src\Rn.Common\Rn.Common.csproj
$projectFile = $projectDir + "\IqOptionApi.NET.csproj";
# C:\projects\rn-common\src\Rn.CommonTests
$testDir = $buildDir + "\tests\IqOptionApi.Tests";
# C:\projects\rn-common\src\Rn.Common\Rn.Common.x.x.x.nupkg
$nugetFile = $projectDir + "\Build\Packages\iqoptionapi." + $buildNumber + ".nupkg";

# Display .Net Core version
Write-Host "Checking .NET Core version" -ForegroundColor Green
& dotnet --version

# Restore the main project
Write-Host "Restoring project" -ForegroundColor Green
& dotnet restore $projectFile --verbosity m

# Publish the project
Write-Host "Publishing project" -ForegroundColor Green
& dotnet build $projectFile -c Release

# Discover and run tests
Write-Host "Running tests" -ForegroundColor Green
cd $testDir
& dotnet restore IqOptionApi.Tests.csproj --verbosity m
$testOutput = & dotnet test | Out-String
Write-Host $testOutput

# Ensure that the tests passed
if ($testOutput.Contains("Test Run Successful.") -eq $False) {
  Write-Host "Build failed!";
  Exit;
}

# Generate a NuGet package for publishing
Write-Host "Generating NuGet Package" -ForegroundColor Green
cd $projectDir
& dotnet pack -c Release /p:PackageVersion=$buildNumber -o Build\Packages\

# Save generated artifacts
Write-Host "Saving Artifacts" -ForegroundColor Green
Push-AppveyorArtifact $nugetFile

# Publish package to NuGet
#Write-Host "Publishing NuGet package" -ForegroundColor Green
#& nuget push $nugetFile -ApiKey $env:NUGET_API_KEY -Source https://www.nuget.org/api/v2/package

# Done
Write-Host "Done!" -ForegroundColor Green