using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Room
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public Guid HotelId { get; set; }

        public string CoverImage { get; set; }

        public string[] Images { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        // Navigation property
        public Hotel Hotel { get; set; }
    }
}
