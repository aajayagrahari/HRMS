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

public partial class Pages_Employee_frmMonthlyAttendance : System.Web.UI.Page
{
    MonthlyAttendanceRegisterManager objMonthlyAttendanceRegisterManager = new MonthlyAttendanceRegisterManager();
    EmployeeMontlyAttendanceMasterManager objEmployeeMontlyAttendanceMasterManager = new EmployeeMontlyAttendanceMasterManager();
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
                
                if (ddlMonth.SelectedIndex > 0 && ddlFinYear.SelectedIndex > 0)
                {
                    BindMonthlyAttendanceCalender(ddlMonth.SelectedValue, ddlFinYear.SelectedValue);
                }

                if (ddlMonth.SelectedIndex > 0 && ddlFinYear.SelectedIndex > 0)
                {
                    PopulateDetails4AttendaceSummary(Convert.ToString(Session["EmployeeId"]).Trim(), Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlFinYear.SelectedValue));
                }

                DataSet ds4GetDetails = new DataSet();
                ds4GetDetails = objMonthlyAttendanceRegisterManager.GetMonthlyAttendanceRegister4ID(Convert.ToString(txtCode.Text).Trim(), Convert.ToString(lblTodayDate.Text).Trim());

                if (ds4GetDetails != null && ds4GetDetails.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(ds4GetDetails.Tables[0].Rows[0]["AttendanceDate"]).Trim() == Convert.ToString(lblTodayDate.Text))
                    {
                        if (Convert.ToString(ds4GetDetails.Tables[0].Rows[0]["MarkInTime"]).Trim() != "00:00" && Convert.ToString(ds4GetDetails.Tables[0].Rows[0]["MarkOutTime"]).Trim() != "00:00")
                        {
                            btnMarkIn.Enabled = false;
                            btnMarkOutTime.Enabled = false;

                            txtMarkInTime.Text = Convert.ToString(ds4GetDetails.Tables[0].Rows[0]["MarkInTime"]).Trim();
                            txtMarkOutTime.Text = Convert.ToString(ds4GetDetails.Tables[0].Rows[0]["MarkOutTime"]).Trim();
                            txtRemarks.Text = Convert.ToString(ds4GetDetails.Tables[0].Rows[0]["Remarks"]).Trim();
                            lblAttendanceStatus.Text = Convert.ToString(ds4GetDetails.Tables[0].Rows[0]["Status"]).Trim();
                            txtRemarks.Enabled = false;
                            BindCurrentDateAndTime();
                        }
                        else if (Convert.ToString(ds4GetDetails.Tables[0].Rows[0]["MarkInTime"]).Trim() != "00:00" && Convert.ToString(ds4GetDetails.Tables[0].Rows[0]["MarkOutTime"]).Trim() == "00:00")
                        {
                            btnMarkIn.Enabled = false;
                            btnMarkOutTime.Enabled = true;
                            txtRemarks.Enabled = true;
                            GetMarkInTime();
                            BindCurrentDateAndTime();
                        }
                        else if (Convert.ToString(ds4GetDetails.Tables[0].Rows[0]["MarkInTime"]).Trim() == "00:00" && Convert.ToString(ds4GetDetails.Tables[0].Rows[0]["MarkOutTime"]).Trim() == "00:00")
                        {
                            btnMarkIn.Enabled = true;
                            btnMarkOutTime.Enabled = false;
                            BindCurrentDateAndTime();
                        }
                    }
                    else
                    {
                        btnMarkIn.Enabled = true;
                        btnMarkOutTime.Enabled = false;
                        txtRemarks.Enabled = false;
                        BindCurrentDateAndTime();
                    }
                }
                else
                {
                    btnMarkOutTime.Enabled = false;
                    txtRemarks.Enabled = false;
                    BindCurrentDateAndTime();
                }
            }
        }
    }

    #region iniControls
    public void iniControls()
    {
        txtCode.Text = "";
        txtfhName.Text = "";
        txtName.Text = "";
        txtDateOfJoining.Text = "";
        txtUnit.Text = "";
        DDLGender.SelectedIndex = 0;
        DDLGender.Enabled = true;

        inicontrols4TaxablEarning();
    }

    public void inicontrols4TaxablEarning()
    {
        //foreach (GridViewRow grd in grdMonthlyAttendanceSummary.Rows)
        //{
        //    Label lbl_MonthlyAttendanceCalender = (Label)grd.FindControl("lbl_MonthlyAttendanceCalender");
        //    TextBox txt_MonthlyAttendanceCalender = (TextBox)grd.FindControl("txt_MonthlyAttendanceCalender");

        //    txt_MonthlyAttendanceCalender.Text = "";
        //    txt_MonthlyAttendanceCalender.Enabled = false;
        //}
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
    public void BindMonthlyAttendanceCalender(string Month,string Year)
    {
        try
        {
            //ds4MonthlyAttendanceCalender = objEmployeeMontlyAttendanceMasterManager.GetMonthlyAttendanceCalender(Convert.ToString(Session["EmployeeId"]).Trim());
            ds4MonthlyAttendanceCalender = objMonthlyAttendanceRegisterManager.GetMonthlyAttendanceCalender(Convert.ToString(Session["EmployeeId"]).Trim(),Month,Year);
            grdMonthlyAttendanceSummary.DataSource = ds4MonthlyAttendanceCalender.Tables[0];
            grdMonthlyAttendanceSummary.DataBind();
            Session["MonthlyAttendanceCalender"] = ds4MonthlyAttendanceCalender.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    private void BindCurrentDateAndTime()
    {
        DataTable _dt = objEmployeeMontlyAttendanceMasterManager.GetDateAndTime();
        if (_dt != null && _dt.Rows.Count > 0)
        {
            if (btnMarkIn.Enabled == true)
            {
                txtMarkInTime.Text = _dt.Rows[0]["CurrentTIme"].ToString();
            }
            else if (btnMarkOutTime.Enabled == true)
            {
                txtMarkOutTime.Text = _dt.Rows[0]["CurrentTIme"].ToString();
            }

            txtFullTime.Text = _dt.Rows[0]["FullDateTime"].ToString();

            DDD = Convert.ToDateTime(_dt.Rows[0]["FullDateTime"].ToString());
            hour = DDD.Hour;
            minute = DDD.Minute;
            date = DDD.Day;
            month = DDD.Month;
            year = DDD.Year;
            APM = Convert.ToDateTime(_dt.Rows[0]["FullDateTime"].ToString()).ToString("tt");
        }
    }

    
    public void PopulateDetails4AttendaceSummary(string EmpId, int Month, int Year)
    {
        try
        {
            DataSet dt4MonthlyAttendanceSummary = objMonthlyAttendanceRegisterManager.GetMonthlyAttendanceRegisterDetails(EmpId, Month, Year);
            if (dt4MonthlyAttendanceSummary.Tables[0].Rows.Count > 0)
            {
                foreach (GridViewRow grd in grdMonthlyAttendanceSummary.Rows)
                {
                    CheckBox chk_Date = (CheckBox)grd.FindControl("chk_Date");
                    TextBox txt_MarkInTime = (TextBox)grd.FindControl("txt_MarkInTime");
                    TextBox txt_MarkOutTime = (TextBox)grd.FindControl("txt_MarkOutTime");
                    TextBox txt_UpdatedMarkInTime = (TextBox)grd.FindControl("txt_UpdatedMarkInTime");
                    TextBox txt_UpdatedMarkOutTime = (TextBox)grd.FindControl("txt_UpdatedMarkOutTime");
                    Label lbl_Status = (Label)grd.FindControl("lbl_Status");

                    foreach (DataRow dr in dt4MonthlyAttendanceSummary.Tables[0].Rows)
                    {
                        if (Convert.ToString(chk_Date.Text).Trim() == Convert.ToString(dr["AttendanceDate"]).Trim())
                        {
                            chk_Date.Checked = true;
                            chk_Date.ForeColor = System.Drawing.Color.Purple;
                            txt_MarkInTime.Text = dr["MarkInTime"].ToString();
                            txt_MarkOutTime.Text = dr["MarkOutTime"].ToString();
                            txt_UpdatedMarkInTime.Text = dr["UpdatedMarkInTime"].ToString();
                            txt_UpdatedMarkOutTime.Text = dr["UpdatedMarkOutTime"].ToString();
                            lbl_Status.Text = dr["Status"].ToString();
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

    #region Get Details
    public void GetMarkInTime()
    {
        DataSet ds4GetMArkInTime = new DataSet();
        ds4GetMArkInTime = objMonthlyAttendanceRegisterManager.GetMonthlyAttendanceRegister4ID(Convert.ToString(txtCode.Text).Trim(), Convert.ToString(lblTodayDate.Text).Trim());

        if (ds4GetMArkInTime != null && ds4GetMArkInTime.Tables[0].Rows.Count > 0)
        {
            txtMarkInTime.Text = Convert.ToString(ds4GetMArkInTime.Tables[0].Rows[0]["MarkInTime"]).Trim();
        }
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

    #region Grid Events
    //Allowances Grid
    protected void grdMonthlyAttendanceSummary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //DataSet ds = new DataSet();
        //ds = objMonthlyAttendanceRegisterManager.GetMonthlyAttendanceRegisterDetails4Grid(Convert.ToString(txtCode.Text).Trim(), Convert.ToInt32(ddlMonth.SelectedValue.ToString().Trim()),Convert.ToInt32(ddlFinYear.SelectedValue.ToString().Trim())) ;
        //if (ds != null && ds.Tables[0].Rows.Count > 0)
        //{
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = ((DataRowView)e.Row.DataItem);
                Label lbl_Days = ((Label)e.Row.FindControl("lbl_Days"));
                Label lbl_Status = ((Label)e.Row.FindControl("lbl_Status"));
                TextBox txt_MarkInTime = ((TextBox)e.Row.FindControl("txt_MarkInTime"));
                TextBox txt_MarkOutTime = ((TextBox)e.Row.FindControl("txt_MarkOutTime"));
                CheckBox chk_Date = ((CheckBox)e.Row.FindControl("chk_Date"));

                if (Convert.ToString(lbl_Days.Text).Trim() == "WO")
                {
                    chk_Date.Enabled = false;
                    chk_Date.ForeColor = System.Drawing.Color.Red;
                    lbl_Days.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    chk_Date.Enabled = true;
                    lbl_Days.Visible = false;
                }

                DateTime dt1 = Convert.ToDateTime(Pages_Employee_frmMonthlyAttendance.ToDateTime1(chk_Date.Text));
                DateTime dt2 = Convert.ToDateTime(Pages_Employee_frmMonthlyAttendance.ToDateTime1(DateTime.Now.ToString("dd/MM/yyyy")));

                if (Convert.ToString(chk_Date.Text).Trim() == DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    chk_Date.Checked = true;
                    chk_Date.Enabled = false;
                    chk_Date.ForeColor = System.Drawing.Color.Green;
                    lblTodayDate.Text = chk_Date.Text;
                    lblTodayDate.Font.Bold = true;
                }
                else if (dt1 < dt2)
                {
                    chk_Date.Checked = false;
                    chk_Date.Enabled = false;
                    chk_Date.ForeColor = System.Drawing.Color.Blue;

                    if (Convert.ToString(txt_MarkInTime.Text).Trim() == "" && Convert.ToString(txt_MarkOutTime.Text).Trim() == "")
                    {
                        chk_Date.Checked = false;
                        lbl_Status.Text = "Absent";
                    }
                    else if (Convert.ToString(txt_MarkInTime.Text).Trim() != "" && Convert.ToString(txt_MarkOutTime.Text).Trim() != "")
                    {
                        chk_Date.Checked = true;
                        lbl_Status.Text = "Present";
                    }
                }
                else if (dt1 > dt2)
                {
                    chk_Date.Enabled = false;
                    chk_Date.Checked = false;
                }

                if (chk_Date.Checked == true && Convert.ToString(chk_Date.Text).Trim() == DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    DataSet ds4GetMArkInTime = new DataSet();
                    ds4GetMArkInTime = objMonthlyAttendanceRegisterManager.GetMonthlyAttendanceRegister4ID(Convert.ToString(txtCode.Text).Trim(), Convert.ToString(lblTodayDate.Text).Trim());

                    if (ds4GetMArkInTime != null && ds4GetMArkInTime.Tables[0].Rows.Count > 0)
                    {
                        txt_MarkInTime.Text = ds4GetMArkInTime.Tables[0].Rows[0]["MarkInTime"].ToString();
                        txt_MarkOutTime.Text = ds4GetMArkInTime.Tables[0].Rows[0]["MarkOutTime"].ToString();
                        lbl_Status.Text = ds4GetMArkInTime.Tables[0].Rows[0]["Status"].ToString();
                    }
                }
                else
                {
                    txt_MarkInTime.Text = "";
                    txt_MarkOutTime.Text = "";
                    txt_MarkOutTime.Enabled = false;
                }
            }
        //}
        //else
        //{ 
            
        //}
    }

    protected void grdMonthlyAttendanceSummary_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {

        }
    }

    protected void grdMonthlyAttendanceSummary_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdMonthlyAttendanceSummary_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion

    #region Button Click Event
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //lblMsg.Text = "";
        //try
        //{
        //    MonthlyAttendanceRegister objMonthlyAttendanceRegister = new MonthlyAttendanceRegister();

        //    setObjectInfor4Attendance(objMonthlyAttendanceRegister);

        //    if (btnSubmit.Text == "Submit")
        //    {
        //        foreach (ErrorHandlerClass err in objMonthlyAttendanceRegisterManager.SaveMonthlyAttendanceRegister(objMonthlyAttendanceRegister))
        //        {

        //            if (err.Type == "E")
        //            {
        //                lblMsg.Text = err.Message.ToString();
        //                break;
        //            }
        //            else if (err.Type == "A")
        //            {
        //                lblMsg.Text = err.Message.ToString();
        //                break;
        //            }
        //            else
        //            {
        //                if (lblMsg.Text.ToString() == "")
        //                {
        //                    lblMsg.Text = err.Message.ToString();
        //                    btnSubmit.Text = "Next Employee";
        //                    //Response.Redirect("ListOrchardMaster.aspx?OrchardCode=");
        //                }
        //            }
        //            iniControls();
        //        }
        //    }
        //    else
        //    {
        //        btnSubmit.Text = "Submit";
        //        TabContainer1.TabIndex = 0;
        //        iniControls();
        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblMsg.Text = "" + ex.Message.ToString();
        //    //objErrorLog.WriteErrorLog(ex.ToString());
        //}
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        iniControls();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        iniControls();
    }

    protected void btnMarkIn_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        try
        {
            BindCurrentDateAndTime();

            if (AttendanceStatus() == false)
            {
                lblAttendanceStatus.Text = "Half Day";
                lblAttendanceStatus.Visible = false;
            }

            MonthlyAttendanceRegister objMonthlyAttendanceRegister = new MonthlyAttendanceRegister();

            setObjectInfor4Attendance(objMonthlyAttendanceRegister);

            foreach (ErrorHandlerClass err in objMonthlyAttendanceRegisterManager.SaveMonthlyAttendanceRegister(objMonthlyAttendanceRegister))
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
                        btnMarkIn.Enabled = false;
                        btnMarkOutTime.Enabled = true;
                        txtRemarks.Enabled = true;
                        BindCurrentDateAndTime();
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

    protected void btnMarkOutTime_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        try
        {
            if (AttendanceStatus() == true)
            {
                lblAttendanceStatus.Text = "Present";
            }
            else
            {
                lblAttendanceStatus.Text = "Half Day";
            }

            BindCurrentDateAndTime();

            MonthlyAttendanceRegister objMonthlyAttendanceRegister = new MonthlyAttendanceRegister();

            setObjectInfor4Attendance(objMonthlyAttendanceRegister);

            foreach (ErrorHandlerClass err in objMonthlyAttendanceRegisterManager.SaveMonthlyAttendanceRegister(objMonthlyAttendanceRegister))
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
                        btnMarkOutTime.Enabled = false;
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
    #endregion

    #region SetobjectInfo
    public void setObjectInfor4Attendance(MonthlyAttendanceRegister objMonthlyAttendanceRegister)
    {
        objMonthlyAttendanceRegister.EmployeeId = Convert.ToString(txtCode.Text).Trim();
        objMonthlyAttendanceRegister.AttendanceDate = Convert.ToString(lblTodayDate.Text).Trim();

        if (Convert.ToString(txtMarkInTime.Text).Trim() != "")
        {
            objMonthlyAttendanceRegister.MarkInTime = Convert.ToString(txtMarkInTime.Text).Trim();
        }
        else
        {
            objMonthlyAttendanceRegister.MarkInTime = "00:00";
        }

        if (Convert.ToString(txtUpdatedMarkInTime.Text).Trim() != "")
        {
            objMonthlyAttendanceRegister.UpdatedMarkInTime = Convert.ToString(txtUpdatedMarkInTime.Text).Trim();
        }
        else
        {
            objMonthlyAttendanceRegister.UpdatedMarkInTime = "00:00";
        }

        if (Convert.ToString(txtMarkOutTime.Text).Trim() != "")
        {
            objMonthlyAttendanceRegister.MarkOutTime = Convert.ToString(txtMarkOutTime.Text).Trim();
        }
        else
        {
            objMonthlyAttendanceRegister.MarkOutTime = "00:00";
        }

        if (Convert.ToString(txtUpdatedMarkOutTime.Text).Trim() != "")
        {
            objMonthlyAttendanceRegister.UpdatedMarkOutTime = Convert.ToString(txtUpdatedMarkOutTime.Text).Trim();
        }
        else
        {
            objMonthlyAttendanceRegister.UpdatedMarkOutTime = "00:00";
        }

        if (Convert.ToString(txtRemarks.Text).Trim() != "")
        {
            objMonthlyAttendanceRegister.Remarks = Convert.ToString(txtRemarks.Text).Trim();
        }
        else
        {
            objMonthlyAttendanceRegister.Remarks = "";
        }

        if (Convert.ToString(lblAttendanceStatus.Text).Trim() != "")
        {
            objMonthlyAttendanceRegister.Status = Convert.ToString(lblAttendanceStatus.Text).Trim();
        }
        else
        {
            objMonthlyAttendanceRegister.Status = "";
        }

        if (ddlMonth.SelectedIndex >= 0)
        {
            objMonthlyAttendanceRegister.Month = Convert.ToInt32(ddlMonth.SelectedValue);
        }
        else
        {
            objMonthlyAttendanceRegister.Month = 0;
        }

        if (ddlFinYear.SelectedIndex >= 0)
        {
            objMonthlyAttendanceRegister.Year = Convert.ToInt32(ddlFinYear.SelectedValue);
        }
        else
        {
            objMonthlyAttendanceRegister.Year =0;
        }

        objMonthlyAttendanceRegister.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
        objMonthlyAttendanceRegister.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();
    }

    public ICollection<MonthlyAttendanceRegister> SetObjectInfo4Earnings()
    {
        List<MonthlyAttendanceRegister> lst = new List<MonthlyAttendanceRegister>();
        MonthlyAttendanceRegister objMonthlyAttendanceRegister = null;

        foreach (GridViewRow grd in grdMonthlyAttendanceSummary.Rows)
        {
            Label lbl_MonthlyAttendanceCalender = (Label)grd.FindControl("lbl_MonthlyAttendanceCalender");
            TextBox txt_MonthlyAttendanceCalender = (TextBox)grd.FindControl("txt_MonthlyAttendanceCalender");
            CheckBox chk_Date = (CheckBox)grd.FindControl("chk_Date");

        }

        return lst;
    }
    #endregion

    #region Selected Index Changed Event
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonth.SelectedIndex > 0 && ddlFinYear.SelectedIndex >0)
        {
            BindMonthlyAttendanceCalender(ddlMonth.SelectedValue, ddlFinYear.SelectedValue);
            PopulateDetails4AttendaceSummary(Convert.ToString(Session["EmployeeId"]).Trim(), Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlFinYear.SelectedValue));
        }
    }

    protected void ddlFinYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonth.SelectedIndex > 0 && ddlFinYear.SelectedIndex > 0)
        {
            BindMonthlyAttendanceCalender(ddlMonth.SelectedValue, ddlFinYear.SelectedValue);
            PopulateDetails4AttendaceSummary(Convert.ToString(Session["EmployeeId"]).Trim(), Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlFinYear.SelectedValue));
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

    #region Check Chanege Event
    protected void chk_Date_CheckChanged(object sender, EventArgs e)
    {
        int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox chk_Date = (CheckBox)grdMonthlyAttendanceSummary.Rows[selRowIndex].FindControl("chk_Date");
        TextBox txt_MarkInTime = (TextBox)grdMonthlyAttendanceSummary.Rows[selRowIndex].FindControl("txt_MarkInTime");
        TextBox txt_MarkOutTime = (TextBox)grdMonthlyAttendanceSummary.Rows[selRowIndex].FindControl("txt_MarkOutTime");
        TextBox txt_UpdatedMarkInTime = (TextBox)grdMonthlyAttendanceSummary.Rows[selRowIndex].FindControl("txt_UpdatedMarkInTime");
        TextBox txt_UpdatedMarkOutTime = (TextBox)grdMonthlyAttendanceSummary.Rows[selRowIndex].FindControl("txt_UpdatedMarkOutTime");

        if (chk_Date.Checked == true)
        {
            txt_MarkInTime.Text = "00:00";
            txt_MarkOutTime.Text = "00:00";
            txt_MarkInTime.Enabled = true;
            txt_MarkOutTime.Enabled = true;
        }
        else
        {
            txt_MarkInTime.Text = "";
            txt_MarkOutTime.Text = "";
            txt_MarkInTime.Enabled = false;
            txt_MarkOutTime.Enabled = false;
        }

        dt4MonthlyAttendanceCalender = (DataTable)Session["MonthlyAttendanceCalender"];
        dt4MonthlyAttendanceCalender.AcceptChanges();
        Session["MonthlyAttendanceCalender"] = (DataTable)dt4MonthlyAttendanceCalender;
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

        DateTime dt1 = Convert.ToDateTime(Pages_Employee_frmMonthlyAttendance.ToDateTime1(txtDateOfJoining.Text));
        DateTime dt2 = Convert.ToDateTime(Pages_Employee_frmMonthlyAttendance.ToDateTime1("31/03/2014"));

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

    #region Check Validation
    public bool AttendanceStatus()
    {
        bool IsPresent = true;

        if (hour == 9 && minute > 45 && APM == "AM")
        { 
            IsPresent = false;
        }
        else if (hour < 18 && minute >= 0 && APM == "PM")
        {
            IsPresent = false;
        }
        else
        {
            IsPresent = true;
        }
        return IsPresent;
    }
    #endregion


}