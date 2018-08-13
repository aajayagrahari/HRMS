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
public partial class Pages_Admin_ListCircularMaster : System.Web.UI.Page
{
    CircularMasterManager objCircularMasterManager = new CircularMasterManager();
    CircularMaster objCircularMaster = new CircularMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCircularMaster();
        }
    }
    void BindCircularMaster()
    {

        DataSet ds = new DataSet();
        ds = objCircularMasterManager.GetCircularMaster();

        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_list_circular_master.DataSource = ds.Tables[0];
            gv_list_circular_master.DataBind();

        }
        else
        {

            gv_list_circular_master.DataSource = null;
            gv_list_circular_master.DataBind();
            lblMsg.Text ="Record Not Found !.";
        }
    }




    protected void gv_list_circular_master_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image Img4Delete = ((Image)e.Row.FindControl("Img4Delete"));
                Image ImgTick = ((Image)e.Row.FindControl("ImgTick"));
                Label lbl_deleted = ((Label)e.Row.FindControl("lbl_IsDeleted"));

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
            //lbl_msg.Text = "" + ex.Message.ToString();
            // objErrorLog.WriteErrorLog(ex.ToString());
        }


    }
    protected void gv_list_circular_master_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_list_circular_master.PageIndex = e.NewPageIndex;
        BindCircularMaster();
    }
    protected void gv_list_circular_master_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        long cid=Convert.ToInt64(gv_list_circular_master.DataKeys[e.RowIndex].Value.ToString());
        Label is_deleted = (Label)gv_list_circular_master.Rows[e.RowIndex].FindControl("lbl_IsDeleted");
        int deleted=Convert.ToInt32(is_deleted.Text);
        if (deleted == 0)
        {
            deleted = 1;
        }
        else
        {
            deleted = 0;
        }
        objCircularMaster.CId = cid;
        objCircularMaster.IsDeleted = deleted;
        objCircularMaster.ModifiedBy = Session["LoginId"].ToString();

        foreach (ErrorHandlerClass err in objCircularMasterManager.DeleteCircularMaster(objCircularMaster))
        {
            if (err.Type == "E")
            {
                lblMsg.ForeColor =System.Drawing.Color.Red;
                lblMsg.Text = err.Message.ToString();
                break;
            }
            else if (err.Type == "A")
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = err.Message.ToString();
                break;
            }
            else if (err.Type == "S")
            {

                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = err.Message.ToString();

                BindCircularMaster();


            }

        }

    }
}