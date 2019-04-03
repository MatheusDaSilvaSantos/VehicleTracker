#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["VehicleTracker.Service.ApiGateway/VehicleTracker.Service.ApiGateway.csproj", "VehicleTracker.Service.ApiGateway/"]
RUN dotnet restore "VehicleTracker.Service.ApiGateway/VehicleTracker.Service.ApiGateway.csproj"
COPY . .
WORKDIR "/src/VehicleTracker.Service.ApiGateway"
RUN dotnet build "VehicleTracker.Service.ApiGateway.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VehicleTracker.Service.ApiGateway.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VehicleTracker.Service.ApiGateway.dll"]