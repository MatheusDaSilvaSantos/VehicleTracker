using AutoMapper;
using VehicleTracker.TrackerEngine.Application.ViewModels;
using VehicleTracker.TrackerEngine.Domain.Commands;

namespace VehicleTracker.TrackerEngine.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<VehiclePingCommand, VehiclePingViewModel>();
        }
    }
}
