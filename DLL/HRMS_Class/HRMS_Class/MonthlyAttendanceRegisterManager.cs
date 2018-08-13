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

#region Developnet Detatil
//Developer Name: Shruti Dwivedi
//Date:           19-09-2013
#endregion Developnet Detatil

namespace HRMS_Class
{
    public class MonthlyAttendanceRegisterManager
    {
        const string MonthlyAttendanceRegisterTable = "MonthlyAttendanceRegister";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public MonthlyAttendanceRegister objGetMonthlyAttendanceRegister(string EmployeeId, string AttendanceId)
        {
            MonthlyAttendanceRegister argMonthlyAttendanceRegister = new MonthlyAttendanceRegister();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetMonthlyAttendanceRegister4ID(EmployeeId.ToString().Trim(), AttendanceId);

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argMonthlyAttendanceRegister = this.objCreteMonthlyAttendanceRegister((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

        return argMonthlyAttendanceRegister;
        }

        private MonthlyAttendanceRegister objCreteMonthlyAttendanceRegister(DataRow dr)
        {
            MonthlyAttendanceRegister tMonthlyAttendanceRegister = new MonthlyAttendanceRegister();

            tMonthlyAttendanceRegister.SetObjectInfo(dr);

            return tMonthlyAttendanceRegister;

        }

        public DataSet GetMonthlyAttendanceRegister4Month(string Month,string Year)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Month",Month);
            param[1] = new SqlParameter("@Year",Year);
            DataSetToFill = da.FillDataSet("Proc_GetMonthlyAttendance4Month", param);
            return DataSetToFill;
        }

        public DataSet GetMonthlyAttendanceRegister()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetMonthlyAttendanceRegister", param);
            return DataSetToFill;
        }

        public DataSet GetMonthlyAttendanceRegisterDetails4Grid(string argEmployeeId, int Month, int Year)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            param[1] = new SqlParameter("@Month", Month);
            param[2] = new SqlParameter("@Year", Year);
            DataSetToFill = da.FillDataSet("Proc_GetMonthlyAttendanceRegisterDetails4Grid", param);
            return DataSetToFill;
        }

        public DataSet GetMonthlyAttendanceRegister4ID(string argEmployeeId, string argAttendanceDate)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            param[1] = new SqlParameter("@AttendanceDate", argAttendanceDate);
            DataSetToFill = da.FillDataSet("Proc_GetMonthlyAttendanceRegister4Id", param);
            return DataSetToFill;
        }

        public DataSet GetMonthlyAttendanceRegister4Check(string argEmployeeId, string argAttendanceDate)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            param[1] = new SqlParameter("@AttendanceDate", argAttendanceDate);
            DataSetToFill = da.FillDataSet("Proc_GetMonthlyAttendanceRegister4Check", param);
            return DataSetToFill;
        }

        public DataSet GetMonthlyAttendanceRegisterDetails(string argEmployeeId, int argMonth, int argYear)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            param[1] = new SqlParameter("@Month", argMonth);
            param[2] = new SqlParameter("@Year", argYear);
            DataSetToFill = da.FillDataSet("Proc_GetMonthlyAttendanceRegisterDetails", param);
            return DataSetToFill;
        }

        public ICollection<ErrorHandlerClass> SaveMonthlyAttendanceRegister(MonthlyAttendanceRegister objMonthlyAttendanceRegister)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (blnIsMonthlyAttendanceRegisterExist(objMonthlyAttendanceRegister.EmployeeId, objMonthlyAttendanceRegister.AttendanceDate) == false)
                {
                    InsertMonthlyAttendanceRegister(objMonthlyAttendanceRegister, da, lstErr);

                    foreach (ErrorHandlerClass objerr in lstErr)
                    {
                        if (objerr.Type == "E")
                        {
                            da.ROLLBACK_TRANSACTION();
                            return lstErr;
                        }
                    }
                    da.COMMIT_TRANSACTION();
                }
                else
                {
                    UpdateMonthlyAttendanceRegister(objMonthlyAttendanceRegister, da, lstErr);
                    
                    foreach (ErrorHandlerClass objerr in lstErr)
                    {
                        if (objerr.Type == "E")
                        {
                            da.ROLLBACK_TRANSACTION();
                            return lstErr;
                        }
                    }
                    da.COMMIT_TRANSACTION();
                }
            }
            catch (Exception ex)
            {
                if (da != null)
                {
                    da.ROLLBACK_TRANSACTION();
                }
                objErrorHandlerClass.Type = ErrorConstant.strAboartType;
                objErrorHandlerClass.MsgId = 0;
                objErrorHandlerClass.Message = ex.Message.ToString();
                objErrorHandlerClass.RowNo = 0;
                objErrorHandlerClass.FieldName = "";
                objErrorHandlerClass.LogCode = "";
                lstErr.Add(objErrorHandlerClass);
            }
            finally
            {
                if (da != null)
                {
                    da.Close_Connection();
                    da = null;
                }
            }
            return lstErr;
        }

        public void InsertMonthlyAttendanceRegister(MonthlyAttendanceRegister argMonthlyAttendanceRegister, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@EmployeeId", argMonthlyAttendanceRegister.EmployeeId);
            param[1] = new SqlParameter("@AttendanceDate", argMonthlyAttendanceRegister.AttendanceDate);
            param[2] = new SqlParameter("@MarkInTime", argMonthlyAttendanceRegister.MarkInTime);
            param[3] = new SqlParameter("@UpdatedMarkInTime", argMonthlyAttendanceRegister.UpdatedMarkInTime);
            param[4] = new SqlParameter("@MarkOutTime", argMonthlyAttendanceRegister.MarkOutTime);
            param[5] = new SqlParameter("@UpdatedMarkOutTime", argMonthlyAttendanceRegister.UpdatedMarkOutTime);
            param[6] = new SqlParameter("@Status", argMonthlyAttendanceRegister.Status);

            param[7] = new SqlParameter("@CreatedBy", argMonthlyAttendanceRegister.CreatedBy);
            param[8] = new SqlParameter("@ModifiedBy", argMonthlyAttendanceRegister.ModifiedBy);
            param[9] = new SqlParameter("@Remarks", argMonthlyAttendanceRegister.Remarks);
            param[10] = new SqlParameter("@Month", argMonthlyAttendanceRegister.Month);
            param[11] = new SqlParameter("@Year", argMonthlyAttendanceRegister.Year);

            param[12] = new SqlParameter("@Type", SqlDbType.Char);
            param[12].Size = 1;
            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[13].Size = 255;
            param[13].Direction = ParameterDirection.Output;

            param[14] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[14].Size = 20;
            param[14].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_InsertMonthlyAttendanceRegister", param);

            string strMessage = Convert.ToString(param[13].Value);
            string strType = Convert.ToString(param[12].Value);
            string strRetValue = Convert.ToString(param[14].Value);

            objErrorHandlerClass.Type = strType;
            objErrorHandlerClass.MsgId = 0;
            objErrorHandlerClass.Message = strMessage.ToString();
            objErrorHandlerClass.RowNo = 0;
            objErrorHandlerClass.FieldName = "";
            objErrorHandlerClass.LogCode = "";
            objErrorHandlerClass.ReturnValue = strRetValue;
            lstErr.Add(objErrorHandlerClass);
            //return i;
        }

        public void UpdateMonthlyAttendanceRegister(MonthlyAttendanceRegister argMonthlyAttendanceRegister, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@EmployeeId", argMonthlyAttendanceRegister.EmployeeId);
            param[1] = new SqlParameter("@AttendanceDate", argMonthlyAttendanceRegister.AttendanceDate);
            param[2] = new SqlParameter("@MarkOutTime", argMonthlyAttendanceRegister.MarkOutTime);
            param[3] = new SqlParameter("@Status", argMonthlyAttendanceRegister.Status);

            param[4] = new SqlParameter("@ModifiedBy", argMonthlyAttendanceRegister.ModifiedBy);
            param[5] = new SqlParameter("@Remarks", argMonthlyAttendanceRegister.Remarks);
            param[6] = new SqlParameter("@Month", argMonthlyAttendanceRegister.Month);
            param[7] = new SqlParameter("@Year", argMonthlyAttendanceRegister.Year);

            param[8] = new SqlParameter("@Type", SqlDbType.Char);
            param[8].Size = 1;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[9].Size = 255;
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[10].Size = 20;
            param[10].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_UpdateMonthlyAttendanceRegister", param);

            string strMessage = Convert.ToString(param[9].Value);
            string strType = Convert.ToString(param[8].Value);
            string strRetValue = Convert.ToString(param[10].Value);

            objErrorHandlerClass.Type = strType;
            objErrorHandlerClass.MsgId = 0;
            objErrorHandlerClass.Message = strMessage.ToString();
            objErrorHandlerClass.RowNo = 0;
            objErrorHandlerClass.FieldName = "";
            objErrorHandlerClass.LogCode = "";
            objErrorHandlerClass.ReturnValue = strRetValue;
            lstErr.Add(objErrorHandlerClass);
            //return i;
        }

        public ICollection<ErrorHandlerClass> DeleteMonthlyAttendanceRegister(string argEmployeeId, int iIsDeleted)
        {
            DataAccess da = new DataAccess();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
                param[1] = new SqlParameter("@IsDeleted", iIsDeleted);

                param[2] = new SqlParameter("@Type", SqlDbType.Char);
                param[2].Size = 1;
                param[2].Direction = ParameterDirection.Output;

                param[3] = new SqlParameter("@Message", SqlDbType.VarChar);
                param[3].Size = 255;
                param[3].Direction = ParameterDirection.Output;

                param[4] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
                param[4].Size = 20;
                param[4].Direction = ParameterDirection.Output;
                int i = da.ExecuteNonQuery("Proc_DeleteEmployeeJobDetails", param);

                string strMessage = Convert.ToString(param[3].Value);
                string strType = Convert.ToString(param[2].Value);
                string strRetValue = Convert.ToString(param[4].Value);

                objErrorHandlerClass.Type = strType;
                objErrorHandlerClass.MsgId = 0;
                objErrorHandlerClass.Message = strMessage.ToString();
                objErrorHandlerClass.RowNo = 0;
                objErrorHandlerClass.FieldName = "";
                objErrorHandlerClass.LogCode = "";
                objErrorHandlerClass.ReturnValue = strRetValue;
                lstErr.Add(objErrorHandlerClass);
            }
            catch (Exception ex)
            {
                objErrorHandlerClass.Type = ErrorConstant.strAboartType;
                objErrorHandlerClass.MsgId = 0;
                objErrorHandlerClass.Message = ex.Message.ToString();
                objErrorHandlerClass.RowNo = 0;
                objErrorHandlerClass.FieldName = "";
                objErrorHandlerClass.LogCode = "";
                lstErr.Add(objErrorHandlerClass);
            }
            return lstErr;
        }

        public bool blnIsMonthlyAttendanceRegisterExist(string EmplyeeId, string AttendanceDate)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetMonthlyAttendanceRegister4Check(EmplyeeId, AttendanceDate);
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                IsEmplyeeExist = true;
            }
            else
            {
                IsEmplyeeExist = false;
            }
            return IsEmplyeeExist;
        }

        public DataSet GetMonthlyAttendanceCalender(string EmployeeId,string month,string year)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            param[1] = new SqlParameter("@month", month);
            param[2] = new SqlParameter("@year", year);
            DataSetToFill = da.FillDataSet("Proc_GetMonthlyAttendanceCalender", param);
            return DataSetToFill;
        }

       

    }
}
