FROM microsoft/dotnet:2.1-sdk
WORKDIR /app

ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5000"]
