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
using System.Net;
using System.Text;
using System.Globalization;
#region Development Details
//Shruti Dwivedi(11-11-2013)
#endregion Development Details

public partial class Pages_Employee_frmAttendanceSummary : System.Web.UI.Page
{
    #region Global Variable Declaration
    MonthlyAttendanceRegisterManager objMonthlyAttendanceRegisterManager = new MonthlyAttendanceRegisterManager();
    EmployeeMasterDetailsManager objEmployeeMasterDetailsManager = new EmployeeMasterDetailsManager();
    EmployeeAttendanceMasterManager _objEmployeeAttendanceMasterManager = new EmployeeAttendanceMasterManager();
    EmployeeAttendanceMaster _objEmployeeAttendanceMaster = new EmployeeAttendanceMaster();
    DataSet ds4MonthlyAttendanceCalender = new DataSet();
    DataSet ds4EmployeeDetails = new DataSet();
    DataTable dt4EmployeeDetails = new DataTable();
    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["EmployeeId"]).Trim() != "")
                {
                    txtCode.Text = Convert.ToString(Session["EmployeeId"]).Trim();
                    PopulateDetails4EmplopyeeId(Convert.ToString(Session["EmployeeId"]).Trim());
                    txtCode.Enabled = false;

                    ddlMonth.SelectedValue = Convert.ToString(DateTime.Now.Month);
                    ddlFinYear.SelectedValue = Convert.ToString(DateTime.Now.Year);

                    if (ddlMonth.SelectedIndex > 0 && ddlFinYear.SelectedIndex > 0)
                    {
                        BindMonthlyAttendanceCalender(ddlMonth.SelectedValue, ddlFinYear.SelectedValue);
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
  
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonth.SelectedIndex > 0 && ddlFinYear.SelectedIndex > 0)
        {
            BindMonthlyAttendanceCalender(ddlMonth.SelectedValue, ddlFinYear.SelectedValue);
           // PopulateDetails4AttendaceSummary(Convert.ToString(Session["EmployeeId"]).Trim(), Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlFinYear.SelectedValue));
        }
    }

    protected void ddlFinYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonth.SelectedIndex > 0 && ddlFinYear.SelectedIndex > 0)
        {
            BindMonthlyAttendanceCalender(ddlMonth.SelectedValue, ddlFinYear.SelectedValue);
          //  PopulateDetails4AttendaceSummary(Convert.ToString(Session["EmployeeId"]).Trim(), Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlFinYear.SelectedValue));
        }
    }
   
    protected void grdMonthlyAttendanceSummary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl_Days = ((Label)e.Row.FindControl("lbl_Days"));
                Label lbl_Status = ((Label)e.Row.FindControl("lbl_Status"));
                TextBox txt_MarkInTime = ((TextBox)e.Row.FindControl("txt_MarkInTime"));
                TextBox txt_MarkOutTime = ((TextBox)e.Row.FindControl("txt_MarkOutTime"));

                TextBox txtUpdatedMarkin = ((TextBox)e.Row.FindControl("txt_UpdatedMarkInTime"));
                TextBox txtUpdatedMarkout = ((TextBox)e.Row.FindControl("txt_UpdatedMarkOutTime"));

                CheckBox chk_Date = ((CheckBox)e.Row.FindControl("chk_Date"));
                HiddenField AlertMsg = ((HiddenField)e.Row.FindControl("hdnStaus2"));
                HiddenField MarkOutAlertMsg = ((HiddenField)e.Row.FindControl("hdnStaus3"));
                HiddenField isApprove = ((HiddenField)e.Row.FindControl("hdnisApprove"));

                string a = isApprove.Value;

                DateTime dt1 = Convert.ToDateTime(Pages_Employee_frmAttendanceSummary.ToDateTime1(chk_Date.Text));
                DateTime dt2 = Convert.ToDateTime(Pages_Employee_frmAttendanceSummary.ToDateTime1(DateTime.Now.ToString("dd/MM/yyyy")));


                
                
                
                if (isApprove.Value == "0" || isApprove.Value == "1")
                {
                    chk_Date.Enabled = false;
                    txtUpdatedMarkin.Enabled = false;
                    txtUpdatedMarkout.Enabled = false;
                }
                else
                {
                    chk_Date.Enabled = true;
                    txtUpdatedMarkin.Enabled = true;
                    txtUpdatedMarkout.Enabled = true;

                }
               

                if (AlertMsg.Value == MarkOutAlertMsg.Value)
                {
                    
                    if (isApprove.Value == "0")
                    {
                        lbl_Status.Text = "Absent";
                    }
                    else if (isApprove.Value == "1")
                    {
                        lbl_Status.Text = "Present";
                    }
                    else
                    {
                        lbl_Status.Text = AlertMsg.Value;
                    }
                }
                else if (AlertMsg.Value!="Present")
                {
                    if (isApprove.Value == "0")
                    {
                        lbl_Status.Text = "DisApprove";
                    }
                    else if (isApprove.Value == "1")
                    {
                        lbl_Status.Text = "Approve";
                    }
                    else
                    {
                        lbl_Status.Text = AlertMsg.Value;
                    }
                }
                else if (MarkOutAlertMsg.Value != "Present")
                {
                    if (isApprove.Value == "0")
                    {
                        lbl_Status.Text = "DisApprove";
                    }
                    else if (isApprove.Value == "1")
                    {
                        lbl_Status.Text = "Approve";
                    }
                    else
                    {
                        lbl_Status.Text = MarkOutAlertMsg.Value;
                    }
                }
               
                if (dt1 > dt2)
                {
                    chk_Date.Enabled = false;
                    txtUpdatedMarkin.Enabled = false;
                    txtUpdatedMarkout.Enabled = false;
                }
                else
                {
                    if (lbl_Status.Text == "")
                    {
                        lbl_Status.Text = "Absent";
                    }
                }

                if (lbl_Days.Text == "WO")
                {
                    chk_Date.Enabled = false;
                    chk_Date.Checked = true;
                    txtUpdatedMarkin.Enabled = false;
                    txtUpdatedMarkout.Enabled = false;
                    lbl_Days.ForeColor = System.Drawing.Color.Red;
                    lbl_Status.Text = "";
                }
               
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString();
        }

    }
   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        try
        {
            foreach (ErrorHandlerClass err in _objEmployeeAttendanceMasterManager.SaveEmployeeAttendanceCollection(_objEmployeeAttendanceMaster, SetObjectInfoCollection()))
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
                        if (ddlMonth.SelectedIndex > 0 && ddlFinYear.SelectedIndex > 0)
                        {
                            BindMonthlyAttendanceCalender(ddlMonth.SelectedValue, ddlFinYear.SelectedValue);
                        }

                    }
                }

            }
            if (ddlMonth.SelectedIndex > 0 && ddlFinYear.SelectedIndex > 0)
            {
                BindMonthlyAttendanceCalender(ddlMonth.SelectedValue, ddlFinYear.SelectedValue);
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString();
        }

    }
    #endregion Page Event

    #region Page Specific Method
    private void BindMonthlyAttendanceCalender(string Month, string Year)
    {
        try
        {
            //ds4MonthlyAttendanceCalender = objEmployeeMontlyAttendanceMasterManager.GetMonthlyAttendanceCalender(Convert.ToString(Session["EmployeeId"]).Trim());
            ds4MonthlyAttendanceCalender = objMonthlyAttendanceRegisterManager.GetMonthlyAttendanceCalender(Convert.ToString(Session["EmployeeId"]).Trim(), Month, Year);
            grdMonthlyAttendanceSummary.DataSource = ds4MonthlyAttendanceCalender.Tables[0];
            grdMonthlyAttendanceSummary.DataBind();
           // Session["MonthlyAttendanceCalender"] = ds4MonthlyAttendanceCalender.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    
    private void PopulateDetails4EmplopyeeId(string strEmployeeId)
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
    
    public ICollection<EmployeeAttendanceMaster> SetObjectInfoCollection()
    {
        List<EmployeeAttendanceMaster> lst = new List<EmployeeAttendanceMaster>();
        string EmployeeId = Session["EmployeeId"].ToString();
        EmployeeAttendanceMaster _objEmployeeAttendanceMaster = null;
        for (int i = 0; i < grdMonthlyAttendanceSummary.Rows.Count; i++)
        {
            CheckBox chk = (CheckBox)grdMonthlyAttendanceSummary.Rows[i].FindControl("chk_Date");
            TextBox UpdatedMarkinTime = (TextBox)grdMonthlyAttendanceSummary.Rows[i].FindControl("txt_UpdatedMarkInTime");
            TextBox UpdatedMarkOutTime = (TextBox)grdMonthlyAttendanceSummary.Rows[i].FindControl("txt_UpdatedMarkOutTime");
            //string EmployeeId = Session["EmployeeId"].ToString();
            //string atr = chk.Checked.ToString();
            if (chk.Checked == true)
            {
                _objEmployeeAttendanceMaster = new EmployeeAttendanceMaster();
                _objEmployeeAttendanceMaster.EmployeeId = Convert.ToInt64(Session["EmployeeId"].ToString());
                _objEmployeeAttendanceMaster.UpdatedMarkInTime = UpdatedMarkinTime.Text;
                _objEmployeeAttendanceMaster.UpdatedMarkOutTime = UpdatedMarkOutTime.Text;
                _objEmployeeAttendanceMaster.IsSubmitted = true;
                _objEmployeeAttendanceMaster.SubmittedBy = Session["LoginId"].ToString();
                _objEmployeeAttendanceMaster.SubmittedDate = DateTime.Now.ToString();
                _objEmployeeAttendanceMaster.MarkInDate = chk.Text;
                _objEmployeeAttendanceMaster.MarkOutDate = chk.Text;
                _objEmployeeAttendanceMaster.AlertMessasg = "Request for Attendance Approval";
                _objEmployeeAttendanceMaster.MarkOutAlertMessasg = "Request for Attendance Approval";
                _objEmployeeAttendanceMaster.CreatedBy = Session["LoginId"].ToString();
                _objEmployeeAttendanceMaster.CreatedDate = DateTime.Now.ToString();
                _objEmployeeAttendanceMaster.IsApprived =-1;
                lst.Add(_objEmployeeAttendanceMaster);

            }
        }
        return lst;
    }
    #endregion Page Specific Method

   
}