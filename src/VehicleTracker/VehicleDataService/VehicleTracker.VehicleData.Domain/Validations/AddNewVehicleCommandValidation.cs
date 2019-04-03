using VehicleTracker.VehicleData.Domain.Commands;

namespace VehicleTracker.VehicleData.Domain.Validations
{
    public class AddNewVehicleCommandValidation : VehicleValidation<AddNewVehicleCommand>
    {
        public AddNewVehicleCommandValidation()
        {
            ValidateVehicleId();
            ValidateRegNumber();
            ValidateCustomerId();
        }
    }
}