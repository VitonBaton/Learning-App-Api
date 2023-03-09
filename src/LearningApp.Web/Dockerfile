FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LearningApp.Web/LearningApp.Web.csproj", "LearningApp.Web/"]
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
