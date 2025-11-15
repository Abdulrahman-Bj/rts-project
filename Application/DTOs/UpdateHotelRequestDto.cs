using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateHotelRequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string CoverImage { get; set; }

        [Required]
        public string[] Images { get; set; }

        [Required]
        public Guid CityId { get; set; }

        public DateTime UpdatedAt => DateTime.UtcNow;
    }
}
