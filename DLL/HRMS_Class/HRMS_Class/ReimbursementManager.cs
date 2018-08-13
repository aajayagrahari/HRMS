using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ErrorHandler;
using HRMS_Class;
using System.Data;
using HRMS_Connection;

#region Developnet Detatil
//Developer Name: Shruti Dwivedi
//Date:           19-10-2013
#endregion Developnet Detatil

namespace HRMS_Class
{
    public class ReimbursementManager
    {
        const string ReimbursementTable = "Reimbursement";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();
        ReimbursementDetailDetailManager _objReimbursementDetailDetailManager = new ReimbursementDetailDetailManager();

        public DataSet GetReImburstmentDetails4Admin()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetReImburstment4Admin", param);
            return DataSetToFill;
        }
        public DataSet GetReimbursement()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetReimbursement", param);
            return DataSetToFill;
        }
        public DataSet GetReimbursementById(Int32 ReimbursementId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ReimbursementId", ReimbursementId);
            DataSetToFill = da.FillDataSet("Proc_GetReimbursement4Id", param);
            return DataSetToFill;
        }

        public ICollection<ErrorHandlerClass> SaveReimbursement(Reimbursement objReimbursement, ICollection<ReimbursementDetail> colReimbursementDetail)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                string strReimbursementId = InsertReimbursement(objReimbursement, da, lstErr);

                foreach (ErrorHandlerClass objerr in lstErr)
                {
                    if (objerr.Type == "E")
                    {
                        da.ROLLBACK_TRANSACTION();
                        return lstErr;
                    }
                }
                if (strReimbursementId != "")
                {
                    if (colReimbursementDetail.Count > 0)
                    {
                        foreach(ReimbursementDetail argReimbursementDetail in colReimbursementDetail)
                        {
                            argReimbursementDetail.ReimbursementId = Convert.ToInt32(strReimbursementId);
                            _objReimbursementDetailDetailManager.SaveReimbursementDetail(argReimbursementDetail);
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

        public ICollection<ErrorHandlerClass> UpdateReimbursement(Reimbursement objReimbursement)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                UpdateReimbursement(objReimbursement, da, lstErr);

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

        public ICollection<ErrorHandlerClass> DeleteReimbursement(Reimbursement objReimbursement)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                DeleteReimbursement(objReimbursement, da, lstErr);

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

        public string InsertReimbursement(Reimbursement argReimbursement, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@ReimbursementId", argReimbursement.ReimbursementId);
            param[1] = new SqlParameter("@EmployeeId", argReimbursement.EmployeeId);
            param[2] = new SqlParameter("@EmployeeName", argReimbursement.EmployeeName);
            param[3] = new SqlParameter("@ManagerName", argReimbursement.ManagerName);
            param[4] = new SqlParameter("@Department", argReimbursement.Department);
            param[5] = new SqlParameter("@FromDate", argReimbursement.FromDate);
            param[6] = new SqlParameter("@ToDate", argReimbursement.ToDate);
            param[7] = new SqlParameter("@BusinessPurpose", argReimbursement.BusinessPurpose);
            param[8] = new SqlParameter("@CreatedBy", argReimbursement.CreatedBy);

            param[9] = new SqlParameter("@Type", SqlDbType.Char);
            param[9].Size = 1;
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[10].Size = 255;
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[11].Size = 20;
            param[11].Direction = ParameterDirection.Output;
            

            int i = da.NExecuteNonQuery("Proc_InsertReimbursement", param);

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
            return strRetValue;
        }

        public string UpdateReimbursement(Reimbursement argReimbursement, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@ReimbursementId", argReimbursement.ReimbursementId);
            param[1] = new SqlParameter("@EmployeeId", argReimbursement.EmployeeId);
            param[2] = new SqlParameter("@EmployeeName", argReimbursement.EmployeeName);
            param[3] = new SqlParameter("@ManagerName", argReimbursement.ManagerName);
            param[4] = new SqlParameter("@Department", argReimbursement.Department);
            param[5] = new SqlParameter("@FromDate", argReimbursement.FromDate);
            param[6] = new SqlParameter("@ToDate", argReimbursement.ToDate);
            param[7] = new SqlParameter("@BusinessPurpose", argReimbursement.BusinessPurpose);
            param[8] = new SqlParameter("@ModifiedBy", argReimbursement.ModifiedBy);

            param[9] = new SqlParameter("@Type", SqlDbType.Char);
            param[9].Size = 1;
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[10].Size = 255;
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[11].Size = 20;
            param[11].Direction = ParameterDirection.Output;


            int i = da.NExecuteNonQuery("Proc_UpdateReimbursement", param);

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

            return strRetValue;
        }

        public string DeleteReimbursement(Reimbursement argReimbursement, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ReimbursementId", argReimbursement.ReimbursementId);
            param[1] = new SqlParameter("@ModifiedBy", argReimbursement.ModifiedBy);
            param[2] = new SqlParameter("@Type", SqlDbType.Char);
            param[2].Size = 1;
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[3].Size = 255;
            param[3].Direction = ParameterDirection.Output;

            param[4] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[4].Size = 20;
            param[4].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_DeleteReimbursement", param);

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
