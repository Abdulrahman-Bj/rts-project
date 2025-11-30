using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RoomImage
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public string Name { get; set; }
        public Room Room { get; set; }
    }
}
