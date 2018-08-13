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
public partial class Pages_Admin_ListJobMaster : System.Web.UI.Page
{
    JobMasterManager objJobMasterManager = new JobMasterManager();
    JobMaster objJobMaster = new JobMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            BindJobMaster();
        }
    }
    void BindJobMaster()
    {
        DataSet ds = new DataSet();
        ds = objJobMasterManager.GetJobMaster();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_jobmaster.DataSource = ds;
            gv_jobmaster.DataBind();
        }

    }

    protected void gv_jobmaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_jobmaster.PageIndex = e.NewPageIndex;

        BindJobMaster();
    }

    protected void gv_jobmaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Download")
            {

                int rid = Convert.ToInt32(e.CommandArgument.ToString());
                DataSet dt = new DataSet();
                dt = objJobMasterManager.GetJobMaster4Id(rid);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    string filename = dt.Tables[0].Rows[0]["Files"].ToString();
                    string Resume = "~/Jobs/" + filename;
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.Charset = "";
                    response.ContentType = "application/pdf";
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                    Response.TransmitFile(Resume);
                    response.End();
                }
            }
        }
        catch (Exception ex)
        {
            lbl_msg.Text = ex.ToString();

        }
    }

    protected void gv_jobmaster_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void gv_jobmaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gv_jobmaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image Img4Delete = ((Image)e.Row.FindControl("Img4Delete1"));
                Image ImgTick = ((Image)e.Row.FindControl("ImgTick1"));
                Label lbl_deleted = ((Label)e.Row.FindControl("lbl_deleted"));

                if (Convert.ToInt32(lbl_deleted.Text) != 0)
                {
                    ImgTick.Visible = false;
                    Img4Delete.Visible = true;
                }
                else
                {
                    ImgTick.Visible = true;
                    Img4Delete.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            lbl_msg.Text = "" + ex.Message.ToString();
           // objErrorLog.WriteErrorLog(ex.ToString());
        }
    }

}