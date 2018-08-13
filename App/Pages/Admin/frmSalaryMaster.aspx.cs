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
using System.Timers;

public partial class Pages_Admin_frmSalaryMaster : System.Web.UI.Page
{
    EmployeeMontlyAttendanceMasterManager objEmployeeMontlyAttendanceMasterManager = new EmployeeMontlyAttendanceMasterManager();
    EmployeeMasterDetailsManager objEmployeeMasterManager = new EmployeeMasterDetailsManager();
    EmployeeEarningDetailsManager objEmployeeEarningDetailsManager = new EmployeeEarningDetailsManager();
    EmployeeDeductionDetailsManager objEmployeeDeductionDetailsManager = new EmployeeDeductionDetailsManager();
    BindComboMasterManager objBindComboMasterManager = new BindComboMasterManager();
    DataSet ds4EmployeeMasterDetails = new DataSet();
    DataTable dt4EmployeeMaster = new DataTable();

    DataSet ds4EmployeeEarningDetails = new DataSet();
    DataTable dt4EmployeeEarning = new DataTable();

    DataSet ds4EmployeeDeductionDetails = new DataSet();
    DataTable dt4EmployeeDeduction = new DataTable();

    ReportMasterManager _objReportMasterManager = new ReportMasterManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindEmployeeMasterDetails();
            inicontrols();

            if (Convert.ToString(txtCode.Text).Trim() != "")
            {
                BindAllowances(Convert.ToString(txtCode.Text).Trim());

                if (ddlMonth.SelectedIndex > 0)
                {
                    DataTable _dt = _objReportMasterManager.CalculateSalary_MonthWise(Convert.ToInt32(txtCode.Text), Convert.ToInt32(ddlMonth.SelectedValue)).Tables[0];
                    AssignVariableToControl(_dt);
                }
            }
            else
            {
                BindAllowances("-1");
            }
        }
    }

    #region iniControls
    public void inicontrols()
    {
        ddlMonth.SelectedIndex = 0;
        txtTotalDays.Text = "0";
        txtOverTime.Text = "0";
        txtOnDuty.Text = "0";
        txtAbsent.Text = "0";
        txtHolidays.Text = "0";
        txtWeeklyOff1.Text = "0";
        txtEL4Days.Text = "0";
        txtCL4Days.Text = "0";
        txtSL4Days.Text = "0";
        txtL14Days.Text = "0";
        txtL24Days.Text = "0";
        txtL34Days.Text = "0";
        txtRestrictedHolidyas.Text = "0";
        txtMaternity.Text = "0";
        txtDayWork.Text = "0";
        txtPaidDays.Text = "0";
        btnSubmit.Enabled = false;
    }
    #endregion

    #region Bind Combo Box For Earning
    public void BindCalcOn(DropDownList DDLCalcOn)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindCalcOn();
            DDLCalcOn.DataSource = dt;
            DDLCalcOn.DataTextField = "CalculationOn";
            DDLCalcOn.DataValueField = "CalculationOnId";
            DDLCalcOn.DataBind();
            DDLCalcOn.Items.Insert(0, "-- Select--");
            DDLCalcOn.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindPaymentMode(DropDownList DDLpayMode)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindPaymentMode();
            DDLpayMode.DataSource = dt;
            DDLpayMode.DataTextField = "PaymentMode";
            DDLpayMode.DataValueField = "PaymentModeId";
            DDLpayMode.DataBind();
            DDLpayMode.Items.Insert(0, "-- Select--");
            DDLpayMode.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    #endregion

    #region Bind Combo Box For Deduction
    public void BindCalcOnDeductions(DropDownList DDLCalcOnDeduction)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindCalcOn();
            DDLCalcOnDeduction.DataSource = dt;
            DDLCalcOnDeduction.DataTextField = "CalculationOn";
            DDLCalcOnDeduction.DataValueField = "CalculationOnId";
            DDLCalcOnDeduction.DataBind();
            DDLCalcOnDeduction.Items.Insert(0, "-- Select--");
            DDLCalcOnDeduction.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindPaymentMode4Deductions(DropDownList DDLPayMode4Deduction)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindPaymentMode();
            DDLPayMode4Deduction.DataSource = dt;
            DDLPayMode4Deduction.DataTextField = "PaymentMode";
            DDLPayMode4Deduction.DataValueField = "PaymentModeId";
            DDLPayMode4Deduction.DataBind();
            DDLPayMode4Deduction.Items.Insert(0, "-- Select--");
            DDLPayMode4Deduction.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    #endregion

    #region Bind Grid
    public void BindEmployeeMasterDetails()
    {
        try
        {
            ds4EmployeeMasterDetails = objEmployeeMasterManager.GetEmployeeDetails();
            grdEmployeeMasterDetails.DataSource = ds4EmployeeMasterDetails.Tables[1];
            grdEmployeeMasterDetails.DataBind();
            Session["EmployeeMasterDetails"] = ds4EmployeeMasterDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindAllowances(string EmployeeId)
    {
        try
        {
            ds4EmployeeEarningDetails = objEmployeeMontlyAttendanceMasterManager.GetMontlyErrNDeductions(EmployeeId);
            
            dt4EmployeeEarning = ds4EmployeeEarningDetails.Tables[0];
            if (dt4EmployeeEarning.Rows.Count > 0)
            {
                grdAllowances.DataSource = dt4EmployeeEarning;
                grdAllowances.DataBind();
                Session["EmployeeEarning"] = dt4EmployeeEarning;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    //public void BindDeductions(string EmployeeId)
    //{
    //    try
    //    {
    //        ds4EmployeeDeductionDetails = objEmployeeMontlyAttendanceMasterManager.GetEmployeeMontlyDeductions(EmployeeId);
    //        grdDeduction.DataSource = ds4EmployeeDeductionDetails.Tables[0];
    //        grdDeduction.DataBind();
    //        Session["EmployeeDeduction"] = ds4EmployeeDeductionDetails.Tables[0];
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = "" + ex.Message.ToString();
    //    }
    //}
    #endregion

    #region Grid Events
    //Employee Details
    protected void grdEmployeeMasterDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            LinkButton btnDelete = ((LinkButton)e.Row.FindControl("btnDelete"));
            Image Img4Delete = ((Image)e.Row.FindControl("Img4Delete"));
            Image ImgTick = ((Image)e.Row.FindControl("ImgTick"));
            Label lbl_IsDeleted = ((Label)e.Row.FindControl("lbl_IsDeleted"));
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
        }
    }

    protected void grdEmployeeMasterDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            lblMsg.Text = "";
            int index = Convert.ToInt32(e.CommandArgument);
            Label lbl_EmployeeId = (Label)grdEmployeeMasterDetails.Rows[index].Cells[2].FindControl("lbl_EmployeeId");
            Label lbl_PCardNo = (Label)grdEmployeeMasterDetails.Rows[index].Cells[3].FindControl("lbl_PCardNo");
            Label lbl_EmployeeName = (Label)grdEmployeeMasterDetails.Rows[index].Cells[2].FindControl("lbl_EmployeeName");
            Label lbl_FatherName = (Label)grdEmployeeMasterDetails.Rows[index].Cells[3].FindControl("lbl_FatherName");
            Label lbl_Unit = (Label)grdEmployeeMasterDetails.Rows[index].Cells[4].FindControl("lbl_Unit");
            Label lbl_Department = (Label)grdEmployeeMasterDetails.Rows[index].Cells[5].FindControl("lbl_Department");
            Label lbl_JoiningDates = (Label)grdEmployeeMasterDetails.Rows[index].Cells[5].FindControl("lbl_JoiningDate");

            TabContainer1.ActiveTabIndex = 1;


            txtCode.Text = Convert.ToString(lbl_EmployeeId.Text);
            txtCode.Enabled = false;
            txtName.Text = Convert.ToString(lbl_EmployeeName.Text);
            txtName.Enabled = false;
            txtfhName.Text = Convert.ToString(lbl_FatherName.Text);
            txtfhName.Enabled = false;
            //txtWeeklyOff.Text = "Nill";
            //txtWeeklyOff.Enabled = false;

            txtDateOfJoining.Text = Convert.ToString(lbl_JoiningDates.Text);
            txtDateOfJoining.Enabled = false;

            txtLoanBalance.Text = "0";
            txtLoanBalance.Enabled = false;

            txtSalaryProcessDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtSalaryProcessDate.Enabled = false;

            if (Convert.ToString(txtCode.Text).Trim() != "")
            {
                BindAllowances(Convert.ToString(txtCode.Text).Trim());
                //BindDeductions(Convert.ToString(txtCode.Text).Trim());
            }
            else
            {
                BindAllowances("-1");
                //BindDeductions("-1");
            }
        }
    }

    protected void grdEmployeeMasterDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdEmployeeMasterDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    //Allowances Grid
    protected void grdAllowances_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            Label lbl_Allowance = ((Label)e.Row.FindControl("lbl_Allowance"));
            TextBox txt_Amount = ((TextBox)e.Row.FindControl("txt_Amount"));
            TextBox txt_EarnedAmount = ((TextBox)e.Row.FindControl("txt_EarnedAmount"));

            //Label lbl_Deductions = ((Label)e.Row.FindControl("lbl_Deductions"));
            CheckBox chk_Deductions = ((CheckBox)e.Row.FindControl("chk_Deductions"));
            TextBox txt_Percentage = ((TextBox)e.Row.FindControl("txt_Percentage"));
            TextBox txt_Amount4D = ((TextBox)e.Row.FindControl("txt_Amount4D"));
            TextBox txt_DeductAmount = ((TextBox)e.Row.FindControl("txt_DeductAmount"));

            DataTable Dt4MonthlyEarning = new DataTable();
            Dt4MonthlyEarning = (DataTable)Session["EmployeeMasterDetails"];
            //if (chk_Deductions.Text == "ESI" || chk_Deductions.Text=="EPF")
            //{
            //    chk_Deductions.Checked = true;
            //}

            foreach (DataRow dr in Dt4MonthlyEarning.Rows)
            {
                if (lbl_Allowance.Text != "")
                {
                    lbl_Allowance.Visible = true;
                    txt_Amount.Visible = true;
                    txt_EarnedAmount.Visible = true;
                }
                else
                {
                    lbl_Allowance.Visible = false;
                    txt_Amount.Visible = false;
                    txt_Amount.Text = "0";
                    txt_EarnedAmount.Visible = false;
                    txt_EarnedAmount.Text = "0";
                }

                if (chk_Deductions.Text != "")
                {
                    chk_Deductions.Visible = true;
                    txt_Percentage.Visible = true;
                    txt_Amount4D.Visible = true;
                    txt_DeductAmount.Visible = true;
                }
                else
                {
                    chk_Deductions.Visible = false;
                    txt_Percentage.Visible = false;
                    txt_Percentage.Text = "0";
                    txt_Amount4D.Visible = false;
                    txt_Amount4D.Text = "0";
                    txt_DeductAmount.Visible = false;
                    txt_DeductAmount.Text = "0";
                }
            }

        }
    }

    protected void grdAllowances_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            lblMsg.Text = "";
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            CheckBox chk_Allowance = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[2].FindControl("chk_Allowance");
            TextBox txt_Amount = (TextBox)grdEmployeeMasterDetails.Rows[index].Cells[3].FindControl("txt_Amount");
            DropDownList DDLCalcOn = (DropDownList)grdEmployeeMasterDetails.Rows[index].Cells[4].FindControl("DDLCalcOn");
            DropDownList DDLpayMode = (DropDownList)grdEmployeeMasterDetails.Rows[index].Cells[5].FindControl("DDLpayMode");
            CheckBox chk_Bonus = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[6].FindControl("chk_Bonus");
            CheckBox chk_OT = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[7].FindControl("chk_OT");

            TabContainer1.ActiveTabIndex = 1;

            if (chk_Allowance.Checked == true)
            {
                txt_Amount.Enabled = true;
                DDLCalcOn.Enabled = true;
                DDLpayMode.Enabled = true;
                chk_Bonus.Enabled = true;
                chk_OT.Enabled = true;
            }
            else
            {
                txt_Amount.Enabled = false;
                DDLCalcOn.Enabled = false;
                DDLpayMode.Enabled = false;
                chk_Bonus.Enabled = false;
                chk_OT.Enabled = false;
            }

            ////DataTable dt = new DataTable();
            ////dt = (DataTable)Session["EmployeeMasterDetails"];
            ////if (dt != null)
            ////{
            ////    if (dt.Rows.Count > 0)
            ////    {
            ////        foreach (DataRow dr in dt.Rows)
            ////        {
            ////            if (Convert.ToString(dr["Allowances"]).Trim() == "Gross basic Pay")
            ////            {
            ////                txtgBasicPay.Text = Convert.ToString(dr["Amount"]).Trim();
            ////                Session["Amount"] = Convert.ToString(dr["Amount"]).Trim();
            ////            }
            ////        }
            ////    }
            ////}
        }
    }

    protected void grdAllowances_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdAllowances_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    //Deduction Grid
    //protected void grdDeduction_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        DataRowView drv = ((DataRowView)e.Row.DataItem);
    //        Label lbl_Deductions = ((Label)e.Row.FindControl("lbl_Deductions"));
    //        TextBox txt_Percentage = ((TextBox)e.Row.FindControl("txt_Percentage"));
    //        TextBox txt_Amount4D = ((TextBox)e.Row.FindControl("txt_Amount4D"));
    //        TextBox txt_DeductAmount = ((TextBox)e.Row.FindControl("txt_DeductAmount"));
    //        //DropDownList ddlCalcOn4D = ((DropDownList)e.Row.FindControl("ddlCalcOn4D"));
    //        //DropDownList ddlPayMode4D = ((DropDownList)e.Row.FindControl("ddlPayMode4D"));
    //        //CheckBox chk_Limit = ((CheckBox)e.Row.FindControl("chk_Limit"));
    //        //TextBox txt_LimitAmount = ((TextBox)e.Row.FindControl("txt_LimitAmount"));

    //        //BindPaymentMode4Deductions(ddlPayMode4D);
    //        //BindCalcOnDeductions(ddlCalcOn4D);

    //        //DataTable Dt4MonthlyDeductions = new DataTable();
    //        //Dt4MonthlyDeductions = (DataTable)Session["EmployeeDeduction"];

    //        //foreach (DataRow dr in Dt4MonthlyDeductions.Rows)
    //        //{
    //        //    ddlCalcOn4D.SelectedValue = Convert.ToString(dr["DeductionCalcOn"]);
    //        //    ddlPayMode4D.SelectedValue = Convert.ToString(dr["DeductionPayMode"]);

    //        //    //if (Convert.ToInt32(dr["Bonus"]) == 1)
    //        //    //{
    //        //    //    chk_Bonus.Checked = true;
    //        //    //}
    //        //    //else
    //        //    //{
    //        //    //    chk_Bonus.Checked = false;
    //        //    //}

    //        //    //if (Convert.ToInt32(dr["OT"]) == 1)
    //        //    //{
    //        //    //    chk_OT.Checked = true;
    //        //    //}
    //        //    //else
    //        //    //{
    //        //    //    chk_OT.Checked = false;
    //        //    //}
    //        //}

    //    }
    //}

    //protected void grdDeduction_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "Edit")
    //    {
    //        lblMsg.Text = "";
    //        int index = Convert.ToInt32(e.CommandArgument.ToString());
    //        //CheckBox chk_Allowance = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[2].FindControl("chk_Allowance");
    //        //TextBox txt_Amount = (TextBox)grdEmployeeMasterDetails.Rows[index].Cells[3].FindControl("txt_Amount");
    //        //DropDownList DDLCalcOn = (DropDownList)grdEmployeeMasterDetails.Rows[index].Cells[4].FindControl("DDLCalcOn");
    //        //DropDownList DDLpayMode = (DropDownList)grdEmployeeMasterDetails.Rows[index].Cells[5].FindControl("DDLpayMode");
    //        //CheckBox chk_Bonus = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[6].FindControl("chk_Bonus");
    //        //CheckBox chk_OT = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[7].FindControl("chk_OT");

    //        //TabContainer1.ActiveTabIndex = 1;

    //        //if (chk_Allowance.Checked == true)
    //        //{
    //        //    txt_Amount.Enabled = true;
    //        //    DDLCalcOn.Enabled = true;
    //        //    DDLpayMode.Enabled = true;
    //        //    chk_Bonus.Enabled = true;
    //        //    chk_OT.Enabled = true;
    //        //}
    //        //else
    //        //{
    //        //    txt_Amount.Enabled = false;
    //        //    DDLCalcOn.Enabled = false;
    //        //    DDLpayMode.Enabled = false;
    //        //    chk_Bonus.Enabled = false;
    //        //    chk_OT.Enabled = false;
    //        //}

    //        ////DataTable dt = new DataTable();
    //        ////dt = (DataTable)Session["EmployeeMasterDetails"];
    //        ////if (dt != null)
    //        ////{
    //        ////    if (dt.Rows.Count > 0)
    //        ////    {
    //        ////        foreach (DataRow dr in dt.Rows)
    //        ////        {
    //        ////            if (Convert.ToString(dr["Allowances"]).Trim() == "Gross basic Pay")
    //        ////            {
    //        ////                txtgBasicPay.Text = Convert.ToString(dr["Amount"]).Trim();
    //        ////                Session["Amount"] = Convert.ToString(dr["Amount"]).Trim();
    //        ////            }
    //        ////        }
    //        ////    }
    //        ////}
    //    }
    //}

    //protected void grdDeduction_RowEditing(object sender, GridViewEditEventArgs e)
    //{

    //}

    //protected void grdDeduction_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{

    //}
    #endregion

    #region Other Functions
    public int SalaryCalculationDays(int Month)
    {
        int TotalDays = 0;
        if (Month == 1)
        {
            TotalDays = 31;
        }
        else if (Month == 2)
        {
            TotalDays = 29;
        }
        else if (Month == 3)
        {
            TotalDays = 31;
        }
        else if (Month == 4)
        {
            TotalDays = 30;
        }
        else if (Month == 5)
        {
            TotalDays = 31;
        }
        else if (Month == 6)
        {
            TotalDays = 30;
        }
        else if (Month == 7)
        {
            TotalDays = 31;
        }
        else if (Month == 8)
        {
            TotalDays = 31;
        }
        else if (Month == 9)
        {
            TotalDays = 30;
        }
        else if (Month == 10)
        {
            TotalDays = 31;
        }
        else if (Month == 11)
        {
            TotalDays = 30;
        }
        else if (Month == 12)
        {
            TotalDays = 31;
        }
        return TotalDays;
    }

    public string returnMonthNumber(string monthName)
    {
        string MonthNumber;

        switch (monthName)
        {

            case ("january"):
                MonthNumber = "01";
                return MonthNumber;

            case ("february"):
                MonthNumber = "02";
                return MonthNumber;

            case ("march"):
                MonthNumber = "03";
                return MonthNumber;

            case ("april"):
                MonthNumber = "04";
                return MonthNumber;

            case ("may"):
                MonthNumber = "05";
                return MonthNumber;

            case ("june"):
                MonthNumber = "06";
                return MonthNumber;

            case ("july"):
                MonthNumber = "07";
                return MonthNumber;

            case ("august"):
                MonthNumber = "08";
                return MonthNumber;

            case ("september"):
                MonthNumber = "09";
                return MonthNumber;

            case ("october"):
                MonthNumber = "10";
                return MonthNumber;

            case ("november"):
                MonthNumber = "11";
                return MonthNumber;

            case ("december"):
                MonthNumber = "12";
                return MonthNumber;
            default:
                Console.WriteLine("Error");
                return "ERROR";
        }

    }

    private int DaysBetween(DateTime d1, DateTime d2)
    {
        TimeSpan span = d2.Subtract(d1);
        return (int)span.TotalDays;
    }

    public static DateTime? ToDateTime1(string value)
    {
        string subString = "/";
        if (value == null || value.Trim().Length == 0)
        {
            return null;
        }
        else
        {
            value.Trim();
            int strfirst = value.IndexOf(subString);
            int strSecond = value.LastIndexOf(subString);
            DateTime d = Convert.ToDateTime(value.Substring(strfirst + 1, strSecond - strfirst - 1).Trim() + "-" + value.Substring(0, strfirst).Trim() + "-" + value.Substring(strSecond + 1).Trim());
            return d;

        }
    }
    #endregion

    #region Assigne Value to Controls
    private void AssignVariableToControl(DataTable _dt)
    {
        if (_dt.Rows.Count > 0)
        {
            txtTotalDays.Text = _dt.Rows[0]["TotalDaysinMonth"].ToString();
            txtTotalDays.Enabled = false;
            txtWeeklyOff1.Text = _dt.Rows[0]["NoofWeekOffDays"].ToString();
            //txtWeeklyOff1.Enabled = false;
        }
        else
        {
            txtTotalDays.Text = "";
            txtWeeklyOff1.Text = "";
        }
    }
    #endregion

    #region Selected index Change Event
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        try
        {
            string strMonth = returnMonthNumber(ddlMonth.SelectedItem.Text.ToLower());
            int intMonth = Convert.ToInt32(strMonth);
            int intYear = Convert.ToInt32(DDLYear.SelectedItem.Text);
            string strdate = txtDateOfJoining.Text;
            string[] splitdate = strdate.Split(new char[] { '/' });
            string strMonth2 = splitdate[1].ToString();
            int intMonth2 = Convert.ToInt32(strMonth2);
            string stryear2 = splitdate[2].ToString();
            int intyear2 = Convert.ToInt32(stryear2);
            if (intMonth < intMonth2 && intYear <= intyear2)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please ensure that the Salary Date is greater than to the Date Of Joining";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please ensure that the Salary Date is greater than to the Date Of Joining');</script>", false);
                //DDLYear.Focus();
                //return;
                ddlMonth.SelectedIndex = 0;
                ddlMonth.Focus();
            }
            else
            {
                if (txtCode.Text != "")
                {
                    DataTable _dt = _objReportMasterManager.CalculateSalary_MonthWise(Convert.ToInt32(txtCode.Text), Convert.ToInt32(ddlMonth.SelectedValue)).Tables[0];
                    AssignVariableToControl(_dt);

                    string tmpDateInMonth = txtTotalDays.Text + "/" + intMonth + "/" + intYear;

                    DateTime d1 = Convert.ToDateTime(Pages_Admin_frmSalaryMaster.ToDateTime1(txtDateOfJoining.Text));
                    DateTime d2 = Convert.ToDateTime(Pages_Admin_frmSalaryMaster.ToDateTime1(tmpDateInMonth));
                    txtDaysInMonthAfterJoining.Text = (DaysBetween(d1, d2) + 1).ToString();
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString();
        }
    }

    protected void DDLYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strMonth = returnMonthNumber(ddlMonth.SelectedItem.Text.ToLower());
        int intMonth = Convert.ToInt32(strMonth);
        int intYear = Convert.ToInt32(DDLYear.SelectedItem.Text);
        string strdate = txtDateOfJoining.Text;
        string[] splitdate = strdate.Split(new char[] { '/' });
        string strMonth2 = splitdate[1].ToString();
        int intMonth2 = Convert.ToInt32(strMonth2);
        string stryear2 = splitdate[2].ToString();
        int intyear2 = Convert.ToInt32(stryear2);
        if (intMonth2 >= intMonth && intYear >= intyear2)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Please ensure that the Salary Date is greater than to the Date Of Joining";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please ensure that the Salary Date is greater than to the Date Of Joining');</script>", false);
            //DDLYear.Focus();
            //return;
            ddlMonth.SelectedIndex = 0;
            ddlMonth.Focus();
        }
    }
    #endregion

    #region Text Change Event
    protected void txtOnDuty_TextChanged(object sender, EventArgs e)
    {
        if (txtOnDuty.Text != "")
        {
            txtDayWork.Enabled = false;
            txtDayWork.Text = txtOnDuty.Text;
            txtPaidDays.Text = Convert.ToString(Convert.ToInt32(txtWeeklyOff1.Text) + Convert.ToInt32(txtOnDuty.Text) + Convert.ToInt32(txtOverTime.Text) + Convert.ToInt32(txtHolidays.Text) + Convert.ToInt32(txtRestrictedHolidyas.Text) + Convert.ToInt32(txtEL4Days.Text) + Convert.ToInt32(txtCL4Days.Text) + Convert.ToInt32(txtSL4Days.Text) + Convert.ToInt32(txtMaternity.Text));
            txtArrPaidDays.Text = txtPaidDays.Text;
            txtPfPaidDays.Text = txtPaidDays.Text;
            txtEsiPaidDays.Text = txtPaidDays.Text;
            txtAbsent.Focus();
        }
    }

    protected void txtAbsent_TextChanged(object sender, EventArgs e)
    {
        if (txtAbsent.Text != "")
        {
            txtPaidDays.Text = Convert.ToString(Convert.ToInt32(txtWeeklyOff1.Text) + Convert.ToInt32(txtOnDuty.Text) + Convert.ToInt32(txtOverTime.Text) + Convert.ToInt32(txtHolidays.Text) + Convert.ToInt32(txtRestrictedHolidyas.Text) + Convert.ToInt32(txtEL4Days.Text) + Convert.ToInt32(txtCL4Days.Text) + Convert.ToInt32(txtSL4Days.Text) + Convert.ToInt32(txtMaternity.Text));
            txtArrPaidDays.Text = txtPaidDays.Text;
            txtPfPaidDays.Text = txtPaidDays.Text;
            txtEsiPaidDays.Text = txtPaidDays.Text;
            txtOverTime.Focus();
        }
    }

    protected void txtOverTime_TextChanged(object sender, EventArgs e)
    {
        if (txtOverTime.Text != "")
        {
            txtPaidDays.Text = Convert.ToString(Convert.ToInt32(txtWeeklyOff1.Text) + Convert.ToInt32(txtOnDuty.Text) + Convert.ToInt32(txtOverTime.Text) + Convert.ToInt32(txtHolidays.Text) + Convert.ToInt32(txtRestrictedHolidyas.Text) + Convert.ToInt32(txtEL4Days.Text) + Convert.ToInt32(txtCL4Days.Text) + Convert.ToInt32(txtSL4Days.Text) + Convert.ToInt32(txtMaternity.Text));
            txtArrPaidDays.Text = txtPaidDays.Text;
            txtPfPaidDays.Text = txtPaidDays.Text;
            txtEsiPaidDays.Text = txtPaidDays.Text;
            txtHolidays.Focus();
        }
    }

    protected void txtHolidays_TextChanged(object sender, EventArgs e)
    {
        if (txtHolidays.Text != "")
        {
            txtPaidDays.Text = Convert.ToString(Convert.ToInt32(txtWeeklyOff1.Text) + Convert.ToInt32(txtOnDuty.Text) + Convert.ToInt32(txtOverTime.Text) + Convert.ToInt32(txtHolidays.Text) + Convert.ToInt32(txtRestrictedHolidyas.Text) + Convert.ToInt32(txtEL4Days.Text) + Convert.ToInt32(txtCL4Days.Text) + Convert.ToInt32(txtSL4Days.Text) + Convert.ToInt32(txtMaternity.Text));
            txtArrPaidDays.Text = txtPaidDays.Text;
            txtPfPaidDays.Text = txtPaidDays.Text;
            txtEsiPaidDays.Text = txtPaidDays.Text;
            txtWeeklyOff1.Focus();
        }
    }

    protected void txtWeeklyOff1_TextChanged(object sender, EventArgs e)
    {
        if (txtAbsent.Text != "")
        {
            txtPaidDays.Text = Convert.ToString(Convert.ToInt32(txtWeeklyOff1.Text) + Convert.ToInt32(txtOnDuty.Text) + Convert.ToInt32(txtOverTime.Text) + Convert.ToInt32(txtHolidays.Text) + Convert.ToInt32(txtRestrictedHolidyas.Text) + Convert.ToInt32(txtEL4Days.Text) + Convert.ToInt32(txtCL4Days.Text) + Convert.ToInt32(txtSL4Days.Text) + Convert.ToInt32(txtMaternity.Text));
            txtArrPaidDays.Text = txtPaidDays.Text;
            txtPfPaidDays.Text = txtPaidDays.Text;
            txtEsiPaidDays.Text = txtPaidDays.Text;
            txtEL4Days.Focus();
        }
    }

    protected void txtEL4Days_TextChanged(object sender, EventArgs e)
    {
        if (txtEL4Days.Text != "")
        {
            txtPaidDays.Text = Convert.ToString(Convert.ToInt32(txtWeeklyOff1.Text) + Convert.ToInt32(txtOnDuty.Text) + Convert.ToInt32(txtOverTime.Text) + Convert.ToInt32(txtHolidays.Text) + Convert.ToInt32(txtRestrictedHolidyas.Text) + Convert.ToInt32(txtEL4Days.Text) + Convert.ToInt32(txtCL4Days.Text) + Convert.ToInt32(txtSL4Days.Text) + Convert.ToInt32(txtMaternity.Text));
            txtArrPaidDays.Text = txtPaidDays.Text;
            txtPfPaidDays.Text = txtPaidDays.Text;
            txtEsiPaidDays.Text = txtPaidDays.Text;
            txtCL4Days.Focus();
        }
    }

    protected void txtCL4Days_TextChanged(object sender, EventArgs e)
    {
        if (txtCL4Days.Text != "")
        {
            txtPaidDays.Text = Convert.ToString(Convert.ToInt32(txtWeeklyOff1.Text) + Convert.ToInt32(txtOnDuty.Text) + Convert.ToInt32(txtOverTime.Text) + Convert.ToInt32(txtHolidays.Text) + Convert.ToInt32(txtRestrictedHolidyas.Text) + Convert.ToInt32(txtEL4Days.Text) + Convert.ToInt32(txtCL4Days.Text) + Convert.ToInt32(txtSL4Days.Text) + Convert.ToInt32(txtMaternity.Text));
            txtArrPaidDays.Text = txtPaidDays.Text;
            txtPfPaidDays.Text = txtPaidDays.Text;
            txtEsiPaidDays.Text = txtPaidDays.Text;
            txtSL4Days.Focus();
        }
    }

    protected void txtSL4Days_TextChanged(object sender, EventArgs e)
    {
        if (txtSL4Days.Text != "")
        {
            txtPaidDays.Text = Convert.ToString(Convert.ToInt32(txtWeeklyOff1.Text) + Convert.ToInt32(txtOnDuty.Text) + Convert.ToInt32(txtOverTime.Text) + Convert.ToInt32(txtHolidays.Text) + Convert.ToInt32(txtRestrictedHolidyas.Text) + Convert.ToInt32(txtEL4Days.Text) + Convert.ToInt32(txtCL4Days.Text) + Convert.ToInt32(txtSL4Days.Text) + Convert.ToInt32(txtMaternity.Text));
            txtArrPaidDays.Text = txtPaidDays.Text;
            txtPfPaidDays.Text = txtPaidDays.Text;
            txtEsiPaidDays.Text = txtPaidDays.Text;
            txtL14Days.Focus();
        }
    }

    protected void txtL14Days_TextChanged(object sender, EventArgs e)
    {
        if (txtL14Days.Text != "")
        {
            txtPaidDays.Text = Convert.ToString(Convert.ToInt32(txtWeeklyOff1.Text) + Convert.ToInt32(txtOnDuty.Text) + Convert.ToInt32(txtOverTime.Text) + Convert.ToInt32(txtHolidays.Text) + Convert.ToInt32(txtRestrictedHolidyas.Text) + Convert.ToInt32(txtEL4Days.Text) + Convert.ToInt32(txtCL4Days.Text) + Convert.ToInt32(txtSL4Days.Text) + Convert.ToInt32(txtMaternity.Text));
            txtArrPaidDays.Text = txtPaidDays.Text;
            txtPfPaidDays.Text = txtPaidDays.Text;
            txtEsiPaidDays.Text = txtPaidDays.Text;
            txtL24Days.Focus();
        }
    }

    protected void txtL24Days_TextChanged(object sender, EventArgs e)
    {
        if (txtL24Days.Text != "")
        {
            txtPaidDays.Text = Convert.ToString(Convert.ToInt32(txtWeeklyOff1.Text) + Convert.ToInt32(txtOnDuty.Text) + Convert.ToInt32(txtOverTime.Text) + Convert.ToInt32(txtHolidays.Text) + Convert.ToInt32(txtRestrictedHolidyas.Text) + Convert.ToInt32(txtEL4Days.Text) + Convert.ToInt32(txtCL4Days.Text) + Convert.ToInt32(txtSL4Days.Text) + Convert.ToInt32(txtMaternity.Text));
            txtArrPaidDays.Text = txtPaidDays.Text;
            txtPfPaidDays.Text = txtPaidDays.Text;
            txtEsiPaidDays.Text = txtPaidDays.Text;
            txtL34Days.Focus();
        }
    }

    protected void txtL34Days_TextChanged(object sender, EventArgs e)
    {
        if (txtL34Days.Text != "")
        {
            txtPaidDays.Text = Convert.ToString(Convert.ToInt32(txtWeeklyOff1.Text) + Convert.ToInt32(txtOnDuty.Text) + Convert.ToInt32(txtOverTime.Text) + Convert.ToInt32(txtHolidays.Text) + Convert.ToInt32(txtRestrictedHolidyas.Text) + Convert.ToInt32(txtEL4Days.Text) + Convert.ToInt32(txtCL4Days.Text) + Convert.ToInt32(txtSL4Days.Text) + Convert.ToInt32(txtMaternity.Text));
            txtArrPaidDays.Text = txtPaidDays.Text;
            txtPfPaidDays.Text = txtPaidDays.Text;
            txtEsiPaidDays.Text = txtPaidDays.Text;
            txtRestrictedHolidyas.Focus();
        }
    }

    protected void txtRestrictedHolidyas_TextChanged(object sender, EventArgs e)
    {
        if (txtRestrictedHolidyas.Text != "")
        {
            txtPaidDays.Text = Convert.ToString(Convert.ToInt32(txtWeeklyOff1.Text) + Convert.ToInt32(txtOnDuty.Text) + Convert.ToInt32(txtOverTime.Text) + Convert.ToInt32(txtHolidays.Text) + Convert.ToInt32(txtRestrictedHolidyas.Text) + Convert.ToInt32(txtEL4Days.Text) + Convert.ToInt32(txtCL4Days.Text) + Convert.ToInt32(txtSL4Days.Text) + Convert.ToInt32(txtMaternity.Text));
            txtArrPaidDays.Text = txtPaidDays.Text;
            txtPfPaidDays.Text = txtPaidDays.Text;
            txtEsiPaidDays.Text = txtPaidDays.Text;
            txtMaternity.Focus();
        }
    }

    protected void txtMaternity_TextChanged(object sender, EventArgs e)
    {
        if (txtMaternity.Text != "")
        {
            txtPaidDays.Text = Convert.ToString(Convert.ToInt32(txtWeeklyOff1.Text) + Convert.ToInt32(txtOnDuty.Text) + Convert.ToInt32(txtOverTime.Text) + Convert.ToInt32(txtHolidays.Text) + Convert.ToInt32(txtRestrictedHolidyas.Text) + Convert.ToInt32(txtEL4Days.Text) + Convert.ToInt32(txtCL4Days.Text) + Convert.ToInt32(txtSL4Days.Text) + Convert.ToInt32(txtMaternity.Text));
            txtArrPaidDays.Text = txtPaidDays.Text;
            txtPfPaidDays.Text = txtPaidDays.Text;
            txtEsiPaidDays.Text = txtPaidDays.Text;
        }
    }

    protected void txt_DeductAmount_TextChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow grd in grdAllowances.Rows)
        {
            CheckBox chk_Deductions = (CheckBox)grd.FindControl("chk_Deductions");
            TextBox txt_Percentage = (TextBox)grd.FindControl("txt_Percentage");
            TextBox txt_Amount4D = (TextBox)grd.FindControl("txt_Amount4D");
            TextBox txt_DeductAmount = (TextBox)grd.FindControl("txt_DeductAmount");

            if (chk_Deductions.Checked == true)
            {
                if (txt_Amount4D.Text != "")
                {
                    txt_Amount4D.Text = Convert.ToString(txt_DeductAmount.Text);
                }
                else
                {
                    txt_DeductAmount.Text = "0";
                    txt_Amount4D.Text = Convert.ToString(txt_DeductAmount.Text);
                }
            }
            dt4EmployeeEarning = (DataTable)Session["EmployeeEarning"];
            dt4EmployeeEarning.AcceptChanges();
            Session["EmployeeEarning"] = (DataTable)dt4EmployeeEarning;
        }
    }
    #endregion

    #region Checkbox Change Event
    protected void chk_Deductions_CheckChanged(object sender, EventArgs e)
    {
        int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox chk_Deductions = (CheckBox)grdAllowances.Rows[selRowIndex].FindControl("chk_Deductions");
        TextBox txt_Percentage = (TextBox)grdAllowances.Rows[selRowIndex].FindControl("txt_Percentage");
        TextBox txt_Amount4D = (TextBox)grdAllowances.Rows[selRowIndex].FindControl("txt_Amount4D");
        TextBox txt_DeductAmount = (TextBox)grdAllowances.Rows[selRowIndex].FindControl("txt_DeductAmount");

        if (chk_Deductions.Checked == true)
        {
            txt_DeductAmount.Text = "0";
            txt_DeductAmount.Enabled = true;
        }
        else
        {
            txt_DeductAmount.Text = "0";
            txt_DeductAmount.Enabled = false;
        }

        dt4EmployeeEarning = (DataTable)Session["EmployeeEarning"];
        dt4EmployeeEarning.AcceptChanges();
        Session["EmployeeEarning"] = (DataTable)dt4EmployeeEarning;
    }
    #endregion

    #region Button Click Event
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";

        try
        {
            if (btnSubmit.Text == "Submit")
            {
                EmployeeMontlyAttendance objEmployeeMontlyAttendance = new EmployeeMontlyAttendance();
                setObjectInfor4Attendance(objEmployeeMontlyAttendance);

                foreach (ErrorHandlerClass err in objEmployeeMontlyAttendanceMasterManager.SaveEmployeeMontlyAttendance(objEmployeeMontlyAttendance, SetObjectInfo4Earnings()))
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
                            btnSubmit.Text = "Next Employee";
                            //Response.Redirect("ListOrchardMaster.aspx?OrchardCode=");
                        }
                    }
                    inicontrols();
                }
            }
            else
            {
                btnSubmit.Text = "Submit";
                TabContainer1.TabIndex = 0;
                inicontrols();
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
        inicontrols();
    }

    protected void btnCalculateSalary_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlMonth.SelectedIndex > 0)
            {
                lblMsg.Text = "";
                string strMonth = returnMonthNumber(ddlMonth.SelectedItem.Text.ToLower());
                int intMonth = Convert.ToInt32(strMonth);
                int intYear = Convert.ToInt32(DDLYear.SelectedItem.Text);
                string strdate = txtDateOfJoining.Text;
                string[] splitdate = strdate.Split(new char[] { '/' });
                string strMonth2 = splitdate[1].ToString();
                int intMonth2 = Convert.ToInt32(strMonth2);
                string stryear2 = splitdate[2].ToString();
                int intyear2 = Convert.ToInt32(stryear2);

                if (intMonth2 == intMonth && intYear == intyear2)
                {
                    if (Convert.ToInt32(txtDayWork.Text) <= Convert.ToInt32(txtDaysInMonthAfterJoining.Text))
                    {
                        ProcessSalary();
                        btnSubmit.Enabled = true;
                    }
                    else
                    {
                        lblMsg.Text = "Working Days Can not Exceed than Total Working Days";
                    }
                }
                else
                {
                    ProcessSalary();
                    btnSubmit.Enabled = true;
                    for (int i = 0; i < grdAllowances.Rows.Count; i++)
                    {
                        CheckBox ChkDeduction = (CheckBox)grdAllowances.Rows[i].FindControl("chk_Deductions");
                        TextBox DedPer = (TextBox)grdAllowances.Rows[i].FindControl("txt_Percentage");
                        TextBox Dedduction = (TextBox)grdAllowances.Rows[i].FindControl("txt_Amount4D");

                        if (ChkDeduction.Text == "EPF" || ChkDeduction.Text == "EPF")
                        {
                            ChkDeduction.Checked = true;
                            ChkDeduction.Enabled = false;
                            DedPer.Enabled = false;
                            Dedduction.Enabled = false;

                        }
                    }
                }
            }
            else
            {
                lblMsg.Text = "Please Select Month";
                ddlMonth.Focus();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    #endregion

    #region SetobjectInfo
    public void setObjectInfor4Attendance(EmployeeMontlyAttendance objEmployeeMontlyAttendance)
    {
        objEmployeeMontlyAttendance.EmployeeId = Convert.ToString(txtCode.Text).Trim();
        objEmployeeMontlyAttendance.Month = Convert.ToString(ddlMonth.SelectedValue).Trim();
        objEmployeeMontlyAttendance.Year = Convert.ToString(DDLYear.SelectedValue).Trim();
        objEmployeeMontlyAttendance.SalaryProcessDate = Convert.ToString(txtSalaryProcessDate.Text).Trim();
        objEmployeeMontlyAttendance.TotalMontrhInDays = Convert.ToInt32(txtTotalDays.Text);
        objEmployeeMontlyAttendance.OverTime = Convert.ToInt32(txtOverTime.Text);
        objEmployeeMontlyAttendance.Absent = Convert.ToInt32(txtAbsent.Text);
        objEmployeeMontlyAttendance.Holidays = Convert.ToInt32(txtHolidays.Text);
        objEmployeeMontlyAttendance.Present = Convert.ToInt32(txtOnDuty.Text);
        objEmployeeMontlyAttendance.WeekOff = Convert.ToInt32(txtWeeklyOff1.Text);
        objEmployeeMontlyAttendance.EL = Convert.ToInt32(txtEL4Days.Text);
        objEmployeeMontlyAttendance.CL = Convert.ToInt32(txtCL4Days.Text);
        objEmployeeMontlyAttendance.SL = Convert.ToInt32(txtSL4Days.Text);
        objEmployeeMontlyAttendance.L1 = Convert.ToInt32(txtL14Days.Text);
        objEmployeeMontlyAttendance.L2 = Convert.ToInt32(txtL24Days.Text);
        objEmployeeMontlyAttendance.L3 = Convert.ToInt32(txtL34Days.Text);
        objEmployeeMontlyAttendance.PaidDays = Convert.ToString(txtPaidDays.Text);
        objEmployeeMontlyAttendance.RstHoliDays = Convert.ToInt32(txtRestrictedHolidyas.Text);
        objEmployeeMontlyAttendance.Maternity = Convert.ToInt32(txtMaternity.Text);
        objEmployeeMontlyAttendance.DayWork = Convert.ToInt32(txtDayWork.Text);
        objEmployeeMontlyAttendance.ArrPaidDays = Convert.ToString(txtArrPaidDays.Text);
        objEmployeeMontlyAttendance.PFPaidDays = Convert.ToString(txtPfPaidDays.Text);
        objEmployeeMontlyAttendance.ESIPaidDays = Convert.ToString(txtEsiPaidDays.Text);
        objEmployeeMontlyAttendance.Remarks = Convert.ToString(txtRemark.Text);
        objEmployeeMontlyAttendance.ESILeave = 0;

        objEmployeeMontlyAttendance.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
        objEmployeeMontlyAttendance.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();
    }

    public ICollection<EmployeeMontlyAttendance> SetObjectInfo4Earnings()
    {
        List<EmployeeMontlyAttendance> lst = new List<EmployeeMontlyAttendance>();
        EmployeeMontlyAttendance objEmployeeMontlyAttendance = null;
        //DataTable dtAllowancesCount = (DataTable)Session["EmployeeEarning"];
        int itemNo = 1;
        foreach (GridViewRow grd in grdAllowances.Rows)
        {
            Label lbl_Allowance = (Label)grd.FindControl("lbl_Allowance");
            TextBox txt_Amount = (TextBox)grd.FindControl("txt_Amount");
            TextBox txt_EarnedAmount = (TextBox)grd.FindControl("txt_EarnedAmount");
            CheckBox chk_Deductions = (CheckBox)grd.FindControl("chk_Deductions");
            TextBox txt_Percentage = (TextBox)grd.FindControl("txt_Percentage");
            TextBox txt_Amount4D = (TextBox)grd.FindControl("txt_Amount4D");
            TextBox txt_DeductAmount = (TextBox)grd.FindControl("txt_DeductAmount");

            objEmployeeMontlyAttendance = new EmployeeMontlyAttendance();
            objEmployeeMontlyAttendance.EmployeeId = Convert.ToString(txtCode.Text);
            objEmployeeMontlyAttendance.ItemNo = itemNo;
            objEmployeeMontlyAttendance.Allwances = Convert.ToString(lbl_Allowance.Text);
            objEmployeeMontlyAttendance.AllowanesAmount = Convert.ToDouble(txt_EarnedAmount.Text);
            if (chk_Deductions.Checked == true)
            {
                objEmployeeMontlyAttendance.Deductions = Convert.ToString(chk_Deductions.Text);
                objEmployeeMontlyAttendance.DedPercentage = Convert.ToDouble(txt_Percentage.Text);
                objEmployeeMontlyAttendance.DedAmount = Convert.ToDouble(txt_DeductAmount.Text);
            }

            if (ddlMonth.SelectedIndex > 0)
            {
                objEmployeeMontlyAttendance.Month = Convert.ToString(ddlMonth.SelectedValue).Trim();
            }
            else
            {
                objEmployeeMontlyAttendance.Month = Convert.ToString("-1").Trim();
            }

            if (DDLYear.SelectedIndex > -1)
            {
                objEmployeeMontlyAttendance.Year = Convert.ToString(DDLYear.SelectedValue).Trim();
            }
            else
            {
                objEmployeeMontlyAttendance.Year = Convert.ToString("-1").Trim();
            }
            objEmployeeMontlyAttendance.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
            objEmployeeMontlyAttendance.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();
            lst.Add(objEmployeeMontlyAttendance);
            itemNo = itemNo + 1;
        }

        return lst;
    }
    #endregion

    #region Calculate Salary
    public void ProcessSalary()
    {
        CalcuLateEarningNDeductions();
    }

    public void CalcuLateEarningNDeductions()
    {
        try
        {
            DataTable dt = (DataTable)Session["EmployeeEarning"];
            string AllowanceAmount = "";
            foreach (DataRow dr in dt.Rows)
            {
                //Label lbl_Allowance = (Label)grd.FindControl("lbl_Allowance");
                //TextBox txt_Amount = (TextBox)grd.FindControl("txt_Amount");
                //TextBox txt_EarnedAmount = (TextBox)grd.FindControl("txt_EarnedAmount");

                dr["AllowanesAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["Amount"]) / Convert.ToDouble(txtTotalDays.Text)) * Convert.ToDouble(txtPaidDays.Text))).ToString("F2");

                if (txtOverTime.Text != "")
                {
                    if (Convert.ToDouble(txtOverTime.Text) > 0)
                    {
                        double OverTimeAmount = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["Amount"]) / Convert.ToDouble(txtTotalDays.Text)) * Convert.ToDouble(txtOverTime.Text)));
                        AllowanceAmount = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["AllowanesAmount"]) - OverTimeAmount))).ToString("F2");
                    }
                }

                if (Convert.ToInt32(dr["DeductionLimit"]) != 1)
                {
                    //dr["DedAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["DeductionAmount"]) / Convert.ToDouble(txtTotalDays.Text)) * Convert.ToDouble(txtPaidDays.Text))).ToString("F2");
                    if (Convert.ToString(dr["Deductions"]) != "ESI")
                    {
                        dr["DedAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["AllowanesAmount"]) * Convert.ToDouble(dr["DedPercentage"])) / 100)).ToString("F2");
                    }
                    else
                    {
                        if (GetBasicPay() > 15000)
                        {
                            //dr["DedAmount"] = Convert.ToDouble(Math.Round(Convert.ToDouble((GetBasicPay()/Convert.ToDouble(txtTotalDays.Text)) * Convert.ToDouble(dr["DedPercentage"])) / 100) / ) * Convert.ToDouble(txtPaidDays.Text)).ToString("F2");
                            dr["DedAmount"] = Convert.ToDouble(0).ToString("F2");
                        }
                        else
                        {
                            //dr["DedAmount"] = Convert.ToDouble(Math.Ceiling(Math.Round(Convert.ToDouble(Convert.ToDouble((GetBasicPay() / Convert.ToDouble(txtTotalDays.Text)) * Convert.ToDouble(txtPaidDays.Text)) * Convert.ToDouble(dr["DedPercentage"])) / 100))).ToString("F2");
                            dr["DedAmount"] = Math.Ceiling(Convert.ToDouble(GetBasicPay() * Convert.ToDouble(dr["DedPercentage"]))/100).ToString("F2");
                        }
                    }
                }
                else
                {
                    if (Convert.ToDouble(txtOverTime.Text) > 0)
                    {
                        if (Convert.ToDouble(AllowanceAmount) >= 6500)
                        {
                            dr["DedAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["DeductionAmount"])))).ToString("F2");
                        }
                        else
                        {
                            //dr["DedAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["DeductionAmount"]) / Convert.ToDouble(txtTotalDays.Text)) * Convert.ToDouble(txtPaidDays.Text))).ToString("F2");
                            dr["DedAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(AllowanceAmount) * Convert.ToDouble(dr["DedPercentage"])) / 100)).ToString("F2");
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(dr["AllowanesAmount"]) >= 6500)
                        {
                            dr["DedAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["DeductionAmount"])))).ToString("F2");
                        }
                        else
                        {
                            //dr["DedAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["DeductionAmount"]) / Convert.ToDouble(txtTotalDays.Text)) * Convert.ToDouble(txtPaidDays.Text))).ToString("F2");
                            dr["DedAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["AllowanesAmount"]) * Convert.ToDouble(dr["DedPercentage"])) / 100)).ToString("F2");
                        }
                    }
                }
            }
            dt.AcceptChanges();
            Session["EmployeeEarning"] = dt;
            grdAllowances.DataSource = dt;
            grdAllowances.DataBind();
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString();
        }
    }

    public void CalculateDeductions()
    {
        //try
        //{
        //    DataTable dt = (DataTable)Session["EmployeeDeduction"];
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        //Label lbl_Deductions = (Label)grd.FindControl("lbl_Deductions");
        //        //TextBox txt_Percentage = (TextBox)grd.FindControl("txt_Percentage");
        //        //TextBox txt_Amount4D = (TextBox)grd.FindControl("txt_Amount4D");
        //        //TextBox txt_DeductAmount = (TextBox)grd.FindControl("txt_DeductAmount");

        //        dr["DedAmount"] = Convert.ToDouble((Convert.ToDouble(dr["DeductionAmount"]) / Convert.ToDouble(txtTotalDays.Text)) * Convert.ToDouble(txtPaidDays.Text)).ToString("F2");
        //    }
        //    dt.AcceptChanges();
        //    Session["EmployeeDeduction"] = dt;
        //    grdDeduction.DataSource = dt;
        //    grdDeduction.DataBind();
        //}
        //catch (Exception ex)
        //{
        //    lblMsg.Text = "" + ex.ToString();
        //}
    }

    public double GetBasicPay()
    {
        DataTable dt = (DataTable)Session["EmployeeEarning"];
        double GrossBasicPay = 0.0;
        try
        {
            foreach (DataRow dr in dt.Rows)
            {
                //CheckBox chk_Allowance = (CheckBox)grd.FindControl("chk_Allowance");
                //TextBox txt_Amount = (TextBox)grd.FindControl("txt_Amount");
                if (Convert.ToString(dr["Allowances"]).Trim() != "" && Convert.ToString(dr["Allowances"]).Trim() !="MEDICAL")
                {
                    GrossBasicPay = Math.Round(GrossBasicPay + Convert.ToDouble(dr["AllowanesAmount"]));
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString(); ;
        }
        return GrossBasicPay;
    }
    #endregion

}