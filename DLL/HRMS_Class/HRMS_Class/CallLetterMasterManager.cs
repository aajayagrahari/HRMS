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
//Date:           18-10-2013
#endregion Developnet Detatil


namespace HRMS_Class
{
    public class CallLetterMasterManager
    {
        const string CallLetterMasterTable = "CallLetterMaster";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public DataSet GetCallLetterMaster()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetCallLetterMaster", param);
            return DataSetToFill;
        }
        public DataSet GetCallLetterMasterById(Int32 CallLetterMasterId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CallLetterMasterId", CallLetterMasterId);
            DataSetToFill = da.FillDataSet("Proc_GetCallLetterMaster4Id", param);
            return DataSetToFill;
        }

        public DataSet GetHolidayDetails4Month(string Month, string Year)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Month", Month);
            param[1] = new SqlParameter("@Year", Year);
            DataSetToFill = da.FillDataSet("Proc_GetHolidayDetails4Month", param);
            return DataSetToFill;
        }

        public ICollection<ErrorHandlerClass> SaveCallLetterMaster(CallLetterMaster objCallLetterMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                InsertCallLetterMaster(objCallLetterMaster, da, lstErr);

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

        public ICollection<ErrorHandlerClass> UpdateCallLetterMaster(CallLetterMaster objCallLetterMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                UpdateCallLetterMaster(objCallLetterMaster, da, lstErr);

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

        public ICollection<ErrorHandlerClass> DeleteCallLetterMaster(CallLetterMaster objCallLetterMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                DeleteCallLetterMaster(objCallLetterMaster, da, lstErr);

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

        public void InsertCallLetterMaster(CallLetterMaster argCallLetterMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@CallLetterMasterId", argCallLetterMaster.CallLetterMasterId);
            param[1] = new SqlParameter("@Name", argCallLetterMaster.Name);
            param[2] = new SqlParameter("@EmailId", argCallLetterMaster.EmailId);
            param[3] = new SqlParameter("@Designation", argCallLetterMaster.Designation);
            param[4] = new SqlParameter("@Venue", argCallLetterMaster.Venue);
            param[5] = new SqlParameter("@InterviewDate", argCallLetterMaster.InterviewDate);
            param[6] = new SqlParameter("@CreatedBy", argCallLetterMaster.CreatedBy);
            param[7] = new SqlParameter("@Type", SqlDbType.Char);
            param[7].Size = 1;
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[8].Size = 255;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[9].Size = 20;
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@CFileName", argCallLetterMaster.CFileName);
            param[11] = new SqlParameter("@ProjectSiteName", argCallLetterMaster.ProjectSiteName);

            int i = da.NExecuteNonQuery("Proc_InsertCallLetterMaster", param);

            string strMessage = Convert.ToString(param[8].Value);
            string strType = Convert.ToString(param[7].Value);
            string strRetValue = Convert.ToString(param[9].Value);

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

        public string UpdateCallLetterMaster(CallLetterMaster argCallLetterMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@CallLetterMasterId", argCallLetterMaster.CallLetterMasterId);
            param[1] = new SqlParameter("@Name", argCallLetterMaster.Name);
            param[2] = new SqlParameter("@EmailId", argCallLetterMaster.EmailId);
            param[3] = new SqlParameter("@Designation", argCallLetterMaster.Designation);
            param[4] = new SqlParameter("@Venue", argCallLetterMaster.Venue);
            param[5] = new SqlParameter("@InterviewDate", argCallLetterMaster.InterviewDate);
            param[6] = new SqlParameter("@ModifiedBy", argCallLetterMaster.ModifiedBy);
            param[7] = new SqlParameter("@Type", SqlDbType.Char);
            param[7].Size = 1;
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[8].Size = 255;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[9].Size = 20;
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@CFileName", argCallLetterMaster.CFileName);
            param[11] = new SqlParameter("@ProjectSiteName", argCallLetterMaster.ProjectSiteName);


            int i = da.NExecuteNonQuery("Proc_UpdateCallLetterMaster", param);

            string strMessage = Convert.ToString(param[8].Value);
            string strType = Convert.ToString(param[7].Value);
            string strRetValue = Convert.ToString(param[9].Value);

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

        public string DeleteCallLetterMaster(CallLetterMaster argCallLetterMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@CallLetterMasterId", argCallLetterMaster.CallLetterMasterId);
            param[1] = new SqlParameter("@ModifiedBy", argCallLetterMaster.ModifiedBy);
            param[2] = new SqlParameter("@Type", SqlDbType.Char);
            param[2].Size = 1;
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[3].Size = 255;
            param[3].Direction = ParameterDirection.Output;

            param[4] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[4].Size = 20;
            param[4].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_DeleteCallLetterMaster", param);

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
