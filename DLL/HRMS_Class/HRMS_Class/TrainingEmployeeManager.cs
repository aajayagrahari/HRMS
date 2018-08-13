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
    public class TrainingEmployeeManager
    {
        const string TrainingEmployeeTable = "TrainingEmployee";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public DataSet GetTrainingEmployee()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetTrainingEmployee", param);
            return DataSetToFill;
        }
        
        public DataSet GetTrainingEmployeeById(Int32 TrainingEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@TrainingEmployeeId", TrainingEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetTrainingEmployee4Id", param);
            return DataSetToFill;
        }

        public ICollection<ErrorHandlerClass> SaveTrainingEmployee(TrainingEmployee objTrainingEmployee)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                InsertTrainingEmployee(objTrainingEmployee, da, lstErr);
                

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

        public ICollection<ErrorHandlerClass> UpdateTrainingEmployee(TrainingEmployee objTrainingEmployee)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                UpdateTrainingEmployee(objTrainingEmployee, da, lstErr);

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

        public ICollection<ErrorHandlerClass> DeleteTrainingEmployee(TrainingEmployee objTrainingEmployee)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                DeleteTrainingEmployee(objTrainingEmployee, da, lstErr);

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

        public void InsertTrainingEmployee(TrainingEmployee argTrainingEmployee, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@TrainingEmployeeId", argTrainingEmployee.TrainingEmployeeId);
            param[1] = new SqlParameter("@TrainingId", argTrainingEmployee.TrainingId);
            param[2] = new SqlParameter("@EmployeeId", argTrainingEmployee.EmployeeId);
            param[3] = new SqlParameter("@IsDeleted", argTrainingEmployee.IsDeleted);
            param[4] = new SqlParameter("@CreatedDate", argTrainingEmployee.CreatedDate);
            param[5] = new SqlParameter("@ModifiedDate", argTrainingEmployee.ModifiedDate);
            param[6] = new SqlParameter("@CreatedBy", argTrainingEmployee.CreatedBy);
            param[7] = new SqlParameter("@ModifiedBy", argTrainingEmployee.ModifiedBy);



            param[8] = new SqlParameter("@Type", SqlDbType.Char);
            param[8].Size = 1;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[9].Size = 255;
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[10].Size = 20;
            param[10].Direction = ParameterDirection.Output;


            int i = da.NExecuteNonQuery("Proc_InsertTrainingEmployee", param);

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
            //return i;
        }

        public string UpdateTrainingEmployee(TrainingEmployee argTrainingEmployee, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@TrainingEmployeeId", argTrainingEmployee.TrainingEmployeeId);
            param[1] = new SqlParameter("@TrainingId", argTrainingEmployee.TrainingId);
            param[2] = new SqlParameter("@EmployeeId", argTrainingEmployee.EmployeeId);
            param[3] = new SqlParameter("@IsDeleted", argTrainingEmployee.IsDeleted);
            param[4] = new SqlParameter("@CreatedDate", argTrainingEmployee.CreatedDate);
            param[5] = new SqlParameter("@ModifiedDate", argTrainingEmployee.ModifiedDate);
            param[6] = new SqlParameter("@CreatedBy", argTrainingEmployee.CreatedBy);
            param[7] = new SqlParameter("@ModifiedBy", argTrainingEmployee.ModifiedBy);


            param[8] = new SqlParameter("@Type", SqlDbType.Char);
            param[8].Size = 1;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[9].Size = 255;
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[10].Size = 20;
            param[10].Direction = ParameterDirection.Output;



            int i = da.NExecuteNonQuery("Proc_UpdateTrainingEmployee", param);

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

        public string DeleteTrainingEmployee(TrainingEmployee argTrainingEmployee, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@TrainingEmployeeId", argTrainingEmployee.TrainingEmployeeId);
            param[1] = new SqlParameter("@ModifiedBy", argTrainingEmployee.ModifiedBy);
            param[2] = new SqlParameter("@Type", SqlDbType.Char);
            param[2].Size = 1;
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[3].Size = 255;
            param[3].Direction = ParameterDirection.Output;

            param[4] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[4].Size = 20;
            param[4].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_DeleteTrainingEmployee", param);

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
