using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shalom
{
    internal class Tarifa
    {
        public int SedeOrigenId { get; set; }
        public int SedeDestinoId { get; set; }
        public decimal PrecioBase { get; set; }
        public decimal PrecioPorKg { get; set; }
    }
}
