using PositionCalculator.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionCalculator.Calculators
{
    public static class BoxPositionCalculator
    {
        public static Dictionary<string, PositionModel> Calculate(DataSet dsData)
        {
            Dictionary<string, PositionModel> traderPositions = new Dictionary<string, PositionModel>();

            foreach (DataRow dr in dsData.Tables[0].Rows)
            {
                if (traderPositions.ContainsKey(dr["trader"].ToString()))
                {
                    AddinExistingTraderInfo(traderPositions, dr);

                }
                else
                {
                    AddNewTraderInfo(traderPositions, dr);
                }

            }

            return CalculateResults(traderPositions);
            
        }

        private static Dictionary<string, PositionModel> CalculateResults(Dictionary<string, PositionModel> traderPositions)
        {
            Dictionary<string, PositionModel> result = new Dictionary<string, PositionModel>();
            foreach (var traderInfo in traderPositions)
            {
                foreach (var distinctSymbolData in traderInfo.Value.Symbol.GroupBy(r => r.Symbol))
                {
                    foreach (var symbolData in distinctSymbolData)
                    {
                        if (symbolData.Quantity < 0 && distinctSymbolData.Count()>1 &&
                            distinctSymbolData.Select(r => r.Broker).Distinct().Count() > 0)
                        {
                            var longValuesSum = distinctSymbolData.Where(r => r.Quantity > 0);
                            decimal sumLong = longValuesSum.Sum(r => r.Quantity);

                            var shortValuesSum = distinctSymbolData.Where(r => r.Quantity < 0);
                            decimal sumShort = shortValuesSum.Sum(r => Math.Abs(r.Quantity));
                            
                            SymbolData resultData = new SymbolData();
                            resultData.IsBoxed = true;
                            resultData.Quantity = Math.Min(sumLong, sumShort); 
                            resultData.Symbol = symbolData.Symbol;
                            PositionModel positionResult = new PositionModel();
                            List<SymbolData> lstSymbolData = new List<SymbolData>();
                            lstSymbolData.Add(resultData);
                            positionResult.Symbol = lstSymbolData;
                            result.Add(traderInfo.Key, positionResult);
                            

                        }
                    }
                }
            }
            return result;
        }

        private static void AddNewTraderInfo(Dictionary<string, PositionModel> traderPositions, DataRow dr)
        {
            PositionModel pmData = new PositionModel();
            SymbolData symbolData = new SymbolData();

            symbolData.Symbol = dr["symbol"].ToString();
            symbolData.Quantity = Convert.ToDecimal(dr["quantity"].ToString());
            symbolData.Broker = dr["broker"].ToString();
            pmData.Symbol.Add(symbolData);

            traderPositions.Add(dr["trader"].ToString(), pmData);
        }

        private static void AddinExistingTraderInfo(Dictionary<string, PositionModel> traderPositions, DataRow dr)
        {
            var postions = traderPositions[dr["trader"].ToString()];
            SymbolData symbolData = new SymbolData();
            var symbol = postions.Symbol.Where(r => r.Symbol == dr["symbol"].ToString()).ToList();
            //if (symbol.Count() > 0 && symbol.Last().Broker != dr["broker"].ToString())
            //{
            //    symbol.First().Quantity += Convert.ToDecimal(dr["quantity"].ToString());
            //}
            //else
            //{
                symbolData.Symbol = dr["symbol"].ToString();
                symbolData.Quantity = Convert.ToDecimal(dr["quantity"].ToString());
                symbolData.Broker = dr["broker"].ToString();
                postions.Symbol.Add(symbolData);
            //}
        }
    }
}
