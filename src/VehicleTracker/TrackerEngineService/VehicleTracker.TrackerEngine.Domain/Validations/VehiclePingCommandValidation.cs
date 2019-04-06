using VehicleTracker.TrackerEngine.Domain.Commands;

namespace VehicleTracker.TrackerEngine.Domain.Validations
{
    public class VehiclePingCommandValidation : BaseValidation<VehiclePingCommand>
    {
        public VehiclePingCommandValidation()
        {
            ValidateVehicleId();
            //ValidatePingTime();
        }
    }
}