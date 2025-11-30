using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class InputValidationException : Exception
    {
        public InputValidationException(string message) : base(message) { }

    }
}
