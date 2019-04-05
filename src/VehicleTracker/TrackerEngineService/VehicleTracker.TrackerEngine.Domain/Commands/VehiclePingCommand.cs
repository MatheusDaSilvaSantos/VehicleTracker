using System;
using VehicleTracker.TrackerEngine.Domain.Validations;

namespace VehicleTracker.TrackerEngine.Domain.Commands
{
    public class VehiclePingCommand : BaseCommand
    {
        public VehiclePingCommand(Guid id, string vehicleId, TimeSpan pingTime)
        {
            Id = id;
            VehicleId = vehicleId;
            PingTime = pingTime;
        }

        public override bool IsValid()
        {
            ValidationResult = new VehiclePingCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}