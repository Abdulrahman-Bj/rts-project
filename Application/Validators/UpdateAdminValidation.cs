using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class UpdateAdminValidation : AbstractValidator<UpdateAdminRequestDto>
    {
        public UpdateAdminValidation()
        {
            RuleFor(x => x.Username).NotEmpty().MinimumLength(5).MaximumLength(20);
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
        }
    }
}
