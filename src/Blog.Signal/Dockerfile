#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Blog.Signal/Blog.Signal.csproj", "src/Blog.Signal/"]
RUN dotnet restore "src/Blog.Signal/Blog.Signal.csproj"
COPY . .
WORKDIR "/src/src/Blog.Signal"
RUN dotnet build "Blog.Signal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blog.Signal.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blog.Signal.dll"]