# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["GestionITM.Api/GestionITM.Api.csproj", "GestionITM.Api/"]
RUN dotnet restore "GestionITM.Api/GestionITM.Api.csproj"
COPY . .
WORKDIR "/src/GestionITM.Api"
RUN dotnet build "GestionITM.Api.csproj" -c Release -o /app/build
RUN dotnet publish "GestionITM.Api.csproj" -c Release -o /app/publish

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "GestionITM.Api.dll"]