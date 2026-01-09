# syntax=docker/dockerfile:1

# Base runtime image
FROM --platform=$TARGETPLATFORM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

# If you really need a non-root user in AKS, set it explicitly later.
# For now, comment this out to avoid failures due to undefined APP_UID
# USER $APP_UID

# Build image
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY EmployeeAPI.csproj ./
RUN dotnet restore ./EmployeeAPI.csproj

COPY . ./
RUN dotnet build ./EmployeeAPI.csproj -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish ./EmployeeAPI.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish ./
ENTRYPOINT ["dotnet", "EmployeeAPI.dll"]
