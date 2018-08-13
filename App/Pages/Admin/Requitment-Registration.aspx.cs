using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HRMS_Class;
using ErrorHandler;
using System.IO;
#region Development Details
// Harendra kumar maurya(14-10-2013)
#endregion Development Details
public partial class Pages_Admin_Requitment_Registration : System.Web.UI.Page
{
    RequitmentRegistrationMasterManager objRequitmentRegistrationMasterManager = new RequitmentRegistrationMasterManager();
    RequitmentRegistrationMaster ObjRequitmentRegistrationMaster = new RequitmentRegistrationMaster();
    ReferencesMaster ObjReferencesMaster = new ReferencesMaster();
    ReferencesMasterManager ObjReferencesMasterManage = new ReferencesMasterManager();
    LanguageMasterManager ObjLanguageMasterManager = new LanguageMasterManager();
    LanguageMaster ObjLanguageMaster = new LanguageMaster();
    EducationMasterManager ObjEducationMasterManager = new EducationMasterManager();
    EducationMaster ObjEducationMaster = new EducationMaster();
    ExperienceMasterManager ObjExperienceMasterManager = new ExperienceMasterManager();
    ExperienceMaster ObjExperienceMaster = new ExperienceMaster();
    ProfessionalEducationMaster ObjProfessionalEducationMaster = new ProfessionalEducationMaster();
    ProfessionalEducationMasterManager ObjProfessionalEducationMasterManager = new ProfessionalEducationMasterManager();
    PostMasterManager ObjPostMasterManager = new PostMasterManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClearAll();
            ClearField();
            PostMaster();
            Session["Education"]= null;
            Session["ProEducation"] = null;
            Session["Experience"] = null;
            Session["References"] = null;
            Session["Languages"] = null;
        }
    }
    void ClearAll()
    {
        
        txt_f_fname.Text = "";
        txt_f_lname.Text = "";
        txt_f_mname.Text = "";
        txt_fname.Text = "";
        txt_lname.Text = "";
        txt_mname.Text = "";
        txt_job_brief.Text = "";
        txt_language.Text = "";
        txt_mobile.Text = "";
        txt_name.Text = "";
        txt_org_post.Text = "";
        txt_organization.Text = "";
        txt_outcome.Text = "";
        txt_p_address.Text = "";
        txt_p_city.Text = "";
        txt_p_pincode.Text = "";
        txt_p_state.Text = "";
        txt_phone.Text = "";
        ddl_org.SelectedIndex = 0;
       
        ddl_post.SelectedIndex = -1;
        txt_total_Experience.Text = "";
        gv_education.DataSource = null;
        gv_education.DataBind();
        BindEducation();
        gv_Language.DataSource = null;
        gv_Language.DataBind();
        BindLanguage();
        gv_pro_education.DataSource = null;
        gv_pro_education.DataBind();
        BindProfessionalEducation();
        gv_references.DataSource = null;
        gv_references.DataBind();
        BindReferences();
        gv_work_experience.DataSource = null;
        gv_work_experience.DataBind();
        BindWorkExperience();
        chk_about_company.DataSource=null;
        rdo_categry.DataSource=null;

    
    }
    void PostMaster()
    {
        DataSet ds = new DataSet();
        ds = ObjPostMasterManager.GetPostMaster();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_post.DataSource = ds.Tables[0];
            ddl_post.DataTextField = "PostName";
            ddl_post.DataValueField = "PostId";
            ddl_post.DataBind();
            ddl_post.Items.Insert(0,"-- Select Post --");
            lbl_posting_Date.Value = ds.Tables[0].Rows[0]["OpeningDate"].ToString();
        }
        else
        {

            ddl_post.DataSource = null;
            ddl_post.DataBind();  
        }
    
    }
    public DataTable CreateEducation()
    {
        try
        {
            DataTable dtItems = new DataTable();

            if (Session["Education"] == null)
            {

                dtItems.Columns.Add("Qualification", typeof(string));

                dtItems.Columns.Add("University", typeof(string));

                dtItems.Columns.Add("PassingYear", typeof(string));

                dtItems.Columns.Add("Grade", typeof(string));
 
            }
            else
            {
                dtItems = (DataTable)Session["Education"];
            }

            DataRow dr = dtItems.NewRow();
            dr["Qualification"] = txt_qualification.Text.Trim();

            dr["University"] = txt_school.Text.Trim();
            dr["PassingYear"] = txt_passed_year.Text.Trim();
            dr["Grade"] = txt_division.Text.Trim();
           
            dtItems.Rows.Add(dr);
            return dtItems;

        }
        catch (Exception ex)
        {
           // lbl_msg.Text = "" + ex.Message.ToString();
           // objErrorLog.WriteErrorLog(ex.ToString());
            return null;
        }
    }
    public DataTable CreateProEducation()
    {
        try
        {
            DataTable dtItems = new DataTable();

            if (Session["ProEducation"] == null)
            {

                dtItems.Columns.Add("Qualification", typeof(string));

                dtItems.Columns.Add("University", typeof(string));

                dtItems.Columns.Add("PassingYear", typeof(string));

                dtItems.Columns.Add("Grade", typeof(string));

            }
            else
            {
                dtItems = (DataTable)Session["ProEducation"];
            }

            DataRow dr = dtItems.NewRow();
            dr["Qualification"] = txt_pro_qualication.Text.Trim();

            dr["University"] = txt_pro_school.Text.Trim();
            dr["PassingYear"] = txt_pro_passed_year.Text.Trim();
            dr["Grade"] = txt_pro_division.Text.Trim();

            dtItems.Rows.Add(dr);
            return dtItems;

        }
        catch (Exception ex)
        {
            // lbl_msg.Text = "" + ex.Message.ToString();
            // objErrorLog.WriteErrorLog(ex.ToString());
            return null;
        }
    }
    public DataTable CreateWorkExperience()
    {
        try
        {
            DataTable dtItems = new DataTable();

            if (Session["Experience"] == null)
            {

                dtItems.Columns.Add("Organization", typeof(string));

                dtItems.Columns.Add("Designation", typeof(string));

                dtItems.Columns.Add("Duration", typeof(string));

                dtItems.Columns.Add("Salary", typeof(string));
                dtItems.Columns.Add("Jobprofile", typeof(string));
            }
            else
            {
                dtItems = (DataTable)Session["Experience"];
            }

            DataRow dr = dtItems.NewRow();
            dr["Organization"] = txt_organization.Text.Trim();

            dr["Designation"] = txt_designation.Text.Trim();
            dr["Duration"] = txt_duration.Text.Trim();
            dr["Salary"] = txt_salary.Text.Trim();
            dr["Jobprofile"] = txt_job_brief.Text.Trim();
            dtItems.Rows.Add(dr);
            return dtItems;

        }
        catch (Exception ex)
        {
            // lbl_msg.Text = "" + ex.Message.ToString();
            // objErrorLog.WriteErrorLog(ex.ToString());
            return null;
        }
    }
    public DataTable CreateReferences()
    {
        try
        {
            DataTable dtItems = new DataTable();

            if (Session["References"] == null)
            {

                dtItems.Columns.Add("Name", typeof(string));

                dtItems.Columns.Add("Address", typeof(string));

                dtItems.Columns.Add("Contact", typeof(string));
            }
            else
            {
                dtItems = (DataTable)Session["References"];
            }

            DataRow dr = dtItems.NewRow();
            dr["Name"] = txt_name.Text.Trim();
            dr["Address"] = txt_address.Text.Trim();
            dr["Contact"] = txt_contact.Text.Trim();
         
            dtItems.Rows.Add(dr);
            return dtItems;

        }
        catch (Exception ex)
        {
            // lbl_msg.Text = "" + ex.Message.ToString();
            // objErrorLog.WriteErrorLog(ex.ToString());
            return null;
        }
    }
    public DataTable CreateLanguages()
    {
        try
        {
            DataTable dtItems = new DataTable();

            if (Session["Languages"] == null)
            {

                dtItems.Columns.Add("Language", typeof(string));

                dtItems.Columns.Add("Read", typeof(string));

                dtItems.Columns.Add("Speak", typeof(string));
                dtItems.Columns.Add("Write", typeof(string));
            }
            else
            {
                dtItems = (DataTable)Session["Languages"];
            }

            DataRow dr = dtItems.NewRow();
            dr["Language"] = txt_language.Text.Trim();
            if (chk_read.Checked == true)
            {
                dr["Read"] = "Read";
            }
            if (chk_speak.Checked == true)
            {
                dr["Speak"] = "Speak";
            }
            if (chk_write.Checked == true)
            {
                dr["Write"] = "Write";
            }
          
         

            dtItems.Rows.Add(dr);
            return dtItems;

        }
        catch (Exception ex)
        {
            // lbl_msg.Text = "" + ex.Message.ToString();
            // objErrorLog.WriteErrorLog(ex.ToString());
            return null;
        }
    }
    protected DataTable CheckDublicateItems(DataTable dt)
    {
        try
        {
            DataTable dt2 = new DataTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                var UniqueRows = dt.AsEnumerable().Distinct(DataRowComparer.Default);

                dt2 = UniqueRows.CopyToDataTable();
            }

            return dt2;
        }
        catch (Exception ex)
        {
            //lbl_msg.Text = "" + ex.Message.ToString();
            //objErrorLog.WriteErrorLog(ex.ToString());
            return null;
        }
    }
    void BindEducation()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["Education"];
            dt = CheckDublicateItems(dt);
            if (dt.Rows.Count > 0)
            {

                gv_education.DataSource = dt;
                gv_education.DataBind();
                ClearField();
               
                
            }
            else
            {
                gv_education.DataSource = null;
                gv_education.DataBind();
              
            }

        }
        catch (Exception ex)
        {
            //lbl_msg.Text = "" + ex.Message.ToString();
            //objErrorLog.WriteErrorLog(ex.ToString());

        }


    }
    void BindProfessionalEducation()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["ProEducation"];
            dt = CheckDublicateItems(dt);
            if (dt.Rows.Count > 0)
            {

                gv_pro_education.DataSource = dt;
                gv_pro_education.DataBind();
                ClearProfessionalField();


            }
            else
            {
                gv_pro_education.DataSource = null;
                gv_pro_education.DataBind();

            }

        }
        catch (Exception ex)
        {
            //lbl_msg.Text = "" + ex.Message.ToString();
            //objErrorLog.WriteErrorLog(ex.ToString());

        }


    }
    void BindWorkExperience()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["Experience"];
            dt = CheckDublicateItems(dt);
            if (dt.Rows.Count > 0)
            {

                gv_work_experience.DataSource = dt;
                gv_work_experience.DataBind();
                ClearWorkExperienceField();


            }
            else
            {
                gv_work_experience.DataSource = null;
                gv_work_experience.DataBind();

            }

        }
        catch (Exception ex)
        {
            //lbl_msg.Text = "" + ex.Message.ToString();
            //objErrorLog.WriteErrorLog(ex.ToString());

        }


    }
    void BindReferences()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["References"];
            dt = CheckDublicateItems(dt);
            if (dt.Rows.Count > 0)
            {

                gv_references.DataSource = dt;
                gv_references.DataBind();
                ClearReferencesField();


            }
            else
            {
                gv_references.DataSource = null;
                gv_references.DataBind();

            }

        }
        catch (Exception ex)
        {
            //lbl_msg.Text = "" + ex.Message.ToString();
            //objErrorLog.WriteErrorLog(ex.ToString());

        }


    }
    void BindLanguage()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["Languages"];
            dt = CheckDublicateItems(dt);
            if (dt.Rows.Count > 0)
            {

                gv_Language.DataSource = dt;
                gv_Language.DataBind();
                ClearLanguageField();


            }
            else
            {
                gv_Language.DataSource = null;
                gv_Language.DataBind();

            }

        }
        catch (Exception ex)
        {
            //lbl_msg.Text = "" + ex.Message.ToString();
            //objErrorLog.WriteErrorLog(ex.ToString());

        }


    }
    void ClearField()
    {
        txt_division.Text = "";
        txt_qualification.Text = "";
        txt_school.Text = "";
        txt_passed_year.Text = "";
    
    }
    void ClearProfessionalField()
    {
        txt_pro_division.Text = "";
        txt_pro_qualication.Text = "";
        txt_pro_school.Text = "";
        txt_pro_passed_year.Text = "";

    }
    void ClearWorkExperienceField()
    {
        txt_organization.Text = "";
        txt_designation.Text = "";
        txt_duration.Text = "";
        txt_salary.Text = "";
        txt_job_brief.Text = "";
    }
    void ClearReferencesField()
    {
        txt_contact.Text = "";
        txt_address.Text = "";
        txt_name.Text = "";
      
    }
    void ClearLanguageField()
    {
        txt_language.Text = "";
        chk_read.Checked = false;
        chk_speak.Checked = false;
        chk_write.Checked = false;

    }
    protected void btn_add_Click(object sender, EventArgs e)
    {

        if (txt_qualification.Text == "")
        {
            lbl_msg.Text = "Please Enter Qualification !.";
            txt_qualification.Focus();
            return;
        }
        if (txt_school.Text == "")
        {
            lbl_msg.Text = "Please Enter School/University !.";
            txt_school.Focus();
            return;
        }

        if (txt_passed_year.Text == "")
        {
            lbl_msg.Text = "Please Enter Passing Year !.";
            txt_passed_year.Focus();
            return;
        }
        if (txt_division.Text == "")
        {
            lbl_msg.Text = "Please Enter Division !.";
            txt_division.Focus();
            return;
        }
        Session["Education"] = CreateEducation();

        BindEducation();
    }
    protected void gv_education_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gv_education_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            DataTable dt = new DataTable();
            dt = (DataTable)Session["Education"];

            dt.Rows.RemoveAt(index);
            BindEducation();
           
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txt_organization.Text == "")
        {
            lbl_msg.Text = "Please Enter  Organization !.";
            txt_organization.Focus();
            return;
        }
        if (txt_designation.Text == "")
        {
            lbl_msg.Text = "Please Enter Designation !.";
            txt_designation.Focus();
            return;
        }
        if (txt_duration.Text == "")
        {
            lbl_msg.Text = "Please Enter Duration !.";
            txt_duration.Focus();
            return;
        }
        if (txt_salary.Text == "")
        {
            lbl_msg.Text = "Please Enter Salary !.";
            txt_salary.Focus();
            return;
        }

        if (txt_job_brief.Text == "")
        {
            lbl_msg.Text = "Please Enter Brief Job profile !.";
            txt_job_brief.Focus();
            return;
        }
        Session["Experience"] = CreateWorkExperience();

        BindWorkExperience();
    }
    protected void btn_pro_add_Click(object sender, EventArgs e)
    {
        if (txt_pro_qualication.Text == "")
        {
            lbl_msg.Text = "Please Enter Professional Qualification !.";
            txt_pro_qualication.Focus();
            return;
        }
        if (txt_pro_school.Text == "")
        {
            lbl_msg.Text = "Please Enter Professional School/University !.";
            txt_pro_school.Focus();
            return;
        }
        if (txt_pro_passed_year.Text == "")
        {
            lbl_msg.Text = "Please Enter Professional Passing Year !.";
            txt_pro_passed_year.Focus();
            return;
        }
        if (txt_pro_division.Text == "")
        {
            lbl_msg.Text = "Please Enter Professional Division !.";
            txt_pro_division.Focus();
            return;
        }
        Session["ProEducation"] = CreateProEducation();

        BindProfessionalEducation();
    }
    protected void gv_pro_education_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            DataTable dt = new DataTable();
            dt = (DataTable)Session["ProEducation"];

            dt.Rows.RemoveAt(index);
            BindProfessionalEducation();

        }
    }
    protected void gv_pro_education_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gv_work_experience_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gv_work_experience_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            DataTable dt = new DataTable();
            dt = (DataTable)Session["Experience"];

            dt.Rows.RemoveAt(index);
            BindWorkExperience();

        }
    }
    protected void btn_References_Click(object sender, EventArgs e)
    {
        if (txt_name.Text == "")
        {
            lbl_msg.Text = "Please Enter References Name !.";
            txt_name.Focus();
            return;
        }
        if (txt_address.Text == "")
        {
            lbl_msg.Text = "Please Enter References Address !.";
            txt_address.Focus();
            return;
        }
        if (txt_contact.Text == "")
        {
            lbl_msg.Text = "Please Enter References Contact No. !.";
            txt_contact.Focus();
            return;
        }

        Session["References"] = CreateReferences();

        BindReferences();
    }
    protected void gv_references_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gv_references_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            DataTable dt = new DataTable();
            dt = (DataTable)Session["References"];

            dt.Rows.RemoveAt(index);
            BindReferences();

        }
    }
    protected void btn_language_Click(object sender, EventArgs e)
    {
        if (txt_language.Text == "")
        {
            lbl_msg.Text = "Please Enter Language !.";
            txt_language.Focus();
            return;
        }
        if (chk_read.Checked==false && chk_speak.Checked==false && chk_write.Checked==false)
        {
            lbl_msg.Text = "Please Tick Language Read/Speak/Write !.";
            chk_read.Focus();
            return;
        }
      

        Session["Languages"] = CreateLanguages();

        BindLanguage();
    }
    protected void gv_Language_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gv_Language_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            int index = Convert.ToInt32(e.CommandArgument);

            DataTable dt = new DataTable();
            dt = (DataTable)Session["Languages"];

            dt.Rows.RemoveAt(index);
            BindLanguage();

        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (ddl_post.SelectedIndex== 0)
        {
            lbl_msg.Text =" Please Enter Position !.";
            ddl_post.Focus();
            return;   
        }
        if (txt_fname.Text == "")
        {
            lbl_msg.Text =" Please Enter Name !.";
            txt_fname.Focus();
            return;   
        }
       
        if (txt_lname.Text == "")
        {
            lbl_msg.Text =" Please Enter Last Name !.";
            txt_lname.Focus();
            return;   
        }
        if (txt_f_fname.Text == "")
        {
            lbl_msg.Text =" Please Enter Father First Name !.";
            txt_f_fname.Focus();
            return;   
        }
        if (txt_f_lname.Text == "")
        {
            lbl_msg.Text = " Please Enter Father Last Name !.";
            txt_f_lname.Focus();
            return;
        }
        if (txt_dob.Text == "")
        {
            lbl_msg.Text = " Please Enter Date Of Birth !.";
            txt_dob.Focus();
            return;
        }
        if (rdo_categry.SelectedIndex==-1)
        {
            lbl_msg.Text = " Please Enter Cast Category !.";
            txt_dob.Focus();
            return;
        }
        if (txt_dob.Text == "")
        {
            lbl_msg.Text = " Please Enter Date Of Birth !.";
            txt_dob.Focus();
            return;
        }
        if (txt_c_address.Text == "")
        {
            lbl_msg.Text = " Please Enter Communication Address !.";
            txt_c_address.Focus();
            return;
        }
        if (txt_C_city.Text == "")
        {
            lbl_msg.Text = " Please Enter Communication City !.";
            txt_C_city.Focus();
            return;
        }
        if (txt_c_state.Text == "")
        {
            lbl_msg.Text = " Please Enter Communication State !.";
            txt_c_state.Focus();
            return;
        }
        if (txt_c_pin.Text == "")
        {
            lbl_msg.Text = " Please Enter Communication Pin Code !.";
            txt_c_pin.Focus();
            return;
        }
        if (txt_p_address.Text == "")
        {
            lbl_msg.Text = " Please Enter Permanent Address !.";
            txt_p_address.Focus();
            return;
        }

        if (txt_p_city.Text == "")
        {
            lbl_msg.Text = " Please Enter Permanent City !.";
            txt_p_city.Focus();
            return;
        }

        if (txt_p_state.Text == "")
        {
            lbl_msg.Text = " Please Enter Permanent State !.";
            txt_p_state.Focus();
            return;
        }
        if (txt_p_pincode.Text == "")
        {
            lbl_msg.Text = " Please Enter Permanent Pin Code !.";
            txt_p_pincode.Focus();
            return;
        }


        if (gv_education.Rows.Count ==0)
        {
            lbl_msg.Text = " Please Enter Qualification .";
            txt_qualification.Focus();
            return;
        }
        if (txt_total_Experience.Text=="")
        {
            txt_total_Experience.Text ="0";
        }
        if (gv_work_experience.Rows.Count > 0)
        {
            if (txt_total_Experience.Text == "")
            {
                lbl_msg.Text = " Please Enter Total Experience .";
                txt_total_Experience.Focus();
                return;
            
            }

            if (gv_references.Rows.Count == 0)
            {
                lbl_msg.Text = " Please Enter At least One Reference Details ";
                txt_name.Focus();
                return;
            
            }
        }
        if (gv_Language.Rows.Count == 0)
        {
            lbl_msg.Text = " Please Enter Language .";
            txt_language.Focus();
            return;
        }
        if (chk_about_company.SelectedIndex==-1)
        {
            lbl_msg.Text = " Please Enter How did you learn about the vacancy .";
            chk_about_company.Focus();
            return;
        }
        string ext = Path.GetExtension(upl_resume.PostedFile.ContentType);
        if (upl_resume.PostedFile.ContentLength > 1048567)
        {
            lbl_msg.Text = "Resume file can not upload more than 1MB.";
            upl_resume.Focus();
            return;
        }
        string ext_photo = Path.GetExtension(upd_photo.PostedFile.ContentType);
        if (upd_photo.PostedFile.ContentLength > 51200)
        {
            lbl_msg.Text = "Photo file can not upload more than 50 KB.";
            upd_photo.Focus();
            return;
        }
        
        if (upd_sign.PostedFile.ContentLength > 51200)
        {
            lbl_msg.Text = "Signature file can not upload more than 50 KB.";
            upd_sign.Focus();
            return;
        }
        if (upd_certificate.PostedFile.ContentLength > 1048567)
        {
            lbl_msg.Text = "Signature file can not upload more than 1 MB.";
            upd_certificate.Focus();
            return;
        }


        //if (lbl_min_Age.Value != "" && lbl_max_age.Value != "")
        //{
        //    int min =Convert.ToInt32( lbl_min_Age.Value);
        //    int max = Convert.ToInt32(lbl_max_age.Value);
        //    if()
        //}
        //if (chk_about_company.SelectedIndex == -1)
        //{
        //    lbl_msg.Text = " Please Enter How did you learn about the vacancy .";
        //    chk_about_company.Focus();
        //    return;
        //}

        SetRequitmentRegistrationMasterObjInfo();
        foreach (ErrorHandlerClass err in objRequitmentRegistrationMasterManager.SaveRequitmentRegistrationMaster(ObjRequitmentRegistrationMaster, SetEducationMasterObjInfo(), SetProfesionalEducationMasterObjInfo(), SetExperienceMasterObjInfo(), SetReferencesMasterObjInfo(), SetLanguageMasterObjInfo()))
        {
            if (err.Type == "E")
            {
                lbl_msg.ForeColor = System.Drawing.Color.Red;
                lbl_msg.Text = err.Message.ToString();
                break;
            }
            else if (err.Type == "A")
            {
                lbl_msg.ForeColor = System.Drawing.Color.Red;
                lbl_msg.Text = err.Message.ToString();
                break;
            }
            else if (err.Type == "S")
            {

                lbl_msg.ForeColor = System.Drawing.Color.Green;
                lbl_msg.Text = err.Message.ToString();
                string ReturnValue = err.ReturnValue.ToString();
                Session["Education"] = null;
                Session["ProEducation"] = null;
                Session["Experience"] = null;
                Session["References"] = null;
                Session["Languages"] = null;
               
                BindEducation();
                BindProfessionalEducation();
                BindLanguage();
                BindReferences();
                BindWorkExperience();
                ClearAll();
                Response.Redirect("~/Pages/Universal/frmPrintRegistration.aspx?rid=" + ReturnValue);


            }

        }

        
    }

    public void SetRequitmentRegistrationMasterObjInfo()
    {
        string total = "0";
        total = txt_total_Experience.Text.Trim();
         ObjRequitmentRegistrationMaster.Post = ddl_post.SelectedValue.ToString();
        ObjRequitmentRegistrationMaster.FName = txt_fname.Text.Trim();
        ObjRequitmentRegistrationMaster.MName = txt_mname.Text.Trim();
        ObjRequitmentRegistrationMaster.LName = txt_lname.Text.Trim();
        ObjRequitmentRegistrationMaster.FatherFname = txt_f_fname.Text.Trim();
        ObjRequitmentRegistrationMaster.FatherMName = txt_f_mname.Text.Trim();
        ObjRequitmentRegistrationMaster.FatherLName = txt_f_lname.Text.Trim();
        ObjRequitmentRegistrationMaster.Dob = txt_dob.Text.Trim();
        ObjRequitmentRegistrationMaster.Category = rdo_categry.SelectedValue.ToString();
        ObjRequitmentRegistrationMaster.CAddress = txt_c_address.Text.Trim();
        ObjRequitmentRegistrationMaster.CCity = txt_C_city.Text.Trim();
        ObjRequitmentRegistrationMaster.CState = txt_c_state.Text.Trim();
        ObjRequitmentRegistrationMaster.CPincode = txt_c_pin.Text.Trim();
        ObjRequitmentRegistrationMaster.PAddress = txt_p_address.Text.Trim();
        ObjRequitmentRegistrationMaster.PCity = txt_p_city.Text.Trim();
        ObjRequitmentRegistrationMaster.PState = txt_p_state.Text.Trim();
        ObjRequitmentRegistrationMaster.PPincode = txt_p_pincode.Text.Trim();
        ObjRequitmentRegistrationMaster.Email = txt_email.Text.Trim();
        ObjRequitmentRegistrationMaster.Mobile = txt_mobile.Text.Trim();
        ObjRequitmentRegistrationMaster.TotalEperience = total;
        ObjRequitmentRegistrationMaster.NameOfOrg = ddl_org.SelectedValue.ToString();
        ObjRequitmentRegistrationMaster.NameOfPost = txt_org_post.Text;
        ObjRequitmentRegistrationMaster.DateOfApplied = txt_Date_of_applied.Text;
        ObjRequitmentRegistrationMaster.OutCome = txt_outcome.Text;
        ObjRequitmentRegistrationMaster.AboutCompany = chk_about_company.SelectedValue.ToString();
        ObjRequitmentRegistrationMaster.DateOfIssue = txt_Date_of_issue.Text;
        ObjRequitmentRegistrationMaster.IssueingAuthority = txt_authority.Text;
        ObjRequitmentRegistrationMaster.CardNo = txt_certificate_no.Text;
        if (upl_resume.PostedFile.ContentLength > 0)
        {
            string date = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            string fileName = date + upl_resume.FileName;
            string path = Server.MapPath("~/Resumes/" + fileName);
            upl_resume.SaveAs(path);
           
            ObjRequitmentRegistrationMaster.Resume= fileName;
           
        }
        if (upd_photo.PostedFile.ContentLength > 0)
        {
            string date = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            string fileName = date + upd_photo.FileName;
            string path = Server.MapPath("~/Photos/" + fileName);
            upd_photo.SaveAs(path);

            ObjRequitmentRegistrationMaster.Photo = fileName;

        }
        if (upd_sign.PostedFile.ContentLength > 0)
        {
            string date = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            string fileName = date + upd_sign.FileName;
            string path = Server.MapPath("~/Signatures/" + fileName);
            upd_sign.SaveAs(path);

            ObjRequitmentRegistrationMaster.Signature = fileName;

        }
        if (upd_certificate.PostedFile.ContentLength > 0)
        {
            string date = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            string fileName = date + upd_certificate.FileName;
            string path = Server.MapPath("~/Certificates/" + fileName);
            upd_certificate.SaveAs(path);

            ObjRequitmentRegistrationMaster.Certificate = fileName;

        }
       
        
    
    }
    public ICollection<EducationMaster>SetEducationMasterObjInfo()
    {
        List<EducationMaster> lst = new List<EducationMaster>();
        if (gv_education.Rows.Count > 0)
        {
            for (int i = 0; i < gv_education.Rows.Count; i++)
            {
                Label lbl_Qualification = (Label)gv_education.Rows[i].FindControl("lbl_Qualification");
                Label lbl_University = (Label)gv_education.Rows[i].FindControl("lbl_University");
                Label lbl_PassingYear = (Label)gv_education.Rows[i].FindControl("lbl_PassingYear");
                Label lbl_Grade = (Label)gv_education.Rows[i].FindControl("lbl_Grade");
                ObjEducationMaster.Qualification = lbl_Qualification.Text.Trim();
                ObjEducationMaster.Univercity = lbl_University.Text.Trim();
                ObjEducationMaster.PassingYear = lbl_PassingYear.Text.Trim();
                ObjEducationMaster.Grade = lbl_Grade.Text.Trim();
                ObjEducationMaster.EType ="General";
                lst.Add(ObjEducationMaster);
            }
        }
        else
        {
            lbl_msg.Text = "Please Enter Education Details.";
            return null;
        }
        return lst;
        
    }
    public ICollection<ProfessionalEducationMaster> SetProfesionalEducationMasterObjInfo()
    {
        List<ProfessionalEducationMaster> lst = new List<ProfessionalEducationMaster>();
        if (gv_pro_education.Rows.Count > 0)
        {
            for (int i = 0; i < gv_pro_education.Rows.Count; i++)
            {
                Label lbl_Qualification = (Label)gv_pro_education.Rows[i].FindControl("lbl_Qualification");
                Label lbl_University = (Label)gv_pro_education.Rows[i].FindControl("lbl_University");
                Label lbl_PassingYear = (Label)gv_pro_education.Rows[i].FindControl("lbl_PassingYear");
                Label lbl_Grade = (Label)gv_pro_education.Rows[i].FindControl("lbl_Grade");
                ObjProfessionalEducationMaster.Qualification = lbl_Qualification.Text.Trim();
                ObjProfessionalEducationMaster.Univercity = lbl_University.Text.Trim();
                ObjProfessionalEducationMaster.PassingYear = lbl_PassingYear.Text.Trim();
                ObjProfessionalEducationMaster.Grade = lbl_Grade.Text.Trim();
                ObjProfessionalEducationMaster.EType = "Pro";
                lst.Add(ObjProfessionalEducationMaster);
            }
        }
        return lst;
        //else
        //{
        //    lbl_msg.Text = "Please Enter Education Details.";
        //    return;
        //}


    }
    public ICollection<ReferencesMaster> SetReferencesMasterObjInfo()
    {
        List<ReferencesMaster> lst = new List<ReferencesMaster>();
       
        if (gv_references.Rows.Count > 0)
        {
            for (int i = 0; i < gv_references.Rows.Count; i++)
            {
                Label lbl_Name = (Label)gv_references.Rows[i].FindControl("lbl_Name");
                Label lbl_Address = (Label)gv_references.Rows[i].FindControl("lbl_Address");
                Label lbl_Contact = (Label)gv_references.Rows[i].FindControl("lbl_Contact");

                ObjReferencesMaster.Name = lbl_Name.Text.Trim();
                ObjReferencesMaster.Address = lbl_Address.Text.Trim();
                ObjReferencesMaster.Contact = lbl_Contact.Text.Trim();
                lst.Add(ObjReferencesMaster);
            }
           
        }
        return lst;
        //else
        //{
        //    lbl_msg.Text = "Please Enter Education Details.";
        //    return;
        //}


    }
    public ICollection<ExperienceMaster> SetExperienceMasterObjInfo()
    {
        List<ExperienceMaster> lst = new List<ExperienceMaster>();

        if (gv_work_experience.Rows.Count > 0)
        {
            for (int i = 0; i < gv_work_experience.Rows.Count; i++)
            {
                Label lbl_Organization = (Label)gv_work_experience.Rows[i].FindControl("lbl_Organization");
                Label lbl_Designation = (Label)gv_work_experience.Rows[i].FindControl("lbl_Designation");
                Label lbl_Duration = (Label)gv_work_experience.Rows[i].FindControl("lbl_Duration");
                Label lbl_Salary = (Label)gv_work_experience.Rows[i].FindControl("lbl_Salary");
                Label lbl_Jobprofile = (Label)gv_work_experience.Rows[i].FindControl("lbl_Jobprofile");


                ObjExperienceMaster.Organization = lbl_Organization.Text.Trim();
                ObjExperienceMaster.Designation = lbl_Designation.Text.Trim();
                ObjExperienceMaster.Duration = lbl_Duration.Text.Trim();
                ObjExperienceMaster.Salary =Convert.ToInt32(lbl_Salary.Text.Trim());
                ObjExperienceMaster.JobDescription = lbl_Jobprofile.Text.Trim();
         
               
                lst.Add(ObjExperienceMaster);
            }

        }
        return lst;
        //else
        //{
        //    lbl_msg.Text = "Please Enter Education Details.";
        //    return;
        //}


    }
    public ICollection<LanguageMaster> SetLanguageMasterObjInfo()
    {
        List<LanguageMaster> lst = new List<LanguageMaster>();

        if (gv_Language.Rows.Count > 0)
        {
            for (int i = 0; i < gv_Language.Rows.Count; i++)
            {
                Label lbl_Language = (Label)gv_Language.Rows[i].FindControl("lbl_Language");
                Label lbl_Read = (Label)gv_Language.Rows[i].FindControl("lbl_Read");
                Label lbl_Speak = (Label)gv_Language.Rows[i].FindControl("lbl_Speak");
                Label lbl_Write = (Label)gv_Language.Rows[i].FindControl("lbl_Write");



                ObjLanguageMaster.Language = lbl_Language.Text.Trim();
                ObjLanguageMaster.Reads = lbl_Read.Text.Trim();
                ObjLanguageMaster.Speak = lbl_Speak.Text.Trim();
            
                ObjLanguageMaster.Write = lbl_Write.Text.Trim();


                lst.Add(ObjLanguageMaster);
            }

        }
        return lst;
        //else
        //{
        //    lbl_msg.Text = "Please Enter Education Details.";
        //    return;
        //}


    }

    protected void ddl_post_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_post.SelectedIndex > 0)
        {

            int post_id = Convert.ToInt32(ddl_post.SelectedValue.ToString());
            DataSet ds = new DataSet();
            ds = ObjPostMasterManager.GetPostMasterById(post_id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_max_age.Value = ds.Tables[0].Rows[0]["MaxAge"].ToString();
                lbl_min_Age.Value = ds.Tables[0].Rows[0]["MinAge"].ToString();
            }
        }
    }
}