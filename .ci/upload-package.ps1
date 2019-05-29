#!/usr/bin/pwsh
param(
    [String]$apiKey
)

Import-Module -Name .\Nutanix.psd1

Get-Module Nutanix

Publish-Module -Name .\Nutanix.psd1 -NuGetApiKey $apiKey