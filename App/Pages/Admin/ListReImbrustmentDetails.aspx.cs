using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HRMS_Class;
using ErrorHandler;
using System.IO;
public partial class Pages_Admin_ListReImbrustmentDetails : System.Web.UI.Page
{
    ReimbursementManager objReimbursementManager = new ReimbursementManager();
    ReimbursementDetail _objReimbursementDetail = new ReimbursementDetail();

    ReimbursementDetailDetailManager _objReimbursementDetailDetailManager = new ReimbursementDetailDetailManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindReImburstment();
            BindVerifiedReImburstment();
        }
    }
    void BindReImburstment()
    {
        DataSet ds = new DataSet();
        ds = objReimbursementManager.GetReImburstmentDetails4Admin();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_ReImbrustment.DataSource = ds;
            gv_ReImbrustment.DataBind();
            btn_submit.Visible = true;
        }
        else
        {
            gv_ReImbrustment.DataSource = null;
            gv_ReImbrustment.DataBind();
            btn_submit.Visible = false;
           // lblMsg.Text = "Record Not Found !";
        
        }

    }
    void BindVerifiedReImburstment()
    {
        DataSet ds = new DataSet();
        ds = objReimbursementManager.GetReImburstmentDetails4Admin();
        if (ds.Tables[1].Rows.Count > 0)
        {
            gv_Verified.DataSource = ds.Tables[1];
            gv_Verified.DataBind();
          
        }
        else
        {
            gv_Verified.DataSource = null;
            gv_Verified.DataBind();
           // lblMsg.Text = "Record Not Found !";

        }

    }
    public ICollection<ReimbursementDetail> setObjectInforReimbursementDetail()
    {
        List<ReimbursementDetail> lst = new List<ReimbursementDetail>();
        ReimbursementDetail _objReimbursementDetail = null;
        for (int i = 0; i < gv_ReImbrustment.Rows.Count; i++)
        {

         RadioButtonList  rdo_approved = (RadioButtonList)gv_ReImbrustment.Rows[i].FindControl("rdo_approved");
        HiddenField     hdn_ReimbursementId = (HiddenField)gv_ReImbrustment.Rows[i].FindControl("hdn_ReimbursementId");

        if (rdo_approved.SelectedValue.ToString() !="")
        {
            _objReimbursementDetail = new ReimbursementDetail();
            _objReimbursementDetail.IsApprove = Convert.ToInt32(rdo_approved.SelectedValue.ToString());
            _objReimbursementDetail.ReimbursementDetailId = Convert.ToInt32(hdn_ReimbursementId.Value);
            _objReimbursementDetail.ApprovedBy = Session["LoginId"].ToString();
            _objReimbursementDetail.ModifiedBy = Session["LoginId"].ToString();
            _objReimbursementDetail.ApprovedDate = DateTime.Now.ToString();
            _objReimbursementDetail.ModifiedDate = DateTime.Now.ToString();
            lst.Add(_objReimbursementDetail);
        }

        }
        return lst;
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
      //  setObjectInforReimbursementDetail();

        foreach (ErrorHandlerClass err in _objReimbursementDetailDetailManager.SaveApprovedDisAprovedReimbursementDetail(setObjectInforReimbursementDetail()))
        {
            if (err.Type == "E")
            {
                
                lblMsg.ForeColor =System.Drawing.Color.Red;
                lblMsg.Text = err.Message.ToString();
                break;
            }
            else if (err.Type == "A")
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = err.Message.ToString();
                break;
            }
            else
            {
                if (err.Type == "S")
                {
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = err.Message.ToString();
                    BindReImburstment();
                    BindVerifiedReImburstment();
                }
            }

        }
    }
    protected void gv_ReImbrustment_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gv_ReImbrustment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_ReImbrustment.PageIndex = e.NewPageIndex;
        BindReImburstment();
    }
    protected void gv_Verified_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gv_Verified.PageIndex = e.NewPageIndex;
        BindVerifiedReImburstment();
    }
    protected void gv_Verified_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            Label lbl_approved = ((Label)e.Row.FindControl("lbl_approved"));
            Label lbl_isApprove = ((Label)e.Row.FindControl("lbl_isApprove"));
            int approved = Convert.ToInt32(lbl_approved.Text);
            if (approved == 0)
            {
                lbl_isApprove.Text = "DisApproved";
            }
            if (approved == 1)
            {
                lbl_isApprove.Text = "Approved";
            }
        
        }
    }
}