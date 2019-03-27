FROM mcr.microsoft.com/dotnet/core/runtime:2.2 AS runtime
WORKDIR /app  
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src  
COPY src/ProductsApi.csproj .  
RUN dotnet restore  
COPY . .  
WORKDIR /src  
RUN dotnet build -c Release -o /app

FROM build AS publish  
RUN dotnet publish -c Release -o /app

FROM runtime AS final  
WORKDIR /app  
COPY --from=publish /app .  
ENTRYPOINT ["dotnet", "ProductsApi.dll"]  