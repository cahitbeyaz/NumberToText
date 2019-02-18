dotnet tool install --global coverlet.console
dotnet add package coverlet.msbuild
dotnet clean
dotnet test /p:CollectCoverage=true
PAUSE