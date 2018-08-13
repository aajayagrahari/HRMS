using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ErrorHandler;
using HRMS_Class;
using System.Drawing;
using System.Data;

#region Development Details
//Shruti Dwivedi(25-09-2013)
#endregion Development Details

public partial class Pages_Admin_frmHolidayMaster : System.Web.UI.Page
{
    #region Global Variable Declaration
    HolidayMaster _objHolidayMaster = new HolidayMaster();
    HolidayMasterManager _objHolidayMasterManager = new HolidayMasterManager();
    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindFinyear();
                BindGridView();
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            SetObjectInfo(_objHolidayMaster);
            if (hdnHolyDayId.Value == "")
            {
                foreach (ErrorHandlerClass err in _objHolidayMasterManager.SaveHolidayMaster(_objHolidayMaster))
                {
                    if (err.Type == "E")
                    {
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Text = err.Message.ToString();
                        break;
                    }
                    else if (err.Type == "A")
                    {
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Text = err.Message.ToString();
                        break;
                    }
                    else
                    {
                        if (lblMsg.Text.ToString() == "")
                        {
                            lblMsg.ForeColor = Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            gdvHolidayList.EditIndex = -1;
                            BindGridView();

                        }
                    }

                }
            }
            else
            {
                _objHolidayMaster.HolidaysId = Convert.ToInt32(hdnHolyDayId.Value);
                foreach (ErrorHandlerClass err in _objHolidayMasterManager.UpdateHolidayMaster(_objHolidayMaster))
                {
                    if (err.Type == "E")
                    {
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Text = err.Message.ToString();
                        break;
                    }
                    else if (err.Type == "A")
                    {
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Text = err.Message.ToString();
                        break;
                    }
                    else
                    {
                        if (lblMsg.Text.ToString() == "")
                        {
                            lblMsg.ForeColor = Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            gdvHolidayList.EditIndex = -1;
                            BindGridView();
                            hdnHolyDayId.Value = "";

                        }
                    }

                }
            }
            gdvHolidayList.EditIndex = -1;
            BindGridView();
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }

    protected void gdvHolidayList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gdvHolidayList.PageIndex = e.NewPageIndex;
            BindGridView();
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }

    }

    protected void gdvHolidayList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit")
            {
                DataTable dt = _objHolidayMasterManager.GetHolidayMasterById(Convert.ToInt32(e.CommandArgument)).Tables[0];
                _objHolidayMaster.SetObjectInfo(dt.Rows[0]);
                AssignVariableTOControl(_objHolidayMaster);
                btnSave.Text = "Update";
                hdnHolyDayId.Value = e.CommandArgument.ToString();
            }
            else if (e.CommandName == "Delete")
            {
                _objHolidayMaster.HolidaysId = Convert.ToInt32(e.CommandArgument);
                foreach (ErrorHandlerClass err in _objHolidayMasterManager.DeleteHolidayMaster(_objHolidayMaster))
                {
                    if (err.Type == "E")
                    {
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Text = err.Message.ToString();
                        break;
                    }
                    else if (err.Type == "A")
                    {
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Text = err.Message.ToString();
                        break;
                    }
                    else
                    {
                        if (lblMsg.Text.ToString() == "")
                        {
                            lblMsg.ForeColor = Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            gdvHolidayList.EditIndex = -1;
                            BindGridView();
                            hdnHolyDayId.Value = "";

                        }
                    }

                }
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }

    }

    protected void gdvHolidayList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }

    protected void gdvHolidayList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        gdvHolidayList.EditIndex = -1;
        BindGridView();
    }
    #endregion Page Event

    #region Page Specific Function
    private void SetObjectInfo(HolidayMaster _objHolidayMaster)
    {
        _objHolidayMaster.FinancialYear = ddlFinYear.SelectedValue;
        _objHolidayMaster.HoliDays = txtHoliday.Text;
        _objHolidayMaster.EnglishMonth = ddlMonth.SelectedValue;
        _objHolidayMaster.EnglishDate = Convert.ToInt32(ddlDate.SelectedValue);
        _objHolidayMaster.SakaMonth = ddlSakaMonth.SelectedValue;
        _objHolidayMaster.SakaDate = Convert.ToInt32(ddlSakaDate.SelectedValue);
        _objHolidayMaster.HoliDays_Day = ddlWeekDay.SelectedValue;
        _objHolidayMaster.Holidays_Type = ddlHoliDayNature.SelectedValue;
        _objHolidayMaster.CreatedBy = Session["LoginId"].ToString();
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

        DataTable dt = new DataTable();
        dt.Columns.Add("val");
        dt.Columns.Add("txt");
        DataRow dr = dt.NewRow();
        DataRow dr1 = dt.NewRow();

        string[] str = finyear.Split('-');
        dr["val"] = str[0];
        dr["txt"] = str[0];

        dt.Rows.Add(dr);
        dr1["val"] = str[1];
        dr1["txt"] = str[1];

        dt.Rows.Add(dr1);

        return dt;
    }

    private void BindFinyear()
    {
        ddlFinYear.DataSource = GetFinYear(DateTime.Now.ToString());
        ddlFinYear.DataTextField = GetFinYear(DateTime.Now.ToString()).Columns["txt"].ToString();
        ddlFinYear.DataValueField = GetFinYear(DateTime.Now.ToString()).Columns["val"].ToString();
        ddlFinYear.DataBind();
    }

    private void BindGridView()
    {
        DataTable _dt = _objHolidayMasterManager.GetHolidayMaster().Tables[0];
        gdvHolidayList.DataSource = _dt;
        gdvHolidayList.DataBind();
    }

    private void AssignVariableTOControl(HolidayMaster _objHolidayMaster)
    {
        if (_objHolidayMaster != null)
        {
            ddlFinYear.SelectedValue = _objHolidayMaster.FinancialYear;
            ddlHoliDayNature.SelectedValue = _objHolidayMaster.Holidays_Type;
            ddlMonth.SelectedValue = _objHolidayMaster.EnglishMonth.Split('-')[0];
            ddlDate.SelectedValue = _objHolidayMaster.EnglishDate.ToString();
            ddlSakaMonth.SelectedValue = _objHolidayMaster.SakaMonth;
            ddlSakaDate.SelectedValue = _objHolidayMaster.SakaDate.ToString();
            ddlWeekDay.SelectedValue = _objHolidayMaster.HoliDays_Day;
            txtHoliday.Text = _objHolidayMaster.HoliDays;
        }
    }
    #endregion Page Specific Function

}