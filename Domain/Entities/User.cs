using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public Guid CityId { get; set; }

        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        // Navigation property
        public City City { get; set; }
    }
}
