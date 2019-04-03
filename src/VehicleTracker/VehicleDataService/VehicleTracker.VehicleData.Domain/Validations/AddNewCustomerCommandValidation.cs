using VehicleTracker.VehicleData.Domain.Commands;

namespace VehicleTracker.VehicleData.Domain.Validations
{
    public class AddNewCustomerCommandValidation : CustomerValidation<AddNewCustomerCommand>
    {
        public AddNewCustomerCommandValidation()
        {
            ValidateName();
        }
    }
}