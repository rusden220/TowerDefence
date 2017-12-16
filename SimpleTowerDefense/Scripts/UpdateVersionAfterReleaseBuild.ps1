[CmdletBinding()]
Param (
	[string] $ProjectDir,
    [string] $buildType
)
[System.Text.RegularExpressions.Regex]$rg = New-Object -TypeName System.Text.RegularExpressions.Regex -ArgumentList "([0-9]\.){3}[0-9]"
[System.Text.Encoding]$encoding = [System.Text.Encoding]::UTF8;
[System.Collections.ArrayList] $data = New-Object System.Collections.ArrayList

if($buildType -eq "Release")
{

    $reader = [System.IO.File]::OpenText($ProjectDir)
    while (!($reader.EndOfStream))
    {
        [string]$temp = $reader.ReadLine()
        $data.Add($temp);
    }
    $reader.Close()


    [System.Collections.ArrayList]$fileRows = $data
    [int]$count=0;

    for($i=1; $i -le $data.Count; $i++)
    {
        [string]$row = $data[$i]; 
        Write-Host "row: " $row
        [System.Text.RegularExpressions.Match] $match = $rg.Match($row);
        if($match.Success)
        {
            [string]$fileVersion = $match.Value;
            Write-Host "current version: " $fileVersion;

            [int]$versionNumberRevision = 0;
            [string]$versionNumberRevisionValue = $fileVersion.Substring($fileVersion.LastIndexOf(".") + 1);

            if(![int]::TryParse($versionNumberRevisionValue,[ref] $versionNumberRevision)){
                Write-Host "can't pars data bad regexp pattern"
            }

            $versionNumberRevision++;
            [string]$newVersion = $fileVersion.Substring(0, $fileVersion.LastIndexOf(".") + 1) + $versionNumberRevision;
            Write-Host "new version: " $newVersion;

            $data[$i] = $rg.Replace($row, $newVersion);
        }
    }


    [System.IO.StreamWriter]$sw = New-Object -TypeName System.IO.StreamWriter -ArgumentList $ProjectDir, $false, $encoding 

    foreach($item in $data){
        $sw.WriteLine($item)
    }
    $sw.close()


}
