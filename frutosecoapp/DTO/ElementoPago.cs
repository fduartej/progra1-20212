using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using frutosecoapp.Models;

namespace frutosecoapp.DTO
{
    public class ElementoPago
    {
        public Decimal MontoTotal { get; set; }
        public List<Proforma> ListProformas { get; set; }
    }
}