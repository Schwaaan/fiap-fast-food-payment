FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://*:8000;http://*:80;
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["src/FourSix.Application/*.csproj", "FourSix.Application/"]
COPY ["src/FourSix.Domain/*.csproj", "FourSix.Domain/"]
COPY ["src/FourSix.Infrastructure/*.csproj", "FourSix.Infrastructure/"]
COPY ["src/FourSix.WebApi/*.csproj", "FourSix.WebApi/"]

RUN dotnet restore "FourSix.WebApi/FourSix.WebApi.csproj"

COPY . .
WORKDIR src/FourSix.WebApi
RUN dotnet build "FourSix.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FourSix.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
VOLUME /app
ENTRYPOINT ["dotnet", "FourSix.WebApi.dll"]