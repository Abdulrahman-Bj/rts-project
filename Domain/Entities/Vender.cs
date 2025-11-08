using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vender : User
    {
        public Guid HotelId { get; set; }

        // Navigation property
        public Hotel Hotel { get; set; }
    }
}
