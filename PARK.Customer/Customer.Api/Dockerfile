#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://*:80

FROM mcr.microsoft.com/dotnet/sdk:6.0.101-alpine3.14-amd64 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["PARK.Customer/Customer.Api/Customer.Api.csproj", "PARK.Customer/Customer.Api/"]
COPY ["PARK.Customer/Customer.Writer/Customer.Writer.csproj", "PARK.Customer/Customer.Writer/"]
COPY ["PARK.Customer/Customer.Domain/Customer.Domain.csproj", "PARK.Customer/Customer.Domain/"]
COPY ["PARK.Customer/Customer.Infrastructure.Ioc/Customer.Infrastructure.Ioc.csproj", "PARK.Customer/Customer.Infrastructure.Ioc/"]
COPY ["PARK.Customer/Customer.Application/Customer.Application.csproj", "PARK.Customer/Customer.Application/"]
COPY ["PARK.Customer/Customer.Infrastructure.Data/Customer.Infrastructure.Data.csproj", "PARK.Customer/Customer.Infrastructure.Data/"]
COPY ["PARK.Customer/Customer.Infrastructure/Customer.Infrastructure.csproj", "PARK.Customer/Customer.Infrastructure/"]
RUN dotnet restore "PARK.Customer/Customer.Api/Customer.Api.csproj" --verbosity minimal --configfile ./NuGet.Config
COPY . .
WORKDIR "/src/PARK.Customer/Customer.Api"
RUN dotnet build "Customer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer.Api.dll", "--server.urls", "--environment=Development"]