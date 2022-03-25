# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src/ShoppingCart
COPY . .
RUN dotnet restore "ShoppingCartApi.csproj"
RUN dotnet build "ShoppingCartApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingCartApi.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingCartApi.dll"]

