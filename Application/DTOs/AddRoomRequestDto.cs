using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AddRoomRequestDto
    {
        public Guid Id => Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid HotelId { get; set; }
        [Required]
        [NotMapped]
        public IFormFile CoverImage { get; set; }
        [Required]
        public IFormFile[] Images { get; set; }
        [Required]
        public decimal DailyPrice { get; set; }
        [Required]
        public decimal WeeklyPrice { get; set; }
        [Required]
        public decimal MonthlyPrice { get; set; }

        public int? Discount { get; set; }
        public string? DiscountType { get; set; }


        public ICollection<Guid> ServiceIds { get; set; }

        public DateTime CreatedAt => DateTime.UtcNow;

    }
}
