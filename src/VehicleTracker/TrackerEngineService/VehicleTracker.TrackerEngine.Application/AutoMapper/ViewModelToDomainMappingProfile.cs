using AutoMapper;
using VehicleTracker.TrackerEngine.Application.ViewModels;
using VehicleTracker.TrackerEngine.Domain.Commands;

namespace VehicleTracker.TrackerEngine.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<VehiclePingViewModel, VehiclePingCommand>().ConstructUsing(p =>
                new VehiclePingCommand(p.Id, p.VehicleId, p.PingTime
                ));
        }
    }
}
