using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MillionBeauty
{
    public static class DataSetFactory
    {
        public static DataSet CustomersTable()
        {
            return DatabaseBuilder.Instance.CustomersTable;
        }
    }
}
