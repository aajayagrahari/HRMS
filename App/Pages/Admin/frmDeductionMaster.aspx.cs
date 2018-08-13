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

public partial class Pages_Admin_frmDeductionMaster : System.Web.UI.Page
{
    #region Global Variable Declaration

    DeductionMaster _objDeductionMaster = new DeductionMaster();
    DeductionMasterManager _objDeductionMasterManager = new DeductionMasterManager();
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
    protected void gdvDeduction_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gdvDeduction.EditIndex = e.NewEditIndex;
            BindGridView();
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    protected void gdvDeduction_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gdvDeduction.EditIndex = -1;
            BindGridView();
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

                bool IsExistAllowance = _objDeductionMasterManager.IsExistDeduction(txtDeduction.Text.Trim().Replace(" ", ""));
                if (IsExistAllowance == false)
                {

                    SetObjectInfo(_objDeductionMaster);
                    foreach (ErrorHandlerClass err in _objDeductionMasterManager.SaveDeductionMaster(_objDeductionMaster))
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
                                BindGridView();

                            }
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
    protected void gdvDeduction_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Delete")
            {
                _objDeductionMaster.DesuctionId = Convert.ToInt32(e.CommandArgument.ToString());
                foreach (ErrorHandlerClass err in _objDeductionMasterManager.DeleteDeductionMaster(_objDeductionMaster))
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
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    protected void gdvDeduction_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion Page Event

    #region Page Specific Function
    private void SetObjectInfo(DeductionMaster _objDeductionMaster)
    {
        _objDeductionMaster.Deductions = txtDeduction.Text;
        _objDeductionMaster.DeductionPercentage = txtPercentage.Text;
        _objDeductionMaster.CreatedBy = Session["LoginId"].ToString();
        _objDeductionMaster.ModifiedBy = Session["LoginId"].ToString();
    }
    private bool CheckData()
    {
        bool Flag=true;
        if (txtDeduction.Text == "")
        {
            txtDeduction.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtDeduction.BorderColor = Color.Black;
        }
        if (txtPercentage.Text == "")
        {
            txtPercentage.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtPercentage.BorderColor = Color.Black;
        }

        return Flag;
    }
    private void BindGridView()
    {
        DataTable _dt = _objDeductionMasterManager.GetDeductionMaster().Tables[0];
        gdvDeduction.DataSource = _dt;
        gdvDeduction.DataBind();
    }
    #endregion Page Specific Function


    protected void gdvDeduction_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {

            GridViewRow row = gdvDeduction.Rows[e.RowIndex];
            HiddenField DesuctionId = (HiddenField)gdvDeduction.Rows[e.RowIndex].FindControl("hdnDeductionId");
            TextBox Desuction = (TextBox)gdvDeduction.Rows[e.RowIndex].FindControl("gdvtxtDeduction");
            TextBox DesuctionPerCentage = (TextBox)gdvDeduction.Rows[e.RowIndex].FindControl("txtDeductionPercentage");

            _objDeductionMaster.DesuctionId = Convert.ToInt32(DesuctionId.Value);
            _objDeductionMaster.Deductions = Desuction.Text;
            _objDeductionMaster.DeductionPercentage = DesuctionPerCentage.Text;
            _objDeductionMaster.ModifiedBy = Session["LoginId"].ToString();

            foreach (ErrorHandlerClass err in _objDeductionMasterManager.UpdateDeductionMaster(_objDeductionMaster))
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
                    gdvDeduction.EditIndex = -1;
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
}