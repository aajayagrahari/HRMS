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
public partial class ListRequitmentMaster : System.Web.UI.Page
{
    RequitmentMasterManager objRequitmentMasterManager = new RequitmentMasterManager();
    RequitmentMaster objRequitmentMaster = new RequitmentMaster();
    BindComboMasterManager objBindComboMasterManager = new BindComboMasterManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            BindRequitmentMaster();
        }

    }

    void BindRequitmentMaster()
    {
        DataTable dt = new DataTable();
        dt = objRequitmentMasterManager.GetRequitmentMaster();
        if (dt.Rows.Count > 0)
        {
            gv_requitmentmaster.DataSource = dt;
            gv_requitmentmaster.DataBind();
        }
    
    }
    protected void gv_requitmentmaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_requitmentmaster.PageIndex = e.NewPageIndex;
        gv_requitmentmaster.DataBind();
    }
    protected void gv_requitmentmaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {

            int rid = Convert.ToInt32(e.CommandArgument.ToString());
            DataTable dt = new DataTable();
            dt = objRequitmentMasterManager.GetRequitmentMaster4Download(rid);
            if (dt.Rows.Count > 0)
            {
                string filename =dt.Rows[0]["Resume"].ToString();
                string Resume = "~/Resume/" + filename;
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