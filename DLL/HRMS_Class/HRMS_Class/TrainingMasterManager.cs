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
    public class TrainingMasterManager
    {
        const string TrainingMasterTable = "TrainingMaster";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        TrainingEmployeeManager objTrainingEmployeeManager = new TrainingEmployeeManager();

        public DataSet GetTrainingMaster()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetTrainingMaster", param);
            return DataSetToFill;
        }
       
        public DataSet GetTrainingMasterById(Int32 TrainingId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@TrainingId", TrainingId);
            DataSetToFill = da.FillDataSet("Proc_GetTrainingMaster4Id", param);
            return DataSetToFill;
        }

        public ICollection<ErrorHandlerClass> SaveTrainingMaster(TrainingMaster objTrainingMaster, ICollection<TrainingEmployee> colTrainingEmployee)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                string strTrainingId = InsertTrainingMaster(objTrainingMaster, da, lstErr);

                foreach (ErrorHandlerClass objerr in lstErr)
                {
                    if (objerr.Type == "E")
                    {
                        da.ROLLBACK_TRANSACTION();
                        return lstErr;
                    }
                }
                if (strTrainingId != "")
                {
                    if (colTrainingEmployee.Count > 0)
                    {
                        foreach (TrainingEmployee argTrainingEmployee in colTrainingEmployee)
                        {
                            argTrainingEmployee.TrainingId = Convert.ToInt32(strTrainingId);
                            objTrainingEmployeeManager.SaveTrainingEmployee(argTrainingEmployee);
                        }
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

        public ICollection<ErrorHandlerClass> UpdateTrainingMaster(TrainingMaster objTrainingMaster, ICollection<TrainingEmployee> colTrainingEmployee)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                string strTrainingId = UpdateTrainingMaster(objTrainingMaster, da, lstErr);

                foreach (ErrorHandlerClass objerr in lstErr)
                {
                    if (objerr.Type == "E")
                    {
                        da.ROLLBACK_TRANSACTION();
                        return lstErr;
                    }
                }
                if (strTrainingId != "")
                {
                    if (colTrainingEmployee.Count > 0)
                    {
                        foreach (TrainingEmployee argTrainingEmployee in colTrainingEmployee)
                        {
                            argTrainingEmployee.TrainingId = Convert.ToInt32(strTrainingId);
                            objTrainingEmployeeManager.SaveTrainingEmployee(argTrainingEmployee);
                        }
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

        public ICollection<ErrorHandlerClass> DeleteTrainingMaster(TrainingMaster objTrainingMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                DeleteTrainingMaster(objTrainingMaster, da, lstErr);

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

        public string InsertTrainingMaster(TrainingMaster argTrainingMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@TrainingId", argTrainingMaster.TrainingId);
            param[1] = new SqlParameter("@Traning_Subject", argTrainingMaster.Traning_Subject);
            param[2] = new SqlParameter("@StarDate", argTrainingMaster.StarDate);
            param[3] = new SqlParameter("@EndDate", argTrainingMaster.EndDate);
            param[4] = new SqlParameter("@Traning_Hour", argTrainingMaster.Traning_Hour);
            param[5] = new SqlParameter("@Traning_Minute", argTrainingMaster.Traning_Minute);
            param[6] = new SqlParameter("@Traning_Description", argTrainingMaster.Traning_Description);
            param[7] = new SqlParameter("@CreatedBy", argTrainingMaster.CreatedBy);



            param[8] = new SqlParameter("@Type", SqlDbType.Char);
            param[8].Size = 1;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[9].Size = 255;
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[10].Size = 20;
            param[10].Direction = ParameterDirection.Output;


            int i = da.NExecuteNonQuery("Proc_InsertTrainingMaster", param);

            string strMessage = Convert.ToString(param[9].Value);
            string strType = Convert.ToString(param[8].Value);
            string strRetValue = Convert.ToString(param[10].Value);

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

        public string UpdateTrainingMaster(TrainingMaster argTrainingMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@TrainingId", argTrainingMaster.TrainingId);
            param[1] = new SqlParameter("@Traning_Subject", argTrainingMaster.Traning_Subject);
            param[2] = new SqlParameter("@StarDate", argTrainingMaster.StarDate);
            param[3] = new SqlParameter("@EndDate", argTrainingMaster.EndDate);
            param[4] = new SqlParameter("@Traning_Hour", argTrainingMaster.Traning_Hour);
            param[5] = new SqlParameter("@Traning_Minute", argTrainingMaster.Traning_Minute);
            param[6] = new SqlParameter("@Traning_Description", argTrainingMaster.Traning_Description);
            param[7] = new SqlParameter("@ModifiedBy", argTrainingMaster.ModifiedBy);



            param[8] = new SqlParameter("@Type", SqlDbType.Char);
            param[8].Size = 1;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[9].Size = 255;
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[10].Size = 20;
            param[10].Direction = ParameterDirection.Output;



            int i = da.NExecuteNonQuery("Proc_UpdateTrainingMaster", param);

            string strMessage = Convert.ToString(param[9].Value);
            string strType = Convert.ToString(param[8].Value);
            string strRetValue = Convert.ToString(param[10].Value);

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

        public string DeleteTrainingMaster(TrainingMaster argTrainingMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@TrainingId", argTrainingMaster.TrainingId);
            param[1] = new SqlParameter("@ModifiedBy", argTrainingMaster.ModifiedBy);
            param[2] = new SqlParameter("@Type", SqlDbType.Char);
            param[2].Size = 1;
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[3].Size = 255;
            param[3].Direction = ParameterDirection.Output;

            param[4] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[4].Size = 20;
            param[4].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_DeleteTrainingMaster", param);

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

        public DataSet GetEmployeeMaster(Int32 TrainingId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@TrainingId", TrainingId);
            param[1] = new SqlParameter("@uType", "GetEmployeeMaster");
            DataSetToFill = da.FillDataSet("Proc_Admin", param);
            return DataSetToFill;
        }
    }
}
