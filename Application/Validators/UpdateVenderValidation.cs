using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class UpdateVenderValidation : AbstractValidator<UpdateVenderRequestDto>
    {
        public UpdateVenderValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}