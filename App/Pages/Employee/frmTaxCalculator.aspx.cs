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

public partial class Pages_Employee_frmTaxCalculator : System.Web.UI.Page
{
    TaxCalculationMasterManager objTaxCalculationMasterManager = new TaxCalculationMasterManager();
    TaxCalculationMaster4DeductionManager objTaxCalculationMaster4DeductionManager = new TaxCalculationMaster4DeductionManager();
    EmployeeMasterDetailsManager objEmployeeMasterDetailsManager = new EmployeeMasterDetailsManager();
    EmployeeEarningDetailsManager objEmployeeEarningDetailsManager = new EmployeeEarningDetailsManager();
    EmployeeDeductionDetailsManager objEmployeeDeductionDetailsManager = new EmployeeDeductionDetailsManager();

    DataSet ds4TaxableEarning = new DataSet();
    DataTable dt4TaxableEarning = new DataTable();

    DataSet ds4TaxableDeduction = new DataSet();
    DataTable dt4TaxableDeduction = new DataTable();

    DataSet ds4EmployeeDetails = new DataSet();
    DataTable dt4EmployeeDetails = new DataTable();

    DataSet ds4EmployeeEarningDetails = new DataSet();
    DataTable dt4EmployeeEarningDetails = new DataTable();

    DataSet ds4EmployeeDeductionDetails = new DataSet();
    DataTable dt4EmployeeDeductionDetails = new DataTable();

    ReportMasterManager _objReportMasterManager = new ReportMasterManager();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            iniControls();
            BindGender();
            BindTaxableEarning();
            BindTaxableDeduction();

            if (Convert.ToString(Session["EmployeeId"]).Trim() != "")
            {
                txtCode.Text = Convert.ToString(Session["EmployeeId"]).Trim();
                txtCode.Enabled = false;
                PopulateDetails4EmplopyeeId(Convert.ToString(Session["EmployeeId"]).Trim());
            }
        }
    }

    #region iniControls
    public void iniControls()
    {
        txtTDSEarningId.Text = Convert.ToString(GetTDSEarningId());
        txtTDSDeductionId.Text = Convert.ToString(GetTDSDeductionId());
        txtCode.Text = "";
        txtfhName.Text = "";
        txtName.Text = "";
        txtDateOfJoining.Text = "";
        txtUnit.Text = "";
        DDLGender.SelectedIndex = 0;
        DDLGender.Enabled = true;

        inicontrols4TaxablEarning();
        inicontrols4TaxablDeduction();
    }

    public void inicontrols4TaxablEarning()
    {
        foreach (GridViewRow grd in grdTaxableEarning.Rows)
        {
            Label lbl_TaxableEarning = (Label)grd.FindControl("lbl_TaxableEarning");
            TextBox txt_TaxableEarning = (TextBox)grd.FindControl("txt_TaxableEarning");

            txt_TaxableEarning.Text = "";
            txt_TaxableEarning.Enabled = false;
        }
    }

    public void inicontrols4TaxablDeduction()
    {
        foreach (GridViewRow grd in grdTaxableDeduction.Rows)
        {
            Label lbl_TaxableDeduction = (Label)grd.FindControl("lbl_TaxableDeduction");
            TextBox txt_TaxableDeduction = (TextBox)grd.FindControl("txt_TaxableDeduction");

            txt_TaxableDeduction.Text = "";
            txt_TaxableDeduction.Enabled = false;
        }
    }
    #endregion

    #region Bind Gender
    public void BindGender()
    {
        DDLGender.Items.Add(new ListItem("Male", "M"));
        DDLGender.Items.Add(new ListItem("Female", "F"));
        DDLGender.Items.Insert(0, "-- Select--");
    }
    #endregion

    #region Bind Grid
    public void BindTaxableEarning()
    {
        try
        {
            ds4TaxableEarning = objTaxCalculationMasterManager.GetTaxableEarning();
            grdTaxableEarning.DataSource = ds4TaxableEarning.Tables[0];
            grdTaxableEarning.DataBind();
            Session["TaxableEarning"] = ds4TaxableEarning.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindTaxableDeduction()
    {
        try
        {
            ds4TaxableDeduction = objTaxCalculationMasterManager.GetTaxableDeduction();
            grdTaxableDeduction.DataSource = ds4TaxableDeduction.Tables[0];
            grdTaxableDeduction.DataBind();
            Session["TaxableDeduction"] = ds4TaxableDeduction.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    #endregion

    #region Grid Events
    //Allowances Grid
    protected void grdTaxableEarning_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            Label lbl_TaxableEarning = ((Label)e.Row.FindControl("lbl_TaxableEarning"));
            TextBox txt_TaxableEarning = ((TextBox)e.Row.FindControl("txt_TaxableEarning"));
            CheckBox chk_TaxableEarning = ((CheckBox)e.Row.FindControl("chk_TaxableEarning"));
            txt_TaxableEarning.Text = "0";

            if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "EARNING")
            {
                lbl_TaxableEarning.Font.Bold = true;
                txt_TaxableEarning.Visible = false;
                chk_TaxableEarning.Visible = false;

            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "BASIC")
            {
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "HRA")
            {
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "CONVEYANCE")
            {
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "SPL ALLW")
            {
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "D.P.")
            {
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "D.A.")
            {
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "LV. Amount")
            {
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "ADDL SPLALLW")
            {
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "MEDICAL")
            {
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "LTA")
            {
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "PREV. EMP INCOME")
            {
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "OTHERS")
            {
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "GROSS SALARY")
            {
                lbl_TaxableEarning.ForeColor = System.Drawing.Color.Black;
                lbl_TaxableEarning.Font.Bold = true;
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "EXEMPTION U/s 10")
            {
                lbl_TaxableEarning.ForeColor = System.Drawing.Color.Black;
                lbl_TaxableEarning.Font.Bold = true;
                txt_TaxableEarning.Visible = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "TOTAL EXEMPTION")
            {
                lbl_TaxableEarning.ForeColor = System.Drawing.Color.Black;
                lbl_TaxableEarning.Font.Bold = true;
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "SALARY AFTER 10")
            {
                lbl_TaxableEarning.ForeColor = System.Drawing.Color.Black;
                lbl_TaxableEarning.Font.Bold = true;
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "DEDUCTION U/s 16")
            {
                lbl_TaxableEarning.ForeColor = System.Drawing.Color.Black;
                lbl_TaxableEarning.Font.Bold = true;
                txt_TaxableEarning.Visible = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "SALARY AFTER SEC. 16")
            {
                lbl_TaxableEarning.ForeColor = System.Drawing.Color.Black;
                lbl_TaxableEarning.Font.Bold = true;
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "INC. FROM HOUSE")
            {
                lbl_TaxableEarning.ForeColor = System.Drawing.Color.Black;
                lbl_TaxableEarning.Font.Bold = true;
                txt_TaxableEarning.Visible = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "TOTAL INCOME")
            {
                lbl_TaxableEarning.ForeColor = System.Drawing.Color.Black;
                lbl_TaxableEarning.Font.Bold = true;
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "HRA EXEMPTION")
            {
                txt_TaxableEarning.Enabled = false;
                chk_TaxableEarning.Visible = false;
            }
        }
    }

    protected void grdTaxableEarning_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {

        }
    }

    protected void grdTaxableEarning_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdTaxableEarning_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    //Deduction Grid
    protected void grdTaxableDeduction_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            Label lbl_TaxableDeduction = ((Label)e.Row.FindControl("lbl_TaxableDeduction"));
            TextBox txt_TaxableDeduction = ((TextBox)e.Row.FindControl("txt_TaxableDeduction"));
            CheckBox chk_TaxableDeduction = ((CheckBox)e.Row.FindControl("chk_TaxableDeduction"));
            txt_TaxableDeduction.Text = "0";


            if (Convert.ToString(lbl_TaxableDeduction.Text).Trim() == "INVESTMENTS U/s 80CCE")
            {
                lbl_TaxableDeduction.Font.Bold = true;
                txt_TaxableDeduction.Visible = false;
                chk_TaxableDeduction.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableDeduction.Text).Trim() == "TOTAL INVESTMENTS")
            {
                lbl_TaxableDeduction.ForeColor = System.Drawing.Color.Black;
                lbl_TaxableDeduction.Font.Bold = true;
                txt_TaxableDeduction.Enabled = false;
                chk_TaxableDeduction.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableDeduction.Text).Trim() == "TOTAL DEDUCTION")
            {
                lbl_TaxableDeduction.ForeColor = System.Drawing.Color.Black;
                lbl_TaxableDeduction.Font.Bold = true;
                txt_TaxableDeduction.Enabled = false;
                chk_TaxableDeduction.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableDeduction.Text).Trim() == "DEDUCTION U/s 80")
            {
                lbl_TaxableDeduction.ForeColor = System.Drawing.Color.Black;
                lbl_TaxableDeduction.Font.Bold = true;
                txt_TaxableDeduction.Visible = false;
                chk_TaxableDeduction.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableDeduction.Text).Trim() == "TOTAL DEUCTIONS U/s 80")
            {
                lbl_TaxableDeduction.ForeColor = System.Drawing.Color.Black;
                lbl_TaxableDeduction.Font.Bold = true;
                txt_TaxableDeduction.Enabled = false;
                chk_TaxableDeduction.Visible = false;
            }
            else if (Convert.ToString(lbl_TaxableDeduction.Text).Trim() == "TAX PAYABLE")
            {
                lbl_TaxableDeduction.ForeColor = System.Drawing.Color.Black;
                lbl_TaxableDeduction.Font.Bold = true;
                txt_TaxableDeduction.Enabled = false;
                chk_TaxableDeduction.Visible = false;
            }
        }
    }

    protected void grdTaxableDeduction_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {

        }
    }

    protected void grdTaxableDeduction_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdTaxableDeduction_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

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
                foreach (ErrorHandlerClass err in objTaxCalculationMasterManager.SaveTaxCalculationMaster(SetObjectInfo4Earnings(), SetObjectInfo4Deduction()))
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
                    iniControls();
                }
            }
            else
            {
                btnSubmit.Text = "Submit";
                TabContainer1.TabIndex = 0;
                iniControls();
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
        iniControls();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        iniControls();
    }

    protected void btnClick_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(txtRentPaidByEmployee.Text).Trim() != "" && Convert.ToString(txtRentCalculation.Text).Trim() != "" && Convert.ToString(txt4050PercentOfBasic.Text).Trim() != "")
        {
            double MaxAmount = 0;
            double[] LargestAmount = { Convert.ToDouble(txtRentPaidByEmployee.Text), Convert.ToDouble(txtRentCalculation.Text), Convert.ToDouble(txt4050PercentOfBasic.Text) };
            MaxAmount = LargestAmount.Max();

            if (MaxAmount == Convert.ToDouble(txtRentPaidByEmployee.Text))
            {
                if (Convert.ToDouble(txtRentCalculation.Text) < Convert.ToDouble(txt4050PercentOfBasic.Text))
                {
                    txtHRAEXEMPTION.Text = txtRentCalculation.Text;
                }
                else
                {
                    txtHRAEXEMPTION.Text = txt4050PercentOfBasic.Text;
                }
            }
            else if (MaxAmount == Convert.ToDouble(txtRentCalculation.Text))
            {
                if (Convert.ToDouble(txtRentPaidByEmployee.Text) < Convert.ToDouble(txt4050PercentOfBasic.Text))
                {
                    txtHRAEXEMPTION.Text = txtRentPaidByEmployee.Text;
                }
                else
                {
                    txtHRAEXEMPTION.Text = txt4050PercentOfBasic.Text;
                }
            }
            else if (MaxAmount == Convert.ToDouble(txt4050PercentOfBasic.Text))
            {
                if (Convert.ToDouble(txtRentCalculation.Text) < Convert.ToDouble(txtRentPaidByEmployee.Text))
                {
                    txtHRAEXEMPTION.Text = txtRentCalculation.Text;
                }
                else
                {
                    txtHRAEXEMPTION.Text = txtRentPaidByEmployee.Text;
                }
            }
        }
        else
        {
            lblMsg.Text = "Please Enter The All Required Data";
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow grd in grdTaxableEarning.Rows)
            {
                Label lbl_TaxableEarning = (Label)grd.FindControl("lbl_TaxableEarning");
                TextBox txt_TaxableEarning = (TextBox)grd.FindControl("txt_TaxableEarning");

                if (lbl_TaxableEarning.Text == "HRA EXEMPTION")
                {
                    txt_TaxableEarning.Text = txtHRAEXEMPTION.Text;
                }
                else if (lbl_TaxableEarning.Text == "TOTAL INCOME")
                {
                    txt_TaxableEarning.Text = Convert.ToString(Convert.ToDouble(txt_TaxableEarning.Text) - Convert.ToDouble(txtHRAEXEMPTION.Text));
                }
            }

            txtRentPaidByEmployee.Text = "";
            txtRentCalculation.Text = "";
            txtHRAEXEMPTION.Text = "";
            TaxableIncome();
            TaxaPayableAmount();
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    protected void btnclose_Click(object sender, EventArgs e)
    {
        iniControls();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtRentPaidByEmployee.Text = "";
        txtRentCalculation.Text = "";
        txtHRAEXEMPTION.Text = "";
    }
    #endregion

    #region SetobjectInfo
    public ICollection<TaxCalculationMaster> SetObjectInfo4Earnings()
    {
        List<TaxCalculationMaster> lst = new List<TaxCalculationMaster>();
        TaxCalculationMaster objTaxCalculationMaster = null;
        int itemNo = 1;

        foreach (GridViewRow grd in grdTaxableEarning.Rows)
        {
            Label lbl_TaxableEarning = (Label)grd.FindControl("lbl_TaxableEarning");
            TextBox txt_TaxableEarning = (TextBox)grd.FindControl("txt_TaxableEarning");

            objTaxCalculationMaster = new TaxCalculationMaster();
            objTaxCalculationMaster.TDSNo = Convert.ToInt32(txtTDSEarningId.Text);
            objTaxCalculationMaster.EmployeeId = Convert.ToString(txtCode.Text);
            objTaxCalculationMaster.ItemNo = itemNo;
            objTaxCalculationMaster.TaxableAllowance = Convert.ToString(lbl_TaxableEarning.Text);
            objTaxCalculationMaster.TaxableAmount = Convert.ToDouble(txt_TaxableEarning.Text);

            objTaxCalculationMaster.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
            objTaxCalculationMaster.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();
            lst.Add(objTaxCalculationMaster);
            itemNo = itemNo + 1;
        }

        return lst;
    }

    public ICollection<TaxCalculationMaster4Deduction> SetObjectInfo4Deduction()
    {
        List<TaxCalculationMaster4Deduction> lst = new List<TaxCalculationMaster4Deduction>();
        TaxCalculationMaster4Deduction objTaxCalculationMaster4Deduction = null;
        int itemNo = 1;

        foreach (GridViewRow grd in grdTaxableDeduction.Rows)
        {
            Label lbl_TaxableDeduction = (Label)grd.FindControl("lbl_TaxableDeduction");
            TextBox txt_TaxableDeduction = (TextBox)grd.FindControl("txt_TaxableDeduction");

            objTaxCalculationMaster4Deduction = new TaxCalculationMaster4Deduction();
            objTaxCalculationMaster4Deduction.TDSNo = Convert.ToInt32(txtTDSDeductionId.Text);
            objTaxCalculationMaster4Deduction.EmployeeId = Convert.ToString(txtCode.Text);
            objTaxCalculationMaster4Deduction.ItemNo = itemNo;
            objTaxCalculationMaster4Deduction.TaxableDeduction = Convert.ToString(lbl_TaxableDeduction.Text);
            objTaxCalculationMaster4Deduction.TaxableAmount = Convert.ToDouble(txt_TaxableDeduction.Text);

            objTaxCalculationMaster4Deduction.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
            objTaxCalculationMaster4Deduction.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();
            lst.Add(objTaxCalculationMaster4Deduction);
            itemNo = itemNo + 1;
        }

        return lst;
    }
    #endregion

    #region Selected Index Changed Event
    protected void DDLAssesmentYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DDLTaxPayer_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DDLGender_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DDLResidentialStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    #region Text Change Event
    protected void txtCode_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(txtCode.Text).Trim() != "")
        {
            lblMsg.Text = "";
            PopulateDetails4EmplopyeeId(Convert.ToString(txtCode.Text).Trim());
        }
        else
        {
            txtCode.Focus();
            txtDateOfJoining.Text = "";
            txtName.Text = "";
            txtfhName.Text = "";
            DDLGender.SelectedIndex = 0;
            DDLGender.Enabled = true;
            txtUnit.Text = "";
            lblMsg.Text = "Please Enter The Employee Id";
        }
    }

    protected void txt_TaxableEarning_TextChanged(object sender, EventArgs e)
    {
        double ExemptionAmount = 0;
        double Amount = 0;
        double TotalIncome = 0;
        double GrossSalary = 0;
        double HRAExemption = 0;
        double IncomeFromOtherSources = 0;

        int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
        CheckBox chk_TaxableEarning = (CheckBox)grdTaxableEarning.Rows[selRowIndex].FindControl("chk_TaxableEarning");
        TextBox txt_TaxableEarning = (TextBox)grdTaxableEarning.Rows[selRowIndex].FindControl("txt_TaxableEarning");
        Label lbl_TaxableEarning = (Label)grdTaxableEarning.Rows[selRowIndex].FindControl("lbl_TaxableEarning");

        try
        {
            foreach (GridViewRow grd in grdTaxableEarning.Rows)
            {
                Label lbl_TaxableEarning1 = (Label)grd.FindControl("lbl_TaxableEarning");
                TextBox txt_TaxableEarning1 = (TextBox)grd.FindControl("txt_TaxableEarning");

                if (Convert.ToString(lbl_TaxableEarning1.Text).Trim() == "GROSS SALARY")
                {
                    GrossSalary = Convert.ToDouble(txt_TaxableEarning1.Text);
                }
                else if (Convert.ToString(lbl_TaxableEarning1.Text).Trim() == "HRA EXEMPTION")
                {
                    HRAExemption = Convert.ToDouble(txt_TaxableEarning1.Text);
                }
                else if (Convert.ToString(lbl_TaxableEarning1.Text).Trim() == "TOTAL INCOME")
                {
                    TotalIncome = Convert.ToDouble(txt_TaxableEarning1.Text);
                }
            }

            if (Convert.ToString(txt_TaxableEarning.Text).Trim() != "")
            {
                if (chk_TaxableEarning.Checked == true)
                {
                    if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "INC. FROM OTHER SOURCE")
                    {
                        if (Convert.ToString(txt_TaxableEarning.Text).Trim() != "")
                        {
                            IncomeFromOtherSources = Convert.ToDouble(txt_TaxableEarning.Text);
                        }
                    }
                    else
                    {
                        foreach (GridViewRow grd in grdTaxableEarning.Rows)
                        {
                            Label lbl_TaxableEarning1 = (Label)grd.FindControl("lbl_TaxableEarning");
                            TextBox txt_TaxableEarning1 = (TextBox)grd.FindControl("txt_TaxableEarning");

                            if (Convert.ToString(lbl_TaxableEarning1.Text).Trim() == "INC. FROM OTHER SOURCE")
                            {
                                IncomeFromOtherSources = Convert.ToDouble(txt_TaxableEarning1.Text);
                            }
                        }
                    }

                    foreach (GridViewRow grd in grdTaxableEarning.Rows)
                    {
                        Label lbl_TaxableEarning1 = (Label)grd.FindControl("lbl_TaxableEarning");
                        TextBox txt_TaxableEarning1 = (TextBox)grd.FindControl("txt_TaxableEarning");
                        CheckBox chk_TaxableEarning1 = (CheckBox)grd.FindControl("chk_TaxableEarning");

                        if (chk_TaxableEarning1.Checked == true)
                        {
                            if (Convert.ToString(lbl_TaxableEarning1.Text).Trim() != "INC. FROM OTHER SOURCE")
                            {
                                ExemptionAmount = ExemptionAmount + Convert.ToDouble(txt_TaxableEarning1.Text);
                                Amount = HRAExemption + ExemptionAmount;
                                TotalIncome = GrossSalary + IncomeFromOtherSources - Amount;
                            }
                            else if (Convert.ToString(lbl_TaxableEarning1.Text).Trim() == "INC. FROM OTHER SOURCE")
                            {
                                Amount = HRAExemption + ExemptionAmount;
                                TotalIncome = GrossSalary + IncomeFromOtherSources - Amount;
                            }
                        }
                    }
                }
            }
            else
            {
                txt_TaxableEarning.Text = "0";
                if (chk_TaxableEarning.Checked == true)
                {
                    if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "INC. FROM OTHER SOURCE")
                    {
                        if (Convert.ToString(txt_TaxableEarning.Text).Trim() != "")
                        {
                            IncomeFromOtherSources = Convert.ToDouble(txt_TaxableEarning.Text);
                        }
                    }
                    else
                    {
                        foreach (GridViewRow grd in grdTaxableEarning.Rows)
                        {
                            Label lbl_TaxableEarning1 = (Label)grd.FindControl("lbl_TaxableEarning");
                            TextBox txt_TaxableEarning1 = (TextBox)grd.FindControl("txt_TaxableEarning");

                            if (Convert.ToString(lbl_TaxableEarning1.Text).Trim() == "INC. FROM OTHER SOURCE")
                            {
                                IncomeFromOtherSources = Convert.ToDouble(txt_TaxableEarning1.Text);
                            }
                        }
                    }

                    foreach (GridViewRow grd in grdTaxableEarning.Rows)
                    {
                        Label lbl_TaxableEarning1 = (Label)grd.FindControl("lbl_TaxableEarning");
                        TextBox txt_TaxableEarning1 = (TextBox)grd.FindControl("txt_TaxableEarning");
                        CheckBox chk_TaxableEarning1 = (CheckBox)grd.FindControl("chk_TaxableEarning");

                        if (chk_TaxableEarning1.Checked == true)
                        {
                            if (Convert.ToString(lbl_TaxableEarning1.Text).Trim() != "INC. FROM OTHER SOURCE")
                            {
                                ExemptionAmount = ExemptionAmount + Convert.ToDouble(txt_TaxableEarning1.Text);
                                Amount = HRAExemption + ExemptionAmount;
                                TotalIncome = GrossSalary + IncomeFromOtherSources - Amount;
                            }
                            else if (Convert.ToString(lbl_TaxableEarning1.Text).Trim() == "INC. FROM OTHER SOURCE")
                            {
                                TotalIncome = GrossSalary + IncomeFromOtherSources - Amount;
                            }
                        }
                    }
                }
            }

            foreach (GridViewRow grd in grdTaxableEarning.Rows)
            {
                Label lbl_TaxableEarning1 = (Label)grd.FindControl("lbl_TaxableEarning");
                TextBox txt_TaxableEarning1 = (TextBox)grd.FindControl("txt_TaxableEarning");
                
                if (Convert.ToString(lbl_TaxableEarning1.Text).Trim() == "TOTAL INCOME")
                {
                    txt_TaxableEarning1.Text = Convert.ToString(TotalIncome);
                }
            }

            txtRentPaidByEmployee.Text = "";
            txtRentCalculation.Text = "";
            txtHRAEXEMPTION.Text = "";
            TaxableIncome();
            TaxaPayableAmount();
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    protected void txt_TaxableDeduction_TextChanged(object sender, EventArgs e)
    {
        double InvestMent = 0;
        double TotalDeductions = 0;
        double TaxAbleIncome = 0;
        double Amount = 0;
        double TaxPaybleAmount = 0;
        double HRAExemption = 0;
        double OtherExpences = 0;

        int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
        CheckBox chk_TaxableDeduction = (CheckBox)grdTaxableDeduction.Rows[selRowIndex].FindControl("chk_TaxableDeduction");
        TextBox txt_TaxableDeduction = (TextBox)grdTaxableDeduction.Rows[selRowIndex].FindControl("txt_TaxableDeduction");
        Label lbl_TaxableDeduction = (Label)grdTaxableDeduction.Rows[selRowIndex].FindControl("lbl_TaxableDeduction");

        try
        {
            foreach (GridViewRow grd in grdTaxableDeduction.Rows)
            {
                Label lbl_TaxableDeduction1 = (Label)grd.FindControl("lbl_TaxableDeduction");
                TextBox txt_TaxableDeduction1 = (TextBox)grd.FindControl("txt_TaxableDeduction");

                if (Convert.ToString(lbl_TaxableDeduction1.Text).Trim() == "TOTAL DEDUCTION")
                {
                    InvestMent = Convert.ToDouble(txt_TaxableDeduction1.Text);
                }
                else if (Convert.ToString(lbl_TaxableDeduction1.Text).Trim() == "TAX PAYABLE")
                {
                    TaxPaybleAmount = Convert.ToDouble(txt_TaxableDeduction1.Text);
                }
                else if (Convert.ToString(lbl_TaxableDeduction1.Text).Trim() == "TAXABLE INCOME")
                {
                    TaxAbleIncome = Convert.ToDouble(txt_TaxableDeduction1.Text);
                }
            }

            if (Convert.ToString(txt_TaxableDeduction.Text).Trim() != "")
            {
                if (chk_TaxableDeduction.Checked == true)
                {
                    foreach (GridViewRow grd in grdTaxableDeduction.Rows)
                    {
                        Label lbl_TaxableDeduction1 = (Label)grd.FindControl("lbl_TaxableDeduction");
                        TextBox txt_TaxableDeduction1 = (TextBox)grd.FindControl("txt_TaxableDeduction");
                        CheckBox chk_TaxableDeduction1 = (CheckBox)grd.FindControl("chk_TaxableDeduction");

                        if (chk_TaxableDeduction1.Checked == true)
                        {
                            TotalDeductions = TotalDeductions + Convert.ToDouble(txt_TaxableDeduction1.Text);
                        }
                    }
                }
            }
            else
            {
                txt_TaxableDeduction.Text = "0";
                if (chk_TaxableDeduction.Checked == true)
                {
                    foreach (GridViewRow grd in grdTaxableDeduction.Rows)
                    {
                        Label lbl_TaxableDeduction1 = (Label)grd.FindControl("lbl_TaxableDeduction");
                        TextBox txt_TaxableDeduction1 = (TextBox)grd.FindControl("txt_TaxableDeduction");
                        CheckBox chk_TaxableDeduction1 = (CheckBox)grd.FindControl("chk_TaxableDeduction");

                        if (chk_TaxableDeduction1.Checked == true)
                        {
                            TotalDeductions = TotalDeductions + Convert.ToDouble(txt_TaxableDeduction1.Text);
                        }
                    }
                }
            }

            foreach (GridViewRow grd in grdTaxableDeduction.Rows)
            {
                Label lbl_TaxableDeduction1 = (Label)grd.FindControl("lbl_TaxableDeduction");
                TextBox txt_TaxableDeduction1 = (TextBox)grd.FindControl("txt_TaxableDeduction");

                if (Convert.ToString(lbl_TaxableDeduction1.Text).Trim() == "TOTAL INVESTMENTS")
                {
                    txt_TaxableDeduction1.Text = Convert.ToString(TotalDeductions);
                }
                else if (Convert.ToString(lbl_TaxableDeduction1.Text).Trim() == "TOTAL DEDUCTION")
                {
                    txt_TaxableDeduction1.Text = Convert.ToString(TotalDeductions);
                }
            }
            TaxableIncome();
            txtRentPaidByEmployee.Text = "";
            txtRentCalculation.Text = "";
            txtHRAEXEMPTION.Text = "";
            TaxableIncome();
            TaxaPayableAmount();
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    protected void txtRentPaidByEmployee_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(txtRentPaidByEmployee.Text).Trim() != "")
        {
            if (Convert.ToString(txt10PercentOfBasic.Text).Trim() != "")
            {
                txtRentCalculation.Text = Convert.ToString(Convert.ToDouble(txtRentPaidByEmployee.Text) - Convert.ToDouble(txt10PercentOfBasic.Text)).Trim();
            }
            else
            {
                txtRentCalculation.Text = Convert.ToString(Convert.ToDouble(txtRentPaidByEmployee.Text) - Convert.ToDouble(0)).Trim();
            }
        }
        else
        {
            lblMsg.Text = "Please Enter The Value Of Rent Paid By Employee";
        }
    }
    #endregion

    #region Check Chanege Event
    protected void chk_TaxableEarning_CheckChanged(object sender, EventArgs e)
    {
        int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox chk_TaxableEarning = (CheckBox)grdTaxableEarning.Rows[selRowIndex].FindControl("chk_TaxableEarning");
        TextBox txt_TaxableEarning = (TextBox)grdTaxableEarning.Rows[selRowIndex].FindControl("txt_TaxableEarning");

        if (chk_TaxableEarning.Checked == true)
        {
            txt_TaxableEarning.Text = "0";
            txt_TaxableEarning.Enabled = true;
        }
        else
        {
            txt_TaxableEarning.Text = "";
            txt_TaxableEarning.Enabled = false;
        }

        dt4TaxableEarning = (DataTable)Session["TaxableEarning"];
        dt4TaxableEarning.AcceptChanges();
        Session["TaxableEarning"] = (DataTable)dt4TaxableEarning;
    }

    protected void chk_TaxableDeduction_CheckChanged(object sender, EventArgs e)
    {
        int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox chk_TaxableDeduction = (CheckBox)grdTaxableDeduction.Rows[selRowIndex].FindControl("chk_TaxableDeduction");
        TextBox txt_TaxableDeduction = (TextBox)grdTaxableDeduction.Rows[selRowIndex].FindControl("txt_TaxableDeduction");

        if (chk_TaxableDeduction.Checked == true)
        {
            txt_TaxableDeduction.Text = "0";
            txt_TaxableDeduction.Enabled = true;
        }
        else
        {
            txt_TaxableDeduction.Text = "0";
            txt_TaxableDeduction.Enabled = false;
        }

        dt4TaxableDeduction = (DataTable)Session["TaxableDeduction"];
        dt4TaxableDeduction.AcceptChanges();
        Session["TaxableDeduction"] = (DataTable)dt4TaxableDeduction;
    }
    #endregion

    #region Other Functions
    public void PopulateDetails4EmplopyeeId(string strEmployeeId)
    {
        try
        {
            lblMsg.Text = "";
            ds4EmployeeDetails = objEmployeeMasterDetailsManager.GetEmployeeMaster4ID(strEmployeeId);
            dt4EmployeeDetails = ds4EmployeeDetails.Tables[0];
            if (dt4EmployeeDetails != null && dt4EmployeeDetails.Rows.Count > 0)
            {
                txtName.Text = Convert.ToString(dt4EmployeeDetails.Rows[0]["FirstName"] + " " + dt4EmployeeDetails.Rows[0]["LastName"]);

                if (Convert.ToString(dt4EmployeeDetails.Rows[0]["Gender"]) != "")
                {
                    DDLGender.SelectedValue = Convert.ToString(dt4EmployeeDetails.Rows[0]["Gender"]);
                    DDLGender.Enabled = false;
                }
                txtDateOfJoining.Text = Convert.ToString(dt4EmployeeDetails.Rows[0]["JoiningDate"]);
                txtfhName.Text = Convert.ToString(dt4EmployeeDetails.Rows[0]["FatherName"]);
                txtUnit.Text = Convert.ToString(dt4EmployeeDetails.Rows[0]["Unit"]);
                PopulateEarningDetails4EmplopyeeId(strEmployeeId);
                PopulateDeductionDetails4EmplopyeeId(strEmployeeId);
                CalculateGrossSalary();
                CalculateInvestMent();
                TaxableIncome();
                TaxaPayableAmount();
            }
            else
            {
                lblMsg.Text = "There Is no Record Found for This Employee Id. Please Enter Valid Employee Id";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString();
        }
    }

    public void PopulateEarningDetails4EmplopyeeId(string strEmployeeId)
    {
        try
        {
            ds4EmployeeEarningDetails = objEmployeeEarningDetailsManager.GetEmployeeEarningDetails4ID(strEmployeeId);
            dt4EmployeeEarningDetails = ds4EmployeeEarningDetails.Tables[0];
            if (dt4EmployeeEarningDetails != null)
            {
                foreach (DataRow dr in dt4EmployeeEarningDetails.Rows)
                {
                    foreach (GridViewRow grd in grdTaxableEarning.Rows)
                    {
                        Label lbl_TaxableEarning = (Label)grd.FindControl("lbl_TaxableEarning");
                        TextBox txt_TaxableEarning = (TextBox)grd.FindControl("txt_TaxableEarning");

                        if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == Convert.ToString(dr["Allowances"]).Trim())
                        {
                            if (Convert.ToString(dr["Amount"]).Trim() != "")
                            {
                                txt_TaxableEarning.Text = Math.Round(CalculateMonth(Convert.ToDouble(dr["Amount"]))).ToString();
                            }
                            else
                            {
                                txt_TaxableEarning.Text = "0";
                            }
                        }
                    }
                }
            }
            BasicRate4HRAExm();
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString();
        }
    }

    public void PopulateDeductionDetails4EmplopyeeId(string strEmployeeId)
    {
        try
        {
            ds4EmployeeDeductionDetails = objEmployeeDeductionDetailsManager.GetEmployeeDeductionDetails4ID(strEmployeeId);
            dt4EmployeeDeductionDetails = ds4EmployeeDeductionDetails.Tables[0];
            if (dt4EmployeeDeductionDetails != null)
            {
                foreach (DataRow dr in dt4EmployeeDeductionDetails.Rows)
                {
                    foreach (GridViewRow grd in grdTaxableDeduction.Rows)
                    {
                        Label lbl_TaxableDeduction = (Label)grd.FindControl("lbl_TaxableDeduction");
                        TextBox txt_TaxableDeduction = (TextBox)grd.FindControl("txt_TaxableDeduction");
                        CheckBox chk_TaxableDeduction = (CheckBox)grd.FindControl("chk_TaxableDeduction");

                        if (Convert.ToString(lbl_TaxableDeduction.Text).Trim() == Convert.ToString(dr["Deductions"]).Trim())
                        {
                            if (Convert.ToString(dr["DeductionAmount"]).Trim() != "")
                            {
                                txt_TaxableDeduction.Text = Math.Round(CalculateMonth(Convert.ToDouble(dr["DeductionAmount"]))).ToString();
                                txt_TaxableDeduction.Enabled = false;
                                chk_TaxableDeduction.Visible = false;
                                chk_TaxableDeduction.Checked = true;
                            }
                            else
                            {
                                txt_TaxableDeduction.Text = "0";
                                chk_TaxableDeduction.Visible = true;
                                chk_TaxableDeduction.Checked = false;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString();
        }
    }
    #endregion

    #region Calculate INCOME & DEDUCTIONS
    public void CalculateGrossSalary()
    {
        double GrosSalary = 0;
        double TotalIncome = 0;
        //DataTable dt = (DataTable)Session["TaxableEarning"];
        foreach (GridViewRow grd in grdTaxableEarning.Rows)
        {
            Label lbl_TaxableEarning = (Label)grd.FindControl("lbl_TaxableEarning");
            TextBox txt_TaxableEarning = (TextBox)grd.FindControl("txt_TaxableEarning");

            if (txt_TaxableEarning.Text != "")
            {
                foreach (DataRow dr in dt4EmployeeEarningDetails.Rows)
                {
                    if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == Convert.ToString(dr["Allowances"]).Trim())
                    {
                        GrosSalary = Convert.ToDouble(GrosSalary + Convert.ToDouble(txt_TaxableEarning.Text));
                    }
                    else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() != Convert.ToString(dr["Allowances"]).Trim())
                    {
                        TotalIncome = GrosSalary + Convert.ToDouble(txt_TaxableEarning.Text);
                    }
                }

                if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "GROSS SALARY")
                {
                    txt_TaxableEarning.Text = Convert.ToString(GrosSalary);
                    txt_TaxableEarning.ForeColor = System.Drawing.Color.Black;
                    txt_TaxableEarning.Font.Bold = true;
                }
                else if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "TOTAL INCOME")
                {
                    txt_TaxableEarning.Text = Convert.ToString(TotalIncome);
                    txt_TaxableEarning.ForeColor = System.Drawing.Color.Black;
                    txt_TaxableEarning.Font.Bold = true;
                }

            }
        }
    }

    public void CalculateInvestMent()
    {
        double InvestMent = 0;

        foreach (GridViewRow grd in grdTaxableDeduction.Rows)
        {
            Label lbl_TaxableDeduction = (Label)grd.FindControl("lbl_TaxableDeduction");
            TextBox txt_TaxableDeduction = (TextBox)grd.FindControl("txt_TaxableDeduction");

            if (txt_TaxableDeduction.Text != "")
            {
                foreach (DataRow dr in dt4EmployeeDeductionDetails.Rows)
                {
                    if (Convert.ToString(lbl_TaxableDeduction.Text).Trim() == Convert.ToString(dr["Deductions"]).Trim())
                    {
                        InvestMent = Convert.ToDouble(InvestMent + Convert.ToDouble(txt_TaxableDeduction.Text));
                    }
                }

                if (lbl_TaxableDeduction.Text == "TOTAL INVESTMENTS")
                {
                    txt_TaxableDeduction.Text = Convert.ToString(InvestMent);
                    txt_TaxableDeduction.ForeColor = System.Drawing.Color.Black;
                    txt_TaxableDeduction.Font.Bold = true;
                }

                if (lbl_TaxableDeduction.Text == "TOTAL DEDUCTION")
                {
                    txt_TaxableDeduction.Text = Convert.ToString(InvestMent);
                    txt_TaxableDeduction.ForeColor = System.Drawing.Color.Black;
                    txt_TaxableDeduction.Font.Bold = true;
                }
            }
        }
    }

    public void CalculateTotalInvestMent()
    {
        double TotalInvestMent = 0;

        foreach (GridViewRow grd in grdTaxableDeduction.Rows)
        {
            Label lbl_TaxableDeduction = (Label)grd.FindControl("lbl_TaxableDeduction");
            TextBox txt_TaxableDeduction = (TextBox)grd.FindControl("txt_TaxableDeduction");
            CheckBox chk_TaxableDeduction = (CheckBox)grd.FindControl("chk_TaxableDeduction");

            if (txt_TaxableDeduction.Text != "")
            {
                TotalInvestMent = Convert.ToDouble(TotalInvestMent + Convert.ToDouble(txt_TaxableDeduction.Text));
            }
        }

        foreach (GridViewRow grd in grdTaxableDeduction.Rows)
        {
            Label lbl_TaxableDeduction = (Label)grd.FindControl("lbl_TaxableDeduction");
            TextBox txt_TaxableDeduction = (TextBox)grd.FindControl("txt_TaxableDeduction");
            CheckBox chk_TaxableDeduction = (CheckBox)grd.FindControl("chk_TaxableDeduction");

            if (txt_TaxableDeduction.Text != "")
            {
                if (lbl_TaxableDeduction.Text == "TOTAL INVESTMENTS")
                {
                    txt_TaxableDeduction.Text = Convert.ToString(TotalInvestMent);
                    txt_TaxableDeduction.ForeColor = System.Drawing.Color.Black;
                    txt_TaxableDeduction.Font.Bold = true;
                }

                if (lbl_TaxableDeduction.Text == "TOTAL DEDUCTION")
                {
                    txt_TaxableDeduction.Text = Convert.ToString(TotalInvestMent);
                    txt_TaxableDeduction.ForeColor = System.Drawing.Color.Black;
                    txt_TaxableDeduction.Font.Bold = true;
                }
            }
        }
    }
    #endregion

    #region Calculation
    public void CalculateTotalIncome()
    {
        double TotalIncome = 0;
        foreach (GridViewRow grd in grdTaxableEarning.Rows)
        {
            Label lbl_TaxableEarning = (Label)grd.FindControl("lbl_TaxableEarning");
            TextBox txt_TaxableEarning = (TextBox)grd.FindControl("txt_TaxableEarning");

            if (txt_TaxableEarning.Text != "")
            {
                TotalIncome = Convert.ToDouble(TotalIncome + Convert.ToDouble(txt_TaxableEarning.Text));

                if (lbl_TaxableEarning.Text == "TOTAL INCOME")
                {
                    txt_TaxableEarning.Text = Convert.ToString(TotalIncome);
                    txt_TaxableEarning.ForeColor = System.Drawing.Color.Black;
                    txt_TaxableEarning.Font.Bold = true;
                }
            }
        }
    }

    public void CalculateTotalDeduction()
    {
        //double TotalIncome = 0;
        //foreach (GridViewRow grd in grdTaxableDeduction.Rows)
        //{
        //    Label lbl_TaxableDeduction = (Label)grd.FindControl("lbl_TaxableDeduction");
        //    TextBox txt_TaxableDeduction = (TextBox)grd.FindControl("txt_TaxableDeduction");

        //    if (txt_TaxableDeduction.Text != "")
        //    {
        //        TotalIncome = Convert.ToDouble(TotalIncome + Convert.ToDouble(txt_TaxableDeduction.Text));

        //        if (lbl_TaxableDeduction.Text == "TOTAL INCOME")
        //        {
        //            txt_TaxableEarning.Text = Convert.ToString(TotalIncome);
        //            txt_TaxableEarning.ForeColor = System.Drawing.Color.Black;
        //            txt_TaxableEarning.Font.Bold = true;
        //        }
        //    }
        //}
    }
    #endregion

    #region HRA Exemption
    public void BasicRate4HRAExm()
    {
        double Basic = 0;
        double PercenteOfBasic = 0;

        DataSet ds=objEmployeeMasterDetailsManager.GetEmployeeMaster4ID(Convert.ToString(txtCode.Text));

        foreach (GridViewRow grd in grdTaxableEarning.Rows)
        {
            Label lbl_TaxableEarning = (Label)grd.FindControl("lbl_TaxableEarning");
            TextBox txt_TaxableEarning = (TextBox)grd.FindControl("txt_TaxableEarning");

            if (Convert.ToString(lbl_TaxableEarning.Text).Trim() == "BASIC")
            {
                if (Convert.ToString(txt_TaxableEarning.Text).Trim() != "")
                {
                    Basic = Math.Round(Convert.ToDouble(Convert.ToDouble(txt_TaxableEarning.Text) * 10) / 100);
                    if (ds != null && ds.Tables[0].Rows.Count >0)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[0]["CityType"]).Trim() == "NM")
                        {
                            PercenteOfBasic = Math.Round(Convert.ToDouble(Convert.ToDouble(txt_TaxableEarning.Text) * 40) / 100);
                        }
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["CityType"]).Trim() == "M")
                        {
                            PercenteOfBasic = Math.Round(Convert.ToDouble(Convert.ToDouble(txt_TaxableEarning.Text) * 50) / 100);
                        }
                    }
                    txt10PercentOfBasic.Text = Convert.ToString(Basic);
                    txt4050PercentOfBasic.Text = Convert.ToString(PercenteOfBasic);
                }
            }
        }
    }
    #endregion

    #region Calculate Month & Days
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

    public double CalculateMonth(double Amount)
    {
        double AnnumSalary = 0;
        int days = 0, days1 = 0;
        int months = 0, months1 = 0;
        int years = 0, years1 = 0;

        DateTime dt1 = Convert.ToDateTime(Pages_Employee_frmTaxCalculator.ToDateTime1(txtDateOfJoining.Text));
        DateTime dt2 = Convert.ToDateTime(Pages_Employee_frmTaxCalculator.ToDateTime1("31/03/2014"));

        dt1 = dt1.Date;
        dt2 = dt2.Date;

        days = dt2.Day - dt1.Day;
        if (days < 0)
        {
            var newNow = dt2.AddMonths(-1);
            days += (int)(dt2 - newNow).TotalDays;
            dt2 = newNow;
        }
        months = dt2.Month - dt1.Month;
        if (months < 0)
        {
            months += 12;
            dt2 = dt2.AddYears(-1);
        }
        years = dt2.Year - dt1.Year;
        if (years == 0)
        {
            if (months == 0)
            {
                days1 = days;
            }
            else if (days >= 0)
            {
                months1 = months;
                days1 = days;
            }
        }

        int daysInMonth = SalaryCalculationDays(dt1.Month);

        if (days1 == 0)
        {
            AnnumSalary = Amount * months1;
        }
        else
        {
            if ((days1 + 1) == daysInMonth)
            {
                days1 = 0;
                months1 = months1 + 1;
                AnnumSalary = Amount * months1 + (Amount / daysInMonth) * (days1 + 1);
            }
            else
            {
                AnnumSalary = Amount * months1 + (Amount / daysInMonth) * (days1);
            }
        }

        return AnnumSalary;
    }
    #endregion

    #region Calculate Tax Payble Amount
    public void TaxableIncome()
    {
        double TotalIncome = 0;
        double TotalInvestMent = 0;
        double TaxPayableAmount = 0;

        foreach (GridViewRow grd in grdTaxableEarning.Rows)
        {
            Label lbl_TaxableEarning = (Label)grd.FindControl("lbl_TaxableEarning");
            TextBox txt_TaxableEarning = (TextBox)grd.FindControl("txt_TaxableEarning");

            if (txt_TaxableEarning.Text != "")
            {
                if (lbl_TaxableEarning.Text == "TOTAL INCOME")
                {
                    TotalIncome = Convert.ToDouble(txt_TaxableEarning.Text);
                }
            }
        }

        foreach (GridViewRow grd in grdTaxableDeduction.Rows)
        {
            Label lbl_TaxableDeduction = (Label)grd.FindControl("lbl_TaxableDeduction");
            TextBox txt_TaxableDeduction = (TextBox)grd.FindControl("txt_TaxableDeduction");

            if (txt_TaxableDeduction.Text != "")
            {
                if (lbl_TaxableDeduction.Text == "TOTAL DEDUCTION")
                {
                    TotalInvestMent = Convert.ToDouble(txt_TaxableDeduction.Text);
                }
            }
        }

        TaxPayableAmount = TotalIncome - TotalInvestMent;

        foreach (GridViewRow grd in grdTaxableDeduction.Rows)
        {
            Label lbl_TaxableDeduction = (Label)grd.FindControl("lbl_TaxableDeduction");
            TextBox txt_TaxableDeduction = (TextBox)grd.FindControl("txt_TaxableDeduction");

            if (txt_TaxableDeduction.Text != "")
            {
                if (lbl_TaxableDeduction.Text == "TAXABLE INCOME")
                {
                    txt_TaxableDeduction.Text = Convert.ToString(TaxPayableAmount);
                }
            }
        }
    }

    public void TaxaPayableAmount()
    {
        double TaxPayableAmount = 0;
        double TaxableIncome = 0;
        double TaxableDifference = 0;
        double EducationCessAmount = 0;

        foreach (GridViewRow grd in grdTaxableDeduction.Rows)
        {
            Label lbl_TaxableDeduction = (Label)grd.FindControl("lbl_TaxableDeduction");
            TextBox txt_TaxableDeduction = (TextBox)grd.FindControl("txt_TaxableDeduction");

            if (txt_TaxableDeduction.Text != "")
            {
                if (lbl_TaxableDeduction.Text == "TAXABLE INCOME")
                {
                    TaxableIncome = Convert.ToDouble(txt_TaxableDeduction.Text);
                }
            }
        }

        if (TaxableIncome <= 200000)
        {
            TaxPayableAmount = 0;
        }
        else if (TaxableIncome > 200000 && TaxableIncome <= 500000)
        {
            TaxableDifference = TaxableIncome - 200000;
            TaxPayableAmount = TaxPayableAmount + (TaxableDifference * 10) / 100;
        }
        else if (TaxableIncome > 500000 && TaxableIncome <= 1000000)
        {
            TaxableDifference = 500000 - 200000;
            TaxPayableAmount = TaxPayableAmount + (TaxableDifference * 10) / 100;

            if (TaxableIncome > 500000)
            {
                TaxableDifference = TaxableIncome - 500000;
                TaxPayableAmount = TaxPayableAmount + (TaxableDifference * 20) / 100;
            }
        }
        else if (TaxableIncome > 1000000)
        {
            TaxableDifference = 500000 - 200000;
            TaxPayableAmount = TaxPayableAmount + (TaxableDifference * 10) / 100;

            if (TaxableIncome > 500000 && TaxableIncome > 1000000)
            {
                TaxableDifference = 1000000 - 500000;
                TaxPayableAmount = TaxPayableAmount + (TaxableDifference * 20) / 100;
            }
            else if (TaxableIncome > 1000000)
            {
                TaxableDifference = TaxableIncome - 1000000;
                TaxPayableAmount = TaxPayableAmount + (TaxableDifference * 30) / 100;
            }
        }

        EducationCessAmount = TaxPayableAmount * 3 / 100;

        foreach (GridViewRow grd in grdTaxableDeduction.Rows)
        {
            Label lbl_TaxableDeduction = (Label)grd.FindControl("lbl_TaxableDeduction");
            TextBox txt_TaxableDeduction = (TextBox)grd.FindControl("txt_TaxableDeduction");

            if (txt_TaxableDeduction.Text != "")
            {
                if (lbl_TaxableDeduction.Text == "TAX ON TOTAL INCOME")
                {
                    txt_TaxableDeduction.Text = Convert.ToString(Math.Round(TaxPayableAmount));
                }
                else if (lbl_TaxableDeduction.Text == "EDU. CESS 3%")
                {
                    txt_TaxableDeduction.Text = Convert.ToString(Math.Round(EducationCessAmount));
                }
                else if (lbl_TaxableDeduction.Text == "ANNUAL TAX LIABILITY")
                {
                    txt_TaxableDeduction.Text = Convert.ToString(Math.Round(TaxPayableAmount + EducationCessAmount));
                }
                else if (lbl_TaxableDeduction.Text == "TAX PAYABLE")
                {
                    txt_TaxableDeduction.Text = Convert.ToString(Math.Round(TaxPayableAmount + EducationCessAmount));
                }
            }
        }
    }

    public int GetNumberUnit(int Length)
    {
        int numberUnit = 0;

        switch (Length)
        {

            case (3):
                numberUnit = 100;
                return numberUnit;

            case (4):
                numberUnit = 1000;
                return numberUnit;

            case (5):
                numberUnit = 10000;
                return numberUnit;

            case (6):
                numberUnit = 100000;
                return numberUnit;

            case (7):
                numberUnit = 1000000;
                return numberUnit;

            case (8):
                numberUnit = 10000000;
                return numberUnit;

            case (9):
                numberUnit = 100000000;
                return numberUnit;

            case (10):
                numberUnit = 1000000000;
                return numberUnit;

            default:
                Console.WriteLine("Error");
                return 0;
        }
    }
    #endregion

    #region Generate Id
    public int GetTDSEarningId()
    {
        int TDSEarningId = 0;
        DataSet ds4TDSEarningId = new DataSet();
        try
        {
            ds4TDSEarningId = objTaxCalculationMasterManager.GenerateTDSEarningId();
            if (ds4TDSEarningId != null)
            {
                TDSEarningId = Convert.ToInt32(ds4TDSEarningId.Tables[0].Rows[0]["TDSNo"]) + 1;
            }

        }
        catch (Exception ex)
        {
            TDSEarningId = TDSEarningId + 1;
        }
        return TDSEarningId;
    }

    public int GetTDSDeductionId()
    {
        int TDSDeductionId = 0;
        DataSet ds4TdSDeduction = new DataSet();
        try
        {
            ds4TdSDeduction = objTaxCalculationMaster4DeductionManager.GenerateTDSDeductiond();
            if (ds4TdSDeduction != null)
            {
                TDSDeductionId = Convert.ToInt32(ds4TdSDeduction.Tables[0].Rows[0]["TDSNo"]) + 1;
            }
        }
        catch (Exception ex)
        {
            TDSDeductionId = TDSDeductionId + 1;
        }
        return TDSDeductionId;
    }
    #endregion

}