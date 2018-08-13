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
//Date:           19-09-2013
#endregion Developnet Detatil

namespace HRMS_Class
{
    public class EmployeeMontlyAttendanceMasterManager
    {
        const string EmployeeMontlyAttendanceTable = "EmployeeMontlyAttendance";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public EmployeeMontlyAttendance objGetEmployeeMontlyAttendance(string EmployeeId)
        {
            EmployeeMontlyAttendance argEmployeeMontlyAttendance = new EmployeeMontlyAttendance();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetEmployeeMontlyAttendance4ID(EmployeeId.ToString().Trim());

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argEmployeeMontlyAttendance = this.objCreteEmployeeMontlyAttendance((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

        return argEmployeeMontlyAttendance;
        }

        private EmployeeMontlyAttendance objCreteEmployeeMontlyAttendance(DataRow dr)
        {
            EmployeeMontlyAttendance tEmployeeMontlyAttendance = new EmployeeMontlyAttendance();

            tEmployeeMontlyAttendance.SetObjectInfo(dr);

            return tEmployeeMontlyAttendance;

        }

        public DataSet GetEmployeeMontlyAttendance4Month(string Month,string Year)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Month",Month);
            param[1] = new SqlParameter("@Year",Year);
            DataSetToFill = da.FillDataSet("Proc_GetMonthlyAttendance4Month", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeMontlyAttendance()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetMonthlyEarningnDeduction", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeMontlyAttendance4ID(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetMonthlyEarningnDeduction4Id", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeMontlyAttendance4Check(string EmployeeId,string Month,string Year)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            param[1] = new SqlParameter("@Month", Month);
            param[2] = new SqlParameter("@Year", Year);
            DataSetToFill = da.FillDataSet("Proc_GetMonthlyAttendance4Check", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeMontlyEarning(string EmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeEarningDetails4Attendance", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeMontlyDeductions(string EmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeDeductionDetails4Attendance", param);
            return DataSetToFill;
        }

        public DataSet GetMontlyErrNDeductions(string EmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetMonthlyEarningNDeduction4Attendance", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeMontlyAttendance4Employee(string EmployeeId,string Month,string Year)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            param[1] = new SqlParameter("@Month", Month);
            param[2] = new SqlParameter("@Year", Year);
            DataSetToFill = da.FillDataSet("Proc_GetMonthlyAttendance4Employee", param);
            return DataSetToFill;
        }

        public ICollection<ErrorHandlerClass> SaveEmployeeMontlyAttendance(EmployeeMontlyAttendance objEmployeeMontlyAttendance, ICollection<EmployeeMontlyAttendance> colEmployeeMontlyAttendance)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (blnIsEmployeeMontlyAttendanceExist(objEmployeeMontlyAttendance.EmployeeId, objEmployeeMontlyAttendance.Month, objEmployeeMontlyAttendance.Year) == false)
                {
                   // objEmployeeMontlyAttendance.ErrorMsg = "0";
                    InsertEmployeeMontlyAttendance(objEmployeeMontlyAttendance, da, lstErr);
                    foreach (ErrorHandlerClass objerr in lstErr)
                    {
                        if (objerr.Type == "E")
                        {
                            da.ROLLBACK_TRANSACTION();
                            return lstErr;
                        }
                    }

                    if (colEmployeeMontlyAttendance.Count > 0)
                    {
                        foreach (EmployeeMontlyAttendance argEmployeeMontlyAttendance in colEmployeeMontlyAttendance)
                        {
                            InsertEmployeeErrnDeduction(argEmployeeMontlyAttendance, da, lstErr);
                        }
                    }

                    da.COMMIT_TRANSACTION();
                }
                else
                {
                   ErrorHandlerClass _objErrorHandlerClass=new ErrorHandlerClass();
                    _objErrorHandlerClass.Message = "This months's Salary has been already calculate!!";
                        
                    
                }
                //else
                //{
                //    UpdateEmployeeMontlyAttendance(objEmployeeMontlyAttendance, da, lstErr);
                //    UpdateEmployeeErrnDeduction(objEmployeeMontlyAttendance, da, lstErr);
                //    foreach (ErrorHandlerClass objerr in lstErr)
                //    {
                //        if (objerr.Type == "E")
                //        {
                //            da.ROLLBACK_TRANSACTION();
                //            return lstErr;
                //        }
                //    }
                //    da.COMMIT_TRANSACTION();
                //}
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

        public void InsertEmployeeMontlyAttendance(EmployeeMontlyAttendance argEmployeeMontlyAttendance, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[40];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeMontlyAttendance.EmployeeId);
            param[1] = new SqlParameter("@Month", argEmployeeMontlyAttendance.Month);
            param[2] = new SqlParameter("@Year", argEmployeeMontlyAttendance.Year);
            param[3] = new SqlParameter("@SalaryProcessDate", argEmployeeMontlyAttendance.SalaryProcessDate);
            param[4] = new SqlParameter("@TotalMonthDays", argEmployeeMontlyAttendance.TotalMontrhInDays);
            param[5] = new SqlParameter("@OverTime", argEmployeeMontlyAttendance.OverTime);
            param[6] = new SqlParameter("@Present", argEmployeeMontlyAttendance.Present);
            param[7] = new SqlParameter("@Absent", argEmployeeMontlyAttendance.Absent);
            param[8] = new SqlParameter("@Holidays", argEmployeeMontlyAttendance.Holidays);
            param[9] = new SqlParameter("@WeekOff", argEmployeeMontlyAttendance.WeekOff);
            param[10] = new SqlParameter("@RstHoliDays ", argEmployeeMontlyAttendance.RstHoliDays);
            param[11] = new SqlParameter("@Maternity", argEmployeeMontlyAttendance.Maternity);
            param[12] = new SqlParameter("@EL", argEmployeeMontlyAttendance.EL);
            param[13] = new SqlParameter("@CL", argEmployeeMontlyAttendance.CL);
            param[14] = new SqlParameter("@SL", argEmployeeMontlyAttendance.SL);
            param[15] = new SqlParameter("@L1", argEmployeeMontlyAttendance.L1);
            param[16] = new SqlParameter("@L2", argEmployeeMontlyAttendance.L2);
            param[17] = new SqlParameter("@L3", argEmployeeMontlyAttendance.L3);
            param[18] = new SqlParameter("@PaidDays", argEmployeeMontlyAttendance.PaidDays);
            param[19] = new SqlParameter("@DayWork", argEmployeeMontlyAttendance.DayWork);
            param[20] = new SqlParameter("@ESILeave", argEmployeeMontlyAttendance.ESILeave);
            param[21] = new SqlParameter("@ArrPaidDays", argEmployeeMontlyAttendance.ArrPaidDays);
            param[22] = new SqlParameter("@PFPaidDays", argEmployeeMontlyAttendance.PFPaidDays);
            param[23] = new SqlParameter("@ESIPaidDays", argEmployeeMontlyAttendance.ESIPaidDays);
            param[24] = new SqlParameter("@Remarks", argEmployeeMontlyAttendance.Remarks);

            param[25] = new SqlParameter("@CreatedBy", argEmployeeMontlyAttendance.CreatedBy);
            param[26] = new SqlParameter("@ModifiedBy", argEmployeeMontlyAttendance.ModifiedBy);

            param[27] = new SqlParameter("@Type", SqlDbType.Char);
            param[27].Size = 1;
            param[27].Direction = ParameterDirection.Output;

            param[28] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[28].Size = 255;
            param[28].Direction = ParameterDirection.Output;

            param[29] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[29].Size = 20;
            param[29].Direction = ParameterDirection.Output;

            param[30] = new SqlParameter("@IsSytemCalucalted", argEmployeeMontlyAttendance.IsSytemCalucalted);
            param[31] = new SqlParameter("@CEL", argEmployeeMontlyAttendance.CEL);
            param[32] = new SqlParameter("@NCEL", argEmployeeMontlyAttendance.NCEL);
            param[33] = new SqlParameter("@Paternity", argEmployeeMontlyAttendance.Paternity);
            param[34] = new SqlParameter("@HalfDay", argEmployeeMontlyAttendance.HalfDay);

            param[35] = new SqlParameter("@OverTimeAmount", argEmployeeMontlyAttendance.OverTimeAmount);
            param[36] = new SqlParameter("@CalcOverTimeAmount", argEmployeeMontlyAttendance.CalcOverTimeAmount);
            param[37] = new SqlParameter("@ActualEarnSalary", argEmployeeMontlyAttendance.ActualEarnSalary);
            param[38] = new SqlParameter("@SalaryCalculationDate", argEmployeeMontlyAttendance.SalaryCalculationDate);
            param[39] = new SqlParameter("@HPL", argEmployeeMontlyAttendance.HPL);

            int i = da.NExecuteNonQuery("Proc_InsertMonthlyAttendance", param);

            string strMessage = Convert.ToString(param[28].Value);
            string strType = Convert.ToString(param[27].Value);
            string strRetValue = Convert.ToString(param[29].Value);

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

        public void InsertEmployeeErrnDeduction(EmployeeMontlyAttendance argEmployeeMontlyAttendance, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeMontlyAttendance.EmployeeId);
            param[1] = new SqlParameter("@Allwances", argEmployeeMontlyAttendance.Allwances);
            param[2] = new SqlParameter("@AllowanesAmount", argEmployeeMontlyAttendance.AllowanesAmount);
            param[3] = new SqlParameter("@Deductions", argEmployeeMontlyAttendance.Deductions);
            param[4] = new SqlParameter("@DedPercentage", argEmployeeMontlyAttendance.DedPercentage);
            param[5] = new SqlParameter("@DedAmount", argEmployeeMontlyAttendance.DedAmount);

            param[6] = new SqlParameter("@CreatedBy", argEmployeeMontlyAttendance.CreatedBy);
            param[7] = new SqlParameter("@ModifiedBy", argEmployeeMontlyAttendance.ModifiedBy);
            param[8] = new SqlParameter("@ItemNo", argEmployeeMontlyAttendance.ItemNo);
            param[9] = new SqlParameter("@Month", argEmployeeMontlyAttendance.Month);
            param[10] = new SqlParameter("@Year", argEmployeeMontlyAttendance.Year);

            param[11] = new SqlParameter("@Type", SqlDbType.Char);
            param[11].Size = 1;
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[12].Size = 255;
            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[13].Size = 20;
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@IsSytemCalucalted", argEmployeeMontlyAttendance.IsSytemCalucalted);

            int i = da.NExecuteNonQuery("Proc_InsertMonthlyEarningnDeduction", param);

            string strMessage = Convert.ToString(param[12].Value);
            string strType = Convert.ToString(param[11].Value);
            string strRetValue = Convert.ToString(param[13].Value);

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

        public void UpdateEmployeeMontlyAttendance(EmployeeMontlyAttendance argEmployeeMontlyAttendance, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[29];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeMontlyAttendance.EmployeeId);
            param[1] = new SqlParameter("@Month", argEmployeeMontlyAttendance.Month);
            param[2] = new SqlParameter("@Year", argEmployeeMontlyAttendance.Year);
            param[3] = new SqlParameter("@SalaryProcessDate", argEmployeeMontlyAttendance.SalaryProcessDate);
            param[4] = new SqlParameter("@TotalMonthDays", argEmployeeMontlyAttendance.TotalMontrhInDays);
            param[5] = new SqlParameter("@OverTime", argEmployeeMontlyAttendance.OverTime);
            param[6] = new SqlParameter("@Present", argEmployeeMontlyAttendance.Present);
            param[7] = new SqlParameter("@Absent", argEmployeeMontlyAttendance.Absent);
            param[8] = new SqlParameter("@Holidays", argEmployeeMontlyAttendance.Holidays);
            param[9] = new SqlParameter("@WeekOff", argEmployeeMontlyAttendance.WeekOff);
            param[10] = new SqlParameter("@RstHoliDays ", argEmployeeMontlyAttendance.RstHoliDays);
            param[11] = new SqlParameter("@Maternity", argEmployeeMontlyAttendance.Maternity);
            param[12] = new SqlParameter("@EL", argEmployeeMontlyAttendance.EL);
            param[13] = new SqlParameter("@CL", argEmployeeMontlyAttendance.CL);
            param[14] = new SqlParameter("@SL", argEmployeeMontlyAttendance.SL);
            param[15] = new SqlParameter("@L1", argEmployeeMontlyAttendance.L1);
            param[16] = new SqlParameter("@L2", argEmployeeMontlyAttendance.L2);
            param[17] = new SqlParameter("@L3", argEmployeeMontlyAttendance.L3);
            param[18] = new SqlParameter("@PaidDays", argEmployeeMontlyAttendance.PaidDays);
            param[19] = new SqlParameter("@DayWork", argEmployeeMontlyAttendance.DayWork);
            param[20] = new SqlParameter("@ESILeave", argEmployeeMontlyAttendance.ESILeave);
            param[21] = new SqlParameter("@ArrPaidDays", argEmployeeMontlyAttendance.ArrPaidDays);
            param[22] = new SqlParameter("@PFPaidDays", argEmployeeMontlyAttendance.PFPaidDays);
            param[23] = new SqlParameter("@ESIPaidDays", argEmployeeMontlyAttendance.ESIPaidDays);
            param[24] = new SqlParameter("@Remarks", argEmployeeMontlyAttendance.Remarks);

            param[25] = new SqlParameter("@ModifiedBy", argEmployeeMontlyAttendance.ModifiedBy);

            param[26] = new SqlParameter("@Type", SqlDbType.Char);
            param[26].Size = 1;
            param[26].Direction = ParameterDirection.Output;

            param[27] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[27].Size = 255;
            param[27].Direction = ParameterDirection.Output;

            param[28] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[28].Size = 20;
            param[28].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_UpdateEmployeeAttendance", param);

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

        public void UpdateEmployeeErrnDeduction(EmployeeMontlyAttendance argEmployeeMontlyAttendance, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeMontlyAttendance.EmployeeId);
            param[1] = new SqlParameter("@Allwances", argEmployeeMontlyAttendance.Allwances);
            param[2] = new SqlParameter("@AllowanesAmount", argEmployeeMontlyAttendance.AllowanesAmount);
            param[3] = new SqlParameter("@Deductions", argEmployeeMontlyAttendance.Deductions);
            param[4] = new SqlParameter("@DedPercentage", argEmployeeMontlyAttendance.DedPercentage);
            param[5] = new SqlParameter("@DedAmount", argEmployeeMontlyAttendance.DedAmount);

            param[6] = new SqlParameter("@ModifiedBy", argEmployeeMontlyAttendance.ModifiedBy);
            param[7] = new SqlParameter("@Month", argEmployeeMontlyAttendance.Month);
            param[8] = new SqlParameter("@Year", argEmployeeMontlyAttendance.Year);

            param[9] = new SqlParameter("@Type", SqlDbType.Char);
            param[9].Size = 1;
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[10].Size = 255;
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[11].Size = 20;
            param[11].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_UpdateEmployeeDeductionDetails", param);

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

        public ICollection<ErrorHandlerClass> DeleteEmployeeMontlyAttendance(string argEmployeeId, int iIsDeleted)
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

        public bool blnIsEmployeeMontlyAttendanceExist(string EmplyeeId, string month,string Year)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetEmployeeMontlyAttendance4Check(EmplyeeId,month,Year);
            if (ds.Tables[0].Rows.Count > 0)
            {

               // EmployeeMontlyAttendance _objEmployeeMontlyAttendance = new EmployeeMontlyAttendance();
                //_objEmployeeMontlyAttendance.ErrorMsg = "This months's Salary has been already calculate!!";
                IsEmplyeeExist = true;
               
            }
            else
            {
                
               // EmployeeMontlyAttendance _objEmployeeMontlyAttendance = new EmployeeMontlyAttendance();  
               // _objEmployeeMontlyAttendance.ErrorMsg = "0";
                IsEmplyeeExist = false;
                
            }
            return IsEmplyeeExist;
        }

        //public DataSet GetMonthlyAttendanceCalender(string EmployeeId)
        //{
        //    DataAccess da = new DataAccess();
        //    DataSet DataSetToFill = new DataSet();

        //    SqlParameter[] param = new SqlParameter[1];
        //    param[0] = new SqlParameter("@EmployeeId", EmployeeId);
        //    DataSetToFill = da.FillDataSet("Proc_GetMonthlyAttendanceCalender", param);
        //    return DataSetToFill;
        //}

        public DataTable GetDateAndTime()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@uType", "GetDateandTIme");
            DataSetToFill = da.FillDataSet("Proc_Employee", param);
            return DataSetToFill.Tables[0];
        }

    }
}
