using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class AddHotelValidation : AbstractValidator<AddHotelRequestDto>
    {
        public AddHotelValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.CoverImage).NotEmpty();
            RuleFor(x => x.Images).NotEmpty();
            RuleFor(x => x.CityId).NotEmpty();
        }
        
    }
}