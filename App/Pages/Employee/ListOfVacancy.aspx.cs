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
    AdvertisemetnMasterManager objAdvertisemetnMasterManager = new AdvertisemetnMasterManager();
    AdvertisemetnMaster objAdvertisemetnMaster = new AdvertisemetnMaster();
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
            Int32 Jobid = Convert.ToInt32(Request.QueryString["JobId"].ToString());
            DataSet dt = new DataSet();
            dt = objAdvertisemetnMasterManager.GetAdvertisemetnMasterById(Jobid);
            if (dt.Tables[0].Rows.Count > 0)
            {
                string filename = dt.Tables[0].Rows[0]["PDFFileName"].ToString();
                string ext = Path.GetExtension(filename);
                string Resume = "~/Jobs/" + filename;
                if (ext == ".pdf")
                {
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.Charset = "";
                    response.ContentType = "application/pdf";
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                    Response.TransmitFile(Resume);
                    response.End();
                }
                else
                {
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
    }
    void BindJobs()
    {
        DataSet ds = new DataSet();
        ds = objAdvertisemetnMasterManager.GetAdvertisemetnMaster();
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpt_vacancy.DataSource = ds;
            rpt_vacancy.DataBind();
            //lbl_title.Text = ds.Tables[0].Rows[0]["Title"].ToString();
            //lbl_description.Text = ds.Tables[0].Rows[0]["Description"].ToString();
        }
    
    }
}