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
    public class EmployeeLeftDetailsManager
    {
        const string EmployeeLeftDetailsTable = "EmployeeLeftDetails";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public EmployeeLeftDetails objGetEmployeeLeftDetails(string EmployeeId)
        {
            EmployeeLeftDetails argEmployeeLeftDetails = new EmployeeLeftDetails();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetEmployeeLeftDetails4ID(EmployeeId.ToString().Trim());

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argEmployeeLeftDetails = this.objCreteEmployeeLeftDetails((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

        return argEmployeeLeftDetails;
        }

        private EmployeeLeftDetails objCreteEmployeeLeftDetails(DataRow dr)
        {
            EmployeeLeftDetails tEmployeeLeftDetails = new EmployeeLeftDetails();

            tEmployeeLeftDetails.SetObjectInfo(dr);

            return tEmployeeLeftDetails;

        }

        public DataSet GetEmployeeLeftDetails()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeLeftDetails", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeLeftDetails4ID(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeLeftDetails4ID", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeLeftDetails4Check(string EmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeLeftDetails4Check", param);
            return DataSetToFill;
        }

        public void SaveEmployeeLeftDetails(EmployeeLeftDetails objEmployeeLeftDetails, ref DataAccess da, ref List<ErrorHandlerClass> lstErr)
        {
            try
            {
                if (blnIsEmployeeLeftDetailsExist(objEmployeeLeftDetails.EmployeeId) == false)
                {
                    InsertEmployeeLeftDetails(objEmployeeLeftDetails, da, lstErr);
                }
                else
                {
                    UpdateEmployeeLeftDetails(objEmployeeLeftDetails, da, lstErr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<ErrorHandlerClass> SaveEmployeeLeftDetails(EmployeeLeftDetails objEmployeeLeftDetails)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (blnIsEmployeeLeftDetailsExist(objEmployeeLeftDetails.EmployeeId) == false)
                {
                    InsertEmployeeLeftDetails(objEmployeeLeftDetails, da, lstErr);

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
                    UpdateEmployeeLeftDetails(objEmployeeLeftDetails, da, lstErr);
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

        public void InsertEmployeeLeftDetails(EmployeeLeftDetails argEmployeeLeftDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeLeftDetails.EmployeeId);
            param[1] = new SqlParameter("@LeftDate", argEmployeeLeftDetails.LeftDate);
            param[2] = new SqlParameter("@FullnFinal", argEmployeeLeftDetails.FullnFinal);
            param[3] = new SqlParameter("@LeftReason", argEmployeeLeftDetails.LeftReason);
            param[4] = new SqlParameter("@LeavingReason4PFDepartment", argEmployeeLeftDetails.LeavingReason4PFDepartment);
            param[5] = new SqlParameter("@LeavingReason4ESIDepartment", argEmployeeLeftDetails.LeavingReason4ESIDepartment);

            param[6] = new SqlParameter("@CreatedBy", argEmployeeLeftDetails.CreatedBy);
            param[7] = new SqlParameter("@ModifiedBy", argEmployeeLeftDetails.ModifiedBy);

            param[8] = new SqlParameter("@Type", SqlDbType.Char);
            param[8].Size = 1;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[9].Size = 255;
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[10].Size = 20;
            param[10].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_InsertEmployeeLeftDetails", param);

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

        public void UpdateEmployeeLeftDetails(EmployeeLeftDetails argEmployeeLeftDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeLeftDetails.EmployeeId);
            param[1] = new SqlParameter("@LeftDate", argEmployeeLeftDetails.LeftDate);
            param[2] = new SqlParameter("@FullnFinal", argEmployeeLeftDetails.FullnFinal);
            param[3] = new SqlParameter("@LeftReason", argEmployeeLeftDetails.LeftReason);
            param[4] = new SqlParameter("@LeavingReason4PFDepartment", argEmployeeLeftDetails.LeavingReason4PFDepartment);
            param[5] = new SqlParameter("@LeavingReason4ESIDepartment", argEmployeeLeftDetails.LeavingReason4ESIDepartment);

            param[6] = new SqlParameter("@ModifiedBy", argEmployeeLeftDetails.ModifiedBy);

            param[7] = new SqlParameter("@Type", SqlDbType.Char);
            param[7].Size = 1;
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[8].Size = 255;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[9].Size = 20;
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@EmployeeLeftId", argEmployeeLeftDetails.EmployeeLeftId);
            int i = da.NExecuteNonQuery("Proc_UpdateEmployeeLeftDetails", param);

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

        public ICollection<ErrorHandlerClass> DeleteEmployeeLeftDetails(string argEmployeeId, int iIsDeleted, string ModifiedBy, string EmployeeLeftId)
        {
            DataAccess da = new DataAccess();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            try
            {
                SqlParameter[] param = new SqlParameter[7];
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
                param[5] = new SqlParameter("@EmployeeLeftId", EmployeeLeftId);
                param[6] = new SqlParameter("@ModifiedBy", ModifiedBy);
                int i = da.ExecuteNonQuery("Proc_DeleteEmployeeLeftDetails", param);

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

        public bool blnIsEmployeeLeftDetailsExist(string EmplyeeId)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetEmployeeLeftDetails4Check(EmplyeeId);
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
