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
#region Development Details
//Shruti Dwivedi(18-10-2013)
#endregion Development Details

public partial class Pages_Admin_frmCallLetter : System.Web.UI.Page
{
    #region Global Variable Declaration
    CallLetterMaster _objCallLetterMaster = new CallLetterMaster();
    CallLetterMasterManager _objCallLetterMasterManager = new CallLetterMasterManager();
    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                BindGridview();
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            if (CheckData())
            {
                SetObjectInfo(_objCallLetterMaster);
                if (hdnCallLetterId.Value != "")
                {
                    _objCallLetterMaster.CallLetterMasterId = Convert.ToInt32(hdnCallLetterId.Value);
                    foreach (ErrorHandlerClass err in _objCallLetterMasterManager.UpdateCallLetterMaster(_objCallLetterMaster))
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
                                BindGridview();
                                hdnCallLetterId.Value = "";
                                btnAdd.Text = "Add";
                                Reset();
                            }
                        }

                    }
                }
                else
                {

                    foreach (ErrorHandlerClass err in _objCallLetterMasterManager.SaveCallLetterMaster(_objCallLetterMaster))
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
                                BindGridview();
                                Reset();
                            }
                        }

                    }
                }
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Input data is not in correct format";
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }

    }
    protected void gdvCallLetter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gdvCallLetter.PageIndex = e.NewPageIndex;
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    protected void Reset()
    {

        txtName.Text = "";
        txtDesignation.Text = "";
        txtEmail.Text = "";
        txtDate.Text = "";
        txtVenue.Text = "";
        txtFileName.Text = "";
        txtProjectSiteName.Text = "";


    }
    protected void gdvCallLetter_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "Edit")
        {

            int index = Convert.ToInt32(e.CommandArgument);

            HiddenField hdnDate = (HiddenField)gdvCallLetter.Rows[index].FindControl("hdnDate");
            HiddenField CallLetterId = (HiddenField)gdvCallLetter.Rows[index].FindControl("hdnCallLetterMasterId");
            Label gdvtxtName = (Label)gdvCallLetter.Rows[index].FindControl("gdvtxtName");
            Label gdvtxtEmailID = (Label)gdvCallLetter.Rows[index].FindControl("gdvtxtEmailID");
            Label gdvtxtDesignation = (Label)gdvCallLetter.Rows[index].FindControl("gdvtxtDesignation");
            Label gdvtxtVenue = (Label)gdvCallLetter.Rows[index].FindControl("gdvtxtVenue");
            Label InterviewDate = (Label)gdvCallLetter.Rows[index].FindControl("gdvtxtInterviewDate");
            Label FileName = (Label)gdvCallLetter.Rows[index].FindControl("gdvtxtFileName");
            Label ProjectSiteName = (Label)gdvCallLetter.Rows[index].FindControl("gdvtxtProjectSiteName");

            //  Label txtManagerName = (Label)gdvCallLetter.Rows[index].Cells[0].FindControl("txtManagerName");
            txtName.Text = gdvtxtName.Text;
            txtEmail.Text = gdvtxtEmailID.Text;
            txtDesignation.Text = gdvtxtDesignation.Text;
            txtVenue.Text = gdvtxtVenue.Text;
            string str = InterviewDate.Text;
            txtDate.Text = hdnDate.Value;
            txtFileName.Text = FileName.Text;
            txtProjectSiteName.Text = ProjectSiteName.Text;
            btnAdd.Text = "Update";
            hdnCallLetterId.Value = CallLetterId.Value;

        }
        else if (e.CommandName == "Delete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            HiddenField CallLetterId = (HiddenField)gdvCallLetter.Rows[index].FindControl("hdnCallLetterMasterId");
            _objCallLetterMaster.CallLetterMasterId = Convert.ToInt32(CallLetterId.Value);
            foreach (ErrorHandlerClass err in _objCallLetterMasterManager.DeleteCallLetterMaster(_objCallLetterMaster))
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
                        BindGridview();
                        Reset();
                    }
                }


            }
        }
        else
        {
            int index = Convert.ToInt32(e.CommandArgument);
            HiddenField CallLetterId = (HiddenField)gdvCallLetter.Rows[index].Cells[0].FindControl("hdnCallLetterMasterId");
            TextBox ManagerName = (TextBox)gdvCallLetter.Rows[index].Cells[0].FindControl("txtManagerName");
            //  string Id = CallLetterId.Value;
            //string m = ManagerName.Text;


            StringBuilder sb = new StringBuilder();
            sb.Append("<script language='javascript'>");
            sb.Append("window.open('../Admin/frmPrintCallLetter.aspx?CallLetterId=" + CallLetterId.Value + '-' + ManagerName.Text + "','CustomPop','height=500,width=900');");
            sb.Append("</script>");
            Type t = this.GetType();
            if (!ClientScript.IsClientScriptBlockRegistered(t, "PopupScript"))
                ClientScript.RegisterClientScriptBlock(t, "PopupScript", sb.ToString());
        }
    }
    protected void gdvCallLetter_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gdvCallLetter_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion Page Event

    #region Page Specific Event
    private void SetObjectInfo(CallLetterMaster _objCallLetterMaster)
    {
        _objCallLetterMaster.Name = txtName.Text;
        _objCallLetterMaster.Designation = txtDesignation.Text;
        _objCallLetterMaster.Venue = txtVenue.Text;
        _objCallLetterMaster.EmailId = txtEmail.Text;
        _objCallLetterMaster.InterviewDate = txtDate.Text;
        _objCallLetterMaster.CreatedBy = Session["EmployeeId"].ToString();
        _objCallLetterMaster.ModifiedBy = Session["EmployeeId"].ToString();
        _objCallLetterMaster.CFileName = txtFileName.Text;
        _objCallLetterMaster.ProjectSiteName = txtProjectSiteName.Text;
    }
    private bool CheckData()
    {
        bool _Flag = true;
        if (txtName.Text == "")
        {
            txtName.BorderColor = Color.Red;
            _Flag = false;
        }
        else
        {
            txtName.BorderColor = Color.Black;
        }
        if (txtDesignation.Text == "")
        {
            txtDesignation.BorderColor = Color.Red;
            _Flag = false;
        }
        else
        {
            txtDesignation.BorderColor = Color.Black;
        }
        if (txtEmail.Text == "")
        {
            txtEmail.BorderColor = Color.Red;
            _Flag = false;
        }
        else
        {
            txtEmail.BorderColor = Color.Black;
        }
        if (txtVenue.Text == "")
        {
            txtVenue.BorderColor = Color.Red;
            _Flag = false;
        }
        else
        {
            txtVenue.BorderColor = Color.Black;
        }
        if (txtDate.Text == "")
        {
            txtDate.BorderColor = Color.Red;
            _Flag = false;
        }
        else
        {
            txtDate.BorderColor = Color.Black;
        }
        if (txtFileName.Text == "")
        {
            txtFileName.BorderColor = Color.Red;
            _Flag = false;
        }
        else
        {
            txtFileName.BorderColor = Color.Black;
        }
        if (txtProjectSiteName.Text == "")
        {
            txtProjectSiteName.BorderColor = Color.Red;
            _Flag = false;
        }
        else
        {
            txtProjectSiteName.BorderColor = Color.Black;
        }
        return _Flag;
    }
    private void BindGridview()
    {
        DataTable _dt = _objCallLetterMasterManager.GetCallLetterMaster().Tables[0];
        gdvCallLetter.DataSource = _dt;
        gdvCallLetter.DataBind();
    }
    #endregion Page Specific Event

}