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
//Shruti Dwivedi(21-10-2013)
#endregion Development Details

public partial class Pages_Admin_frmPostMaster : System.Web.UI.Page
{
    #region Global Variable Declaration
    PostMaster _objPostMaster = new PostMaster();
    PostMasterManager _objPostMasterManager = new PostMasterManager();
    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindDDl();
                BindGridview();
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
            lblMsg.Text = "";
            if (CheckData())
            {
                SetObjectInfo(_objPostMaster);
                if (hdnPostId1.Value != "")
                {
                    _objPostMaster.PostId = hdnPostId1.Value;
                    foreach (ErrorHandlerClass err in _objPostMasterManager.UpdatePostMaster(_objPostMaster))
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
                                hdnPostId1.Value = "";
                                txtPost.Text = "";
                                txtPostDetail.Text = "";
                                txtMaxAge.Text = "";
                                txtMinAge.Text = "";
                                BindGridview();
                            }
                        }

                    }
                }
                else
                {
                    foreach (ErrorHandlerClass err in _objPostMasterManager.SavePostMaster(_objPostMaster))
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
                                hdnPostId1.Value = "";
                                txtPost.Text = "";
                                txtPostDetail.Text = "";
                                BindGridview();
                            }
                        }

                    }
                }
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Input Data is not in correct format.";
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    protected void gdvPostDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
    protected void gdvPostDetail_RowEditing(object sender, GridViewEditEventArgs e)
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
    protected void gdvPostDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblMsg.Text="";
            if (e.CommandName == "Delete")
            {
                Int32 Index = Convert.ToInt32(e.CommandArgument);
                HiddenField PostId = (HiddenField)gdvPostDetail.Rows[Index].FindControl("hdnPostId");
                _objPostMaster.PostId = PostId.Value;
                foreach (ErrorHandlerClass err in _objPostMasterManager.DeletePostMaster(_objPostMaster))
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
                        }
                    }

                }
            }
            else
            {
                Int32 Index = Convert.ToInt32(e.CommandArgument);
                HiddenField PostId = (HiddenField)gdvPostDetail.Rows[Index].FindControl("hdnPostId");
                Label PostName = (Label)gdvPostDetail.Rows[Index].FindControl("lblPostName");
                Label PostDetail = (Label)gdvPostDetail.Rows[Index].FindControl("lblPostDetail");
                Label MinAge = (Label)gdvPostDetail.Rows[Index].FindControl("lblMinAge");
                Label MaxAge = (Label)gdvPostDetail.Rows[Index].FindControl("lblMaxge");
                hdnPostId1.Value = PostId.Value;
                txtPost.Text = PostName.Text;
                txtPostDetail.Text = PostDetail.Text;
                txtMinAge.Text = MinAge.Text;
                txtMaxAge.Text = MaxAge.Text;
                btnSave.Text = "Update";
              

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
    private bool CheckData()
    {
        bool _flag=true;
        if (txtPost.Text == "")
        {
            txtPost.BorderColor = Color.Red;
            _flag = false;
        }
        else
            txtPost.BorderColor = Color.Black;
        if (txtMinAge.Text == "")
        {
            txtMinAge.BorderColor = Color.Red;
            _flag = false;
        }
        else
            txtMinAge.BorderColor = Color.Black;
        if (txtMaxAge.Text == "")
        {
            txtMaxAge.BorderColor = Color.Red;
            _flag = false;
        }
        else
            txtMaxAge.BorderColor = Color.Black;

        return _flag;
    }
    private void SetObjectInfo(PostMaster _objPostMaster)
    {
        _objPostMaster.AdvertisementId =Convert.ToInt32(ddlAdvertisement.SelectedValue);
        _objPostMaster.PostName = txtPost.Text;
        _objPostMaster.PostDescription = txtPostDetail.Text;
        _objPostMaster.CreatedBy = Session["LoginId"].ToString();
        _objPostMaster.ModifiedBy = Session["LoginId"].ToString();
        _objPostMaster.MaxAge = Convert.ToInt32(txtMaxAge.Text);
        _objPostMaster.MinAge = Convert.ToInt32(txtMinAge.Text);
    }
    private void BindDDl()
    {
        DataTable _dt = _objPostMasterManager.getAdvertisement().Tables[0];
        ddlAdvertisement.DataSource = _dt;
        ddlAdvertisement.DataTextField = _dt.Columns["txt"].ToString();
        ddlAdvertisement.DataValueField = _dt.Columns["val"].ToString();
        ddlAdvertisement.DataBind();
        ddlAdvertisement.Enabled = false;
    }
    private void BindGridview()
    {
        DataTable _dt = _objPostMasterManager.GetPostMasterMain().Tables[0];
        gdvPostDetail.DataSource = _dt;
        gdvPostDetail.DataBind();
    }
    
    #endregion Page Specific Method


    protected void gdvPostDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvPostDetail.PageIndex = e.NewPageIndex;
        BindGridview();
    }
}