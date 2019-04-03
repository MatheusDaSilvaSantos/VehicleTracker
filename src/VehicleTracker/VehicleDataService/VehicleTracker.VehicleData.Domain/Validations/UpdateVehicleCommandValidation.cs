using VehicleTracker.VehicleData.Domain.Commands;

namespace VehicleTracker.VehicleData.Domain.Validations
{
    public class UpdateVehicleCommandValidation : VehicleValidation<UpdateVehicleCommand>
    {
        public UpdateVehicleCommandValidation()
        {
            ValidateId();
            ValidateRegNumber();
            ValidateVehicleId();
            ValidateCustomerId();
        }
    }
}