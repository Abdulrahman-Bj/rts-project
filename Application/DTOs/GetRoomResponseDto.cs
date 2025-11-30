using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GetRoomResponseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }

        public ICollection<ServiceDto> services { get; set; } = new List<ServiceDto>();
        public ICollection<RoomImageDto> Images { get; set; } = new List<RoomImageDto>();

        public decimal DailyPrice { get; set; }
        public decimal WeeklyPrice { get; set; }
        public decimal MonthlyPrice { get; set; }

        public decimal ConvertedDailyPrice { get; set; }
        public decimal ConvertedWeeklyPrice { get; set; }
        public decimal ConvertedMonthlyPrice { get; set; }

        public int? Discount { get; set; }
        public string? DiscountType { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}
