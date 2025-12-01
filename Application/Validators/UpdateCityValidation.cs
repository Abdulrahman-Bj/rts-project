using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class UpdateCityValidation: AbstractValidator<UpdateCityRequestDto>
    {
        public UpdateCityValidation()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3).MaximumLength(20);
            
        }
        
    }
}