using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Client : User
    {
        public string Phone { get; set; }
        public string CountryCode { get; set; }
        public Guid CityId { get; set; }

        // Navigation property
        public City City { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
