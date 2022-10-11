#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Nigel.Dapr.BackendApi/Nigel.Dapr.BackendApi.csproj", "Nigel.Dapr.BackendApi/"]
RUN dotnet restore "Nigel.Dapr.BackendApi/Nigel.Dapr.BackendApi.csproj"
COPY . .
WORKDIR "/src/Nigel.Dapr.BackendApi"
RUN dotnet build "Nigel.Dapr.BackendApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nigel.Dapr.BackendApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nigel.Dapr.BackendApi.dll"]