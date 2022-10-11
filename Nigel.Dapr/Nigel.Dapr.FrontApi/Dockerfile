#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Nigel.Dapr.FrontApi/Nigel.Dapr.FrontApi.csproj", "Nigel.Dapr.FrontApi/"]
RUN dotnet restore "Nigel.Dapr.FrontApi/Nigel.Dapr.FrontApi.csproj"
COPY . .
WORKDIR "/src/Nigel.Dapr.FrontApi"
RUN dotnet build "Nigel.Dapr.FrontApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nigel.Dapr.FrontApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nigel.Dapr.FrontApi.dll"]