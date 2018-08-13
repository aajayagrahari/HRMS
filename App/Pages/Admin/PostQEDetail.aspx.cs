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
//Shruti Dwivedi(25-10-2013)
#endregion Development Details

public partial class Pages_Admin_PostQEDetail : System.Web.UI.Page
{
    #region Global Variable Declaration
    PostQEDetail _objPostQEDetail = new PostQEDetail();
    PostQEDetailManager _objPostQEDetailManager = new PostQEDetailManager();
    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindPostDDl();
                BindGridView();
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }

    }
    protected void gdvPostQEDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            if (e.CommandName == "Delete")
            {
               
                Int32 Index = Convert.ToInt32(e.CommandArgument);
                HiddenField PoseQEID = (HiddenField)gdvPostQEDetail.Rows[Index].FindControl("hdnPostQEIdId");
                _objPostQEDetail.PostQEDetailId = PoseQEID.Value;
                foreach (ErrorHandlerClass err in _objPostQEDetailManager.DeletePostQEDetail(_objPostQEDetail))
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
                Int32 Index = Convert.ToInt32(e.CommandArgument);
                HiddenField PoseQEID = (HiddenField)gdvPostQEDetail.Rows[Index].FindControl("hdnPostQEIdId");
                HiddenField PostId = (HiddenField)gdvPostQEDetail.Rows[Index].FindControl("hdnPostId");
                HiddenField Type = (HiddenField)gdvPostQEDetail.Rows[Index].FindControl("hdnType");
                HiddenField EType = (HiddenField)gdvPostQEDetail.Rows[Index].FindControl("hdnEType");
                Label Qualification = (Label)gdvPostQEDetail.Rows[Index].FindControl("lblQualification");
                Label Experience = (Label)gdvPostQEDetail.Rows[Index].FindControl("lblExperience");

                ddlPost.SelectedValue = PostId.Value;
                hdnPostQEIdId1.Value = PoseQEID.Value;
                rblEssentialandDesirable.SelectedValue = Type.Value;
                txtExperienceDetail.Text = Experience.Text;
                txtQualificationDetail.Text = Qualification.Text;
                rdo_education_type.SelectedValue = EType.Value;
                btnSave.Text = "Update";
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
       
    }
    protected void gdvPostQEDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gdvPostQEDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (CheckData())
            {
                lblMsg.Text = "";
                SetObjectInfo(_objPostQEDetail);
                if (hdnPostQEIdId1.Value != "")
                {
                    _objPostQEDetail.PostQEDetailId = hdnPostQEIdId1.Value;
                    foreach (ErrorHandlerClass err in _objPostQEDetailManager.UpdatePostQEDetail(_objPostQEDetail))
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
                                txtExperienceDetail.Text = "";
                                txtQualificationDetail.Text = "";
                                rdo_education_type.SelectedValue = null;
                                rblEssentialandDesirable.SelectedValue = null;
                                ddlPost.SelectedIndex = 0;
                                btnSave.Text = "Save";
                                BindGridView();
                            }
                        }

                    }
                }
                else
                {
                    foreach (ErrorHandlerClass err in _objPostQEDetailManager.SavePostQEDetail(_objPostQEDetail))
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
                        else if (err.Type == "S")
                        {
                            
                                lblMsg.ForeColor = Color.Green;
                                lblMsg.Text ="Record Saved Successfully.";
                                txtExperienceDetail.Text = "";
                                txtQualificationDetail.Text = "";
                                rdo_education_type.SelectedValue = null;
                                rblEssentialandDesirable.SelectedValue = null;
                                ddlPost.SelectedIndex = 0;
                                btnSave.Text = "Save";
                                BindGridView();
                        }

                    }
                }
                BindGridView();
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Input data is not in correct in  format.";
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    protected void gdvPostQEDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvPostQEDetail.PageIndex = e.NewPageIndex;
        BindGridView();
    }
    #endregion Page Event

    #region Page Specific Method
    private void BindPostDDl()
    {

        DataTable _dt = _objPostQEDetailManager.GetPost().Tables[0];
        ddlPost.DataSource = _dt;
        ddlPost.DataValueField = _dt.Columns["val"].ToString();
        ddlPost.DataTextField = _dt.Columns["txt"].ToString();
        ddlPost.DataBind();
        ddlPost.Items.Insert(0, "Select");

        
    }
    private void SetObjectInfo(PostQEDetail _objPostQEDetail)
    {
        _objPostQEDetail.PostId = ddlPost.SelectedValue;
        _objPostQEDetail.QualificationDetail = txtQualificationDetail.Text;
        _objPostQEDetail.ExperienceDetail = txtExperienceDetail.Text;
        _objPostQEDetail.QualificationType = rblEssentialandDesirable.SelectedValue;
        _objPostQEDetail.EType = rdo_education_type.SelectedValue.ToString();
        _objPostQEDetail.CreatedBy = Session["LoginId"].ToString();
        _objPostQEDetail.ModifiedBy = Session["LoginId"].ToString();
    }
    private bool CheckData()
    {
        bool Flag = true;
        if (ddlPost.SelectedIndex == 0)
        {
            ddlPost.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            ddlPost.BorderColor = Color.Black;
        }
        //if (txtExperienceDetail.Text == "")
        //{
        //    txtExperienceDetail.BorderColor = Color.Red;
        //    Flag = false;
        //}
        //else
        //{
        //    txtExperienceDetail.BorderColor = Color.Black;
        //}
        if (txtExperienceDetail.Text == "")
        {
            if (txtQualificationDetail.Text == "")
            {
                txtQualificationDetail.BorderColor = Color.Red;
                Flag = false;
            }
            else
            {
                txtQualificationDetail.BorderColor = Color.Black;
            }
        }
        if (rblEssentialandDesirable.SelectedValue == null)
        {
            rblEssentialandDesirable.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            rblEssentialandDesirable.BorderColor = Color.Black;
        }

        if (rdo_education_type.SelectedValue == null)
        {
            rdo_education_type.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            rdo_education_type.BorderColor = Color.Black;
        }
        return Flag;
    }
    private void BindGridView()
    {
        DataTable _dt = _objPostQEDetailManager.GetPostQEDetail().Tables[0];
        gdvPostQEDetail.DataSource = _dt;
        gdvPostQEDetail.DataBind();
    }
    
    #endregion Page Specific Method
   
}