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
public partial class Pages_Admin_JobMasterDetails : System.Web.UI.Page
{
    JobMasterManager objJobMasterManager = new JobMasterManager();
    JobMaster objJobMaster = new JobMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            GetJobId();
            BindJobDetails();
        }
    }
    public long GetJobId()
    {
        long JobId = 0;
        if (Request.QueryString["JobId"] != null)
        {
            JobId = Convert.ToInt64(Request.QueryString["JobId"].ToString());
        }
        return JobId;
    }
    void BindJobDetails()
    { 
      DataSet dt = new DataSet();
      dt = objJobMasterManager.GetJobMaster4Id(GetJobId());
                if (dt.Tables[0].Rows.Count > 0)
                {
                    txt_job_title.Text = dt.Tables[0].Rows[0]["Title"].ToString();
                    txt_discription.Text = dt.Tables[0].Rows[0]["Description"].ToString();
                    ViewState["Fiels"] = dt.Tables[0].Rows[0]["Files"].ToString();
                }
    
    }
    void SetObjInfo()
    {
        try
        {
            if (upd_job.PostedFile.ContentLength > 0)
            {
                string files = objJobMaster.Files = ViewState["Fiels"].ToString();
                string paths = Server.MapPath("~/images/FruitImages/" + files);
                if (File.Exists(paths))
                {
                    File.Delete(paths);
                }
                string date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string second = DateTime.Now.Second.ToString();
                string fileName = date + upd_job.FileName;
                string path = Server.MapPath("~/Jobs/" + fileName);
                upd_job.SaveAs(path);
                objJobMaster.JobId = GetJobId();
                objJobMaster.Title = txt_job_title.Text.Trim();
                objJobMaster.Description = txt_discription.Text.Trim();
                objJobMaster.Files = fileName;
                objJobMaster.ModifiedBy = "";
                objJobMaster.CreatedBy = "";
            }
            else

            {
                if (ViewState["Fiels"] != null)
                {

                  objJobMaster.Files=  ViewState["Fiels"].ToString();
                  objJobMaster.JobId = GetJobId();
                  objJobMaster.Title = txt_job_title.Text.Trim();
                  objJobMaster.Description = txt_discription.Text.Trim();
                //  objJobMaster.Files = fileName;
                  objJobMaster.ModifiedBy = "";
                  objJobMaster.CreatedBy = "";
                }
            
            
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
            lbl_msg.Text = "Enter Job Title !.";
            txt_job_title.Focus();
            return;
        }

        if (txt_discription.Text == "")
        {
            lbl_msg.Text = "Enter Discription !.";
            txt_discription.Focus();
            return;
        }

       
        SetObjInfo();

        foreach (ErrorHandlerClass err in objJobMasterManager.UpdateJobMaster(objJobMaster))
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
                   
                    //Response.Redirect("ListOrchardMaster.aspx?OrchardCode=");
                }
            }

        }
    }
}