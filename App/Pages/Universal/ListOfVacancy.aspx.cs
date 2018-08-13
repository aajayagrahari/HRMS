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
public partial class Pages_Universal_ListOfVacancy : System.Web.UI.Page
{
    JobMasterManager objJobMasterManager = new JobMasterManager();
    JobMaster objJobMaster = new JobMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindJobs();
            OpenFiles();
        }
    }

    void OpenFiles()
    {
        if (Request.QueryString["JobId"] != null)
        {
            long Jobid = Convert.ToInt64(Request.QueryString["JobId"].ToString());
            DataSet dt = new DataSet();
            dt = objJobMasterManager.GetJobMaster4Id(Jobid);
            if (dt.Tables[0].Rows.Count > 0)
            {
                string filename = dt.Tables[0].Rows[0]["Files"].ToString();
                string Resume = "~/Jobs/" + filename;
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.Charset = "";
                response.ContentType = "application/vnd.word";
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                Response.TransmitFile(Resume);
                response.End();
            }
        }
    }
    void BindJobs()
    {
        DataSet ds = new DataSet();
        ds = objJobMasterManager.GetJobMaster4User();
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpt_vacancy.DataSource = ds;
            rpt_vacancy.DataBind();
            //lbl_title.Text = ds.Tables[0].Rows[0]["Title"].ToString();
            //lbl_description.Text = ds.Tables[0].Rows[0]["Description"].ToString();
        }
    
    }
}