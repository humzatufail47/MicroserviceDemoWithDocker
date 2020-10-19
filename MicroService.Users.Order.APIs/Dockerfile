FROM mcr.microsoft.com/dotnet/core/aspnet AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk AS build
WORKDIR /src
COPY ["MicroService.Users.Order.APIs/MicroService.Users.Order.APIs.csproj", "MicroService.Users.Order.APIs/"]
COPY ["MicroService.Users.Data/MicroService.Users.Data.csproj", "MicroService.Users.Data/"]
RUN dotnet restore "MicroService.Users.Order.APIs/MicroService.Users.Order.APIs.csproj"
COPY . .
WORKDIR "/src/MicroService.Users.Order.APIs"
RUN dotnet build "MicroService.Users.Order.APIs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroService.Users.Order.APIs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroService.Users.Order.APIs.dll"]