using VehicleTracker.VehicleData.Domain.Commands;

namespace VehicleTracker.VehicleData.Domain.Validations
{
    public class UpdateCustomerCommandValidation : CustomerValidation<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}