. "$PSScriptRoot/../HttpPipelineMocking.ps1"

Describe 'New-Vm expanded' {
    It "Should create a new vm" {

        $vmName = -join ((48..57) + (97..122) `
            | Get-Random -Count 16 `
            | % {[char]$_})
        $vmDesc = -join ((48..57) + (97..122) `
            | Get-Random -Count 16 `
            | % {[char]$_})

        $metadata = New-VmMetadataObject

        $disk = New-DiskObject `
            -DeviceType DISK `
            -DiskSizeMib 200

        $resources = New-VmResourcesObject `
            -NumSockets 1 `
            -NumVcpusPerSocket 2 `
            -PowerState ON `
            -MemorySizeMib 4096 `
            -DiskList $disk

        $spec = New-VmObject `
            -ClusterReferenceUuid $env:ClusterID `
            -Name $vmName `
            -Resources $resources `
            -Description $vmDesc

        $vm = New-Vm `
            -Metadata $metadata `
            -Spec $spec `
            -SkipSSL

        $vmGet = Get-Vm `
            -Uuid $vm.Metadata.Uuid `
            -SkipSSL

        Remove-Vm `
            -Uuid $vmGet.Metadata.Uuid `
            -SkipSSl

    }
}

Describe "New-VM all atts" {
    It "Should Create a New-VM" {

        $vmName = -join ((48..57) + (97..122) `
            | Get-Random -Count 16 `
            | % {[char]$_})
        $vmDesc = -join ((48..57) + (97..122) `
            | Get-Random -Count 16 `
            | % {[char]$_})

        $vm = New-Vm `
            -NumSockets 1 `
            -NumVcpusPerSocket 2 `
            -PowerState ON `
            -MemorySizeMib 1000 `
            -Name $vmName `
            -Description $vmDesc `
            -ClusterReferenceUuid $env:ClusterID `
            -SkipSSL

        Remove-Vm `
            -Uuid $vm.Metadata.Uuid `
            -SkipSSl
    }
}