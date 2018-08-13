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
    public class TaxCalculationMasterManager
    {
        const string TDS4Earning = "TDS4Earning";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();
        TaxCalculationMaster4DeductionManager objTaxCalculationMaster4DeductionManager = new TaxCalculationMaster4DeductionManager();

        public TaxCalculationMaster objGetTaxCalculationMaster(string EmployeeId)
        {
            TaxCalculationMaster argTaxCalculationMaster = new TaxCalculationMaster();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetTaxCalculationMaster4ID(EmployeeId.ToString().Trim());

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argTaxCalculationMaster = this.objCreteTaxCalculationMaster((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

            return argTaxCalculationMaster;
        }

        private TaxCalculationMaster objCreteTaxCalculationMaster(DataRow dr)
        {
            TaxCalculationMaster tTaxCalculationMaster = new TaxCalculationMaster();

            tTaxCalculationMaster.SetObjectInfo(dr);

            return tTaxCalculationMaster;
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

        public DataSet GetTaxCalculationMaster()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetTDS4Earning", param);
            return DataSetToFill;
        }

        public DataSet GetTaxCalculationMaster4ID(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetTDS4Earning4Id", param);
            return DataSetToFill;
        }

        public DataSet GetTaxCalculationMaster4Check(string EmployeeId, int ItemNo, int TDSNo)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            param[1] = new SqlParameter("@ItemNo", ItemNo);
            param[2] = new SqlParameter("@TDSNo", TDSNo);
            DataSetToFill = da.FillDataSet("Proc_GetTDS4Earning4Check", param);
            return DataSetToFill;
        }

        public ICollection<ErrorHandlerClass> SaveTaxCalculationMaster(ICollection<TaxCalculationMaster> colTaxCalculationMaster, ICollection<TaxCalculationMaster4Deduction> colTaxCalculationMaster4Deduction)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (colTaxCalculationMaster.Count > 0)
                {
                    foreach (TaxCalculationMaster argTaxCalculationMaster in colTaxCalculationMaster)
                    {
                        if (blnIsTaxCalculationMasterExist(argTaxCalculationMaster.EmployeeId, argTaxCalculationMaster.ItemNo, argTaxCalculationMaster.TDSNo) == false)
                        {
                            InsertTaxCalculationMaster(argTaxCalculationMaster, da, lstErr);
                            foreach (ErrorHandlerClass objerr in lstErr)
                            {
                                if (objerr.Type == "E")
                                {
                                    da.ROLLBACK_TRANSACTION();
                                    return lstErr;
                                }
                            }
                            //da.COMMIT_TRANSACTION();
                        }
                        else
                        {
                            UpdateTaxCalculationMaster(argTaxCalculationMaster, da, lstErr);
                            foreach (ErrorHandlerClass objerr in lstErr)
                            {
                                if (objerr.Type == "E")
                                {
                                    da.ROLLBACK_TRANSACTION();
                                    return lstErr;
                                }
                            }
                            //da.COMMIT_TRANSACTION();
                        }
                    }

                    da.COMMIT_TRANSACTION();

                    if (colTaxCalculationMaster4Deduction.Count > 0)
                    {
                        foreach (TaxCalculationMaster4Deduction argTaxCalculationMaster4Deduction in colTaxCalculationMaster4Deduction)
                        {
                            objTaxCalculationMaster4DeductionManager.SaveTaxCalculationMaster4Deduction(argTaxCalculationMaster4Deduction);
                        }
                    }
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

        public void InsertTaxCalculationMaster(TaxCalculationMaster argTaxCalculationMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@EmployeeId", argTaxCalculationMaster.EmployeeId);
            param[1] = new SqlParameter("@TDSNo", argTaxCalculationMaster.TDSNo);
            param[2] = new SqlParameter("@ItemNo", argTaxCalculationMaster.ItemNo);
            param[3] = new SqlParameter("@TaxableAllowance", argTaxCalculationMaster.TaxableAllowance);
            param[4] = new SqlParameter("@TaxableAmount", argTaxCalculationMaster.TaxableAmount);

            param[5] = new SqlParameter("@CreatedBy", argTaxCalculationMaster.CreatedBy);
            param[6] = new SqlParameter("@ModifiedBy", argTaxCalculationMaster.ModifiedBy);


            param[7] = new SqlParameter("@Type", SqlDbType.Char);
            param[7].Size = 1;
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[8].Size = 255;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[9].Size = 20;
            param[9].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_InsertTDS4Earning", param);

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

        public void UpdateTaxCalculationMaster(TaxCalculationMaster argTaxCalculationMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@EmployeeId", argTaxCalculationMaster.EmployeeId);
            param[1] = new SqlParameter("@TDSNo", argTaxCalculationMaster.TDSNo);
            param[2] = new SqlParameter("@ItemNo", argTaxCalculationMaster.ItemNo);
            param[3] = new SqlParameter("@TaxableAmount", argTaxCalculationMaster.TaxableAmount);

            param[4] = new SqlParameter("@ModifiedBy", argTaxCalculationMaster.ModifiedBy);


            param[5] = new SqlParameter("@Type", SqlDbType.Char);
            param[5].Size = 1;
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[6].Size = 255;
            param[6].Direction = ParameterDirection.Output;

            param[7] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[7].Size = 20;
            param[7].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_UpdateTDS4Earning", param);

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

        public ICollection<ErrorHandlerClass> DeleteTaxCalculationMaster(string argEmployeeId, int iIsDeleted)
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
                int i = da.ExecuteNonQuery("Proc_DeleteTaxCalculationMaster", param);

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

        public bool blnIsTaxCalculationMasterExist(string EmplyeeId, int ItemNo, int TDSNo)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetTaxCalculationMaster4Check(EmplyeeId, ItemNo, TDSNo);
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

        public DataSet GenerateTDSEarningId()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GenerateTDSEarningId", param);
            return DataSetToFill;
        }

    }
}
