## Publish yöntemleri
- `dotnet publish -c Release -r win-x64 -p:SelfContained=false` => Uygulamanın çalışması için .NET kurulu olması gerekiyor
- `dotnet publish -c Release -r win-x64 -p:PublishSingleFile=true -p:SelfContained=true` => Uygulamanın çalışması için .NET kurulu olması gerekmiyor(JIT Bağımlı çalışır)
- `dotnet publish -c Release -r win-x64 -p:PublishAot=true` => Uygulamanın çalışması için .NET kurulu olması gerekmiyor([Native](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot) çalışır)
