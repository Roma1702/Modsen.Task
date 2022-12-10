using FluentValidation;
using Models.Core;

namespace Validation.Validators
{
    public class EventRoleValidator : AbstractValidator<EventRoleModel>
    {
        public EventRoleValidator()
        {
            RuleFor(model => model.Name)
                .NotNull()
                .WithMessage("Please ensure you have entered your {PropertyName}");
            RuleFor(model => model.Role).NotNull();
        }
    }
}
