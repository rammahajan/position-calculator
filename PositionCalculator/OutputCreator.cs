using PositionCalculator.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionCalculator
{
    public static class OutputCreator
    {
        private static string GenerateOutputCSV(Dictionary<string, PositionModel> positions)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("TRADER,SYMBOL,QUANTITY");
            foreach (var trader in positions)
            {
                foreach (var symbol in trader.Value.Symbol)
                {
                    sb.AppendLine(trader.Key + "," + symbol.Symbol + "," + symbol.Quantity);
                }

            }
            return sb.ToString();
        }

        public static void Save(string saveFilePath, Dictionary<string, PositionModel> positions)
        {
            File.WriteAllText(saveFilePath, GenerateOutputCSV(positions));
        }
    }
}
