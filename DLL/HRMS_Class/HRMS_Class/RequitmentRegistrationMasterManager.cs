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
//Developer Name: Harendra Kumar Maurya
//Date:           19-10-2013
#endregion Developnet Detatil
namespace HRMS_Class
{
public class RequitmentRegistrationMasterManager
    {
    const string RequitmentRegistrationMasterTable = "RequitmentRegistrationMaster";
        ErrorHandlerClass objErrorHandlerClass = new ErrorHandlerClass();
        EducationMasterManager ObjEducationMasterManager = new EducationMasterManager();
        ReferencesMasterManager ObjReferencesMasterManager = new ReferencesMasterManager();
        ProfessionalEducationMasterManager ObjProfessionalEducationMasterManager = new ProfessionalEducationMasterManager();
        ExperienceMasterManager ObjExperienceMasterManager = new ExperienceMasterManager();
        LanguageMasterManager ObjLanguageMasterManager = new LanguageMasterManager();

        public DataSet GetRequitmentRegistration4Admin()
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[0];

            DataSetToFill = da.FillDataSet("Proc_GetRequitmentRegistrationMaster4Admin", param);
            return DataSetToFill;
        }
        public DataSet GetRequitmentRegistration(long RRId)
        {
            DataAccess da = new DataAccess();
            DataSet DataSetToFill = new DataSet();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RRId", RRId);
            DataSetToFill = da.FillDataSet("Proc_GetRequitmentRegistrationMaster", param);
            return DataSetToFill;
        }
        public ICollection<ErrorHandlerClass> SaveRequitmentRegistrationMaster(RequitmentRegistrationMaster argRequitmentRegistrationMaster, ICollection<EducationMaster> ColEducationMaster, ICollection<ProfessionalEducationMaster> ColProfessionalEducationMaster, ICollection<ExperienceMaster> ColExperienceMaster, ICollection<ReferencesMaster> ColReferencesMaster, ICollection<LanguageMaster> ColLanguageMaster)
    {
        List<ErrorHandlerClass> lstErr = new List<ErrorHandlerClass>();
        DataAccess da = new DataAccess();
        try
        {
            da.Open_Connection();
            da.BEGIN_TRANSACTION();

       string strRetValue=InsertRequitmentRegistrationMaster(argRequitmentRegistrationMaster, da, lstErr);

            foreach (ErrorHandlerClass objerr in lstErr)
            {
                if (objerr.Type == "E")
                {
                    da.ROLLBACK_TRANSACTION();
                    return lstErr;
                }
            }
            if (strRetValue != "")
            {
                if (ColEducationMaster != null)
                {
                    if (ColEducationMaster.Count > 0)
                    {

                        foreach (EducationMaster ObjEducationMaster in ColEducationMaster)
                        {
                            ObjEducationMaster.RRId = Convert.ToInt64(strRetValue);
                            ObjEducationMasterManager.SaveRequitmentEducationMaster(ObjEducationMaster);
                        }
                    }
                }

                // insert ProfessionalEducationMaster
                if (ColProfessionalEducationMaster.Count > 0)
                {

                    foreach (ProfessionalEducationMaster ObjProfessionalEducationMaster in ColProfessionalEducationMaster)
                    {
                        ObjProfessionalEducationMaster.RRId = Convert.ToInt64(strRetValue);
                        ObjProfessionalEducationMasterManager.SaveRequitmentEducationMaster(ObjProfessionalEducationMaster);


                    }
                }
                    //insert ExperienceMaster
                    if (ColExperienceMaster.Count > 0)
                    {

                        foreach (ExperienceMaster objExperienceMaster in ColExperienceMaster)
                        {
                            objExperienceMaster.RRId = Convert.ToInt64(strRetValue);
                            ObjExperienceMasterManager.SaveExperienceMasterTable(objExperienceMaster);


                        }
                    }

                //insert references
                    if (ColReferencesMaster.Count > 0)
                    {

                        foreach (ReferencesMaster obReferencesMaster in ColReferencesMaster)
                        {
                            obReferencesMaster.RRId = Convert.ToInt64(strRetValue);
                            ObjReferencesMasterManager.SaveReferencesMaster(obReferencesMaster);


                        }
                    }
                    //insert references
                    if (ColLanguageMaster.Count > 0)
                    {

                        foreach (LanguageMaster objLanguageMaster in ColLanguageMaster)
                        {
                            objLanguageMaster.RRId = Convert.ToInt64(strRetValue);
                            ObjLanguageMasterManager.SaveLanguageMaster(objLanguageMaster);


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

       public string InsertRequitmentRegistrationMaster(RequitmentRegistrationMaster argRequitmentRegistrationMaster, DataAccess da, List<ErrorHandlerClass> lstErr)
    {
        da.Open_Connection();

        SqlParameter[] param = new SqlParameter[37];
        param[0] = new SqlParameter("@FName", argRequitmentRegistrationMaster.FName);
        param[1] = new SqlParameter("@MName", argRequitmentRegistrationMaster.MName);
        param[2] = new SqlParameter("@LName", argRequitmentRegistrationMaster.LName);
        param[3] = new SqlParameter("@Post", argRequitmentRegistrationMaster.Post);
        param[4] = new SqlParameter("@FatherFname", argRequitmentRegistrationMaster.FatherFname);
        param[5] = new SqlParameter("@FatherMName", argRequitmentRegistrationMaster.FatherMName);
        param[6] = new SqlParameter("@FatherLName", argRequitmentRegistrationMaster.FatherLName);
        param[7] = new SqlParameter("@Dob", argRequitmentRegistrationMaster.Dob);
        param[8] = new SqlParameter("@Category", argRequitmentRegistrationMaster.Category);
        param[9] = new SqlParameter("@CAddress", argRequitmentRegistrationMaster.CAddress);
        param[10] = new SqlParameter("@CCity", argRequitmentRegistrationMaster.CCity);
        param[11] = new SqlParameter("@CState", argRequitmentRegistrationMaster.CState);
        param[12] = new SqlParameter("@CPincode", argRequitmentRegistrationMaster.CPincode);
        param[13] = new SqlParameter("@PAddress", argRequitmentRegistrationMaster.PAddress);
        param[14] = new SqlParameter("@PCity", argRequitmentRegistrationMaster.PCity);
        param[15] = new SqlParameter("@PState", argRequitmentRegistrationMaster.PState);
        param[16] = new SqlParameter("@PPincode", argRequitmentRegistrationMaster.PPincode);
        param[17] = new SqlParameter("@Email", argRequitmentRegistrationMaster.Email);
        param[18] = new SqlParameter("@Mobile", argRequitmentRegistrationMaster.Mobile);
        param[19] = new SqlParameter("@TotalEperience", argRequitmentRegistrationMaster.TotalEperience);
        param[20] = new SqlParameter("@NameOfOrg", argRequitmentRegistrationMaster.NameOfOrg);
        param[21] = new SqlParameter("@NameOfPost", argRequitmentRegistrationMaster.NameOfPost);
        param[22] = new SqlParameter("@DateOfApplied", argRequitmentRegistrationMaster.DateOfApplied);
        param[23] = new SqlParameter("@OutCome", argRequitmentRegistrationMaster.OutCome);
        param[24] = new SqlParameter("@AboutCompany", argRequitmentRegistrationMaster.AboutCompany);
        param[25] = new SqlParameter("@Resume", argRequitmentRegistrationMaster.Resume);
        param[26] = new SqlParameter("@PhoneNo", argRequitmentRegistrationMaster.PhoneNo);
        param[27] = new SqlParameter("@CardNo", argRequitmentRegistrationMaster.CardNo);
        param[28] = new SqlParameter("@DateOfIssue", argRequitmentRegistrationMaster.DateOfIssue);
        param[29] = new SqlParameter("@IssueingAuthority", argRequitmentRegistrationMaster.IssueingAuthority);
        param[30] = new SqlParameter("@Photo", argRequitmentRegistrationMaster.Photo);
        param[31] = new SqlParameter("@Signature", argRequitmentRegistrationMaster.Signature);
        param[32] = new SqlParameter("@Certificate", argRequitmentRegistrationMaster.Certificate);
        param[33] = new SqlParameter("@AdvertisementId", argRequitmentRegistrationMaster.AdvertisementId);

        param[34] = new SqlParameter("@Type", SqlDbType.Char);
        param[34].Size = 1;
        param[34].Direction = ParameterDirection.Output;

        param[35] = new SqlParameter("@Message", SqlDbType.VarChar);
        param[35].Size = 255;
        param[35].Direction = ParameterDirection.Output;

        param[36] = new SqlParameter("@returnvalue", SqlDbType.VarChar);
        param[36].Size = 20;
        param[36].Direction = ParameterDirection.Output;


        int i = da.NExecuteNonQuery("Proc_InsertRequitmentRegistration", param);

        string strMessage = Convert.ToString(param[35].Value);
        string strType = Convert.ToString(param[34].Value);
        string strRetValue = Convert.ToString(param[36].Value);

        objErrorHandlerClass.Type = strType;
        objErrorHandlerClass.MsgId = 0;
        objErrorHandlerClass.Message = strMessage.ToString();
        objErrorHandlerClass.RowNo = 0;
        objErrorHandlerClass.FieldName = "";
        objErrorHandlerClass.LogCode = "";
        objErrorHandlerClass.ReturnValue = strRetValue;
        lstErr.Add(objErrorHandlerClass);
        //return i;
        return strRetValue;
    }
       public DataTable getQualificationDetail(Int32 PostId)
       {
           DataAccess da = new DataAccess();
           DataSet DataSetToFill = new DataSet();

           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("@PostId", PostId);
           param[1] = new SqlParameter("@uType", "getQualificationDetail");
           DataSetToFill = da.FillDataSet("Proc_Employee", param);
           return DataSetToFill.Tables[0];
       }
       public DataTable getProffestionalDetail(Int32 PostId)
       {
           DataAccess da = new DataAccess();
           DataSet DataSetToFill = new DataSet();

           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("@PostId", PostId);
           param[1] = new SqlParameter("@uType", "getProffestionalDetail");
           DataSetToFill = da.FillDataSet("Proc_Employee", param);
           return DataSetToFill.Tables[0];
       }
       public DataTable getWorkExperienceDetail(Int32 PostId)
       {
           DataAccess da = new DataAccess();
           DataSet DataSetToFill = new DataSet();

           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("@PostId", PostId);
           param[1] = new SqlParameter("@uType", "getWorkExperienceDetail");
           DataSetToFill = da.FillDataSet("Proc_Employee", param);
           return DataSetToFill.Tables[0];
       }

}
}
