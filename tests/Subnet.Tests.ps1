# Pull In Mocking Support
. "$PSScriptRoot/HttpPipelineMocking.ps1"
 Describe "New-Subnet" {
     It "Should create a New-Subnet" {
        $options = New-DhcpOptionsObject -BootFileName bootifile -DomainName nutanix -TftpServerName 10.250.140.200 -DomainNameServerList "8.8.8.8", "4.2.2.2" -DomainSearchList "terraform.nutanix.com", "terraform.unit.test.com"
        $ipconfig = New-IpConfigObject -DefaultGatewayIp 10.250.141.1 -DhcpOptions $options -AddressIp 10.250.141.254 -PoolList "10.250.141.110 10.250.141.250" -PrefixLength 24 -SubnetIp 10.250.141.0
        $subnetresources = New-SubnetResourcesObject -IpConfig $ipconfig -VlanId 3896 -SubnetType VLAN
        $subnetObj = New-SubnetObject -Name CmdletGen -Description "Generated via cmdlet" -Resources $subnetresources -ClusterReferenceUuid 27db5fb2-2aa0-48c4-bd2a-2fccdb8fad36
        $metadata = New-SubnetMetadataObject

        $subnet = New-Subnet -Metadata $metadata -Spec $subnetObj -SkipSSL

        Get-Subnet -Uuid $subnet.Metadata.Uuid -SkipSSL
        Remove-Subnet -Uuid $subnet.Metadata.Uuid -SkipSSL
     }
 }