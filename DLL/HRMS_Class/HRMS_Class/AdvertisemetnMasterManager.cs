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
//Date:           09-10-2013
#endregion Developnet Detatil

namespace HRMS_Class
{
    public class AdvertisemetnMasterManager
    {
        const string AdvertisemetnMasterTable = "AdvertisemetnMaster";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public DataSet GetAdvertisemetnMaster()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetAdvertisemetnMaster", param);
            return DataSetToFill;
        }

        public DataSet GetAdvertisemetnMasterById(Int32 AdvertisementId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@AdvertisementId", AdvertisementId);
            DataSetToFill = da.FillDataSet("Proc_GetAdvertisemetnMaster4Id", param);
            return DataSetToFill;
        }

        public ICollection<ErrorHandlerClass> SaveAdvertisemetnMaster(AdvertisemetnMaster objAdvertisemetnMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                InsertAdvertisemetnMaster(objAdvertisemetnMaster, da, lstErr);


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

        public ICollection<ErrorHandlerClass> UpdateAdvertisemetnMaster(AdvertisemetnMaster objAdvertisemetnMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                UpdateAdvertisemetnMaster(objAdvertisemetnMaster, da, lstErr);

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

        public ICollection<ErrorHandlerClass> DeleteAdvertisemetnMaster(AdvertisemetnMaster objAdvertisemetnMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                DeleteAdvertisemetnMaster(objAdvertisemetnMaster, da, lstErr);

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

        public void InsertAdvertisemetnMaster(AdvertisemetnMaster argAdvertisemetnMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@AdvertisementId", argAdvertisemetnMaster.AdvertisementId);
            param[1] = new SqlParameter("@AdvertisementName", argAdvertisemetnMaster.AdvertisementName);
            param[2] = new SqlParameter("@AdverDescription", argAdvertisemetnMaster.AdverDescription);
            param[3] = new SqlParameter("@OpeningDate", argAdvertisemetnMaster.OpeningDate);
            param[4] = new SqlParameter("@ClosingDate", argAdvertisemetnMaster.ClosingDate);
            param[5] = new SqlParameter("@CreatedBy", argAdvertisemetnMaster.CreatedBy);
            



            param[6] = new SqlParameter("@Type", SqlDbType.Char);
            param[6].Size = 1;
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[7].Size = 255;
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[8].Size = 20;
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@PDFFileName", argAdvertisemetnMaster.PDFFileName);


            int i = da.NExecuteNonQuery("Proc_InsertAdvertisemetnMaster", param);

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

        public string UpdateAdvertisemetnMaster(AdvertisemetnMaster argAdvertisemetnMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@AdvertisementId", argAdvertisemetnMaster.AdvertisementId);
            param[1] = new SqlParameter("@AdvertisementName", argAdvertisemetnMaster.AdvertisementName);
            param[2] = new SqlParameter("@AdverDescription", argAdvertisemetnMaster.AdverDescription);
            param[3] = new SqlParameter("@OpeningDate", argAdvertisemetnMaster.OpeningDate);
            param[4] = new SqlParameter("@ClosingDate", argAdvertisemetnMaster.ClosingDate);
            param[5] = new SqlParameter("@ModifiedBy", argAdvertisemetnMaster.ModifiedBy);




            param[6] = new SqlParameter("@Type", SqlDbType.Char);
            param[6].Size = 1;
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[7].Size = 255;
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[8].Size = 20;
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@PDFFileName", argAdvertisemetnMaster.PDFFileName);



            int i = da.NExecuteNonQuery("Proc_UpdateAdvertisemetnMaster", param);

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

            return strRetValue;
        }

        public string DeleteAdvertisemetnMaster(AdvertisemetnMaster argAdvertisemetnMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@AdvertisementId", argAdvertisemetnMaster.AdvertisementId);
            param[1] = new SqlParameter("@ModifiedBy", argAdvertisemetnMaster.ModifiedBy);
            param[2] = new SqlParameter("@Type", SqlDbType.Char);
            param[2].Size = 1;
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[3].Size = 255;
            param[3].Direction = ParameterDirection.Output;

            param[4] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[4].Size = 20;
            param[4].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_DeleteAdvertisemetnMaster", param);

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
