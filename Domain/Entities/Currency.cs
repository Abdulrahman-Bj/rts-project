using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Currency : General
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal ExchangeRateToDefault { get; set; }
        public bool IsDefault { get; set; }
    }
}
