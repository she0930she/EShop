﻿FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV CustomerDB="Server=tcp:multiservicedbserver.database.windows.net,1433;Initial Catalog=multiCustomerDb;Persist Security Info=False;User ID=multiservicedbadmin;Password=yourStrong1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CustomerService/CustomerAPI/CustomerAPI.csproj", "CustomerService/CustomerAPI/"]
RUN dotnet restore "CustomerService/CustomerAPI/CustomerAPI.csproj"
COPY . .
WORKDIR "/src/CustomerService/CustomerAPI"
RUN dotnet build "CustomerAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CustomerAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerAPI.dll"]
