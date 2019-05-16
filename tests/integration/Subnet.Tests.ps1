# Pull In Mocking Support
. "$PSScriptRoot/../HttpPipelineMocking.ps1"
 Describe  "New-Subnet" {
     It "Should create a New-Subnet all-attr" {

      #  $randParams = @{ 'minimum' = '1' ;
      #                   'maximum' ='500' }

      #  $vlanID = Get-Random @randparams

      #  $subnet = New-Subnet `
      #      -BootFileName bootifile `
      #      -DomainName nutanix `
      #      -TftpServerName 10.250.140.200 `
      #      -DomainNameServerList "8.8.8.8", "4.2.2.2" `
      #      -DomainSearchList "terraform.nutanix.com", "terraform.unit.test.com" `
      #      -DefaultGatewayIp 10.250.141.1 `
      #      -PoolList "10.250.141.110 10.250.141.250" `
      #      -Ip 10.250.141.254 `
      #      -PrefixLength 24 `
      #      -SubnetIp 10.250.141.0 `
      #      -VlanId 324 `
      #      -SubnetType Vlan `
      #      -Name CmdletGen `
      #      -Description "Generated via cmdlet" `
      #      -ClusterReferenceUuid $env:ClusterID 

      #  Get-Subnet `
      #      -Uuid $subnet.Metadata.Uuid `
      #      -SkipSSL
      #  Remove-Subnet `
      #      -Uuid $subnet.Metadata.Uuid `
      #      -SkipSSL
     }
     It "Should create a New-Subnet expanded" {

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

        $subnet = New-Subnet `
            -Metadata $metadata `
            -Spec $subnetObj `
            -SkipSSL

        Get-Subnet `
            -Uuid $subnet.Metadata.Uuid `
            -SkipSSL
        Remove-Subnet `
            -Uuid $subnet.Metadata.Uuid `
            -SkipSSL
     }
 }