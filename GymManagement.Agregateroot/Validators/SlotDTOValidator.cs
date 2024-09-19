using FluentValidation;
using GymManagement.DTO;

namespace GymManagement.Agregateroot.Validators
{
    public class SlotDTOValidator : AbstractValidator<SlotDTO>
    {
        public SlotDTOValidator()
        {
            RuleFor(slot => slot.SlotName)
                .NotEmpty().WithMessage("Slot name is required.")
                .Length(2, 50).WithMessage("Slot name must be between 2 and 50 characters.");

            RuleFor(slot => slot.SlotTime)
                .NotEmpty().WithMessage("Slot time is required.");
                //.Must(BeAValidTime).WithMessage("Slot time must be a valid time.");

            RuleFor(slot => slot.ClassesIncluded)
                .NotEmpty().WithMessage("Classes included is required.");

            RuleFor(slot => slot.IsBooked)
                .NotNull().WithMessage("Booking status must be specified.");

            RuleFor(slot => slot.TrainerId)
                .GreaterThan(0).WithMessage("Trainer ID must be greater than zero.");

            RuleFor(slot => slot.TrainerName)
                .NotEmpty().WithMessage("Trainer name is required.")
                .Length(2, 50).WithMessage("Trainer name must be between 2 and 50 characters.");
        }

        //private bool BeAValidTime(TimeSpan slotTime)
        //{
        //    return slotTime.TotalMinutes >= 0 && slotTime.TotalMinutes < 1440; // 24 hours in minutes
        //}
    }
}
