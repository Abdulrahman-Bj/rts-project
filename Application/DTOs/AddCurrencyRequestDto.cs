using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AddCurrencyRequestDto
    {
        [Required]
        [MinLength(3,ErrorMessage ="Name must be more than three characters")]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public decimal ExchangeRateToDefault { get; set; }
        [Required]
        public bool IsDefault { get; set; }
        public DateTime CreatedAt => DateTime.UtcNow;
    }
}
