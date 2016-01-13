using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionCalculator.Model
{
    public class SymbolData
    {
        public string Symbol { get; set; }
        public decimal Quantity { get; set; }
        public string Broker { get; set; }
        public bool IsBoxed { get; set; }
    }
}
