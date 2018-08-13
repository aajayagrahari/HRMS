using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HRMS_Class;
using ErrorHandler;
public partial class Pages_Admin_JobMaster : System.Web.UI.Page
{
    JobMasterManager objJobMasterManager = new JobMasterManager();
    JobMaster objJobMaster = new JobMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            iniControls();
            lbl_msg.Text = "";
        }
    }
    void   iniControls()
       {
       txt_discription.Text="";
           txt_job_title.Text="";
       }
    void SetObjInfo()
    { 
     try
        {
            if (upd_job.PostedFile.ContentLength > 0)
        {
            string date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string second = DateTime.Now.Second.ToString();
            string fileName = date + upd_job.FileName;
            string path = Server.MapPath("~/Jobs/" + fileName);
            upd_job.SaveAs(path);
            objJobMaster.Title = txt_job_title.Text.Trim();
            objJobMaster.Description = txt_discription.Text.Trim();
            objJobMaster.Files = fileName;
            objJobMaster.ModifiedBy = "";
            objJobMaster.CreatedBy = "";
        }

        }
     catch (Exception ex)
     {
         lbl_msg.Text = "" + ex.Message.ToString();
     }
    
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (txt_job_title.Text == "")
        {
            lbl_msg.Text ="Enter Job Title !.";
            txt_job_title.Focus();
            return;
        }

        if (txt_discription.Text == "")
        {
            lbl_msg.Text = "Enter Discription !.";
            txt_discription.Focus();
            return;
        }

        if (upd_job.PostedFile.FileName.Length==0)
        {
            lbl_msg.Text = "Choose Job File";
            upd_job.Focus();
            return;
        }
        SetObjInfo();

        foreach (ErrorHandlerClass err in objJobMasterManager.SaveJobMaster(objJobMaster))
        {

            if (err.Type == "E")
            {
                lbl_msg.Text = err.Message.ToString();
                break;
            }
            else if (err.Type == "A")
            {
                lbl_msg.Text = err.Message.ToString();
                break;
            }
            else
            {
                if (err.Type == "S")
                {
                    lbl_msg.Text = err.Message.ToString();
                    iniControls();
                    //Response.Redirect("ListOrchardMaster.aspx?OrchardCode=");
                }
            }

        }

    }
}