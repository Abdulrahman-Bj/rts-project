using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class AddVenderValidation : AbstractValidator<AddVenderRequestDto>
    {
        public AddVenderValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.PasswordConfirm).NotEmpty().MinimumLength(8).Equal(x => x.Password).WithMessage("Password do not matches");        }
    }
}