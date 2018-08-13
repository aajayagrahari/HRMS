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
    public class PromotionEarningDetailsManager
    {
        const string PromotionEarningDetailsTable = "PromotionEarningDetails";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();
        EmployeeEarningDetailsManager objEmployeeEarningDetailsManager = new EmployeeEarningDetailsManager();

        public PromotionEarningDetails objGetPromotionEarningDetails(string EmployeeId)
        {
            PromotionEarningDetails argPromotionEarningDetails = new PromotionEarningDetails();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetPromotionEarningDetails4ID(EmployeeId.ToString().Trim());

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argPromotionEarningDetails = this.objCretePromotionEarningDetails((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

            return argPromotionEarningDetails;
        }

        private PromotionEarningDetails objCretePromotionEarningDetails(DataRow dr)
        {
            PromotionEarningDetails tPromotionEarningDetails = new PromotionEarningDetails();

            tPromotionEarningDetails.SetObjectInfo(dr);

            return tPromotionEarningDetails;
        }

        public DataSet GetPromotionEarningDetails()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetPromotionEarningDetails", param);
            return DataSetToFill;
        }

        public DataSet GetPromotionEarningDetails4ID(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetPromotionEarningDetails4ID", param);
            return DataSetToFill;
        }

        public DataSet GetPromotionEarningDetails4Check(int EmployeePromotionNo, string EmployeeId, int ItemNo)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmployeePromotionNo", EmployeePromotionNo);
            param[1] = new SqlParameter("@EmployeeId", EmployeeId);
            param[2] = new SqlParameter("@ItemNo", ItemNo);
            DataSetToFill = da.FillDataSet("Proc_GetPromotionEarningDetails4Check", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeEarningDetails4Check(string EmployeeId, int ItemNo)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            param[1] = new SqlParameter("@ItemNo", ItemNo);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeEarningDetails4Check", param);
            return DataSetToFill;
        }

        public ICollection<ErrorHandlerClass> SavePromotionEarningDetails(PromotionEarningDetails objPromotionEarningDetails)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            string strretValue="";
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (blnIsPromotionEarningDetailsExist(objPromotionEarningDetails.EmployeePromotionNo,objPromotionEarningDetails.EmployeeId, objPromotionEarningDetails.ItemNo) == false)
                {
                    strretValue=InsertPromotionEarningDetails(objPromotionEarningDetails, da, lstErr);

                    if (strretValue != "")
                    {
                        if (blnIsEmployeeEarningDetailsExist(objPromotionEarningDetails.EmployeeId, objPromotionEarningDetails.ItemNo) == true)
                        {
                            UpdateEmployeePromotionEarningDetails(objPromotionEarningDetails, da, lstErr);
                        }
                        else
                        {
                            InsertEmployeePromotionEarningDetails(objPromotionEarningDetails, da, lstErr);
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
                    UpdatePromotionEarningDetails(objPromotionEarningDetails, da, lstErr);
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

        public string InsertPromotionEarningDetails(PromotionEarningDetails argPromotionEarningDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@EmployeeId", argPromotionEarningDetails.EmployeeId);
            param[1] = new SqlParameter("@Allowances", argPromotionEarningDetails.Allowances);
            param[2] = new SqlParameter("@Amount", argPromotionEarningDetails.Amount);
            param[3] = new SqlParameter("@CalcOn", argPromotionEarningDetails.CalcOn);
            param[4] = new SqlParameter("@PaymentMode", argPromotionEarningDetails.PaymentMode);
            param[5] = new SqlParameter("@Bonus", argPromotionEarningDetails.Bonus);
            param[6] = new SqlParameter("@OT", argPromotionEarningDetails.OT);

            param[7] = new SqlParameter("@CreatedBy", argPromotionEarningDetails.CreatedBy);
            param[8] = new SqlParameter("@ModifiedBy", argPromotionEarningDetails.ModifiedBy);
            param[9] = new SqlParameter("@ItemNo", argPromotionEarningDetails.ItemNo);
            param[10] = new SqlParameter("@NewAmount", argPromotionEarningDetails.NewAmount);
            param[11] = new SqlParameter("@EmployeePromotionNo", argPromotionEarningDetails.EmployeePromotionNo);

            param[12] = new SqlParameter("@Type", SqlDbType.Char);
            param[12].Size = 1;
            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[13].Size = 255;
            param[13].Direction = ParameterDirection.Output;

            param[14] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[14].Size = 20;
            param[14].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_InsertPromotionEarningDetails", param);

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
            return strRetValue;
        }

        public void InsertEmployeePromotionEarningDetails(PromotionEarningDetails argPromotionEarningDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@EmployeeId", argPromotionEarningDetails.EmployeeId);
            param[1] = new SqlParameter("@Allowances", argPromotionEarningDetails.Allowances);
            param[2] = new SqlParameter("@Amount", argPromotionEarningDetails.NewAmount);
            param[3] = new SqlParameter("@CalcOn", argPromotionEarningDetails.CalcOn);
            param[4] = new SqlParameter("@PaymentMode", argPromotionEarningDetails.PaymentMode);
            param[5] = new SqlParameter("@Bonus", argPromotionEarningDetails.Bonus);
            param[6] = new SqlParameter("@OT", argPromotionEarningDetails.OT);

            param[7] = new SqlParameter("@CreatedBy", argPromotionEarningDetails.CreatedBy);
            param[8] = new SqlParameter("@ModifiedBy", argPromotionEarningDetails.ModifiedBy);
            param[9] = new SqlParameter("@ItemNo", argPromotionEarningDetails.ItemNo);

            param[10] = new SqlParameter("@Type", SqlDbType.Char);
            param[10].Size = 1;
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[11].Size = 255;
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[12].Size = 20;
            param[12].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_InsertEmployeeEarningDetails", param);

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
        }

        public void UpdatePromotionEarningDetails(PromotionEarningDetails argPromotionEarningDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@EmployeeId", argPromotionEarningDetails.EmployeeId);
            param[1] = new SqlParameter("@Allowances", argPromotionEarningDetails.Allowances);
            param[2] = new SqlParameter("@Amount", argPromotionEarningDetails.Amount);
            param[3] = new SqlParameter("@CalcOn", argPromotionEarningDetails.CalcOn);
            param[4] = new SqlParameter("@PaymentMode", argPromotionEarningDetails.PaymentMode);
            param[5] = new SqlParameter("@Bonus", argPromotionEarningDetails.Bonus);
            param[6] = new SqlParameter("@OT", argPromotionEarningDetails.OT);

            param[7] = new SqlParameter("@ModifiedBy", argPromotionEarningDetails.ModifiedBy);
            param[8] = new SqlParameter("@ItemNo", argPromotionEarningDetails.ItemNo);
            param[9] = new SqlParameter("@NewAmount", argPromotionEarningDetails.NewAmount);
            param[10] = new SqlParameter("@EmployeePromotionNo", argPromotionEarningDetails.EmployeePromotionNo);

            param[11] = new SqlParameter("@Type", SqlDbType.Char);
            param[11].Size = 1;
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[12].Size = 255;
            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[13].Size = 20;
            param[13].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_UpdatePromotionEarningDetails", param);

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

        public void UpdateEmployeePromotionEarningDetails(PromotionEarningDetails argPromotionEarningDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@EmployeeId", argPromotionEarningDetails.EmployeeId);
            param[1] = new SqlParameter("@Allowances", argPromotionEarningDetails.Allowances);
            param[2] = new SqlParameter("@Amount", argPromotionEarningDetails.NewAmount);
            param[3] = new SqlParameter("@CalcOn", argPromotionEarningDetails.CalcOn);
            param[4] = new SqlParameter("@PaymentMode", argPromotionEarningDetails.PaymentMode);
            param[5] = new SqlParameter("@Bonus", argPromotionEarningDetails.Bonus);
            param[6] = new SqlParameter("@OT", argPromotionEarningDetails.OT);

            param[7] = new SqlParameter("@ModifiedBy", argPromotionEarningDetails.ModifiedBy);
            param[8] = new SqlParameter("@ItemNo", argPromotionEarningDetails.ItemNo);

            param[9] = new SqlParameter("@Type", SqlDbType.Char);
            param[9].Size = 1;
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[10].Size = 255;
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[11].Size = 20;
            param[11].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_UpdateEmployeePromotionEarningDetails", param);

            string strMessage = Convert.ToString(param[10].Value);
            string strType = Convert.ToString(param[9].Value);
            string strRetValue = Convert.ToString(param[11].Value);

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

        public ICollection<ErrorHandlerClass> DeletePromotionEarningDetails(string argEmployeeId, int iIsDeleted)
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
                int i = da.ExecuteNonQuery("Proc_DeletePromotionEarningDetails", param);

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

        public bool blnIsPromotionEarningDetailsExist(int EmployeePromotionNo, string EmplyeeId, int ItemNo)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetPromotionEarningDetails4Check(EmployeePromotionNo,EmplyeeId, ItemNo);
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

        public bool blnIsEmployeeEarningDetailsExist(string EmplyeeId, int ItemNo)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetEmployeeEarningDetails4Check(EmplyeeId, ItemNo);
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

        public DataSet GetMaxItemNo4Earning(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetMaxItemNo4Earning", param);
            return DataSetToFill;
        }

    }
}
