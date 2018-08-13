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
//Date:           19-09-2013
#endregion Developnet Detatil

namespace HRMS_Class
{
    public class EmployeeAttendanceMasterManager
    {
        const string EmployeeAttendanceTable = "EmployeeAttendance";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();

        public DataSet GetEmployeeAttendance()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeAttendance", param);
            return DataSetToFill;
        }
        public DataSet GetEmployeeAttendanceById(Int64 AttendanceId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@AttendanceId", AttendanceId);
            DataSetToFill = da.FillDataSet("Proc_GetEmployeeAttendance4Id", param);
            return DataSetToFill;
        }
        //public DataSet GetEmployeeAttendanceByEmployeeId(Int64 EmployeeId)
        //{
        //    DataAccess da = new DataAccess();
        //    DataSet DataSetToFill = new DataSet();

        //    SqlParameter[] param = new SqlParameter[1];
        //    param[0] = new SqlParameter("@EmployeeId", EmployeeId);
        //    DataSetToFill = da.FillDataSet("Proc_GetEmployeeAttendance4EmployeeId", param);
        //    return DataSetToFill;
        //}


        public DataTable GetDateandTime()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@uType", "GetDateandTIme");
            DataSetToFill = da.FillDataSet("Proc_Employee", param);
            return DataSetToFill.Tables[0];
        }
        public bool IsMarkin(Int64 EmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@uType", "IsMarkin");
            param[1] = new SqlParameter("@EmployeeId", EmployeeId);
            DataSetToFill = da.FillDataSet("Proc_Employee", param);
            return Convert.ToBoolean(DataSetToFill.Tables[0].Rows[0][0]);
        }
        public bool IsAlertMsgShow(Int64 EmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@uType", "IsAlertMsgShow");
            param[1] = new SqlParameter("@EmployeeId", EmployeeId);
            DataSetToFill = da.FillDataSet("Proc_Employee", param);
            return Convert.ToBoolean(DataSetToFill.Tables[0].Rows[0][0]);
        }
        public bool IsAttendanceMarkIn(Int64 EmployeeId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@uType", "IsAttendanceMarkIn");
            param[1] = new SqlParameter("@EmployeeId", EmployeeId);
            DataSetToFill = da.FillDataSet("Proc_Employee", param);
            return Convert.ToBoolean(DataSetToFill.Tables[0].Rows[0][0]);
        }
        public ICollection<ErrorHandlerClass> UpdateEmployeeAttendance(EmployeeAttendanceMaster objEmployeeAttendanceMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                UpdateEmployeeAttendance(objEmployeeAttendanceMaster, da, lstErr);

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
        public string UpdateEmployeeAttendance(EmployeeAttendanceMaster argEmployeeAttendanceMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@AttendanceId", argEmployeeAttendanceMaster.AttendanceId);
            param[1] = new SqlParameter("@EmployeeId", argEmployeeAttendanceMaster.EmployeeId);
            param[2] = new SqlParameter("@MarkoutRemark", argEmployeeAttendanceMaster.MarkoutRemark);
            param[3] = new SqlParameter("@MarkoutDate", clsConvert.ToDateTime1(argEmployeeAttendanceMaster.MarkOutDate));
            param[4] = new SqlParameter("@MarkoutTime", argEmployeeAttendanceMaster.MarkOutTime);
            param[5] = new SqlParameter("@ModifiedBy", argEmployeeAttendanceMaster.ModifiedBy);
            param[6] = new SqlParameter("@MarkOutIPAddress", argEmployeeAttendanceMaster.MarkOutIPAddress);

            param[7] = new SqlParameter("@Type", SqlDbType.Char);
            param[7].Size = 1;
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[8].Size = 255;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[9].Size = 20;
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@MarkOutAlertMessasg", argEmployeeAttendanceMaster.MarkOutAlertMessasg);


            int i = da.NExecuteNonQuery("Proc_UpdateEmployeeAttendance", param);

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

            return strRetValue;
        }



        public ICollection<ErrorHandlerClass> SaveEmployeeAttendance(EmployeeAttendanceMaster objEmployeeAttendanceMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                InsertEmployeeAttendance(objEmployeeAttendanceMaster, da, lstErr);

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

        public ICollection<ErrorHandlerClass> UpdateEmployeeAttendancebyAttendanceId(EmployeeAttendanceMaster objEmployeeAttendanceMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                UpdateEmployeeAttendancebyAttendanceId(objEmployeeAttendanceMaster, da, lstErr);

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

        public ICollection<ErrorHandlerClass> DeleteEmployeeAttendance(EmployeeAttendanceMaster objEmployeeAttendanceMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                DeleteEmployeeAttendance(objEmployeeAttendanceMaster, da, lstErr);

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

        public void InsertEmployeeAttendance(EmployeeAttendanceMaster argEmployeeAttendanceMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();

            SqlParameter[] param = new SqlParameter[23];
            param[0] = new SqlParameter("@AttendanceId", argEmployeeAttendanceMaster.AttendanceId);
            param[1] = new SqlParameter("@EmployeeId", argEmployeeAttendanceMaster.EmployeeId);
            param[2] = new SqlParameter("@MarkInRemark", argEmployeeAttendanceMaster.MarkInRemark);
            param[3] = new SqlParameter("@MarkInDate",  clsConvert.ToDateTime1(argEmployeeAttendanceMaster.MarkInDate));
            param[4] = new SqlParameter("@MarkInTime", argEmployeeAttendanceMaster.MarkIntime);
            param[5] = new SqlParameter("@CreatedBy", argEmployeeAttendanceMaster.CreatedBy);
            param[6] = new SqlParameter("@MarkInIPAddress", argEmployeeAttendanceMaster.MarkInIPAddress);


            param[7] = new SqlParameter("@Type", SqlDbType.Char);
            param[7].Size = 1;
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[8].Size = 255;
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[9].Size = 20;
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@AlertMessasg", argEmployeeAttendanceMaster.AlertMessasg);

            param[11] = new SqlParameter("@MarkOutDate", clsConvert.ToDateTime1(argEmployeeAttendanceMaster.MarkOutDate));
            param[12] = new SqlParameter("@MarkOutTime", argEmployeeAttendanceMaster.MarkOutTime);
            param[13] = new SqlParameter("@IsSubmitted", argEmployeeAttendanceMaster.IsSubmitted);
            param[14] = new SqlParameter("@SubmittedBy", argEmployeeAttendanceMaster.SubmittedBy);
            param[15] = new SqlParameter("@SubmittedDate", argEmployeeAttendanceMaster.SubmittedDate);
            param[16] = new SqlParameter("@IsApprived", argEmployeeAttendanceMaster.IsApprived);
            param[17] = new SqlParameter("@ApprovedDate", argEmployeeAttendanceMaster.ApprovedDate);
            param[18] = new SqlParameter("@ApprovedBy", argEmployeeAttendanceMaster.ApprovedBy);
            param[19] = new SqlParameter("@ApprovalRemark", argEmployeeAttendanceMaster.ApprovalRemark);

            param[20] = new SqlParameter("@UpdatedMarkInTime", argEmployeeAttendanceMaster.UpdatedMarkInTime);
            param[21] = new SqlParameter("@UpdatedMarkOutTime", argEmployeeAttendanceMaster.UpdatedMarkOutTime);
            param[22] = new SqlParameter("@MarkOutAlertMessasg", argEmployeeAttendanceMaster.MarkOutAlertMessasg);
            

            int i = da.NExecuteNonQuery("Proc_InsertEmployeeAttendance", param);

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

        public string UpdateEmployeeAttendancebyAttendanceId(EmployeeAttendanceMaster argEmployeeAttendanceMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[17];
            param[0] = new SqlParameter("@AttendanceId", argEmployeeAttendanceMaster.AttendanceId);
            param[1] = new SqlParameter("@EmployeeId", argEmployeeAttendanceMaster.EmployeeId);
            param[2] = new SqlParameter("@MarkoutRemark", argEmployeeAttendanceMaster.MarkoutRemark);
            param[3] = new SqlParameter("@MarkoutDate", clsConvert.ToDateTime1(argEmployeeAttendanceMaster.MarkOutDate));
            param[4] = new SqlParameter("@MarkoutTime", argEmployeeAttendanceMaster.MarkOutTime);
            param[5] = new SqlParameter("@ModifiedBy", argEmployeeAttendanceMaster.ModifiedBy);
            param[6] = new SqlParameter("@MarkOutIPAddress", argEmployeeAttendanceMaster.MarkOutIPAddress);

            param[7] = new SqlParameter("@Type", SqlDbType.Char);
            param[7].Size = 1;
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[8].Size = 255;
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[9].Size = 20;
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@MarkOutAlertMessasg", argEmployeeAttendanceMaster.MarkOutAlertMessasg);
            param[11] = new SqlParameter("@AlertMessasg", argEmployeeAttendanceMaster.AlertMessasg);
            param[12] = new SqlParameter("@MarkIntime", argEmployeeAttendanceMaster.MarkIntime);
            param[13] = new SqlParameter("@IsApprived", argEmployeeAttendanceMaster.IsApprived);
            param[14] = new SqlParameter("@ApprovedBy", argEmployeeAttendanceMaster.ApprovedBy);
            param[15] = new SqlParameter("@ApprovedDate", argEmployeeAttendanceMaster.ApprovedDate);
            param[16] = new SqlParameter("@ApprovalRemark", argEmployeeAttendanceMaster.ApprovalRemark);




            int i = da.NExecuteNonQuery("Proc_UpdateEmployeeAttendanceByAttendanceId", param);
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

            return strRetValue;
        }

        public string DeleteEmployeeAttendance(EmployeeAttendanceMaster argEmployeeAttendanceMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
        {
            da.Open_Connection();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@AttendanceId", argEmployeeAttendanceMaster.AttendanceId);
            param[1] = new SqlParameter("@ModifiedBy", argEmployeeAttendanceMaster.ModifiedBy);
            param[2] = new SqlParameter("@Type", SqlDbType.Char);
            param[2].Size = 1;
            param[2].Direction = ParameterDirection.Output;

            param[3] = new SqlParameter("@Message", SqlDbType.VarChar);
            param[3].Size = 255;
            param[3].Direction = ParameterDirection.Output;

            param[4] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
            param[4].Size = 20;
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@IsDeleted", argEmployeeAttendanceMaster.IsDeleted);
            int i = da.NExecuteNonQuery("Proc_DeleteEmployeeAttendance", param);

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

        public ICollection<ErrorHandlerClass> SaveEmployeeAttendanceCollection(EmployeeAttendanceMaster objEmployeeAttendanceMaster, ICollection<EmployeeAttendanceMaster> colEmployeeAttendanceMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                //string strTrainingId = InsertEmployeeAttendance(objEmployeeAttendanceMaster, da, lstErr);

                foreach (ErrorHandlerClass objerr in lstErr)
                {
                    if (objerr.Type == "E")
                    {
                        da.ROLLBACK_TRANSACTION();
                        return lstErr;
                    }
                }
                //if (strTrainingId != "")
                //{
                if (colEmployeeAttendanceMaster.Count > 0)
                    {
                        foreach (EmployeeAttendanceMaster argEmployeeAttendanceMaster in colEmployeeAttendanceMaster)
                        {
                            //argEmployeeAttendanceMaster.TrainingId = Convert.ToInt32(strTrainingId);
                            SaveEmployeeAttendance(argEmployeeAttendanceMaster);
                        }
                    }
               // }

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
        public ICollection<ErrorHandlerClass> UpdateEmployeeAttendanceCollection(EmployeeAttendanceMaster objEmployeeAttendanceMaster, ICollection<EmployeeAttendanceMaster> colEmployeeAttendanceMaster)
        {
            List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
            DataAccess da = new DataAccess();
            try
            {
                da.Open_Connection();
                da.BEGIN_TRANSACTION();

                //string strTrainingId = InsertEmployeeAttendance(objEmployeeAttendanceMaster, da, lstErr);

                foreach (ErrorHandlerClass objerr in lstErr)
                {
                    if (objerr.Type == "E")
                    {
                        da.ROLLBACK_TRANSACTION();
                        return lstErr;
                    }
                }
               
                if (colEmployeeAttendanceMaster.Count > 0)
                {
                    foreach (EmployeeAttendanceMaster argEmployeeAttendanceMaster in colEmployeeAttendanceMaster)
                    {
                        //argEmployeeAttendanceMaster.TrainingId = Convert.ToInt32(strTrainingId);
                        UpdateEmployeeAttendancebyAttendanceId(argEmployeeAttendanceMaster);
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
        public DataSet getUpdatedAttendance(string EmployeeId,string Month,string year)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            param[1] = new SqlParameter("@Month", Month);
            param[2] = new SqlParameter("@Year", year);
            param[3] = new SqlParameter("@uType", "getUpdatedAttendance");
            DataSetToFill = da.FillDataSet("Proc_Admin", param);
            return DataSetToFill;
        }
    }
}
