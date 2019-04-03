using System;
using VehicleTracker.VehicleData.Domain.Validations;

namespace VehicleTracker.VehicleData.Domain.Commands
{
    public class RemoveVehicleCommand : VehicleCommand
    {
        public RemoveVehicleCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveVehicleCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}