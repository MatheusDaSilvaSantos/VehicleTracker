using AutoMapper;
using VehicleTracker.PingReceiver.Application.ViewModels;
using VehicleTracker.PingReceiver.Domain.Commands;

namespace VehicleTracker.PingReceiver.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<PingCommand, PingViewModel>();
        }
    }
}
