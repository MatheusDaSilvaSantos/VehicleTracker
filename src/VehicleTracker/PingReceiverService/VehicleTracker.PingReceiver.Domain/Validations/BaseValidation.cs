using System;
using FluentValidation;
using VehicleTracker.PingReceiver.Domain.Commands;

namespace VehicleTracker.PingReceiver.Domain.Validations
{
    public abstract class BaseValidation<T> : AbstractValidator<T> where T : BaseCommand
    {
        protected void ValidateVehicleId()
        {
            RuleFor(c => c.VehicleId)
                .NotEmpty().WithMessage("Please ensure you have entered the VehicleId");
        }

        protected void ValidatePingTime()
        {
            RuleFor(c => c.PingTime)
                .NotEmpty()
                .Must(HaveMinimumTime)
                .WithMessage("The ping action must be in one minute");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected static bool HaveMinimumTime(TimeSpan pingTime)
        {
            return pingTime <= DateTime.Now.AddMinutes(-1).TimeOfDay;
        }
    }
}