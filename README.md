# What is the VehicleTracker? 

 **VehicleTracker** is a soultion written in .NET Core 2.2
 
 The goal of the project is implementing a monitoring connection status of connected vehicles that belong to a number of customers.
 So, a vehicle is either Connected or Disconnected.

# How to use:

- You will need the latest Visual Studio 2017 and the .NET Core SDK 2.2.
- **Please check if you have installed the same runtime version (SDK) described in global.json**
- You will need the latest version of **Azure Storage Emulator**.
	> You can find **Azure Storage Emulator** and how to configuer it here [Azure storage emulator for development and testing](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator).
	> Also you can find  **Azure Storage Explorer**  to be able to view the queue and table data here  [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/).
- The latest SDK and tools can be downloaded from https://dot.net/core.


Also you can run the Project in Visual Studio Code (Windows, Linux or MacOS).

# Solution architectural diagram

<img src="documents/VehicleTracker solution architectural sketch.png" alt="Solution architectural diagram"> 

# Solution Behaviors

-  Every vehicle should call an API **PingReceiverService** to send information about itself like (Id, Auth token for validation) .
	>  The authentication and authorization is out of scope here.
-  **PingReceiverService**  will send a message to a service bus.
	> (will use **Azure storage emulator queue **  to be able to develop it locally as an alternative to Azure service bus).
- **PingQueueTrigger** it's an Azure function queue trigger will listen to the queue and then, will send the received message to the **TrackerEngineService** to perform the tracking connection status logic .
- **TrackerEngineService** will be dequeuing the message from the queue and add or update the ping time in an **Azure storage table**  to get the status from it easily and will bush the status notification via **SignalR Hub** connected to the GUI (ann Angualr 7 SPA app).


# how to run the project

 - 1 - run the azure storegae emilator.
 
for the **Back-End** projects:
-  2 - Run `Update-Database` in this projects:
	  - VehicleTracker.VehicleData.Infra.Data
	  - VehicleTracker.TrackerEngine.Infra.Data
 -  3 - you need to startup this projects :
	  - VehicleTracker.PingReceiver.Service.Api
	 -  VehicleTracker.TrackerEngine.Service.Api
	 -  VehicleTracker.TrackerEngine.PingQueueTrigger
	 -  VehicleTracker.VehicleData.Service.Api
	 -  VehicleTracke.VehicleSimulator.FunctionTrigger
	 -  VehicleTracker.Service.ApiGateway
	 
 for the **Front-End**  (Angular 7 application )
 - 4 - go to `src/GuiApp/VehicleTrackerApp` and Run `npm install` 
 - Run `ng serve -o` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.


## Technologies implemented:

- ASP.NET Core 2.2 (with .NET Core 2.2)
 - ASP.NET WebApi Core
- Entity Framework Core 2.2
- .NET Core Native DI
-  Azure Storage (Queue, Table)
- AutoMapper
- FluentValidator
- MediatR
- SignalR
- Swagger UI
- MS Unit Testing 
- Angualr 7

## Architecture:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Notification
- CQRS (Imediate Consistency)
- Event Sourcing
- Unit of Work
- Repository and Generic Repository


