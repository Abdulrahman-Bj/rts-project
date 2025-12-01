using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class AddCurrencyValidation : AbstractValidator<AddCurrencyRequestDto>
    {
        public AddCurrencyValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Code).NotEmpty().Length(3,4);
            RuleFor(x => x.ExchangeRateToDefault).NotEmpty();
            RuleFor(x => x.IsDefault).NotEmpty();
        }
        
    }
}