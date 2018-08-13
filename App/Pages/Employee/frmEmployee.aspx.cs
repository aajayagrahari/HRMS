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
using System.IO;
#region Development Details
//Shruti Dwivedi(18-09-2013)
#endregion Development Details

public partial class Pages_Employee_frmEmployee : System.Web.UI.Page
{
    #region Global Variable Declaration

    EmployeeMasterDetails _objEmployeeMasterDetails = new EmployeeMasterDetails();
    EmployeeMasterDetailsManager _objEmployeeMasterDetailsManager = new EmployeeMasterDetailsManager();
    EmployeeAttendanceMasterManager _objEmployeeAttendanceMasterManager = new EmployeeAttendanceMasterManager();
    EmployeeAttendanceMaster _objEmployeeAttendanceMaster = new EmployeeAttendanceMaster();
    ReportMaster _objReportMaster = new ReportMaster();
    ReportMasterManager _objReportMasterManager = new ReportMasterManager();
    EmployeeLeaveDetailMaster1 _objEmployeeLeaveDetailMaster = new EmployeeLeaveDetailMaster1();
    EmployeeLeaveDetailMasterManager1 _objEmployeeLeaveDetailMasterManager = new EmployeeLeaveDetailMasterManager1();
    BindComboMasterManager _objBindComboMasterManager = new BindComboMasterManager();
    HolidayMasterManager _objHolidayMasterManager = new HolidayMasterManager();

    DateTime DDD = new DateTime();
    int hour;
    int minute;
    int date;
    int month;
    int year;
    string APM;

    #endregion Global Variable Declaration

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                DataTable dt = _objEmployeeMasterDetailsManager.GetEmployeeMaster4ID(Session["EmployeeId"].ToString()).Tables[0];
                FormEmpDetail.DataSource = dt;
                FormEmpDetail.DataBind();
              
                lblEmpId.Text = Session["EmployeeId"].ToString();
                lblLeaveEmployeeId.Text = Session["EmployeeId"].ToString();
                DisableEnableControl(false);
                SetButtonText();
                //EmployeeAttendanceSummary(Convert.ToInt64(Session["EmployeeId"].ToString()));
                BindEmployeeLeaveDetail();
                BindLeaveNature();
                TabContainer1.ActiveTabIndex = 0;
                DataSet ds = _objReportMasterManager.CalculateEmployeeSalary(Convert.ToInt32(Session["EmployeeId"].ToString()));
               // litSalaryReportReport.Text = _objReportMaster.EmployeeSalaryDetail(ds);

                BindGridView();
            }
            BindCurrentDate();

            if (btnMarkin.Text == "MarkIn")
            {
                
                if (hour == 9 && minute <= 45 && APM == "AM")
                {
                    lblAlertMsg.Text = "";

                }
                else if (hour < 9 && APM == "AM")
                {
                    lblAlertMsg.Text = "";
                }
                else
                {
                    //lblAlertMsg.Text = "your Causal leave will be subtracted by one beacuse you have to come late in office";
                    lblAlertMsg.Text = "Today your Attendance will be mark as halfday.";
                    lblAlertMsg.ForeColor = Color.Red;
                }
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }

    }

    protected void btnMarkin_Click(object sender, EventArgs e)
    {
        try
        {
            bool IsAttendanceMarkIn = _objEmployeeAttendanceMasterManager.IsAttendanceMarkIn(Convert.ToInt64(lblEmpId.Text));
            if (IsAttendanceMarkIn == true && btnMarkin.Text.ToUpper() == "MARKIN")
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "You have already markin your attendance!!";
                txtRemarks.Text = "";
            }
            else
            {
                SetObjectInfo(_objEmployeeAttendanceMaster);
                if (btnMarkin.Text.ToUpper() == "MARKIN")
                {
                    if ((txtRemarks.Text == "" && hour == 9 && minute > 45 && APM == "AM") || (txtRemarks.Text == "" && hour > 9 && APM == "AM") || (txtRemarks.Text == "" && APM == "PM"))
                    {
                        lblMsg.Text = "Remarks is Mendatory";
                        lblMsg.ForeColor = Color.Red;
                        txtRemarks.BorderColor = Color.Red;
                    }
                    else
                    {
                        lblMsg.Text = "";
                        txtRemarks.BorderColor = Color.Gray;
                        foreach (ErrorHandlerClass err in _objEmployeeAttendanceMasterManager.SaveEmployeeAttendance(_objEmployeeAttendanceMaster))
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
                                    lblMsg.Text = "Successfully MarkIn your Attendance";
                                    TabContainer1.ActiveTabIndex = 1;
                                    Response.Redirect("frmEmployee.aspx", false);
                                }
                            }
                        }
                    }
                }
                else
                {
                    lblMsg.Text = "";
                    txtRemarks.BorderColor = Color.Gray;
                    if (hour<18)
                    {
                        _objEmployeeAttendanceMaster.MarkOutAlertMessasg = "Markout before 06 PM";
                    }
                    else
                    {
                        _objEmployeeAttendanceMaster.MarkOutAlertMessasg = "";
                    }
                    if ((hour == 18 && minute <= 30 && APM == "PM") || txtRemarks.Text != "" || hour == 6)
                    {
                        foreach (ErrorHandlerClass err in _objEmployeeAttendanceMasterManager.UpdateEmployeeAttendance(_objEmployeeAttendanceMaster))
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
                                lblMsg.ForeColor = Color.Green;
                                lblMsg.Text = err.Message.ToString();
                                lblMsg.Text = "Successfully MarkOut your Attendance";
                                Response.Redirect("frmEmployee.aspx", false);
                                //lblMsg.Text = "Successfully MarkOut your Attendance";
                                //Response.Write("<script>alert('Successfully MarkOut your Attendance.');document.location.href='frmEmployee.aspx';</script>");
                            }
                        }
                    }
                    else
                    {
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Text = "Remarks is Mendatory";
                        txtRemarks.BorderColor = Color.Red;
                    }
                }
                SetButtonText();
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }

    #region EmployeeLeaveEvent
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (checkLaeveData() == true)
            {
                SetObjectInfo(_objEmployeeLeaveDetailMaster);
                if (hdnLeaveId.Value == "")
                {
                    foreach (ErrorHandlerClass err in _objEmployeeLeaveDetailMasterManager.SaveEmployeeLeaveDetail(_objEmployeeLeaveDetailMaster))
                    {
                        if (err.Type == "E")
                        {
                            lblLeaveMsg.ForeColor = Color.Red;
                            lblLeaveMsg.Text = err.Message.ToString();
                            break;
                        }
                        else if (err.Type == "A")
                        {
                            lblLeaveMsg.ForeColor = Color.Red;
                            lblLeaveMsg.Text = err.Message.ToString();
                            break;
                        }
                        else
                        {

                            lblLeaveMsg.ForeColor = Color.Green;
                            lblLeaveMsg.Text = err.Message.ToString();
                            TabContainer1.ActiveTabIndex = 3;
                            Response.Redirect("frmEmployee.aspx", false);
                            // lblMsg.Text = "Successfully MarkIn your Attendance";
                            // Response.Redirect("frmEmployee.aspx", false);
                            //lblMsg.Text = "Successfully MarkOut your Attendance";
                            //Response.Write("<script>alert('Successfully MarkIn your Attendance.');document.location.href='frmEmployee.aspx';</script>");

                        }

                    }
                }
                else
                {
                    _objEmployeeLeaveDetailMaster.LeaveId = Convert.ToInt32(hdnLeaveId.Value);
                    foreach (ErrorHandlerClass err in _objEmployeeLeaveDetailMasterManager.UpdateEmployeeLeaveDetail(_objEmployeeLeaveDetailMaster))
                    {
                        if (err.Type == "E")
                        {
                            lblLeaveMsg.ForeColor = Color.Red;
                            lblLeaveMsg.Text = err.Message.ToString();
                            break;
                        }
                        else if (err.Type == "A")
                        {
                            lblLeaveMsg.ForeColor = Color.Red;
                            lblLeaveMsg.Text = err.Message.ToString();
                            break;
                        }
                        else
                        {
                            if (lblLeaveMsg.Text.ToString() == "")
                            {
                                lblLeaveMsg.ForeColor = Color.Green;
                                lblLeaveMsg.Text = err.Message.ToString();
                                TabContainer1.ActiveTabIndex = 3;

                            }
                        }
                    }

                }
                BindEmployeeLeaveDetail();
                Response.Redirect("frmEmployee.aspx", false);
                LeaveReset();
            }
            else
            {
                //lblLeaveMsg.Text="Input data is not in Correct Format"
            }
        }
        catch (Exception ee)
        {
            lblLeaveMsg.Text = ee.StackTrace;
            lblLeaveMsg.ForeColor = Color.Red;
        }

    }

    protected void gdvSavedLeaveDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Delete")
            {
                _objEmployeeLeaveDetailMaster.LeaveId = Convert.ToInt32(e.CommandArgument.ToString());

                foreach (ErrorHandlerClass err in _objEmployeeLeaveDetailMasterManager.DeleteEmployeeLeaveDetail(_objEmployeeLeaveDetailMaster))
                {
                    if (err.Type == "E")
                    {
                        lblLeaveMsg.ForeColor = Color.Red;
                        lblLeaveMsg.Text = err.Message.ToString();
                        break;
                    }
                    else if (err.Type == "A")
                    {
                        lblLeaveMsg.ForeColor = Color.Red;
                        lblLeaveMsg.Text = err.Message.ToString();
                        break;
                    }
                    else
                    {
                        lblLeaveMsg.ForeColor = Color.Green;
                        lblLeaveMsg.Text = err.Message.ToString();
                        BindEmployeeLeaveDetail();
                        // Response.Redirect("frmEmployee.aspx", false);
                        //lblMsg.Text = "Successfully MarkIn your Attendance";
                        //Response.Redirect("frmEmployee.aspx", false);
                        //lblMsg.Text = "Successfully MarkOut your Attendance";
                        //Response.Write("<script>alert('Successfully MarkIn your Attendance.');document.location.href='frmEmployee.aspx';</script>");

                    }

                }

            }
            else if (e.CommandName == "Edit")
            {
                DataTable _dt = _objEmployeeLeaveDetailMasterManager.GetEmployeeLeaveDetailById(Convert.ToInt64(e.CommandArgument.ToString())).Tables[0];
                _objEmployeeLeaveDetailMaster.SetObjectInfo(_dt.Rows[0]);
                AssignVariableToControl(_objEmployeeLeaveDetailMaster);
                hdnLeaveId.Value = e.CommandArgument.ToString();
                btnSave.Text = "Update";
                gdvSavedLeaveDetail.EditIndex = -1;
                BindEmployeeLeaveDetail();
            }
            else if (e.CommandName == "Submit")
            {

                DataTable _dt = _objEmployeeLeaveDetailMasterManager.GetEmployeeLeaveDetailById(Convert.ToInt64(e.CommandArgument.ToString())).Tables[0];
                _objEmployeeLeaveDetailMaster.SetObjectInfo(_dt.Rows[0]);
                _objEmployeeLeaveDetailMaster.LeaveId = Convert.ToInt32(e.CommandArgument.ToString());
                _objEmployeeLeaveDetailMaster.IsSubmitted = "1";
                _objEmployeeLeaveDetailMaster.SubmittedDate = DateTime.Now.ToString();
                _objEmployeeLeaveDetailMaster.IsApproved = null;
                _objEmployeeLeaveDetailMaster.ApprovedBy = null;
                _objEmployeeLeaveDetailMaster.ApprovedDate = null;
                foreach (ErrorHandlerClass err in _objEmployeeLeaveDetailMasterManager.UpdateEmployeeLeaveDetail(_objEmployeeLeaveDetailMaster))
                {
                    if (err.Type == "E")
                    {
                        lblLeaveMsg.ForeColor = Color.Red;
                        lblLeaveMsg.Text = err.Message.ToString();
                        break;
                    }
                    else if (err.Type == "A")
                    {
                        lblLeaveMsg.ForeColor = Color.Red;
                        lblLeaveMsg.Text = err.Message.ToString();
                        break;
                    }
                    else
                    {
                        if (lblLeaveMsg.Text.ToString() == "")
                        {
                            lblLeaveMsg.ForeColor = Color.Green;
                            //lblLeaveMsg.Text = err.Message.ToString();
                            gdvSavedLeaveDetail.EditIndex = -1;
                            BindEmployeeLeaveDetail();
                        }
                    }
                }

            }
        }
        catch (Exception ee)
        {
            lblLeaveMsg.Text = ee.StackTrace;
            lblLeaveMsg.ForeColor = Color.Red;
        }

    }

    protected void gdvSavedLeaveDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
        }
        catch (Exception ee)
        {
            lblLeaveMsg.Text = ee.StackTrace;
            lblLeaveMsg.ForeColor = Color.Red;
        }

    }

    protected void gdvSavedLeaveDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
        }
        catch (Exception ee)
        {
            lblLeaveMsg.Text = ee.StackTrace;
            lblLeaveMsg.ForeColor = Color.Red;
        }

    }
    #endregion EmployeeLeaveEvent

    #region Page Specific Function
    private void BindCurrentDate()
    {
        DataTable _dt = _objEmployeeAttendanceMasterManager.GetDateandTime();
        txtDate.Text = _dt.Rows[0]["CurrentDate"].ToString();
        txtTime.Text = _dt.Rows[0]["CurrentTIme"].ToString();

        DDD = Convert.ToDateTime(_dt.Rows[0]["FullDateTime"].ToString());
        hour = DDD.Hour;
        minute = DDD.Minute;
        date = DDD.Day;
        month = DDD.Month;
        year = DDD.Year;
        APM = Convert.ToDateTime(_dt.Rows[0]["FullDateTime"].ToString()).ToString("tt");
    }

    private void DisableEnableControl(bool value)
    {
        txtDate.Enabled = value;
        txtTime.Enabled = value;
    }

    private void SetObjectInfo(EmployeeAttendanceMaster _objvEmployeeAttendanceMaster)
    {
        try
        {
            _objEmployeeAttendanceMaster.EmployeeId = Convert.ToInt64(lblEmpId.Text);
            if (btnMarkin.Text.ToUpper() == "MARKIN")
            {
                _objEmployeeAttendanceMaster.MarkInRemark = txtRemarks.Text;
                _objEmployeeAttendanceMaster.CreatedBy = Session["LoginId"].ToString();
                
                _objEmployeeAttendanceMaster.MarkInDate = txtDate.Text;
                _objEmployeeAttendanceMaster.MarkIntime = txtTime.Text;
                _objEmployeeAttendanceMaster.AlertMessasg = lblAlertMsg.Text;
                _objEmployeeAttendanceMaster.MarkInIPAddress = GetIP();
            }
            else
            {
                _objEmployeeAttendanceMaster.MarkOutDate = txtDate.Text;
                _objEmployeeAttendanceMaster.MarkOutTime = txtTime.Text;
                _objEmployeeAttendanceMaster.MarkoutRemark = txtRemarks.Text;
                _objEmployeeAttendanceMaster.ModifiedBy = Session["LoginId"].ToString();
                _objEmployeeAttendanceMaster.MarkOutIPAddress = GetIP();
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }

    private void SetObjectInfo(EmployeeLeaveDetailMaster1 _objEmployeeLeaveDetailMaster)
    {
        try
        {
            _objEmployeeLeaveDetailMaster.EmployeeId = Convert.ToInt64(lblLeaveEmployeeId.Text);
            _objEmployeeLeaveDetailMaster.FromDate = txtFromDate.Text;
            _objEmployeeLeaveDetailMaster.ToDate = txtToDate.Text;
            _objEmployeeLeaveDetailMaster.Reason = txtReason.Text;
            _objEmployeeLeaveDetailMaster.CreatedBy = Session["LoginId"].ToString();
            _objEmployeeLeaveDetailMaster.ModifiedBy = Session["LoginId"].ToString();
            _objEmployeeLeaveDetailMaster.LeaveTypeId = ddlLeaveNature.SelectedValue;
        }
        catch (Exception ee)
        {
            lblLeaveMsg.Text = ee.StackTrace;
            lblLeaveMsg.ForeColor = Color.Red;
        }
    }

    private void SetButtonText()
    {
        try
        {
            bool IsMarkIn = _objEmployeeAttendanceMasterManager.IsMarkin(Convert.ToInt64(lblEmpId.Text));
            if (IsMarkIn == true)
                btnMarkin.Text = "MarkOut";
            else
                btnMarkin.Text = "MarkIn";
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }

    private string GetIP()
    {
        string strHostName = "";
        strHostName = System.Net.Dns.GetHostName();
        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
        IPAddress[] addr = ipEntry.AddressList;
        return addr[2].ToString();
    }

    //private void EmployeeAttendanceSummary(Int64 UserName)
    //{
    //    try
    //    {
    //        DataTable _dt = _objReportMasterManager.EmployeeAttendanceSummary(UserName);
    //        litAttendanceReport.Text = _objReportMaster.EmployeeAttendanceSummary(_dt);
    //    }
    //    catch (Exception ee)
    //    {
    //        lblMsg.Text = ee.StackTrace;
    //        lblMsg.ForeColor = Color.Red;
    //    }
    //}

    private void LeaveReset()
    {
        txtFromDate.Text = "";
        txtToDate.Text = "";
        txtReason.Text = "";
        btnSave.Text = "Save";
        hdnLeaveId.Value = "";
        ddlLeaveNature.SelectedIndex = 0;
    }

    private void BindEmployeeLeaveDetail()
    {
        DataSet ds = _objEmployeeLeaveDetailMasterManager.GetEmployeeLeaveDetailbyEmpId(Convert.ToInt64(lblLeaveEmployeeId.Text));
        gdvSavedLeaveDetail.DataSource = ds.Tables[0];
        gdvSavedLeaveDetail.DataBind();
        gdvSubmittedLeaveDetail.DataSource = ds.Tables[1];
        gdvSubmittedLeaveDetail.DataBind();

        if (gdvSavedLeaveDetail.Rows.Count > 0)
        {
            row1.Visible = true;
            gdvrow1.Visible = true;
        }
        if (gdvSubmittedLeaveDetail.Rows.Count > 0)
        {
            gdvrow2.Visible = true;
            row2.Visible = true;
        }
    }

    private void AssignVariableToControl(EmployeeLeaveDetailMaster1 _objEmployeeLeaveDetailMaster)
    {
        txtFromDate.Text = _objEmployeeLeaveDetailMaster.FromDate.Split(' ')[0];
        txtToDate.Text = _objEmployeeLeaveDetailMaster.ToDate.Split(' ')[0];
        txtReason.Text = _objEmployeeLeaveDetailMaster.Reason;
        ddlLeaveNature.SelectedValue = _objEmployeeLeaveDetailMaster.LeaveTypeId.ToString();
    }

    private void BindLeaveNature()
    {
        DataTable _dt = _objBindComboMasterManager.BindLeaveNature();
        ddlLeaveNature.DataSource = _dt;
        ddlLeaveNature.DataTextField = _dt.Columns["txt"].ToString();
        ddlLeaveNature.DataValueField = _dt.Columns["val"].ToString();
        ddlLeaveNature.DataBind();
        ddlLeaveNature.Items.Insert(0, "Select Leave Nature");
    }

    private bool checkLaeveData()
    {
        bool _Flag = true;
        if (ddlLeaveNature.SelectedIndex == 0)
        {
            ddlLeaveNature.BorderColor = Color.Red;
            _Flag = false;
        }
        else
        {
            ddlLeaveNature.BorderColor = Color.Black;
        }
        if (txtReason.Text == "")
        {
            txtReason.BorderColor = Color.Red;
            _Flag = false;
        }
        else
        {
            txtReason.BorderColor = Color.Black;
        }

        return _Flag;
    }
    private void BindGridView()
    {
        DataTable _dt = _objHolidayMasterManager.GetHolidayMaster().Tables[0];
        gdvHolidayList.DataSource = _dt;
        gdvHolidayList.DataBind();
    }
    #endregion Page Specific Function

}