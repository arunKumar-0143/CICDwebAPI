@echo off
echo ========================================================
echo  BUILDING CICDProject SOLUTION
echo ========================================================

dotnet build "CICDProject.sln"

if %ERRORLEVEL% neq 0 (
    echo.
    echo ========================================================
    echo  BUILD FAILED! Exiting with code 1...
    echo ========================================================
    exit /b 1
)

echo.
echo ========================================================
echo  BUILD SUCCESSFUL!
echo ========================================================
exit /b 0
