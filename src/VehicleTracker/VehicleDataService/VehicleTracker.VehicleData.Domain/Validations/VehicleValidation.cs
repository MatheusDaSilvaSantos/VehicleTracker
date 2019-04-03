using System;
using FluentValidation;
using VehicleTracker.VehicleData.Domain.Commands;

namespace VehicleTracker.VehicleData.Domain.Validations
{
    public abstract class VehicleValidation<T> : AbstractValidator<T> where T : VehicleCommand
    {
        protected void ValidateVehicleId()
        {
            RuleFor(v => v.VehicleId)
                .NotEmpty().WithMessage("Please ensure you have entered the VehicleId")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateRegNumber()
        {
            RuleFor(v => v.RegNumber)
                .NotEmpty().WithMessage("Please ensure you have entered the RegNumber")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateCustomerId()
        {
            RuleFor(v => v.CustomerId)
                .NotEqual(Guid.Empty);
        }


        protected void ValidateId()
        {
            RuleFor(v => v.Id)
                .NotEqual(Guid.Empty);
        }


    }
}