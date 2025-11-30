using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AddReservationRequestDto
    {
        [Required]
        public Guid RoomId { get; set; }
        [Required]
        public DateTime StartedAt { get; set; }
        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public DateTime EndedAt { get; set; }

        public string Status => "Pending";

        public DateTime CreatedAt => DateTime.UtcNow;


    }
}
