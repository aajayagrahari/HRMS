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
    public class EmployeeLeaveDetailsManager
    {
        const string EmployeeLeaveDetailsTable = "EmployeeLeaveDetails";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public EmployeeLeaveDetails objGetEmployeeLeaveDetails(string EmployeeId)
        {
            EmployeeLeaveDetails argEmployeeLeaveDetails = new EmployeeLeaveDetails();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetEmployeeLeaveDetails4ID(EmployeeId.ToString().Trim());

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argEmployeeLeaveDetails = this.objCreteEmployeeLeaveDetails((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

        return argEmployeeLeaveDetails;
        }

        private EmployeeLeaveDetails objCreteEmployeeLeaveDetails(DataRow dr)
        {
            EmployeeLeaveDetails tEmployeeLeaveDetails = new EmployeeLeaveDetails();

            tEmployeeLeaveDetails.SetObjectInfo(dr);

            return tEmployeeLeaveDetails;

        }
        public DataSet GetMaxEmployeeLeaveId()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetMaxEmployeeLeaveId", param);
            return DataSetToFill;
        }
        public DataSet GetEmployeeLeaveDetails()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeLeaveDetails", param);
            return DataSetToFill;
        }
        
        public DataSet GetEmployeeLeaveDetails4ID(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeLeaveDetails4ID", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeLeaveDetails4Check(string EmployeeId, int ItemNo)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            param[1] = new SqlParameter("@ItemNo", ItemNo);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeLeaveDetails4Check", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeLeaveDetails4Grid(string strEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", strEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeLeaveDetails4Grid", param);
            return DataSetToFill;
        }

        public void SaveEmployeeLeaveDetails(EmployeeLeaveDetails objEmployeeLeaveDetails, ref DataAccess da, ref List<ErrorHandlerClass> lstErr)
        {
            try
            {
                if (blnIsEmployeeLeaveDetailsExist(objEmployeeLeaveDetails.EmployeeId, objEmployeeLeaveDetails.ItemNo) == false)
                {
                    InsertEmployeeLeaveDetails(objEmployeeLeaveDetails, da, lstErr);
                }
                else
                {
                    UpdateEmployeeLeaveDetails(objEmployeeLeaveDetails, da, lstErr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<ErrorHandlerClass> SaveEmployeeLeaveDetails(EmployeeLeaveDetails objEmployeeLeaveDetails)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (blnIsEmployeeLeaveDetailsExist(objEmployeeLeaveDetails.EmployeeId,objEmployeeLeaveDetails.ItemNo) == false)
                {
                    InsertEmployeeLeaveDetails(objEmployeeLeaveDetails, da, lstErr);

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
                    UpdateEmployeeLeaveDetails(objEmployeeLeaveDetails, da, lstErr);
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

        public void InsertEmployeeLeaveDetails(EmployeeLeaveDetails argEmployeeLeaveDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[18];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeLeaveDetails.EmployeeId);
            param[1] = new SqlParameter("@LeaveType", argEmployeeLeaveDetails.LeaveType);
            param[2] = new SqlParameter("@Opening", argEmployeeLeaveDetails.Opening);
            param[3] = new SqlParameter("@MonthlyEarnedType", argEmployeeLeaveDetails.MonthlyEarnedType);
            param[4] = new SqlParameter("@MonthlyEarned", argEmployeeLeaveDetails.MonthlyEarned);
            param[5] = new SqlParameter("@EarningLeaveAllowedAfter", argEmployeeLeaveDetails.EarningLeaveAllowedAfter);
            param[6] = new SqlParameter("@EarningLeaveIn", argEmployeeLeaveDetails.EarningLeaveIn);
            param[7] = new SqlParameter("@ConsumedEL", argEmployeeLeaveDetails.ConsumedEL);
            param[8] = new SqlParameter("@CasulLeaveAllowedAfter", argEmployeeLeaveDetails.CasulLeaveAllowedAfter);
            param[9] = new SqlParameter("@CasualLeaveAllowedIn", argEmployeeLeaveDetails.CasualLeaveAllowedIn);
            param[10] = new SqlParameter("@EarnedCL", argEmployeeLeaveDetails.EarnedCL);

            param[11] = new SqlParameter("@CreatedBy", argEmployeeLeaveDetails.CreatedBy);
            param[12] = new SqlParameter("@ModifiedBy", argEmployeeLeaveDetails.ModifiedBy);
            param[13] = new SqlParameter("@ItemNo", argEmployeeLeaveDetails.ItemNo);

            param[14] = new SqlParameter("@Type", SqlDbType.Char);
            param[14].Size = 1;
            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[15].Size = 255;
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[16].Size = 20;
            param[16].Direction = ParameterDirection.Output;
            param[17] = new SqlParameter("@EmployeeLeaveId", argEmployeeLeaveDetails.EmployeeLeaveId);
            int i = da.NExecuteNonQuery("Proc_InsertEmployeeLeaveDetails", param);

            string strMessage = Convert.ToString(param[15].Value);
            string strType = Convert.ToString(param[14].Value);
            string strRetValue = Convert.ToString(param[16].Value);

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

        public void UpdateEmployeeLeaveDetails(EmployeeLeaveDetails argEmployeeLeaveDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[17];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeLeaveDetails.EmployeeId);
            param[1] = new SqlParameter("@LeaveType", argEmployeeLeaveDetails.LeaveType);
            param[2] = new SqlParameter("@Opening", argEmployeeLeaveDetails.Opening);
            param[3] = new SqlParameter("@MonthlyEarnedType", argEmployeeLeaveDetails.MonthlyEarnedType);
            param[4] = new SqlParameter("@MonthlyEarned", argEmployeeLeaveDetails.MonthlyEarned);
            param[5] = new SqlParameter("@EarningLeaveAllowedAfter", argEmployeeLeaveDetails.EarningLeaveAllowedAfter);
            param[6] = new SqlParameter("@EarningLeaveIn", argEmployeeLeaveDetails.EarningLeaveIn);
            param[7] = new SqlParameter("@ConsumedEL", argEmployeeLeaveDetails.ConsumedEL);
            param[8] = new SqlParameter("@CasulLeaveAllowedAfter", argEmployeeLeaveDetails.CasulLeaveAllowedAfter);
            param[9] = new SqlParameter("@CasualLeaveAllowedIn", argEmployeeLeaveDetails.CasualLeaveAllowedIn);
            param[10] = new SqlParameter("@EarnedCL ", argEmployeeLeaveDetails.EarnedCL);

            param[11] = new SqlParameter("@ModifiedBy", argEmployeeLeaveDetails.ModifiedBy);
            param[12] = new SqlParameter("@ItemNo", argEmployeeLeaveDetails.ItemNo);

            param[13] = new SqlParameter("@Type", SqlDbType.Char);
            param[13].Size = 1;
            param[13].Direction = ParameterDirection.Output;

            param[14] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[14].Size = 255;
            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[15].Size = 20;
            param[15].Direction = ParameterDirection.Output;
            param[16] = new SqlParameter("@EmployeeLeaveId", argEmployeeLeaveDetails.EmployeeLeaveId);
            int i = da.NExecuteNonQuery("Proc_UpdateEmployeeLeaveDetails", param);

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
            //return i;
        }

        public ICollection<ErrorHandlerClass> DeleteEmployeeLeaveDetails(string argEmployeeId, int iIsDeleted, string ModifiedBy, string ItemNo, string EmployeeLeaveId)
        {
            DataAccess da = new DataAccess();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            try
            {
                SqlParameter[] param = new SqlParameter[8];
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
                param[5] = new SqlParameter("@ItemNo", ItemNo);
                param[6] = new SqlParameter("@EmployeeLeaveId", EmployeeLeaveId);
                param[7] = new SqlParameter("@ModifiedBy", ModifiedBy);
                int i = da.ExecuteNonQuery("Proc_DeleteEmployeeLeaveDetails", param);

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

        public bool blnIsEmployeeLeaveDetailsExist(string EmplyeeId, int ItemNo)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetEmployeeLeaveDetails4Check(EmplyeeId, ItemNo);
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

    }
}
