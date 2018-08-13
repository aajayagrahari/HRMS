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

public partial class Pages_Employee_ListHolidayMaster : System.Web.UI.Page
{
    HolidayMasterManager objHolidayMasterManager = new HolidayMasterManager();

    DataSet ds4HolidayDetails = new DataSet();
    DataTable dt4Holiday = new DataTable();

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
    public void BindHolidaysDetails(string FinYear, string Month)
    {
        try
        {
            ds4HolidayDetails = objHolidayMasterManager.GetHolidayDetails4Month(Month, FinYear);
            grdHolidayDetails.DataSource = ds4HolidayDetails.Tables[0];
            grdHolidayDetails.DataBind();
            Session["HolidayDetails"] = ds4HolidayDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    #endregion

    #region Grid Events
    //Employee Earning Grid
    protected void grdHolidayDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            LinkButton btnDelete = ((LinkButton)e.Row.FindControl("btnDelete"));
            Image Img4Delete = ((Image)e.Row.FindControl("Img4Delete"));
            Image ImgTick = ((Image)e.Row.FindControl("ImgTick"));
            Label lbl_IsDeleted = ((Label)e.Row.FindControl("lbl_IsDeleted"));
            LinkButton btnEdit = ((LinkButton)e.Row.FindControl("btnEdit"));

            if (Convert.ToBoolean(lbl_IsDeleted.Text) != false)
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

    protected void grdHolidayDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {

        }
    }

    protected void grdHolidayDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdHolidayDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

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
                    BindHolidaysDetails(Convert.ToString(ddlFinYear.SelectedValue), Convert.ToString(ddlMonth.SelectedValue));
                }
                else
                {
                    lblMsg.Text = "Please Select Month";
                }
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = "" + ee.Message.ToString();
        }

    }
    #endregion

}