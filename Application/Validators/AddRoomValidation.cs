using Application.DTOs;
using Domain.Enums;
using FluentValidation;

namespace Application.Validators
{
    public class AddRoomValidation : AbstractValidator<AddRoomRequestDto>
    {

        public AddRoomValidation()
        {
            string[] allowedTypes = ["Sharqiya","Qibliya","GhurfatQat"];
            string[] allowedDsicountTypes = ["Fixed", "Percentage"];

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Type).NotEmpty().Must(x => allowedTypes.Contains(x));
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.HotelId).NotEmpty();
            RuleFor(x => x.CoverImage).NotEmpty();
            RuleFor(x => x.Images).NotEmpty();
            RuleFor(x => x.DailyPrice).NotEmpty();
            RuleFor(x => x.WeeklyPrice).NotEmpty();
            RuleFor(x => x.MonthlyPrice).NotEmpty();
            

        }
        
    }
}