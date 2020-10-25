function publish($a) {
    $path = "../../LinkCreator/"
    $zipFile = $path+"LinkCreator-x"+$a+".7z"
    
    dotnet publish -r win-x$a -c Release -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained true
    7z a -t7z $zipFile ./bin/Release/net5.0/win-x$a/*
    Get-FileHash $zipFile | Out-File $path$a".hash"
 }

Set-Location "./src/DotnetBucket.LinkCreator/"

publish("64")
publish("86")

Set-Location "../.."