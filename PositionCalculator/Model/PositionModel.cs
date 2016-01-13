using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionCalculator.Model
{
    public class PositionModel
    {
        public string Trader { get; set; }
        public List<SymbolData> Symbol=new List<SymbolData>();
    }
}
