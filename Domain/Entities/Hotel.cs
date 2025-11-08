using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Hotel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
        public Guid CityId { get; set; }

        public Guid VenderId { get; set; }

        public string CoverImage { get; set; }

        public string[] Images { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        // Navigation properties
        public City City { get; set; }
        public Vender Vender { get; set; }
    }
}
