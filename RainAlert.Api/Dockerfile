#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RainAlert.Api/RainAlert.Api.csproj", "RainAlert.Api/"]
RUN dotnet restore "RainAlert.Api/RainAlert.Api.csproj"
COPY . .
WORKDIR "/src/RainAlert.Api"
RUN dotnet build "RainAlert.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RainAlert.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RainAlert.Api.dll"]