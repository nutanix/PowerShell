. "$PSScriptRoot/HttpPipelineMocking.ps1"

Describe "New-CategoryKey" {
    It "Creates a new category" {
        $cmdletcategory = -join ((48..57) + (97..122) `
            | Get-Random -Count 16 `
            | % {[char]$_})

        $category = New-CategoryKey `
            -Name $cmdletcategory `
            -Description "created via cmdlet" `
            -SkipSSL

        Remove-CategoryKey `
            -Name $category.Name `
            -SkipSSL

    }
}

Describe "New-CategoryValue" {
    It "Creates a new category" {
        $cmdletcategory = -join ((48..57) + (97..122) `
            | Get-Random -Count 16 `
            | % {[char]$_})

        $category = New-CategoryKey `
            -Name $cmdletcategory `
            -Description "created with a cmdlet" `
            -SkipSSL

        $value = New-CategoryValue `
            -Name $category.Name `
            -Value value `
            -SkipSSL

        Remove-CategoryValue `
            -Name $category.Name `
            -Value $value.Value `
            -SkipSSL

        Remove-CategoryKey `
            -Name $category.Name `
            -SkipSSL
    }
}
