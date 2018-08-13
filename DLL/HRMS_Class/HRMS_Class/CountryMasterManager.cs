using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HRMS_Connection;
using ErrorHandler;

namespace HRMS_Class
{
    public class CountryMasterManager
    {
        public DataSet GetCountryMaster()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetCountryMaster", param);
            return DataSetToFill;
        }

        public DataSet GetCountryMaster4Id(string CountryCode)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CountryCode", CountryCode);
            DataSetToFill = da.FillDataSet("Proc_GetCountryMaster4Id", param);
            return DataSetToFill;
        }
    }
}
