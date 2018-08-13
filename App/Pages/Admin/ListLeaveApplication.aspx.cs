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
public partial class Pages_Admin_ListLeaveApplication : System.Web.UI.Page
{
    LeaveApplicationManager objLeaveApplicationManager = new LeaveApplicationManager();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindLeaveApplication();
        }
    }

    public void BindLeaveApplication()
    {
        DataSet ds = new DataSet();
        ds = objLeaveApplicationManager.GetLeaveApplication();
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdLeaveApplicationList.DataSource = ds;
            grdLeaveApplicationList.DataBind();
        }

    }

    protected void grdLeaveApplicationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdLeaveApplicationList.PageIndex = e.NewPageIndex;
        
        BindLeaveApplication();
    }

    protected void grdLeaveApplicationList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Download")
            {
                string rid = Convert.ToString(e.CommandArgument);
                DataSet dt = new DataSet();
                dt = objLeaveApplicationManager.GetLeaveApplication4ID(rid);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    string filename = dt.Tables[0].Rows[0]["EmpDocument"].ToString();
                    string Resume = "~/Leave/" + filename;
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

    protected void grdLeaveApplicationList_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdLeaveApplicationList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdLeaveApplicationList_RowDataBound(object sender, GridViewRowEventArgs e)
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