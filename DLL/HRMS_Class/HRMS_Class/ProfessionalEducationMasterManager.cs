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
//Developer Name: Harendra Kumar Maurya
//Date:           19-10-2013
#endregion Developnet Detatil
namespace HRMS_Class
{
   public class ProfessionalEducationMasterManager
    {

     

           const string EducationMasterTable = "EducationMaster";
           ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();
           public ICollection<ErrorHandlerClass> SaveRequitmentEducationMaster(ProfessionalEducationMaster argEducationMaster)
           {
               List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
               DataAccess da = new DataAccess();
               try
               {
                   da.Open_Connection();
                   da.BEGIN_TRANSACTION();

                   InsertEducationMasterManager(argEducationMaster, da, lstErr);

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

           public void InsertEducationMasterManager(ProfessionalEducationMaster argEducationMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
           {
               da.Open_Connection();

              

               SqlParameter[] param = new SqlParameter[9];
               param[0] = new SqlParameter("@Qualification", argEducationMaster.Qualification);
               param[1] = new SqlParameter("@Univercity", argEducationMaster.Univercity);
               param[2] = new SqlParameter("@PassingYear", argEducationMaster.PassingYear);
               param[3] = new SqlParameter("@Grade", argEducationMaster.Grade);
               param[4] = new SqlParameter("@RRId", argEducationMaster.RRId);
               param[5] = new SqlParameter("@eType", argEducationMaster.EType);



               param[6] = new SqlParameter("@Type", SqlDbType.Char);
               param[6].Size = 1;
               param[6].Direction = ParameterDirection.Output;

               param[7] = new SqlParameter("@Message", SqlDbType.VarChar);
               param[7].Size = 255;
               param[7].Direction = ParameterDirection.Output;

               param[8] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
               param[8].Size = 20;
               param[8].Direction = ParameterDirection.Output;


               int i = da.NExecuteNonQuery("Proc_InsertEducationMaster", param);


               string strMessage = Convert.ToString(param[7].Value);
               string strType = Convert.ToString(param[6].Value);
               string strRetValue = Convert.ToString(param[8].Value);

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

       }
    }

