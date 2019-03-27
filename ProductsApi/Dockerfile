FROM microsoft/dotnet:runtime AS base  
WORKDIR /app  
EXPOSE 5000

FROM microsoft/dotnet:sdk AS build  
WORKDIR /src  
COPY src/ProductsApi.csproj .  
RUN dotnet restore  
COPY . .  
WORKDIR /src  
RUN dotnet build -c Release -o /app

FROM build AS publish  
RUN dotnet publish -c Release -o /app

FROM base AS final  
WORKDIR /app  
COPY --from=publish /app .  
ENTRYPOINT ["dotnet", "ProductsApi.dll"]  