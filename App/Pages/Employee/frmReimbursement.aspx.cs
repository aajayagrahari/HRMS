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
using System.Globalization;
#region Development Details
//Shruti Dwivedi(19-10-2013)
#endregion Development Details

public partial class Pages_Employee_frmReimbursement : System.Web.UI.Page
{
    #region Global Variable Declaration
    Reimbursement _objReimbursement=new Reimbursement();
    ReimbursementManager _objReimbursementManager=new ReimbursementManager();
    ReimbursementDetail _objReimbursementDetail = new ReimbursementDetail();

    ReimbursementDetailDetailManager _objReimbursementDetailDetailManager = new ReimbursementDetailDetailManager();
    EmployeeMasterDetails _objEmployeeMasterDetails = new EmployeeMasterDetails();
    EmployeeMasterDetailsManager _objEmployeeMasterDetailsManager = new EmployeeMasterDetailsManager();
    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    txtEmployeeId.Text = Session["EmployeeId"].ToString();
                    DataTable _dt = _objEmployeeMasterDetailsManager.GetEmployeeMaster4ID(txtEmployeeId.Text).Tables[0];
                    _objEmployeeMasterDetails.SetObjectInfo(_dt.Rows[0]);
                    if (_dt.Rows[0]["MiddleName"].ToString() != "")
                    {
                        txtEmployeeName.Text = (_dt.Rows[0]["FirstName"].ToString() + _dt.Rows[0]["MiddleName"].ToString() + _dt.Rows[0]["LastName"].ToString());
                    }
                    else{
                        txtEmployeeName.Text = (_dt.Rows[0]["FirstName"].ToString()+ _dt.Rows[0]["LastName"].ToString());
                    }
                    txtDepartment.Text = _dt.Rows[0]["DepartmentName"].ToString();
                    BindSubmittedGridView(txtEmployeeId.Text);
                   
                }
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
            if (CheckData())
            {
                EnableandDisableControl(false);
                lnkEdit.Visible = true;

                if (btnAdd.Text == "Update")
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)ViewState["MyTable"];

                    if (dt != null)
                    {



                        if (dt != null && ViewState["rowid"] != null)
                        {

                            int index = Convert.ToInt32(ViewState["rowid"].ToString());
                            // dt.Rows[index]["ExpanceId"] = Convert.ToString(ddl_fruit_type.SelectedValue.ToString());
                            dt.Rows[index]["Date"] =txtDate.Text;
                            dt.Rows[index]["Description"] = txtDescription.Text;
                            dt.Rows[index]["Category"] = txtCategory.Text;
                            dt.Rows[index]["Cost"] = txtCost.Text;
                            dt.AcceptChanges();
                            ViewState["MyTable"] = dt;
                            DataTable dt1 = new DataTable();
                            dt1 = (DataTable)ViewState["MyTable"];
                            BindGridview(dt1);
                        }
                    }

                }
                else
                {
                    DataTable _dt;

                    if (ViewState["MyTable"] == null)
                    {
                        _dt = new DataTable("MyTable");
                        _dt.Columns.Add("ExpanceId");
                        _dt.Columns.Add("Date");
                        _dt.Columns.Add("Description");
                        _dt.Columns.Add("Category");
                        _dt.Columns.Add("Cost");


                    }
                    else
                    {
                        _dt = (DataTable)ViewState["MyTable"];
                    }
                    DataRow dr;
                    dr = _dt.NewRow();
                    dr["ExpanceId"] = (_dt.Rows.Count + 1);
                    dr["Date"] = txtDate.Text;
                    dr["Description"] = txtDescription.Text;
                    dr["Category"] = txtCategory.Text;
                    dr["Cost"] = txtCost.Text;
                    _dt.Rows.Add(dr);
                    ViewState["MyTable"] = _dt;
                    BindGridview(ViewState["MyTable"] as DataTable);
                    Reset();
                }
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Input data is not in correct format....";
            }

        }
        catch (Exception ee)
        {

            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (gdvExpenceDetail.Rows.Count > 0)
            {
                SetObjectInfo(_objReimbursement);
                foreach (ErrorHandlerClass err in _objReimbursementManager.SaveReimbursement(_objReimbursement, setObjectInforReimbursementDetail()))
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
                            BindSubmittedGridView(txtEmployeeId.Text);
                        }
                    }

                }
            }
            else
            {
                lblMsg.Text = "No Record Found !";
            }
        }
        catch (Exception ee)
        {

            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    protected void gdvExpenceDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                HiddenField ExpenceId = (HiddenField)gdvExpenceDetail.Rows[index].FindControl("hdnExpanceId");
                Label lblDate = (Label)gdvExpenceDetail.Rows[index].FindControl("lblDate");
                Label lblDescription = (Label)gdvExpenceDetail.Rows[index].FindControl("lblDescription");
                Label lblCategory = (Label)gdvExpenceDetail.Rows[index].FindControl("lblCategory");
                Label lblCost = (Label)gdvExpenceDetail.Rows[index].FindControl("lblCost");

                txtDate.Text = lblDate.Text;
                txtDescription.Text = lblDescription.Text;
                txtCategory.Text = lblCategory.Text;
                txtCost.Text = lblCost.Text;
                btnAdd.Text = "Update";
                ViewState["rowid"] = index;
            }
            else
            {
                int index = Convert.ToInt32(e.CommandArgument);

                DataTable dt = new DataTable();
                dt = (DataTable)ViewState["MyTable"];
                dt.Rows.RemoveAt(index);
                BindGridview(dt);
            }
        }
        catch (Exception ee)
        {

            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    protected void gdvExpenceDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        

    }
    protected void gdvExpenceDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            SetObjectInfo(_objReimbursement);
            EnableandDisableControl(false);
            btnUpdate.Visible = false;
            
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }

    }
    protected void lnkEdit_Click1(object sender, EventArgs e)
    {
        try
        {
            EnableandDisableControl(true);
            btnUpdate.Visible = true;
            lnkEdit.Visible = false;
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }



    }
    #endregion Page Event

    #region Page Specific Event
    private void BindGridview(DataTable _dt)
    {
        gdvExpenceDetail.DataSource = _dt;
        gdvExpenceDetail.DataBind();

    }
    private void Reset()
    {
        txtDate.Text = "";
        txtDescription.Text = "";
        txtCategory.Text = "";
        txtCost.Text = "";
    }
    private void EnableandDisableControl(bool value)
    {
        txtEmployeeId.Enabled = value;
        txtEmployeeName.Enabled = value;
        txtManagerName.Enabled = value;
        txtDepartment.Enabled = value;
        txtFromDate.Enabled = value;
        txtToDate.Enabled = value;
        txtBusinessPurpose.Enabled = value;
    }
    private void SetObjectInfo(Reimbursement _objReimbursement)
    {
        _objReimbursement.EmployeeId = txtEmployeeId.Text;
        _objReimbursement.EmployeeName = txtEmployeeName.Text;
        _objReimbursement.ManagerName = txtManagerName.Text;
        _objReimbursement.Department = txtDepartment.Text;
        _objReimbursement.FromDate =txtFromDate.Text;
        _objReimbursement.ToDate =txtToDate.Text;
        _objReimbursement.BusinessPurpose = txtBusinessPurpose.Text;
        _objReimbursement.CreatedBy = Session["LoginId"].ToString();
        _objReimbursement.ModifiedBy = Session["LoginId"].ToString();
    }
    public ICollection<ReimbursementDetail> setObjectInforReimbursementDetail()
    {
        List<ReimbursementDetail> lst = new List<ReimbursementDetail>();
        ReimbursementDetail _objReimbursementDetail = null;
        for (int i = 0; i < gdvExpenceDetail.Rows.Count; i++)
        {
           
            Label lblDate = (Label)gdvExpenceDetail.Rows[i].FindControl("lblDate");
            Label lblDescription = (Label)gdvExpenceDetail.Rows[i].FindControl("lblDescription");
            Label lblCategory = (Label)gdvExpenceDetail.Rows[i].FindControl("lblCategory");
            Label lblCost = (Label)gdvExpenceDetail.Rows[i].FindControl("lblCost");
           
           _objReimbursementDetail = new ReimbursementDetail();
                _objReimbursementDetail.ReimbursementDate = lblDate.Text;
                _objReimbursementDetail.ReimbursementDescription = lblDescription.Text;
                _objReimbursementDetail.Category = lblCategory.Text;
                _objReimbursementDetail.Cost = lblCost.Text;
                _objReimbursementDetail.CreatedBy = Session["LoginId"].ToString();
                _objReimbursementDetail.ModifiedBy = Session["LoginId"].ToString();
                _objReimbursementDetail.CreatedDate = DateTime.Now.ToString();
                _objReimbursementDetail.ModifiedDate = DateTime.Now.ToString();
                lst.Add(_objReimbursementDetail);

           
        }
        return lst;
    }
    private bool CheckData()
    {
        bool Flag=true;
        if (txtEmployeeId.Text == "")
        {
            txtEmployeeId.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtEmployeeId.BorderColor = Color.Black;
        }
        if (txtEmployeeName.Text == "")
        {
            txtEmployeeName.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtEmployeeName.BorderColor = Color.Black;
        }
        if (txtManagerName.Text == "")
        {
            txtManagerName.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtManagerName.BorderColor = Color.Black;
        }
        if (txtDepartment.Text == "")
        {
            txtDepartment.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtDepartment.BorderColor = Color.Black;
        }
        if (txtFromDate.Text == "")
        {
            txtFromDate.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtFromDate.BorderColor = Color.Black;
        }
        if (txtToDate.Text == "")
        {
            txtToDate.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtToDate.BorderColor = Color.Black;
        }
        if (txtDate.Text == "")
        {
            txtDate.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtDate.BorderColor = Color.Black;
        }
        if (txtCategory.Text == "")
        {
            txtCategory.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtCategory.BorderColor = Color.Black;
        }
        if (txtCost.Text == "")
        {
            txtCost.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtCost.BorderColor = Color.Black;
        }
        if (txtDescription.Text == "")
        {
            txtDescription.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtDescription.BorderColor = Color.Black;
        }
        return Flag;
    }
    private void BindSubmittedGridView(string EmployeeId)
    {
        DataSet  ds = _objReimbursementDetailDetailManager.GetReimbursementDetailByEmployeeId(EmployeeId);
        gdvSubmittedDetail.DataSource = (ds.Tables[0]);
        gdvSubmittedDetail.DataBind();

        gdvAfterSubmitted.DataSource = (ds.Tables[1]);
        gdvAfterSubmitted.DataBind();
    }
    #endregion Page Specific Event


    protected void gdvSubmittedDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            Int32 Index = Convert.ToInt32(e.CommandArgument);
            HiddenField ReimbursementDetailId = (HiddenField)gdvSubmittedDetail.Rows[Index].FindControl("hdnReimbursementDetailId");
           
            _objReimbursementDetail.ReimbursementDetailId = Convert.ToInt32(ReimbursementDetailId.Value);
            DataTable _dt = _objReimbursementDetailDetailManager.GetReimbursementDetailById(Convert.ToInt32(ReimbursementDetailId.Value)).Tables[0];
            _objReimbursementDetail.SetObjectInfo(_dt.Rows[0]);
            _objReimbursementDetail.IsSubmitted = true;
            _objReimbursementDetail.SubmittedBy = Session["LoginId"].ToString();
            _objReimbursementDetail.SubmittedDate = DateTime.Now.ToString();
            foreach (ErrorHandlerClass err in _objReimbursementDetailDetailManager.UpdateReimbursementDetail(_objReimbursementDetail))
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
                        BindSubmittedGridView(txtEmployeeId.Text);
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
    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        if (txtFromDate.Text != "")
        {
            //DateTime dtFrm = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy");
            string strFrm = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            if (txtFromDate.Text != strFrm)
            {
                txtFromDate.Text = strFrm;
            }
        }
    }
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        if (txtToDate.Text != "")
        {
            string dtTo = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            if (txtToDate.Text != dtTo)
            {
                txtToDate.Text = dtTo;
            }
        }
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        if (txtDate.Text != "")
        {
            string dtDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            if (txtDate.Text != dtDate)
            {
                txtDate.Text = dtDate;
            }
        }
    }
}