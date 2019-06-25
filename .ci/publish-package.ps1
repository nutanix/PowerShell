#!/usr/bin/pwsh
param(
    [String]$apiKey
)
0
$ModuleName= "Nutanix"

mkdir  ".\$ModuleName"

Get-ChildItem -Path . | Copy-Item -Destination ".\$ModuleName" -Recurse -Container 

rm -rf ./Nutanix/private/
rm -rf ./Nutanix/help/   
rm -rf ./Nutanix/test*   

Import-Module ".\$ModuleName\$ModuleName.psd1"

Get-Module Nutanix

Publish-Module -Name ".\$ModuleName\$ModuleName.psd1" -NuGetApiKey $apiKey

rm -rf ./Nutanix   