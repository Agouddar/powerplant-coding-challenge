#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8888

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ENGIE.CC.RESTAPI/ENGIE.CC.RESTAPI.csproj", "ENGIE.CC.RESTAPI/"]
RUN dotnet restore "ENGIE.CC.RESTAPI/ENGIE.CC.RESTAPI.csproj"
COPY . .
WORKDIR "/src/ENGIE.CC.RESTAPI"
RUN dotnet build "ENGIE.CC.RESTAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ENGIE.CC.RESTAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ENGIE.CC.RESTAPI.dll"]