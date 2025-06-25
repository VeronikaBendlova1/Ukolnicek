# Fáze 1: build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Zkopíruj csproj a obnov balíčky
COPY Ukolnicek.csproj ./
RUN dotnet restore

# Zkopíruj zbytek projektu a sestav
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Fáze 2: run
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Railway očekává, že app běží na portu 8080
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Ukolnicek.dll"]
