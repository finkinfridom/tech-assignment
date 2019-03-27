FROM microsoft/dotnet:2.2-sdk-alpine as build
WORKDIR /app

COPY src/ProductsApi.csproj ./src/
WORKDIR /app/src
RUN dotnet restore

# copy and publish app and libraries
WORKDIR /app
COPY src/. ./src/
WORKDIR /app/src
RUN dotnet publish -c Release -o out


FROM build AS testrunner
WORKDIR /app/tests
COPY __tests__/. .
#ENTRYPOINT ["dotnet", "test", "--logger:trx"]


FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine as runtime
ENV ASPNETCORE_ENVIRONMENT Production 
WORKDIR /app
COPY --from=build /app/src/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "ProductsApi.dll"]