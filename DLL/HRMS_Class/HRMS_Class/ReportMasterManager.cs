using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ErrorHandler;
using HRMS_Class;
using System.Data;
using System.Text;
using HRMS_Connection;

namespace HRMS_Class
{
   public class ReportMasterManager
   {
       #region Report Visisble at Employee Side
       public DataTable EmployeeAttendanceSummary(Int64 EmployeeId)
       {
           DataAccess da = new DataAccess();
           DataSet DataSetToFill = new DataSet();

           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("@uType", "EmployeeAttendanceSummary");
           param[1] = new SqlParameter("@EmployeeId", EmployeeId);
           //param[2] = new SqlParameter("@year", Year);
           //param[3] = new SqlParameter("@Month", Month);
           DataSetToFill = da.FillDataSet("Proc_Employee", param);
           return DataSetToFill.Tables[0];
       }
       public DataSet CalculateEmployeeSalary(Int64 EmployeeId)
       {
           DataAccess da = new DataAccess();
           DataSet DataSetToFill = new DataSet();

           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("@uType", "CalculateSalary");
           param[1] = new SqlParameter("@EmployeeId", EmployeeId);
           DataSetToFill = da.FillDataSet("Proc_Employee", param);
           return DataSetToFill;
       }
       public DataSet CalculateSalary_MonthWise(Int64 EmployeeId,Int32 Month)
       {
           DataAccess da = new DataAccess();
           DataSet DataSetToFill = new DataSet();

           SqlParameter[] param = new SqlParameter[3];
           param[0] = new SqlParameter("@uType", "CalculateSalary_MonthWise");
           param[1] = new SqlParameter("@EmployeeId", EmployeeId);
           param[2] = new SqlParameter("@Month", Month);
           DataSetToFill = da.FillDataSet("Proc_Employee", param);
           return DataSetToFill;
       }

       public DataSet MyMonthWiseSalarySlip(Int32 Year, Int32 Month, string EmployeeId)
       {
           DataAccess da = new DataAccess();
           DataSet DataSetToFill = new DataSet();

           SqlParameter[] param = new SqlParameter[4];
           param[0] = new SqlParameter("@uType", "MyMonthWiseSalarySlip");
           param[1] = new SqlParameter("@Year", Year);
           param[2] = new SqlParameter("@Month", Month);
           param[3] = new SqlParameter("@EmployeeId", EmployeeId);
           DataSetToFill = da.FillDataSet("Proc_Employee", param);
           return DataSetToFill;
       }
       #endregion  Report Visisble at Employee Side

       #region Report Visisble at Admin Side
       public DataTable AdminAllEmployeeDetails(Int32 Month)
       {
           DataAccess da = new DataAccess();
           DataSet DataSetToFill = new DataSet();
           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("@uType", "AllEmployeeDetails");
           param[1] = new SqlParameter("@Month", Month);
           DataSetToFill = da.FillDataSet("Proc_Admin", param);
           return DataSetToFill.Tables[0];
       }
       public DataSet GenratePaySlip(Int64 EmployeeId)
       {
           DataAccess da = new DataAccess();
           DataSet DataSetToFill = new DataSet();

           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("@uType", "GenratePaySlip");
           param[1] = new SqlParameter("@EmployeeId", EmployeeId);
           DataSetToFill = da.FillDataSet("Proc_Admin", param);
           return DataSetToFill;
       }
       public DataSet PaymentWages(Int32 Year, Int32 Month)
       {
           DataAccess da = new DataAccess();
           DataSet DataSetToFill = new DataSet();

           SqlParameter[] param = new SqlParameter[3];
           param[0] = new SqlParameter("@uType", "PaymentWages");
           param[1] = new SqlParameter("@Year", Year);
           param[2] = new SqlParameter("@Month", Month);
           DataSetToFill = da.FillDataSet("Proc_Admin", param);
           return DataSetToFill;
       }
       public DataSet SystemGenratedMonthlyAttendance(Int32 Year, Int32 Month, string EmployeeId)
       {
           DataAccess da = new DataAccess();
           DataSet DataSetToFill = new DataSet();

           SqlParameter[] param = new SqlParameter[4];
           param[0] = new SqlParameter("@uType", "SystemGenratedMonthlyAttendance");
           param[1] = new SqlParameter("@Year", Year);
           param[2] = new SqlParameter("@Month", Month);
           param[3] = new SqlParameter("@EmployeeId", EmployeeId);
           DataSetToFill = da.FillDataSet("Proc_Admin", param);
           return DataSetToFill;
       }
       public DataSet GetChallan(Int32 Year, Int32 Month)
       {
           DataAccess da = new DataAccess();
           DataSet DataSetToFill = new DataSet();

           SqlParameter[] param = new SqlParameter[3];
           param[0] = new SqlParameter("@uType", "Challan");
           param[1] = new SqlParameter("@Year", Year);
           param[2] = new SqlParameter("@Month", Month);
           DataSetToFill = da.FillDataSet("Proc_Admin", param);
           return DataSetToFill;
       }
       public DataSet GetEsiChallan(Int32 Year, Int32 Month)
       {
           DataAccess da = new DataAccess();
           DataSet DataSetToFill = new DataSet();

           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("@Year", Year);
           param[1] = new SqlParameter("@Month", Month);
           DataSetToFill = da.FillDataSet("Proc_GetEsiChallan", param);
           return DataSetToFill;
       }
       public DataSet PayRegister(Int32 Month)
       {
           DataAccess da = new DataAccess();
           DataSet DataSetToFill = new DataSet();

           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("@uType", "PayRegister");
           param[1] = new SqlParameter("@Month", Month);

           DataSetToFill = da.FillDataSet("Proc_Admin", param);
           return DataSetToFill;
       }
       #endregion Report Visisble at Admin Side
   }
}
