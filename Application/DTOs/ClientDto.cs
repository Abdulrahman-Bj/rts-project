using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ClientDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string CountryCode { get; set; }
        public CityDto City { get; set; }

        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }
    }
}
