using FluentValidation;
using Models.Core;

namespace Validation.Validators;

public class EventValidator : AbstractValidator<EventModel>
{
    public EventValidator()
    {
        RuleFor(model => model.Name).NotEmpty().MaximumLength(50).WithMessage("The name mustn't be longer than 50 chars");
        RuleFor(model => model.Place).NotNull().NotEmpty();
        RuleFor(model => model.MeetupDate).NotEmpty().GreaterThan(DateTime.UtcNow);
    }
}