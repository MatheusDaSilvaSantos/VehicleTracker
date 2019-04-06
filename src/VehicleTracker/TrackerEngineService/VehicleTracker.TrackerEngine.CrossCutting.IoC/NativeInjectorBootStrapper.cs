using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.Abstract.Domain.Core.Events;
using VehicleTracker.Abstract.Domain.Core.Interfaces;
using VehicleTracker.Abstract.Domain.Core.Notifications;
using VehicleTracker.TrackerEngine.Application.Interfaces;
using VehicleTracker.TrackerEngine.Application.Services;
using VehicleTracker.TrackerEngine.Domain.CommandHandlers;
using VehicleTracker.TrackerEngine.Domain.Commands;
using VehicleTracker.TrackerEngine.Domain.EventHandlers;
using VehicleTracker.TrackerEngine.Domain.Events;
using VehicleTracker.TrackerEngine.Domain.Interfaces;
using VehicleTracker.TrackerEngine.Domain.Models;
using VehicleTracker.TrackerEngine.Domain.StatusService;
using VehicleTracker.TrackerEngine.Infra.Data.Context;
using VehicleTracker.TrackerEngine.Infra.Data.EventSourcing;
using VehicleTracker.TrackerEngine.Infra.Data.Repository;
using VehicleTracker.TrackerEngine.Infra.Data.ServiceBusService;
using VehicleTracker.TrackerEngine.Infra.Data.StorageTableService;

namespace VehicleTracker.TrackerEngine.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();


            // Application
            services.AddScoped<IVehiclePingAppService, VehiclePingAppService>();
            services.AddScoped<IVehiclesConnectionStatusService, VehiclesConnectionStatusService>();


            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<VehiclePingedEvent>, VehiclePingEventHandler>();
  

            // Domain - Commands
            services.AddScoped<IRequestHandler<VehiclePingCommand, bool>, VehiclePingCommandHandler>();


            // Infra - Data
            services.AddScoped<IReceiveMessagesService, ReceiveMessagesService>();
            services.AddScoped<ITableRepository<VehiclesConnectionStatus>, TableRepository<VehiclesConnectionStatus>>();
            services.AddScoped<IVehiclesConnectionStatusRepository, VehiclesConnectionStatusRepository>();
            services.AddScoped<IGetCloudTable, GetCloudTable>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }

    }
}
