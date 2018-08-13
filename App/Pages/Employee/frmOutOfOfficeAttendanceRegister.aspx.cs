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

public partial class Pages_Employee_frmOutOfOfficeAttendanceRegister : System.Web.UI.Page
{
    OutOfOfficeAttendanceMasterManager objOutOfOfficeAttendanceMasterManager = new OutOfOfficeAttendanceMasterManager();
    EmployeeMasterDetailsManager objEmployeeMasterDetailsManager = new EmployeeMasterDetailsManager();

    DataSet ds4MonthlyAttendanceCalender = new DataSet();
    DataTable dt4MonthlyAttendanceCalender = new DataTable();

    DataSet ds4EmployeeDetails = new DataSet();
    DataTable dt4EmployeeDetails = new DataTable();

    DateTime DDD = new DateTime();
    public static int hour;
    public static int minute;
    public static int date;
    public static int month;
    public static int year;
    public static string APM;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            iniControls();
            BindGender();

            if (Convert.ToString(Session["EmployeeId"]).Trim() != "")
            {
                txtCode.Text = Convert.ToString(Session["EmployeeId"]).Trim();
                PopulateDetails4EmplopyeeId(Convert.ToString(Session["EmployeeId"]).Trim());
                txtCode.Enabled = false;

                ddlMonth.SelectedValue = Convert.ToString(DateTime.Now.Month);
                ddlFinYear.SelectedValue = Convert.ToString(DateTime.Now.Year);
            }
        }
    }

    #region iniControls
    public void iniControls()
    {
        txtDateFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtDateTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtPurpose.Text = "";
    }
    #endregion

    #region PopulateBasicDetails
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
    #endregion

    #region Bind Gender
    public void BindGender()
    {
        DDLGender.Items.Add(new ListItem("Male", "M"));
        DDLGender.Items.Add(new ListItem("Female", "F"));
        DDLGender.Items.Insert(0, "-- Select--");
    }
    #endregion

    #region Button Click Event
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        try
        {
            OutOfOfficeAttendanceMaster objOutOfOfficeAttendanceMaster = new OutOfOfficeAttendanceMaster();

            setObjectInfor4Attendance(objOutOfOfficeAttendanceMaster);

            foreach (ErrorHandlerClass err in objOutOfOfficeAttendanceMasterManager.SaveOutOfOfficeAttendanceMaster(objOutOfOfficeAttendanceMaster))
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
                iniControls();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        iniControls();
    }
    #endregion

    #region SetobjectInfo
    public void setObjectInfor4Attendance(OutOfOfficeAttendanceMaster objOutOfOfficeAttendanceMaster)
    {
        objOutOfOfficeAttendanceMaster.EmployeeId = Convert.ToString(txtCode.Text).Trim();
        objOutOfOfficeAttendanceMaster.OutOfOfficeDateFrom = Convert.ToString(txtDateFrom.Text).Trim();
        objOutOfOfficeAttendanceMaster.OutOfOfficeDateTo = Convert.ToString(txtDateTo.Text).Trim();
        objOutOfOfficeAttendanceMaster.Purpose = Convert.ToString(txtPurpose.Text).Trim();
        
        if (ddlMonth.SelectedIndex >= 0)
        {
            objOutOfOfficeAttendanceMaster.month = Convert.ToInt32(ddlMonth.SelectedValue);
        }
        else
        {
            objOutOfOfficeAttendanceMaster.month = 0;
        }

        if (ddlFinYear.SelectedIndex >= 0)
        {
            objOutOfOfficeAttendanceMaster.year = Convert.ToInt32(ddlFinYear.SelectedValue);
        }
        else
        {
            objOutOfOfficeAttendanceMaster.year =0;
        }

        objOutOfOfficeAttendanceMaster.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
        objOutOfOfficeAttendanceMaster.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();
    }
    #endregion

    #region Selected Index Changed Event
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonth.SelectedIndex > 0 && ddlFinYear.SelectedIndex >0)
        {
            
        }
    }

    protected void ddlFinYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonth.SelectedIndex > 0 && ddlFinYear.SelectedIndex > 0)
        {
            
        }
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
            PopulateDetails4EmplopyeeId(Convert.ToString(Session["EmployeeId"]).Trim());
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

        DateTime dt1 = Convert.ToDateTime(Pages_Employee_frmOutOfOfficeAttendanceRegister.ToDateTime1(txtDateOfJoining.Text));
        DateTime dt2 = Convert.ToDateTime(Pages_Employee_frmOutOfOfficeAttendanceRegister.ToDateTime1("31/03/2014"));

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

}