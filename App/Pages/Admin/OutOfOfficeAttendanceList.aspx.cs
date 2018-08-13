using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using HRMS_Class;
using ErrorHandler;

public partial class Pages_Admin_OutOfOfficeAttendanceList : System.Web.UI.Page
{

    OutOfOfficeAttendanceMasterManager objOutOfOfficeAttendanceMasterManager = new OutOfOfficeAttendanceMasterManager();

    DataSet ds4OutOfOffice = new DataSet();
    DataTable dt4OutOfOffice = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblMsg.Text = "";
            BindFinyear();
        }
    }

    #region Bind Combo Box
    private void BindFinyear()
    {
        ddlFinYear.DataSource = GetFinYear(DateTime.Now.ToString());
        ddlFinYear.DataTextField = GetFinYear(DateTime.Now.ToString()).Columns["txt"].ToString();
        ddlFinYear.DataValueField = GetFinYear(DateTime.Now.ToString()).Columns["val"].ToString();
        ddlFinYear.DataBind();
        //ddlFinYear.Items.Insert(0, "Select");

    }

    public DataTable GetFinYear(string sdate)
    {
        string finyear = "";
        DateTime s = Convert.ToDateTime(sdate);

        int m = s.Month;
        int y = s.Year;
        if (m > 3)
        {
            finyear = y.ToString() + "-" + Convert.ToString((y + 1));
        }
        else
        {
            finyear = Convert.ToString((y - 1)) + "-" + y.ToString();
        }
        //return finyear;
        DataTable dt = new DataTable();
        dt.Columns.Add("val");
        dt.Columns.Add("txt");
        DataRow dr = dt.NewRow();
        DataRow dr1 = dt.NewRow();

        string[] str = finyear.Split('-');
        dr["val"] = str[0];
        dr["txt"] = str[0];

        dr1["val"] = str[1];
        dr1["txt"] = str[1];
        dt.Rows.Add(dr);
        dt.Rows.Add(dr1);
        return dt;
    }
    #endregion

    #region Bind Grid Functions
    public void BindOutOfOfficeDetails(string FinYear, string Month)
    {
        try
        {
            ds4OutOfOffice = objOutOfOfficeAttendanceMasterManager.GetOutOfOfficeAttendanceMaster();
            dt4OutOfOffice = ds4OutOfOffice.Tables[0];
            grdOutOfOffice.DataSource = dt4OutOfOffice;
            grdOutOfOffice.DataBind();
            Session["OutOfoffice"] = dt4OutOfOffice;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    #endregion

    #region Grid Events
    //Employee Earning Grid
    protected void grdOutOfOffice_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            LinkButton btnDelete = ((LinkButton)e.Row.FindControl("btnDelete"));
            Image Img4Delete = ((Image)e.Row.FindControl("Img4Delete"));
            Image ImgTick = ((Image)e.Row.FindControl("ImgTick"));
            Label lbl_IsDeleted = ((Label)e.Row.FindControl("lbl_IsDeleted"));
            Label lbl_IsApprove = ((Label)e.Row.FindControl("lbl_IsApprove"));
            RadioButtonList rblApproveDisApprove = ((RadioButtonList)e.Row.FindControl("rblApproveDisApprove"));
            LinkButton btnEdit = ((LinkButton)e.Row.FindControl("btnEdit"));

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

            if (Convert.ToString(lbl_IsApprove.Text).Trim() != "")
            {
                rblApproveDisApprove.SelectedValue = Convert.ToString(lbl_IsApprove.Text);
            }
        }
    }

    protected void grdOutOfOffice_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {

        }
    }

    protected void grdOutOfOffice_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdOutOfOffice_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion

    #region Set Object Info
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        try
        {
            foreach (ErrorHandlerClass err in objOutOfOfficeAttendanceMasterManager.ApproveOutOfOfficeAttendanceByAdmin(SetObjectInfo4Approve()))
            {

                if (err.Type == "E")
                {
                    lblMsg.Text = err.Message.ToString();
                    break;
                }
                else if (err.Type == "A")
                {
                    lblMsg.Text = err.Message.ToString();
                    break;
                }
                else
                {
                    if (lblMsg.Text.ToString() == "")
                    {
                        lblMsg.Text = err.Message.ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
            //objErrorLog.WriteErrorLog(ex.ToString());
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
        //Response.Redirect("ListOrchardMaster.aspx");
    }

    public ICollection<OutOfOfficeAttendanceMaster> SetObjectInfo4Approve()
    {
        List<OutOfOfficeAttendanceMaster> lst = new List<OutOfOfficeAttendanceMaster>();
        OutOfOfficeAttendanceMaster objOutOfOfficeAttendanceMaster = null;

        foreach (GridViewRow grd in grdOutOfOffice.Rows)
        {
            RadioButtonList rblApproveDisApprove = (RadioButtonList)grd.FindControl("rblApproveDisApprove");
            Label lbl_EmployeeId = (Label)grd.FindControl("lbl_EmployeeId");
            Label lbl_OutOfOfficeDateFrom = (Label)grd.FindControl("lbl_OutOfOfficeDateFrom");
            Label lbl_IsApprove = (Label)grd.FindControl("lbl_IsApprove");
            Label lbl_Status = (Label)grd.FindControl("lbl_Status");

            if (Convert.ToString(rblApproveDisApprove.SelectedValue).Trim() != "")
            {
                objOutOfOfficeAttendanceMaster = new OutOfOfficeAttendanceMaster();
                objOutOfOfficeAttendanceMaster.EmployeeId = Convert.ToString(lbl_EmployeeId.Text);

                objOutOfOfficeAttendanceMaster.OutOfOfficeDateFrom = Convert.ToString(lbl_OutOfOfficeDateFrom.Text).Trim();

                if (lbl_IsApprove.Text != "")
                {
                    objOutOfOfficeAttendanceMaster.IsApprove = Convert.ToInt32(lbl_IsApprove.Text);
                }
                else
                {
                    objOutOfOfficeAttendanceMaster.IsApprove = -1;
                }

                if (lbl_Status.Text != "")
                {
                    objOutOfOfficeAttendanceMaster.Status = lbl_Status.Text;
                }
                else
                {
                    objOutOfOfficeAttendanceMaster.Status = "Pending";
                }

                objOutOfOfficeAttendanceMaster.Approvedby = Convert.ToString(Session["EmployeeId"]).Trim();
                objOutOfOfficeAttendanceMaster.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
                objOutOfOfficeAttendanceMaster.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();

                lst.Add(objOutOfOfficeAttendanceMaster);
            }
        }
        return lst;
    }
    #endregion

    #region Selected Index Change
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(ddlFinYear.SelectedValue) != "" && Convert.ToString(ddlFinYear.SelectedValue) != "&nbsp;")
            {
                if (ddlMonth.SelectedIndex > 0)
                {
                    BindOutOfOfficeDetails(Convert.ToString(ddlFinYear.SelectedValue), Convert.ToString(ddlMonth.SelectedValue));
                }
                else
                {
                    lblMsg.Text = "Please Select Month";
                    BindOutOfOfficeDetails(Convert.ToString(ddlFinYear.SelectedValue), "-1");
                }
            }

        }
        catch (Exception ee)
        {
            lblMsg.Text = "" + ee.Message.ToString();
        }
    }

    protected void ddlFinYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(ddlFinYear.SelectedValue) != "" && Convert.ToString(ddlFinYear.SelectedValue) != "&nbsp;")
            {
                if (ddlMonth.SelectedIndex > 0)
                {
                    BindOutOfOfficeDetails(Convert.ToString(ddlFinYear.SelectedValue), Convert.ToString(ddlMonth.SelectedValue));
                }
                else
                {
                    lblMsg.Text = "Please Select Month";
                    BindOutOfOfficeDetails(Convert.ToString(ddlFinYear.SelectedValue), "-1");
                }
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = "" + ee.Message.ToString();
        }
    }

    protected void rblApproveDisApprove_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int selRowIndex = ((GridViewRow)(((RadioButtonList)sender).Parent.Parent)).RowIndex;
            RadioButtonList isApprove = (RadioButtonList)grdOutOfOffice.Rows[selRowIndex].FindControl("rblApproveDisApprove");
            Label lbl_IsApprove = (Label)grdOutOfOffice.Rows[selRowIndex].FindControl("lbl_IsApprove");
            Label lbl_Status = (Label)grdOutOfOffice.Rows[selRowIndex].FindControl("lbl_Status");

            if (isApprove.SelectedValue == "1")
            {
                lbl_IsApprove.Text = "1";
                lbl_Status.Text = "Approve";
            }
            else if (isApprove.SelectedValue == "0")
            {
                lbl_IsApprove.Text = "0";
                lbl_Status.Text = "Reject";
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }

        dt4OutOfOffice = (DataTable)Session["OutOfOffice"];
        dt4OutOfOffice.AcceptChanges();
        Session["OutOfOffice"] = (DataTable)dt4OutOfOffice;
    }
    #endregion

}