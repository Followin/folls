FROM node:alpine as frontend-build-env 
WORKDIR /app

COPY ./fe/package*.json ./
RUN npm install

COPY ./fe ./
RUN npx vue-cli-service build --dest out

FROM microsoft/dotnet:2.1-sdk as build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
COPY --from=frontend-build-env /app/out ./wwwroot
RUN dotnet publish -c Release -o out --no-restore


FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Folls.UI.dll"]