using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionCalculator.Data
{
    public static class DataFactory
    {
        public static IDataReader GetDataFactory(string dataSource)
        {
            IDataReader dataReader=null;
            switch(dataSource)
            {
                case "CSV":
                    dataReader = new CSVFileReader();
                    break;
                case "TestData":
                    dataReader = new TestDataReader();
                    break;
               

            }
            return dataReader;
        }
    }
}
