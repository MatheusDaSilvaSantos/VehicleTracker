using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using VehicleTracker.VehicleData.Application.AutoMapper;

namespace VehicleTracker.VehicleData.Service.Api.Configurations
{
  public static class AutoMapperSetup
  {
      public static void AddAutoMapperSetup(this IServiceCollection services)
      {
          if (services == null) throw new ArgumentNullException(nameof(services));

          services.AddAutoMapper();

          AutoMapperConfig.RegisterMappings();
      }
  }
}