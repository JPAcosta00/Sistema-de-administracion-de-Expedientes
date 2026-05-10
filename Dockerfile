# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos de proyecto y restaurar
COPY ["SGE.Interfaz/SGE.Interfaz.csproj", "SGE.Interfaz/"]
COPY ["SGE.Aplicacion/SGE.Aplicacion.csproj", "SGE.Aplicacion/"]
COPY ["SGE.Repositorios/SGE.Repositorios.csproj", "SGE.Repositorios/"]
RUN dotnet restore "SGE.Interfaz/SGE.Interfaz.csproj"

# Copiar todo y publicar
COPY . .
WORKDIR "/src/SGE.Interfaz"
RUN dotnet publish "SGE.Interfaz.csproj" -c Release -o /app/publish

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SGE.Interfaz.dll"]