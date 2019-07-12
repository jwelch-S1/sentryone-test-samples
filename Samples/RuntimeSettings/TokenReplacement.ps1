param (
    [Parameter(Mandatory=$true)]
        [string]$sourceFile,
    [Parameter(Mandatory=$false)]
        [string]$targetFile = $sourceFile,
    [Parameter(Mandatory=$true)]
    [ValidateNotNullOrEmpty()]
        [string[]]$replacementList 
 )

$content = (Get-Content $sourceFile)
foreach($replaceItem in $replacementList)
{
    $replace = $replaceItem.Split("|")
    $content = $content.Replace($replace[0], $replace[1])
}

Set-Content -Value $content -Path $targetFile