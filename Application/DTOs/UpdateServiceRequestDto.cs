using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateServiceRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public string Name { get; set; }

        [Required]
        public string Icon { get; set; }
        public IFormFile? IconFile { get; set; }
        public DateTime UpdatedAt => DateTime.UtcNow;
    }
}
