set OPENCOVER="%USERPROFILE%\.nuget\packages\opencover\4.7.922\tools\OpenCover.Console.exe"
set TARGET="dotnet.exe"
set TARGET_TEST="test OreAka.WPF.Test.csproj"
set OUTPUT="coverage.xml"
set FILTERS="+[OreAka*]* -[*Test*]* -[*]*.Presentation.*"
%OPENCOVER% -register:user -target:%TARGET% -targetargs:%TARGET_TEST% -filter:%FILTERS% -oldstyle -output:%OUTPUT%

pause

set REPORTGEN="%USERPROFILE%\.nuget\packages\reportgenerator\4.3.0\tools\netcoreapp3.0\ReportGenerator.exe"
set OUTPUT="coverage.xml"
set OUTPUT_DIR="Coverage"
%REPORTGEN% -reports:%OUTPUT% -targetdir:%OUTPUT_DIR%

pause