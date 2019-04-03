using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.Abstract.Domain.Core.Interfaces;
using VehicleTracker.Abstract.Domain.Core.Notifications;
using VehicleTracker.PingReceiver.Application.Interfaces;
using VehicleTracker.PingReceiver.Application.Services;
using VehicleTracker.PingReceiver.Domain.CommandHandlers;
using VehicleTracker.PingReceiver.Domain.Commands;
using VehicleTracker.PingReceiver.Domain.EventHandlers;
using VehicleTracker.PingReceiver.Domain.Events;
using VehicleTracker.PingReceiver.Domain.Interfaces;
using VehicleTracker.PingReceiver.Infra.Data.ServiceBusService;

namespace VehicleTracker.PingReceiver.Infra.CrossCutting.IoC
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
            services.AddScoped<IPingAppService, PingAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<VehiclePingedEvent>, PingEventHandler>();


            // Domain - Commands
            services.AddScoped<IRequestHandler<PingCommand, bool>, PingCommandHandler>();


            // Infra - Data
            services.AddScoped<ISendMessagesService, SendMessagesService>();



        }
    }
}
