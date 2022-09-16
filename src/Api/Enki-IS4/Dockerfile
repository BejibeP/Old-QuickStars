#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Enki-IS4/Enki-IS4.csproj", "Enki-IS4/"]
RUN dotnet restore "Enki-IS4/Enki-IS4.csproj"
COPY . .
WORKDIR "/src/Enki-IS4"
RUN dotnet build "Enki-IS4.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Enki-IS4.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Enki-IS4.dll"]