using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using FluentValidation;
namespace Application.Validators
{
    public class AddReservationValidator : AbstractValidator<AddReservationRequestDto>
    {
        public AddReservationValidator()
        {
            RuleFor(x => x.RoomId).NotEmpty();
            RuleFor(x => x.StartedAt).LessThan(x => x.EndedAt).WithMessage("Started date can not be bigger than the end date");
            RuleFor(x => x.ClientId).NotEmpty().WithMessage("Provide client id for the user who made the reservation");
        }
    }
}
