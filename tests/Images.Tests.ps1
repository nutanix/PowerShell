# Pull In Mocking Support
. "$PSScriptRoot/HttpPipelineMocking.ps1"
 Describe "New-Image" {
     It "Should create a New-Image" {
        $imageUrl = "http://archive.ubuntu.com/ubuntu/dists/bionic/main/installer-amd64/current/images/netboot/mini.iso"

        $resources = New-ImageResourcesObject `
            -SourceUri $imageUrl 

        $imageObj = New-ImageObject `
            -Name name `
            -Description "Ubuntu mini iso" `
            -Resources $resources

        $metadata = New-ImageMetadataObject

        $image = New-Image `
            -Metadata $metadata `
            -Spec $imageObj `
            -SkipSSL

        $imageUploaded = New-Image `
            -Metadata $metadata `
            -ImageName "Uploaded image" `
            -ImageDescription "Someimage" `
            -SkipSSL

        Remove-Image `
            -Uuid $imageUploaded.Metadata.Uuid `
            -SkipSSL
     }
 }