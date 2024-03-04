FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App
ENV ASPNETCORE_URLS=http://+:5000

# Copy everything
COPY . ./

# Restore as distinct layers
RUN dotnet restore "Stepstone.Api/Stepstone.Api.csproj"

# Build and publish a release
RUN dotnet publish -c Release -o out "Stepstone.Api/Stepstone.Api.csproj"

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
EXPOSE 5000
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "Stepstone.Api.dll", "--server.urls", "http://+:5000"]