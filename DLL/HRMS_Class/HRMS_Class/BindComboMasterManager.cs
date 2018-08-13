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
    public class BindComboMasterManager
    {
       
        public DataTable BindCountry()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetCountry4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindState(string CountryCode)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CountryCode", CountryCode);
            DataSetToFill = da.FillDataSet("Proc_GetState4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindUserType()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetUserType4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindSalaryType()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetSalaryType4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindEmployeeType()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeType4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindCategory()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetCategory4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindOTRateType()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetOTRateType4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindLateRateType()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetLateRateType4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindMonth()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetMonth4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindAllowance()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetAllowance4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindCalcOn()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetCalcOn4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindPaymentMode()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetPaymentMode4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindDeductions()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetDeductions4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindLeaveType()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetLeaveType4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindDepartment()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetDepartment4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindDesignation()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetDesignation4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindLeftReason()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetLeftReason4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindPFDeptLeavingReason()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetPFDeptLeavingReason4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindESIDeptLeavingReason()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetESIDeptLeavingReason4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindEmployeeCode()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeCode4Combo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindLeaveNature()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@uType", "GetLeaveNature");
            DataSetToFill = da.FillDataSet("Proc_BindAllCombo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable GetAllEmployee()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@uType", "GetAllEmployee");
            DataSetToFill = da.FillDataSet("Proc_BindAllCombo", param);
            return DataSetToFill.Tables[0];
        }

        public DataTable BindEmployeeId()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeId4Combo", param);
            return DataSetToFill.Tables[0];
        }
    }
}
