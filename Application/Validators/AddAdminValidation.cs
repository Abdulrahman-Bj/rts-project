using Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class AddAdminValidation : AbstractValidator<AddAdminRequestDto>
    {
        public AddAdminValidation()
        {
            RuleFor(x => x.Username).NotEmpty().MinimumLength(5).MaximumLength(20);
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.PasswordConfirm).NotEmpty().MinimumLength(8).Equal(x => x.Password).WithMessage("Password do not matches");
        }
    }
}
