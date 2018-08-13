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

    public class EmployeePromotionDetailsManager
    {
        const string EmployeePromotionMasterTable = "EmployeePromotionMaster";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();
        PromotionEarningDetailsManager objPromotionEarningDetailsManager = new PromotionEarningDetailsManager();
        PromotionDeductionDetailsManager objPromotionDeductionDetailsManager = new PromotionDeductionDetailsManager();
        PromotionLeaveDetailsManager objPromotionLeaveDetailsManager = new PromotionLeaveDetailsManager();

        EmployeeMasterDetailsManager objEmployeeMasterDetailsManager = new EmployeeMasterDetailsManager();

        public EmployeePromotionDetails objGetEmployeePromotionMaster(string EmployeeId)
        {
            EmployeePromotionDetails argEmployeePromotionDetails = new EmployeePromotionDetails();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetEmployeePromotionMaster4ID(EmployeeId.ToString().Trim());

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argEmployeePromotionDetails = this.objCreteEmployeePromotionMaster((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

        return argEmployeePromotionDetails;
        }

        private EmployeePromotionDetails objCreteEmployeePromotionMaster(DataRow dr)
        {
            EmployeePromotionDetails tEmployeePromotionMaster = new EmployeePromotionDetails();

            tEmployeePromotionMaster.SetObjectInfo(dr);

            return tEmployeePromotionMaster;

        }

        public DataSet GetEmployeePromotionMaster()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetEmployeePromotionMaster", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeePromotionMaster4ID(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeePromotionMaster4ID", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeePromotionMaster4Check(string EmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeePromotionMaster4Check", param);
            return DataSetToFill;
        }

        public ICollection<ErrorHandlerClass> SaveEmployeePromotionMaster(EmployeePromotionDetails objEmployeePromotionMaster, ICollection<PromotionEarningDetails> colPromotionEarningDetails, ICollection<PromotionDeductionDetails> colPromotionDeductionDetails, ICollection<PromotionLeaveDetails> colPromotionLeaveDetails)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            string strretValue = "";
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                //if (blnIsEmployeePromotionMasterExist(objEmployeePromotionMaster.EmployeeId) == false)
                //{
                    strretValue = InsertEmployeePromotionMaster(objEmployeePromotionMaster, da, lstErr);

                    if (strretValue != "")
                    {
                        UpdateEmployeePromotionDetails(objEmployeePromotionMaster, da, lstErr);
                    }
                //}
                //else
                //{
                //    //strretValue = UpdateEmployeePromotionMaster(objEmployeePromotionMaster, da, lstErr);
                //}

                foreach (ErrorHandlerClass objerr in lstErr)
                {
                    if (objerr.Type == "E")
                    {
                        da.ROLLBACK_TRANSACTION();
                        return lstErr;
                    }

                    if (objerr.Type == "A")
                    {
                        da.ROLLBACK_TRANSACTION();
                        return lstErr;
                    }
                }

                if (strretValue != "")
                {

                    if (colPromotionEarningDetails.Count > 0)
                    {
                        foreach (PromotionEarningDetails argPromotionEarningDetails in colPromotionEarningDetails)
                        {
                            argPromotionEarningDetails.EmployeePromotionNo = Convert.ToInt32(strretValue);
                            objPromotionEarningDetailsManager.SavePromotionEarningDetails(argPromotionEarningDetails);
                        }
                    }

                    if (colPromotionDeductionDetails.Count > 0)
                    {
                        foreach (PromotionDeductionDetails argPromotionDeductionDetails in colPromotionDeductionDetails)
                        {
                            argPromotionDeductionDetails.EmployeePromotionNo = Convert.ToInt32(strretValue);
                            objPromotionDeductionDetailsManager.SavePromotionDeductionDetails(argPromotionDeductionDetails);
                        }
                    }

                    if (colPromotionLeaveDetails.Count > 0)
                    {
                        foreach (PromotionLeaveDetails argPromotionLeaveDetails in colPromotionLeaveDetails)
                        {
                            argPromotionLeaveDetails.EmployeePromotionNo = Convert.ToInt32(strretValue);
                            objPromotionLeaveDetailsManager.SavePromotionLeaveDetails(argPromotionLeaveDetails);
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

        public string InsertEmployeePromotionMaster(EmployeePromotionDetails argEmployeePromotionMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@EmployeeId", argEmployeePromotionMaster.EmployeeId);
            param[1] = new SqlParameter("@CurrentDept", argEmployeePromotionMaster.CurrentDept);
            param[2] = new SqlParameter("@CurrentDesig", argEmployeePromotionMaster.CurrentDesig);
            param[3] = new SqlParameter("@NewDept", argEmployeePromotionMaster.NewDept);
            param[4] = new SqlParameter("@NewDesig", argEmployeePromotionMaster.NewDesig);
            param[5] = new SqlParameter("@JoiningDate", argEmployeePromotionMaster.JoiningDate);
            param[6] = new SqlParameter("@PromotionDate", argEmployeePromotionMaster.PromotionDate);

            param[7] = new SqlParameter("@CreatedBy", argEmployeePromotionMaster.CreatedBy);
            param[8] = new SqlParameter("@ModifiedBy", argEmployeePromotionMaster.ModifiedBy);
            

            param[9] = new SqlParameter("@Type", SqlDbType.Char);
            param[9].Size = 1;
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[10].Size = 255;
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[11].Size = 20;
            param[11].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_InsertEmployeePromotionMaster", param);

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

        public string UpdateEmployeePromotionMaster(EmployeePromotionDetails argEmployeePromotionMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@EmployeeId", argEmployeePromotionMaster.EmployeeId);
            param[1] = new SqlParameter("@CurrentDept", argEmployeePromotionMaster.CurrentDept);
            param[2] = new SqlParameter("@CurrentDesig", argEmployeePromotionMaster.CurrentDesig);
            param[3] = new SqlParameter("@NewDept", argEmployeePromotionMaster.NewDept);
            param[4] = new SqlParameter("@NewDesig", argEmployeePromotionMaster.NewDesig);
            param[5] = new SqlParameter("@JoiningDate", argEmployeePromotionMaster.JoiningDate);
            param[6] = new SqlParameter("@PromotionDate", argEmployeePromotionMaster.PromotionDate);

            param[7] = new SqlParameter("@ModifiedBy", argEmployeePromotionMaster.ModifiedBy);


            param[8] = new SqlParameter("@Type", SqlDbType.Char);
            param[8].Size = 1;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[9].Size = 255;
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[10].Size = 20;
            param[10].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_UpdateEmployeePromotionMaster", param);

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

        public void UpdateEmployeePromotionDetails(EmployeePromotionDetails argEmployeePromotionDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@EmployeeId", argEmployeePromotionDetails.EmployeeId);
            param[1] = new SqlParameter("@Department", argEmployeePromotionDetails.NewDept);
            param[2] = new SqlParameter("@Designation", argEmployeePromotionDetails.NewDesig);

            param[3] = new SqlParameter("@ModifiedBy", argEmployeePromotionDetails.ModifiedBy);


            param[4] = new SqlParameter("@Type", SqlDbType.Char);
            param[4].Size = 1;
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[5].Size = 255;
            param[5].Direction = ParameterDirection.Output;

            param[6] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[6].Size = 20;
            param[6].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_UpdateEmployeePromotionDetails", param);

            string strMessage = Convert.ToString(param[5].Value);
            string strType = Convert.ToString(param[4].Value);
            string strRetValue = Convert.ToString(param[6].Value);

            objErrorHandlerClass.Type = strType;
            objErrorHandlerClass.MsgId = 0;
            objErrorHandlerClass.Message = strMessage.ToString();
            objErrorHandlerClass.RowNo = 0;
            objErrorHandlerClass.FieldName = "";
            objErrorHandlerClass.LogCode = "";
            objErrorHandlerClass.ReturnValue = strRetValue;
            lstErr.Add(objErrorHandlerClass);
            //return strRetValue;
        }

        public ICollection<ErrorHandlerClass> DeleteEmployeePromotionMaster(string argEmployeeId, int iIsDeleted)
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
                int i = da.ExecuteNonQuery("Proc_DeleteEmployeePromotionMaster", param);

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

        public bool blnIsEmployeePromotionMasterExist(string EmplyeeId)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetEmployeePromotionMaster4Check(EmplyeeId);
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
