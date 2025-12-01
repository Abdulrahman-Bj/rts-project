using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Guid CoverImageId { get; set; }
        [NotMapped]
        public HotelImage CoverImage { get; set; }



        // Navigation properties
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        public ICollection<HotelImage> Images { get; set; }

        public City City { get; set; }

    }
}
