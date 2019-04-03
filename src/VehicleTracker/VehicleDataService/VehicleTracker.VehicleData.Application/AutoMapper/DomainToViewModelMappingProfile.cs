using AutoMapper;
using VehicleTracker.VehicleData.Application.ViewModels;
using VehicleTracker.VehicleData.Domain.Models;

namespace VehicleTracker.VehicleData.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Vehicle, VehicleViewModel>();
        }
    }
}
