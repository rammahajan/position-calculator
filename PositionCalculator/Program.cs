using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PositionCalculator.Calculators;
using PositionCalculator.Data;

namespace PositionCalculator
{
    class Program
    {
        static Data.IDataReader dataReader;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter 1 for Net position results and 2 for Boxed position result");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    NetPostionsResults();
                }
                else if (input == "2")
                {
                    BoxPostionsResults();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
        }

        private static void NetPostionsResults()
        {  
            dataReader = DataFactory.GetDataFactory("CSV");
            DataSet dsData = dataReader.LoadData();
            var result= NetPositionCalculator.Calculate(dsData);
            OutputCreator.Save(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "NetPostion.csv"), result);
        }

        private static void BoxPostionsResults()
        {
            dataReader = DataFactory.GetDataFactory("CSV");
            DataSet dsData = dataReader.LoadData();
            var result = BoxPositionCalculator.Calculate(dsData);
            OutputCreator.Save(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "BoxPostion.csv"), result);
        }
    }
}
