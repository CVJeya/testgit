FROM mcr.microsoft.com/dotnet/sdk:6.0 AS dotnet-build
WORKDIR /src
EXPOSE 80
COPY ["ReactSPA/ReactSPA.csproj", "ReactSPA/"]
RUN dotnet restore "ReactSPA/ReactSPA.csproj"
COPY . .
WORKDIR "/src/ReactSPA"
RUN dotnet build "ReactSPA.csproj" -c Release -o /app/build

COPY ["ReactSPA/ReactSPA.csproj", "ReactSPA/"]

FROM dotnet-build AS dotnet-publish
RUN dotnet publish "ReactSPA.csproj" -c Release -o /app/publish

FROM node:16-alpine3.12 AS node-builder
WORKDIR /node
COPY /ReactSPA/ClientApp /node
RUN npm install
COPY . ./
RUN npm run build

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
EXPOSE 80

RUN mkdir /app/wwwroot
COPY --from=dotnet-publish /app/publish .
COPY --from=node-builder /node/build ./wwwroot
ENTRYPOINT ["dotnet", "ReactSPA.dll"]