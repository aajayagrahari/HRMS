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
// Harendra kumar maurya(23-10-2013)
#endregion Development Details
public partial class Pages_Admin_RequitmentRegistration : System.Web.UI.Page
{
    RequitmentRegistrationMasterManager objRequitmentRegistrationMasterManager = new RequitmentRegistrationMasterManager();
    RequitmentRegistrationMaster ObjRequitmentRegistrationMaster = new RequitmentRegistrationMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRequitmentMaster();
        }
    }
    void BindRequitmentMaster()
    {
        DataSet ds = new DataSet();
        ds = objRequitmentRegistrationMasterManager.GetRequitmentRegistration4Admin();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_requitmentMaster.DataSource = ds.Tables[0];
            gv_requitmentMaster.DataBind();

        }
        else
        {
            gv_requitmentMaster.DataSource = null;
            gv_requitmentMaster.DataBind();
            lbl_msg.Text = "Record Not Found !.";
        }
    }
    protected void gv_requitmentMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_requitmentMaster.PageIndex = e.NewPageIndex;
        BindRequitmentMaster();
    }
    protected void gv_requitmentMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {

            long rid = Convert.ToInt32(e.CommandArgument.ToString());
            DataTable dt = new DataTable();
            dt = objRequitmentRegistrationMasterManager.GetRequitmentRegistration(rid).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string filename = dt.Rows[0]["Resume"].ToString();
                string Resume = "~/Resumes/" + filename;
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.Charset = "";
                response.ContentType = "application/vnd.word";
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                Response.TransmitFile(Resume);
                response.End();
            }
        }

        if (e.CommandName == "Certificate")
        {

            long rid = Convert.ToInt32(e.CommandArgument.ToString());
            DataTable dt = new DataTable();
            dt = objRequitmentRegistrationMasterManager.GetRequitmentRegistration(rid).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string filename = dt.Rows[0]["Certificate"].ToString();
                string Resume = "~/Certificates/" + filename;
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