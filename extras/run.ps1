# Build then run

function Step() {
    param([string] $title)
    Write-Output "--------------------------"
    Write-Output $title
}

function EndStep() {
    Write-Output "END"
}

Step "# Create new bin/"
if (Test-Path bin/) {
    Remove-Item bin/ -Recurse
}
New-Item bin/ -ItemType Directory
EndStep

Step "# Copy dll from lib/"
Copy-Item lib/*.dll bin/
EndStep

Step "# Compile base.dll"
csc.ps1 -path src/*.cs `
    -targetLibrary `
    -out bin/base.dll `
    -reference System.Net.Http.dll, Newtonsoft.Json.dll `
    -lib bin
EndStep

Step "# Compile JudgeMain.cs"
csc.ps1 -path src/JudgeMain.cs `
    -out bin/JudgeMain.exe `
    -reference bin/base.dll
EndStep

Step "# Run JudgeMain.exe"
./bin/JudgeMain.exe
EndStep
