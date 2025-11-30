using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Hotel : General
    {

        public string Name { get; set; }

        public string Address { get; set; }
        public Guid CityId { get; set; }

        public string CoverImage { get; set; }

        public string[] Images { get; set; }


        // Navigation properties
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        public City City { get; set; }
    }
}
