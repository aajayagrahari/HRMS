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
  public  class RequitmentMasterManager
    {
      const string RequitmentMasterManagerTable = "RequitmentMasterManager";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();
        public DataTable GetRequitmentMaster()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
           
            DataSetToFill = da.FillDataSet("GetRequitmentMaster", param);
            return DataSetToFill.Tables[0];
        }
        public DataTable GetRequitmentMaster4Download(int Rid)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RId", Rid);
            DataSetToFill = da.FillDataSet("GetRequitmentMaster4Download", param);
            return DataSetToFill.Tables[0];
        }
        public ICollection<ErrorHandlerClass> SaveRequitmentMaster(RequitmentMaster argRequitmentMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                InsertRequitmentMasterDetails(argRequitmentMaster, da, lstErr);

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


        public void InsertRequitmentMasterDetails(RequitmentMaster argRequitmentMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[21];
            param[0] = new SqlParameter("@FName", argRequitmentMaster.FName);
            param[1] = new SqlParameter("@LName", argRequitmentMaster.LName);
            param[2] = new SqlParameter("@Gender", argRequitmentMaster.Gender);
            param[3] = new SqlParameter("@EmailId", argRequitmentMaster.EmailId);
            param[4] = new SqlParameter("@DOB", argRequitmentMaster.DOB);
            param[5] = new SqlParameter("@MobileNo", argRequitmentMaster.MobileNo);
            param[6] = new SqlParameter("@Qualification", argRequitmentMaster.Qualification);
            param[7] = new SqlParameter("@Exprience", argRequitmentMaster.Exprience);
            param[8] = new SqlParameter("@Designation", argRequitmentMaster.Designation);
            param[9] = new SqlParameter("@CountryCode", argRequitmentMaster.CountryCode);
            param[10] = new SqlParameter("@StateCode ", argRequitmentMaster.StateCode);
            param[11] = new SqlParameter("@City", argRequitmentMaster.City);
            param[12] = new SqlParameter("@PinCode", argRequitmentMaster.PinCode);
            param[13] = new SqlParameter("@CAddress", argRequitmentMaster.CAddress);
            param[14] = new SqlParameter("@PAddress", argRequitmentMaster.PAddress);
            param[15] = new SqlParameter("@Resume", argRequitmentMaster.Resume);
            param[16] = new SqlParameter("@CreatedBy", argRequitmentMaster.CreatedBy);
            param[17] = new SqlParameter("@ModifiedBy", argRequitmentMaster.ModifiedBy);

            param[18] = new SqlParameter("@Type", SqlDbType.Char);
            param[18].Size = 1;
            param[18].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[19].Size = 255;
            param[19].Direction = ParameterDirection.Output;

            param[20] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[20].Size = 20;
            param[20].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_InsertRequitmentMaster", param);

            string strMessage = Convert.ToString(param[19].Value);
            string strType = Convert.ToString(param[18].Value);
            string strRetValue = Convert.ToString(param[20].Value);

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

    }
}
