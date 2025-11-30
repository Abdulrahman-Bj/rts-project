using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class RoomDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }

        public ICollection<ServiceDto> services { get; set; } = new List<ServiceDto>();
        public ICollection<RoomImageDto> Images { get; set; } = new List<RoomImageDto>();

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}
