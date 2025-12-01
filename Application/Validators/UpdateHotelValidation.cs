using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class UpdateHotelValidation : AbstractValidator<UpdateHotelRequestDto>
    {
        public UpdateHotelValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.CoverImage).NotEmpty();
            RuleFor(x => x.Images).NotEmpty();
            RuleFor(x => x.CityId).NotEmpty();
        }
        
    }
}