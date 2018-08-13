using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ErrorHandler;
using System.Drawing;
using System.Text;
using System.Configuration;
using HRMS_Classes;


public partial class Pages_Admin_frmUnitMaster : System.Web.UI.Page
{
    #region Global Variable Declaration

    UnitMaster _objUnitMaster = new UnitMaster();
    UnitMasterManager _objUnitMasterManager = new UnitMasterManager();
    //string ToMailId = ConfigurationSettings.AppSettings["EmailId"].ToString();

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
                    SetObjectInfo(_objUnitMaster);
                    if (txtUnitCode.ReadOnly != true)
                    {
                        lblMsg.Text = "";

                        foreach (ErrorHandlerClass err in _objUnitMasterManager.SaveUnitMaster(_objUnitMaster))
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
                        _objUnitMaster.UnitCode = txtUnitCode.Text;
                        DataTable dt1 = _objUnitMasterManager.GetUnitMasterById(_objUnitMaster.UnitCode).Tables[0];
                        foreach (ErrorHandlerClass err in _objUnitMasterManager.UpdateUnitMaster(_objUnitMaster))
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
                    Reset();
                    gdvUnit.EditIndex = -1;
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
                gdvUnit.EditIndex = -1;
                BindGridview();

            
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = ex.Message;
        }

    }
    protected void gdvUnit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
             if (e.CommandName.ToString() == "Edit")
                {
                    lblMsg.Text = "";
                    _objUnitMaster.UnitCode = e.CommandArgument.ToString();
                    DataTable dt = _objUnitMasterManager.GetUnitMasterById(_objUnitMaster.UnitCode).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        _objUnitMaster.setObjectInfo(dt.Rows[0]);
                        AssignVariabltoControl(_objUnitMaster);

                        gdvUnit.EditIndex = -1;
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
    protected void gdvUnit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            lblMsg.Text = "";
            int index = Convert.ToInt32(e.RowIndex);
            GridViewRow row = gdvUnit.Rows[index];
            Label lblIsDeleted = (Label)row.FindControl("lblIsDeleted");
            string UnitCode = Convert.ToString(row.Cells[2].Text).Trim();
            int IsDeleted = Convert.ToInt32(lblIsDeleted.Text);
            System.Web.UI.WebControls.Image Img4Delete = ((System.Web.UI.WebControls.Image)row.FindControl("Img4Delete"));
            System.Web.UI.WebControls.Image ImgTick = ((System.Web.UI.WebControls.Image)row.FindControl("ImgTick"));
            LinkButton btnDelete = ((LinkButton)row.FindControl("btnDelete"));

            if (IsDeleted == 0)
            {
                _objUnitMaster.ModifiedBy = Session["LoginId"].ToString();
                _objUnitMaster.UnitCode = UnitCode;
                _objUnitMaster.IsDeleted = 1;
                foreach (ErrorHandlerClass err in _objUnitMasterManager.DeleteUnitMaster(_objUnitMaster))
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


                            //DataTable dt = _objUnitMasterManager.GetUnitMasterById(_objUnitMaster.UnitCode).Tables[0];
                            //_objUnitMaster.setObjectInfo(dt.Rows[0]);
                            //string Body = CreateBody(_objUnitMaster,null,false);
                            //bool IsSuccess = MailMasterManager.SendEmail(ToMailId, "Changes(Delete) made by Admin!", Body);

                            
                                lblMsg.Font.Bold = true;
                                lblMsg.ForeColor = Color.Green;
                                lblMsg.Text = err.Message.ToString();
                                ImgTick.Visible = false;
                                Img4Delete.Visible = true;
                                gdvUnit.EditIndex = -1;
                                BindGridview();
                           

                        }
                    }
                }
            }
            else
            {
                _objUnitMaster.ModifiedBy = Session["LoginId"].ToString();
                _objUnitMaster.UnitCode = UnitCode;
                _objUnitMaster.IsDeleted = 0;
                foreach (ErrorHandlerClass err in _objUnitMasterManager.DeleteUnitMaster(_objUnitMaster))
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
                                gdvUnit.EditIndex = -1;
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
    protected void gdvUnit_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gdvUnit_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gdvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gdvUnit.PageIndex = e.NewPageIndex;
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
        txtUnitCode.Text = "";
        txtUnitName.Text = "";
        btnSave.Text = "Save";
        txtUnitCode.Enabled = true;
        txtUnitCode.ReadOnly = false;
       // lblMsg.Text = "";
    }

    private void SetObjectInfo(UnitMaster _objUnitMaster)
    {
        _objUnitMaster.UnitCode = txtUnitCode.Text;
        _objUnitMaster.UnitName = txtUnitName.Text;
        _objUnitMaster.CreatedBy = Session["LoginId"].ToString();
        _objUnitMaster.ModifiedBy = Session["LoginId"].ToString();
    }

    private bool CheckData()
    {
        Boolean _flag = true;
        if (!Validation.IsValidData(txtUnitCode, "AD", "10", true)) _flag = false;
        if (!Validation.IsValidData(txtUnitName, "AD", "30", true)) _flag = false;
        
        return _flag;
    }
    private void BindGridview()
    {
        gdvUnit.DataSource = _objUnitMasterManager.GetUnitMaster();
        gdvUnit.DataBind();
    }
    private void AssignVariabltoControl(UnitMaster _objUnitMaster)
    {
        txtUnitCode.Text = _objUnitMaster.UnitCode;
        txtUnitName.Text = _objUnitMaster.UnitName;
        txtUnitCode.ReadOnly = true;
        txtUnitCode.Enabled = false;
        btnSave.Text = "Update";
    }
   
    #endregion Page Specific Method

    
}