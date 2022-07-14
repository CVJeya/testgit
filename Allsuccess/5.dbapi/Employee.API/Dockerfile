FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Employee.API.csproj", "."]
RUN dotnet restore "./Employee.API.csproj"
COPY . .
RUN dotnet publish -c release -o /app


#Run phase
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
COPY --from=build /app .
ENTRYPOINT [ "dotnet","Employee.API.dll" ]