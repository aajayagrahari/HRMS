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
    public class EmployeeDeductionDetailsManager
    {
        const string EmployeeDeductionDetailsTable = "EmployeeDeductionDetails";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public EmployeeDeductionDetails objGetEmployeeDeductionDetails(string EmployeeId)
        {
            EmployeeDeductionDetails argEmployeeDeductionDetails = new EmployeeDeductionDetails();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetEmployeeDeductionDetails4ID(EmployeeId.ToString().Trim());

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argEmployeeDeductionDetails = this.objCreteEmployeeDeductionDetails((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

        return argEmployeeDeductionDetails;
        }   

        private EmployeeDeductionDetails objCreteEmployeeDeductionDetails(DataRow dr)
        {
            EmployeeDeductionDetails tEmployeeDeductionDetails = new EmployeeDeductionDetails();

            tEmployeeDeductionDetails.SetObjectInfo(dr);

            return tEmployeeDeductionDetails;
        }
        public DataSet GetMaxEmployeeDeductionId()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetMaxEmployeeDeductionId", param);
            return DataSetToFill;
        }
        public DataSet GetEmployeeDeductionDetails()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeDeductionDetails", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeDeductionDetails4ID(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeDeductionDetails4ID", param);
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

        public DataSet GetEmployeeDeductionDetails4Grid(string strEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", strEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeDeductionDetails4Grid", param);
            return DataSetToFill;
        }

        public void SaveEmployeeDeductionDetails(EmployeeDeductionDetails objEmployeeDeductionDetails, ref DataAccess da, ref List<ErrorHandlerClass> lstErr)
        {
            try
            {
                if (blnIsEmployeeDeductionDetailsExist(objEmployeeDeductionDetails.EmployeeId, objEmployeeDeductionDetails.ItemNo) == false)
                {
                    InsertEmployeeDeductionDetails(objEmployeeDeductionDetails, da, lstErr);
                }
                else
                {
                    UpdateEmployeeDeductionDetails(objEmployeeDeductionDetails, da, lstErr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<ErrorHandlerClass> SaveEmployeeDeductionDetails(EmployeeDeductionDetails objEmployeeDeductionDetails)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (blnIsEmployeeDeductionDetailsExist(objEmployeeDeductionDetails.EmployeeId,objEmployeeDeductionDetails.ItemNo) == false)
                {
                    InsertEmployeeDeductionDetails(objEmployeeDeductionDetails, da, lstErr);

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
                    UpdateEmployeeDeductionDetails(objEmployeeDeductionDetails, da, lstErr);
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

        public void InsertEmployeeDeductionDetails(EmployeeDeductionDetails argEmployeeDeductionDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeDeductionDetails.EmployeeId);
            param[1] = new SqlParameter("@Deductions", argEmployeeDeductionDetails.Deductions);
            param[2] = new SqlParameter("@DeductionPercetage", argEmployeeDeductionDetails.DeductionPercetage);
            param[3] = new SqlParameter("@DeductionAmount", argEmployeeDeductionDetails.DeductionAmount);
            param[4] = new SqlParameter("@DeductionCalcOn", argEmployeeDeductionDetails.DeductionCalcOn);
            param[5] = new SqlParameter("@DeductionPayMode", argEmployeeDeductionDetails.DeductionPayMode);
            param[6] = new SqlParameter("@DeductionLimit", argEmployeeDeductionDetails.DeductionLimit);

            param[7] = new SqlParameter("@CreatedBy", argEmployeeDeductionDetails.CreatedBy);
            param[8] = new SqlParameter("@ModifiedBy", argEmployeeDeductionDetails.ModifiedBy);
            param[9] = new SqlParameter("@ItemNo", argEmployeeDeductionDetails.ItemNo);
            param[10] = new SqlParameter("@LimitAmount", argEmployeeDeductionDetails.LimitAmount);

            param[11] = new SqlParameter("@Type", SqlDbType.Char);
            param[11].Size = 1;
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[12].Size = 255;
            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[13].Size = 20;
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@EmployeeDeductionId", argEmployeeDeductionDetails.EmployeeDeductionId);
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

        public void UpdateEmployeeDeductionDetails(EmployeeDeductionDetails argEmployeeDeductionDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeDeductionDetails.EmployeeId);
            param[1] = new SqlParameter("@Deductions", argEmployeeDeductionDetails.Deductions);
            param[2] = new SqlParameter("@DeductionPercetage", argEmployeeDeductionDetails.DeductionPercetage);
            param[3] = new SqlParameter("@DeductionAmount", argEmployeeDeductionDetails.DeductionAmount);
            param[4] = new SqlParameter("@DeductionCalcOn", argEmployeeDeductionDetails.DeductionCalcOn);
            param[5] = new SqlParameter("@DeductionPayMode", argEmployeeDeductionDetails.DeductionPayMode);
            param[6] = new SqlParameter("@DeductionLimit", argEmployeeDeductionDetails.DeductionLimit);

            param[7] = new SqlParameter("@ModifiedBy", argEmployeeDeductionDetails.ModifiedBy);
            param[8] = new SqlParameter("@ItemNo", argEmployeeDeductionDetails.ItemNo);
            param[9] = new SqlParameter("@LimitAmount", argEmployeeDeductionDetails.LimitAmount);

            param[10] = new SqlParameter("@Type", SqlDbType.Char);
            param[10].Size = 1;
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[11].Size = 255;
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[12].Size = 20;
            param[12].Direction = ParameterDirection.Output;
            param[13] = new SqlParameter("@EmployeeDeductionId", argEmployeeDeductionDetails.EmployeeDeductionId);
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

        public ICollection<ErrorHandlerClass> DeleteEmployeeDeductionDetails(string argEmployeeId, int iIsDeleted, string ModifiedBy, string ItemNo, string EmployeeDeductionId)
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
                param[6] = new SqlParameter("@EmployeeDeductionId", EmployeeDeductionId);
                param[7] = new SqlParameter("@ModifiedBy", ModifiedBy);
                int i = da.ExecuteNonQuery("Proc_DeleteEmployeeDeductionDetails", param);

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

    }
}
