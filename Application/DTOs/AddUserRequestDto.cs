using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AddUserRequestDto
    {

        public Guid Id => Guid.NewGuid();
        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public Guid CityId { get; set; }

        public string Type { get; set; }
        public DateTime CreatedAt = DateTime.UtcNow;

    }
}
