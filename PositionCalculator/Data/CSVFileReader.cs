using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Configuration;

namespace PositionCalculator.Data
{
    public class CSVFileReader : IDataReader
    {
        private string _connectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source = " +
         "{0}; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"";

        public DataSet LoadData()
        {
            DataSet dsResult;

            string fileName = ConfigurationManager.AppSettings["CSVFilePath"];
            _connectionString = string.Format(_connectionString, Path.GetDirectoryName(fileName));
            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            {
                conn.Open();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + Path.GetFileName(fileName), conn))
                {
                    dsResult = new DataSet("CSVData");
                    adapter.Fill(dsResult);
                }

            }
            return dsResult;
            
        }
    }
}
