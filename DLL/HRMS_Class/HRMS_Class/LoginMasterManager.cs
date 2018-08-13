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
    public class LoginMasterManager
    {
        ErrorHandlerClass onjErrorHandlerClass = new ErrorHandlerClass();    
             
        public DataSet CheckUserLogin(string argLoginId, string argPassword)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@LoginId", argLoginId);
            param[1] = new SqlParameter("@Password", argPassword);

            DataSetToFill = da.FillDataSet("Proc_CheckLoginDetails", param);

            return DataSetToFill;
        }

        public ICollection<ErrorHandlerClass> SaveLoginDetails(LoginMaster argLoginMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();
                InsertLoginDetails(argLoginMaster, da, lstErr);
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
                onjErrorHandlerClass.Type = ErrorConstant.strAboartType;
                onjErrorHandlerClass.MsgId = 0;
                onjErrorHandlerClass.Message = ex.Message.ToString();
                onjErrorHandlerClass.RowNo = 0;
                onjErrorHandlerClass.FieldName = "";
                onjErrorHandlerClass.LogCode = "";
                lstErr.Add(onjErrorHandlerClass);
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
        
        public void InsertLoginDetails(LoginMaster argLoginMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@LoginId", argLoginMaster.LoginId);
            param[1] = new SqlParameter("@IP", argLoginMaster.IP);
            param[2] = new SqlParameter("@Host", argLoginMaster.Host);
            param[3] = new SqlParameter("@LastRefreshedDate", argLoginMaster.LastRefreshedDate);
            param[4] = new SqlParameter("@LoginDate", argLoginMaster.LoginDate);
            param[5] = new SqlParameter("@UserAgent", argLoginMaster.UserAgent);
            param[6] = new SqlParameter("@IsSucessfull", argLoginMaster.IsSucessfull);
            
            param[7] = new SqlParameter("@Type", SqlDbType.Char);
            param[7].Size = 1;
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[8].Size = 255;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[9].Size = 20;
            param[9].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_InsertLoginDetails", param);


            string strMessage = Convert.ToString(param[8].Value);
            string strType = Convert.ToString(param[7].Value);
            string strRetValue = Convert.ToString(param[9].Value);


            onjErrorHandlerClass.Type = strType;
            onjErrorHandlerClass.MsgId = 0;
            onjErrorHandlerClass.Message = strMessage.ToString();
            onjErrorHandlerClass.RowNo = 0;
            onjErrorHandlerClass.FieldName = "";
            onjErrorHandlerClass.LogCode = "";
            lstErr.Add(onjErrorHandlerClass);
        }
    }
}
