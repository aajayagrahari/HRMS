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
    public class EmployeeQualificationDetailsManager
    {
        const string EmployeeQualificationDetailsTable = "EmployeeQualificationDetails";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public EmployeeQualificationDetails objGetEmployeeQualificationDetails(string EmployeeId)
        {
            EmployeeQualificationDetails argEmployeeQualificationDetails = new EmployeeQualificationDetails();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetEmployeeQualificationDetails4ID(EmployeeId.ToString().Trim());

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argEmployeeQualificationDetails = this.objCreteEmployeeQualificationDetails((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

        return argEmployeeQualificationDetails;
        }

        private EmployeeQualificationDetails objCreteEmployeeQualificationDetails(DataRow dr)
        {
            EmployeeQualificationDetails tEmployeeQualificationDetails = new EmployeeQualificationDetails();

            tEmployeeQualificationDetails.SetObjectInfo(dr);

            return tEmployeeQualificationDetails;

        }
        public DataSet GetMaxEmployeeQualificationId()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetMaxEmployeeQualificationId", param);
            return DataSetToFill;
        }
        public DataSet GetEmployeeQualificationDetails()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeQualificationDetails", param);
            return DataSetToFill;
        }
        
        public DataSet GetEmployeeQualificationDetails4ID(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeQualificationDetails4ID", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeQualificationDetails4Check(string EmployeeId, int ItemNo)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            param[1] = new SqlParameter("@ItemNo", ItemNo);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeQualificationDetails4Check", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeQualificationDetails4Grid(string strEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", strEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeQualificationDetails4Grid", param);
            return DataSetToFill;
        }

        public void SaveEmployeeQualificationDetails(EmployeeQualificationDetails objEmployeeQualificationDetails, ref DataAccess da, ref List<ErrorHandlerClass> lstErr)
        {
            try
            {
                if (blnIsEmployeeQualificationDetailsExist(objEmployeeQualificationDetails.EmployeeId, objEmployeeQualificationDetails.ItemNo) == false)
                {
                    InsertEmployeeQualificationDetails(objEmployeeQualificationDetails, da, lstErr);
                }
                else
                {
                    UpdateEmployeeQualificationDetails(objEmployeeQualificationDetails, da, lstErr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<ErrorHandlerClass> SaveEmployeeQualificationDetails(EmployeeQualificationDetails objEmployeeQualificationDetails)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (blnIsEmployeeQualificationDetailsExist(objEmployeeQualificationDetails.EmployeeId,objEmployeeQualificationDetails.ItemNo) == false)
                {
                    InsertEmployeeQualificationDetails(objEmployeeQualificationDetails, da, lstErr);

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
                    UpdateEmployeeQualificationDetails(objEmployeeQualificationDetails, da, lstErr);
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

        public void InsertEmployeeQualificationDetails(EmployeeQualificationDetails argEmployeeQualificationDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeQualificationDetails.EmployeeId);
            param[1] = new SqlParameter("@ClassId", argEmployeeQualificationDetails.ClassId);
            param[2] = new SqlParameter("@ClassName", argEmployeeQualificationDetails.ClassName);
            param[3] = new SqlParameter("@CollegeOrUniversityName", argEmployeeQualificationDetails.CollegeOrUniversityName);
            param[4] = new SqlParameter("@PassingYear", argEmployeeQualificationDetails.PassingYear);
            param[5] = new SqlParameter("@Subject", argEmployeeQualificationDetails.Subject);
            param[6] = new SqlParameter("@Percentage", argEmployeeQualificationDetails.Percentage);
            param[7] = new SqlParameter("@ItemNo", argEmployeeQualificationDetails.ItemNo);

            param[8] = new SqlParameter("@CreatedBy", argEmployeeQualificationDetails.CreatedBy);
            param[9] = new SqlParameter("@ModifiedBy", argEmployeeQualificationDetails.ModifiedBy);

            param[10] = new SqlParameter("@Type", SqlDbType.Char);
            param[10].Size = 1;
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[11].Size = 255;
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[12].Size = 20;
            param[12].Direction = ParameterDirection.Output;
            param[13] = new SqlParameter("@EmployeeQualificationId", argEmployeeQualificationDetails.EmployeeQualificationId);
            int i = da.NExecuteNonQuery("Proc_InsertEmployeeQualificationDetails", param);

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

        public void UpdateEmployeeQualificationDetails(EmployeeQualificationDetails argEmployeeQualificationDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeQualificationDetails.EmployeeId);
            param[1] = new SqlParameter("@ClassId", argEmployeeQualificationDetails.ClassId);
            param[2] = new SqlParameter("@ClassName", argEmployeeQualificationDetails.ClassName);
            param[3] = new SqlParameter("@CollegeOrUniversityName", argEmployeeQualificationDetails.CollegeOrUniversityName);
            param[4] = new SqlParameter("@PassingYear", argEmployeeQualificationDetails.PassingYear);
            param[5] = new SqlParameter("@Subject", argEmployeeQualificationDetails.Subject);
            param[6] = new SqlParameter("@Percentage", argEmployeeQualificationDetails.Percentage);
            param[7] = new SqlParameter("@ItemNo", argEmployeeQualificationDetails.ItemNo);

            param[8] = new SqlParameter("@ModifiedBy", argEmployeeQualificationDetails.ModifiedBy);

            param[9] = new SqlParameter("@Type", SqlDbType.Char);
            param[9].Size = 1;
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[10].Size = 255;
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[11].Size = 20;
            param[11].Direction = ParameterDirection.Output;
            param[12] = new SqlParameter("@EmployeeQualificationId", argEmployeeQualificationDetails.EmployeeQualificationId);
            int i = da.NExecuteNonQuery("Proc_UpdateEmployeeQualificationDetails", param);

            string strMessage = Convert.ToString(param[10].Value);
            string strType = Convert.ToString(param[9].Value);
            string strRetValue = Convert.ToString(param[11].Value);

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

        public ICollection<ErrorHandlerClass> DeleteEmployeeQualificationDetails(string argEmployeeId, int iIsDeleted, string ModifiedBy, string ItemNo, string EmployeeQualificationId)
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
                param[6] = new SqlParameter("@EmployeeQualificationId", EmployeeQualificationId);
                param[7] = new SqlParameter("@ModifiedBy", ModifiedBy);
                int i = da.ExecuteNonQuery("Proc_DeleteEmployeeQualificationDetails", param);
                 
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

        public bool blnIsEmployeeQualificationDetailsExist(string EmplyeeId, int ItemNo)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetEmployeeQualificationDetails4Check(EmplyeeId, ItemNo);
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
