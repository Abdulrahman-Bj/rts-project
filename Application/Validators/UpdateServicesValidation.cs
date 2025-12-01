using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class UpdateServicesValidation: AbstractValidator<UpdateServiceRequestDto>
    {
        public UpdateServicesValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.IconFile).NotEmpty();
        }
    }
}