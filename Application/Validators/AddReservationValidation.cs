using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class AddReservationValidation : AbstractValidator<AddReservationRequestDto>
    {
        public AddReservationValidation()
        {
            RuleFor(x => x.RoomId).NotEmpty();
            RuleFor(x => x.StartedAt).NotEmpty().LessThan(x => x.EndedAt).GreaterThan(DateTime.Now)
                .WithMessage("started date van not be in the past");
            RuleFor(x => x.EndedAt).NotEmpty();
            
        }
        
    }
}