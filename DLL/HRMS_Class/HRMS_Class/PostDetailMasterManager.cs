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
    public class PostDetailMasterManager
    {
        const string PostDetailMasterTable = "PostDetailMaster";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public DataSet GetPostDetailMaster()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetPostDetailMaster", param);
            return DataSetToFill;
        }

        public DataSet GetPostDetailMasterById(Int32 PostDetailMasterId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PostDetailMasterId", PostDetailMasterId);
            DataSetToFill = da.FillDataSet("Proc_GetPostDetailMaster4Id", param);
            return DataSetToFill;
        }
        public ICollection<ErrorHandlerClass> SavePostDetailMasterCollection(ICollection<PostDetailMaster> colPostDetailMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (colPostDetailMaster.Count > 0)
                {
                    foreach (PostDetailMaster argPostDetailMaster in colPostDetailMaster)
                    {
                        //argTrainingEmployee.TrainingId = Convert.ToInt32(strTrainingId);
                        SavePostDetailMaster(argPostDetailMaster);
                       // objTrainingEmployeeManager.SaveTrainingEmployee(argTrainingEmployee);
                    }
                }
                //InsertPostDetailMaster(objPostDetailMaster, da, lstErr);


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
        public ICollection<ErrorHandlerClass> UpdatePostDetailMasterCollection(ICollection<PostDetailMaster> colPostDetailMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (colPostDetailMaster.Count > 0)
                {
                    foreach (PostDetailMaster argPostDetailMaster in colPostDetailMaster)
                    {
                      
                        UpdatePostDetailMaster(argPostDetailMaster);
                     
                    }
                }
                //InsertPostDetailMaster(objPostDetailMaster, da, lstErr);


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
        public ICollection<ErrorHandlerClass> SavePostDetailMaster(PostDetailMaster objPostDetailMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                InsertPostDetailMaster(objPostDetailMaster, da, lstErr);


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

        public ICollection<ErrorHandlerClass> UpdatePostDetailMaster(PostDetailMaster objPostDetailMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                UpdatePostDetailMaster(objPostDetailMaster, da, lstErr);

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

        public ICollection<ErrorHandlerClass> DeletePostDetailMaster(PostDetailMaster objPostDetailMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                DeletePostDetailMaster(objPostDetailMaster, da, lstErr);

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

        public void InsertPostDetailMaster(PostDetailMaster argPostDetailMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[21];
            param[0] = new SqlParameter("@PostIdDetailId", argPostDetailMaster.PostIdDetailId);
            param[1] = new SqlParameter("@PostId", argPostDetailMaster.PostId);
            param[2] = new SqlParameter("@IsGenral", argPostDetailMaster.IsGenral);
            param[3] = new SqlParameter("@IsSC", argPostDetailMaster.IsSC);
            param[4] = new SqlParameter("@IsST", argPostDetailMaster.IsST);
            param[5] = new SqlParameter("@CreatedBy", argPostDetailMaster.CreatedBy);
            
            param[6] = new SqlParameter("@Type", SqlDbType.Char);
            param[6].Size = 1;
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[7].Size = 255;
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[8].Size = 20;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@IsOBC", argPostDetailMaster.IsOBC);
            param[10] = new SqlParameter("@IsPH", argPostDetailMaster.IsPH);

            param[11] = new SqlParameter("@GenralSeat", argPostDetailMaster.GenralSeat);
            param[12] = new SqlParameter("@STSeat", argPostDetailMaster.STSeat);
            param[13] = new SqlParameter("@SCSeat", argPostDetailMaster.SCSeat);
            param[14] = new SqlParameter("@OBCSeat", argPostDetailMaster.OBCSeat);
            param[15] = new SqlParameter("@PHSeat", argPostDetailMaster.PHSeat);

            param[16] = new SqlParameter("@GenralAmt", argPostDetailMaster.GenralAmt);
            param[17] = new SqlParameter("@STAmt", argPostDetailMaster.STAmt);
            param[18] = new SqlParameter("@SCAmt", argPostDetailMaster.SCAmt);
            param[19] = new SqlParameter("@OBCAmt", argPostDetailMaster.OBCAmt);
            param[20] = new SqlParameter("@PHAmt", argPostDetailMaster.PHAmt);
            



            int i = da.NExecuteNonQuery("Proc_InsertPostDetailMaster", param);

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
            //return i;
        }

        public string UpdatePostDetailMaster(PostDetailMaster argPostDetailMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[21];
            param[0] = new SqlParameter("@PostIdDetailId", argPostDetailMaster.PostIdDetailId);
            param[1] = new SqlParameter("@PostId", argPostDetailMaster.PostId);
            param[2] = new SqlParameter("@IsGenral", argPostDetailMaster.IsGenral);
            param[3] = new SqlParameter("@IsSC", argPostDetailMaster.IsSC);
            param[4] = new SqlParameter("@IsST", argPostDetailMaster.IsST);
            param[5] = new SqlParameter("@ModifiedBy", argPostDetailMaster.ModifiedBy);

            param[6] = new SqlParameter("@Type", SqlDbType.Char);
            param[6].Size = 1;
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[7].Size = 255;
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[8].Size = 20;
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@IsOBC", argPostDetailMaster.IsOBC);
            param[10] = new SqlParameter("@IsPH", argPostDetailMaster.IsPH);

            param[11] = new SqlParameter("@GenralSeat", argPostDetailMaster.GenralSeat);
            param[12] = new SqlParameter("@STSeat", argPostDetailMaster.STSeat);
            param[13] = new SqlParameter("@SCSeat", argPostDetailMaster.SCSeat);
            param[14] = new SqlParameter("@OBCSeat", argPostDetailMaster.OBCSeat);
            param[15] = new SqlParameter("@PHSeat", argPostDetailMaster.PHSeat);

            param[16] = new SqlParameter("@GenralAmt", argPostDetailMaster.GenralAmt);
            param[17] = new SqlParameter("@STAmt", argPostDetailMaster.STAmt);
            param[18] = new SqlParameter("@SCAmt", argPostDetailMaster.SCAmt);
            param[19] = new SqlParameter("@OBCAmt", argPostDetailMaster.OBCAmt);
            param[20] = new SqlParameter("@PHAmt", argPostDetailMaster.PHAmt);
            

            int i = da.NExecuteNonQuery("Proc_UpdatePostDetailMaster", param);

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

        public string DeletePostDetailMaster(PostDetailMaster argPostDetailMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@PostIdDetailId", argPostDetailMaster.PostIdDetailId);
            param[1] = new SqlParameter("@ModifiedBy", argPostDetailMaster.ModifiedBy);
            param[2] = new SqlParameter("@Type", SqlDbType.Char);
            param[2].Size = 1;
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[3].Size = 255;
            param[3].Direction = ParameterDirection.Output;

            param[4] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[4].Size = 20;
            param[4].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_DeletePostDetailMaster", param);

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
