# Nutanix PowerShell

Microsoft PowerShell module to integrate with Nutanix Enterprise Cloud

NOTE: This PowerShell module is currently tech preview as of 13 June 2018. See "Current Development Status" below.

NOTE: This is open source, and we love pull requests! Please see the GitHub issues for help wanted, and feel free to chip in with pull requests!

#### Project, Build, Quality Status

[![Waffle.io - Columns and their card count](https://badge.waffle.io/nutanix/PowerShell.svg?columns=all)](https://waffle.io/nutanix/PowerShell) [![Codacy Badge](https://api.codacy.com/project/badge/Grade/31363a609f9e422097824a083e983357)](https://www.codacy.com/app/JonKohler/PowerShell?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=nutanix/PowerShell&amp;utm_campaign=Badge_Grade) [![codecov](https://codecov.io/gh/nutanix/PowerShell/branch/master/graph/badge.svg)](https://codecov.io/gh/nutanix/PowerShell)
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Fnutanix%2FPowerShell.svg?type=shield)](https://app.fossa.io/projects/git%2Bgithub.com%2Fnutanix%2FPowerShell?ref=badge_shield)

| Master                                                                                                                                                          | Develop                                                                                                                                                           |
| --------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [![CircleCI](https://circleci.com/gh/nutanix/PowerShell.svg?style=svg)](https://circleci.com/gh/nutanix/PowerShell) | (TBD) |



What, Why, and Goals
--------------------
Nutanix is committed to making PowerShell a first-class feature. In service of that goal, Nutanix is planning to deprecate the existing PowerShell cmdlets, in favor of this fully open source project.

Nutanix cmdlets are being replaced with a "from the ground up" rewrite, leveraging our latest API's and Microsoft's PowerShell 6.x code train.

This new release will fundamentally enhance our functionality, including:
* PowerShell 6.0 Support for Windows, Linux, and OSX
* Module support, for easy integration with editors like Visual Studio Code
* PowerShell Gallery support, for ease of deployment
* Simplified, easy to use Cmdlets with traditional virtualization sysadmin semantics
* Verbose Get-Help with detailed examples on each cmdlet
* Production supported, with additional Open Source community collaboration on GitHub and Slack
* Nutanix v3 API support - This means Calm, Micro Seg, and all of the other goodies.
* Note: legacy API’s will only be leveraged for methods not yet available in v3 API

Nutanix is taking an inclusive approach to developing this new feature and welcomes customer feedback. Please see our development project on GitHub, comment on requirements and/or design, and feel free to join us on Slack. Instructions on commenting, contributing, and joining our community Slack channel are all located within our GitHub Readme.

For a slack invite, please contact PowerShell@nutanix.com from your business address, and we'll add you.

Roadmap
--------------------
If you're reading this, you're in on the ground floor. Really, the parking garage. We've just started to put in the foundation for this project, and we're "soft launching" by opening up so people can check out our development progress.

In the short term, we'll be adding our full requirements list as we build our our documentation, and start baking in a proper readme, etc.

##### TODO - tune up the install / dev docs based on the new processes
Quick Install
-------------

Just try out the Docker image?

    sudo docker run -it kasprosian/ntnx-powershell bash

Then inside the container:

    cd /Powershell
    sh test/sanity_test.sh

Install Dependencies
--------------------

Make sure nuget is installed (check via `which nuget`).

    make deps

Install from source
-------------------

    make

Install from package
--------------------

TODO: coming soon, a way to install from powershell gallery.

Install PowerShell 6.1.0-Preview3++: https://github.com/PowerShell/PowerShell/releases
Launch PowerShell Preview: pwsh-preview
import-module -Name /Users/jon/git/PowerShell/src/Nutanix.PowerShell.SDK/bin/Debug/netcoreapp2.1/Nutanix.PowerShell.SDK.psm1 -Verbose
    (this assumes you've compiled and moved the psm1/psd1 to the bin/debug/netcoreapp2.1 folder)
$pass = ConvertTo-SecureString -string "Nutanix/1234" -force -AsPlainText
Connect-Cluster -Server 10.5.80.60 -UserName admin -Password $pass -AcceptInvalidSslCerts

## License
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Fnutanix%2FPowerShell.svg?type=large)](https://app.fossa.io/projects/git%2Bgithub.com%2Fnutanix%2FPowerShell?ref=badge_large)
