using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public string Name { get; set; }

        public Guid CityId { get; set; }

        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }
    }
}
