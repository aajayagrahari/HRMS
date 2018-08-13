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
    public class PromotionLeaveDetailsManager
    {
        const string PromotionLeaveDetailsTable = "PromotionLeaveDetails";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public PromotionLeaveDetails objGetPromotionLeaveDetails(string EmployeeId)
        {
            PromotionLeaveDetails argPromotionLeaveDetails = new PromotionLeaveDetails();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetPromotionLeaveDetails4ID(EmployeeId.ToString().Trim());

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argPromotionLeaveDetails = this.objCretePromotionLeaveDetails((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

        return argPromotionLeaveDetails;
        }

        private PromotionLeaveDetails objCretePromotionLeaveDetails(DataRow dr)
        {
            PromotionLeaveDetails tPromotionLeaveDetails = new PromotionLeaveDetails();

            tPromotionLeaveDetails.SetObjectInfo(dr);

            return tPromotionLeaveDetails;

        }

        public DataSet GetPromotionLeaveDetails()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetPromotionLeaveDetails", param);
            return DataSetToFill;
        }

        public DataSet GetPromotionLeaveDetails4ID(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetPromotionLeaveDetails4ID", param);
            return DataSetToFill;
        }

        public DataSet GetPromotionLeaveDetails4Check(int EmployeePromotionNo,string EmployeeId, int ItemNo)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            param[1] = new SqlParameter("@EmployeePromotionNo", EmployeePromotionNo);
            param[2] = new SqlParameter("@ItemNo", ItemNo);
            DataSetToFill = da.FillDataSet("Proc_GetPromotionLeaveDetails4Check", param);
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

        public ICollection<ErrorHandlerClass> SavePromotionLeaveDetails(PromotionLeaveDetails objPromotionLeaveDetails)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();
                string strretValue="";

                if (blnIsPromotionLeaveDetailsExist(objPromotionLeaveDetails.EmployeePromotionNo,objPromotionLeaveDetails.EmployeeId, objPromotionLeaveDetails.ItemNo) == false)
                {
                    strretValue=InsertPromotionLeaveDetails(objPromotionLeaveDetails, da, lstErr);

                    if (strretValue != "")
                    {
                        if (blnIsEmployeeLeaveDetailsExist(objPromotionLeaveDetails.EmployeeId, objPromotionLeaveDetails.ItemNo) == true)
                        {
                            UpdateEmployeePromotionLeaveDetails(objPromotionLeaveDetails, da, lstErr);
                        }
                        else
                        {
                            InsertEmployeePromotionLeaveDetails(objPromotionLeaveDetails, da, lstErr);
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
                else
                {
                    UpdatePromotionLeaveDetails(objPromotionLeaveDetails, da, lstErr);
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

        public string InsertPromotionLeaveDetails(PromotionLeaveDetails argPromotionLeaveDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[19];
            param[0] = new SqlParameter("@EmployeeId", argPromotionLeaveDetails.EmployeeId);
            param[1] = new SqlParameter("@LeaveType", argPromotionLeaveDetails.LeaveType);
            param[2] = new SqlParameter("@Opening", argPromotionLeaveDetails.Opening);
            param[3] = new SqlParameter("@MonthlyEarnedType", argPromotionLeaveDetails.MonthlyEarnedType);
            param[4] = new SqlParameter("@MonthlyEarned", argPromotionLeaveDetails.MonthlyEarned);
            param[5] = new SqlParameter("@EarningLeaveAllowedAfter", argPromotionLeaveDetails.EarningLeaveAllowedAfter);
            param[6] = new SqlParameter("@EarningLeaveIn", argPromotionLeaveDetails.EarningLeaveIn);
            param[7] = new SqlParameter("@ConsumedEL", argPromotionLeaveDetails.ConsumedEL);
            param[8] = new SqlParameter("@CasulLeaveAllowedAfter", argPromotionLeaveDetails.CasulLeaveAllowedAfter);
            param[9] = new SqlParameter("@CasualLeaveAllowedIn", argPromotionLeaveDetails.CasualLeaveAllowedIn);
            param[10] = new SqlParameter("@EarnedCL", argPromotionLeaveDetails.EarnedCL);

            param[11] = new SqlParameter("@CreatedBy", argPromotionLeaveDetails.CreatedBy);
            param[12] = new SqlParameter("@ModifiedBy", argPromotionLeaveDetails.ModifiedBy);
            param[13] = new SqlParameter("@ItemNo", argPromotionLeaveDetails.ItemNo);
            param[14] = new SqlParameter("@NewOpening", argPromotionLeaveDetails.NewOpening);
            param[15] = new SqlParameter("@EmployeePromotionNo", argPromotionLeaveDetails.EmployeePromotionNo);

            param[16] = new SqlParameter("@Type", SqlDbType.Char);
            param[16].Size = 1;
            param[16].Direction = ParameterDirection.Output;

            param[17] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[17].Size = 255;
            param[17].Direction = ParameterDirection.Output;

            param[18] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[18].Size = 20;
            param[18].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_InsertPromotionLeaveDetails", param);

            string strMessage = Convert.ToString(param[17].Value);
            string strType = Convert.ToString(param[16].Value);
            string strRetValue = Convert.ToString(param[18].Value);

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

        public void UpdatePromotionLeaveDetails(PromotionLeaveDetails argPromotionLeaveDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[18];
            param[0] = new SqlParameter("@EmployeeId", argPromotionLeaveDetails.EmployeeId);
            param[1] = new SqlParameter("@LeaveType", argPromotionLeaveDetails.LeaveType);
            param[2] = new SqlParameter("@Opening", argPromotionLeaveDetails.Opening);
            param[3] = new SqlParameter("@MonthlyEarnedType", argPromotionLeaveDetails.MonthlyEarnedType);
            param[4] = new SqlParameter("@MonthlyEarned", argPromotionLeaveDetails.MonthlyEarned);
            param[5] = new SqlParameter("@EarningLeaveAllowedAfter", argPromotionLeaveDetails.EarningLeaveAllowedAfter);
            param[6] = new SqlParameter("@EarningLeaveIn", argPromotionLeaveDetails.EarningLeaveIn);
            param[7] = new SqlParameter("@ConsumedEL", argPromotionLeaveDetails.ConsumedEL);
            param[8] = new SqlParameter("@CasulLeaveAllowedAfter", argPromotionLeaveDetails.CasulLeaveAllowedAfter);
            param[9] = new SqlParameter("@CasualLeaveAllowedIn", argPromotionLeaveDetails.CasualLeaveAllowedIn);
            param[10] = new SqlParameter("@EarnedCL ", argPromotionLeaveDetails.EarnedCL);

            param[11] = new SqlParameter("@ModifiedBy", argPromotionLeaveDetails.ModifiedBy);
            param[12] = new SqlParameter("@ItemNo", argPromotionLeaveDetails.ItemNo);
            param[13] = new SqlParameter("@NewOpening", argPromotionLeaveDetails.NewOpening);
            param[14] = new SqlParameter("@EmployeePromotionNo", argPromotionLeaveDetails.EmployeePromotionNo);

            param[15] = new SqlParameter("@Type", SqlDbType.Char);
            param[15].Size = 1;
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[16].Size = 255;
            param[16].Direction = ParameterDirection.Output;

            param[17] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[17].Size = 20;
            param[17].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_UpdatePromotionLeaveDetails", param);

            string strMessage = Convert.ToString(param[16].Value);
            string strType = Convert.ToString(param[15].Value);
            string strRetValue = Convert.ToString(param[17].Value);

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

        public void InsertEmployeePromotionLeaveDetails(PromotionLeaveDetails argPromotionLeaveDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[17];
            param[0] = new SqlParameter("@EmployeeId", argPromotionLeaveDetails.EmployeeId);
            param[1] = new SqlParameter("@LeaveType", argPromotionLeaveDetails.LeaveType);
            param[2] = new SqlParameter("@Opening", argPromotionLeaveDetails.NewOpening);
            param[3] = new SqlParameter("@MonthlyEarnedType", argPromotionLeaveDetails.MonthlyEarnedType);
            param[4] = new SqlParameter("@MonthlyEarned", argPromotionLeaveDetails.MonthlyEarned);
            param[5] = new SqlParameter("@EarningLeaveAllowedAfter", argPromotionLeaveDetails.EarningLeaveAllowedAfter);
            param[6] = new SqlParameter("@EarningLeaveIn", argPromotionLeaveDetails.EarningLeaveIn);
            param[7] = new SqlParameter("@ConsumedEL", argPromotionLeaveDetails.ConsumedEL);
            param[8] = new SqlParameter("@CasulLeaveAllowedAfter", argPromotionLeaveDetails.CasulLeaveAllowedAfter);
            param[9] = new SqlParameter("@CasualLeaveAllowedIn", argPromotionLeaveDetails.CasualLeaveAllowedIn);
            param[10] = new SqlParameter("@EarnedCL", argPromotionLeaveDetails.EarnedCL);

            param[11] = new SqlParameter("@CreatedBy", argPromotionLeaveDetails.CreatedBy);
            param[12] = new SqlParameter("@ModifiedBy", argPromotionLeaveDetails.ModifiedBy);
            param[13] = new SqlParameter("@ItemNo", argPromotionLeaveDetails.ItemNo);

            param[14] = new SqlParameter("@Type", SqlDbType.Char);
            param[14].Size = 1;
            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[15].Size = 255;
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[16].Size = 20;
            param[16].Direction = ParameterDirection.Output;

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

        public void UpdateEmployeePromotionLeaveDetails(PromotionLeaveDetails argPromotionLeaveDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@EmployeeId", argPromotionLeaveDetails.EmployeeId);
            param[1] = new SqlParameter("@LeaveType", argPromotionLeaveDetails.LeaveType);
            param[2] = new SqlParameter("@Opening", argPromotionLeaveDetails.NewOpening);
            param[3] = new SqlParameter("@MonthlyEarnedType", argPromotionLeaveDetails.MonthlyEarnedType);
            param[4] = new SqlParameter("@MonthlyEarned", argPromotionLeaveDetails.MonthlyEarned);
            param[5] = new SqlParameter("@EarningLeaveAllowedAfter", argPromotionLeaveDetails.EarningLeaveAllowedAfter);
            param[6] = new SqlParameter("@EarningLeaveIn", argPromotionLeaveDetails.EarningLeaveIn);
            param[7] = new SqlParameter("@ConsumedEL", argPromotionLeaveDetails.ConsumedEL);
            param[8] = new SqlParameter("@CasulLeaveAllowedAfter", argPromotionLeaveDetails.CasulLeaveAllowedAfter);
            param[9] = new SqlParameter("@CasualLeaveAllowedIn", argPromotionLeaveDetails.CasualLeaveAllowedIn);
            param[10] = new SqlParameter("@EarnedCL ", argPromotionLeaveDetails.EarnedCL);

            param[11] = new SqlParameter("@ModifiedBy", argPromotionLeaveDetails.ModifiedBy);
            param[12] = new SqlParameter("@ItemNo", argPromotionLeaveDetails.ItemNo);

            param[13] = new SqlParameter("@Type", SqlDbType.Char);
            param[13].Size = 1;
            param[13].Direction = ParameterDirection.Output;

            param[14] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[14].Size = 255;
            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[15].Size = 20;
            param[15].Direction = ParameterDirection.Output;

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

        public ICollection<ErrorHandlerClass> DeletePromotionLeaveDetails(string argEmployeeId, int iIsDeleted)
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
                int i = da.ExecuteNonQuery("Proc_DeletePromotionLeaveDetails", param);

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

        public bool blnIsPromotionLeaveDetailsExist(int EmployeePromotionNo,string EmplyeeId, int ItemNo)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetPromotionLeaveDetails4Check(EmployeePromotionNo,EmplyeeId, ItemNo);
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

        public DataSet GetMaxItemNo4Leave(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetMaxItemNo4Leave", param);
            return DataSetToFill;
        }

    }
}
