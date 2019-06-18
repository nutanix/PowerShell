#!/usr/bin/pwsh
param(
    [String]$apiKey
)
0
$ModuleName= "Nutanix"

Import-Module ".\$ModuleName.psd1"

Get-Module Nutanix

Publish-Module -Name ".\$ModuleName.psd1" -NuGetApiKey $apiKey