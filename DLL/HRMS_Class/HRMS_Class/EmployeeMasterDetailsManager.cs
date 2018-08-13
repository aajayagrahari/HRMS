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

    public class EmployeeMasterDetailsManager
    {
        const string EmployeeMasterTable = "EmployeeMaster";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();
        EmployeeJobDetailsManager objEmployeeJobDetailsManager = new EmployeeJobDetailsManager();
        EmployeeQualificationDetailsManager objEmployeeQualificationDetailsManager = new EmployeeQualificationDetailsManager();
        EmployeeEarningDetailsManager objEmployeeEarningDetailsManager = new EmployeeEarningDetailsManager();
        EmployeeDeductionDetailsManager objEmployeeDeductionDetailsManager = new EmployeeDeductionDetailsManager();
        EmployeeLeaveDetailsManager objEmployeeLeaveDetailsManager = new EmployeeLeaveDetailsManager();
        EmployeeLeftDetailsManager objEmployeeLeftDetailsManager = new EmployeeLeftDetailsManager();
        EmployeeOtherDetailsManager objEmployeeOtherDetailsManager = new EmployeeOtherDetailsManager();

        public EmployeeMasterDetails objGetEmployeeMaster(string EmployeeId)
        {
            EmployeeMasterDetails argEmployeeMaster = new EmployeeMasterDetails();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetEmployeeMaster4ID(EmployeeId.ToString().Trim());

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argEmployeeMaster = this.objCreteEmployeeMaster((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

            return argEmployeeMaster;
        }

        private EmployeeMasterDetails objCreteEmployeeMaster(DataRow dr)
        {
            EmployeeMasterDetails tEmployeeMaster = new EmployeeMasterDetails();

            tEmployeeMaster.SetObjectInfo(dr);

            return tEmployeeMaster;

        }

        public DataSet GetEmployeeMaster()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeMaster", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeDetails()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeDetails", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeMaster4ID(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeMaster4ID", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeMaster4Check(string EmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeMaster4Check", param);
            return DataSetToFill;
        }

        //Save Function for Bulk Insert
        public void SaveEmployeeMaster(EmployeeMasterDetails objEmployeeMaster, ref DataAccess da, ref List<ErrorHandlerClass> lstErr)
        {
            try
            {
                if (blnIsEmployeeMasterExist(objEmployeeMaster.EmployeeId) == false)
                {
                    InsertEmployeeMaster(objEmployeeMaster, da, lstErr);
                }
                else
                {
                    UpdateEmployeeMaster(objEmployeeMaster, da, lstErr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICollection<ErrorHandlerClass> SaveEmployeeMaster(ICollection<EmployeeMasterDetails> colEmployeeMaster, ICollection<EmployeeJobDetails> colEmployeeJobDetails, ICollection<EmployeeQualificationDetails> colEmployeeQualificationDetails, ICollection<EmployeeEarningDetails> colEmployeeEarningDetails, ICollection<EmployeeDeductionDetails> colEmployeeDeductionDetails, ICollection<EmployeeLeaveDetails> colEmployeeLeaveDetails, ICollection<EmployeeLeftDetails> colEmployeeLeftDetails, ICollection<EmployeeOtherDetails> colEmployeeOtherDetails)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            string strretValue = "";
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (colEmployeeMaster.Count > 0)
                {
                    foreach (EmployeeMasterDetails argEmployeeMasterDetails in colEmployeeMaster)
                    {
                        if (blnIsEmployeeMasterExist(argEmployeeMasterDetails.EmployeeId) == false)
                        {
                            strretValue = InsertEmployeeMaster(argEmployeeMasterDetails, da, lstErr);
                        }
                        else
                        {
                            strretValue = UpdateEmployeeMaster(argEmployeeMasterDetails, da, lstErr);
                        }

                        if (strretValue != "")
                        {
                            if (colEmployeeJobDetails.Count > 0)
                            {
                                try
                                {
                                    foreach (EmployeeJobDetails argEmployeeJobDetails in colEmployeeJobDetails)
                                    {
                                        if (argEmployeeJobDetails != null)
                                        {
                                            if (argEmployeeJobDetails.EmployeeId == strretValue)
                                            {
                                                argEmployeeJobDetails.EmployeeId = Convert.ToString(strretValue);
                                                objEmployeeJobDetailsManager.SaveEmployeeJobDetails(argEmployeeJobDetails);
                                            }
                                        }
                                    }
                                }
                                catch (Exception err)
                                { 
                                    
                                }
                            }

                            if (colEmployeeQualificationDetails.Count > 0)
                            {
                                try
                                {
                                    int QualficationId = GetEmployeeQualificationId();

                                    foreach (EmployeeQualificationDetails argEmployeeQualificationDetails in colEmployeeQualificationDetails)
                                    {
                                        if (argEmployeeQualificationDetails != null)
                                        {
                                            if (argEmployeeQualificationDetails.EmployeeId == strretValue)
                                            {
                                                argEmployeeQualificationDetails.EmployeeId = Convert.ToString(strretValue);
                                                argEmployeeQualificationDetails.EmployeeQualificationId = QualficationId;
                                                objEmployeeQualificationDetailsManager.SaveEmployeeQualificationDetails(argEmployeeQualificationDetails);
                                            }
                                        }
                                    }
                                }
                                catch (Exception err)
                                { 
                                
                                }
                            }

                            if (colEmployeeEarningDetails.Count > 0)
                            {
                                try
                                {
                                    int EarningId = GetEmployeeEarningId();
                                    foreach (EmployeeEarningDetails argEmployeeEarningDetails in colEmployeeEarningDetails)
                                    {
                                        if (argEmployeeEarningDetails != null)
                                        {
                                            if (argEmployeeEarningDetails.EmployeeId == strretValue)
                                            {
                                                argEmployeeEarningDetails.EmployeeId = Convert.ToString(strretValue);
                                                argEmployeeEarningDetails.EmployeeEarningId = EarningId;
                                                objEmployeeEarningDetailsManager.SaveEmployeeEarningDetails(argEmployeeEarningDetails);
                                            }
                                        }
                                    }
                                }
                                catch (Exception err)
                                {

                                }
                            }

                            if (colEmployeeDeductionDetails.Count > 0)
                            {
                                try
                                {
                                    int DeductionId = GetEmployeeDeductionId();
                                    foreach (EmployeeDeductionDetails argEmployeeDeductionDetails in colEmployeeDeductionDetails)
                                    {
                                        if (argEmployeeDeductionDetails != null)
                                        {
                                            if (argEmployeeDeductionDetails.EmployeeId == strretValue)
                                            {
                                                argEmployeeDeductionDetails.EmployeeId = Convert.ToString(strretValue);
                                                argEmployeeDeductionDetails.EmployeeDeductionId = DeductionId;
                                                objEmployeeDeductionDetailsManager.SaveEmployeeDeductionDetails(argEmployeeDeductionDetails);
                                            }
                                        }
                                    }
                                }
                                catch (Exception err)
                                {

                                }
                            }

                            if (colEmployeeLeaveDetails.Count > 0)
                            {
                                try
                                {
                                    int LeaveId = GetEmployeeLeaveId();
                                    foreach (EmployeeLeaveDetails argEmployeeLeaveDetails in colEmployeeLeaveDetails)
                                    {
                                        if (argEmployeeLeaveDetails != null)
                                        {
                                            if (argEmployeeLeaveDetails.EmployeeId == strretValue)
                                            {
                                                argEmployeeLeaveDetails.EmployeeId = Convert.ToString(strretValue);
                                                argEmployeeLeaveDetails.EmployeeLeaveId = LeaveId;
                                                objEmployeeLeaveDetailsManager.SaveEmployeeLeaveDetails(argEmployeeLeaveDetails);
                                            }
                                        }
                                    }
                                }
                                catch (Exception err)
                                {

                                }
                            }

                            if (colEmployeeLeftDetails.Count > 0)
                            {
                                try
                                {
                                    foreach (EmployeeLeftDetails argEmployeeLeftDetails in colEmployeeLeftDetails)
                                    {
                                        if (argEmployeeLeftDetails != null)
                                        {
                                            if (argEmployeeLeftDetails.EmployeeId == strretValue)
                                            {
                                                argEmployeeLeftDetails.EmployeeId = Convert.ToString(strretValue);
                                                objEmployeeLeftDetailsManager.SaveEmployeeLeftDetails(argEmployeeLeftDetails);
                                            }
                                        }
                                    }
                                }
                                catch (Exception err)
                                {

                                }
                            }

                            if (colEmployeeOtherDetails.Count > 0)
                            {
                                try
                                {
                                    foreach (EmployeeOtherDetails argEmployeeOtherDetails in colEmployeeOtherDetails)
                                    {
                                        if (argEmployeeOtherDetails != null)
                                        {
                                            if (argEmployeeOtherDetails.EmployeeId == strretValue)
                                            {
                                                argEmployeeOtherDetails.EmployeeId = Convert.ToString(strretValue);
                                                objEmployeeOtherDetailsManager.SaveEmployeeOtherDetails(argEmployeeOtherDetails);
                                            }
                                        }
                                    }
                                }
                                catch (Exception err)
                                {

                                }
                            }
                        }
                    }
                }

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
        //Anuj

        public ICollection<ErrorHandlerClass> SaveEmployeeMaster(EmployeeMasterDetails objEmployeeMaster, EmployeeJobDetails objEmployeeJobDetails, ICollection<EmployeeQualificationDetails> colEmployeeQualificationDetails, ICollection<EmployeeEarningDetails> colEmployeeEarningDetails, ICollection<EmployeeDeductionDetails> colEmployeeDeductionDetails, ICollection<EmployeeLeaveDetails> colEmployeeLeaveDetails, EmployeeLeftDetails objEmployeeLeftDetails, EmployeeOtherDetails objEmployeeOtherDetails)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            string strretValue = "";
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (blnIsEmployeeMasterExist(objEmployeeMaster.EmployeeId) == false)
                {
                    strretValue = InsertEmployeeMaster(objEmployeeMaster, da, lstErr);
                }
                else
                {
                    strretValue = UpdateEmployeeMaster(objEmployeeMaster, da, lstErr);
                }

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
                    if (objEmployeeJobDetails != null)
                    {
                        objEmployeeJobDetails.EmployeeId = Convert.ToString(strretValue);
                        //objEmployeeJobDetails.EmployeeId = Convert.ToString(strretValue);
                        objEmployeeJobDetailsManager.SaveEmployeeJobDetails(objEmployeeJobDetails);
                    }

                    if (colEmployeeQualificationDetails.Count > 0)
                    {
                        foreach (EmployeeQualificationDetails argEmployeeQualificationDetails in colEmployeeQualificationDetails)
                        {
                            argEmployeeQualificationDetails.EmployeeId = Convert.ToString(strretValue);
                            objEmployeeQualificationDetailsManager.SaveEmployeeQualificationDetails(argEmployeeQualificationDetails);
                        }
                    }

                    if (colEmployeeEarningDetails.Count > 0)
                    {
                        foreach (EmployeeEarningDetails argEmployeeEarningDetails in colEmployeeEarningDetails)
                        {
                            argEmployeeEarningDetails.EmployeeId = Convert.ToString(strretValue);
                            objEmployeeEarningDetailsManager.SaveEmployeeEarningDetails(argEmployeeEarningDetails);
                        }
                    }

                    if (colEmployeeDeductionDetails.Count > 0)
                    {
                        foreach (EmployeeDeductionDetails argEmployeeDeductionDetails in colEmployeeDeductionDetails)
                        {
                            argEmployeeDeductionDetails.EmployeeId = Convert.ToString(strretValue);
                            objEmployeeDeductionDetailsManager.SaveEmployeeDeductionDetails(argEmployeeDeductionDetails);
                        }
                    }

                    if (colEmployeeLeaveDetails.Count > 0)
                    {
                        foreach (EmployeeLeaveDetails argEmployeeLeaveDetails in colEmployeeLeaveDetails)
                        {
                            argEmployeeLeaveDetails.EmployeeId = Convert.ToString(strretValue);
                            objEmployeeLeaveDetailsManager.SaveEmployeeLeaveDetails(argEmployeeLeaveDetails);
                        }
                    }

                    if (objEmployeeLeftDetails != null)
                    {
                        objEmployeeLeftDetails.EmployeeId = Convert.ToString(strretValue);
                        objEmployeeLeftDetailsManager.SaveEmployeeLeftDetails(objEmployeeLeftDetails);
                    }

                    if (objEmployeeOtherDetails != null)
                    {
                        objEmployeeOtherDetails.EmployeeId = Convert.ToString(strretValue);
                        objEmployeeOtherDetailsManager.SaveEmployeeOtherDetails(objEmployeeOtherDetails);
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

        public string InsertEmployeeMaster(EmployeeMasterDetails argEmployeeMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[55];
            param[0] = new SqlParameter("@FirstName", argEmployeeMaster.FirstName);
            param[1] = new SqlParameter("@MiddleName", argEmployeeMaster.MiddleName);
            param[2] = new SqlParameter("@LastName", argEmployeeMaster.LastName);
            param[3] = new SqlParameter("@FatherName", argEmployeeMaster.FatherName);
            param[4] = new SqlParameter("@Designation", argEmployeeMaster.Designation);
            param[5] = new SqlParameter("@Unit ", argEmployeeMaster.Unit);
            param[6] = new SqlParameter("@SubUnit", argEmployeeMaster.SubUnit);
            param[7] = new SqlParameter("@Department", argEmployeeMaster.Department);
            param[8] = new SqlParameter("@PFNo", argEmployeeMaster.PFNo);
            param[9] = new SqlParameter("@ESINo", argEmployeeMaster.ESINo);
            param[10] = new SqlParameter("@AliasName ", argEmployeeMaster.AliasName);
            param[11] = new SqlParameter("@NickName", argEmployeeMaster.NickName);
            param[12] = new SqlParameter("@LocalAddress", argEmployeeMaster.LocalAddress);
            param[13] = new SqlParameter("@City", argEmployeeMaster.City);
            param[14] = new SqlParameter("@ZipCode", argEmployeeMaster.ZipCode);
            param[15] = new SqlParameter("@Country", argEmployeeMaster.Country);
            param[16] = new SqlParameter("@State", argEmployeeMaster.State);
            param[17] = new SqlParameter("@ContactNo ", argEmployeeMaster.ContactNo);
            param[18] = new SqlParameter("@EmailId", argEmployeeMaster.EmailId);
            param[19] = new SqlParameter("@ParamAddress", argEmployeeMaster.ParamAddress);
            param[20] = new SqlParameter("@ParamCity", argEmployeeMaster.ParamCity);
            param[21] = new SqlParameter("@ParamZipCode", argEmployeeMaster.ParamZipCode);
            param[22] = new SqlParameter("@ParamCountry ", argEmployeeMaster.ParamCountry);
            param[23] = new SqlParameter("@ParamState", argEmployeeMaster.ParamState);
            param[24] = new SqlParameter("@PlaceOfBirth", argEmployeeMaster.PlaceOfBirth);
            param[25] = new SqlParameter("@RationCardNo", argEmployeeMaster.RationCardNo);
            param[26] = new SqlParameter("@VoterId", argEmployeeMaster.VoterId);
            param[27] = new SqlParameter("@PassportNo", argEmployeeMaster.PassportNo);
            param[28] = new SqlParameter("@DLNo", argEmployeeMaster.DLNo);
            param[29] = new SqlParameter("@ValidUpTo ", argEmployeeMaster.ValidUpTo);
            param[30] = new SqlParameter("@IdentityMarks", argEmployeeMaster.IdentityMarks);
            param[31] = new SqlParameter("@Religion", argEmployeeMaster.Religion);
            param[32] = new SqlParameter("@Nationality", argEmployeeMaster.Nationality);
            param[33] = new SqlParameter("@DateOfBirth", argEmployeeMaster.DateOfBirth);
            param[34] = new SqlParameter("@RetirementDate ", argEmployeeMaster.RetirementDate);
            param[35] = new SqlParameter("@Gender", argEmployeeMaster.Gender);
            param[36] = new SqlParameter("@Height", argEmployeeMaster.Height);
            param[37] = new SqlParameter("@Date", argEmployeeMaster.Date);
            param[38] = new SqlParameter("@BloodGroup", argEmployeeMaster.BloodGroup);
            param[39] = new SqlParameter("@MaritalStatus", argEmployeeMaster.MaritalStatus);

            param[40] = new SqlParameter("@CreatedBy", argEmployeeMaster.CreatedBy);
            param[41] = new SqlParameter("@ModifiedBy", argEmployeeMaster.ModifiedBy);
            param[42] = new SqlParameter("@EmployeeId", argEmployeeMaster.EmployeeId);
            param[43] = new SqlParameter("@PCardNo", argEmployeeMaster.PCardNo);
            param[44] = new SqlParameter("@EmployeePic", argEmployeeMaster.EmployeePic);
            param[45] = new SqlParameter("@BankName", argEmployeeMaster.BankName);
            param[46] = new SqlParameter("@AccountNo", argEmployeeMaster.AccountNo);
            param[47] = new SqlParameter("@AccountHolderName", argEmployeeMaster.AccountHolderName);
            param[48] = new SqlParameter("@Branch", argEmployeeMaster.Branch);
            param[49] = new SqlParameter("@PANNo", argEmployeeMaster.PANNo);
            param[50] = new SqlParameter("@EmployeeType", argEmployeeMaster.EmployeeType);

            param[51] = new SqlParameter("@Type", SqlDbType.Char);
            param[51].Size = 1;
            param[51].Direction = ParameterDirection.Output;

            param[52] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[52].Size = 255;
            param[52].Direction = ParameterDirection.Output;

            param[53] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[53].Size = 20;
            param[53].Direction = ParameterDirection.Output;
            param[54] = new SqlParameter("@CityType", argEmployeeMaster.CityType);
            int i = da.NExecuteNonQuery("Proc_InsertEmployeeMaster", param);

            string strMessage = Convert.ToString(param[52].Value);
            string strType = Convert.ToString(param[51].Value);
            string strRetValue = Convert.ToString(param[53].Value);

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

        public string UpdateEmployeeMaster(EmployeeMasterDetails argEmployeeMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[54];
            param[0] = new SqlParameter("@FirstName", argEmployeeMaster.FirstName);
            param[1] = new SqlParameter("@MiddleName", argEmployeeMaster.MiddleName);
            param[2] = new SqlParameter("@LastName", argEmployeeMaster.LastName);
            param[3] = new SqlParameter("@FatherName", argEmployeeMaster.FatherName);
            param[4] = new SqlParameter("@Designation", argEmployeeMaster.Designation);
            param[5] = new SqlParameter("@Unit ", argEmployeeMaster.Unit);
            param[6] = new SqlParameter("@SubUnit", argEmployeeMaster.SubUnit);
            param[7] = new SqlParameter("@Department", argEmployeeMaster.Department);
            param[8] = new SqlParameter("@PFNo", argEmployeeMaster.PFNo);
            param[9] = new SqlParameter("@ESINo", argEmployeeMaster.ESINo);
            param[10] = new SqlParameter("@AliasName ", argEmployeeMaster.AliasName);
            param[11] = new SqlParameter("@NickName", argEmployeeMaster.NickName);
            param[12] = new SqlParameter("@LocalAddress", argEmployeeMaster.LocalAddress);
            param[13] = new SqlParameter("@City", argEmployeeMaster.City);
            param[14] = new SqlParameter("@ZipCode", argEmployeeMaster.ZipCode);
            param[15] = new SqlParameter("@Country", argEmployeeMaster.Country);
            param[16] = new SqlParameter("@State", argEmployeeMaster.State);
            param[17] = new SqlParameter("@ContactNo ", argEmployeeMaster.ContactNo);
            param[18] = new SqlParameter("@EmailId", argEmployeeMaster.EmailId);
            param[19] = new SqlParameter("@ParamAddress", argEmployeeMaster.ParamAddress);
            param[20] = new SqlParameter("@ParamCity", argEmployeeMaster.ParamCity);
            param[21] = new SqlParameter("@ParamZipCode", argEmployeeMaster.ParamZipCode);
            param[22] = new SqlParameter("@ParamCountry ", argEmployeeMaster.ParamCountry);
            param[23] = new SqlParameter("@ParamState", argEmployeeMaster.ParamState);
            param[24] = new SqlParameter("@PlaceOfBirth", argEmployeeMaster.PlaceOfBirth);
            param[25] = new SqlParameter("@RationCardNo", argEmployeeMaster.RationCardNo);
            param[26] = new SqlParameter("@VoterId", argEmployeeMaster.VoterId);
            param[27] = new SqlParameter("@PassportNo", argEmployeeMaster.PassportNo);
            param[28] = new SqlParameter("@DLNo", argEmployeeMaster.DLNo);
            param[29] = new SqlParameter("@ValidUpTo ", argEmployeeMaster.ValidUpTo);
            param[30] = new SqlParameter("@IdentityMarks", argEmployeeMaster.IdentityMarks);
            param[31] = new SqlParameter("@Religion", argEmployeeMaster.Religion);
            param[32] = new SqlParameter("@Nationality", argEmployeeMaster.Nationality);
            param[33] = new SqlParameter("@DateOfBirth", argEmployeeMaster.DateOfBirth);
            param[34] = new SqlParameter("@RetirementDate ", argEmployeeMaster.RetirementDate);
            param[35] = new SqlParameter("@Gender", argEmployeeMaster.Gender);
            param[36] = new SqlParameter("@Height", argEmployeeMaster.Height);
            param[37] = new SqlParameter("@Date", argEmployeeMaster.Date);
            param[38] = new SqlParameter("@BloodGroup", argEmployeeMaster.BloodGroup);
            param[39] = new SqlParameter("@MaritalStatus", argEmployeeMaster.MaritalStatus);
            param[40] = new SqlParameter("@ModifiedBy", argEmployeeMaster.ModifiedBy);
            param[41] = new SqlParameter("@EmployeeId", argEmployeeMaster.EmployeeId);
            param[42] = new SqlParameter("@PCardNo", argEmployeeMaster.PCardNo);
            param[43] = new SqlParameter("@EmployeePic", argEmployeeMaster.EmployeePic);
            param[44] = new SqlParameter("@BankName", argEmployeeMaster.BankName);
            param[45] = new SqlParameter("@AccountNo", argEmployeeMaster.AccountNo);
            param[46] = new SqlParameter("@AccountHolderName", argEmployeeMaster.AccountHolderName);
            param[47] = new SqlParameter("@Branch", argEmployeeMaster.Branch);
            param[48] = new SqlParameter("@PANNo", argEmployeeMaster.PANNo);
            param[49] = new SqlParameter("@EmployeeType", argEmployeeMaster.EmployeeType);

            param[50] = new SqlParameter("@Type", SqlDbType.Char);
            param[50].Size = 1;
            param[50].Direction = ParameterDirection.Output;

            param[51] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[51].Size = 255;
            param[51].Direction = ParameterDirection.Output;

            param[52] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[52].Size = 20;
            param[52].Direction = ParameterDirection.Output;
            param[53] = new SqlParameter("@CityType", argEmployeeMaster.CityType);
            int i = da.NExecuteNonQuery("Proc_UpdateEmployeeMaster", param);

            string strMessage = Convert.ToString(param[51].Value);
            string strType = Convert.ToString(param[50].Value);
            string strRetValue = Convert.ToString(param[52].Value);

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

        public ICollection<ErrorHandlerClass> DeleteEmployeeMaster(string argEmployeeId, int iIsDeleted, string LoginId)
        {
            DataAccess da = new DataAccess();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            try
            {
                SqlParameter[] param = new SqlParameter[6];
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
                int i = da.ExecuteNonQuery("Proc_DeleteEmployeeMaster", param);

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

        public bool blnIsEmployeeMasterExist(string EmplyeeId)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetEmployeeMaster4Check(EmplyeeId);
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

        public DataSet GenerateEmployeeCode()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GenerateEmployeeCode", param);
            return DataSetToFill;
        }

        public DataSet GetClassName()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetClassName", param);
            return DataSetToFill;
        }

        public DataSet GetAllowances()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetAllowance", param);
            return DataSetToFill;
        }

        public DataSet GetDeductions()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetDeductions", param);
            return DataSetToFill;
        }

        public DataSet GetLeaveType()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetLeaveType", param);
            return DataSetToFill;
        }

        public DataSet GetTrainingDetail(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            param[1] = new SqlParameter("@uType", "TrainingDetail");
            DataSetToFill = da.FillDataSet("Proc_Employee", param);
            return DataSetToFill;
        }

        #region Generate Code
        public int GetEmployeeDeductionId()
        {
            int EmployeeDeductionId = 0;
            DataSet ds4EmployeeDeductionId = new DataSet();
            try
            {
                ds4EmployeeDeductionId = objEmployeeDeductionDetailsManager.GetMaxEmployeeDeductionId();
                if (ds4EmployeeDeductionId != null)
                {
                    EmployeeDeductionId = Convert.ToInt32(ds4EmployeeDeductionId.Tables[0].Rows[0]["EmployeeDeductionId"]) + 1;
                }

            }
            catch (Exception ex)
            {
                EmployeeDeductionId = EmployeeDeductionId + 1;
            }
            return EmployeeDeductionId;
        }

        public int GetEmployeeEarningId()
        {
            int EmployeeEarningId = 0;
            DataSet ds4EmployeeEarningId = new DataSet();
            try
            {
                ds4EmployeeEarningId = objEmployeeEarningDetailsManager.GetMaxEmployeeEarningId();
                if (ds4EmployeeEarningId != null)
                {
                    EmployeeEarningId = Convert.ToInt32(ds4EmployeeEarningId.Tables[0].Rows[0]["EmployeeEarningId"]) + 1;
                }

            }
            catch (Exception ex)
            {
                EmployeeEarningId = EmployeeEarningId + 1;
            }
            return EmployeeEarningId;
        }

        public int GetEmployeeLeaveId()
        {
            int EmployeeLeaveId = 0;
            DataSet ds4EmployeeLeaveId = new DataSet();
            try
            {
                ds4EmployeeLeaveId = objEmployeeLeaveDetailsManager.GetMaxEmployeeLeaveId();
                if (ds4EmployeeLeaveId != null)
                {
                    EmployeeLeaveId = Convert.ToInt32(ds4EmployeeLeaveId.Tables[0].Rows[0]["EmployeeLeaveId"]) + 1;
                }

            }
            catch (Exception ex)
            {
                EmployeeLeaveId = EmployeeLeaveId + 1;
            }
            return EmployeeLeaveId;
        }

        public int GetEmployeeQualificationId()
        {
            int EmployeeQualificationId = 0;
            DataSet ds4EmployeeQualificationId = new DataSet();
            try
            {
                ds4EmployeeQualificationId = objEmployeeQualificationDetailsManager.GetMaxEmployeeQualificationId();
                if (ds4EmployeeQualificationId != null)
                {
                    EmployeeQualificationId = Convert.ToInt32(ds4EmployeeQualificationId.Tables[0].Rows[0]["EmployeeQualificationId"]) + 1;
                }

            }
            catch (Exception ex)
            {
                EmployeeQualificationId = EmployeeQualificationId + 1;
            }
            return EmployeeQualificationId;
        }
        #endregion


    }

}
