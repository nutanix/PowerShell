
@{
ModuleVersion="1.0"
NestedModules = @(
  "./bin/NutanixIntentfulAPI.private.dll"
  "NutanixIntentfulAPI.psm1"
)
# don't export any actual cmdlets by default
CmdletsToExport = ''
# export the functions that we loaded(these are the proxy cmdlets)
FunctionsToExport = '*-*'
}