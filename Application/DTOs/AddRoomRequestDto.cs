using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AddRoomRequestDto
    {

        public string Name { get; set; }

        public RoomType Type { get; set; }
        public string Description { get; set; }
        public Guid HotelId { get; set; }

        public string CoverImage { get; set; }

        public string[] Images { get; set; }

        public DateTime CreatedAt => DateTime.UtcNow;

    }
}
