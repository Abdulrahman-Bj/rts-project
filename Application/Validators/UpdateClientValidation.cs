using Application.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Validators
{
    public class UpdateClientValidation : AbstractValidator<UpdateClientRequestDto>
    {
        public UpdateClientValidation()
        {
            RuleFor(x => x.Phone).NotNull().NotEmpty().MinimumLength(9).MaximumLength(9);
            RuleFor(x => x.CountryCode).NotNull().NotEmpty().MinimumLength(3).MaximumLength(3);
            RuleFor(X => X.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.CityId).NotNull().NotEmpty();
            
        }
        
    }
}