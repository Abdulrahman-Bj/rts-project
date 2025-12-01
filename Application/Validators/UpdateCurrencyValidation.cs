using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class UpdateCurrencyValidation : AbstractValidator<UpdateCurrencyRequestDto>
    {
        public UpdateCurrencyValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Code).NotEmpty().Length(3,4);
            RuleFor(x => x.ExchangeRateToDefault).NotEmpty();
            RuleFor(x => x.IsDefault).NotEmpty();
        }
        
    }
}