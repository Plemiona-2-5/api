FROM  mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY WebApi/*.csproj ./WebApi/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY ApplicationCore/. ./ApplicationCore/.
RUN dotnet restore WebApi/

# Copy everything else and build
COPY WebApi/. ./WebApi/.
COPY Infrastructure/. ./Infrastructure/.
COPY ApplicationCore/. ./ApplicationCore/.
RUN dotnet publish WebApi/*.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "WebApi.dll"]