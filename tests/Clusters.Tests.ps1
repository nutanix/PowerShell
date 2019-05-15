# Pull In Mocking Support
. "$PSScriptRoot/HttpPipelineMocking.ps1"
 Describe "Get-Cluster" {
     It "Should Get Cluster" {
        $clusterMetaObj = New-ClusterListMetadataObject `
           -Length "1" `
           -Filter ""  `
           -SortOrder "DESCENDING" `
           -Offset 1 `
           -SortAttribute "name"

        $clusterList = Get-Cluster `
            -GetEntitiesRequest $clusterMetaObj `
            -SkipSSL
        
        $clusterList.Metadata.Kind | should be "cluster"
     }
 }