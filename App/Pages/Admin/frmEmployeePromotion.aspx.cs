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

public partial class Pages_Admin_frmEmployeePromotion : System.Web.UI.Page
{
    EmployeePromotionDetailsManager objEmployeePromotionDetailsManager = new EmployeePromotionDetailsManager();
    EmployeeEarningDetailsManager objEmployeeEarningDetailsManager = new EmployeeEarningDetailsManager();
    EmployeeDeductionDetailsManager objEmployeeDeductionDetailsManager = new EmployeeDeductionDetailsManager();
    EmployeeLeaveDetailsManager objEmployeeLeaveDetailsManager = new EmployeeLeaveDetailsManager();

    PromotionEarningDetailsManager objPromotionEarningDetailsManager = new PromotionEarningDetailsManager();
    PromotionDeductionDetailsManager objPromotionDeductionDetailsManager = new PromotionDeductionDetailsManager();
    PromotionLeaveDetailsManager objPromotionLeaveDetailsManager = new PromotionLeaveDetailsManager();

    EmployeeMasterDetailsManager objEmployeeMasterManager = new EmployeeMasterDetailsManager();
    BindComboMasterManager objBindComboMasterManager = new BindComboMasterManager();
    DataSet ds4EmployeeEarningDetails = new DataSet();
    DataTable dt4EmployeeEarning = new DataTable();

    DataSet ds4EmployeeDeductionDetails = new DataSet();
    DataTable dt4EmployeeDeduction = new DataTable();

    DataSet ds4PromotionLeaveDetails = new DataSet();
    DataTable dt4PromotionLeaveDetails = new DataTable();

    DataSet ds4AllowancesDetails = new DataSet();
    DataTable dt4Allowances = new DataTable();

    DataSet ds4DeductionsDetails = new DataSet();
    DataTable dt4Deductions = new DataTable();

    DataSet ds4LeaveTypeDetails = new DataSet();
    DataTable dt4Leave = new DataTable();

    DataSet ds4ClassDetails = new DataSet();
    DataTable dt4Class = new DataTable();

    DataSet ds4PopulateEmployeeDetails = new DataSet();
    DataTable dt4PopulateDetails = new DataTable();

    DataSet ds4PopulateEmployeeEarningDetails = new DataSet();
    DataTable dt4PopulateEarningDetails = new DataTable();

    DataSet ds4PopulateEmployeeDeductionDetails = new DataSet();
    DataTable dt4PopulateDeductionDetails = new DataTable();

    string EmployeeId = "";
    public static int ItemNo4Earning = 0;
    public static int ItemNo4Deduction = 0;
    public static int ItemNo4Leave = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblMsg.Text = "";
            iniControls();

            BindEmployeeId();
            BindDepartment();
            BindDesignation();
            BindNewDepartment();
            BindNewDesignation();
            BindEmployeeType();

            BindEarningLeaveAllowedAfter();
            BindCasualLeaveAllowedAfter();
        }
    }

    #region iniControls
    public void iniControls()
    {
        DDLEmployeeId.SelectedIndex = 0;
        txtFirstName.Text = "";
        txtMiddleName.Text = "";
        txtLastName.Text = "";
        txtFatherName.Text = "";
        DDLDesignation.SelectedIndex = 0;
        txtUnit.Text = "";
        txtSubUnit.Text = "";
        DDLDepartment.SelectedIndex = 0;
        txtEsiNo.Text = "";
        ItemNo4Earning = 0;
        ItemNo4Deduction = 0;
        ItemNo4Leave = 0;
        iniControls4First();
        iniControls4Second();
        iniControls4Third();
        iniControls4Fourth();
        //Session["EmployeeEarning"] = null;
        //Session["EmployeeDeduction"] = null;
        //Session["EmployeeLeave"] = null;
        //Session["Allowances"] = null;
        //Session["Deductions"] = null;
        //Session["LeaveType"] = null;

        BindAllowances();
        BindDeductions();
        BindLeaveType();
    }

    public void iniControls4First()
    {
        txtPromotionDate.Text = "";
        DDLNewDept.SelectedIndex = 0;
        DDlNewDesignation.SelectedIndex = 0;
    }

    public void iniControls4Second()
    {
        foreach (GridViewRow grd in grdEmployeeMasterDetails.Rows)
        {
            CheckBox chk_Allowance = (CheckBox)grd.FindControl("chk_Allowance");
            TextBox txt_Amount = (TextBox)grd.FindControl("txt_Amount");
            DropDownList ddlCalcOn = (DropDownList)grd.FindControl("ddlCalcOn");
            DropDownList ddlPayMode = (DropDownList)grd.FindControl("ddlPayMode");
            CheckBox chk_Bonus = (CheckBox)grd.FindControl("chk_Bonus");
            CheckBox chk_OT = (CheckBox)grd.FindControl("chk_OT");

            chk_Allowance.Checked = false;
            txt_Amount.Text = "";
            txt_Amount.Enabled = false;
            ddlCalcOn.SelectedIndex = 1;
            ddlCalcOn.Enabled = false;
            ddlPayMode.SelectedIndex = 0;
            ddlPayMode.Enabled = false;
            chk_Bonus.Checked = false;
            chk_Bonus.Enabled = false;
            chk_OT.Checked = false;
            chk_OT.Enabled = false;
        }
    }

    public void iniControls4Third()
    {
        foreach (GridViewRow grd in grdDeduction.Rows)
        {
            CheckBox chk_Deductions = (CheckBox)grd.FindControl("chk_Deductions");
            TextBox txt_Percentage = (TextBox)grd.FindControl("txt_Percentage");
            TextBox txt_Amount4D = (TextBox)grd.FindControl("txt_Amount4D");
            DropDownList ddlCalcOn4D = (DropDownList)grd.FindControl("ddlCalcOn4D");
            DropDownList ddlPayMode4D = (DropDownList)grd.FindControl("ddlPayMode4D");
            CheckBox chk_NewLimit = (CheckBox)grd.FindControl("chk_NewLimit");
            TextBox txt_NewLimitAmount = (TextBox)grd.FindControl("txt_NewLimitAmount");
            CheckBox chk_OldLimit = (CheckBox)grd.FindControl("chk_OldLimit");
            TextBox txt_OldLimitAmount = (TextBox)grd.FindControl("txt_OldLimitAmount");

            chk_Deductions.Checked = false;
            txt_Percentage.Text = "";
            txt_Amount4D.Text = "";
            txt_Amount4D.Enabled = false;
            ddlCalcOn4D.SelectedIndex = 1;
            ddlCalcOn4D.Enabled = false;
            ddlPayMode4D.SelectedIndex = 0;
            ddlPayMode4D.Enabled = false;
            chk_NewLimit.Checked = false;
            chk_NewLimit.Enabled = false;
            txt_NewLimitAmount.Text = "";
            txt_NewLimitAmount.Visible = false;

            chk_OldLimit.Checked = false;
            chk_OldLimit.Enabled = false;
            txt_OldLimitAmount.Text = "";
            txt_OldLimitAmount.Visible = false;
        }
    }

    public void iniControls4Fourth()
    {
        foreach (GridViewRow grd in grdLeave.Rows)
        {
            CheckBox chk_LeaveTypeId = (CheckBox)grd.FindControl("chk_LeaveTypeId");
            TextBox txt_Opening = (TextBox)grd.FindControl("txt_Opening");
            TextBox txt_NewOpening = (TextBox)grd.FindControl("txt_NewOpening");
            RadioButtonList rbtn_MonthlyEarnedType = (RadioButtonList)grd.FindControl("rbtn_MonthlyEarnedType");
            TextBox txt_MonthlyEarned = (TextBox)grd.FindControl("txt_MonthlyEarned");

            chk_LeaveTypeId.Checked = false;
            txt_Opening.Text = "";
            txt_Opening.Enabled = false;
            txt_NewOpening.Text = "";
            txt_NewOpening.Enabled = false;
            rbtn_MonthlyEarnedType.SelectedIndex = 1;
            rbtn_MonthlyEarnedType.Enabled = false;
            txt_MonthlyEarned.Text = "";
            txt_MonthlyEarned.Visible = false;
        }

        txtEarningLeaveAllowdAfter.Text = "";
        DDLEarningLeaveAllowed.SelectedIndex = 0;
        chkOnlyLastYearConsumed.Checked = false;
        txtCasualLeaveAllowedAfter.Text = "";
        DDLCasualLeaveAllowedAfter.SelectedIndex = 0;
        chkCLConsumedinCurrentYear.Checked = false;

        txtEarningLeaveAllowdAfter.Enabled = false;
        DDLEarningLeaveAllowed.Enabled = false;
        chkOnlyLastYearConsumed.Enabled = false;
        txtCasualLeaveAllowedAfter.Enabled = false;
        DDLCasualLeaveAllowedAfter.Enabled = false;
        chkCLConsumedinCurrentYear.Enabled = false;

        txtItemNo4Leave.Text = "";
        txtItemNo4Leave.Text = Convert.ToString(GetItemNo4Leave());
    }
    #endregion

    #region Bind Combo Box for Employee Details
    public void BindEmployeeId()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindEmployeeId();
            DDLEmployeeId.DataSource = dt;
            DDLEmployeeId.DataTextField = "EmployeeName";
            DDLEmployeeId.DataValueField = "EmployeeId";
            DDLEmployeeId.DataBind();
            DDLEmployeeId.Items.Insert(0, "-- Select--");
            DDLEmployeeId.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindDepartment()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindDepartment();
            DDLDepartment.DataSource = dt;
            DDLDepartment.DataTextField = "Department";
            DDLDepartment.DataValueField = "DepartmentId";
            DDLDepartment.DataBind();
            DDLDepartment.Items.Insert(0, "-- Select--");
            DDLDepartment.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindDesignation()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindDesignation();
            DDLDesignation.DataSource = dt;
            DDLDesignation.DataTextField = "Designation";
            DDLDesignation.DataValueField = "DesignationId";
            DDLDesignation.DataBind();
            DDLDesignation.Items.Insert(0, "-- Select--");
            DDLDesignation.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindNewDepartment()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindDepartment();
            DDLNewDept.DataSource = dt;
            DDLNewDept.DataTextField = "Department";
            DDLNewDept.DataValueField = "DepartmentId";
            DDLNewDept.DataBind();
            DDLNewDept.Items.Insert(0, "-- Select--");
            DDLNewDept.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindNewDesignation()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindDesignation();
            DDlNewDesignation.DataSource = dt;
            DDlNewDesignation.DataTextField = "Designation";
            DDlNewDesignation.DataValueField = "DesignationId";
            DDlNewDesignation.DataBind();
            DDlNewDesignation.Items.Insert(0, "-- Select--");
            DDlNewDesignation.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindEmployeeType()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindEmployeeType();
            DDlEmployeeType.DataSource = dt;
            DDlEmployeeType.DataTextField = "EmployeeType";
            DDlEmployeeType.DataValueField = "EmployeeTypeId";
            DDlEmployeeType.DataBind();
            DDlEmployeeType.Items.Insert(0, "-- Select--");
            DDlEmployeeType.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
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

    #region Bind Combo Box 4 Leave
    public void BindEarningLeaveAllowedAfter()
    {
        DDLEarningLeaveAllowed.Items.Add(new ListItem("Days", "D"));
        DDLEarningLeaveAllowed.Items.Add(new ListItem("Month", "M"));
    }

    public void BindCasualLeaveAllowedAfter()
    {
        DDLCasualLeaveAllowedAfter.Items.Add(new ListItem("Days", "D"));
        DDLCasualLeaveAllowedAfter.Items.Add(new ListItem("Month", "M"));
    }
    #endregion

    #region Bind Grid Functions
    public void BindAllowances()
    {
        try
        {
            ds4AllowancesDetails = objEmployeeMasterManager.GetAllowances();
            grdEmployeeMasterDetails.DataSource = ds4AllowancesDetails.Tables[0];
            grdEmployeeMasterDetails.DataBind();
            Session["EmployeeEarning"] = ds4AllowancesDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindDeductions()
    {
        try
        {
            ds4DeductionsDetails = objEmployeeMasterManager.GetDeductions();
            grdDeduction.DataSource = ds4DeductionsDetails.Tables[0];
            grdDeduction.DataBind();
            Session["EmployeeDeduction"] = ds4DeductionsDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindLeaveType()
    {
        try
        {
            ds4LeaveTypeDetails = objEmployeeMasterManager.GetLeaveType();
            grdLeave.DataSource = ds4LeaveTypeDetails.Tables[0];
            grdLeave.DataBind();
            Session["EmployeeLeave"] = ds4LeaveTypeDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    #endregion

    #region Populate EmployeeDetails
    public void PopulateEmployeeDetails(string strEmployeeId)
    {
        try
        {
            ds4PopulateEmployeeDetails = objEmployeeMasterManager.GetEmployeeMaster4ID(strEmployeeId);

            if (ds4PopulateEmployeeDetails != null)
            {
                BindEmployeeType();

                if (Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["EmployeeTypeId"]).Trim() != "")
                {
                    DDlEmployeeType.SelectedValue = Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["EmployeeTypeId"]).Trim();
                    DDlEmployeeType.Enabled = false;
                }
                else
                {
                    DDlEmployeeType.SelectedIndex = 0;
                    DDlEmployeeType.Enabled = true;
                }

                if (Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["FirstName"]).Trim() != "")
                {
                    txtFirstName.Text = Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["FirstName"]).Trim();
                    txtFirstName.Enabled = false;
                }
                else
                {
                    txtFirstName.Text = "";
                    txtFirstName.Enabled = true;
                }

                if (Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["MiddleName"]).Trim() != "")
                {
                    txtMiddleName.Text = Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["MiddleName"]).Trim();
                    txtMiddleName.Enabled = false;
                }
                else
                {
                    txtMiddleName.Text = "";
                    txtMiddleName.Enabled = true;
                }

                if (Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["LastName"]).Trim() != "")
                {
                    txtLastName.Text = Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["LastName"]).Trim();
                    txtLastName.Enabled = false;
                }
                else
                {
                    txtLastName.Text = "";
                    txtLastName.Enabled = true;
                }

                if (Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["FatherName"]).Trim() != "")
                {
                    txtFatherName.Text = Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["FatherName"]).Trim();
                    txtFatherName.Enabled = false;
                }
                else
                {
                    txtFatherName.Text = "";
                    txtFatherName.Enabled = true;
                }

                BindDepartment();
                if (Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["Department"]).Trim() != "")
                {
                    DDLDepartment.SelectedValue = Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["Department"]).Trim();
                    DDLDepartment.Enabled = false;
                }
                else
                {
                    DDLDepartment.SelectedIndex = 0;
                    DDLDepartment.Enabled = true;
                }

                BindDesignation();
                if (Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["Designation"]).Trim() != "")
                {
                    DDLDesignation.SelectedValue = Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["Designation"]).Trim();
                    DDLDesignation.Enabled = false;
                }
                else
                {
                    DDLDesignation.SelectedIndex = 0;
                    DDLDesignation.Enabled = true;
                }

                if (Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["Unit"]).Trim() != "")
                {
                    txtUnit.Text = Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["Unit"]).Trim();
                    txtUnit.Enabled = false;
                }
                else
                {
                    txtUnit.Text = "";
                    txtUnit.Enabled = true;
                }

                if (Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["SubUnit"]).Trim() != "")
                {
                    txtSubUnit.Text = Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["SubUnit"]).Trim();
                    txtSubUnit.Enabled = false;
                }
                else
                {
                    txtSubUnit.Text = "";
                    txtSubUnit.Enabled = true;
                }

                if (Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["PFNo"]).Trim() != "")
                {
                    txtPFNo.Text = Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["PFNo"]).Trim();
                    txtPFNo.Enabled = false;
                }
                else
                {
                    txtPFNo.Text = "";
                    txtPFNo.Enabled = true;
                }

                if (Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["ESINo"]).Trim() != "")
                {
                    txtEsiNo.Text = Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["ESINo"]).Trim();
                    txtEsiNo.Enabled = false;
                }
                else
                {
                    txtEsiNo.Text = "";
                    txtEsiNo.Enabled = true;
                }

                if (Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["JoiningDate"]).Trim() != "")
                {
                    txtJoningDate.Text = Convert.ToString(ds4PopulateEmployeeDetails.Tables[0].Rows[0]["JoiningDate"]).Trim();
                    txtJoningDate.Enabled = false;
                }
                else
                {
                    txtJoningDate.Text = "";
                    txtJoningDate.Enabled = true;
                }

                PopulateEmployeeEarningDetails(strEmployeeId);
                PopulateEmployeeDeductionDetails(strEmployeeId);
                PopulateEmployeeLeaveDetails(strEmployeeId);
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void PopulateEmployeeEarningDetails(string strEmployeeId)
    {
        try
        {
            ds4PopulateEmployeeEarningDetails = objEmployeeEarningDetailsManager.GetEmployeeEarningDetails4ID(strEmployeeId);

            foreach (GridViewRow row in grdEmployeeMasterDetails.Rows)
            {
                CheckBox chk_Allowance = (CheckBox)row.FindControl("chk_Allowance");
                TextBox txt_Amount = (TextBox)row.FindControl("txt_Amount");
                TextBox txt_NewAmount = (TextBox)row.FindControl("txt_NewAmount");
                TextBox txt_ItemNo = (TextBox)row.FindControl("txt_ItemNo");
                DropDownList ddlCalcOn = (DropDownList)row.FindControl("ddlCalcOn");
                DropDownList ddlPayMode = (DropDownList)row.FindControl("ddlPayMode");
                CheckBox chk_Bonus = (CheckBox)row.FindControl("chk_Bonus");
                CheckBox chk_OT = (CheckBox)row.FindControl("chk_OT");

                foreach (DataRow dr in ds4PopulateEmployeeEarningDetails.Tables[0].Rows)
                {
                    if (Convert.ToString(chk_Allowance.Text).Trim() == Convert.ToString(dr["Allowances"]).Trim())
                    {
                        chk_Allowance.Checked = true;

                        if (chk_Allowance.Checked == true)
                        {
                            txt_Amount.Text = Convert.ToString(dr["Amount"]);
                            txt_ItemNo.Text = Convert.ToString(dr["ItemNo"]);
                            ddlCalcOn.SelectedValue = Convert.ToString(dr["CalcOn"]);
                            ddlPayMode.SelectedValue = Convert.ToString(dr["PaymentMode"]);

                            if (Convert.ToInt32(dr["Bonus"]) == 1)
                            {
                                chk_Bonus.Checked = true;
                            }
                            else
                            {
                                chk_Bonus.Checked = false;
                            }

                            if (Convert.ToInt32(dr["OT"]) == 1)
                            {
                                chk_OT.Checked = true;
                            }
                            else
                            {
                                chk_OT.Checked = false;
                            }
                            if (Convert.ToString(txt_Amount.Text) == "")
                            {
                                txt_Amount.Text = "0";
                            }

                            txt_NewAmount.Text = "0";
                            txt_NewAmount.Enabled = true;
                            ddlCalcOn.Enabled = true;
                            ddlPayMode.Enabled = true;

                            if (ddlPayMode.SelectedIndex == 0)
                            {
                                ddlPayMode.SelectedIndex = 0;
                            }
                            chk_Bonus.Enabled = true;
                            chk_OT.Enabled = true;
                        }
                        else
                        {
                            txt_NewAmount.Text = "";
                            txt_NewAmount.Enabled = false;
                            ddlCalcOn.Enabled = false;
                            ddlPayMode.Enabled = false;
                            ddlPayMode.SelectedIndex = 0;
                            chk_Bonus.Enabled = false;
                            chk_OT.Enabled = false;
                        }
                    }
                }

            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void PopulateEmployeeDeductionDetails(string strEmployeeId)
    {
        try
        {
            ds4PopulateEmployeeDeductionDetails = objEmployeeDeductionDetailsManager.GetEmployeeDeductionDetails4ID(strEmployeeId);

            foreach (GridViewRow row in grdDeduction.Rows)
            {
                CheckBox chk_Deductions = (CheckBox)row.FindControl("chk_Deductions");
                TextBox txt_Percentage = (TextBox)row.FindControl("txt_Percentage");
                TextBox txt_Amount4D = (TextBox)row.FindControl("txt_Amount4D");
                TextBox txt_ItemNo = (TextBox)row.FindControl("txt_ItemNo");
                TextBox txt_NewAmount4D = (TextBox)row.FindControl("txt_NewAmount4D");
                TextBox txt_ItemNo4D = (TextBox)row.FindControl("txt_ItemNo4D");
                DropDownList ddlCalcOn4D = (DropDownList)row.FindControl("ddlCalcOn4D");
                DropDownList ddlPayMode4D = (DropDownList)row.FindControl("ddlPayMode4D");
                CheckBox chk_OldLimit = (CheckBox)row.FindControl("chk_OldLimit");
                TextBox txt_OldLimitAmount = (TextBox)row.FindControl("txt_OldLimitAmount");
                CheckBox chk_NewLimit = (CheckBox)row.FindControl("chk_NewLimit");
                TextBox txt_NewLimitAmount = (TextBox)row.FindControl("txt_NewLimitAmount");

                foreach (DataRow dr1 in ds4PopulateEmployeeDeductionDetails.Tables[0].Rows)
                {
                    if (Convert.ToString(chk_Deductions.Text).Trim() == Convert.ToString(dr1["Deductions"]).Trim())
                    {
                        chk_Deductions.Checked = true;

                        if (chk_Deductions.Checked == true)
                        {
                            txt_Amount4D.Text = Convert.ToString(dr1["DeductionAmount"]);
                            txt_ItemNo.Text = Convert.ToString(dr1["ItemNo"]);
                            ddlCalcOn4D.SelectedValue = Convert.ToString(dr1["DeductionCalcOn"]);
                            ddlPayMode4D.SelectedValue = Convert.ToString(dr1["DeductionPayMode"]);

                            if (Convert.ToInt32(dr1["DeductionLimit"]) == 1)
                            {
                                chk_OldLimit.Checked = true;
                                txt_OldLimitAmount.Text = Convert.ToString(Convert.ToString(dr1["LimitAmount"]));
                            }
                            else
                            {
                                chk_OldLimit.Checked = false;
                                txt_OldLimitAmount.Text = "";
                            }
                            if (Convert.ToString(txt_Amount4D.Text) == "")
                            {
                                txt_Amount4D.Text = "0";
                            }

                            if (chk_Deductions.Text == "EPF" || chk_Deductions.Text == "ESI")
                            {
                                txt_NewAmount4D.Enabled = false;
                            }
                            else
                            {
                                txt_NewAmount4D.Enabled = true;
                            }

                            if (chk_Deductions.Text == "ESI")
                            {
                                chk_NewLimit.Enabled = false;
                                if (GetBasicPay() >= 15000)
                                {
                                    txt_NewAmount4D.Text = "0.0000";
                                }
                                else
                                {
                                    //txt_Amount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
                                    txt_NewAmount4D.Text = Convert.ToString(CalculateESIDeductions(Convert.ToDouble(txt_Percentage.Text)));
                                }
                            }
                            else
                            {
                                txt_NewAmount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
                                chk_NewLimit.Enabled = true;
                            }

                            ddlCalcOn4D.Enabled = true;
                            ddlPayMode4D.Enabled = true;
                            if (ddlPayMode4D.SelectedIndex == 0)
                            {
                                ddlPayMode4D.SelectedIndex = 0;
                            }
                            //chk_Limit.Enabled = true;
                            txt_NewLimitAmount.Enabled = true;
                        }
                        else
                        {
                            ddlCalcOn4D.Enabled = false;
                            ddlPayMode4D.Enabled = false;
                            ddlPayMode4D.SelectedIndex = 0;
                            txt_NewAmount4D.Enabled = false;
                            chk_NewLimit.Enabled = false;
                            txt_NewLimitAmount.Enabled = false;
                            txt_NewAmount4D.Text = "";
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void PopulateEmployeeLeaveDetails(string strEmployeeId)
    {
        try
        {
            ds4PopulateEmployeeDeductionDetails = objEmployeeLeaveDetailsManager.GetEmployeeLeaveDetails4ID(strEmployeeId);

            foreach (GridViewRow row in grdLeave.Rows)
            {
                CheckBox chk_LeaveTypeId = (CheckBox)row.FindControl("chk_LeaveTypeId");
                TextBox txt_Opening = (TextBox)row.FindControl("txt_Opening");
                TextBox txt_ItemNo = (TextBox)row.FindControl("txt_ItemNo");
                TextBox txt_MonthlyEarned = (TextBox)row.FindControl("txt_MonthlyEarned");
                RadioButtonList rbtn_MonthlyEarnedType = (RadioButtonList)row.FindControl("rbtn_MonthlyEarnedType");

                foreach (DataRow dr1 in ds4PopulateEmployeeDeductionDetails.Tables[0].Rows)
                {
                    if (Convert.ToString(chk_LeaveTypeId.Text).Trim() == Convert.ToString(dr1["LeaveType"]).Trim())
                    {
                        chk_LeaveTypeId.Checked = true;
                        if (chk_LeaveTypeId.Checked == true)
                        {
                            txt_Opening.Text = Convert.ToString(dr1["Opening"]);
                            txt_ItemNo.Text = Convert.ToString(dr1["ItemNo"]);
                            rbtn_MonthlyEarnedType.SelectedValue = Convert.ToString(dr1["MonthlyEarnedType"]);
                            rbtn_MonthlyEarnedType.Enabled = true;
                            txt_MonthlyEarned.Enabled = true;
                        }
                        else
                        {
                            rbtn_MonthlyEarnedType.Enabled = false;
                            txt_MonthlyEarned.Enabled = false;
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    #endregion

    #region Buton Click Event
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        if (CheckValidation() == true)
        {
            EmployeePromotionDetails objEmployeePromotionDetails = new EmployeePromotionDetails();
            PromotionLeaveDetails objPromotionLeaveDetails = new PromotionLeaveDetails();

            try
            {
                setObjectInfor4Employee(objEmployeePromotionDetails);

                foreach (ErrorHandlerClass err in objEmployeePromotionDetailsManager.SaveEmployeePromotionMaster(objEmployeePromotionDetails, SetObjectInfo4Earnings(), SetObjectInfo4Deductions(), SetObjectInfo4Leaves()))
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
                            //Response.Redirect("ListOrchardMaster.aspx?OrchardCode=");
                        }
                    }
                    iniControls();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "" + ex.Message.ToString();
                //objErrorLog.WriteErrorLog(ex.ToString());
            }
        }
        else
        {
            DDlEmployeeType.Focus();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        iniControls();
        //Response.Redirect("ListOrchardMaster.aspx");
    }
    #endregion

    #region SetObjectInfo
    public void setObjectInfor4Employee(EmployeePromotionDetails objEmployeePromotionDetails)
    {
        if (DDLEmployeeId.SelectedIndex > 0)
        {

            objEmployeePromotionDetails.EmployeeId = Convert.ToString(DDLEmployeeId.SelectedValue).Trim();

            if (DDLDepartment.SelectedIndex > 0)
            {
                objEmployeePromotionDetails.CurrentDept = Convert.ToString(DDLDepartment.SelectedValue).Trim();
            }
            else
            {
                objEmployeePromotionDetails.CurrentDept = "";
            }

            if (DDLDesignation.SelectedIndex > 0)
            {
                objEmployeePromotionDetails.CurrentDesig = Convert.ToString(DDLDesignation.SelectedValue).Trim();
            }
            else
            {
                objEmployeePromotionDetails.CurrentDesig = "";
            }

            if (DDLNewDept.SelectedIndex > 0)
            {
                objEmployeePromotionDetails.NewDept = Convert.ToString(DDLNewDept.SelectedValue).Trim();
            }
            else
            {
                objEmployeePromotionDetails.NewDept = "";
            }

            if (DDlNewDesignation.SelectedIndex > 0)
            {
                objEmployeePromotionDetails.NewDesig = Convert.ToString(DDlNewDesignation.SelectedValue).Trim();
            }
            else
            {
                objEmployeePromotionDetails.NewDesig = "";
            }

            objEmployeePromotionDetails.PromotionDate = Convert.ToString(txtPromotionDate.Text).Trim();
            objEmployeePromotionDetails.JoiningDate = Convert.ToString(txtJoningDate.Text).Trim();

            objEmployeePromotionDetails.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
            objEmployeePromotionDetails.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();
        }
    }

    public ICollection<PromotionEarningDetails> SetObjectInfo4Earnings()
    {
        List<PromotionEarningDetails> lst = new List<PromotionEarningDetails>();
        PromotionEarningDetails objPromotionEarningDetails = null;
        //int itemNo = GetItemNo4Earning();

        foreach (GridViewRow grd in grdEmployeeMasterDetails.Rows)
        {
            CheckBox chk_Allowance = (CheckBox)grd.FindControl("chk_Allowance");
            TextBox txt_Amount = (TextBox)grd.FindControl("txt_Amount");
            TextBox txt_NewAmount = (TextBox)grd.FindControl("txt_NewAmount");
            TextBox txt_ItemNo = (TextBox)grd.FindControl("txt_ItemNo");
            DropDownList DDLCalcOn = (DropDownList)grd.FindControl("DDLCalcOn");
            DropDownList DDLpayMode = (DropDownList)grd.FindControl("DDLpayMode");
            CheckBox chk_Bonus = (CheckBox)grd.FindControl("chk_Bonus");
            CheckBox chk_OT = (CheckBox)grd.FindControl("chk_OT");

            if (chk_Allowance.Checked == true)
            {
                objPromotionEarningDetails = new PromotionEarningDetails();

                objPromotionEarningDetails.EmployeePromotionNo = -1;

                objPromotionEarningDetails.EmployeeId = Convert.ToString(DDLEmployeeId.SelectedValue).Trim();
                objPromotionEarningDetails.ItemNo = Convert.ToInt32(txt_ItemNo.Text);
                objPromotionEarningDetails.Allowances = Convert.ToString(chk_Allowance.Text).Trim();
                objPromotionEarningDetails.Amount = Convert.ToDouble(txt_Amount.Text);
                objPromotionEarningDetails.NewAmount = Convert.ToDouble(txt_NewAmount.Text);
                objPromotionEarningDetails.CalcOn = Convert.ToString(DDLCalcOn.SelectedValue).Trim();
                objPromotionEarningDetails.PaymentMode = Convert.ToString(DDLpayMode.SelectedValue).Trim();

                if (chk_Bonus.Checked == true)
                {
                    objPromotionEarningDetails.Bonus = 1;
                }
                else
                {
                    objPromotionEarningDetails.Bonus = 0;
                }

                if (chk_OT.Checked == true)
                {
                    objPromotionEarningDetails.OT = 1;
                }
                else
                {
                    objPromotionEarningDetails.OT = 0;
                }
                objPromotionEarningDetails.IsDeleted = Convert.ToInt32(0);
                objPromotionEarningDetails.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
                objPromotionEarningDetails.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();

                lst.Add(objPromotionEarningDetails);
                //itemNo = itemNo + 1;
            }
        }
        return lst;
    }

    public ICollection<PromotionDeductionDetails> SetObjectInfo4Deductions()
    {
        List<PromotionDeductionDetails> lst = new List<PromotionDeductionDetails>();
        PromotionDeductionDetails objPromotionDeductionDetails = null;
        //int itemNo = 1;

        foreach (GridViewRow grd in grdDeduction.Rows)
        {
            CheckBox chk_Deductions = (CheckBox)grd.FindControl("chk_Deductions");
            TextBox txt_Percentage = (TextBox)grd.FindControl("txt_Percentage");
            TextBox txt_Amount4D = (TextBox)grd.FindControl("txt_Amount4D");
            TextBox txt_NewAmount4D = (TextBox)grd.FindControl("txt_NewAmount4D");
            TextBox txt_ItemNo = (TextBox)grd.FindControl("txt_ItemNo");
            DropDownList ddlCalcOn4D = (DropDownList)grd.FindControl("ddlCalcOn4D");
            DropDownList ddlPayMode4D = (DropDownList)grd.FindControl("ddlPayMode4D");
            CheckBox chk_OldLimit = (CheckBox)grd.FindControl("chk_OldLimit");
            CheckBox chk_NewLimit = (CheckBox)grd.FindControl("chk_NewLimit");
            TextBox txt_NewLimitAmount = (TextBox)grd.FindControl("txt_NewLimitAmount");
            TextBox txt_OldLimitAmount = (TextBox)grd.FindControl("txt_OldLimitAmount");

            if (chk_Deductions.Checked == true)
            {
                objPromotionDeductionDetails = new PromotionDeductionDetails();
                objPromotionDeductionDetails.EmployeePromotionNo = -1;
                objPromotionDeductionDetails.EmployeeId = Convert.ToString(DDLEmployeeId.SelectedValue).Trim();
                objPromotionDeductionDetails.ItemNo = Convert.ToInt32(txt_ItemNo.Text);
                objPromotionDeductionDetails.Deductions = Convert.ToString(chk_Deductions.Text).Trim();

                if (txt_Percentage.Text != "")
                {
                    objPromotionDeductionDetails.DeductionPercetage = Convert.ToDouble(txt_Percentage.Text);
                }
                else
                {
                    objPromotionDeductionDetails.DeductionPercetage = 0;
                }

                if (txt_Amount4D.Text != "")
                {
                    objPromotionDeductionDetails.DeductionAmount = Convert.ToDouble(txt_Amount4D.Text);
                }
                else
                {
                    objPromotionDeductionDetails.DeductionAmount = 0;
                }

                if (txt_Amount4D.Text != "")
                {
                    objPromotionDeductionDetails.NewDeductionAmount = Convert.ToDouble(txt_NewAmount4D.Text);
                }
                else
                {
                    objPromotionDeductionDetails.NewDeductionAmount = 0;
                }

                if (ddlCalcOn4D.SelectedIndex > 0)
                {
                    objPromotionDeductionDetails.DeductionCalcOn = Convert.ToString(ddlCalcOn4D.SelectedValue).Trim();
                }
                else
                {
                    objPromotionDeductionDetails.DeductionCalcOn = "";
                }

                if (ddlPayMode4D.SelectedIndex > 0)
                {
                    objPromotionDeductionDetails.DeductionPayMode = Convert.ToString(ddlPayMode4D.SelectedValue).Trim();
                }
                else
                {
                    objPromotionDeductionDetails.DeductionPayMode = "";
                }

                if (chk_NewLimit.Checked == true)
                {
                    objPromotionDeductionDetails.NewDeductionLimit = Convert.ToInt32(1);
                    if (txt_NewLimitAmount.Text != "")
                    {
                        objPromotionDeductionDetails.NewLimitAmount = Convert.ToDouble(txt_NewLimitAmount.Text);
                    }
                    else
                    {
                        objPromotionDeductionDetails.NewLimitAmount = 0.0000;
                    }
                }
                else
                {
                    objPromotionDeductionDetails.NewDeductionLimit = 0;
                    objPromotionDeductionDetails.NewLimitAmount = 0.0000;
                }

                if (chk_OldLimit.Checked == true)
                {
                    objPromotionDeductionDetails.DeductionLimit = Convert.ToInt32(1);
                    if (txt_OldLimitAmount.Text != "")
                    {
                        objPromotionDeductionDetails.LimitAmount = Convert.ToDouble(txt_OldLimitAmount.Text);
                    }
                    else
                    {
                        objPromotionDeductionDetails.LimitAmount = 0.0000;
                    }
                }
                else
                {
                    objPromotionDeductionDetails.DeductionLimit = 0;
                    objPromotionDeductionDetails.LimitAmount = 0.0000;
                }

                objPromotionDeductionDetails.IsDeleted = Convert.ToInt32(0);
                objPromotionDeductionDetails.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
                objPromotionDeductionDetails.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();

                lst.Add(objPromotionDeductionDetails);
                //itemNo = itemNo + 1;
            }
        }
        return lst;
    }

    public ICollection<PromotionLeaveDetails> SetObjectInfo4Leaves()
    {
        List<PromotionLeaveDetails> lst = new List<PromotionLeaveDetails>();
        PromotionLeaveDetails objPromotionLeaveDetails = null;
        //int itemno = 1;

        foreach (GridViewRow grd in grdLeave.Rows)
        {
            CheckBox chk_LeaveTypeId = (CheckBox)grd.FindControl("chk_LeaveTypeId");
            TextBox txt_Opening = (TextBox)grd.FindControl("txt_Opening");
            TextBox txt_NewOpening = (TextBox)grd.FindControl("txt_NewOpening");
            RadioButtonList rbtn_MonthlyEarnedType = (RadioButtonList)grd.FindControl("rbtn_MonthlyEarnedType");
            TextBox txt_ItemNo = (TextBox)grd.FindControl("txt_ItemNo");
            TextBox txt_MonthlyEarned = (TextBox)grd.FindControl("txt_MonthlyEarned");

            if (chk_LeaveTypeId.Checked == true)
            {
                objPromotionLeaveDetails = new PromotionLeaveDetails();
                objPromotionLeaveDetails.EmployeePromotionNo = -1;
                objPromotionLeaveDetails.EmployeeId = Convert.ToString(DDLEmployeeId.SelectedValue).Trim();
                objPromotionLeaveDetails.ItemNo = Convert.ToInt32(txt_ItemNo.Text);
                objPromotionLeaveDetails.LeaveType = Convert.ToString(chk_LeaveTypeId.Text).Trim();
                if (txt_Opening.Text != "")
                {
                    objPromotionLeaveDetails.Opening = Convert.ToInt32(txt_Opening.Text);
                }
                else
                {
                    objPromotionLeaveDetails.Opening = 0;
                }

                if (txt_NewOpening.Text != "")
                {
                    objPromotionLeaveDetails.NewOpening = Convert.ToInt32(txt_NewOpening.Text);
                }
                else
                {
                    objPromotionLeaveDetails.NewOpening = 0;
                }

                objPromotionLeaveDetails.MonthlyEarnedType = Convert.ToInt32(rbtn_MonthlyEarnedType.SelectedValue);
                objPromotionLeaveDetails.MonthlyEarned = Convert.ToString(txt_MonthlyEarned.Text).Trim();

                if (Convert.ToString(txtEarningLeaveAllowdAfter.Text).Trim() != "")
                {
                    objPromotionLeaveDetails.EarningLeaveAllowedAfter = Convert.ToInt32(txtEarningLeaveAllowdAfter.Text);
                }
                else
                {
                    objPromotionLeaveDetails.EarningLeaveAllowedAfter = 0;
                }

                if (DDLEarningLeaveAllowed.SelectedIndex > 0)
                {
                    objPromotionLeaveDetails.EarningLeaveIn = Convert.ToString(DDLEarningLeaveAllowed.SelectedValue).Trim();
                }
                else
                {
                    objPromotionLeaveDetails.EarningLeaveIn = "";
                }

                if (chkOnlyLastYearConsumed.Checked == true)
                {
                    objPromotionLeaveDetails.ConsumedEL = 1;
                }
                else
                {
                    objPromotionLeaveDetails.ConsumedEL = 0;
                }

                if (Convert.ToString(txtCasualLeaveAllowedAfter.Text).Trim() != "")
                {
                    objPromotionLeaveDetails.CasulLeaveAllowedAfter = Convert.ToInt32(txtCasualLeaveAllowedAfter.Text);
                }
                else
                {
                    objPromotionLeaveDetails.CasulLeaveAllowedAfter = 0;
                }

                if (DDLCasualLeaveAllowedAfter.SelectedIndex > 0)
                {
                    objPromotionLeaveDetails.CasualLeaveAllowedIn = Convert.ToString(DDLCasualLeaveAllowedAfter.SelectedValue);
                }
                else
                {
                    objPromotionLeaveDetails.CasualLeaveAllowedIn = "";
                }

                if (chkCLConsumedinCurrentYear.Checked == true)
                {
                    objPromotionLeaveDetails.EarnedCL = 1;
                }
                else
                {
                    objPromotionLeaveDetails.EarnedCL = 0;
                }

                objPromotionLeaveDetails.IsDeleted = Convert.ToInt32(0);
                objPromotionLeaveDetails.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
                objPromotionLeaveDetails.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();

                lst.Add(objPromotionLeaveDetails);
                //itemno = itemno + 1;
            }
        }
        return lst;
    }
    #endregion

    #region Selected index Change
    protected void DDLEmployeeId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLEmployeeId.SelectedIndex > 0 && DDLEmployeeId.SelectedValue != "")
        {
            PopulateEmployeeDetails(Convert.ToString(DDLEmployeeId.SelectedValue).Trim());
        }
        else
        {
            lblMsg.Text = "Please Select Country";
            DDLEmployeeId.Focus();
        }
    }

    //Leave Tab Selected index changed Function
    protected void ddlPayMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = 0;
        foreach (GridViewRow grd in grdEmployeeMasterDetails.Rows)
        {
            DropDownList ddlPayMode = (DropDownList)grd.FindControl("ddlPayMode");
            CheckBox chk_Allowance = (CheckBox)grd.FindControl("chk_Allowance");
            if (chk_Allowance.Checked == true)
            {
                if (ddlPayMode.SelectedIndex > 0)
                {

                    ddlPayMode.SelectedIndex = ddlPayMode.SelectedIndex;
                    index = ddlPayMode.SelectedIndex;
                }
                else
                {
                    ddlPayMode.SelectedIndex = index;
                }
            }
        }
    }

    protected void ddlPayMode4D_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = 0;
        foreach (GridViewRow grd in grdDeduction.Rows)
        {
            DropDownList ddlPayMode4D = (DropDownList)grd.FindControl("ddlPayMode4D");
            CheckBox chk_Deductions = (CheckBox)grd.FindControl("chk_Deductions");

            if (chk_Deductions.Checked == true)
            {
                if (ddlPayMode4D.SelectedIndex > 0)
                {
                    ddlPayMode4D.SelectedIndex = ddlPayMode4D.SelectedIndex;
                    index = ddlPayMode4D.SelectedIndex;
                }
                else
                {
                    ddlPayMode4D.SelectedIndex = index;
                }
            }
        }
    }
    #endregion

    #region Text Box Change Events
    protected void txt_LimitAmount_TextChanged(object sender, EventArgs e)
    {
        int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
        TextBox txt_LimitAmount = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_LimitAmount");
        TextBox txt_Amount4D = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_Amount4D");
        TextBox txt_Percentage = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_Percentage");

        if (txt_LimitAmount.Text == "")
        {
            txt_LimitAmount.Text = "0.0000";
            txt_Amount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
        }
    }

    protected void txt_NewAmount_TextChanged(object sender, EventArgs e)
    {
        int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
        TextBox txt_NewAmount = (TextBox)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("txt_NewAmount");
        CheckBox chk_Allowances = (CheckBox)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("chk_Allowances");

        foreach (GridViewRow grd in grdDeduction.Rows)
        {
            CheckBox chk_Deductions = (CheckBox)grd.FindControl("chk_Deductions");
            TextBox txt_Percentage = (TextBox)grd.FindControl("txt_Percentage");
            TextBox txt_NewAmount4D = (TextBox)grd.FindControl("txt_NewAmount4D");
            CheckBox chk_NewLimit = (CheckBox)grd.FindControl("chk_NewLimit");
            TextBox txt_NewLimitAmount = (TextBox)grd.FindControl("txt_NewLimitAmount");

            if (chk_Deductions.Checked == true)
            {
                if (chk_Deductions.Text == "EPF" || chk_Deductions.Text == "ESI")
                {
                    txt_NewAmount4D.Enabled = false;
                }
                else
                {
                    txt_NewAmount4D.Enabled = true;
                }

                if (chk_Deductions.Text == "ESI")
                {
                    chk_NewLimit.Enabled = false;
                    if (GetBasicPay() >= 15000)
                    {
                        txt_NewAmount4D.Text = "0.0000";
                    }
                    else
                    {
                        txt_NewAmount4D.Text = Convert.ToString(CalculateESIDeductions(Convert.ToDouble(txt_Percentage.Text)));
                    }
                }
                else
                {
                    txt_NewAmount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
                    chk_NewLimit.Enabled = true;
                }
            }
        }

    }
    #endregion

    #region Checkbox Change Event
    protected void chk_Allowance_CheckChanged(object sender, EventArgs e)
    {
        int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox chk_Allowance = (CheckBox)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("chk_Allowance");
        TextBox txt_Amount = (TextBox)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("txt_Amount");
        TextBox txt_NewAmount = (TextBox)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("txt_NewAmount");
        TextBox txt_ItemNo = (TextBox)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("txt_ItemNo");
        DropDownList DDLCalcOn = (DropDownList)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("DDLCalcOn");
        DropDownList DDLpayMode = (DropDownList)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("DDLpayMode");
        CheckBox chk_Bonus = (CheckBox)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("chk_Bonus");
        CheckBox chk_OT = (CheckBox)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("chk_OT");

        if (chk_Allowance.Checked == true)
        {
            if (Convert.ToString(txt_Amount.Text) == "")
            {
                txt_Amount.Text = "0";
            }
            txt_ItemNo.Text = Convert.ToString(GetItemNo4Earning());
            txt_NewAmount.Text = "0";
            txt_NewAmount.Enabled = true;
            DDLCalcOn.Enabled = true;
            DDLpayMode.Enabled = true;
            DDLpayMode.SelectedIndex = 0;
            chk_Bonus.Enabled = true;
            chk_OT.Enabled = true;
        }
        else
        {
            txt_NewAmount.Text = "";
            txt_ItemNo.Text = "";
            txt_NewAmount.Enabled = false;
            DDLCalcOn.Enabled = false;
            DDLpayMode.Enabled = false;
            DDLpayMode.SelectedIndex = 0;
            chk_Bonus.Enabled = false;
            chk_OT.Enabled = false;
        }

        dt4Allowances = (DataTable)Session["EmployeeEarning"];
        dt4Allowances.AcceptChanges();
        Session["EmployeeEarning"] = (DataTable)dt4Allowances;
    }

    protected void chk_Deductions_CheckChanged(object sender, EventArgs e)
    {
        int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox chk_Deductions = (CheckBox)grdDeduction.Rows[selRowIndex].FindControl("chk_Deductions");
        TextBox txt_Percentage = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_Percentage");
        TextBox txt_Amount4D = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_Amount4D");
        TextBox txt_ItemNo = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_ItemNo");
        TextBox txt_NewAmount4D = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_NewAmount4D");
        DropDownList ddlCalcOn4D = (DropDownList)grdDeduction.Rows[selRowIndex].FindControl("ddlCalcOn4D");
        DropDownList ddlPayMode4D = (DropDownList)grdDeduction.Rows[selRowIndex].FindControl("ddlPayMode4D");
        CheckBox chk_NewLimit = (CheckBox)grdDeduction.Rows[selRowIndex].FindControl("chk_NewLimit");
        TextBox txt_NewLimitAmount = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_NewLimitAmount");

        if (chk_Deductions.Checked == true)
        {
            txt_ItemNo.Text = Convert.ToString(GetItemNo4Deduction());
            if (Convert.ToString(txt_Amount4D.Text) == "")
            {
                txt_Amount4D.Text = "0";
            }

            if (chk_Deductions.Text == "EPF" || chk_Deductions.Text == "ESI")
            {
                txt_NewAmount4D.Enabled = false;
            }
            else
            {
                txt_NewAmount4D.Enabled = true;
            }

            if (chk_Deductions.Text == "ESI")
            {
                chk_NewLimit.Enabled = false;
                if (GetBasicPay() >= 15000)
                {
                    txt_NewAmount4D.Text = "0.0000";
                }
                else
                {
                    //txt_Amount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
                    txt_NewAmount4D.Text = Convert.ToString(CalculateESIDeductions(Convert.ToDouble(txt_Percentage.Text)));
                }
            }
            else
            {
                txt_NewAmount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
                chk_NewLimit.Enabled = true;
            }

            ddlCalcOn4D.Enabled = true;
            ddlPayMode4D.Enabled = true;
            ddlPayMode4D.SelectedIndex = 0;
            //chk_Limit.Enabled = true;
            txt_NewLimitAmount.Enabled = true;
        }
        else
        {
            ddlCalcOn4D.Enabled = false;
            ddlPayMode4D.Enabled = false;
            ddlPayMode4D.SelectedIndex = 0;
            txt_NewAmount4D.Enabled = false;
            chk_NewLimit.Enabled = false;
            txt_NewLimitAmount.Enabled = false;
            txt_NewAmount4D.Text = "";
        }

        dt4Deductions = (DataTable)Session["EmployeeDeduction"];
        dt4Deductions.AcceptChanges();
        Session["EmployeeDeduction"] = (DataTable)dt4Deductions;
    }

    protected void chk_LeaveTypeId_CheckChanged(object sender, EventArgs e)
    {
        int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox chk_LeaveTypeId = (CheckBox)grdLeave.Rows[selRowIndex].FindControl("chk_LeaveTypeId");
        TextBox txt_Opening = (TextBox)grdLeave.Rows[selRowIndex].FindControl("txt_Opening");
        TextBox txt_ItemNo = (TextBox)grdLeave.Rows[selRowIndex].FindControl("txt_ItemNo");
        TextBox txt_NewOpening = (TextBox)grdLeave.Rows[selRowIndex].FindControl("txt_NewOpening");
        RadioButtonList rbtn_MonthlyEarnedType = (RadioButtonList)grdLeave.Rows[selRowIndex].FindControl("rbtn_MonthlyEarnedType");
        TextBox txt_MonthlyEarned = (TextBox)grdLeave.Rows[selRowIndex].FindControl("txt_MonthlyEarned");

        if (chk_LeaveTypeId.Checked == true)
        {
            rbtn_MonthlyEarnedType.Enabled = true;
            txt_MonthlyEarned.Enabled = true;
            txt_ItemNo.Text = Convert.ToString(GetItemNo4Leave());
        }
        else
        {
            rbtn_MonthlyEarnedType.Enabled = false;
            txt_MonthlyEarned.Enabled = false;
        }

        dt4Leave = (DataTable)Session["EmployeeLeave"];
        dt4Leave.AcceptChanges();
        Session["EmployeeLeave"] = (DataTable)dt4Leave;
    }

    protected void chkLeaveValidation_CheckedChanged(object sender, EventArgs e)
    {
        if (chkLeaveValidation.Checked == true)
        {
            txtEarningLeaveAllowdAfter.Enabled = true;
            DDLEarningLeaveAllowed.Enabled = true;
            chkOnlyLastYearConsumed.Enabled = true;
            txtCasualLeaveAllowedAfter.Enabled = true;
            DDLCasualLeaveAllowedAfter.Enabled = true;
            chkCLConsumedinCurrentYear.Enabled = true;
        }
        else
        {
            txtEarningLeaveAllowdAfter.Enabled = false;
            DDLEarningLeaveAllowed.Enabled = false;
            chkOnlyLastYearConsumed.Enabled = false;
            txtCasualLeaveAllowedAfter.Enabled = false;
            DDLCasualLeaveAllowedAfter.Enabled = false;
            chkCLConsumedinCurrentYear.Enabled = false;
        }
    }

    protected void chkLimit_CheckedChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox chk_Deductions = (CheckBox)grdDeduction.Rows[selRowIndex].FindControl("chk_Deductions");
        CheckBox chk_NewLimit = (CheckBox)grdDeduction.Rows[selRowIndex].FindControl("chk_NewLimit");
        TextBox txt_NewLimitAmount = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_NewLimitAmount");
        TextBox txt_Amount4D = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_Amount4D");
        TextBox txt_NewAmount4D = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_NewAmount4D");
        TextBox txt_Percentage = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_Percentage");

        if (chk_NewLimit.Checked == true)
        {
            if (chk_Deductions.Text == "ESI")
            {
                if (GetBasicPay() >= 15000)
                {
                    txt_NewAmount4D.Text = "0.0000";
                }
                else
                {
                    //txt_Amount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
                    txt_NewAmount4D.Text = Convert.ToString(CalculateESIDeductions(Convert.ToDouble(txt_Percentage.Text)));
                }
            }
            else
            {
                txt_NewLimitAmount.Visible = true;
                if (txt_NewLimitAmount.Text != "")
                {
                    txt_NewAmount4D.Text = Convert.ToString(CalculateDeductionsOnLimit(Convert.ToDouble(txt_Percentage.Text), Convert.ToDouble(txt_NewLimitAmount.Text)));
                }
                else
                {
                    txt_NewLimitAmount.Text = "6500.00";
                    txt_NewAmount4D.Text = Convert.ToString(CalculateDeductionsOnLimit(Convert.ToDouble(txt_Percentage.Text), Convert.ToDouble(txt_NewLimitAmount.Text)));
                }
            }
        }
        else
        {

            txt_NewLimitAmount.Text = "";
            txt_NewLimitAmount.Visible = false;

            if (chk_Deductions.Text == "ESI")
            {
                if (GetBasicPay() >= 15000)
                {
                    txt_NewAmount4D.Text = "0.0000";
                }
                else
                {
                    txt_NewAmount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
                }
            }
            else
            {
                txt_NewAmount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
            }
        }
    }
    #endregion

    #region Grid Events
    //Allowances Grid
    protected void grdEmployeeMasterDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            CheckBox chk_Allowance = ((CheckBox)e.Row.FindControl("chk_Allowance"));
            TextBox txt_NewAmount = ((TextBox)e.Row.FindControl("txt_NewAmount"));
            DropDownList DDLCalcOn = ((DropDownList)e.Row.FindControl("DDLCalcOn"));
            DropDownList DDLpayMode = ((DropDownList)e.Row.FindControl("DDLpayMode"));
            CheckBox chk_Bonus = ((CheckBox)e.Row.FindControl("chk_Bonus"));
            CheckBox chk_OT = ((CheckBox)e.Row.FindControl("chk_OT"));

            BindPaymentMode(DDLpayMode);
            BindCalcOn(DDLCalcOn);

            if (chk_Allowance.Checked == true)
            {
                txt_NewAmount.Enabled = true;
                DDLCalcOn.Enabled = true;
                DDLpayMode.Enabled = true;
                chk_Bonus.Enabled = true;
                chk_OT.Enabled = true;
            }
            else
            {
                txt_NewAmount.Enabled = false;
                DDLCalcOn.Enabled = false;
                DDLpayMode.Enabled = false;
                chk_Bonus.Enabled = false;
                chk_OT.Enabled = false;
            }
        }
    }

    protected void grdEmployeeMasterDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            lblMsg.Text = "";
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            CheckBox chk_Allowance = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[2].FindControl("chk_Allowance");
            TextBox txt_NewAmount = (TextBox)grdEmployeeMasterDetails.Rows[index].Cells[3].FindControl("txt_NewAmount");
            DropDownList DDLCalcOn = (DropDownList)grdEmployeeMasterDetails.Rows[index].Cells[4].FindControl("DDLCalcOn");
            DropDownList DDLpayMode = (DropDownList)grdEmployeeMasterDetails.Rows[index].Cells[5].FindControl("DDLpayMode");
            CheckBox chk_Bonus = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[6].FindControl("chk_Bonus");
            CheckBox chk_OT = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[7].FindControl("chk_OT");

            TabContainer1.ActiveTabIndex = 1;

            if (chk_Allowance.Checked == true)
            {
                txt_NewAmount.Enabled = true;
                DDLCalcOn.Enabled = true;
                DDLpayMode.Enabled = true;
                chk_Bonus.Enabled = true;
                chk_OT.Enabled = true;
            }
            else
            {
                txt_NewAmount.Enabled = false;
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

    protected void grdEmployeeMasterDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdEmployeeMasterDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    //Deduction Grid
    protected void grdDeduction_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            CheckBox chk_Deductions = ((CheckBox)e.Row.FindControl("chk_Deductions"));
            TextBox txt_Percentage = ((TextBox)e.Row.FindControl("txt_Percentage"));
            TextBox txt_NewAmount4D = ((TextBox)e.Row.FindControl("txt_NewAmount4D"));
            DropDownList ddlCalcOn4D = ((DropDownList)e.Row.FindControl("ddlCalcOn4D"));
            DropDownList ddlPayMode4D = ((DropDownList)e.Row.FindControl("ddlPayMode4D"));
            CheckBox chk_NewLimit = ((CheckBox)e.Row.FindControl("chk_NewLimit"));
            TextBox txt_OldLimitAmount = ((TextBox)e.Row.FindControl("txt_OldLimitAmount"));
            TextBox txt_NewLimitAmount = ((TextBox)e.Row.FindControl("txt_NewLimitAmount"));

            BindPaymentMode4Deductions(ddlPayMode4D);
            BindCalcOnDeductions(ddlCalcOn4D);

            if (chk_Deductions.Checked == true)
            {
                ddlCalcOn4D.Enabled = true;
                ddlPayMode4D.Enabled = true;
                chk_NewLimit.Enabled = true;
                txt_NewLimitAmount.Enabled = true;
            }
            else
            {
                ddlCalcOn4D.Enabled = false;
                ddlPayMode4D.Enabled = false;
                chk_NewLimit.Enabled = false;
                txt_NewLimitAmount.Enabled = false;
            }
        }
    }

    protected void grdDeduction_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            lblMsg.Text = "";
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            //CheckBox chk_Allowance = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[2].FindControl("chk_Allowance");
            //TextBox txt_Amount = (TextBox)grdEmployeeMasterDetails.Rows[index].Cells[3].FindControl("txt_Amount");
            //DropDownList DDLCalcOn = (DropDownList)grdEmployeeMasterDetails.Rows[index].Cells[4].FindControl("DDLCalcOn");
            //DropDownList DDLpayMode = (DropDownList)grdEmployeeMasterDetails.Rows[index].Cells[5].FindControl("DDLpayMode");
            //CheckBox chk_Bonus = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[6].FindControl("chk_Bonus");
            //CheckBox chk_OT = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[7].FindControl("chk_OT");

            //TabContainer1.ActiveTabIndex = 1;

            //if (chk_Allowance.Checked == true)
            //{
            //    txt_Amount.Enabled = true;
            //    DDLCalcOn.Enabled = true;
            //    DDLpayMode.Enabled = true;
            //    chk_Bonus.Enabled = true;
            //    chk_OT.Enabled = true;
            //}
            //else
            //{
            //    txt_Amount.Enabled = false;
            //    DDLCalcOn.Enabled = false;
            //    DDLpayMode.Enabled = false;
            //    chk_Bonus.Enabled = false;
            //    chk_OT.Enabled = false;
            //}

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

    protected void grdDeduction_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdDeduction_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    //Leave Type Grid
    protected void grdLeave_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            CheckBox chk_LeaveTypeId = ((CheckBox)e.Row.FindControl("chk_LeaveTypeId"));
            TextBox txt_Opening = ((TextBox)e.Row.FindControl("txt_Opening"));
            TextBox txt_NewOpening = ((TextBox)e.Row.FindControl("txt_NewOpening"));
            RadioButtonList rbtn_MonthlyEarnedType = ((RadioButtonList)e.Row.FindControl("rbtn_MonthlyEarnedType"));
            TextBox txt_MonthlyEarned = ((TextBox)e.Row.FindControl("txt_MonthlyEarned"));

            if (chk_LeaveTypeId.Checked == true)
            {
                rbtn_MonthlyEarnedType.Enabled = true;
                txt_MonthlyEarned.Enabled = true;
            }
            else
            {
                rbtn_MonthlyEarnedType.Enabled = false;
                txt_MonthlyEarned.Enabled = false;
            }
        }
    }

    protected void grdLeave_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            lblMsg.Text = "";
            //int index = Convert.ToInt32(e.CommandArgument.ToString());
            //CheckBox chk_Allowance = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[2].FindControl("chk_Allowance");
            //TextBox txt_Amount = (TextBox)grdEmployeeMasterDetails.Rows[index].Cells[3].FindControl("txt_Amount");
            //DropDownList DDLCalcOn = (DropDownList)grdEmployeeMasterDetails.Rows[index].Cells[4].FindControl("DDLCalcOn");
            //DropDownList DDLpayMode = (DropDownList)grdEmployeeMasterDetails.Rows[index].Cells[5].FindControl("DDLpayMode");
            //CheckBox chk_Bonus = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[6].FindControl("chk_Bonus");
            //CheckBox chk_OT = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[7].FindControl("chk_OT");

            //TabContainer1.ActiveTabIndex = 1;

            //if (chk_Allowance.Checked == true)
            //{
            //    txt_Amount.Enabled = true;
            //    DDLCalcOn.Enabled = true;
            //    DDLpayMode.Enabled = true;
            //    chk_Bonus.Enabled = true;
            //    chk_OT.Enabled = true;
            //}
            //else
            //{
            //    txt_Amount.Enabled = false;
            //    DDLCalcOn.Enabled = false;
            //    DDLpayMode.Enabled = false;
            //    chk_Bonus.Enabled = false;
            //    chk_OT.Enabled = false;
            //}

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

    protected void grdLeave_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdLeave_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion

    #region Other Function
    public int GetItemNo4Earning()
    {
        DataSet ds4ItemNo = new DataSet();
        try
        {
            if (DDLEmployeeId.SelectedIndex > 0)
            {
                if (ItemNo4Earning == 0)
                {
                    ds4ItemNo = objPromotionEarningDetailsManager.GetMaxItemNo4Earning(Convert.ToString(DDLEmployeeId.SelectedValue).Trim());
                    if (ds4ItemNo != null)
                    {
                        ItemNo4Earning = Convert.ToInt32(ds4ItemNo.Tables[0].Rows[0]["ItemNo"]) + 1;
                    }
                }
                else
                {
                    ItemNo4Earning = ItemNo4Earning + 1;
                }
            }
            else
            {
                lblMsg.Text = "please Select Employee Code";
            }
        }
        catch (Exception ex)
        {
            ItemNo4Earning = ItemNo4Earning + 1;
        }
        return ItemNo4Earning;
    }

    public int GetItemNo4Deduction()
    {
        DataSet ds4ItemNo = new DataSet();
        try
        {
            if (DDLEmployeeId.SelectedIndex > 0)
            {
                if (ItemNo4Deduction == 0)
                {
                    ds4ItemNo = objPromotionDeductionDetailsManager.GetMaxItemNo4Deduction(Convert.ToString(DDLEmployeeId.SelectedValue).Trim());
                    if (ds4ItemNo != null)
                    {
                        ItemNo4Deduction = Convert.ToInt32(ds4ItemNo.Tables[0].Rows[0]["ItemNo"]) + 1;
                    }
                }
                else
                {
                    ItemNo4Deduction = ItemNo4Deduction + 1;
                }
            }
            else
            {
                lblMsg.Text = "please Select Employee Code";
            }
        }
        catch (Exception ex)
        {
            ItemNo4Deduction = ItemNo4Deduction + 1;
        }
        return ItemNo4Deduction;
    }

    public int GetItemNo4Leave()
    {
        DataSet ds4ItemNo = new DataSet();
        try
        {
            if (DDLEmployeeId.SelectedIndex > 0)
            {
                if (ItemNo4Leave == 0)
                {
                    ds4ItemNo = objPromotionLeaveDetailsManager.GetMaxItemNo4Leave(Convert.ToString(DDLEmployeeId.SelectedValue).Trim());
                    if (ds4ItemNo != null)
                    {
                        ItemNo4Leave = Convert.ToInt32(ds4ItemNo.Tables[0].Rows[0]["ItemNo"]) + 1;
                    }
                    else
                    {
                        lblMsg.Text = "please Select Employee Code";
                    }
                }
                else
                {
                    ItemNo4Leave = ItemNo4Leave + 1;
                }
            }

        }
        catch (Exception ex)
        {
            ItemNo4Leave = ItemNo4Leave + 1;
        }
        return ItemNo4Leave;
    }

    //public int GetItemNo4Earning()
    //{
    //    int Itemno = 0;
    //    dt4EmployeeEarning = (DataTable)Session["EmployeeEarning"];
    //    if (dt4EmployeeEarning != null)
    //    {
    //        Itemno = Convert.ToInt32(dt4EmployeeEarning.Rows.Count) + 1;
    //    }
    //    else
    //    {
    //        Itemno = Itemno + 1;
    //    }
    //    return Itemno;
    //}

    //public int GetItemNo4Deduction()
    //{
    //    int Itemno = 0;
    //    dt4EmployeeDeduction = (DataTable)Session["EmployeeDeduction"];
    //    if (dt4EmployeeDeduction != null)
    //    {
    //        Itemno = Convert.ToInt32(dt4EmployeeDeduction.Rows.Count) + 1;
    //    }
    //    else
    //    {
    //        Itemno = Itemno + 1;
    //    }
    //    return Itemno;
    //}

    //public int GetItemNo4Leave()
    //{
    //    int Itemno = 0;
    //    dt4PromotionLeaveDetails = (DataTable)Session["EmployeeLeave"];
    //    if (dt4PromotionLeaveDetails != null)
    //    {
    //        Itemno = Convert.ToInt32(dt4PromotionLeaveDetails.Rows.Count) + 1;
    //    }
    //    else
    //    {
    //        Itemno = Itemno + 1;
    //    }
    //    return Itemno;
    //}
    #endregion

    #region Calculation
    public double CalculateDeductions(double Percentage)
    {
        DataTable dt = new DataTable();
        double deductionAmount = 0.0;
        try
        {
            foreach (GridViewRow grd in grdEmployeeMasterDetails.Rows)
            {
                CheckBox chk_Allowance = (CheckBox)grd.FindControl("chk_Allowance");
                TextBox txt_NewAmount = (TextBox)grd.FindControl("txt_NewAmount");

                if (Convert.ToString(chk_Allowance.Text) == "Basic")
                {
                    deductionAmount = Math.Round((Convert.ToDouble(txt_NewAmount.Text) * Percentage) / 100);
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString(); ;
        }
        return deductionAmount;
    }

    public double CalculateESIDeductions(double Percentage)
    {
        DataTable dt = new DataTable();
        double deductionAmount = 0.0;
        try
        {
            //foreach (GridViewRow grd in grdEmployeeMasterDetails.Rows)
            //{
            //CheckBox chk_Allowance = (CheckBox)grd.FindControl("chk_Allowance");
            //TextBox txt_Amount = (TextBox)grd.FindControl("txt_Amount");

            //if (chk_Allowance.Checked ==true)
            //{
            deductionAmount = Math.Round((Convert.ToDouble(GetBasicPay() * Percentage) / 100));
            //    }
            //}
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString(); ;
        }
        return deductionAmount;
    }

    public double CalculateDeductionsOnLimit(double Percentage, double LimitAmount)
    {
        DataTable dt = new DataTable();
        double deductionAmount = 0.0;
        try
        {
            foreach (GridViewRow grd in grdEmployeeMasterDetails.Rows)
            {
                CheckBox chk_Allowance = (CheckBox)grd.FindControl("chk_Allowance");
                TextBox txt_NewAmount = (TextBox)grd.FindControl("txt_NewAmount");
                if (Convert.ToString(chk_Allowance.Text) == "BASIC")
                {
                    if (LimitAmount > Convert.ToDouble(txt_NewAmount.Text))
                    {
                        deductionAmount = (Convert.ToDouble(txt_NewAmount.Text) * Percentage) / 100;
                    }
                    else
                    {
                        if (LimitAmount != 0.0000)
                        {
                            deductionAmount = Math.Round((LimitAmount * Percentage) / 100);
                        }
                        else
                        {
                            deductionAmount = Math.Round((Convert.ToDouble(txt_NewAmount.Text) * Percentage) / 100);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString(); ;
        }
        return deductionAmount;
    }

    public double GetBasicPay()
    {
        DataTable dt = new DataTable();
        double GrossBasicPay = 0.0;
        try
        {
            foreach (GridViewRow grd in grdEmployeeMasterDetails.Rows)
            {
                CheckBox chk_Allowance = (CheckBox)grd.FindControl("chk_Allowance");
                TextBox txt_NewAmount = (TextBox)grd.FindControl("txt_NewAmount");

                if (chk_Allowance.Checked == true)
                {
                    GrossBasicPay = Math.Round(GrossBasicPay + Convert.ToDouble(txt_NewAmount.Text));
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

    #region Check Validation
    public bool CheckValidation()
    {
        bool IsTrue = true;
        if (DDlEmployeeType.SelectedIndex == 0)
        {
            lblMsg.Text = "Please Select EmployeeType";
            IsTrue = false;
        }
        return IsTrue;
    }
    #endregion

}