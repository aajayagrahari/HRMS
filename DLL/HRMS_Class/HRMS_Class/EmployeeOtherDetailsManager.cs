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
    public class EmployeeOtherDetailsManager
    {
        const string EmployeeOtherDetailsTable = "EmployeeOtherDetails";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public EmployeeOtherDetails objGetEmployeeOtherDetails(string EmployeeId)
        {
            EmployeeOtherDetails argEmployeeOtherDetails = new EmployeeOtherDetails();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetEmployeeOtherDetails4ID(EmployeeId.ToString().Trim());

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argEmployeeOtherDetails = this.objCreteEmployeeOtherDetails((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

        return argEmployeeOtherDetails;
        }

        private EmployeeOtherDetails objCreteEmployeeOtherDetails(DataRow dr)
        {
            EmployeeOtherDetails tEmployeeOtherDetails = new EmployeeOtherDetails();

            tEmployeeOtherDetails.SetObjectInfo(dr);

            return tEmployeeOtherDetails;

        }

        public DataSet GetEmployeeOtherDetails()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeOtherDetails", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeOtherDetails4ID(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeOtherDetails4ID", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeOtherDetails4Check(string EmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeOtherDetails4Check", param);
            return DataSetToFill;
        }

        public void SaveEmployeeOtherDetails(EmployeeOtherDetails objEmployeeOtherDetails, ref DataAccess da, ref List<ErrorHandlerClass> lstErr)
        {
            try
            {
                if (blnIsEmployeeOtherDetailsExist(objEmployeeOtherDetails.EmployeeId) == false)
                {
                    InsertEmployeeOtherDetails(objEmployeeOtherDetails, da, lstErr);
                }
                else
                {
                    UpdateEmployeeOtherDetails(objEmployeeOtherDetails, da, lstErr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<ErrorHandlerClass> SaveEmployeeOtherDetails(EmployeeOtherDetails objEmployeeOtherDetails)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (blnIsEmployeeOtherDetailsExist(objEmployeeOtherDetails.EmployeeId) == false)
                {
                    InsertEmployeeOtherDetails(objEmployeeOtherDetails, da, lstErr);

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
                    UpdateEmployeeOtherDetails(objEmployeeOtherDetails, da, lstErr);
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

        public void InsertEmployeeOtherDetails(EmployeeOtherDetails argEmployeeOtherDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[22];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeOtherDetails.EmployeeId);
            param[1] = new SqlParameter("@SalaryType", argEmployeeOtherDetails.SalaryType);
            param[2] = new SqlParameter("@LateRateType", argEmployeeOtherDetails.LateRateType);
            param[3] = new SqlParameter("@Skilled", argEmployeeOtherDetails.Skilled);
            param[4] = new SqlParameter("@Category", argEmployeeOtherDetails.Category);
            param[5] = new SqlParameter("@OTRateType", argEmployeeOtherDetails.OTRateType);
            param[6] = new SqlParameter("@OTRate", argEmployeeOtherDetails.OTRate);
            param[7] = new SqlParameter("@LatePenaltyRate", argEmployeeOtherDetails.LatePenaltyRate);
            
            param[8] = new SqlParameter("@IncrementDueDate", argEmployeeOtherDetails.IncrementDueDate);
            param[9] = new SqlParameter("@IncrementMonth", argEmployeeOtherDetails.IncrementMonth);
            param[10] = new SqlParameter("@BasicPayIncrementAs ", argEmployeeOtherDetails.BasicPayIncrementAs);
            param[11] = new SqlParameter("@IdentityCardValidity", argEmployeeOtherDetails.IdentityCardValidity);
            param[12] = new SqlParameter("@SalaryCalculationDays", argEmployeeOtherDetails.SalaryCalculationDays);
            param[13] = new SqlParameter("@GeneralWorkingHours", argEmployeeOtherDetails.GeneralWorkingHours);
            param[14] = new SqlParameter("@OTCalculationDays", argEmployeeOtherDetails.OTCalculationDays);
            param[15] = new SqlParameter("@OTWorkingHours", argEmployeeOtherDetails.OTWorkingHours);
            param[16] = new SqlParameter("@TotalDaysInMonth", argEmployeeOtherDetails.TotalDaysInMonth);

            param[17] = new SqlParameter("@CreatedBy", argEmployeeOtherDetails.CreatedBy);
            param[18] = new SqlParameter("@ModifiedBy", argEmployeeOtherDetails.ModifiedBy);

            param[19] = new SqlParameter("@Type", SqlDbType.Char);
            param[19].Size = 1;
            param[19].Direction = ParameterDirection.Output;

            param[20] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[20].Size = 255;
            param[20].Direction = ParameterDirection.Output;

            param[21] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[21].Size = 20;
            param[21].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_InsertEmployeeOtherDetails", param);

            string strMessage = Convert.ToString(param[20].Value);
            string strType = Convert.ToString(param[19].Value);
            string strRetValue = Convert.ToString(param[21].Value);

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

        public void UpdateEmployeeOtherDetails(EmployeeOtherDetails argEmployeeOtherDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[22];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeOtherDetails.EmployeeId);
            param[1] = new SqlParameter("@SalaryType", argEmployeeOtherDetails.SalaryType);
            param[2] = new SqlParameter("@LateRateType", argEmployeeOtherDetails.LateRateType);
            param[3] = new SqlParameter("@Skilled", argEmployeeOtherDetails.Skilled);
            param[4] = new SqlParameter("@Category", argEmployeeOtherDetails.Category);
            param[5] = new SqlParameter("@OTRateType", argEmployeeOtherDetails.OTRateType);
            param[6] = new SqlParameter("@OTRate", argEmployeeOtherDetails.OTRate);
            param[7] = new SqlParameter("@LatePenaltyRate", argEmployeeOtherDetails.LatePenaltyRate);
            param[8] = new SqlParameter("@IncrementDueDate", argEmployeeOtherDetails.IncrementDueDate);
            param[9] = new SqlParameter("@IncrementMonth", argEmployeeOtherDetails.IncrementMonth);
            param[10] = new SqlParameter("@BasicPayIncrementAs ", argEmployeeOtherDetails.BasicPayIncrementAs);
            param[11] = new SqlParameter("@IdentityCardValidity", argEmployeeOtherDetails.IdentityCardValidity);
            param[12] = new SqlParameter("@SalaryCalculationDays", argEmployeeOtherDetails.SalaryCalculationDays);
            param[13] = new SqlParameter("@GeneralWorkingHours", argEmployeeOtherDetails.GeneralWorkingHours);
            param[14] = new SqlParameter("@OTCalculationDays", argEmployeeOtherDetails.OTCalculationDays);
            param[15] = new SqlParameter("@OTWorkingHours", argEmployeeOtherDetails.OTWorkingHours);
            param[16] = new SqlParameter("@TotalDaysInMonth", argEmployeeOtherDetails.TotalDaysInMonth);

            param[17] = new SqlParameter("@ModifiedBy", argEmployeeOtherDetails.ModifiedBy);

            param[18] = new SqlParameter("@Type", SqlDbType.Char);
            param[18].Size = 1;
            param[18].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[19].Size = 255;
            param[19].Direction = ParameterDirection.Output;

            param[20] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[20].Size = 20;
            param[20].Direction = ParameterDirection.Output;
            param[21] = new SqlParameter("@EmployeeOtherId", argEmployeeOtherDetails.EmployeeOtherId);
            int i = da.NExecuteNonQuery("Proc_UpdateEmployeeOtherDetails", param);

            string strMessage = Convert.ToString(param[19].Value);
            string strType = Convert.ToString(param[18].Value);
            string strRetValue = Convert.ToString(param[20].Value);

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

        public ICollection<ErrorHandlerClass> DeleteEmployeeOtherDetails(string argEmployeeId, int iIsDeleted, string ModifiedBy, string EmployeeOtherId)
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
                param[5] = new SqlParameter("@EmployeeOtherId", EmployeeOtherId);
                param[6] = new SqlParameter("@ModifiedBy", ModifiedBy);
                int i = da.ExecuteNonQuery("Proc_DeleteEmployeeOtherDetails", param);

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

        public bool blnIsEmployeeOtherDetailsExist(string EmplyeeId)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetEmployeeOtherDetails4Check(EmplyeeId);
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
