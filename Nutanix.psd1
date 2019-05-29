
@{
ModuleVersion='1.0'
Author='Nutanix'
Description='Nutanix pwsh'
GUID = '197269f6-8815-402f-97d1-c06a1261bc78'
NestedModules = @(
  "./bin/Nutanix.private.dll"
  "Nutanix.psm1"

)
# don't export any actual cmdlets by default
CmdletsToExport = ''
# export the functions that we loaded(these are the proxy cmdlets)
FunctionsToExport = '*-*'
}