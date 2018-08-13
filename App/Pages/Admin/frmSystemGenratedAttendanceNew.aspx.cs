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
using System.Text;

#region Development Details
//Shruti Dwivedi(25-09-2013)
#endregion Development Details

public partial class Pages_Admin_frmSystemGenratedAttendanceNew : System.Web.UI.Page
{
    #region Global Variable Declaration
    BindComboMasterManager _objBindComboMasterManager = new BindComboMasterManager();
    ReportMasterManager _objReportMasterManager = new ReportMasterManager();
    decimal GrossBasicPay = 0;
    decimal BasicPayG=0;
    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                BindFinyear();
                BindAllEmployee();
                //ddlMonth.SelectedValue = Convert.ToString(DateTime.Now.Month);
               // DDLYear.SelectedValue = Convert.ToString(DateTime.Now.Year);
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }

    }
    protected void btnCalculateSalary_Click(object sender, EventArgs e)
    {

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void btnNext_Click(object sender, EventArgs e)
    {

    }
    protected void DDLYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEmployee.SelectedItem.Text != "Select" && ddlMonth.SelectedItem.Text != "Select" && DDLYear.SelectedItem.Text != "Select")
        {
            Calculate();
            //BindGridview(ds.Tables[2], ds.Tables[3]);
        }
       
    }
    protected void gdvAllowane_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox EarningBasicPAy = (TextBox)e.Row.FindControl("txtEarningAmount");
            Label Allowance = (Label)e.Row.FindControl("lblAllowance");
            Label AllowanceAmount = (Label)e.Row.FindControl("lblAmount");
           // AllowanceAmount.Text = Math.Round(Convert.ToDecimal(AllowanceAmount)).ToString();
            AllowanceAmount.Text = Math.Round(Convert.ToDecimal(AllowanceAmount.Text)).ToString();
            if (Allowance.Text == "BASIC")
            {
              
                decimal BasicPAy;
                BasicPAy = (Convert.ToDecimal(AllowanceAmount.Text) * Convert.ToDecimal(txtPaidDays.Text)) / Convert.ToDecimal(txtTotalDays.Text);
                BasicPayG = Math.Round(BasicPAy);
                //EarningBasicPAy.Text = hdnWorkingSalary.Value;
                EarningBasicPAy.Text = Math.Round(BasicPAy).ToString();
                GrossBasicPay = Math.Round(BasicPAy);
            }
            else if (Allowance.Text == "D.A" || Allowance.Text == "D.A.")
            {
                decimal DA;
                DA = (Convert.ToDecimal(AllowanceAmount.Text) * Convert.ToDecimal(txtPaidDays.Text)) / Convert.ToDecimal(txtTotalDays.Text);
                EarningBasicPAy.Text = Math.Round(DA).ToString();
                GrossBasicPay = GrossBasicPay + Math.Round(DA);
            }
            else if (Allowance.Text == "HRA")
            {
                decimal HRA;
                HRA = (Convert.ToDecimal(AllowanceAmount.Text) * Convert.ToDecimal(txtPaidDays.Text)) / Convert.ToDecimal(txtTotalDays.Text);
                EarningBasicPAy.Text = Math.Round(HRA).ToString();
                GrossBasicPay = GrossBasicPay + Math.Round(HRA);
            }
            else if (Allowance.Text=="CONVEYANCE")
            {
                decimal CONVEYANCE;
                CONVEYANCE = (Convert.ToDecimal(AllowanceAmount.Text) * Convert.ToDecimal(txtPaidDays.Text)) / Convert.ToDecimal(txtTotalDays.Text);
                EarningBasicPAy.Text = Math.Round(CONVEYANCE).ToString();
                GrossBasicPay = GrossBasicPay + Math.Round(CONVEYANCE);
            }
            else if (Allowance.Text == "MEDICAL")
            {
                decimal MEDICAL;
                MEDICAL = (Convert.ToDecimal(AllowanceAmount.Text) * Convert.ToDecimal(txtPaidDays.Text)) / Convert.ToDecimal(txtTotalDays.Text);
                EarningBasicPAy.Text = Math.Round(MEDICAL).ToString();
                GrossBasicPay = GrossBasicPay + Math.Round(MEDICAL);
            }
            EarningBasicPAy.Enabled = false;
            //for (int i = 0; i < gdvAllowane.Rows.Count; i++)
            // {
            //str=Convert.ToDecimal(gdvAllowane.Rows[i].FindControl("txtEarningAmount"));
            //  TotalEarning = TotalEarning + str;
            //}
            //hdnTotalEarning.Value = (TotalEarning + Convert.ToDecimal(Allowance.Text)).ToString();
        }
    }
    protected void gdvDeduction_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label Deduction = (Label)e.Row.FindControl("lblDeduction");
            Label DeductionAmount = (Label)e.Row.FindControl("lblDeductionAmt");

            Label perc = (Label)e.Row.FindControl("lblDeductionPercentage");
            Label LimitAmount = (Label)e.Row.FindControl("lblLimit");
            TextBox EarningDeduction = (TextBox)e.Row.FindControl("txtEarningDeduction");
            

            DeductionAmount.Text = Math.Round(Convert.ToDecimal(DeductionAmount.Text)).ToString();
           // perc.Text = Math.Round(Convert.ToDecimal(perc.Text)).ToString();
            LimitAmount.Text = Math.Round(Convert.ToDecimal(LimitAmount.Text)).ToString();
            if (LimitAmount.Text == "0")
            {
                LimitAmount.Text = "";
            }

            if (Deduction.Text == "EPF")
            {
                decimal EPF;
                if (LimitAmount.Text != "" && BasicPayG >= Convert.ToDecimal(LimitAmount.Text))
                {
                    EPF = Convert.ToDecimal(LimitAmount.Text) * Convert.ToDecimal(perc.Text) / 100;
                    EarningDeduction.Text = Math.Round(EPF).ToString();
                    EarningDeduction.Enabled = false;
                }
                else
                {
                    EPF = BasicPayG * Convert.ToDecimal(perc.Text) / 100;
                    EarningDeduction.Text = Math.Round(EPF).ToString();
                    EarningDeduction.Enabled = false;
                    //EarningDeduction.Text = (Convert.ToDecimal(hdnWorkingSalary.Value) * Convert.ToDecimal(perc.Text) / 100).ToString();
                }
            }
            else if (Deduction.Text == "ESI")
            {
                if (GrossBasicPay <= 15000)
                {
                    decimal ESI = GrossBasicPay * Convert.ToDecimal(perc.Text) / 100;
                    EarningDeduction.Text = Math.Round(ESI).ToString();
                    EarningDeduction.Enabled = false;
                }
                else
                {
                    EarningDeduction.Text = "0";
                    EarningDeduction.Enabled = false;
                }
            }

            foreach (DataControlField col in gdvDeduction.Columns)
            {
                if (col.HeaderText == "Amount")
                {
                    col.Visible = false;
                }
            }

           // DeductionAmount.Visible = false;
            //else
            //{
            //    EarningDeduction.Text = (Convert.ToDecimal(hdnTotalEarning.Value) * Convert.ToDecimal(perc.Text) / 100).ToString();
            //}

        }

    }

    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLYear.SelectedItem.Text != "Select")
        {
            Calculate();
        }
    }
    #endregion Page Event

    #region Page Specific Function
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


        //dr["val"] = finyear;
        //dr["txt"] = finyear;

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

        DDLYear.DataSource = GetFinYear(DateTime.Now.ToString());
        DDLYear.DataTextField = GetFinYear(DateTime.Now.ToString()).Columns["txt"].ToString();
        DDLYear.DataValueField = GetFinYear(DateTime.Now.ToString()).Columns["val"].ToString();
        DDLYear.DataBind();
        DDLYear.Items.Insert(0, "Select");

    }
    private void BindAllEmployee()
    {
        DataTable _dt = _objBindComboMasterManager.GetAllEmployee();
        ddlEmployee.DataSource = _dt;
        ddlEmployee.DataTextField = _dt.Columns["txt"].ToString();
        ddlEmployee.DataValueField = _dt.Columns["val"].ToString();
        ddlEmployee.DataBind();
        ddlEmployee.Items.Insert(0, "Select");
    }
    private void AssignVariabletoControl(DataTable _dt)
    {
        txtCode.Text = _dt.Rows[0]["EmployeeId"].ToString();
        txtName.Text = _dt.Rows[0]["Name"].ToString();
        txtEmail.Text = _dt.Rows[0]["EmailId"].ToString();
        txtDateOfJoining.Text = _dt.Rows[0]["JoiningDate"].ToString();
        txtfhName.Text = _dt.Rows[0]["FatherName"].ToString();
    }
    private void AssignVariableToControlForAttendance(DataTable _dt)
    {
        txtTotalDays.Text = _dt.Rows[0]["TotalDaysinMonth"].ToString();
        txtWeeklyOff1.Text = _dt.Rows[0]["NoofWeekOffDays"].ToString();
        txtPresent.Text = _dt.Rows[0]["NoofPresentDays"].ToString();
        txtAbsent.Text = _dt.Rows[0]["NotComingDayswithoutAnyLeave"].ToString();

        txtCEL1.Text = _dt.Rows[0]["Alloted_CEL"].ToString();
        txtCEL2.Text = _dt.Rows[0]["Uded_CEL"].ToString();
        txtCEL3.Text = _dt.Rows[0]["Balance_CEL"].ToString();

        txtNCEL1.Text = _dt.Rows[0]["Alloted_NCEL"].ToString();
        txtNCEL2.Text = _dt.Rows[0]["Uded_NCEL"].ToString();
        txtNCEL3.Text = _dt.Rows[0]["Balance_NCEL"].ToString();

        txtPaternity1.Text = _dt.Rows[0]["Alloted_PL"].ToString();
        txtPaternity2.Text = _dt.Rows[0]["Uded_PL"].ToString();
        txtPaternity3.Text = _dt.Rows[0]["Balance_PL"].ToString();

        txtMaternity1.Text = _dt.Rows[0]["Alloted_ML"].ToString();
        txtMaternity2.Text = _dt.Rows[0]["Uded_ML"].ToString(); ;
        txtMaternity3.Text = _dt.Rows[0]["Balance_ML"].ToString();

        txtRestrictedHolidyas1.Text = _dt.Rows[0]["Alloted_RH"].ToString();
        txtRestrictedHolidyas2.Text = _dt.Rows[0]["Uded_RH"].ToString();
        txtRestrictedHolidyas3.Text = _dt.Rows[0]["Balance_RH"].ToString();

        txtCL1.Text = _dt.Rows[0]["Alloted_CL"].ToString();
        txtCL2.Text = _dt.Rows[0]["Uded_CL"].ToString();
        txtCL3.Text = _dt.Rows[0]["Balance_CL"].ToString();

        txtL11.Text = _dt.Rows[0]["Alloted_L1"].ToString();
        txtL12.Text = _dt.Rows[0]["Uded_L1"].ToString();
        txtL13.Text = _dt.Rows[0]["Balance_L1"].ToString();

        txtL21.Text = _dt.Rows[0]["Alloted_L2"].ToString();
        txtL22.Text = _dt.Rows[0]["Uded_L2"].ToString();
        txtL23.Text = _dt.Rows[0]["Balance_L2"].ToString();

        txtL31.Text = _dt.Rows[0]["Alloted_L3"].ToString();
        txtL32.Text = _dt.Rows[0]["Uded_L3"].ToString();
        txtL33.Text = _dt.Rows[0]["Balance_L3"].ToString();

        txtHPL1.Text = _dt.Rows[0]["Alloted_HPL"].ToString();
        txtHPL2.Text = _dt.Rows[0]["Uded_HPL"].ToString();
        txtHPL3.Text = _dt.Rows[0]["Balance_HPL"].ToString();

        txtPaidDays.Text = _dt.Rows[0]["PaidDay"].ToString();
        txtlHalfday.Text = _dt.Rows[0]["HalfDay"].ToString();
        //txtlateComingDay.Text = _dt.Rows[0]["LateComingDay"].ToString();
        //txtNotMarkoutDay.Text = _dt.Rows[0]["NotSameDayMarkoutDay"].ToString();
        hdnPaidDays.Value = txtPaidDays.Text;
        //if (Convert.ToInt32(txtlHalfday.Text) / 2 == 0)
        //{
        //}

        txtHolidays.Text = _dt.Rows[0]["Holiday"].ToString();

        decimal BesicSalary=Convert.ToDecimal(_dt.Rows[0]["BasicSalary"].ToString());
        decimal TotalDay = Convert.ToDecimal(_dt.Rows[0]["TotalDaysinMonth"].ToString());
        decimal WorkingSalary = 0;
        decimal PaidDays = Convert.ToDecimal(_dt.Rows[0]["PaidDay"].ToString());
        WorkingSalary = BesicSalary * PaidDays / TotalDay;
        hdnWorkingSalary.Value = WorkingSalary.ToString("F1");
        txtEarnSalary.Text = hdnWorkingSalary.Value; ;
    }
    private void BindAllowanceGridview(DataTable _dt1)
    {
        gdvAllowane.DataSource = _dt1;
        gdvAllowane.DataBind();

       

    }
    private void BindDeductionGridview(DataTable _dt2)
    {
        gdvDeduction.DataSource = _dt2;
        gdvDeduction.DataBind();
    }
    private void Calculationone()
    {
        decimal TotalEarning = 0;
        for (int i = 0; i < gdvAllowane.Rows.Count; i++)
        {
            Label Allowance = (Label)gdvAllowane.Rows[i].FindControl("lblAllowance");
            TextBox EarningGrossPAy = (TextBox)gdvAllowane.Rows[i].FindControl("txtEarningAmount");

            if (Allowance.Text == "BASIC")
            {
                if (Convert.ToDecimal(EarningGrossPAy.Text) > 15000)
                {
                    TotalEarning = TotalEarning + Convert.ToDecimal(0);
                }
                else
                {
                    TotalEarning = TotalEarning + Convert.ToDecimal(EarningGrossPAy.Text);
                }
            }
            else
            {
                TotalEarning = TotalEarning + Convert.ToDecimal(EarningGrossPAy.Text);
            }


        }
        hdnTotalEarning.Value = TotalEarning.ToString();
        //lblMsg.Text = hdnTotalEarning.Value;
    }
    private void EnableandDisableControl(bool value)
    {
        txtTotalDays.Enabled = value;
        txtWeeklyOff1.Enabled = value;
        txtPresent.Enabled = value;
        txtAbsent.Enabled = value;

        txtCEL1.Enabled = value;
        txtCEL2.Enabled = value;
        txtCEL3.Enabled = value;

        txtNCEL1.Enabled = value;
        txtNCEL2.Enabled = value;
        txtNCEL3.Enabled = value;

        txtPaternity1.Enabled = value;
        txtPaternity2.Enabled = value;
        txtPaternity3.Enabled = value;

        txtMaternity1.Enabled = value;
        txtMaternity2.Enabled = value;
        txtMaternity3.Enabled = value;

        txtRestrictedHolidyas1.Enabled = value;
        txtRestrictedHolidyas2.Enabled = value;
        txtRestrictedHolidyas3.Enabled = value;

        txtCL1.Enabled = value;
        txtCL2.Enabled = value;
        txtCL3.Enabled = value;

        txtL11.Enabled = value;
        txtL12.Enabled = value;
        txtL13.Enabled = value;

        txtL21.Enabled = value;
        txtL22.Enabled = value;
        txtL23.Enabled = value;

        txtL31.Enabled = value;
        txtL32.Enabled = value;
        txtL33.Enabled = value;

        txtHPL1.Enabled = value;
        txtHPL2.Enabled = value;
        txtHPL3.Enabled = value;

        txtPaidDays.Enabled = value;

        txtlateComingDay.Enabled = value;
        txtNotMarkoutDay.Enabled = value;
        txtHolidays.Enabled = value;
        txtlHalfday.Enabled = value;
    }
    private void Calculate()
    {
        DataSet ds = _objReportMasterManager.SystemGenratedMonthlyAttendance(Convert.ToInt32(DDLYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue), ddlEmployee.SelectedValue);
        AssignVariabletoControl(ds.Tables[1]);
        AssignVariableToControlForAttendance(ds.Tables[0]);
        BindAllowanceGridview(ds.Tables[2]);
        Calculationone();
        BindDeductionGridview(ds.Tables[3]);
        EnableandDisableControl(false);
    }
    #endregion Page Specific Function

   
}