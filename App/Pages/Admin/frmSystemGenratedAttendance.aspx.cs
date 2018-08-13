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

public partial class Pages_Admin_frmSystemGenratedAttendance : System.Web.UI.Page
{
    #region Global Variable Declaration
    BindComboMasterManager _objBindComboMasterManager = new BindComboMasterManager();
    ReportMasterManager _objReportMasterManager = new ReportMasterManager();
    EmployeeMontlyAttendanceMasterManager objEmployeeMontlyAttendanceMasterManager = new EmployeeMontlyAttendanceMasterManager();

    DataSet ds4EmployeeEarningDetails = new DataSet();
    DataTable dt4EmployeeEarning = new DataTable();

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
    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEmployee.SelectedIndex > 0 && ddlMonth.SelectedIndex > 0 && DDLYear.SelectedIndex > 0)
        {
            Calculate();
            BindAllowances(Convert.ToString(ddlEmployee.SelectedValue).Trim());
            ProcessSalary();
            CalculateTotalSalary();
        }
    }
    protected void DDLYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEmployee.SelectedIndex > 0 && ddlMonth.SelectedIndex > 0 && DDLYear.SelectedIndex > 0)
        {
            
            Calculate();
            string []DOJMonth=txtDateOfJoining.Text.Split('/');
            if (Convert.ToInt32(ddlMonth.SelectedValue) < Convert.ToInt32(DOJMonth[1]))
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Please ensure that the Salary Date is greater than to the Date Of Joining";
                AssignVariableToControlForAttendance("");
                BindAllowances("");
            }
            else
            {
                lblMsg.Text = "";
                BindAllowances(Convert.ToString(ddlEmployee.SelectedValue).Trim());
                ProcessSalary();
                CalculateTotalSalary();
            }
               
            
        }
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlEmployee.SelectedIndex > 0 && ddlMonth.SelectedIndex > 0 && DDLYear.SelectedIndex > 0)
        //{
        //    string []Month=txtDateOfJoining.Text.Split('/');
        //    if (Convert.ToInt32(ddlMonth.SelectedValue) < Convert.ToInt32(Month[1].ToString()))
        //    {
        //        lblMsg.Text = "Please ensure that the Salary Date is greater than to the Date Of Joining";
        //    }
        //    else
        //    {

        //    Calculate();
        //    BindAllowances(Convert.ToString(ddlEmployee.SelectedValue).Trim());
        //    ProcessSalary();
        //    CalculateTotalSalary();
        //    }
        //}
        if (ddlEmployee.SelectedIndex > 0 && ddlMonth.SelectedIndex > 0 && DDLYear.SelectedIndex > 0)
        {
           
            Calculate();
            string[] DOJMonth = txtDateOfJoining.Text.Split('/');
            if (Convert.ToInt32(ddlMonth.SelectedValue) < Convert.ToInt32(DOJMonth[1]))
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Font.Bold = true;
                lblMsg.Text = "Please ensure that the Salary Date is greater than to the Date Of Joining";
                AssignVariableToControlForAttendance("");
                BindAllowances("");
            }
            else
            {
                lblMsg.Text = "";
                BindAllowances(Convert.ToString(ddlEmployee.SelectedValue).Trim());
                ProcessSalary();
                CalculateTotalSalary();
            }


        }
    }
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
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
        txtPaidDays.Text = Convert.ToDecimal(_dt.Rows[0]["PaidDay"].ToString()).ToString("F");
       // txtPaidDays.Text = Math.Round(Convert.ToDecimal(txtPaidDays.Text)).ToString();
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
        txtEarnSalary.Text = hdnWorkingSalary.Value;
        txtEarnSalary.Text = Math.Round(Convert.ToDecimal(txtEarnSalary.Text)).ToString();

        txtArrPaidDays.Text = Convert.ToDecimal(_dt.Rows[0]["PaidDay"].ToString()).ToString("F");
        txtPfPaidDays.Text = Convert.ToDecimal(_dt.Rows[0]["PaidDay"].ToString()).ToString("F");
        txtEsiPaidDays.Text = Convert.ToDecimal(_dt.Rows[0]["PaidDay"].ToString()).ToString("F");

       

    }
    private void AssignVariableToControlForAttendance(string Data)
    {
        txtTotalDays.Text = Data;
        txtWeeklyOff1.Text = Data;
        txtPresent.Text = Data;
        txtAbsent.Text = Data;

        txtCEL1.Text = Data;
        txtCEL2.Text = Data;
        txtCEL3.Text = Data;

        txtNCEL1.Text = Data;
        txtNCEL2.Text = Data;
        txtNCEL3.Text = Data;

        txtPaternity1.Text = Data;
        txtPaternity2.Text = Data;
        txtPaternity3.Text = Data;

        txtMaternity1.Text = Data;
        txtMaternity2.Text = Data;
        txtMaternity3.Text = Data;

        txtRestrictedHolidyas1.Text = Data;
        txtRestrictedHolidyas2.Text = Data;
        txtRestrictedHolidyas3.Text = Data;

        txtCL1.Text = Data;
        txtCL2.Text = Data;
        txtCL3.Text = Data;

        txtL11.Text = Data;
        txtL12.Text = Data;
        txtL13.Text = Data;

        txtL21.Text = Data;
        txtL22.Text = Data;
        txtL23.Text = Data;

        txtL31.Text = Data;
        txtL32.Text = Data;
        txtL33.Text = Data;

        txtHPL1.Text = Data;
        txtHPL2.Text = Data;
        txtHPL3.Text = Data;

        txtPaidDays.Text = Data;
        //txtPaidDays.Text = Convert.ToDecimal(_dt.Rows[0]["PaidDay"].ToString()).ToString("F");
        // txtPaidDays.Text = Math.Round(Convert.ToDecimal(txtPaidDays.Text)).ToString();
        txtlHalfday.Text = Data;
        //txtlateComingDay.Text = _dt.Rows[0]["LateComingDay"].ToString();
        //txtNotMarkoutDay.Text = _dt.Rows[0]["NotSameDayMarkoutDay"].ToString();
        hdnPaidDays.Value = Data;
        //if (Convert.ToInt32(txtlHalfday.Text) / 2 == 0)
        //{
        //}

        txtHolidays.Text = Data;

        //decimal BesicSalary = Convert.ToDecimal(_dt.Rows[0]["BasicSalary"].ToString());
        //decimal TotalDay = Convert.ToDecimal(_dt.Rows[0]["TotalDaysinMonth"].ToString());
        //decimal WorkingSalary = 0;
        //decimal PaidDays = Convert.ToDecimal(_dt.Rows[0]["PaidDay"].ToString());
       
       // WorkingSalary = BesicSalary * PaidDays / TotalDay;
        //hdnWorkingSalary.Value = WorkingSalary.ToString("F1");
        txtEarnSalary.Text = Data;
        txtEarnSalary.Text = Data;

        txtArrPaidDays.Text = Data;
        txtPfPaidDays.Text = Data;
        txtEsiPaidDays.Text = Data;



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
    public void setObjectInfor4Attendance(EmployeeMontlyAttendance objEmployeeMontlyAttendance)
    {
        objEmployeeMontlyAttendance.EmployeeId = Convert.ToString(txtCode.Text).Trim();
        objEmployeeMontlyAttendance.Month = Convert.ToString(ddlMonth.SelectedValue).Trim();
        objEmployeeMontlyAttendance.Year = Convert.ToString(DDLYear.SelectedValue).Trim();

        //objEmployeeMontlyAttendance.SalaryProcessDate = Convert.ToString(txtSalaryProcessDate.Text).Trim();
        objEmployeeMontlyAttendance.SalaryCalculationDate = DateTime.Now.ToString();
        objEmployeeMontlyAttendance.HPL = txtHPL2.Text;

        objEmployeeMontlyAttendance.TotalMontrhInDays = Convert.ToInt32(txtTotalDays.Text);

        objEmployeeMontlyAttendance.OverTime = Convert.ToInt32(txtOverTimeHour.Text);
        objEmployeeMontlyAttendance.OverTimeAmount = txtOverTimeAmount.Text;
        objEmployeeMontlyAttendance.CalcOverTimeAmount = txtTotalOvertimeAmt.Text;

        objEmployeeMontlyAttendance.ActualEarnSalary = txtEarnSalary.Text;
        objEmployeeMontlyAttendance.IsSytemCalucalted = true;
        objEmployeeMontlyAttendance.NCEL = txtNCEL2.Text;
        objEmployeeMontlyAttendance.CEL = txtCL2.Text;
        objEmployeeMontlyAttendance.Paternity = txtPaternity2.Text;
        objEmployeeMontlyAttendance.HalfDay = txtlHalfday.Text;

        objEmployeeMontlyAttendance.Absent = Convert.ToInt32(txtAbsent.Text);
        objEmployeeMontlyAttendance.Holidays = Convert.ToInt32(txtHolidays.Text);
        objEmployeeMontlyAttendance.Present = Convert.ToInt32(txtPresent.Text);
        objEmployeeMontlyAttendance.WeekOff = Convert.ToInt32(txtWeeklyOff1.Text);
        //HPL-----------------------
        //objEmployeeMontlyAttendance.EL = Convert.ToInt32(txtEL4Days.Text);
        objEmployeeMontlyAttendance.CL = Convert.ToInt32(txtCL2.Text);
       // objEmployeeMontlyAttendance.SL = Convert.ToInt32(txtSL4Days.Text);
        objEmployeeMontlyAttendance.L1 = Convert.ToInt32(txtL12.Text);
        objEmployeeMontlyAttendance.L2 = Convert.ToInt32(txtL22.Text);
        objEmployeeMontlyAttendance.L3 = Convert.ToInt32(txtL32.Text);

        objEmployeeMontlyAttendance.PaidDays = Convert.ToString(txtPaidDays.Text);
        objEmployeeMontlyAttendance.RstHoliDays = Convert.ToInt32(txtRestrictedHolidyas2.Text);
        objEmployeeMontlyAttendance.Maternity = Convert.ToInt32(txtMaternity2.Text);
        //objEmployeeMontlyAttendance.DayWork = Convert.ToInt32(txtDayWork.Text);

        //objEmployeeMontlyAttendance.ArrPaidDays = Convert.ToInt32(txtArrPaidDays.Text);
        //objEmployeeMontlyAttendance.PFPaidDays = Convert.ToInt32(txtPfPaidDays.Text);
        //objEmployeeMontlyAttendance.ESIPaidDays = Convert.ToInt32(txtEsiPaidDays.Text);

        objEmployeeMontlyAttendance.ArrPaidDays = Convert.ToString(txtArrPaidDays.Text);
        objEmployeeMontlyAttendance.PFPaidDays = Convert.ToString(txtPfPaidDays.Text);
        objEmployeeMontlyAttendance.ESIPaidDays = Convert.ToString(txtEsiPaidDays.Text);


        //objEmployeeMontlyAttendance.Remarks = Convert.ToString(txtRemark.Text);
        //objEmployeeMontlyAttendance.ESILeave = 0;

        objEmployeeMontlyAttendance.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
        objEmployeeMontlyAttendance.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();
    }
    public ICollection<EmployeeMontlyAttendance> SetObjectInfo4Earnings()
    {
        List<EmployeeMontlyAttendance> lst = new List<EmployeeMontlyAttendance>();
        EmployeeMontlyAttendance objEmployeeMontlyAttendance = null;
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
            if (chk_Deductions.Checked==true)
            {
            objEmployeeMontlyAttendance.Deductions = Convert.ToString(chk_Deductions.Text);
            objEmployeeMontlyAttendance.DedPercentage = Convert.ToDouble(txt_Percentage.Text);
            objEmployeeMontlyAttendance.DedAmount = Convert.ToDouble(txt_DeductAmount.Text);
            }

            objEmployeeMontlyAttendance.IsSytemCalucalted = true;

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
    #endregion Page Specific Function

    #region Text change Event
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

    #region Bind Grid & Grid Event
    public void BindAllowances(string EmployeeId)
    {
        try
        {
            ds4EmployeeEarningDetails = objEmployeeMontlyAttendanceMasterManager.GetMontlyErrNDeductions(EmployeeId);
            dt4EmployeeEarning = ds4EmployeeEarningDetails.Tables[0];
            Session["EmployeeEarning"] = dt4EmployeeEarning;
            grdAllowances.DataSource = dt4EmployeeEarning;
            grdAllowances.DataBind();
            if (dt4EmployeeEarning.Rows.Count > 0)
            {
                rowChk.Visible = true;
                rowSubmit.Visible = true;
            }
            else
            {
                rowChk.Visible = false;
                rowSubmit.Visible = false;
            }

                
            
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    protected void grdAllowances_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            Label lbl_Allowance = ((Label)e.Row.FindControl("lbl_Allowance"));
            TextBox txt_Amount = ((TextBox)e.Row.FindControl("txt_Amount"));
            TextBox txt_EarnedAmount = ((TextBox)e.Row.FindControl("txt_EarnedAmount"));

            CheckBox chk_Deductions = ((CheckBox)e.Row.FindControl("chk_Deductions"));
            TextBox txt_Percentage = ((TextBox)e.Row.FindControl("txt_Percentage"));
            TextBox txt_Amount4D = ((TextBox)e.Row.FindControl("txt_Amount4D"));
            TextBox txt_DeductAmount = ((TextBox)e.Row.FindControl("txt_DeductAmount"));

            txt_DeductAmount.Text = Math.Round(Convert.ToDecimal( txt_DeductAmount.Text)).ToString();
            txt_EarnedAmount.Text = Math.Round(Convert.ToDecimal(txt_EarnedAmount.Text)).ToString();
            txt_Amount.Text = Math.Round(Convert.ToDecimal(txt_Amount.Text)).ToString();

            //if (lbl_Allowance.Text != "")
            //{
            //    GrossBasicPay = GrossBasicPay + Convert.ToDecimal(txt_EarnedAmount.Text);
            //}
            //txtEarnSalary.Text = GrossBasicPay.ToString();



            DataTable Dt4MonthlyEarning = new DataTable();
            Dt4MonthlyEarning = (DataTable)Session["EmployeeEarning"];
            if (chk_Deductions.Text == "EPF" || chk_Deductions.Text == "ESI")
            {
                chk_Deductions.Checked = true;
                chk_Deductions.Enabled = false;
                txt_Percentage.Enabled = false;
                txt_DeductAmount.Enabled = false;


            }

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
            
            //else if (lbl_Allowance.Text == "D.A." || lbl_Allowance.Text == "D.A")
            //{
            //    GrossBasicPay = GrossBasicPay + Convert.ToDecimal(txt_EarnedAmount.Text);
            //}
            //else if (lbl_Allowance.Text == "HRA")
            //{
            //    GrossBasicPay = GrossBasicPay + Convert.ToDecimal(txt_EarnedAmount.Text);
            //}
            //else if (lbl_Allowance.Text == "CONVEYANCE")
            //{
            //    GrossBasicPay = GrossBasicPay + Convert.ToDecimal(txt_EarnedAmount.Text);
            //}
            //else if (lbl_Allowance.Text == "MEDICAL")
            //{
            //    GrossBasicPay = GrossBasicPay + Convert.ToDecimal(txt_EarnedAmount.Text);
            //}
            
                
          
           // txtEarnSalary.Text = GrossBasicPay.ToString();
          
        }
       
    }

    protected void grdAllowances_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
        
        }
    }

    protected void grdAllowances_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdAllowances_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion

    #region Calculate Salary
    public void ProcessSalary()
    {
        CalculateEarning();
        CalcuLateEarningNDeductions();
    }

    public void CalculateEarning()
    {
        try
        {
            DataTable dt = (DataTable)Session["EmployeeEarning"];
            string AllowanceAmount = "";
            foreach (DataRow dr in dt.Rows)
            {
                dr["AllowanesAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["Amount"]) / Convert.ToDouble(txtTotalDays.Text)) * Convert.ToDouble(txtPaidDays.Text))).ToString("F2");

                //if (txtOverTime.Text != "")
                //{
                //    if (Convert.ToDouble(txtOverTime.Text) > 0)
                //    {
                //        //int a=txtPaidDays*g
                //       // double OverTimeAmount = Convert.ToDouble(Math.Round(( * Convert.ToDouble(txtOverTime.Text))));
                //        //AllowanceAmount = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["AllowanesAmount"]) - OverTimeAmount))).ToString("F2");
                //    }
                //}
            }
            dt.AcceptChanges();
            grdAllowances.DataSource = dt;
            Session["EmployeeEarning"] = dt;
            grdAllowances.DataBind();
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString();
        }
    }

    public void CalcuLateEarningNDeductions()
    {
        try
        {
            DataTable dt = (DataTable)Session["EmployeeEarning"];
            string AllowanceAmount = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToInt32(dr["DeductionLimit"]) != 1)
                {
                    //dr["DedAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["DeductionAmount"]) / Convert.ToDouble(txtTotalDays.Text)) * Convert.ToDouble(txtPaidDays.Text))).ToString("F2");
                    if (Convert.ToString(dr["Deductions"]) != "ESI")
                    {
                        dr["DedAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["AllowanesAmount"]) * Convert.ToDouble(dr["DedPercentage"])) / 100)).ToString("F2");
                    }
                    else
                    {
                        if (GetBasicPay() > Convert.ToDouble(15000))
                        {
                            //dr["DedAmount"] = Convert.ToDouble(Math.Round(Convert.ToDouble((GetBasicPay()/Convert.ToDouble(txtTotalDays.Text)) * Convert.ToDouble(dr["DedPercentage"])) / 100) / ) * Convert.ToDouble(txtPaidDays.Text)).ToString("F2");
                            dr["DedAmount"] = Convert.ToDouble(0).ToString("F2");
                        }
                        else
                        {
                            dr["DedAmount"] = Math.Ceiling(Convert.ToDouble(Convert.ToDouble(GetBasicPay() * Convert.ToDouble(dr["DedPercentage"])) / 100)).ToString("F2");
                        }
                    }
                }
                else
                {
                    //if (Convert.ToDouble(txtOverTime.Text) > 0)
                    //{
                    //    if (Convert.ToDouble(AllowanceAmount) >= 6500)
                    //    {
                    //        dr["DedAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["DeductionAmount"])))).ToString("F2");
                    //    }
                    //    else
                    //    {
                    //        //dr["DedAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["DeductionAmount"]) / Convert.ToDouble(txtTotalDays.Text)) * Convert.ToDouble(txtPaidDays.Text))).ToString("F2");
                    //        dr["DedAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(AllowanceAmount) * Convert.ToDouble(dr["DedPercentage"])) / 100)).ToString("F2");
                    //    }
                    //}
                    //else
                    //{
                        if (Convert.ToDouble(dr["AllowanesAmount"]) >= 6500)
                        {
                            dr["DedAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["DeductionAmount"])))).ToString("F2");
                        }
                        else
                        {
                            //dr["DedAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["DeductionAmount"]) / Convert.ToDouble(txtTotalDays.Text)) * Convert.ToDouble(txtPaidDays.Text))).ToString("F2");
                            dr["DedAmount"] = Convert.ToDouble(Math.Round((Convert.ToDouble(dr["AllowanesAmount"]) * Convert.ToDouble(dr["DedPercentage"])) / 100)).ToString("F2");
                        }
                   // }
                }
            }
            dt.AcceptChanges();
            grdAllowances.DataSource = dt;
            Session["EmployeeEarning"] = dt;
            grdAllowances.DataBind();
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString();
        }
    }

    public double GetBasicPay()
    {
        DataTable dt = (DataTable)Session["EmployeeEarning"];
        double GrossBasicPay = 0.0;
        try
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToString(dr["Allowances"]).Trim() != "" && Convert.ToString(dr["Allowances"]).Trim() != "MEDICAL")
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

    public void CalculateTotalSalary()
    {
        try
        {
            double TotalEarningAmount = 0.0;
            double TotalDeductionAmount = 0.0;
            double TotalSalary = 0.0;

            foreach (GridViewRow grd in grdAllowances.Rows)
            {
                CheckBox chk_Deductions = (CheckBox)grd.FindControl("chk_Deductions");
                TextBox txt_DeductAmount = (TextBox)grd.FindControl("txt_DeductAmount");
                TextBox txt_EarnedAmount = (TextBox)grd.FindControl("txt_EarnedAmount");

                if (txt_EarnedAmount.Text != "")
                {
                    TotalEarningAmount = TotalEarningAmount + Convert.ToDouble(txt_EarnedAmount.Text);
                }
                
                if (txt_DeductAmount.Text != "")
                {
                    TotalDeductionAmount = TotalDeductionAmount + Convert.ToDouble(txt_DeductAmount.Text);
                }
            }

            TotalSalary = TotalEarningAmount - TotalDeductionAmount;

            txtEarnSalary.Text = Convert.ToString(TotalSalary);
            txtEarnSalary.Text = Convert.ToString(TotalSalary + Convert.ToDouble(txtTotalOvertimeAmt.Text));
            hdnTotalEarning.Value = txtEarnSalary.Text;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString();
        }
    }
    #endregion

    #region Populate EmployeeDetail
    private void Calculate()
    {
        DataSet ds = _objReportMasterManager.SystemGenratedMonthlyAttendance(Convert.ToInt32(DDLYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue), ddlEmployee.SelectedValue);
        AssignVariabletoControl(ds.Tables[1]);
        AssignVariableToControlForAttendance(ds.Tables[0]);
        EnableandDisableControl(false);
    }
    #endregion

   
}