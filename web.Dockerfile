FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/LearningApp.Web", "LearningApp.Web/"]
COPY ["src/LearningApp.Core", "LearningApp.Core/"]
COPY ["src/LearningApp.DataAccess", "LearningApp.DataAccess/"]
COPY ["src/LearningApp.LoggerService", "LearningApp.LoggerService/"]
COPY ["src/LearningApp.Models", "LearningApp.Models/"]
COPY ["src/LearningApp.Services", "LearningApp.Services/"]
COPY ["src/LearningApp.Contracts", "LearningApp.Contracts/"]
RUN dotnet restore "LearningApp.Web/LearningApp.Web.csproj"

COPY . .
WORKDIR "/src/LearningApp.Web"

RUN dotnet build "LearningApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearningApp.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearningApp.Web.dll"]
