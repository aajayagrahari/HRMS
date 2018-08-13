using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ErrorHandler;
using HRMS_Class;
using System.Data;
using System.Text;
using HRMS_Connection;

namespace HRMS_Class
{
  public  class ChartMasterManager
    {
      public DataSet LeaveChart()
      {
          DataAccess da = new DataAccess();
          DataSet DataSetToFill = new DataSet();

          SqlParameter[] param = new SqlParameter[1];
          param[0] = new SqlParameter("@uType", "LeaveChart");
          DataSetToFill = da.FillDataSet("Proc_Chart", param);
          return DataSetToFill;
      }
      public DataSet DesignationChart()
      {
          DataAccess da = new DataAccess();
          DataSet DataSetToFill = new DataSet();

          SqlParameter[] param = new SqlParameter[1];
          param[0] = new SqlParameter("@uType", "DesignationChart");
          DataSetToFill = da.FillDataSet("Proc_Chart", param);
          return DataSetToFill;
      }
      public DataSet DepartmentChart()
      {
          DataAccess da = new DataAccess();
          DataSet DataSetToFill = new DataSet();

          SqlParameter[] param = new SqlParameter[1];
          param[0] = new SqlParameter("@uType", "DepartmentChart");
          DataSetToFill = da.FillDataSet("Proc_Chart", param);
          return DataSetToFill;
      }
      public DataSet YearlyJoinChart()
      {
          DataAccess da = new DataAccess();
          DataSet DataSetToFill = new DataSet();

          SqlParameter[] param = new SqlParameter[1];
          param[0] = new SqlParameter("@uType", "YearlyJoinChart");
          DataSetToFill = da.FillDataSet("Proc_Chart", param);
          return DataSetToFill;
      }
    }
}
