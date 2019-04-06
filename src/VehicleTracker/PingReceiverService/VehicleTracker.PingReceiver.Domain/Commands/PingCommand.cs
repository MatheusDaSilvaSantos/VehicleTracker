using System;
using FluentValidation.Results;
using VehicleTracker.PingReceiver.Domain.Validations;

namespace VehicleTracker.PingReceiver.Domain.Commands
{
    public class PingCommand : BaseCommand
    {
        public PingCommand(Guid id, string vehicleId, DateTime pingTime)
        {
            Id = id;
            VehicleId = vehicleId;
            PingTime = pingTime;
        }

        public override bool IsValid()
        {
            ValidationResult = new PingCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}