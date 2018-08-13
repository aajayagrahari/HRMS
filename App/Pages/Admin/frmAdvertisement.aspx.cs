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

public partial class Pages_Admin_frmAdvertisement : System.Web.UI.Page
{
    #region Global Variable Declaration
    AdvertisemetnMaster _objAdvertisemetnMaster = new AdvertisemetnMaster();
    AdvertisemetnMasterManager _objAdvertisemetnMasterManager = new AdvertisemetnMasterManager();
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
            
            lblmsg.Text = ee.StackTrace;
            lblmsg.ForeColor = Color.Red;
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (CheckData())
            {
                if (upd_job.PostedFile.FileName.Length == 0)
                {

                    lblmsg.Text = "Choose Job File";
                    upd_job.Focus();
                    return;
                }
                else
                {
                    SetObjectInfo(_objAdvertisemetnMaster);
                    if (hdnAdvertisementId1.Value != "")
                    {
                        _objAdvertisemetnMaster.AdvertisementId = Convert.ToInt32(hdnAdvertisementId1.Value);
                        foreach (ErrorHandlerClass err in _objAdvertisemetnMasterManager.UpdateAdvertisemetnMaster(_objAdvertisemetnMaster))
                        {
                            if (err.Type == "E")
                            {

                                lblmsg.ForeColor = Color.Red;
                                lblmsg.Text = err.Message.ToString();
                                break;
                            }
                            else if (err.Type == "A")
                            {
                                lblmsg.ForeColor = Color.Red;
                                lblmsg.Text = err.Message.ToString();
                                break;
                            }
                            else
                            {
                                if (lblmsg.Text.ToString() == "")
                                {
                                    lblmsg.ForeColor = Color.Green;
                                    lblmsg.Text = err.Message.ToString();
                                    BindGridView();
                                    Reset();

                                }
                            }

                        }
                    }
                    else
                    {
                        foreach (ErrorHandlerClass err in _objAdvertisemetnMasterManager.SaveAdvertisemetnMaster(_objAdvertisemetnMaster))
                        {
                            if (err.Type == "E")
                            {

                                lblmsg.ForeColor = Color.Red;
                                lblmsg.Text = err.Message.ToString();
                                break;
                            }
                            else if (err.Type == "A")
                            {
                                lblmsg.ForeColor = Color.Red;
                                lblmsg.Text = err.Message.ToString();
                                break;
                            }
                            else
                            {
                                if (lblmsg.Text.ToString() == "")
                                {
                                    lblmsg.ForeColor = Color.Green;
                                    lblmsg.Text = err.Message.ToString();
                                    BindGridView();
                                    Reset();
                                }
                            }

                        }
                    }
                }
            }
            else
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = "Input data is not in correct format.";
            }
        }
        catch (Exception ee)
        {

            lblmsg.Text = ee.StackTrace;
            lblmsg.ForeColor = Color.Red;
        }

    }
    protected void gdvAdvertisementDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            
        }
        catch (Exception ee)
        {

            lblmsg.Text = ee.StackTrace;
            lblmsg.ForeColor = Color.Red;
        }

    }
    protected void gdvAdvertisementDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
        }
        catch (Exception ee)
        {

            lblmsg.Text = ee.StackTrace;
            lblmsg.ForeColor = Color.Red;
        }

    }
    protected void gdvAdvertisementDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (e.CommandName == "Delete")
            {
                Int32 index = Convert.ToInt32(e.CommandArgument);
                HiddenField AdvertisementId = (HiddenField)gdvAdvertisementDetail.Rows[index].FindControl("hdnAdvertisementId");
                _objAdvertisemetnMaster.AdvertisementId = Convert.ToInt32(AdvertisementId.Value);
                foreach (ErrorHandlerClass err in _objAdvertisemetnMasterManager.DeleteAdvertisemetnMaster(_objAdvertisemetnMaster))
                {
                    if (err.Type == "E")
                    {

                        lblmsg.ForeColor = Color.Red;
                        lblmsg.Text = err.Message.ToString();
                        break;
                    }
                    else if (err.Type == "A")
                    {
                        lblmsg.ForeColor = Color.Red;
                        lblmsg.Text = err.Message.ToString();
                        break;
                    }
                    else
                    {
                        if (lblmsg.Text.ToString() == "")
                        {
                            lblmsg.ForeColor = Color.Green;
                            lblmsg.Text = err.Message.ToString();
                            BindGridView();
                        }
                    }

                }
             
                    
            }
            else if (e.CommandName == "Download")
            {

                Int32 index = Convert.ToInt32(e.CommandArgument);
                HiddenField AdvertisementId = (HiddenField)gdvAdvertisementDetail.Rows[index].FindControl("hdnAdvertisementId");
                
                DataSet dt = new DataSet();
                dt = _objAdvertisemetnMasterManager.GetAdvertisemetnMasterById(Convert.ToInt32(AdvertisementId.Value));
                if (dt.Tables[0].Rows.Count > 0)
                {
                    string filename = dt.Tables[0].Rows[0]["PDFFileName"].ToString();
                    string Advertisement = "~/Jobs/" + filename;
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.Charset = "";
                    response.ContentType = "application/pdf";
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                    Response.TransmitFile(Advertisement);
                    response.End();
                }
            }
            else
            {
                Int32 index = Convert.ToInt32(e.CommandArgument);
                HiddenField AdvertisementId = (HiddenField)gdvAdvertisementDetail.Rows[index].FindControl("hdnAdvertisementId");
                Label Advertisement = (Label)gdvAdvertisementDetail.Rows[index].FindControl("lblAdvertisement");
                Label OpeningDate = (Label)gdvAdvertisementDetail.Rows[index].FindControl("lblOpeningDate");
                Label ClosingDate = (Label)gdvAdvertisementDetail.Rows[index].FindControl("lblClosingDate");
                Label Discription = (Label)gdvAdvertisementDetail.Rows[index].FindControl("lblDescription");
                hdnAdvertisementId1.Value = AdvertisementId.Value;

                txtAdvertisement.Text = Advertisement.Text;
                txtOpeningDate.Text = OpeningDate.Text;
                txtClosingDate.Text = ClosingDate.Text;
                txtDiscription.Text = Discription.Text;
                btnSave.Text = "Update";


            }
        }
        catch (Exception ee)
        {

            lblmsg.Text = ee.StackTrace;
            lblmsg.ForeColor = Color.Red;
        }
    }
    #endregion Page Event

    #region Page Specific Method
    private void SetObjectInfo(AdvertisemetnMaster _objAdvertisemetnMaster)
    {
        _objAdvertisemetnMaster.AdvertisementName = txtAdvertisement.Text;
        _objAdvertisemetnMaster.OpeningDate = txtOpeningDate.Text;
        _objAdvertisemetnMaster.ClosingDate = txtClosingDate.Text;
        _objAdvertisemetnMaster.AdverDescription = txtDiscription.Text;
        _objAdvertisemetnMaster.CreatedBy = Session["LoginId"].ToString();
        _objAdvertisemetnMaster.ModifiedBy = Session["LoginId"].ToString();
        if (upd_job.PostedFile.ContentLength > 0)
        {
            string date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string second = DateTime.Now.Second.ToString();
            string fileName = date + upd_job.FileName;
            string path = Server.MapPath("~/Jobs/" + fileName);
            upd_job.SaveAs(path);
            _objAdvertisemetnMaster.PDFFileName = fileName;
           
        }
    }
    private bool CheckData()
    {
        bool _flag = true;
        if (txtAdvertisement.Text == "")
        {
            txtAdvertisement.BorderColor = Color.Red;
            _flag = false;
        }
        else
        {
            txtAdvertisement.BorderColor = Color.Black;
        }
        if (txtClosingDate.Text == "")
        {
            txtClosingDate.BorderColor = Color.Red;
            _flag = false;
        }
        else
        {
            txtClosingDate.BorderColor = Color.Black;
        }
        if (txtOpeningDate.Text == "")
        {
            txtOpeningDate.BorderColor = Color.Red;
            _flag = false;
        }
        else
        {
            txtOpeningDate.BorderColor = Color.Black;
        }
        if (txtDiscription.Text == "")
        {
            txtDiscription.BorderColor = Color.Red;
            _flag = false;
        }
        else
        {
            txtDiscription.BorderColor = Color.Black;
        }
        return _flag;
    }
    private void Reset()
    {
        txtAdvertisement.Text = "";
        txtOpeningDate.Text = "";
        txtClosingDate.Text = "";
        txtDiscription.Text = "";
        hdnAdvertisementId1.Value = "";
        btnSave.Text = "Save";
    }
    private void BindGridView()
    {
        gdvAdvertisementDetail.DataSource = _objAdvertisemetnMasterManager.GetAdvertisemetnMaster();
        gdvAdvertisementDetail.DataBind();
    }
    #endregion Page Specific Method

}