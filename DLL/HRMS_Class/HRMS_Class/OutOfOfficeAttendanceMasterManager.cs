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
    public class OutOfOfficeAttendanceMasterManager
    {
        const string OutOfOfficeAttendanceRegisterTable = "OutOfOfficeAttendanceRegister";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public OutOfOfficeAttendanceMaster objGetOutOfOfficeAttendanceMaster(string EmployeeId, string outOfOfficeFrom)
        {
            OutOfOfficeAttendanceMaster argOutOfOfficeAttendanceMaster = new OutOfOfficeAttendanceMaster();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetOutOfOfficeAttendanceMaster4ID(EmployeeId.ToString().Trim(), outOfOfficeFrom);

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argOutOfOfficeAttendanceMaster = this.objCreteOutOfOfficeAttendanceMaster((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

        return argOutOfOfficeAttendanceMaster;
        }

        private OutOfOfficeAttendanceMaster objCreteOutOfOfficeAttendanceMaster(DataRow dr)
        {
            OutOfOfficeAttendanceMaster tOutOfOfficeAttendanceMaster = new OutOfOfficeAttendanceMaster();

            tOutOfOfficeAttendanceMaster.SetObjectInfo(dr);

            return tOutOfOfficeAttendanceMaster;

        }

        public DataSet GetOutOfOfficeAttendanceMaster4Month(string Month,string Year)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@month",Month);
            param[1] = new SqlParameter("@year",Year);
            DataSetToFill = da.FillDataSet("Proc_GetMonthlyAttendance4Month", param);
            return DataSetToFill;
        }

        public DataSet GetOutOfOfficeAttendanceMaster()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetOutOfOfficeAttendanceRegister", param);
            return DataSetToFill;
        }

        public DataSet GetOutOfOfficeAttendanceMaster4Employee(string strEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", strEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetOutOfOfficeAttendanceRegister4Employee", param);
            return DataSetToFill;
        }

        public DataSet GetOutOfOfficeAttendanceMasterDetails4Grid(string argEmployeeId, int Month, int Year)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            param[1] = new SqlParameter("@Month", Month);
            param[2] = new SqlParameter("@Year", Year);
            DataSetToFill = da.FillDataSet("Proc_GetOutOfOfficeAttendanceMasterDetails4Grid", param);
            return DataSetToFill;
        }

        public DataSet GetOutOfOfficeAttendanceMaster4ID(string argEmployeeId, string argOutOfOfficeDateFrom)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            param[1] = new SqlParameter("@OutOfOfficeDateFrom", argOutOfOfficeDateFrom);
            DataSetToFill = da.FillDataSet("Proc_GetOutOfOfficeAttendanceRegister4Id", param);
            return DataSetToFill;
        }

        public DataSet GetOutOfOfficeAttendanceMaster4Check(string argEmployeeId, string argOutOfOfficeDateFrom)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            param[1] = new SqlParameter("@OutOfOfficeDateFrom", argOutOfOfficeDateFrom);
            DataSetToFill = da.FillDataSet("Proc_GetOutOfOfficeAttendanceRegister4Check", param);
            return DataSetToFill;
        }

        public DataSet GetOutOfOfficeAttendanceMasterDetails(string argEmployeeId, int argMonth, int argYear)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            param[1] = new SqlParameter("@Month", argMonth);
            param[2] = new SqlParameter("@Year", argYear);
            DataSetToFill = da.FillDataSet("Proc_GetOutOfOfficeAttendanceMasterDetails", param);
            return DataSetToFill;
        }

        public ICollection<ErrorHandlerClass> SaveOutOfOfficeAttendanceMaster(OutOfOfficeAttendanceMaster objOutOfOfficeAttendanceMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (blnIsOutOfOfficeAttendanceMasterExist(objOutOfOfficeAttendanceMaster.EmployeeId, objOutOfOfficeAttendanceMaster.OutOfOfficeDateFrom) == false)
                {
                    InsertOutOfOfficeAttendanceMaster(objOutOfOfficeAttendanceMaster, da, lstErr);

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
                    UpdateOutOfOfficeAttendanceMaster(objOutOfOfficeAttendanceMaster, da, lstErr);
                    
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

        public void InsertOutOfOfficeAttendanceMaster(OutOfOfficeAttendanceMaster argOutOfOfficeAttendanceMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@EmployeeId", argOutOfOfficeAttendanceMaster.EmployeeId);
            param[1] = new SqlParameter("@OutOfOfficeDateFrom", argOutOfOfficeAttendanceMaster.OutOfOfficeDateFrom);
            param[2] = new SqlParameter("@OutOfOfficeDateTo", argOutOfOfficeAttendanceMaster.OutOfOfficeDateTo);
            param[3] = new SqlParameter("@Purpose", argOutOfOfficeAttendanceMaster.Purpose);
            param[4] = new SqlParameter("@month", argOutOfOfficeAttendanceMaster.month);
            param[5] = new SqlParameter("@year", argOutOfOfficeAttendanceMaster.year);

            param[6] = new SqlParameter("@CreatedBy", argOutOfOfficeAttendanceMaster.CreatedBy);
            param[7] = new SqlParameter("@ModifiedBy", argOutOfOfficeAttendanceMaster.ModifiedBy);

            param[8] = new SqlParameter("@Type", SqlDbType.Char);
            param[8].Size = 1;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[9].Size = 255;
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[10].Size = 20;
            param[10].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_InsertOutOfOfficeAttendanceRegister", param);

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

        public void UpdateOutOfOfficeAttendanceMaster(OutOfOfficeAttendanceMaster argOutOfOfficeAttendanceMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@EmployeeId", argOutOfOfficeAttendanceMaster.EmployeeId);
            param[1] = new SqlParameter("@OutOfOfficeDateFrom", argOutOfOfficeAttendanceMaster.OutOfOfficeDateFrom);
            param[2] = new SqlParameter("@OutOfOfficeDateTo", argOutOfOfficeAttendanceMaster.OutOfOfficeDateTo);
            param[3] = new SqlParameter("@Purpose", argOutOfOfficeAttendanceMaster.Purpose);
            param[4] = new SqlParameter("@month", argOutOfOfficeAttendanceMaster.month);
            param[5] = new SqlParameter("@year", argOutOfOfficeAttendanceMaster.year);

            param[6] = new SqlParameter("@ModifiedBy", argOutOfOfficeAttendanceMaster.ModifiedBy);

            param[7] = new SqlParameter("@Type", SqlDbType.Char);
            param[7].Size = 1;
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[8].Size = 255;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[9].Size = 20;
            param[9].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_UpdateOutOfOfficeAttendanceRegister", param);

            string strMessage = Convert.ToString(param[8].Value);
            string strType = Convert.ToString(param[7].Value);
            string strRetValue = Convert.ToString(param[9].Value);

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

        public ICollection<ErrorHandlerClass> ApproveOutOfOfficeAttendanceByAdmin(ICollection<OutOfOfficeAttendanceMaster> colOutOfOfficeAttendanceMaster)
        {
            DataAccess da = new DataAccess();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (colOutOfOfficeAttendanceMaster.Count > 0)
                {
                    foreach (OutOfOfficeAttendanceMaster argOutOfOfficeAttendanceMaster in colOutOfOfficeAttendanceMaster)
                    {
                        ApproveOutOfOfficeAttendanceByAdmin(argOutOfOfficeAttendanceMaster);
                    }
                }

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
        
        public void ApproveOutOfOfficeAttendanceByAdmin(OutOfOfficeAttendanceMaster argOutOfOfficeAttendanceMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();

            try
            {
                da.Open_Connection();

                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@EmployeeId", argOutOfOfficeAttendanceMaster.EmployeeId);
                param[1] = new SqlParameter("@OutOfOfficeDateFrom", clsConvert.ToDateTime1(argOutOfOfficeAttendanceMaster.OutOfOfficeDateFrom));
                param[2] = new SqlParameter("@Status", argOutOfOfficeAttendanceMaster.Status);
                param[3] = new SqlParameter("@IsApprove", argOutOfOfficeAttendanceMaster.IsApprove);
                param[4] = new SqlParameter("@ApprovedBy", argOutOfOfficeAttendanceMaster.Approvedby);

                param[5] = new SqlParameter("@ModifiedBy", argOutOfOfficeAttendanceMaster.ModifiedBy);

                param[6] = new SqlParameter("@Type", SqlDbType.Char);
                param[6].Size = 1;
                param[6].Direction = ParameterDirection.Output;

                param[7] = new SqlParameter("@Message", SqlDbType.VarChar);
                param[7].Size = 255;
                param[7].Direction = ParameterDirection.Output;

                param[8] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
                param[8].Size = 20;
                param[8].Direction = ParameterDirection.Output;

                int i = da.NExecuteNonQuery("Proc_ApproveOutOfOfficeAttendance4Admin", param);

                string strMessage = Convert.ToString(param[7].Value);
                string strType = Convert.ToString(param[6].Value);
                string strRetValue = Convert.ToString(param[8].Value);

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
                objErrorHandlerClass.Message = ex.Message.ToString();
            }
            //return i;
        }

        public ICollection<ErrorHandlerClass> DeleteOutOfOfficeAttendanceMaster(string argEmployeeId, int iIsDeleted)
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

        public bool blnIsOutOfOfficeAttendanceMasterExist(string EmplyeeId, string AttendanceDate)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetOutOfOfficeAttendanceMaster4Check(EmplyeeId, AttendanceDate);
            
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

        public DataSet GetMonthlyAttendanceCalender(string EmployeeId, string month, string year)
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
