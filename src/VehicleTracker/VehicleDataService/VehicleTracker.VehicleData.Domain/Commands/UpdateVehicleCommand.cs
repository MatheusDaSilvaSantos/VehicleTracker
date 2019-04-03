using System;
using VehicleTracker.VehicleData.Domain.Validations;

namespace VehicleTracker.VehicleData.Domain.Commands
{
    public class UpdateVehicleCommand : VehicleCommand
    {
        public UpdateVehicleCommand(Guid id, string vehicleId, string regNumber, Guid customerId)
        {
            Id = id;
            VehicleId = vehicleId;
            RegNumber = regNumber;
            CustomerId = customerId;

        }



        public override bool IsValid()
        {
            ValidationResult = new UpdateVehicleCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}