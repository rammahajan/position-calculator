using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PositionCalculator.Model;

namespace PositionCalculator.Calculators
{
    public static class NetPositionCalculator
    {
        public static Dictionary<string, PositionModel> Calculate(DataSet dsData)
        {
            Dictionary<string, PositionModel> traderPositions = new Dictionary<string, PositionModel>();

            foreach (DataRow dr in dsData.Tables[0].Rows)
            {
                if (traderPositions.ContainsKey(dr["trader"].ToString()))
                {
                    var postions = traderPositions[dr["trader"].ToString()];
                    SymbolData symbolData = new SymbolData();
                    var symbol = postions.Symbol.Where(r => r.Symbol == dr["symbol"].ToString()).ToList();
                    if (symbol.Count() > 0)
                    {
                        symbol.First().Quantity += Convert.ToDecimal(dr["quantity"].ToString());
                    }
                    else
                    {
                        symbolData.Symbol = dr["symbol"].ToString();
                        symbolData.Quantity = Convert.ToDecimal(dr["quantity"].ToString());
                        postions.Symbol.Add(symbolData);
                    }

                }
                else
                {
                    PositionModel pmData=new PositionModel(); 
                    SymbolData symbolData = new SymbolData();
                    symbolData.Symbol = dr["symbol"].ToString();
                    symbolData.Quantity = Convert.ToDecimal(dr["quantity"].ToString());
                    pmData.Symbol.Add(symbolData);
                    traderPositions.Add(dr["trader"].ToString(), pmData);
                }

            }
            return traderPositions;

            
            
        }
    }
}
