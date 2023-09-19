FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /weatherService
COPY ["weatherService/Api/Api.csproj", "Api/"]
COPY ["weatherService/Common/Common.csproj", "Common/"]
COPY ["weatherService/Contracts/Contracts.csproj", "Contracts/"]
COPY ["weatherService/Domain/Domain.csproj", "Domain/"]
COPY ["weatherService/Persistence/Persistence.csproj", "Persistence/"]
COPY ["weatherService/Presentation/Presentation.csproj", "Presentation/"]
COPY ["weatherService/Repository/Repository.csproj", "Repository/"]
COPY ["weatherService/Repository.Abstractions/Repository.Abstractions.csproj", "Repository.Abstractions/"]
COPY ["weatherService/Service/Service.csproj", "Service/"]
COPY ["weatherService/Service.Abstractions/Service.Abstractions.csproj", "Service.Abstractions/"]

RUN dotnet restore "Api/Api.csproj"
COPY . .
WORKDIR "/weatherService/weatherService/Api"
RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]