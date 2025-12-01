using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class AddServicesValidation: AbstractValidator<AddServiceRequestDto>
    {
        public AddServicesValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.IconFile).NotEmpty();
        }
    }
}