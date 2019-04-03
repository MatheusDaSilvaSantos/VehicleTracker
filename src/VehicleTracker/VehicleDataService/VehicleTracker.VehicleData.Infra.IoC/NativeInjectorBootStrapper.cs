using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using VehicleTracker.Abstract.Domain.Core.Bus;
using VehicleTracker.Abstract.Domain.Core.Interfaces;
using VehicleTracker.Abstract.Domain.Core.Notifications;
using VehicleTracker.VehicleData.Application.Interfaces;
using VehicleTracker.VehicleData.Application.Services;
using VehicleTracker.VehicleData.Domain.CommandHandlers;
using VehicleTracker.VehicleData.Domain.Commands;
using VehicleTracker.VehicleData.Domain.EventHandlers;
using VehicleTracker.VehicleData.Domain.Events;
using VehicleTracker.VehicleData.Domain.Interfaces;
using VehicleTracker.VehicleData.Infra.Data.Context;
using VehicleTracker.VehicleData.Infra.Data.Repository;
using VehicleTracker.VehicleData.Infra.Data.UoW;

namespace VehicleTracker.VehicleData.Infra.CrossCutting.IoC
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
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IVehicleAppService, VehicleAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerAddedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            services.AddScoped<INotificationHandler<VehicleAddedEvent>, VehicleEventHandler>();
            services.AddScoped<INotificationHandler<VehicleUpdatedEvent>, VehicleEventHandler>();
            services.AddScoped<INotificationHandler<VehicleRemovedEvent>, VehicleEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<AddNewCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, bool>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, bool>, CustomerCommandHandler>();

            services.AddScoped<IRequestHandler<AddNewVehicleCommand, bool>, VehicleCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateVehicleCommand, bool>, VehicleCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveVehicleCommand, bool>, VehicleCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<VehicleDataContext>();


        }
    }
}
