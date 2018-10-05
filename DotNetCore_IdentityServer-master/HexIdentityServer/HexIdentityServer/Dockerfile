FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore

#copy remaining files
COPY . .
RUN dotnet build -c Release -o /app
RUN dotnet publish -c Release -o /app

#Create image using runtime base image
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS final
WORKDIR /app
EXPOSE 80
ENV ConnectionStrings:DefaultConnection="Server=tcp:rikydb.database.windows.net,1433;Initial Catalog=blogdb;Persist Security Info=False;User ID=rakeshthakur;Password=Rthakur12#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
ENV SpaClient=""
ENV MvcClient=""
COPY --from=build /app ""
ENTRYPOINT [ "dotnet", "HexIdentityServer.dll" ]