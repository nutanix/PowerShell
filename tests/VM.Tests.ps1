. "$PSScriptRoot/HttpPipelineMocking.ps1"

Describe 'New-Vm expanded' {
    It "Should create a new vm" {

        $vmName = -join ((48..57) + (97..122) | Get-Random -Count 16 | % {[char]$_})
        $vmDesc = -join ((48..57) + (97..122) | Get-Random -Count 16 | % {[char]$_})

        $metadata = New-VmMetadataObject
        $disk = New-DiskObject -DeviceType DISK -DiskSizeMib 200
        $resources = New-VmResourcesObject -NumSockets 1 -NumVcpusPerSocket 2 -PowerState ON -MemorySizeMib 4096 -DiskList $disk
        $spec = New-VmObject -ClusterReferenceUuid $env:ClusterID -Name $vmName -Resources $resources -Description $vmDesc -SkipSSL

        $vmGet = Get-ServiceVm -Uuid $vm.Metadata.Uuid -SkipSSL

        $vm = New-Vm -HttpPipelineAppend $mock -Metadata $metadata -Spec $spec
    }
}

Describe "New-VM all atts" {
    It "Should Create a New-VM" {

    }
}