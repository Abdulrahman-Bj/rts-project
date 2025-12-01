using Application.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Validators
{
    public class AddClientValidation : AbstractValidator<AddClientRequestDto>
    {
        public AddClientValidation()
        {
            RuleFor(x => x.Phone).NotNull().NotEmpty().MinimumLength(9).MaximumLength(9);
            RuleFor(x => x.CountryCode).NotNull().NotEmpty().MinimumLength(3).MaximumLength(3);
            RuleFor(X => X.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.CityId).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.PasswordConfirm).NotEmpty().MinimumLength(8).Equal(x => x.Password).WithMessage("Password do not matches");
            
        }
        
    }
}