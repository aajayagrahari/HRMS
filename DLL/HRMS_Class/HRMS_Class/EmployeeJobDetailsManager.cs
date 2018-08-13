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
    public class EmployeeJobDetailsManager
    {
        const string EmployeeJobDetailsTable = "EmployeeJobDetails";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public EmployeeJobDetails objGetEmployeeJobDetails(string EmployeeId)
        {
            EmployeeJobDetails argEmployeeJobDetails = new EmployeeJobDetails();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetEmployeeJobDetails4ID(EmployeeId.ToString().Trim());

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argEmployeeJobDetails = this.objCreteEmployeeJobDetails((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

        return argEmployeeJobDetails;
        }

        private EmployeeJobDetails objCreteEmployeeJobDetails(DataRow dr)
        {
            EmployeeJobDetails tEmployeeJobDetails = new EmployeeJobDetails();

            tEmployeeJobDetails.SetObjectInfo(dr);

            return tEmployeeJobDetails;

        }

        public DataSet GetEmployeeJobDetails()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeJobDetails", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeJobDetails4ID(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeJobDetails4ID", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeJobDetails4Check(string EmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeJobDetails4Check", param);
            return DataSetToFill;
        }

        public void SaveEmployeeJobDetails(EmployeeJobDetails objEmployeeJobDetails, ref DataAccess da, ref List<ErrorHandlerClass> lstErr)
        {
            try
            {
                if (blnIsEmployeeJobDetailsExist(objEmployeeJobDetails.EmployeeId) == false)
                {
                    InsertEmployeeJobDetails(objEmployeeJobDetails, da, lstErr);
                }
                else
                {
                    UpdateEmployeeJobDetails(objEmployeeJobDetails, da, lstErr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<ErrorHandlerClass> SaveEmployeeJobDetails(EmployeeJobDetails objEmployeeJobDetails)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (blnIsEmployeeJobDetailsExist(objEmployeeJobDetails.EmployeeId) == false)
                {
                    InsertEmployeeJobDetails(objEmployeeJobDetails, da, lstErr);

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
                    UpdateEmployeeJobDetails(objEmployeeJobDetails, da, lstErr);
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

        public void InsertEmployeeJobDetails(EmployeeJobDetails argEmployeeJobDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[29];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeJobDetails.EmployeeId);
            param[1] = new SqlParameter("@ApplicationDate", argEmployeeJobDetails.ApplicationDate);
            param[2] = new SqlParameter("@InterviewDate", argEmployeeJobDetails.InterviewDate);
            param[3] = new SqlParameter("@JoiningDate", argEmployeeJobDetails.JoiningDate);
            param[4] = new SqlParameter("@ConfirmationDate", argEmployeeJobDetails.ConfirmationDate);
            param[5] = new SqlParameter("@SalartyStopAfter", argEmployeeJobDetails.SalartyStopAfter);
            param[6] = new SqlParameter("@ContractStartDate", argEmployeeJobDetails.ContractStartDate);
            param[7] = new SqlParameter("@ContractEndDate", argEmployeeJobDetails.ContractEndDate);
            param[8] = new SqlParameter("@DateOfTransfer", argEmployeeJobDetails.DateOfTransfer);
            param[9] = new SqlParameter("@PFStartDate", argEmployeeJobDetails.PFStartDate);
            param[10] = new SqlParameter("@EPSStartDate ", argEmployeeJobDetails.EPSStartDate);
            param[11] = new SqlParameter("@ESISStartDate", argEmployeeJobDetails.ESISStartDate);
            param[12] = new SqlParameter("@Category", argEmployeeJobDetails.Category);
            param[13] = new SqlParameter("@Grade", argEmployeeJobDetails.Grade);
            param[14] = new SqlParameter("@Lavel", argEmployeeJobDetails.Lavel);
            param[15] = new SqlParameter("@Location", argEmployeeJobDetails.Location);
            param[16] = new SqlParameter("@Status", argEmployeeJobDetails.Status);
            param[17] = new SqlParameter("@AdharCardNo", argEmployeeJobDetails.AdharCardNo);
            param[18] = new SqlParameter("PSNo", argEmployeeJobDetails.PSNo);
            param[19] = new SqlParameter("@ESIDispensary", argEmployeeJobDetails.ESIDispensary);
            param[20] = new SqlParameter("@PlacementBy", argEmployeeJobDetails.PlacementBy);
            param[21] = new SqlParameter("@BossReportTo", argEmployeeJobDetails.BossReportTo);

            param[22] = new SqlParameter("@CreatedBy", argEmployeeJobDetails.CreatedBy);
            param[23] = new SqlParameter("@ModifiedBy", argEmployeeJobDetails.ModifiedBy);
            param[24] = new SqlParameter("@NSSNo", argEmployeeJobDetails.NSSNo);
            param[25] = new SqlParameter("@AppointmentLetterIssueDate", argEmployeeJobDetails.AppointmentLetterIssueDate);

            param[26] = new SqlParameter("@Type", SqlDbType.Char);
            param[26].Size = 1;
            param[26].Direction = ParameterDirection.Output;

            param[27] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[27].Size = 255;
            param[27].Direction = ParameterDirection.Output;

            param[28] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[28].Size = 20;
            param[28].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_InsertEmployeeJobDetails", param);

            string strMessage = Convert.ToString(param[27].Value);
            string strType = Convert.ToString(param[26].Value);
            string strRetValue = Convert.ToString(param[28].Value);

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

        public void UpdateEmployeeJobDetails(EmployeeJobDetails argEmployeeJobDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[29];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeJobDetails.EmployeeId);
            param[1] = new SqlParameter("@ApplicationDate", argEmployeeJobDetails.ApplicationDate);
            param[2] = new SqlParameter("@InterviewDate", argEmployeeJobDetails.InterviewDate);
            param[3] = new SqlParameter("@JoiningDate", argEmployeeJobDetails.JoiningDate);
            param[4] = new SqlParameter("@ConfirmationDate", argEmployeeJobDetails.ConfirmationDate);
            param[5] = new SqlParameter("@SalartyStopAfter", argEmployeeJobDetails.SalartyStopAfter);
            param[6] = new SqlParameter("@ContractStartDate", argEmployeeJobDetails.ContractStartDate);
            param[7] = new SqlParameter("@ContractEndDate", argEmployeeJobDetails.ContractEndDate);
            param[8] = new SqlParameter("@DateOfTransfer", argEmployeeJobDetails.DateOfTransfer);
            param[9] = new SqlParameter("@PFStartDate", argEmployeeJobDetails.PFStartDate);
            param[10] = new SqlParameter("@EPSStartDate ", argEmployeeJobDetails.EPSStartDate);
            param[11] = new SqlParameter("@ESISStartDate", argEmployeeJobDetails.ESISStartDate);
            param[12] = new SqlParameter("@Category", argEmployeeJobDetails.Category);
            param[13] = new SqlParameter("@Grade", argEmployeeJobDetails.Grade);
            param[14] = new SqlParameter("@Lavel", argEmployeeJobDetails.Lavel);
            param[15] = new SqlParameter("@Location", argEmployeeJobDetails.Location);
            param[16] = new SqlParameter("@Status", argEmployeeJobDetails.Status);
            param[17] = new SqlParameter("@AdharCardNo", argEmployeeJobDetails.AdharCardNo);
            param[18] = new SqlParameter("PSNo", argEmployeeJobDetails.PSNo);
            param[19] = new SqlParameter("@ESIDispensary", argEmployeeJobDetails.ESIDispensary);
            param[20] = new SqlParameter("@PlacementBy", argEmployeeJobDetails.PlacementBy);
            param[21] = new SqlParameter("@BossReportTo", argEmployeeJobDetails.BossReportTo);

            param[22] = new SqlParameter("@ModifiedBy", argEmployeeJobDetails.ModifiedBy);
            param[23] = new SqlParameter("@NSSNo", argEmployeeJobDetails.NSSNo);
            param[24] = new SqlParameter("@AppointmentLetterIssueDate", argEmployeeJobDetails.AppointmentLetterIssueDate);

            param[25] = new SqlParameter("@Type", SqlDbType.Char);
            param[25].Size = 1;
            param[25].Direction = ParameterDirection.Output;

            param[26] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[26].Size = 255;
            param[26].Direction = ParameterDirection.Output;

            param[27] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[27].Size = 20;
            param[27].Direction = ParameterDirection.Output;
            param[28] = new SqlParameter("@EmployeeJobId", argEmployeeJobDetails.EmployeeJobId);
            int i = da.NExecuteNonQuery("Proc_UpdateEmployeeJobDetails", param);

            string strMessage = Convert.ToString(param[26].Value);
            string strType = Convert.ToString(param[25].Value);
            string strRetValue = Convert.ToString(param[27].Value);

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

        public ICollection<ErrorHandlerClass> DeleteEmployeeJobDetails(string argEmployeeId, int iIsDeleted, string LoginId, string EmployeeJobId)
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
                param[5] = new SqlParameter("@ModifiedBy", LoginId);
                param[6] = new SqlParameter("@EmployeeJobId",EmployeeJobId);


                int i = da.ExecuteNonQuery("Proc_DeleteEmployeeJobDetails", param);

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

        public bool blnIsEmployeeJobDetailsExist(string EmplyeeId)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetEmployeeJobDetails4Check(EmplyeeId);
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
