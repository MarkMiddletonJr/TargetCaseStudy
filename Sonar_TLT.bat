Sample Sonar-Publish.Bat

call :Logit>>UnitTestProducts.log 2>&1
:Logit

echo Start time is: %date% %TIME%

@set TestRunnerExe="%VS110COMNTOOLS%..\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
@set OpenCoverExe="C:\SonarQubeSupportive\OpenCover.4.5.3723\OpenCover.Console.exe"

@set ProjectTestDll=UnitTestProducts.dll
@set OpenCoverResults=UnitTestProducts.xml
rem %TestRunnerExe%  %ProjectTestDll% 
%OpenCoverExe% -register:user -target:%TestRunnerExe% -targetargs:"%ProjectTestDll% /Logger:trx" -output:%OpenCoverResults%


C:\SonarQubeSupportive\sonar-runner-dist-2.4\sonar-runner-2.4\bin\sonar-runner.bat

echo End time is: %date% %TIME%

exit /b %errorlevel%
