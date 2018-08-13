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
    public class EmployeeAttendanceDetailsManager
    {
        const string EmployeeAttendanceDetailsTable = "EmployeeAttendanceDetails";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public EmployeeAttendanceDetails objGetEmployeeAttendanceDetails(string EmployeeId)
        {
            EmployeeAttendanceDetails argEmployeeAttendanceDetails = new EmployeeAttendanceDetails();
            DataSet DataSetToFill = new DataSet();

            if (EmployeeId.ToString().Trim() == "")
            {
                goto ErrorHandlers;
            }

            DataSetToFill = this.GetEmployeeAttendanceDetails4ID(EmployeeId.ToString().Trim());

            if (DataSetToFill.Tables[0].Rows.Count <= 0)
            {
                goto Finish;
            }

            argEmployeeAttendanceDetails = this.objCreteEmployeeAttendanceDetails((DataRow)DataSetToFill.Tables[0].Rows[0]);

            goto Finish;

        ErrorHandlers:

        Finish:
            DataSetToFill = null;

        return argEmployeeAttendanceDetails;
        }

        private EmployeeAttendanceDetails objCreteEmployeeAttendanceDetails(DataRow dr)
        {
            EmployeeAttendanceDetails tEmployeeAttendanceDetails = new EmployeeAttendanceDetails();

            tEmployeeAttendanceDetails.SetObjectInfo(dr);

            return tEmployeeAttendanceDetails;

        }

        public DataSet GetEmployeeAttendanceDetails()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeAttendanceDetails", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeAttendanceDetails4ID(string argEmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", argEmployeeId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeAttendanceDetails4ID", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeAttendanceDetails4Check(int EMPAttendanceId,int ItemNo,string EmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EMPAttendanceId", EMPAttendanceId);
            param[1] = new SqlParameter("@EmployeeId", EmployeeId);
            param[2] = new SqlParameter("@ItemNo", ItemNo);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeAttendanceDetails4Check", param);
            return DataSetToFill;
        }

        public DataSet GetEmployeeAttendanceDetails4Grid(int EMPAttendanceId, int ItemNo, string EmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EMPAttendanceId", EMPAttendanceId);
            param[1] = new SqlParameter("@EmployeeId", EmployeeId);
            param[2] = new SqlParameter("@ItemNo", ItemNo);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeAttendanceDetails4Grid", param);
            return DataSetToFill;
        }

        public ICollection<ErrorHandlerClass> SaveEmployeeAttendanceDetails(EmployeeAttendanceDetails objEmployeeAttendanceDetails)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                if (blnIsEmployeeAttendanceDetailsExist(objEmployeeAttendanceDetails.EMPAttendanceId, objEmployeeAttendanceDetails.ItemNo, objEmployeeAttendanceDetails.EmployeeId) == false)
                {
                    InsertEmployeeAttendanceDetails(objEmployeeAttendanceDetails, da, lstErr);

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
                    UpdateEmployeeAttendanceDetails(objEmployeeAttendanceDetails, da, lstErr);
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

        public void InsertEmployeeAttendanceDetails(EmployeeAttendanceDetails argEmployeeAttendanceDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@EMPAttendanceId", argEmployeeAttendanceDetails.EMPAttendanceId);
            param[1] = new SqlParameter("@EmployeeId", argEmployeeAttendanceDetails.EmployeeId);
            param[2] = new SqlParameter("@ItemNo", argEmployeeAttendanceDetails.ItemNo);
            param[3] = new SqlParameter("@AttendanceMonth", argEmployeeAttendanceDetails.AttendanceMonth);
            param[4] = new SqlParameter("@AttendanceYear", argEmployeeAttendanceDetails.AttendanceYear);
            param[5] = new SqlParameter("@TotalDaysInMonth", argEmployeeAttendanceDetails.TotalDaysInMonth);
            param[6] = new SqlParameter("@WeekOff", argEmployeeAttendanceDetails.WeekOff);
            param[7] = new SqlParameter("@Holidays", argEmployeeAttendanceDetails.Holidays);
            param[8] = new SqlParameter("@PresentDays", argEmployeeAttendanceDetails.PresentDays);
            param[9] = new SqlParameter("@AbsentDays", argEmployeeAttendanceDetails.AbsentDays);
            param[10] = new SqlParameter("@WorkingDays", argEmployeeAttendanceDetails.WorkingDays);
            param[11] = new SqlParameter("@PaidDays", argEmployeeAttendanceDetails.PaidDays);
            param[12] = new SqlParameter("@SalaryProcessDate", argEmployeeAttendanceDetails.SalaryProcessDate);
            param[13] = new SqlParameter("@Status", argEmployeeAttendanceDetails.Status);
            param[14] = new SqlParameter("@Remarks", argEmployeeAttendanceDetails.Remarks);

            param[15] = new SqlParameter("@CreatedBy", argEmployeeAttendanceDetails.CreatedBy);
            param[16] = new SqlParameter("@ModifiedBy", argEmployeeAttendanceDetails.ModifiedBy);
            

            param[17] = new SqlParameter("@Type", SqlDbType.Char);
            param[17].Size = 1;
            param[17].Direction = ParameterDirection.Output;

            param[18] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[18].Size = 255;
            param[18].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[19].Size = 20;
            param[19].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_InsertEmployeeAttendanceDetails", param);

            string strMessage = Convert.ToString(param[18].Value);
            string strType = Convert.ToString(param[17].Value);
            string strRetValue = Convert.ToString(param[19].Value);

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

        public void UpdateEmployeeAttendanceDetails(EmployeeAttendanceDetails argEmployeeAttendanceDetails, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[19];
            param[0] = new SqlParameter("@EMPAttendanceId", argEmployeeAttendanceDetails.EMPAttendanceId);
            param[1] = new SqlParameter("@EmployeeId", argEmployeeAttendanceDetails.EmployeeId);
            param[2] = new SqlParameter("@ItemNo", argEmployeeAttendanceDetails.ItemNo);
            param[3] = new SqlParameter("@AttendanceMonth", argEmployeeAttendanceDetails.AttendanceMonth);
            param[4] = new SqlParameter("@AttendanceYear", argEmployeeAttendanceDetails.AttendanceYear);
            param[5] = new SqlParameter("@TotalDaysInMonth", argEmployeeAttendanceDetails.TotalDaysInMonth);
            param[6] = new SqlParameter("@WeekOff", argEmployeeAttendanceDetails.WeekOff);
            param[7] = new SqlParameter("@Holidays", argEmployeeAttendanceDetails.Holidays);
            param[8] = new SqlParameter("@PresentDays", argEmployeeAttendanceDetails.PresentDays);
            param[9] = new SqlParameter("@AbsentDays", argEmployeeAttendanceDetails.AbsentDays);
            param[10] = new SqlParameter("@WorkingDays", argEmployeeAttendanceDetails.WorkingDays);
            param[11] = new SqlParameter("@PaidDays", argEmployeeAttendanceDetails.PaidDays);
            param[12] = new SqlParameter("@SalaryProcessDate", argEmployeeAttendanceDetails.SalaryProcessDate);
            param[13] = new SqlParameter("@Status", argEmployeeAttendanceDetails.Status);
            param[14] = new SqlParameter("@Remarks", argEmployeeAttendanceDetails.Remarks);

            param[15] = new SqlParameter("@ModifiedBy", argEmployeeAttendanceDetails.ModifiedBy);


            param[16] = new SqlParameter("@Type", SqlDbType.Char);
            param[16].Size = 1;
            param[16].Direction = ParameterDirection.Output;

            param[17] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[17].Size = 255;
            param[17].Direction = ParameterDirection.Output;

            param[18] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[18].Size = 20;
            param[18].Direction = ParameterDirection.Output;

            int i = da.NExecuteNonQuery("Proc_UpdateEmployeeLeaveDetails", param);

            string strMessage = Convert.ToString(param[17].Value);
            string strType = Convert.ToString(param[16].Value);
            string strRetValue = Convert.ToString(param[18].Value);

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

        public ICollection<ErrorHandlerClass> DeleteEmployeeAttendanceDetails(int argEmpAttendanceId, string argEmployeeId, int iIsDeleted)
        {
            DataAccess da = new DataAccess();
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();

            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@EMPAttendanceId", argEmpAttendanceId);
                param[1] = new SqlParameter("@EmployeeId", argEmployeeId);
                param[2] = new SqlParameter("@IsDeleted", iIsDeleted);

                param[3] = new SqlParameter("@Type", SqlDbType.Char);
                param[3].Size = 1;
                param[3].Direction = ParameterDirection.Output;

                param[4] = new SqlParameter("@Message", SqlDbType.VarChar);
                param[4].Size = 255;
                param[4].Direction = ParameterDirection.Output;

                param[5] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
                param[5].Size = 20;
                param[5].Direction = ParameterDirection.Output;
               
                int i = da.ExecuteNonQuery("Proc_DeleteEmployeeAttendanceDetails", param);

                string strMessage = Convert.ToString(param[4].Value);
                string strType = Convert.ToString(param[3].Value);
                string strRetValue = Convert.ToString(param[5].Value);

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

        public bool blnIsEmployeeAttendanceDetailsExist(int EMPAttendanecId,int ItemNo,string EmplyeeId)
        {
            bool IsEmplyeeExist = false;
            DataSet ds = new DataSet();
            ds = GetEmployeeAttendanceDetails4Check(EMPAttendanecId, ItemNo, EmplyeeId);
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
