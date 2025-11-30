using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateRoomRequestDto
    {
        [Required]

        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid HotelId { get; set; }

        [Required]
        public string CoverImage { get; set; }

        [Required]
        public string[] Images { get; set; }

        [Required]
        public decimal DailyPrice { get; set; }
        [Required]
        public decimal WeeklyPrice { get; set; }
        [Required]
        public decimal MonthlyPrice { get; set; }


        public int? Discount { get; set; }
        public DiscountTypes? DiscountType { get; set; }


        public DateTime UpdatedAt => DateTime.UtcNow;
    }
}
