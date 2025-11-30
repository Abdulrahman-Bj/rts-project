using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reservation : General
    {
        public Guid RoomId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }

        public ReservationStatus Status { get; set; }

        // Navgation properties

        public Room Room { get; set; }
        public Client Client { get; set; }


    }
}
