using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateVenderRequestDto
    {
        [Required]
        public string Name { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        public Guid HotelId { get; set; }
        public DateTime UpdatedAt => DateTime.UtcNow;
    }
}
