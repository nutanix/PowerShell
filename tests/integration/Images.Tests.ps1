# Pull In Mocking Support
. "$PSScriptRoot/../HttpPipelineMocking.ps1"
 Describe "New-Image" {
     It "Should create a New-Image" {
        $imageUrl = "http://archive.ubuntu.com/ubuntu/dists/bionic/main/installer-amd64/current/images/netboot/mini.iso"

        $resources = New-ImageResourcesObject `
            -SourceUri $imageUrl 

        $resources.SourceUri | should be $imageUrl

        $imageObj = New-ImageObject `
            -Name name `
            -Description "Ubuntu mini iso" `
            -Resources $resources
        
        $imageObj.Name | should be "name"
        $imageObj.Description | should be "Ubuntu mini iso"

        $metadata = New-ImageMetadataObject

        $image = New-Image `
            -Metadata $metadata `
            -Spec $imageObj `
            -SkipSSL
        
        $image.Spec.Resources.Architecture | should be "X86_64"

        Remove-Image `
            -Uuid $image.Metadata.Uuid `
            -SkipSSL
     }
     It "Should create a New-Image MetaSpec Expanded" {
        $imageUrl = "http://archive.ubuntu.com/ubuntu/dists/bionic/main/installer-amd64/current/images/netboot/mini.iso"

        $resources = New-ImageResourcesObject `
            -SourceUri $imageUrl 

        $metadata = New-ImageMetadataObject

        $imageUploaded = New-Image `
            -Metadata $metadata `
            -ImageName "Uploaded image" `
            -ImageDescription "Someimage" `
            -ImageResources $resources `
            -SkipSSL

        $imageUploaded.Spec.Resources.Architecture | should be "X86_64"

        Remove-Image `
            -Uuid $imageUploaded.Metadata.Uuid `
            -SkipSSL
     }
 }