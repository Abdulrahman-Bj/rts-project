using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateAdminRequestDto
    {
        public string Name { get; set; }
        public string Username { get; set; }

        public DateTime UpdatedAt => DateTime.UtcNow;
    }
}
