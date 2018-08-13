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
    public class TaxCalculationMaster4DeductionManager
    {
        const string TDSDeductions = "TDSDeductions";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public TaxCalculationMaster4Deduction objGetTaxCalculationMaster4Deduction(string EmployeeId)
        {
            TaxCalculationMaster4Deduction argTaxCalculationMaster4Deduction = new TaxCalculationMaster4Deduction();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetTaxCalculationMaster4Deduction4ID(EmployeeId.ToString().Trim());

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argTaxCalculationMaster4Deduction = this.objCreteTaxCalculationMaster4Deduction((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

            return argTaxCalculationMaster4Deduction;
        }

        private TaxCalculationMaster4Deduction objCreteTaxCalculationMaster4Deduction(DataRow dr)
        {
            TaxCalculationMaster4Deduction tTaxCalculationMaster4Deduction = new TaxCalculationMaster4Deduction();

            tTaxCalculationMaster4Deduction.SetObjectInfo(dr);

            return tTaxCalculationMaster4Deduction;
        }

        public DataSet GetTaxableDeduction()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetTaxableDeduction", param);
            return DataSetToFill;
        }

        public DataSet GetTaxableEarning()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetTaxableEarning", param);
            return DataSetToFill;
        }

        public DataSet GetTaxCalculationMaster4Deduction()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetTDSDeductions", param);
            return DataSetToFill;
        }

        public DataSet GetTaxCalculationMaster4Deduction4ID(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetTDSDeductions4Id", param);
            return DataSetToFill;
        }

        public DataSet GetTaxCalculationMaster4Deduction4Check(string EmployeeId, int ItemNo,int TDSNo)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            param[1] = new SqlParameter("@ItemNo", ItemNo);
            param[2] = new SqlParameter("@TDSNo", TDSNo);
            DataSetToFill = da.FillDataSet("Proc_GetTDSDeductions4Check", param);
            return DataSetToFill;
        }

        public ICollection<ErrorHandlerClass> SaveTaxCalculationMaster4Deduction(TaxCalculationMaster4Deduction objTaxCalculationMaster4Deduction)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (blnIsTaxCalculationMaster4DeductionExist(objTaxCalculationMaster4Deduction.EmployeeId, objTaxCalculationMaster4Deduction.ItemNo, objTaxCalculationMaster4Deduction.TDSNo) == false)
                {
                    InsertTaxCalculationMaster4Deduction(objTaxCalculationMaster4Deduction, da, lstErr);

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
                    UpdateTaxCalculationMaster4Deduction(objTaxCalculationMaster4Deduction, da, lstErr);
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

        public void InsertTaxCalculationMaster4Deduction(TaxCalculationMaster4Deduction argTaxCalculationMaster4Deduction, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@EmployeeId", argTaxCalculationMaster4Deduction.EmployeeId);
            param[1] = new SqlParameter("@TDSNo", argTaxCalculationMaster4Deduction.TDSNo);
            param[2] = new SqlParameter("@ItemNo", argTaxCalculationMaster4Deduction.ItemNo);
            param[3] = new SqlParameter("@TaxableDeduction", argTaxCalculationMaster4Deduction.TaxableDeduction);
            param[4] = new SqlParameter("@TaxableAmount", argTaxCalculationMaster4Deduction.TaxableAmount);

            param[5] = new SqlParameter("@CreatedBy", argTaxCalculationMaster4Deduction.CreatedBy);
            param[6] = new SqlParameter("@ModifiedBy", argTaxCalculationMaster4Deduction.ModifiedBy);
            

            param[7] = new SqlParameter("@Type", SqlDbType.Char);
            param[7].Size = 1;
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[8].Size = 255;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[9].Size = 20;
            param[9].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_InsertTDSDeductions", param);

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

        public void UpdateTaxCalculationMaster4Deduction(TaxCalculationMaster4Deduction argTaxCalculationMaster4Deduction, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@EmployeeId", argTaxCalculationMaster4Deduction.EmployeeId);
            param[1] = new SqlParameter("@TDSNo", argTaxCalculationMaster4Deduction.TDSNo);
            param[2] = new SqlParameter("@ItemNo", argTaxCalculationMaster4Deduction.ItemNo);
            param[3] = new SqlParameter("@TaxableAmount", argTaxCalculationMaster4Deduction.TaxableAmount);

            param[4] = new SqlParameter("@ModifiedBy", argTaxCalculationMaster4Deduction.ModifiedBy);


            param[5] = new SqlParameter("@Type", SqlDbType.Char);
            param[5].Size = 1;
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[6].Size = 255;
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[7].Size = 20;
            param[7].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_UpdateTDSDeductions", param);

            string strMessage = Convert.ToString(param[6].Value);
            string strType = Convert.ToString(param[5].Value);
            string strRetValue = Convert.ToString(param[7].Value);

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

        public ICollection<ErrorHandlerClass> DeleteTaxCalculationMaster4Deduction(string argEmployeeId, int iIsDeleted)
        {
            DataAccess da = new DataAccess();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            try
            {
                SqlParameter[] param = new SqlParameter[5];
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
                int i = da.ExecuteNonQuery("Proc_DeleteTaxCalculationMaster4Deduction", param);

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

        public bool blnIsTaxCalculationMaster4DeductionExist(string EmplyeeId, int ItemNo, int TDSNo)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetTaxCalculationMaster4Deduction4Check(EmplyeeId, ItemNo,TDSNo);
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

        public DataSet GenerateTDSDeductiond()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GenerateTDSDeductionId", param);
            return DataSetToFill;
        }

    }
}
