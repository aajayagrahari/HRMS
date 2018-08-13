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
#region Development Details
//Shruti Dwivedi(23-09-2013)
#endregion Development Details


public partial class Pages_Admin_frmApproveEmployeeLeave : System.Web.UI.Page
{
    #region Global Variable Declaration
    EmployeeLeaveDetailMaster1 _objEmployeeLeaveDetailMaster = new EmployeeLeaveDetailMaster1();
    EmployeeLeaveDetailMasterManager1 _objEmployeeLeaveDetailMasterManager = new EmployeeLeaveDetailMasterManager1();
    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindEmployeeLeaveDetail();
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }

    protected void gdvApproveLeave_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gdvApproveLeave.Rows[index];
            
            HiddenField LeaveId = (HiddenField)row.FindControl("hdnLeaveId");
            RadioButtonList ApproveDisapprove = (RadioButtonList)row.FindControl("rblApproceDisApprove");
            TextBox Remarks = (TextBox)row.FindControl("txtRemark");

            _objEmployeeLeaveDetailMaster.LeaveId = Convert.ToInt32(LeaveId.Value);
            DataTable _dt = _objEmployeeLeaveDetailMasterManager.GetEmployeeLeaveDetailById(Convert.ToInt32(_objEmployeeLeaveDetailMaster.LeaveId)).Tables[0];
            _objEmployeeLeaveDetailMaster.SetObjectInfo(_dt.Rows[0]);

            _objEmployeeLeaveDetailMaster.IsApproved = ApproveDisapprove.SelectedValue;
            _objEmployeeLeaveDetailMaster.Remark = Remarks.Text;
            _objEmployeeLeaveDetailMaster.ApprovedBy = Session["LoginId"].ToString();
            _objEmployeeLeaveDetailMaster.ApprovedDate = DateTime.Now.ToString();

            foreach (ErrorHandlerClass err in _objEmployeeLeaveDetailMasterManager.UpdateEmployeeLeaveDetail(_objEmployeeLeaveDetailMaster))
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
                        BindEmployeeLeaveDetail();
                        lblMsg.Text = "Successfully Submitted";
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
    private void BindEmployeeLeaveDetail()
    {
        try
        {
            DataSet ds = _objEmployeeLeaveDetailMasterManager.GetEmployeeLeaveDetail();
            gdvApproveLeave.DataSource = ds.Tables[0];
            gdvApproveLeave.DataBind();

            gdvApproveDisApprove.DataSource = ds.Tables[1];
            gdvApproveDisApprove.DataBind();
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    #endregion Page Specific Function

}