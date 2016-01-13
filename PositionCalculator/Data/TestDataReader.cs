using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionCalculator.Data
{
    public class TestDataReader : IDataReader
    {
        public DataSet LoadData()
        {
            DataSet dsResult = new DataSet();

            DataTable dt = new DataTable();
            dt.Columns.Add("trader");
            dt.Columns.Add("broker");
            dt.Columns.Add("symbol");
            dt.Columns.Add("quantity");
            dt.Columns.Add("price");

            DataRow dr1 = dt.NewRow();
            dr1["trader"] = "Anuj";
            dr1["broker"] = "ICICI";
            dr1["symbol"] = "SCI";
            dr1["quantity"] = "120";
            dr1["price"] = "80";

            DataRow dr2 = dt.NewRow();
            dr2["trader"] = "Arya";
            dr2["broker"] = "ICICI";
            dr2["symbol"] = "Rel";
            dr2["quantity"] = "-20";
            dr2["price"] = "3000";

            DataRow dr3 = dt.NewRow();
            dr3["trader"] = "Arya";
            dr3["broker"] = "BNP";
            dr3["symbol"] = "Rel";
            dr3["quantity"] = "50";
            dr3["price"] = "3000";

            DataRow dr4 = dt.NewRow();
            dr4["trader"] = "Misha";
            dr4["broker"] = "SH";
            dr4["symbol"] = "PNB";
            dr4["quantity"] = "-20";
            dr4["price"] = "200";

            DataRow dr5 = dt.NewRow();
            dr5["trader"] = "Misha";
            dr5["broker"] = "BNP";
            dr5["symbol"] = "PNB";
            dr5["quantity"] = "10";
            dr5["price"] = "200";

            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            dt.Rows.Add(dr3);
            dt.Rows.Add(dr4);
            dt.Rows.Add(dr5);

            dsResult.Tables.Add(dt);
            return dsResult;
            
        }
    }
}
