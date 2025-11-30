using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Service : General
    {
        public String Name { get; set; }
        public string Icon { get; set; }

        // Navigation property
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
