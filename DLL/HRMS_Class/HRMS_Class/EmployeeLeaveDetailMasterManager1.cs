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
//Date:           20-09-2013
#endregion Developnet Detatil

namespace HRMS_Class
{
    public class EmployeeLeaveDetailMasterManager1
    {
        const string EmployeeLeaveDetailTable = "EmployeeLeaveDetail";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public DataSet GetEmployeeLeaveDetailbyEmpId(Int64 EmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeLeaveDetailbyEmpId", param);
            return DataSetToFill;
        }
        public DataSet GetEmployeeLeaveDetail()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();
            SqlParameter[] param = new SqlParameter[0];
            //param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeLeaveDetail", param);
            return DataSetToFill;
        }
        public DataSet GetEmployeeLeaveDetailById(Int64 LeaveId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@LeaveId", LeaveId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeLeaveDetail4Id", param);
            return DataSetToFill;
        }
        public ICollection<ErrorHandlerClass> SaveEmployeeLeaveDetail(EmployeeLeaveDetailMaster1 objEmployeeLeaveDetailMaster1)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                InsertEmployeeLeaveDetail(objEmployeeLeaveDetailMaster1, da, lstErr);

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
        public ICollection<ErrorHandlerClass> UpdateEmployeeLeaveDetail(EmployeeLeaveDetailMaster1 objEmployeeLeaveDetailMaster1)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                UpdateEmployeeLeaveDetail(objEmployeeLeaveDetailMaster1, da, lstErr);

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
        public ICollection<ErrorHandlerClass> DeleteEmployeeLeaveDetail(EmployeeLeaveDetailMaster1 objEmployeeLeaveDetailMaster1)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                DeleteEmployeeLeaveDetail(objEmployeeLeaveDetailMaster1, da, lstErr);

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
        public void InsertEmployeeLeaveDetail(EmployeeLeaveDetailMaster1 argEmployeeLeaveDetailMaster1, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@LeaveId", argEmployeeLeaveDetailMaster1.LeaveId);
            param[1] = new SqlParameter("@EmployeeId", argEmployeeLeaveDetailMaster1.EmployeeId);
            param[2] = new SqlParameter("@FromDate", (argEmployeeLeaveDetailMaster1.FromDate));
            param[3] = new SqlParameter("@FromPeriod", argEmployeeLeaveDetailMaster1.FromPeriod);
            param[4] = new SqlParameter("@ToDate", (argEmployeeLeaveDetailMaster1.ToDate));
            param[5] = new SqlParameter("@ToPeriod", argEmployeeLeaveDetailMaster1.ToPeriod);
            param[6] = new SqlParameter("@Reason", argEmployeeLeaveDetailMaster1.Reason);
            param[7] = new SqlParameter("@CreatedBy", argEmployeeLeaveDetailMaster1.CreatedBy);


            param[8] = new SqlParameter("@Type", SqlDbType.Char);
            param[8].Size = 1;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[9].Size = 255;
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[10].Size = 20;
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@LeaveNatureId", argEmployeeLeaveDetailMaster1.LeaveTypeId);


            int i = da.NExecuteNonQuery("Proc_InsertEmployeeLeaveDetail", param);

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
        public string UpdateEmployeeLeaveDetail(EmployeeLeaveDetailMaster1 argEmployeeLeaveDetailMaster1, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[18];
            param[0] = new SqlParameter("@LeaveId", argEmployeeLeaveDetailMaster1.LeaveId);
            param[1] = new SqlParameter("@EmployeeId", argEmployeeLeaveDetailMaster1.EmployeeId);
            param[2] = new SqlParameter("@FromDate", (argEmployeeLeaveDetailMaster1.FromDate));
            param[3] = new SqlParameter("@FromPeriod", argEmployeeLeaveDetailMaster1.FromPeriod);
            param[4] = new SqlParameter("@ToDate", (argEmployeeLeaveDetailMaster1.ToDate));
            param[5] = new SqlParameter("@ToPeriod", argEmployeeLeaveDetailMaster1.ToPeriod);
            param[6] = new SqlParameter("@Reason", argEmployeeLeaveDetailMaster1.Reason);
            param[7] = new SqlParameter("@ModifiedBy", argEmployeeLeaveDetailMaster1.ModifiedBy);

            param[8] = new SqlParameter("@IsSubmitted", argEmployeeLeaveDetailMaster1.IsSubmitted);
            param[9] = new SqlParameter("@SubmittedDate", argEmployeeLeaveDetailMaster1.SubmittedDate);
            param[10] = new SqlParameter("@IsApproved", argEmployeeLeaveDetailMaster1.IsApproved);
            param[11] = new SqlParameter("@ApprovedBy", argEmployeeLeaveDetailMaster1.ApprovedBy);
            param[12] = new SqlParameter("@ApprovedDate", argEmployeeLeaveDetailMaster1.ApprovedDate);


            param[13] = new SqlParameter("@Type", SqlDbType.Char);
            param[13].Size = 1;
            param[13].Direction = ParameterDirection.Output;

            param[14] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[14].Size = 255;
            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[15].Size = 20;
            param[15].Direction = ParameterDirection.Output;
            param[16] = new SqlParameter("@LeaveNatureId", argEmployeeLeaveDetailMaster1.LeaveTypeId);
            param[17] = new SqlParameter("@Remark", argEmployeeLeaveDetailMaster1.Remark);


            int i = da.NExecuteNonQuery("Proc_UpdateEmployeeLeaveDetail", param);

            string strMessage = Convert.ToString(param[14].Value);
            string strType = Convert.ToString(param[13].Value);
            string strRetValue = Convert.ToString(param[15].Value);

            objErrorHandlerClass.Type = strType;
            objErrorHandlerClass.MsgId = 0;
            objErrorHandlerClass.Message = strMessage.ToString();
            objErrorHandlerClass.RowNo = 0;
            objErrorHandlerClass.FieldName = "";
            objErrorHandlerClass.LogCode = "";
            objErrorHandlerClass.ReturnValue = strRetValue;
            lstErr.Add(objErrorHandlerClass);

            return strRetValue;
        }
        public string DeleteEmployeeLeaveDetail(EmployeeLeaveDetailMaster1 argEmployeeLeaveDetailMaster1, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@LeaveId", argEmployeeLeaveDetailMaster1.LeaveId);
            param[1] = new SqlParameter("@ModifiedBy", argEmployeeLeaveDetailMaster1.ModifiedBy);
            param[2] = new SqlParameter("@Type", SqlDbType.Char);
            param[2].Size = 1;
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[3].Size = 255;
            param[3].Direction = ParameterDirection.Output;

            param[4] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[4].Size = 20;
            param[4].Direction = ParameterDirection.Output;
            //param[5] = new SqlParameter("@IsDeleted", argEmployeeLeaveDetailMaster.IsDeleted);
            int i = da.NExecuteNonQuery("Proc_DeleteEmployeeLeaveDetail", param);

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

            return strRetValue;
        }
    }
}
