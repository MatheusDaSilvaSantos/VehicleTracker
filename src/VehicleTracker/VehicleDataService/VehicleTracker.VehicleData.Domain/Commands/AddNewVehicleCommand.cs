using System;
using VehicleTracker.VehicleData.Domain.Validations;

namespace VehicleTracker.VehicleData.Domain.Commands
{
    public class AddNewVehicleCommand : VehicleCommand
    {
        public AddNewVehicleCommand(string vehicleId, string regNumber, Guid customerId)
        {
            VehicleId = vehicleId;
            RegNumber = regNumber;
            CustomerId = customerId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewVehicleCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}