using System;
using VehicleTracker.VehicleData.Domain.Validations;

namespace VehicleTracker.VehicleData.Domain.Commands
{
    public class UpdateCustomerCommand : CustomerCommand
    {
        public UpdateCustomerCommand(Guid id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;

        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}