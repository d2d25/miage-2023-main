FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MiageCorp.AwesomeShop.ProductApi/MiageCorp.AwesomeShop.ProductApi.csproj", "MiageCorp.AwesomeShop.ProductApi/"]
RUN dotnet restore "MiageCorp.AwesomeShop.ProductApi/MiageCorp.AwesomeShop.ProductApi.csproj"
COPY . .
WORKDIR "/src/MiageCorp.AwesomeShop.ProductApi"
RUN dotnet build "MiageCorp.AwesomeShop.ProductApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiageCorp.AwesomeShop.ProductApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiageCorp.AwesomeShop.ProductApi.dll"]
