FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
WORKDIR /src

COPY ["Portfolio.Api.csproj", "./"]
RUN dotnet restore "Portfolio.Api.csproj"

COPY . .
RUN dotnet build "Portfolio.Api.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine
WORKDIR /app

COPY --from=build /app/build .

EXPOSE 8080
EXPOSE 8443

ENTRYPOINT ["dotnet", "Portfolio.Api.dll"]

