using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateCityRequestDto
    {
        public string Name { get; set; }
        public DateTime UpdateAt => DateTime.UtcNow;
    }
}
