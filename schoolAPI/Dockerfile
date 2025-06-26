FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5276

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["schoolAPI.csproj", "."]
RUN dotnet restore "./schoolAPI.csproj"
COPY . .
RUN dotnet publish "schoolAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "schoolAPI.dll", "--urls", "http://+:5276"]