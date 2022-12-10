using FluentValidation;
using Models.Core;

namespace Validation.Validators;

public class EventValidator : AbstractValidator<EventModel>
{
    public EventValidator()
    {
        RuleFor(model => model.Name)
            .NotNull()
            .WithMessage("Please ensure you have entered your {PropertyName}");
        RuleFor(model => model.Plan)
            .NotNull();
        RuleFor(model => model.MeetupDate)
            .NotEmpty()
            .GreaterThan(DateTime.UtcNow);
        RuleFor(model => model.Place)
            .NotNull()
            .WithMessage("Please ensure you have entered eour {PropertyName}");
    }
}