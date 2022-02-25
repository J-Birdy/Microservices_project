#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Student_API/Student_API.csproj", "Student_API/"]
RUN dotnet restore "Student_API/Student_API.csproj"
COPY . .
WORKDIR "/src/Student_API"
RUN dotnet build "Student_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Student_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Student_API.dll"]