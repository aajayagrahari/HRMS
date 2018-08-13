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
public partial class Pages_Admin_ListLoaneApplication : System.Web.UI.Page
{
    LoaneApplicationManager objLoaneApplicationManager = new LoaneApplicationManager();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindLeaveApplication();
        }
    }
    void BindLeaveApplication()
    {
        try
        {
            lbl_msg.Text = "";
            DataSet ds = new DataSet();
            ds = objLoaneApplicationManager.GetLoaneApplication();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                grdLoaneApplication.DataSource = ds;
                grdLoaneApplication.DataBind();
            }
            else
            {
                lbl_msg.Text = "No Record Found";
            }
        }
        catch (Exception ex)
        {
            lbl_msg.Text = "" + ex.Message.ToString();
        }
    }

    protected void grdLoaneApplication_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdLoaneApplication.PageIndex = e.NewPageIndex;

        BindLeaveApplication();
    }

    protected void grdLoaneApplication_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Download")
            {

                string rid = Convert.ToString(e.CommandArgument);
                DataSet dt = new DataSet();
                dt = objLoaneApplicationManager.GetLoaneApplication4ID(rid);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    string filename = dt.Tables[0].Rows[0]["EmpDocument"].ToString();
                    string Resume = "~/Loan/" + filename;
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

    protected void grdLoaneApplication_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdLoaneApplication_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdLoaneApplication_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image Img4Delete = ((Image)e.Row.FindControl("Img4Delete"));
                Image ImgTick = ((Image)e.Row.FindControl("ImgTick"));
                Label lbl_IsDeleted = ((Label)e.Row.FindControl("lbl_IsDeleted"));

                if (Convert.ToInt32(lbl_IsDeleted.Text) != 0)
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