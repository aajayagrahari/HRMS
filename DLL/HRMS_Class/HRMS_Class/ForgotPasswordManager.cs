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
    public class ForgotPasswordManager
    {
        const string DistributorTable = "DistributerMaster";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public DataSet GetPassword(string strEmailID)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmailId", strEmailID);
            DataSetToFill = da.FillDataSet("Proc_GetPassword", param);
            return DataSetToFill;
        }

        public bool CheckPasswordExist(string strLoginId)
        {
            bool IsExist = true;

            DataAccess da = new DataAccess();
            DataSet ds4Check = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@LoginId", strLoginId);
            ds4Check = da.FillDataSet("Proc_GetPassword", param);

            if (ds4Check.Tables[0].Rows.Count > 0)
            {
                IsExist = true;
            }
            else
            {
                IsExist = false;
            }
            return IsExist;
        }

        public DataSet CheckLoginDetails(string argLoginId, string argPassword)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@UserName", argLoginId);
            param[1] = new SqlParameter("@UserPassword", argPassword);

            DataSetToFill = da.FillDataSet("SL_CheckUserLogin", param);

            return DataSetToFill;
        }

        public ICollection<ErrorHandlerClass> ChangePassword(string strLoginId, string OldPassword, string NewPassword)
        {
            DataAccess da = new DataAccess();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@LoginId", strLoginId);
                param[1] = new SqlParameter("@OldPassword", OldPassword);
                param[2] = new SqlParameter("@NewPassword", NewPassword);

                param[3] = new SqlParameter("@Type", SqlDbType.Char);
                param[3].Size = 1;
                param[3].Direction = ParameterDirection.Output;

                param[4] = new SqlParameter("@Message", SqlDbType.VarChar);
                param[4].Size = 255;
                param[4].Direction = ParameterDirection.Output;

                param[5] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
                param[5].Size = 20;
                param[5].Direction = ParameterDirection.Output;

                int i = da.ExecuteNonQuery("Proc_ChangePassword", param);


                string strMessage = Convert.ToString(param[4].Value);
                string strType = Convert.ToString(param[3].Value);
                string strRetValue = Convert.ToString(param[5].Value);


                objErrorHandlerClass.Type = strType;
                objErrorHandlerClass.MsgId = 0;
                objErrorHandlerClass.Message = strMessage.ToString();
                objErrorHandlerClass.RowNo = 0;
                objErrorHandlerClass.FieldName = "";
                objErrorHandlerClass.LogCode = "";
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
    }
}
