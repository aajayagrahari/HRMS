using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ErrorHandler;
using HRMS_Class;
using System.Drawing;

#region Development Details
//Shruti Dwivedi(25-09-2013)
#endregion Development Details

public partial class Pages_Admin_frmApproveUpdatedAttendance : System.Web.UI.Page
{
    #region Global Variable Declaration
    BindComboMasterManager _objBindComboMasterManager = new BindComboMasterManager();
    EmployeeAttendanceMaster _objEmployeeAttendanceMaster = new EmployeeAttendanceMaster();
    EmployeeAttendanceMasterManager _objEmployeeAttendanceMasterManager = new EmployeeAttendanceMasterManager();
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
    protected void DDLYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlEmployee.SelectedItem.Text != "Select" && ddlMonth.SelectedItem.Text != "Select" && DDLYear.SelectedItem.Text != "Select")
            {
                BindGridView(ddlEmployee.SelectedValue, ddlMonth.SelectedValue, DDLYear.SelectedValue);
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
        try
        {
            if (ddlEmployee.SelectedItem.Text != "Select" && ddlMonth.SelectedItem.Text != "Select" && DDLYear.SelectedItem.Text != "Select")
            {
                BindGridView(ddlEmployee.SelectedValue, ddlMonth.SelectedValue, DDLYear.SelectedValue);
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            
            foreach (ErrorHandlerClass err in _objEmployeeAttendanceMasterManager.UpdateEmployeeAttendanceCollection(_objEmployeeAttendanceMaster, SetObjectInfoCollection()))
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
                        if (ddlEmployee.SelectedItem.Text != "Select" && ddlMonth.SelectedItem.Text != "Select" && DDLYear.SelectedItem.Text != "Select")
                        {
                            BindGridView(ddlEmployee.SelectedValue, ddlMonth.SelectedValue, DDLYear.SelectedValue);
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
    protected void rblApproveDisApprove_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            int selRowIndex = ((GridViewRow)(((RadioButtonList)sender).Parent.Parent)).RowIndex;
           // CheckBox chk_Date = (CheckBox)gdvPendingAttendanse.Rows[selRowIndex].FindControl("chk_Date");
            RadioButtonList isApprove = (RadioButtonList)gdvPendingAttendanse.Rows[selRowIndex].FindControl("rblApproveDisApprove");
            TextBox MarkInTime = (TextBox)gdvPendingAttendanse.Rows[selRowIndex].FindControl("txtMarkinTime");
            TextBox MarkOutTime = (TextBox)gdvPendingAttendanse.Rows[selRowIndex].FindControl("txtMarkOutTime");
            TextBox UpdatedMarkInTime = (TextBox)gdvPendingAttendanse.Rows[selRowIndex].FindControl("txtUpdatedMarkinTime");
            TextBox UpdatedMarkOutTime = (TextBox)gdvPendingAttendanse.Rows[selRowIndex].FindControl("txtUpdatedMarkOutTime");

            if (isApprove.SelectedValue == "Approve")
            {
                MarkInTime.Text = UpdatedMarkInTime.Text;
                MarkOutTime.Text = UpdatedMarkOutTime.Text;
            }
            else
            {
                MarkInTime.Text = "";
                MarkOutTime.Text = "";
            }
            
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlEmployee.SelectedItem.Text != "Select" && ddlMonth.SelectedItem.Text != "Select" && DDLYear.SelectedItem.Text != "Select")
            {
                BindGridView(ddlEmployee.SelectedValue, ddlMonth.SelectedValue, DDLYear.SelectedValue);
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    #endregion Page Event

    #region Page Specific Method
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




        string[] str = finyear.Split('-');
        dr["val"] = str[0];
        dr["txt"] = str[0];



        dt.Rows.Add(dr);
        dr1["val"] = str[1];
        dr1["txt"] = str[1];

        dt.Rows.Add(dr1);

        return dt;
    }
    private void BindGridView(string EmployeeId, string Month, string Year)
    {
        DataSet _ds = _objEmployeeAttendanceMasterManager.getUpdatedAttendance(EmployeeId, Month, Year);
        gdvPendingAttendanse.DataSource = _ds.Tables[0];
        gdvPendingAttendanse.DataBind();
        if (_ds.Tables[0].Rows.Count > 0)
        {
            rowSubmit.Visible = true;
        }
        else
        {
            rowSubmit.Visible = false;
        }
        gdvApproved.DataSource = _ds.Tables[1];
        gdvApproved.DataBind();

    }
    public ICollection<EmployeeAttendanceMaster> SetObjectInfoCollection()
    {
        
        List<EmployeeAttendanceMaster> lst = new List<EmployeeAttendanceMaster>();
        string EmployeeId = Session["EmployeeId"].ToString();
        EmployeeAttendanceMaster _objEmployeeAttendanceMaster = null;
        for (int i = 0; i < gdvPendingAttendanse.Rows.Count; i++)
        {

            TextBox AttendanceDate = (TextBox)gdvPendingAttendanse.Rows[i].FindControl("txtAttendanceDate");  
            CheckBox chk = (CheckBox)gdvPendingAttendanse.Rows[i].FindControl("chkSelect");
            TextBox MarkinTime = (TextBox)gdvPendingAttendanse.Rows[i].FindControl("txtMarkinTime");
            TextBox MarkOutTime = (TextBox)gdvPendingAttendanse.Rows[i].FindControl("txtMarkOutTime");
            RadioButtonList isApprove = (RadioButtonList)gdvPendingAttendanse.Rows[i].FindControl("rblApproveDisApprove");
            TextBox Remark = (TextBox)gdvPendingAttendanse.Rows[i].FindControl("txtRemark");
            HiddenField AttendanceId = (HiddenField)gdvPendingAttendanse.Rows[i].FindControl("hdnAttendanceId");
            
            
            if (chk.Checked == true)
            {
                _objEmployeeAttendanceMaster = new EmployeeAttendanceMaster();
                
                DataTable _dt = _objEmployeeAttendanceMasterManager.GetEmployeeAttendanceById(Convert.ToInt64(AttendanceId.Value)).Tables[0];
                _objEmployeeAttendanceMaster.SetObjectInfo(_dt.Rows[0]);
                _objEmployeeAttendanceMaster.AttendanceId = Convert.ToInt32(AttendanceId.Value);
               // _objEmployeeAttendanceMaster.EmployeeId = Convert.ToInt64(Session["EmployeeId"].ToString());
                _objEmployeeAttendanceMaster.MarkIntime = MarkinTime.Text;
                _objEmployeeAttendanceMaster.ApprovalRemark = Remark.Text;
                _objEmployeeAttendanceMaster.MarkOutTime = MarkOutTime.Text;
                if (isApprove.SelectedValue == "Approve")
                {
                    _objEmployeeAttendanceMaster.IsApprived =1;
                    _objEmployeeAttendanceMaster.AlertMessasg = "";
                    _objEmployeeAttendanceMaster.MarkOutAlertMessasg = "";
                }
                else
                {
                    _objEmployeeAttendanceMaster.IsApprived = 0;
                    _objEmployeeAttendanceMaster.AlertMessasg = "DisApprove";
                    _objEmployeeAttendanceMaster.MarkOutAlertMessasg = "DisApprove";
                }
                _objEmployeeAttendanceMaster.IsSubmitted = true;
                _objEmployeeAttendanceMaster.ApprovedBy = Session["LoginId"].ToString();
                _objEmployeeAttendanceMaster.ApprovedDate = DateTime.Now.ToString();
              //  _objEmployeeAttendanceMaster.AlertMessasg = "";
               // _objEmployeeAttendanceMaster.MarkOutAlertMessasg = "";
                _objEmployeeAttendanceMaster.ApprovalRemark = Remark.Text;
                _objEmployeeAttendanceMaster.MarkInDate = AttendanceDate.Text;
                _objEmployeeAttendanceMaster.MarkOutDate = AttendanceDate.Text;
                lst.Add(_objEmployeeAttendanceMaster);

            }
        }
        return lst;
    }
    #endregion Page Specific Method



   
}