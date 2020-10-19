FROM mcr.microsoft.com/dotnet/core/aspnet AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk AS build
WORKDIR /src
COPY ["MicroService.Users.Product.APIs/MicroService.Users.Product.APIs.csproj", "MicroService.Users.Product.APIs/"]
COPY ["MicroService.Users.Data/MicroService.Users.Data.csproj", "MicroService.Users.Data/"]
RUN dotnet restore "MicroService.Users.Product.APIs/MicroService.Users.Product.APIs.csproj"
COPY . .
WORKDIR "/src/MicroService.Users.Product.APIs"
RUN dotnet build "MicroService.Users.Product.APIs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroService.Users.Product.APIs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroService.Users.Product.APIs.dll"]