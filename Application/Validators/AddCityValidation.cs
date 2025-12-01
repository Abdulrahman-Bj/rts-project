using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class AddCityValidation: AbstractValidator<AddCityRequestDto>
    {
        public AddCityValidation()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3).MaximumLength(20);
            
        }
        
    }
}