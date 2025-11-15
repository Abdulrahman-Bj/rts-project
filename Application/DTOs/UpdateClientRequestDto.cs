using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateClientRequestDto
    {
        public string Phone { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public Guid CityId { get; set; }
        public string Type => "Client";
        public DateTime? UpdateAt => DateTime.UtcNow;
    }
}
