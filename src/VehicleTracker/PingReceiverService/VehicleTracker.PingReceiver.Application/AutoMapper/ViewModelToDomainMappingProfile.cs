using AutoMapper;
using VehicleTracker.PingReceiver.Application.ViewModels;
using VehicleTracker.PingReceiver.Domain.Commands;

namespace VehicleTracker.PingReceiver.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PingViewModel, PingCommand>().ConstructUsing(p => new PingCommand(p.Id, p.VehicleId, p.PingTime));
        }
    }
}
