using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ReservationCalendarDto
    {
        public DateOnly Date { get; set; }
        public bool IsReserved { get; set; }
    }
}
