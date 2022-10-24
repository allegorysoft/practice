FROM mcr.microsoft.com/windows/nanoserver:ltsc2019

WORKDIR /app

COPY ./bin/Release/net7.0/win-x64/publish .

ENTRYPOINT [ "Sample.Counter.exe" ]
