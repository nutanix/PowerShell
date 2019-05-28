# Pull In Mocking Support
. "$PSScriptRoot/../HttpPipelineMocking.ps1"
 Describe  "New-Subnet" {

     It "Should create a New-Subnet Meta-Spec Expanded" {

        $randParams = @{ 'minimum' = '1' ;
                         'maximum' ='500' }

        $vlanID = Get-Random @randparams

        $options = New-DhcpOptionsObject `
            -BootFileName bootifile `
            -DomainName nutanix `
            -TftpServerName 10.250.140.200 `
            -DomainNameServerList "8.8.8.8", "4.2.2.2" `
            -DomainSearchList "terraform.nutanix.com", "terraform.unit.test.com"

        $options.BootFileName | should be "bootifile"
        $options.DomainName | should be "nutanix"
        $options.TftpServerName | should be "10.250.140.200"
        $options.DomainNameServerList.Count | should be 2
        $options.DomainSearchList.Count | should be 2
        
        $ipConfig = New-IpConfigObject `
            -DefaultGatewayIp 10.250.141.1 `
            -DhcpOptions $options `
            -AddressIp 10.250.141.254 `
            -PoolList "10.250.141.110 10.250.141.250" `
            -PrefixLength 24 `
            -SubnetIp 10.250.141.0
        
        $ipConfig.DefaultGatewayIp | should be "10.250.141.1"
        $ipConfig.DhcpServerAddress.Ip | should be "10.250.141.254"
        $ipConfig.PoolList.Count | should be 1
        $ipConfig.PrefixLength | should be 24
        $ipConfig.SubnetIp | should be "10.250.141.0"

        $subnetResources = New-SubnetResourcesObject `
            -IpConfig $ipConfig `
            -VlanId $vlanID `
            -SubnetType VLAN

        $subnetResources.SubnetType | should be "VLAN"

        $subnetObj = New-SubnetObject `
            -Name CmdletGen `
            -Description "Generated via cmdlet" `
            -Resources $subnetResources `
            -ClusterReferenceUuid $env:ClusterID 
        
        $subnetObj.Name | Should be "CmdletGen"
        $subnetObj.Description | Should be "Generated via cmdlet"

        $metadata = New-SubnetMetadataObject

        $subnet = New-Subnet `
            -Metadata $metadata `
            -Spec $subnetObj `
            -SkipSSL
        
        $subnet.Metadata.Categories.kind | should be "subnet"

        Get-Subnet `
            -Uuid $subnet.Metadata.Uuid `
            -SkipSSL
        Remove-Subnet `
            -Uuid $subnet.Metadata.Uuid `
            -SkipSSL
     }
     It "Should create a New-Subnet Meta-Spec" {

        $randParams = @{ 'minimum' = '1' ;
                         'maximum' ='500' }

        $vlanID = Get-Random @randparams

        $options = New-DhcpOptionsObject `
            -BootFileName bootifile `
            -DomainName nutanix `
            -TftpServerName 10.250.140.200 `
            -DomainNameServerList "8.8.8.8", "4.2.2.2" `
            -DomainSearchList "terraform.nutanix.com", "terraform.unit.test.com"

        $ipconfig = New-IpConfigObject `
            -DefaultGatewayIp 10.250.141.1 `
            -DhcpOptions $options `
            -AddressIp 10.250.141.254 `
            -PoolList "10.250.141.110 10.250.141.250" `
            -PrefixLength 24 `
            -SubnetIp 10.250.141.0

        $subnetresources = New-SubnetResourcesObject `
            -IpConfig $ipconfig `
            -VlanId $vlanID `
            -SubnetType VLAN

        $subnetObj = New-SubnetObject `
            -Name CmdletGen `
            -Description "Generated via cmdlet" `
            -Resources $subnetresources `
            -ClusterReferenceUuid $env:ClusterID 

        $metadata = New-SubnetMetadataObject

        $subnetBody = New-SubnetIntentInputObject `
            -Metadata $metadata `
            -Spec $subnetObj

        $subnet = New-Subnet -Body $subnetBody `
            -SkipSSL

        Get-Subnet `
            -Uuid $subnet.Metadata.Uuid `
            -SkipSSL
        Remove-Subnet `
            -Uuid $subnet.Metadata.Uuid `
            -SkipSSL
     }
 }