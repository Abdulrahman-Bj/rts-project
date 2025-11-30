using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateReservationRequestDto
    {
        [Required]
        public string Status { get; set; }

        public DateTime UpdatedAt => DateTime.UtcNow;

    }
}
