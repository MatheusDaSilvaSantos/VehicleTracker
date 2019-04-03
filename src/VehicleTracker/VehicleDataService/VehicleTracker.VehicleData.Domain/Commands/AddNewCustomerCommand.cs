using VehicleTracker.VehicleData.Domain.Validations;

namespace VehicleTracker.VehicleData.Domain.Commands
{
    public class AddNewCustomerCommand : CustomerCommand
    {
        public AddNewCustomerCommand(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}