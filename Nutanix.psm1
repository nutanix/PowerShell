# region Initialization
    # this module instance.
    $instance =  [Nutanix.Powershell.Module]::Instance

    # load nested script module if it exists
    if( test-path "$PSScriptRoot/bin/Nutanix.scripts.psm1" )  {
        ipmo "$PSScriptRoot/bin/Nutanix.scripts.psm1"
    }

    $privatemodule = ipmo -passthru "$PSScriptRoot/bin/Nutanix.private.dll"
    # export the 'exported' cmdlets
    Get-ChildItem "$PSScriptRoot/exported" -Recurse -Filter "*.ps1" -File | Sort-Object Name | Foreach {
        Write-Verbose "Dot sourcing private script file: $($_.Name)"
        . $_.FullName
        # Explicity export the member
        Export-ModuleMember -Function $_.BaseName
    }
# endregion

# region Finalization
    # finish initialization of this module
    $instance.Init();

# endregion
