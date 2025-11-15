using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AddVenderRequestDto
    {
        [Required]
        public string Name { get; set; }
        public string Type => "Vender";

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordConfirm { get; set; }
        [Required]
        public Guid HotelId { get; set; }
        public DateTime CreatedAt => DateTime.UtcNow;
    }
}
