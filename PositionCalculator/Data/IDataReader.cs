using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionCalculator.Data
{
    public interface IDataReader
    {
        DataSet LoadData();
    }
}
