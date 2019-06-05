#!/usr/bin/pwsh
param(
    [String]$passwd,
    [String]$user,
    [String]$port=9440,
    [String]$server,
    [String]$protocol="https"
)

Import-Module -Name .\Nutanix.psd1


$credentials = New-NutanixCredential `
    -password $passwd `
    -username $user `
    -port $port `
    -server $server `
    -protocol $protocol 

Set-NutanixCredential -Credential $credentials

Invoke-Pester -Path ".\tests\*.Tests.ps1" -CodeCoverage ".\exported\*Credential*.ps1" 