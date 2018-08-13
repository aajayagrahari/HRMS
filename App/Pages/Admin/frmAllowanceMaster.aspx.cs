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
//Shruti Dwivedi(07-10-2013)
#endregion Development Details

public partial class Pages_Admin_frmAllowanceMaster : System.Web.UI.Page
{
    #region Global Variable Declaration
    AllowanceMaster _objAllowanceMaster = new AllowanceMaster();
    AllowanceMasterManager _objAllowanceMasterManager = new AllowanceMasterManager();
    #endregion Global Variable Declaration
    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }

    }
    protected void gdvAllowance_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gdvAllowance.EditIndex = e.NewEditIndex;
            BindGridView();
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
   
    protected void gdvAllowance_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gdvAllowance.EditIndex = -1;
            BindGridView();
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    protected void gdvAllowance_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow row = gdvAllowance.Rows[e.RowIndex];
            HiddenField AllowanceId = (HiddenField)gdvAllowance.Rows[e.RowIndex].FindControl("hdnAllowanceId");
            TextBox Allowance = (TextBox)gdvAllowance.Rows[e.RowIndex].FindControl("gdvtxtAllowance");

            _objAllowanceMaster.AllowanceId = Convert.ToInt32(AllowanceId.Value);
            _objAllowanceMaster.Allowances = Allowance.Text;
            _objAllowanceMaster.ModifiedBy = Session["LoginId"].ToString();

            foreach (ErrorHandlerClass err in _objAllowanceMasterManager.UpdateAllowanceMaster(_objAllowanceMaster))
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
                        gdvAllowance.EditIndex = -1;
                        BindGridView();
                }

            }


        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (CheckData())
            {
                bool IsExistAllowance = _objAllowanceMasterManager.IsExistAllowance(txtAllowance.Text.Trim().Replace(" ",""));
                if (IsExistAllowance == false)
                {
                    SetObjectInfo(_objAllowanceMaster);
                    foreach (ErrorHandlerClass err in _objAllowanceMasterManager.SaveAllowanceMaster(_objAllowanceMaster))
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
                                BindGridView();

                            
                        }

                    }
                }
                else
                {
                    lblMsg.Text = "This Allowance is already exists.....";
                }
            }
            else
            {
                lblMsg.Text = "Input data is not Correct........";
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    #endregion Page Event

    #region Page Specific Function
    private void SetObjectInfo(AllowanceMaster _objAllowanceMaster)
    {
        _objAllowanceMaster.Allowances = txtAllowance.Text;
        _objAllowanceMaster.CreatedBy = Session["LoginId"].ToString();
        _objAllowanceMaster.ModifiedBy = Session["LoginId"].ToString();
    }
    private bool CheckData()
    {
        bool Flag=true;
        if (txtAllowance.Text == "")
        {
            txtAllowance.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtAllowance.BorderColor = Color.Black;
        }

        return Flag;
    }
    private void BindGridView()
    {
        DataTable _dt = _objAllowanceMasterManager.GetAllowanceMaster().Tables[0];
        gdvAllowance.DataSource = _dt;
        gdvAllowance.DataBind();
    }
    #endregion Page Specific Function

    protected void gdvAllowance_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            _objAllowanceMaster.AllowanceId = Convert.ToInt32(e.CommandArgument.ToString());
            foreach (ErrorHandlerClass err in _objAllowanceMasterManager.DeleteAllowanceMaster(_objAllowanceMaster))
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
                        BindGridView();

                    
                }

            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    protected void gdvAllowance_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}