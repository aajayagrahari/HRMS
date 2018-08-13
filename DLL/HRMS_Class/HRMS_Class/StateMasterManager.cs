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
    public class StateMasterManager
    {
        public DataSet GetStateMaster()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetStateMaster", param);
            return DataSetToFill;
        }

        public DataSet GetStateMaster4Id(string StateCode,string CountryCode)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@StateCode", StateCode);
            param[1] = new SqlParameter("@CountryCode", CountryCode);
            DataSetToFill = da.FillDataSet("Proc_GetStateMaster4Id", param);
            return DataSetToFill;
        }
    }
}
