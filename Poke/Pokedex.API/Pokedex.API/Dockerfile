FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Pokedex.API/Pokedex.API.csproj", "Pokedex.API/"]
RUN dotnet restore "Pokedex.API/Pokedex.API.csproj"
COPY . .
WORKDIR "/src/Pokedex.API"
RUN dotnet build "Pokedex.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Pokedex.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pokedex.API.dll"]