FROM mcr.microsoft.com/dotnet/core/aspnet AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk AS build
WORKDIR /src
COPY ["MicroService.User.API/MicroService.User.API.csproj", "MicroService.User.API/"]
COPY ["MicroService.Users.Data/MicroService.Users.Data.csproj", "MicroService.Users.Data/"]
RUN dotnet restore "MicroService.User.API/MicroService.User.API.csproj"
COPY . .
WORKDIR "/src/MicroService.User.API"
RUN dotnet build "MicroService.User.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroService.User.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroService.User.API.dll"]