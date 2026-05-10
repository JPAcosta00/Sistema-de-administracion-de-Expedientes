# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos de proyecto y restaurar
COPY ["SGE.UI/SGE.UI.csproj", "SGE.UI/"]
COPY ["SGE.Aplicacion/SGE.Aplicacion.csproj", "SGE.Aplicacion/"]
COPY ["SGE.Repositorios/SGE.Repositorios.csproj", "SGE.Repositorios/"]
RUN dotnet restore "SGE.UI/SGE.UI.csproj"

# Copiar todo y publicar
COPY . .
WORKDIR "/src/SGE.UI"
RUN dotnet publish "SGE.UI.csproj" -c Release -o /app/publish

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SGE.UI.dll"]