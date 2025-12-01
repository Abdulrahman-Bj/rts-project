using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DTOs
{
    public class AddHotelRequestDto
    {

        public string Name { get; set; }
        public string Address { get; set; }
        [NotMapped]
        public IFormFile CoverImage { get; set; }
        public IFormFile[] Images { get; set; }
        public Guid CityId { get; set; }
        public DateTime CreatedAt => DateTime.UtcNow;

    }
}
