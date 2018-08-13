using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HRMS_Classes;
using ErrorHandler;
using ErrorHandler;
using System.Drawing;
using System.Text;
using System.Configuration;


public partial class Pages_Admin_frmSubUnitMaster : System.Web.UI.Page
{
    #region Global Variable Declaration

    SubUnitMaster _objSubUnitMaster = new SubUnitMaster();
    SubUnitMasterManager _objSubUnitMasterManager = new SubUnitMasterManager();
    UnitMasterManager _objUnitMasterManager = new UnitMasterManager();
    #endregion Global Variable Declaration

    #region Page Event

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindGridview();
                ddlUnit.DataSource = _objUnitMasterManager.GetUnit4Combo();
                ddlUnit.DataValueField = "UnitCode";
                ddlUnit.DataTextField = "UnitName";
                ddlUnit.DataBind();
                ddlUnit.Items.Insert(0, "Select");
            }
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = ex.Message;
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
                if (CheckData())
                {
                    SetObjectInfo(_objSubUnitMaster);
                    if (txtSubUnitCode.ReadOnly != true)
                    {
                        lblMsg.Text = "";

                        foreach (ErrorHandlerClass err in _objSubUnitMasterManager.SaveSubUnitMaster(_objSubUnitMaster))
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
                                    lblMsg.ForeColor = Color.Green;
                                    lblMsg.Font.Bold = true;
                                    lblMsg.Text = err.Message.ToString();
                                }
                            }

                        }
                    }
                    else
                    {
                        _objSubUnitMaster.SubUnitCode = txtSubUnitCode.Text;
                        DataTable dt1 = _objSubUnitMasterManager.GetSubUnitMasterById(_objSubUnitMaster.SubUnitCode).Tables[0];
                        foreach (ErrorHandlerClass err in _objSubUnitMasterManager.UpdateSubUnitMaster(_objSubUnitMaster))
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
                                    DataTable dt = _objSubUnitMasterManager.GetSubUnitMasterById(_objSubUnitMaster.SubUnitCode).Tables[0];
                                    _objSubUnitMaster.setObjectInfo(dt.Rows[0]);
                                   
                                  
                                       lblMsg.ForeColor = Color.Green;
                                       lblMsg.Font.Bold = true;
                                       lblMsg.Text = err.Message.ToString();
                                  
                                    
                                }
                            }

                        }
                    }
                    Reset();
                    gdvSubUnit.EditIndex = -1;
                    BindGridview();
                }
                else
                {
                    lblMsg.Text = "!! Input data is not according to the instructions in Yellow Background Field. Please check it carefully.";
                }
            
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = ex.Message;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            
                Reset();
                lblMsg.Text = "";
                gdvSubUnit.EditIndex = -1;
                BindGridview();

            
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = ex.Message;
        }

    }
    protected void gdvSubUnit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
             if (e.CommandName.ToString() == "Edit")
                {
                    lblMsg.Text = "";
                    _objSubUnitMaster.SubUnitCode = e.CommandArgument.ToString();
                    DataTable dt = _objSubUnitMasterManager.GetSubUnitMasterById(_objSubUnitMaster.SubUnitCode).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        _objSubUnitMaster.setObjectInfo(dt.Rows[0]);
                        AssignVariabltoControl(_objSubUnitMaster);

                        gdvSubUnit.EditIndex = -1;
                        BindGridview();
                    }
                    else
                    {
                        lblMsg.Font.Bold = true;
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Text = "This record is deleted,so if you want to edit this, then please activate this record";
                    }
                    
                }
                    
                
            
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = ex.Message;
        }

    }
    protected void gdvSubUnit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            lblMsg.Text = "";
            int index = Convert.ToInt32(e.RowIndex);
            GridViewRow row = gdvSubUnit.Rows[index];
            Label lblIsDeleted = (Label)row.FindControl("lblIsDeleted");
            string StationCode = Convert.ToString(row.Cells[2].Text).Trim();
            int IsDeleted = Convert.ToInt32(lblIsDeleted.Text);
            System.Web.UI.WebControls.Image Img4Delete = ((System.Web.UI.WebControls.Image)row.FindControl("Img4Delete"));
            System.Web.UI.WebControls.Image ImgTick = ((System.Web.UI.WebControls.Image)row.FindControl("ImgTick"));
            LinkButton btnDelete = ((LinkButton)row.FindControl("btnDelete"));

            if (IsDeleted == 0)
            {
                _objSubUnitMaster.ModifiedBy = Session["LoginId"].ToString();
                _objSubUnitMaster.SubUnitCode = StationCode;
                _objSubUnitMaster.IsDeleted = 1;
                foreach (ErrorHandlerClass err in _objSubUnitMasterManager.DeleteSubUnitMaster(_objSubUnitMaster))
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


                            DataTable dt = _objSubUnitMasterManager.GetSubUnitMasterById(_objSubUnitMaster.SubUnitCode).Tables[0];
                            _objSubUnitMaster.setObjectInfo(dt.Rows[0]);
                          
                                lblMsg.Font.Bold = true;
                                lblMsg.ForeColor = Color.Green;
                                lblMsg.Text = err.Message.ToString();
                                ImgTick.Visible = false;
                                Img4Delete.Visible = true;
                                gdvSubUnit.EditIndex = -1;
                                BindGridview();
                          

                        }
                    }
                }
            }
            else
            {
                _objSubUnitMaster.ModifiedBy = Session["LoginId"].ToString();
                _objSubUnitMaster.SubUnitCode = StationCode;
                _objSubUnitMaster.IsDeleted = 0;
                foreach (ErrorHandlerClass err in _objSubUnitMasterManager.DeleteSubUnitMaster(_objSubUnitMaster))
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
                           
                                lblMsg.Font.Bold = true;
                                //lblMsg.Text = err.Message.ToString();
                                lblMsg.ForeColor = Color.Green;
                                lblMsg.Text = "Successfully Activated";
                                ImgTick.Visible = true;
                                Img4Delete.Visible = false;
                                gdvSubUnit.EditIndex = -1;
                                BindGridview();
                           
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = ex.Message;
        }

    }
    protected void gdvSubUnit_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gdvSubUnit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = ((DataRowView)e.Row.DataItem);
                LinkButton btnDelete = ((LinkButton)e.Row.FindControl("btnDelete"));
                LinkButton btnEdit = ((LinkButton)e.Row.FindControl("btnEdit"));
                System.Web.UI.WebControls.Image Img4Delete = ((System.Web.UI.WebControls.Image)e.Row.FindControl("Img4Delete"));
                System.Web.UI.WebControls.Image ImgTick = ((System.Web.UI.WebControls.Image)e.Row.FindControl("ImgTick"));
                Label lblIsDeleted = ((Label)e.Row.FindControl("lblIsDeleted"));

                if (Convert.ToInt32(lblIsDeleted.Text) != 0)
                {
                    ImgTick.Visible = false;
                    Img4Delete.Visible = true;
                    btnEdit.Visible = false;
                }
                else
                {
                    ImgTick.Visible = true;
                    Img4Delete.Visible = false;
                    btnEdit.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = ex.Message;
        }
    }
    protected void gdvSubUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gdvSubUnit.PageIndex = e.NewPageIndex;
            BindGridview();
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = ex.Message;
        }
    }

    #endregion Page Event

    #region Page Specific Method
    private void Reset()
    {
        txtSubUnitCode.Text = "";
        txtSubUnitName.Text = "";
        btnSave.Text = "Save";
        txtSubUnitCode.Enabled = true;
        txtSubUnitCode.ReadOnly = false;
       // lblMsg.Text = "";
    }
    private void SetObjectInfo(SubUnitMaster _objSubUnitMaster)
    {
        _objSubUnitMaster.SubUnitCode = txtSubUnitCode.Text;
        _objSubUnitMaster.SubUnitName = txtSubUnitName.Text;
        _objSubUnitMaster.UnitCode = ddlUnit.SelectedValue;
        _objSubUnitMaster.CreatedBy = Session["LoginId"].ToString();
        _objSubUnitMaster.ModifiedBy = Session["LoginId"].ToString();
    }
    private bool CheckData()
    {
        Boolean _flag = true;
        if (!Validation.IsValidData(txtSubUnitCode, "AD", "10", true)) _flag = false;
        if (!Validation.IsValidData(txtSubUnitName, "AD", "30", true)) _flag = false;
        
        return _flag;
    }
    private void BindGridview()
    {
        gdvSubUnit.DataSource = _objSubUnitMasterManager.GetSubUnitMaster();
        gdvSubUnit.DataBind();
    }

    private void AssignVariabltoControl(SubUnitMaster _objSubUnitMaster)
    {
        txtSubUnitCode.Text = _objSubUnitMaster.SubUnitCode;
        txtSubUnitName.Text = _objSubUnitMaster.SubUnitName;
        txtSubUnitCode.ReadOnly = true;
        txtSubUnitCode.Enabled = false;
        btnSave.Text = "Update";
    }
    #endregion Page Specific Method

    
}