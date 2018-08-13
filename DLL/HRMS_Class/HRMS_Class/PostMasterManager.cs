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
//Date:           21-10-2013
#endregion Developnet Detatil

namespace HRMS_Class
{
    public class PostMasterManager
    {
        const string PostMasterTable = "PostMaster";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public DataSet GetPostMaster4Registration()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetPost", param);
            return DataSetToFill;
        }

        public DataSet GetPostMaster()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetPostMaster", param);
            return DataSetToFill;
        }
        public DataSet GetPostMasterMain()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetPostMasterMain", param);
            return DataSetToFill;
        }

        public DataSet GetPostMaster4Id(Int32 PostMasterId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PostId", PostMasterId);
            DataSetToFill = da.FillDataSet("Proc_GetPost4Id", param);
            return DataSetToFill;
        }
        public DataSet GetPostEducation4Id(Int32 PostMasterId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PostId", PostMasterId);
            DataSetToFill = da.FillDataSet("Proc_GetPostEducation4Id", param);
            return DataSetToFill;
        }
        public DataSet GetPostMasterById(Int32 PostMasterId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PostMasterId", PostMasterId);
            DataSetToFill = da.FillDataSet("Proc_GetPostMaster4Id", param);
            return DataSetToFill;
        }
        


        public ICollection<ErrorHandlerClass> SavePostMaster(PostMaster objPostMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                InsertPostMaster(objPostMaster, da, lstErr);


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

        public ICollection<ErrorHandlerClass> UpdatePostMaster(PostMaster objPostMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                UpdatePostMaster(objPostMaster, da, lstErr);

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

        public ICollection<ErrorHandlerClass> DeletePostMaster(PostMaster objPostMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                DeletePostMaster(objPostMaster, da, lstErr);

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

        public void InsertPostMaster(PostMaster argPostMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@PostId", argPostMaster.PostId);
            param[1] = new SqlParameter("@PostName", argPostMaster.PostName);
            param[2] = new SqlParameter("@AdvertisementId", argPostMaster.AdvertisementId);
            param[3] = new SqlParameter("@CreatedBy", argPostMaster.CreatedBy);
          



            param[4] = new SqlParameter("@Type", SqlDbType.Char);
            param[4].Size = 1;
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[5].Size = 255;
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[6].Size = 20;
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@PostDescription", argPostMaster.PostDescription);
            param[8] = new SqlParameter("@MinAge", argPostMaster.MinAge);
            param[9] = new SqlParameter("@MaxAge", argPostMaster.MaxAge);


            int i = da.NExecuteNonQuery("Proc_InsertPostMaster", param);

            string strMessage = Convert.ToString(param[5].Value);
            string strType = Convert.ToString(param[4].Value);
            string strRetValue = Convert.ToString(param[6].Value);

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

        public string UpdatePostMaster(PostMaster argPostMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@PostId", argPostMaster.PostId);
            param[1] = new SqlParameter("@PostName", argPostMaster.PostName);
            param[2] = new SqlParameter("@AdvertisementId", argPostMaster.AdvertisementId);
            param[3] = new SqlParameter("@ModifiedBy", argPostMaster.ModifiedBy);


            param[4] = new SqlParameter("@Type", SqlDbType.Char);
            param[4].Size = 1;
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[5].Size = 255;
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[6].Size = 20;
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@PostDescription", argPostMaster.PostDescription);
            param[8] = new SqlParameter("@MinAge", argPostMaster.MinAge);
            param[9] = new SqlParameter("@MaxAge", argPostMaster.MaxAge);
            int i = da.NExecuteNonQuery("Proc_UpdatePostMaster", param);

            string strMessage = Convert.ToString(param[5].Value);
            string strType = Convert.ToString(param[4].Value);
            string strRetValue = Convert.ToString(param[6].Value);

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

        public string DeletePostMaster(PostMaster argPostMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@PostId", argPostMaster.PostId);
            param[1] = new SqlParameter("@ModifiedBy", argPostMaster.ModifiedBy);
            param[2] = new SqlParameter("@Type", SqlDbType.Char);
            param[2].Size = 1;
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[3].Size = 255;
            param[3].Direction = ParameterDirection.Output;

            param[4] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[4].Size = 20;
            param[4].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_DeletePostMaster", param);

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

        public DataSet getAdvertisement()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@uType", "getAdvertisement");
            DataSetToFill = da.FillDataSet("Proc_Admin", param);
            return DataSetToFill;
        }
    }
}
