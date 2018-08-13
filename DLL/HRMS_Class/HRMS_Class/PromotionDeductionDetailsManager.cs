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
    public class PromotionDeductionDetailsManager
    {
        const string PromotionDeductionDetailsTable = "PromotionDeductionDetails";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public PromotionDeductionDetails objGetPromotionDeductionDetails(string EmployeeId)
        {
            PromotionDeductionDetails argPromotionDeductionDetails = new PromotionDeductionDetails();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetPromotionDeductionDetails4ID(EmployeeId.ToString().Trim());

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argPromotionDeductionDetails = this.objCretePromotionDeductionDetails((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

        return argPromotionDeductionDetails;
        }   

        private PromotionDeductionDetails objCretePromotionDeductionDetails(DataRow dr)
        {
            PromotionDeductionDetails tPromotionDeductionDetails = new PromotionDeductionDetails();

            tPromotionDeductionDetails.SetObjectInfo(dr);

            return tPromotionDeductionDetails;
        }

        public DataSet GetPromotionDeductionDetails()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetPromotionDeductionDetails", param);
            return DataSetToFill;
        }

        public DataSet GetPromotionDeductionDetails4ID(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetPromotionDeductionDetails4ID", param);
            return DataSetToFill;
        }

        public DataSet GetPromotionDeductionDetails4Check(int EmployeePromotionNo, string EmployeeId, int ItemNo)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmployeePromotionNo", EmployeePromotionNo);
            param[1] = new SqlParameter("@EmployeeId", EmployeeId);
            param[2] = new SqlParameter("@ItemNo", ItemNo);
            DataSetToFill = da.FillDataSet("Proc_GetPromotionDeductionDetails4Check", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeDeductionDetails4Check(string EmployeeId, int ItemNo)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            param[1] = new SqlParameter("@ItemNo", ItemNo);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeDeductionDetails4Check", param);
            return DataSetToFill;
        }

        public ICollection<ErrorHandlerClass> SavePromotionDeductionDetails(PromotionDeductionDetails objPromotionDeductionDetails)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();
                string strretValue = "";
                if (blnIsPromotionDeductionDetailsExist(objPromotionDeductionDetails.EmployeePromotionNo,objPromotionDeductionDetails.EmployeeId, objPromotionDeductionDetails.ItemNo) == false)
                {
                    strretValue = InsertPromotionDeductionDetails(objPromotionDeductionDetails, da, lstErr);

                    if (strretValue != "")
                    {
                        if (blnIsEmployeeDeductionDetailsExist(objPromotionDeductionDetails.EmployeeId, objPromotionDeductionDetails.ItemNo) == true)
                        {
                            UpdateEmployeePromotionDeductionDetails(objPromotionDeductionDetails, da, lstErr);
                        }
                        else
                        {
                            InsertEmployeePromotionDeductionDetails(objPromotionDeductionDetails, da, lstErr);
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
                    //UpdatePromotionDeductionDetails(objPromotionDeductionDetails, da, lstErr);
                    //foreach (ErrorHandlerClass objerr in lstErr)
                    //{
                    //    if (objerr.Type == "E")
                    //    {
                    //        da.ROLLBACK_TRANSACTION();
                    //        return lstErr;
                    //    }
                    //}
                    //da.COMMIT_TRANSACTION();
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

        public string InsertPromotionDeductionDetails(PromotionDeductionDetails argPromotionDeductionDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[18];
            param[0] = new SqlParameter("@EmployeeId", argPromotionDeductionDetails.EmployeeId);
            param[1] = new SqlParameter("@Deductions", argPromotionDeductionDetails.Deductions);
            param[2] = new SqlParameter("@DeductionPercetage", argPromotionDeductionDetails.DeductionPercetage);
            param[3] = new SqlParameter("@DeductionAmount", argPromotionDeductionDetails.DeductionAmount);
            param[4] = new SqlParameter("@DeductionCalcOn", argPromotionDeductionDetails.DeductionCalcOn);
            param[5] = new SqlParameter("@DeductionPayMode", argPromotionDeductionDetails.DeductionPayMode);
            param[6] = new SqlParameter("@DeductionLimit", argPromotionDeductionDetails.DeductionLimit);

            param[7] = new SqlParameter("@CreatedBy", argPromotionDeductionDetails.CreatedBy);
            param[8] = new SqlParameter("@ModifiedBy", argPromotionDeductionDetails.ModifiedBy);
            param[9] = new SqlParameter("@ItemNo", argPromotionDeductionDetails.ItemNo);
            param[10] = new SqlParameter("@LimitAmount", argPromotionDeductionDetails.LimitAmount);
            param[11] = new SqlParameter("@NewDeductionAmount", argPromotionDeductionDetails.NewDeductionAmount);
            param[12] = new SqlParameter("@NewLimitAmount", argPromotionDeductionDetails.NewLimitAmount);
            param[13] = new SqlParameter("@NewDeductionLimit", argPromotionDeductionDetails.NewDeductionLimit);
            param[14] = new SqlParameter("@EmployeePromotionNo", argPromotionDeductionDetails.EmployeePromotionNo);

            param[15] = new SqlParameter("@Type", SqlDbType.Char);
            param[15].Size = 1;
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[16].Size = 255;
            param[16].Direction = ParameterDirection.Output;

            param[17] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[17].Size = 20;
            param[17].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_InsertPromotionDeductionDetails", param);

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
            return strRetValue;
        }

        public void UpdatePromotionDeductionDetails(PromotionDeductionDetails argPromotionDeductionDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[17];
            param[0] = new SqlParameter("@EmployeeId", argPromotionDeductionDetails.EmployeeId);
            param[1] = new SqlParameter("@Deductions", argPromotionDeductionDetails.Deductions);
            param[2] = new SqlParameter("@DeductionPercetage", argPromotionDeductionDetails.DeductionPercetage);
            param[3] = new SqlParameter("@DeductionAmount", argPromotionDeductionDetails.DeductionAmount);
            param[4] = new SqlParameter("@DeductionCalcOn", argPromotionDeductionDetails.DeductionCalcOn);
            param[5] = new SqlParameter("@DeductionPayMode", argPromotionDeductionDetails.DeductionPayMode);
            param[6] = new SqlParameter("@DeductionLimit", argPromotionDeductionDetails.DeductionLimit);

            param[7] = new SqlParameter("@ModifiedBy", argPromotionDeductionDetails.ModifiedBy);
            param[8] = new SqlParameter("@ItemNo", argPromotionDeductionDetails.ItemNo);
            param[9] = new SqlParameter("@LimitAmount", argPromotionDeductionDetails.LimitAmount);
            param[10] = new SqlParameter("@NewDeductionAmount", argPromotionDeductionDetails.NewDeductionAmount);
            param[11] = new SqlParameter("@NewLimitAmount", argPromotionDeductionDetails.NewLimitAmount);
            param[12] = new SqlParameter("@NewDeductionLimit", argPromotionDeductionDetails.NewDeductionLimit);
            param[13] = new SqlParameter("@EmployeePromotionNo", argPromotionDeductionDetails.EmployeePromotionNo);

            param[14] = new SqlParameter("@Type", SqlDbType.Char);
            param[14].Size = 1;
            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[15].Size = 255;
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[16].Size = 20;
            param[16].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_UpdatePromotionDeductionDetails", param);

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

        public void InsertEmployeePromotionDeductionDetails(PromotionDeductionDetails argPromotionDeductionDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@EmployeeId", argPromotionDeductionDetails.EmployeeId);
            param[1] = new SqlParameter("@Deductions", argPromotionDeductionDetails.Deductions);
            param[2] = new SqlParameter("@DeductionPercetage", argPromotionDeductionDetails.DeductionPercetage);
            param[3] = new SqlParameter("@DeductionAmount", argPromotionDeductionDetails.NewDeductionAmount);
            param[4] = new SqlParameter("@DeductionCalcOn", argPromotionDeductionDetails.DeductionCalcOn);
            param[5] = new SqlParameter("@DeductionPayMode", argPromotionDeductionDetails.DeductionPayMode);
            param[6] = new SqlParameter("@DeductionLimit", argPromotionDeductionDetails.NewDeductionLimit);

            param[7] = new SqlParameter("@CreatedBy", argPromotionDeductionDetails.CreatedBy);
            param[8] = new SqlParameter("@ModifiedBy", argPromotionDeductionDetails.ModifiedBy);
            param[9] = new SqlParameter("@ItemNo", argPromotionDeductionDetails.ItemNo);
            param[10] = new SqlParameter("@LimitAmount", argPromotionDeductionDetails.NewLimitAmount);

            param[11] = new SqlParameter("@Type", SqlDbType.Char);
            param[11].Size = 1;
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[12].Size = 255;
            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[13].Size = 20;
            param[13].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_InsertEmployeeDeductionDetails", param);

            string strMessage = Convert.ToString(param[12].Value);
            string strType = Convert.ToString(param[11].Value);
            string strRetValue = Convert.ToString(param[13].Value);

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

        public void UpdateEmployeePromotionDeductionDetails(PromotionDeductionDetails argPromotionDeductionDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@EmployeeId", argPromotionDeductionDetails.EmployeeId);
            param[1] = new SqlParameter("@Deductions", argPromotionDeductionDetails.Deductions);
            param[2] = new SqlParameter("@DeductionPercetage", argPromotionDeductionDetails.DeductionPercetage);
            param[3] = new SqlParameter("@DeductionAmount", argPromotionDeductionDetails.NewDeductionAmount);
            param[4] = new SqlParameter("@DeductionCalcOn", argPromotionDeductionDetails.DeductionCalcOn);
            param[5] = new SqlParameter("@DeductionPayMode", argPromotionDeductionDetails.DeductionPayMode);
            param[6] = new SqlParameter("@DeductionLimit", argPromotionDeductionDetails.NewDeductionLimit);

            param[7] = new SqlParameter("@ModifiedBy", argPromotionDeductionDetails.ModifiedBy);
            param[8] = new SqlParameter("@ItemNo", argPromotionDeductionDetails.ItemNo);
            param[9] = new SqlParameter("@LimitAmount", argPromotionDeductionDetails.NewLimitAmount);

            param[10] = new SqlParameter("@Type", SqlDbType.Char);
            param[10].Size = 1;
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[11].Size = 255;
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[12].Size = 20;
            param[12].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_UpdateEmployeeDeductionDetails", param);

            string strMessage = Convert.ToString(param[11].Value);
            string strType = Convert.ToString(param[10].Value);
            string strRetValue = Convert.ToString(param[12].Value);

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

        public ICollection<ErrorHandlerClass> DeletePromotionDeductionDetails(string argEmployeeId, int iIsDeleted)
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
                int i = da.ExecuteNonQuery("Proc_DeletePromotionDeductionDetails", param);

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

        public bool blnIsPromotionDeductionDetailsExist(int EmployeePromotionNo, string EmplyeeId, int ItemNo)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetPromotionDeductionDetails4Check(EmployeePromotionNo,EmplyeeId, ItemNo);
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

        public bool blnIsEmployeeDeductionDetailsExist(string EmplyeeId, int ItemNo)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetEmployeeDeductionDetails4Check(EmplyeeId, ItemNo);
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

        public DataSet GetMaxItemNo4Deduction(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetMaxItemNo4Deduction", param);
            return DataSetToFill;
        }

    }
}
