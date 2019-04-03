using AutoMapper;
using VehicleTracker.VehicleData.Application.ViewModels;
using VehicleTracker.VehicleData.Domain.Commands;

namespace VehicleTracker.VehicleData.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, AddNewCustomerCommand>()
                .ConstructUsing(c => new AddNewCustomerCommand(c.Name, c.Address));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Address));

            CreateMap<VehicleViewModel, AddNewVehicleCommand>()
                .ConstructUsing(v => new AddNewVehicleCommand(v.VehicleId, v.RegNumber, v.CustomerId));
            CreateMap<VehicleViewModel, UpdateVehicleCommand>()
                .ConstructUsing(v => new UpdateVehicleCommand(v.Id, v.VehicleId, v.RegNumber, v.CustomerId));
        }
    }
}
