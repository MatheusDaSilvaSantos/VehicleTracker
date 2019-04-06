using VehicleTracker.PingReceiver.Domain.Commands;

namespace VehicleTracker.PingReceiver.Domain.Validations
{
    public class PingCommandValidation : BaseValidation<PingCommand>
    {
        public PingCommandValidation()
        {
            ValidateVehicleId();
            //ValidatePingTime();
        }
    }
}