using VehicleTracker.VehicleData.Domain.Commands;

namespace VehicleTracker.VehicleData.Domain.Validations
{
    public class RemoveVehicleCommandValidation : VehicleValidation<RemoveVehicleCommand>
    {
        public RemoveVehicleCommandValidation()
        {
            ValidateId();
        }
    }
}