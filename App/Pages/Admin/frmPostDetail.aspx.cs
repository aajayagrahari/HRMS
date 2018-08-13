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
//Shruti Dwivedi(24-10-2013)
#endregion Development Details

public partial class Pages_Admin_frmPostDetail : System.Web.UI.Page
{
    #region Global Variable Declaration
    PostMasterManager _objPostMasterManager = new PostMasterManager();
    PostDetailMaster _objPostDetailMaster = new PostDetailMaster();
    PostDetailMasterManager _objPostDetailMasterManager = new PostDetailMasterManager();
    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindGridView();
                //if(gdvPostDetail.Rows[0].FindControl(""))
                //SetObjectInfo4PostDetail();
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
                if (btnSave.Text == "Update")
                {
                    foreach (ErrorHandlerClass err in _objPostDetailMasterManager.UpdatePostDetailMasterCollection(SetObjectInfo4PostDetail()))
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
                                Response.Redirect("frmListTraineeMaster.aspx", false);
                            }
                        }

                    }
                }
                else
                {
                    foreach (ErrorHandlerClass err in _objPostDetailMasterManager.SavePostDetailMasterCollection(SetObjectInfo4PostDetail()))
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
                                Response.Redirect("frmListTraineeMaster.aspx", false);
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
    protected void gdvPostDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvPostDetail.PageIndex = e.NewPageIndex;
        BindGridView();
    }
    #endregion Page Event

    #region Page Specific Method
    private void BindGridView()
    {
        DataTable _dt = _objPostMasterManager.GetPostMaster().Tables[0];
        gdvPostDetail.DataSource = _dt;
        gdvPostDetail.DataBind();
    }
    private ICollection<PostDetailMaster> SetObjectInfo4PostDetail()
    {
        List<PostDetailMaster> lst = new List<PostDetailMaster>();
        PostDetailMaster _objPostDetailMaster = null;
        for (int i = 0; i < gdvPostDetail.Rows.Count; i++)
        {
            //CheckBox chk = new CheckBox();
            //chk = (CheckBox)gdvPostDetail.Rows[i].FindControl("chkSelect");
            //Label EmployeeId = (Label)gdvPostDetail.Rows[i].FindControl("gdvlblId");
           // if (chk.Checked)
            //{
            HiddenField PostId = (HiddenField)gdvPostDetail.Rows[i].FindControl("hdnPostId");
            HiddenField hdnPostDetailID = (HiddenField)gdvPostDetail.Rows[i].FindControl("hdnPostDetailID");

            CheckBox chkGenral = (CheckBox)gdvPostDetail.Rows[i].FindControl("chkGenral");
            CheckBox chkST = (CheckBox)gdvPostDetail.Rows[i].FindControl("chkST");
            CheckBox chkSC = (CheckBox)gdvPostDetail.Rows[i].FindControl("chkSC");
            CheckBox chkOBC = (CheckBox)gdvPostDetail.Rows[i].FindControl("chkOBC");
            CheckBox chkPH = (CheckBox)gdvPostDetail.Rows[i].FindControl("chkPH");

            TextBox txtGNFee = (TextBox)gdvPostDetail.Rows[i].FindControl("txtGNFee");
            TextBox txtSTFee = (TextBox)gdvPostDetail.Rows[i].FindControl("txtSTFee");
            TextBox txtSCFee = (TextBox)gdvPostDetail.Rows[i].FindControl("txtSCFee");
            TextBox txtOBCFee = (TextBox)gdvPostDetail.Rows[i].FindControl("txtOBCFee");
            TextBox txtPHFee = (TextBox)gdvPostDetail.Rows[i].FindControl("txtPHFee");

            TextBox txtGNVac = (TextBox)gdvPostDetail.Rows[i].FindControl("txtGNVac");
            TextBox txtSTVac = (TextBox)gdvPostDetail.Rows[i].FindControl("txtSTVac");
            TextBox txtSCVac = (TextBox)gdvPostDetail.Rows[i].FindControl("txtSCVac");
            TextBox txtOBCVac = (TextBox)gdvPostDetail.Rows[i].FindControl("txtOBCVac");
            TextBox txtPHVac = (TextBox)gdvPostDetail.Rows[i].FindControl("txtPHVac");
            



            _objPostDetailMaster = new PostDetailMaster();
            //int a = ChkList.Items.Count;
            if (chkGenral.Checked == true)
            {
                _objPostDetailMaster.IsGenral = true;
            }
            if (chkST.Checked == true)
            {
                _objPostDetailMaster.IsST = true;
            }
            if (chkSC.Checked == true)
            {
                _objPostDetailMaster.IsSC = true;
            }
            if (chkOBC.Checked == true)
            {
                _objPostDetailMaster.IsOBC = true;
            }
            if (chkPH.Checked == true)
            {
                _objPostDetailMaster.IsPH = true;
            }
            _objPostDetailMaster.GenralSeat = Convert.ToInt32(txtGNVac.Text == "" ? "0" : txtGNVac.Text);
            _objPostDetailMaster.STSeat = Convert.ToInt32(txtSTVac.Text=="" ? "0" : txtSTVac.Text);
            _objPostDetailMaster.SCSeat = Convert.ToInt32(txtSCVac.Text=="" ? "0" : txtSCVac.Text);
            _objPostDetailMaster.OBCSeat = Convert.ToInt32(txtOBCVac.Text=="" ? "0" :txtOBCVac.Text );
            _objPostDetailMaster.PHSeat = Convert.ToInt32(txtPHVac.Text=="" ? "0" :txtPHVac.Text );

            _objPostDetailMaster.GenralAmt = txtGNFee.Text;
            _objPostDetailMaster.STAmt = txtSTFee.Text;
            _objPostDetailMaster.SCAmt = txtSCFee.Text;
            _objPostDetailMaster.OBCAmt = txtOBCFee.Text;
            _objPostDetailMaster.PHAmt = txtPHFee.Text;
            _objPostDetailMaster.PostId = PostId.Value;
             _objPostDetailMaster.CreatedBy = Session["LoginId"].ToString();
             _objPostDetailMaster.ModifiedBy = Session["LoginId"].ToString();
             _objPostDetailMaster.CreatedDate = DateTime.Now.ToString();
             _objPostDetailMaster.ModifiedDate = DateTime.Now.ToString();

             _objPostDetailMaster.PostIdDetailId = hdnPostDetailID.Value;
                lst.Add(_objPostDetailMaster);

            
        }

        return lst;
    }
    private bool CheckData()
    {
        bool Flag=true;
        for (int i = 0; i < gdvPostDetail.Rows.Count; i++)
        {
            HiddenField PostId = (HiddenField)gdvPostDetail.Rows[i].FindControl("hdnPostId");
           

            CheckBox chkGenral = (CheckBox)gdvPostDetail.Rows[i].FindControl("chkGenral");
            CheckBox chkST = (CheckBox)gdvPostDetail.Rows[i].FindControl("chkST");
            CheckBox chkSC = (CheckBox)gdvPostDetail.Rows[i].FindControl("chkSC");
            CheckBox chkOBC = (CheckBox)gdvPostDetail.Rows[i].FindControl("chkOBC");
            CheckBox chkPH = (CheckBox)gdvPostDetail.Rows[i].FindControl("chkPH");



            TextBox txtGNFee = (TextBox)gdvPostDetail.Rows[i].FindControl("txtGNFee");
            TextBox txtSTFee = (TextBox)gdvPostDetail.Rows[i].FindControl("txtSTFee");
            TextBox txtSCFee = (TextBox)gdvPostDetail.Rows[i].FindControl("txtSCFee");
            TextBox txtOBCFee = (TextBox)gdvPostDetail.Rows[i].FindControl("txtOBCFee");
            TextBox txtPHFee = (TextBox)gdvPostDetail.Rows[i].FindControl("txtPHFee");

            TextBox txtGNVac = (TextBox)gdvPostDetail.Rows[i].FindControl("txtGNVac");
            TextBox txtSTVac = (TextBox)gdvPostDetail.Rows[i].FindControl("txtSTVac");
            TextBox txtSCVac = (TextBox)gdvPostDetail.Rows[i].FindControl("txtSCVac");
            TextBox txtOBCVac = (TextBox)gdvPostDetail.Rows[i].FindControl("txtOBCVac");
            TextBox txtPHVac = (TextBox)gdvPostDetail.Rows[i].FindControl("txtPHVac");
          
            if (chkGenral.Checked == false && chkST.Checked == false && chkSC.Checked == false && chkOBC.Checked == false &&
                chkPH.Checked == false)
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Please select at least one category in all Post";
                break;
            }
            else
            {
                if (chkGenral.Checked == true && txtGNFee.Text == "" && txtGNVac.Text == "")
                {
                    Flag = false;
                    txtGNFee.BorderColor = Color.Red;
                    txtGNVac.BorderColor = Color.Red;
                    // break;
                }
                else
                {
                    txtGNFee.BorderColor = Color.Black;
                    txtGNVac.BorderColor = Color.Black;
                }
                if (chkST.Checked == true && txtSTFee.Text == "" && txtSTVac.Text == "")
                {
                    Flag = false;
                    txtSTFee.BorderColor = Color.Red;
                    txtSTVac.BorderColor = Color.Red;
                    //break;
                }
                else
                {
                    txtSTFee.BorderColor = Color.Black;
                    txtSTVac.BorderColor = Color.Black;
                }
                if (chkSC.Checked == true && txtSCFee.Text == "" && txtSCVac.Text == "")
                {
                    Flag = false;
                    txtSCFee.BorderColor = Color.Red;
                    txtSCVac.BorderColor = Color.Red;
                    //break;
                }
                else
                {
                    txtSCFee.BorderColor = Color.Black;
                    txtSCVac.BorderColor = Color.Black;
                }
                if (chkOBC.Checked == true && txtOBCFee.Text == "" && txtOBCVac.Text == "")
                {
                    Flag = false;
                    txtOBCFee.BorderColor = Color.Red;
                    txtOBCVac.BorderColor = Color.Red;
                    //break;
                }
                else
                {
                    txtOBCFee.BorderColor = Color.Black;
                    txtOBCVac.BorderColor = Color.Black;
                }
                if (chkPH.Checked == true && txtPHFee.Text == "" && txtPHVac.Text == "")
                {
                    Flag = false;
                    txtPHFee.BorderColor = Color.Red;
                    txtPHVac.BorderColor = Color.Red;
                    // break;
                }
                else
                {
                    txtPHFee.BorderColor = Color.Black;
                    txtPHVac.BorderColor = Color.Black;
                }
            }
            
           


        }

        return Flag;
    }
    #endregion Page Specific Method


    
}