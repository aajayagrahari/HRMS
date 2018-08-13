using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using HRMS_Class;
using ErrorHandler;

public partial class Pages_Admin_ListEmployeeMaster : System.Web.UI.Page
{
    EmployeeMasterDetailsManager objEmployeeMasterManager = new EmployeeMasterDetailsManager();
    EmployeeJobDetailsManager objEmployeeJobDetailsManager = new EmployeeJobDetailsManager();
    EmployeeQualificationDetailsManager objEmployeeQualificationDetailsManager = new EmployeeQualificationDetailsManager();
    EmployeeEarningDetailsManager objEmployeeEarningDetailsManager = new EmployeeEarningDetailsManager();
    EmployeeDeductionDetailsManager objEmployeeDeductionDetailsManager = new EmployeeDeductionDetailsManager();
    EmployeeLeaveDetailsManager objEmployeeLeaveDetailsManager = new EmployeeLeaveDetailsManager();
    EmployeeLeftDetailsManager objEmployeeLeftDetailsManager = new EmployeeLeftDetailsManager();
    EmployeeOtherDetailsManager objEmployeeOtherDetailsManager = new EmployeeOtherDetailsManager();
    BulkInsertManager objBulkInsertManager = new BulkInsertManager();

    BindComboMasterManager objBindComboMasterManager = new BindComboMasterManager();
    DataSet ds4EmployeeMasterDetails = new DataSet();
    DataTable dt4EmployeeMaster = new DataTable();

    DataSet ds4EmployeeJobDetails = new DataSet();
    DataTable dt4EmployeeJob = new DataTable();

    DataSet ds4EmployeeQualificationDetails = new DataSet();
    DataTable dt4EmployeeQualification = new DataTable();

    DataSet ds4EmployeeEarningDetails = new DataSet();
    DataTable dt4EmployeeEarning = new DataTable();

    DataSet ds4EmployeeDeductionDetails = new DataSet();
    DataTable dt4EmployeeDeduction = new DataTable();

    DataSet ds4EmployeeLeaveDetails = new DataSet();
    DataTable dt4EmployeeLeaveDetails = new DataTable();

    DataSet ds4EmployeeLeftDetails = new DataSet();
    DataTable dt4EmployeeLeft = new DataTable();

    DataSet ds4EmployeeOtherDetails = new DataSet();
    DataTable dt4EmployeeOther = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblMsg.Text = "";

            BindEmployeeMasterDetails();
            BindEmployeeJobDetails();
            BindEmployeeQualificationDetails();
            BindEmployeeEarningDetails();
            BindEmployeeDeductionDetails();
            BindEmployeeLeaveDetails();
            BindEmployeeLeftDetails();
            BindEmployeeOtherDetails();
        }
    }

    #region Bind Grid Functions
    public void BindEmployeeMasterDetails()
    {
        try
        {
            ds4EmployeeMasterDetails = objEmployeeMasterManager.GetEmployeeMaster();
            grdEmployeeMasterDetails.DataSource = ds4EmployeeMasterDetails.Tables[0];
            grdEmployeeMasterDetails.DataBind();
            Session["EmployeeMasterDetails"] = ds4EmployeeMasterDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    public void BindEmployeeJobDetails()
    {
        try
        {
            ds4EmployeeJobDetails = objEmployeeJobDetailsManager.GetEmployeeJobDetails();
            grdEmployeeJobDetails.DataSource = ds4EmployeeJobDetails.Tables[0];
            grdEmployeeJobDetails.DataBind();
            Session["EmployeeJobDetails"] = ds4EmployeeJobDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindEmployeeQualificationDetails()
    {
        try
        {
            ds4EmployeeQualificationDetails = objEmployeeQualificationDetailsManager.GetEmployeeQualificationDetails();
            grdQualification.DataSource = ds4EmployeeQualificationDetails.Tables[0];
            grdQualification.DataBind();
            Session["EmployeeQualificationDetails"] = ds4EmployeeQualificationDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindEmployeeEarningDetails()
    {
        try
        {
            ds4EmployeeEarningDetails = objEmployeeEarningDetailsManager.GetEmployeeEarningDetails();
            grdEmployeeEarningDetails.DataSource = ds4EmployeeEarningDetails.Tables[0];
            grdEmployeeEarningDetails.DataBind();
            Session["EmployeeEarningDetails"] = ds4EmployeeEarningDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindEmployeeDeductionDetails()
    {
        try
        {
            ds4EmployeeDeductionDetails = objEmployeeDeductionDetailsManager.GetEmployeeDeductionDetails();
            grdEmployeeDeductionDetails.DataSource = ds4EmployeeDeductionDetails.Tables[0];
            grdEmployeeDeductionDetails.DataBind();
            Session["EmployeeDeductionDetails"] = ds4EmployeeDeductionDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindEmployeeLeaveDetails()
    {
        try
        {
            ds4EmployeeLeaveDetails = objEmployeeLeaveDetailsManager.GetEmployeeLeaveDetails();
            grdEmployeeLeaveDetails.DataSource = ds4EmployeeLeaveDetails.Tables[0];
            grdEmployeeLeaveDetails.DataBind();
            Session["EmployeeLeaveDetails"] = ds4EmployeeLeaveDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindEmployeeLeftDetails()
    {
        try
        {
            ds4EmployeeLeftDetails = objEmployeeLeftDetailsManager.GetEmployeeLeftDetails();
            grdEmployeeLeftDetails.DataSource = ds4EmployeeLeftDetails.Tables[0];
            grdEmployeeLeftDetails.DataBind();
            Session["EmployeeLeftDetails"] = ds4EmployeeLeftDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindEmployeeOtherDetails()
    {
        try
        {
            ds4EmployeeOtherDetails = objEmployeeOtherDetailsManager.GetEmployeeOtherDetails();
            grdEmployeeOtherDetails.DataSource = ds4EmployeeOtherDetails.Tables[0];
            grdEmployeeOtherDetails.DataBind();
            Session["EmployeeOtherDetails"] = ds4EmployeeOtherDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    #endregion

    #region Grid Events
    //Employee Earning Grid
    protected void grdEmployeeMasterDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            LinkButton btnDelete = ((LinkButton)e.Row.FindControl("btnDelete"));
            Image Img4Delete = ((Image)e.Row.FindControl("Img4Delete"));
            Image ImgTick = ((Image)e.Row.FindControl("ImgTick"));
            Label lbl_IsDeleted = ((Label)e.Row.FindControl("lbl_IsDeleted"));
            LinkButton btnEdit = ((LinkButton)e.Row.FindControl("btnEdit"));

            if (Convert.ToInt32(lbl_IsDeleted.Text) != 0)
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

    protected void grdEmployeeMasterDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.ToString() == "Edit")
            {
                lblMsg.Text = "";
                int pageSize = grdEmployeeMasterDetails.PageSize;
                int pageIndex = grdEmployeeMasterDetails.PageIndex;
                int EmpId = Convert.ToInt32(e.CommandArgument);
                int newRowIndex = 0;

                if (pageIndex > 0)
                {
                    newRowIndex = pageIndex * pageSize;
                    EmpId = EmpId - newRowIndex;
                }
                Label lblEmpId = ((Label)grdEmployeeMasterDetails.Rows[EmpId].FindControl("lbl_EmployeeId"));
               // Response.Redirect("frmEmployeeMaster.aspx?EmpId=" + Convert.ToString(lblEmpId.Text) + "&JobId=" + "&QuliId=" + "&ErngId=" + "&DdctId=" + "&LeaveId=" + "&LeftId=" + "&OthrId=");
                Response.Redirect("frmEmployeeMaster.aspx?EmpId=" + Convert.ToString(lblEmpId.Text));
            }



        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
        }

    }

    protected void grdEmployeeMasterDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdEmployeeMasterDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            lblMsg.Text = "";
            int pageSize = grdEmployeeMasterDetails.PageSize;
            int pageIndex = grdEmployeeMasterDetails.PageIndex;
            int index = Convert.ToInt32(e.RowIndex);
            int newRowIndex = 0;

            if (pageIndex > 0)
            {
                newRowIndex = pageIndex * pageSize;
                index = index - newRowIndex;
            }
            GridViewRow row = grdEmployeeMasterDetails.Rows[index];
            Label lblIsDeleted = (Label)row.FindControl("lbl_IsDeleted");
            Label lbl_EmployeeId = (Label)row.FindControl("lbl_EmployeeId");
            string EmployeeId = lbl_EmployeeId.Text.Trim();
            int IsDeleted = Convert.ToInt32(lblIsDeleted.Text);
            System.Web.UI.WebControls.Image Img4Delete = ((System.Web.UI.WebControls.Image)row.FindControl("Img4Delete"));
            System.Web.UI.WebControls.Image ImgTick = ((System.Web.UI.WebControls.Image)row.FindControl("ImgTick"));
            LinkButton btnDelete = ((LinkButton)row.FindControl("btnDelete"));

            if (IsDeleted == 0)
            {
                string strModifiedBy = Session["LoginId"].ToString();
                string strEmployeeId = EmployeeId;
                int intIsDeleted = 1;
                foreach (ErrorHandlerClass err in objEmployeeMasterManager.DeleteEmployeeMaster(strEmployeeId, intIsDeleted, strModifiedBy))
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
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            ImgTick.Visible = false;
                            Img4Delete.Visible = true;
                            grdEmployeeMasterDetails.EditIndex = -1;
                            BindEmployeeMasterDetails();
                        }
                    }
                }
            }
            else
            {
                string strModifiedBy = Session["LoginId"].ToString();
                string strEmployeeId = EmployeeId;
                int intIsDeleted = 0;
                foreach (ErrorHandlerClass err in objEmployeeMasterManager.DeleteEmployeeMaster(strEmployeeId, intIsDeleted, strModifiedBy))
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
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            ImgTick.Visible = false;
                            Img4Delete.Visible = true;
                            grdEmployeeMasterDetails.EditIndex = -1;
                            BindEmployeeMasterDetails();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = ex.Message;
        }
    }

    //Employee Qualification Grid
    protected void grdQualification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            LinkButton btnDelete = ((LinkButton)e.Row.FindControl("btnDelete"));
            Image Img4Delete = ((Image)e.Row.FindControl("Img4Delete"));
            Image ImgTick = ((Image)e.Row.FindControl("ImgTick"));
            Label lbl_IsDeleted = ((Label)e.Row.FindControl("lbl_IsDeleted"));
            LinkButton btnEdit = ((LinkButton)e.Row.FindControl("btnEdit"));

            if (Convert.ToInt32(lbl_IsDeleted.Text) != 0)
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

    protected void grdQualification_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.ToString() == "Edit")
            {
                lblMsg.Text = "";
                int pageSize = grdQualification.PageSize;
                int pageIndex = grdQualification.PageIndex;
                int EmpId = Convert.ToInt32(e.CommandArgument);
                int newRowIndex = 0;

                if (pageIndex > 0)
                {
                    newRowIndex = pageIndex * pageSize;
                    EmpId = EmpId - newRowIndex;
                }
                Label lblEmpId = ((Label)grdQualification.Rows[EmpId].FindControl("lbl_EmployeeId"));
                Label lblQuliId = ((Label)grdQualification.Rows[EmpId].FindControl("lbl_EmployeeLeaveId"));
                // Response.Redirect("frmEmployeeMaster.aspx?EmpId=" + Convert.ToString(lblEmpId.Text)+ "&JobId=" + "&QuliId=" + Convert.ToString(lblQuliId.Text) + "&ErngId=" + "&DdctId=" + "&LeaveId=" + "&LeftId=" + "&OthrId=");
                Session["QuliId"] = lblQuliId.Text;
                Response.Redirect("frmEmployeeMaster.aspx?EmpId=" + Convert.ToString(lblEmpId.Text));
               
            }



        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
        }
    }

    protected void grdQualification_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdQualification_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            lblMsg.Text = "";
            int pageSize = grdQualification.PageSize;
            int pageIndex = grdQualification.PageIndex;
            int index = Convert.ToInt32(e.RowIndex);
            int newRowIndex = 0;

            if (pageIndex > 0)
            {
                newRowIndex = pageIndex * pageSize;
                index = index - newRowIndex;
            }
            GridViewRow row = grdQualification.Rows[index];
            Label lblIsDeleted = (Label)row.FindControl("lbl_IsDeleted");
            Label lbl_EmployeeId = (Label)row.FindControl("lbl_EmployeeId");
            Label lbl_EmployeeLeaveId = (Label)row.FindControl("lbl_EmployeeLeaveId");
            Label lbl_ItemNo = (Label)row.FindControl("lbl_ItemNo");
            string EmployeeId = lbl_EmployeeId.Text.Trim();
            int IsDeleted = Convert.ToInt32(lblIsDeleted.Text);
            System.Web.UI.WebControls.Image Img4Delete = ((System.Web.UI.WebControls.Image)row.FindControl("Img4Delete"));
            System.Web.UI.WebControls.Image ImgTick = ((System.Web.UI.WebControls.Image)row.FindControl("ImgTick"));
            LinkButton btnDelete = ((LinkButton)row.FindControl("btnDelete"));

            if (IsDeleted == 0)
            {
                string strModifiedBy = Session["LoginId"].ToString();
                string strEmployeeId = EmployeeId;
                int intIsDeleted = 1;
                foreach (ErrorHandlerClass err in objEmployeeQualificationDetailsManager.DeleteEmployeeQualificationDetails(strEmployeeId,intIsDeleted,strModifiedBy,lbl_ItemNo.Text,lbl_EmployeeLeaveId.Text))
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
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            ImgTick.Visible = false;
                            Img4Delete.Visible = true;
                            grdQualification.EditIndex = -1;
                            BindEmployeeQualificationDetails();
                        }
                    }
                }
            }
            else
            {
                string strModifiedBy = Session["LoginId"].ToString();
                string strEmployeeId = EmployeeId;
                int intIsDeleted = 0;
                foreach (ErrorHandlerClass err in objEmployeeQualificationDetailsManager.DeleteEmployeeQualificationDetails(strEmployeeId, intIsDeleted, strModifiedBy, lbl_ItemNo.Text, lbl_EmployeeLeaveId.Text))
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
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            ImgTick.Visible = false;
                            Img4Delete.Visible = true;
                            grdQualification.EditIndex = -1;
                            BindEmployeeQualificationDetails();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = ex.Message;
        }
    }

    //Employee Deduction Grid
    protected void grdEmployeeJobDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            LinkButton btnDelete = ((LinkButton)e.Row.FindControl("btnDelete"));
            Image Img4Delete = ((Image)e.Row.FindControl("Img4Delete"));
            Image ImgTick = ((Image)e.Row.FindControl("ImgTick"));
            Label lbl_IsDeleted = ((Label)e.Row.FindControl("lbl_IsDeleted"));
            LinkButton btnEdit = ((LinkButton)e.Row.FindControl("btnEdit"));

            if (Convert.ToInt32(lbl_IsDeleted.Text) != 0)
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

    protected void grdEmployeeJobDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.ToString() == "Edit")
            {
                lblMsg.Text = "";
                int pageSize = grdEmployeeJobDetails.PageSize;
                int pageIndex = grdEmployeeJobDetails.PageIndex;
                int EmpId = Convert.ToInt32(e.CommandArgument);
                int newRowIndex = 0;

                if (pageIndex > 0)
                {
                    newRowIndex = pageIndex * pageSize;
                    EmpId = EmpId - newRowIndex;
                }
                Label lblEmpId = ((Label)grdEmployeeJobDetails.Rows[EmpId].FindControl("lbl_EmployeeId"));
                Label lblJobId = ((Label)grdEmployeeJobDetails.Rows[EmpId].FindControl("lbl_EmployeeJobId"));
               // Response.Redirect("frmEmployeeMaster.aspx?EmpId=" + Convert.ToString(lblEmpId.Text) + "&JobId=" + Convert.ToString(lblJobId.Text) +"&ErngId=" + "&DdctId=" + "&LeaveId=" + "&LeftId=" + "&OthrId=");
                Session["JobId"] = lblJobId.Text;
                Response.Redirect("frmEmployeeMaster.aspx?EmpId=" + Convert.ToString(lblEmpId.Text));

            }



        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
        }
        
    }

    protected void grdEmployeeJobDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdEmployeeJobDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            lblMsg.Text = "";
            int pageSize = grdEmployeeJobDetails.PageSize;
            int pageIndex = grdEmployeeJobDetails.PageIndex;
            int index = Convert.ToInt32(e.RowIndex);
            int newRowIndex = 0;

            if (pageIndex > 0)
            {
                newRowIndex = pageIndex * pageSize;
                index = index - newRowIndex;
            }
            GridViewRow row = grdEmployeeJobDetails.Rows[index];
            Label lblIsDeleted = (Label)row.FindControl("lbl_IsDeleted");
            Label lbl_EmployeeId = (Label)row.FindControl("lbl_EmployeeId");
            Label lbl_EmployeeJobId = (Label)row.FindControl("lbl_EmployeeJobId");
            string EmployeeId = lbl_EmployeeId.Text.Trim();
            int IsDeleted = Convert.ToInt32(lblIsDeleted.Text);
            System.Web.UI.WebControls.Image Img4Delete = ((System.Web.UI.WebControls.Image)row.FindControl("Img4Delete"));
            System.Web.UI.WebControls.Image ImgTick = ((System.Web.UI.WebControls.Image)row.FindControl("ImgTick"));
            LinkButton btnDelete = ((LinkButton)row.FindControl("btnDelete"));

            if (IsDeleted == 0)
            {
                string strModifiedBy = Session["LoginId"].ToString();
                string strEmployeeId = EmployeeId;
                int intIsDeleted = 1;
                foreach (ErrorHandlerClass err in objEmployeeJobDetailsManager.DeleteEmployeeJobDetails(strEmployeeId, intIsDeleted, strModifiedBy, lbl_EmployeeJobId.Text))
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
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            ImgTick.Visible = false;
                            Img4Delete.Visible = true;
                            grdEmployeeMasterDetails.EditIndex = -1;
                            BindEmployeeJobDetails();
                        }
                    }
                }
            }
            else
            {
                string strModifiedBy = Session["LoginId"].ToString();
                string strEmployeeId = EmployeeId;
                int intIsDeleted = 0;
                foreach (ErrorHandlerClass err in objEmployeeJobDetailsManager.DeleteEmployeeJobDetails(strEmployeeId, intIsDeleted, strModifiedBy, lbl_EmployeeJobId.Text))
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
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            ImgTick.Visible = false;
                            Img4Delete.Visible = true;
                            grdEmployeeJobDetails.EditIndex = -1;
                            BindEmployeeJobDetails();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = ex.Message;
        }
    }

    //Employee Earning Grid
    protected void grdEmployeeEarningDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            LinkButton btnDelete = ((LinkButton)e.Row.FindControl("btnDelete"));
            Image Img4Delete = ((Image)e.Row.FindControl("Img4Delete"));
            Image ImgTick = ((Image)e.Row.FindControl("ImgTick"));
            Label lbl_IsDeleted = ((Label)e.Row.FindControl("lbl_IsDeleted"));
            LinkButton btnEdit = ((LinkButton)e.Row.FindControl("btnEdit"));
            Label lbl_Bonus = ((Label)e.Row.FindControl("lbl_Bonus"));
            Label lbl_OT = ((Label)e.Row.FindControl("lbl_OT"));

            if (Convert.ToInt32(lbl_IsDeleted.Text) != 0)
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

            if (Convert.ToInt32(lbl_Bonus.Text) == 1)
            {
                lbl_Bonus.Text = "Yes";
            }
            else
            {
                lbl_Bonus.Text = "No";
            }

            if (Convert.ToInt32(lbl_OT.Text) == 1)
            {
                lbl_OT.Text = "Yes";
            }
            else
            {
                lbl_OT.Text = "No";
            }
        }
    }

    protected void grdEmployeeEarningDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.ToString() == "Edit")
            {
                lblMsg.Text = "";
                int pageSize = grdEmployeeEarningDetails.PageSize;
                int pageIndex = grdEmployeeEarningDetails.PageIndex;
                int EmpId = Convert.ToInt32(e.CommandArgument);
                int newRowIndex = 0;

                if (pageIndex > 0)
                {
                    newRowIndex = pageIndex * pageSize;
                    EmpId = EmpId - newRowIndex;
                }
                Label lblEmpId = ((Label)grdEmployeeEarningDetails.Rows[EmpId].FindControl("lbl_EmployeeId"));
                Label lbl_EmployeeEarningId = ((Label)grdEmployeeEarningDetails.Rows[EmpId].FindControl("lbl_EmployeeEarningId"));
              //  Response.Redirect("frmEmployeeMaster.aspx?EmpId=" + Convert.ToString(lblEmpId.Text) + "&JobId=" + "&QuliId=" + "&ErngId=" + Convert.ToString(lbl_EmployeeEarningId.Text) +"&DdctId=" + "&LeaveId=" + "&LeftId=" + "&OthrId=");
                Session["ErngId"] = lbl_EmployeeEarningId.Text;
                Response.Redirect("frmEmployeeMaster.aspx?EmpId=" + Convert.ToString(lblEmpId.Text));
            }



        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
        }
    }

    protected void grdEmployeeEarningDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdEmployeeEarningDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            lblMsg.Text = "";
            int pageSize = grdEmployeeEarningDetails.PageSize;
            int pageIndex = grdEmployeeEarningDetails.PageIndex;
            int index = Convert.ToInt32(e.RowIndex);
            int newRowIndex = 0;

            if (pageIndex > 0)
            {
                newRowIndex = pageIndex * pageSize;
                index = index - newRowIndex;
            }
            GridViewRow row = grdEmployeeEarningDetails.Rows[index];
            Label lblIsDeleted = (Label)row.FindControl("lbl_IsDeleted");
            Label lbl_EmployeeId = (Label)row.FindControl("lbl_EmployeeId");
            Label lbl_EmployeeEarningId = (Label)row.FindControl("lbl_EmployeeEarningId");
            Label lbl_ItemNo = (Label)row.FindControl("lbl_ItemNo");
            string EmployeeId = lbl_EmployeeId.Text.Trim();
            int IsDeleted = Convert.ToInt32(lblIsDeleted.Text);
            System.Web.UI.WebControls.Image Img4Delete = ((System.Web.UI.WebControls.Image)row.FindControl("Img4Delete"));
            System.Web.UI.WebControls.Image ImgTick = ((System.Web.UI.WebControls.Image)row.FindControl("ImgTick"));
            LinkButton btnDelete = ((LinkButton)row.FindControl("btnDelete"));

            if (IsDeleted == 0)
            {
                string strModifiedBy = Session["LoginId"].ToString();
                string strEmployeeId = EmployeeId;
                int intIsDeleted = 1;
                foreach (ErrorHandlerClass err in objEmployeeEarningDetailsManager.DeleteEmployeeEarningDetails(strEmployeeId, intIsDeleted, strModifiedBy, lbl_ItemNo.Text, lbl_EmployeeEarningId.Text))
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
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            ImgTick.Visible = false;
                            Img4Delete.Visible = true;
                            grdEmployeeEarningDetails.EditIndex = -1;
                            BindEmployeeEarningDetails();
                        }
                    }
                }
            }
            else
            {
                string strModifiedBy = Session["LoginId"].ToString();
                string strEmployeeId = EmployeeId;
                int intIsDeleted = 0;
                foreach (ErrorHandlerClass err in objEmployeeEarningDetailsManager.DeleteEmployeeEarningDetails(strEmployeeId, intIsDeleted, strModifiedBy, lbl_ItemNo.Text, lbl_EmployeeEarningId.Text))
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
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            ImgTick.Visible = false;
                            Img4Delete.Visible = true;
                            grdEmployeeEarningDetails.EditIndex = -1;
                            BindEmployeeEarningDetails();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = ex.Message;
        }
    }
    protected void grdEmployeeDeductionDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            LinkButton btnDelete = ((LinkButton)e.Row.FindControl("btnDelete"));
            Image Img4Delete = ((Image)e.Row.FindControl("Img4Delete"));
            Image ImgTick = ((Image)e.Row.FindControl("ImgTick"));
            Label lbl_IsDeleted = ((Label)e.Row.FindControl("lbl_IsDeleted"));
            LinkButton btnEdit = ((LinkButton)e.Row.FindControl("btnEdit"));
            Label lbl_LimitAmount = ((Label)e.Row.FindControl("lbl_LimitAmount"));
            Label lbl_DeductionLimit = ((Label)e.Row.FindControl("lbl_DeductionLimit"));

            if (Convert.ToInt32(lbl_IsDeleted.Text) != 0)
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

            if (Convert.ToInt32(lbl_DeductionLimit.Text) == 1)
            {
                lbl_DeductionLimit.Text = "Yes";
            }
            else
            {
                lbl_DeductionLimit.Text = "No";
            }
        }
    }

    protected void grdEmployeeDeductionDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.ToString() == "Edit")
            {
                lblMsg.Text = "";
                int pageSize = grdEmployeeDeductionDetails.PageSize;
                int pageIndex = grdEmployeeDeductionDetails.PageIndex;
                int EmpId = Convert.ToInt32(e.CommandArgument);
                int newRowIndex = 0;

                if (pageIndex > 0)
                {
                    newRowIndex = pageIndex * pageSize;
                    EmpId = EmpId - newRowIndex;
                }
                Label lblEmpId = ((Label)grdEmployeeDeductionDetails.Rows[EmpId].FindControl("lbl_EmployeeId"));
                Label lbl_EmployeeDeductionId = ((Label)grdEmployeeDeductionDetails.Rows[EmpId].FindControl("lbl_EmployeeDeductionId"));
               // Response.Redirect("frmEmployeeMaster.aspx?EmpId=" + Convert.ToString(lblEmpId.Text) + "&JobId=" + "&QuliId=" + "&ErngId=" + "&DdctId=" + Convert.ToString(lbl_EmployeeDeductionId.Text) + "&LeaveId=" + "&LeftId=" + "&OthrId=");
                Session["DdctId"] = lbl_EmployeeDeductionId.Text;
                Response.Redirect("frmEmployeeMaster.aspx?EmpId=" + Convert.ToString(lblEmpId.Text));
            }



        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
        }
    }

    protected void grdEmployeeDeductionDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdEmployeeDeductionDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            lblMsg.Text = "";
            int pageSize = grdEmployeeDeductionDetails.PageSize;
            int pageIndex = grdEmployeeDeductionDetails.PageIndex;
            int index = Convert.ToInt32(e.RowIndex);
            int newRowIndex = 0;

            if (pageIndex > 0)
            {
                newRowIndex = pageIndex * pageSize;
                index = index - newRowIndex;
            }
            GridViewRow row = grdEmployeeDeductionDetails.Rows[index];
            Label lblIsDeleted = (Label)row.FindControl("lbl_IsDeleted");
            Label lbl_EmployeeId = (Label)row.FindControl("lbl_EmployeeId");
            Label lbl_EmployeeDeductionId = (Label)row.FindControl("lbl_EmployeeDeductionId");
            Label lbl_ItemNo = (Label)row.FindControl("lbl_ItemNo");
            string EmployeeId = lbl_EmployeeId.Text.Trim();
            int IsDeleted = Convert.ToInt32(lblIsDeleted.Text);
            System.Web.UI.WebControls.Image Img4Delete = ((System.Web.UI.WebControls.Image)row.FindControl("Img4Delete"));
            System.Web.UI.WebControls.Image ImgTick = ((System.Web.UI.WebControls.Image)row.FindControl("ImgTick"));
            LinkButton btnDelete = ((LinkButton)row.FindControl("btnDelete"));

            if (IsDeleted == 0)
            {
                string strModifiedBy = Session["LoginId"].ToString();
                string strEmployeeId = EmployeeId;
                int intIsDeleted = 1;
                foreach (ErrorHandlerClass err in objEmployeeDeductionDetailsManager.DeleteEmployeeDeductionDetails(strEmployeeId, intIsDeleted, strModifiedBy, lbl_ItemNo.Text, lbl_EmployeeDeductionId.Text))
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
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            ImgTick.Visible = false;
                            Img4Delete.Visible = true;
                            grdEmployeeDeductionDetails.EditIndex = -1;
                            BindEmployeeDeductionDetails();
                        }
                    }
                }
            }
            else
            {
                string strModifiedBy = Session["LoginId"].ToString();
                string strEmployeeId = EmployeeId;
                int intIsDeleted = 0;
                foreach (ErrorHandlerClass err in objEmployeeDeductionDetailsManager.DeleteEmployeeDeductionDetails(strEmployeeId, intIsDeleted, strModifiedBy, lbl_ItemNo.Text, lbl_EmployeeDeductionId.Text))
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
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            ImgTick.Visible = false;
                            Img4Delete.Visible = true;
                            grdEmployeeDeductionDetails.EditIndex = -1;
                            BindEmployeeDeductionDetails();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = ex.Message;
        }
    }

    //Employee Leave Details
    protected void grdEmployeeLeaveDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            LinkButton btnDelete = ((LinkButton)e.Row.FindControl("btnDelete"));
            Image Img4Delete = ((Image)e.Row.FindControl("Img4Delete"));
            Image ImgTick = ((Image)e.Row.FindControl("ImgTick"));
            Label lbl_IsDeleted = ((Label)e.Row.FindControl("lbl_IsDeleted"));
            LinkButton btnEdit = ((LinkButton)e.Row.FindControl("btnEdit"));

            if (Convert.ToInt32(lbl_IsDeleted.Text) != 0)
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

    protected void grdEmployeeLeaveDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.ToString() == "Edit")
            {
                lblMsg.Text = "";
                int pageSize = grdEmployeeLeaveDetails.PageSize;
                int pageIndex = grdEmployeeLeaveDetails.PageIndex;
                int EmpId = Convert.ToInt32(e.CommandArgument);
                int newRowIndex = 0;

                if (pageIndex > 0)
                {
                    newRowIndex = pageIndex * pageSize;
                    EmpId = EmpId - newRowIndex;
                }
                Label lblEmpId = ((Label)grdEmployeeLeaveDetails.Rows[EmpId].FindControl("lbl_EmployeeId"));
                Label lbl_EmployeeLeaveId = ((Label)grdEmployeeLeaveDetails.Rows[EmpId].FindControl("lbl_EmployeeLeaveId"));
               // Response.Redirect("frmEmployeeMaster.aspx?EmpId=" + Convert.ToString(lblEmpId.Text) + "&JobId=" + "&QuliId=" + "&ErngId=" + "&DdctId=" + "&LeaveId=" + Convert.ToString(lbl_EmployeeLeaveId.Text) + "&LeftId=" + "&OthrId=");
                Session["LeaveId"] = lbl_EmployeeLeaveId.Text;
                Response.Redirect("frmEmployeeMaster.aspx?EmpId=" + Convert.ToString(lblEmpId.Text));
            }



        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
        }
    }

    protected void grdEmployeeLeaveDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdEmployeeLeaveDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            lblMsg.Text = "";
            int pageSize = grdEmployeeLeaveDetails.PageSize;
            int pageIndex = grdEmployeeLeaveDetails.PageIndex;
            int index = Convert.ToInt32(e.RowIndex);
            int newRowIndex = 0;

            if (pageIndex > 0)
            {
                newRowIndex = pageIndex * pageSize;
                index = index - newRowIndex;
            }
            GridViewRow row = grdEmployeeLeaveDetails.Rows[index];
            Label lblIsDeleted = (Label)row.FindControl("lbl_IsDeleted");
            Label lbl_EmployeeId = (Label)row.FindControl("lbl_EmployeeId");
            Label lbl_EmployeeLeaveId = (Label)row.FindControl("lbl_EmployeeLeaveId");
            Label lbl_ItemNo = (Label)row.FindControl("lbl_ItemNo");
            string EmployeeId = lbl_EmployeeId.Text.Trim();
            int IsDeleted = Convert.ToInt32(lblIsDeleted.Text);
            System.Web.UI.WebControls.Image Img4Delete = ((System.Web.UI.WebControls.Image)row.FindControl("Img4Delete"));
            System.Web.UI.WebControls.Image ImgTick = ((System.Web.UI.WebControls.Image)row.FindControl("ImgTick"));
            LinkButton btnDelete = ((LinkButton)row.FindControl("btnDelete"));

            if (IsDeleted == 0)
            {
                string strModifiedBy = Session["LoginId"].ToString();
                string strEmployeeId = EmployeeId;
                int intIsDeleted = 1;
                foreach (ErrorHandlerClass err in objEmployeeLeaveDetailsManager.DeleteEmployeeLeaveDetails(strEmployeeId, intIsDeleted, strModifiedBy, lbl_ItemNo.Text, lbl_EmployeeLeaveId.Text))
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
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            ImgTick.Visible = false;
                            Img4Delete.Visible = true;
                            grdEmployeeLeaveDetails.EditIndex = -1;
                            BindEmployeeLeaveDetails();
                        }
                    }
                }
            }
            else
            {
                string strModifiedBy = Session["LoginId"].ToString();
                string strEmployeeId = EmployeeId;
                int intIsDeleted = 0;
                foreach (ErrorHandlerClass err in objEmployeeLeaveDetailsManager.DeleteEmployeeLeaveDetails(strEmployeeId, intIsDeleted, strModifiedBy, lbl_ItemNo.Text, lbl_EmployeeLeaveId.Text))
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
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            ImgTick.Visible = false;
                            Img4Delete.Visible = true;
                            grdEmployeeLeaveDetails.EditIndex = -1;
                            BindEmployeeLeaveDetails();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = ex.Message;
        }
    }

    //Employee Deduction Grid
    protected void grdEmployeeLeftDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            LinkButton btnDelete = ((LinkButton)e.Row.FindControl("btnDelete"));
            Image Img4Delete = ((Image)e.Row.FindControl("Img4Delete"));
            Image ImgTick = ((Image)e.Row.FindControl("ImgTick"));
            Label lbl_IsDeleted = ((Label)e.Row.FindControl("lbl_IsDeleted"));
            LinkButton btnEdit = ((LinkButton)e.Row.FindControl("btnEdit"));
            Label lbl_FullnFinal = ((Label)e.Row.FindControl("lbl_FullnFinal"));

            if (Convert.ToInt32(lbl_IsDeleted.Text) != 0)
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

            if (Convert.ToInt32(lbl_FullnFinal.Text) == 1)
            {
                lbl_FullnFinal.Text = "Yes";
            }
            else
            {
                lbl_FullnFinal.Text = "No";
            }
        }
    }

    protected void grdEmployeeLeftDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.ToString() == "Edit")
            {
                lblMsg.Text = "";
                int pageSize = grdEmployeeLeftDetails.PageSize;
                int pageIndex = grdEmployeeLeftDetails.PageIndex;
                int EmpId = Convert.ToInt32(e.CommandArgument);
                int newRowIndex = 0;

                if (pageIndex > 0)
                {
                    newRowIndex = pageIndex * pageSize;
                    EmpId = EmpId - newRowIndex;
                }
                Label lblEmpId = ((Label)grdEmployeeLeftDetails.Rows[EmpId].FindControl("lbl_EmployeeId"));
                Label lbl_EmployeeLeftId = ((Label)grdEmployeeLeftDetails.Rows[EmpId].FindControl("lbl_EmployeeLeftId"));
                //Response.Redirect("frmEmployeeMaster.aspx?EmpId=" + Convert.ToString(lblEmpId.Text) + "&JobId=" + "&QuliId=" + "&ErngId=" + "&DdctId=" + "&LeaveId=" + "&LeftId=" + Convert.ToString(lbl_EmployeeLeftId.Text) + "&OthrId=");
                Session["LeftId"] = lbl_EmployeeLeftId.Text;
                Response.Redirect("frmEmployeeMaster.aspx?EmpId=" + Convert.ToString(lblEmpId.Text));
            }



        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
        }
    }

    protected void grdEmployeeLeftDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdEmployeeLeftDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            lblMsg.Text = "";
            int pageSize = grdEmployeeLeftDetails.PageSize;
            int pageIndex = grdEmployeeLeftDetails.PageIndex;
            int index = Convert.ToInt32(e.RowIndex);
            int newRowIndex = 0;

            if (pageIndex > 0)
            {
                newRowIndex = pageIndex * pageSize;
                index = index - newRowIndex;
            }
            GridViewRow row = grdEmployeeLeftDetails.Rows[index];
            Label lblIsDeleted = (Label)row.FindControl("lbl_IsDeleted");
            Label lbl_EmployeeId = (Label)row.FindControl("lbl_EmployeeId");
            Label lbl_EmployeeLeftId = (Label)row.FindControl("lbl_EmployeeLeftId");
            string EmployeeId = lbl_EmployeeId.Text.Trim();
            int IsDeleted = Convert.ToInt32(lblIsDeleted.Text);
            System.Web.UI.WebControls.Image Img4Delete = ((System.Web.UI.WebControls.Image)row.FindControl("Img4Delete"));
            System.Web.UI.WebControls.Image ImgTick = ((System.Web.UI.WebControls.Image)row.FindControl("ImgTick"));
            LinkButton btnDelete = ((LinkButton)row.FindControl("btnDelete"));

            if (IsDeleted == 0)
            {
                string strModifiedBy = Session["LoginId"].ToString();
                string strEmployeeId = EmployeeId;
                int intIsDeleted = 1;
                foreach (ErrorHandlerClass err in objEmployeeLeftDetailsManager.DeleteEmployeeLeftDetails(strEmployeeId, intIsDeleted, strModifiedBy, lbl_EmployeeLeftId.Text))
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
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            ImgTick.Visible = false;
                            Img4Delete.Visible = true;
                            grdEmployeeLeftDetails.EditIndex = -1;
                            BindEmployeeLeftDetails();
                        }
                    }
                }
            }
            else
            {
                string strModifiedBy = Session["LoginId"].ToString();
                string strEmployeeId = EmployeeId;
                int intIsDeleted = 0;
                foreach (ErrorHandlerClass err in objEmployeeLeftDetailsManager.DeleteEmployeeLeftDetails(strEmployeeId, intIsDeleted, strModifiedBy, lbl_EmployeeLeftId.Text))
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
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            ImgTick.Visible = false;
                            Img4Delete.Visible = true;
                            grdEmployeeLeftDetails.EditIndex = -1;
                            BindEmployeeLeftDetails();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = ex.Message;
        }
    }

    //Employee Leave Details
    protected void grdEmployeeOtherDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            LinkButton btnDelete = ((LinkButton)e.Row.FindControl("btnDelete"));
            Image Img4Delete = ((Image)e.Row.FindControl("Img4Delete"));
            Image ImgTick = ((Image)e.Row.FindControl("ImgTick"));
            Label lbl_IsDeleted = ((Label)e.Row.FindControl("lbl_IsDeleted"));
            LinkButton btnEdit = ((LinkButton)e.Row.FindControl("btnEdit"));

            if (Convert.ToInt32(lbl_IsDeleted.Text) != 0)
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

    protected void grdEmployeeOtherDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.ToString() == "Edit")
            {
                lblMsg.Text = "";
                int pageSize = grdEmployeeOtherDetails.PageSize;
                int pageIndex = grdEmployeeOtherDetails.PageIndex;
                int EmpId = Convert.ToInt32(e.CommandArgument);
                int newRowIndex = 0;

                if (pageIndex > 0)
                {
                    newRowIndex = pageIndex * pageSize;
                    EmpId = EmpId - newRowIndex;
                }
                Label lblEmpId = ((Label)grdEmployeeOtherDetails.Rows[EmpId].FindControl("lbl_EmployeeId"));
                Label lbl_EmployeeOtherId = ((Label)grdEmployeeOtherDetails.Rows[EmpId].FindControl("lbl_EmployeeOtherId"));
               // Response.Redirect("frmEmployeeMaster.aspx?EmpId=" + Convert.ToString(lblEmpId.Text) + "&JobId=" + "&QuliId=" + "&ErngId=" + "&DdctId=" + "&LeaveId=" + "&LeftId=" + "&OthrId=" + Convert.ToString(lbl_EmployeeOtherId.Text));
                Session["OthrId"] = lbl_EmployeeOtherId.Text;
                Response.Redirect("frmEmployeeMaster.aspx?EmpId=" + Convert.ToString(lblEmpId.Text));

            }



        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = ex.Message;
        }
    }

    protected void grdEmployeeOtherDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdEmployeeOtherDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            lblMsg.Text = "";
            int pageSize = grdEmployeeOtherDetails.PageSize;
            int pageIndex = grdEmployeeOtherDetails.PageIndex;
            int index = Convert.ToInt32(e.RowIndex);
            int newRowIndex = 0;

            if (pageIndex > 0)
            {
                newRowIndex = pageIndex * pageSize;
                index = index - newRowIndex;
            }
            GridViewRow row = grdEmployeeOtherDetails.Rows[index];
            Label lblIsDeleted = (Label)row.FindControl("lbl_IsDeleted");
            Label lbl_EmployeeId = (Label)row.FindControl("lbl_EmployeeId");
            Label lbl_EmployeeOtherId = (Label)row.FindControl("lbl_EmployeeOtherId");
            string EmployeeId = lbl_EmployeeId.Text.Trim();
            int IsDeleted = Convert.ToInt32(lblIsDeleted.Text);
            System.Web.UI.WebControls.Image Img4Delete = ((System.Web.UI.WebControls.Image)row.FindControl("Img4Delete"));
            System.Web.UI.WebControls.Image ImgTick = ((System.Web.UI.WebControls.Image)row.FindControl("ImgTick"));
            LinkButton btnDelete = ((LinkButton)row.FindControl("btnDelete"));

            if (IsDeleted == 0)
            {
                string strModifiedBy = Session["LoginId"].ToString();
                string strEmployeeId = EmployeeId;
                int intIsDeleted = 1;
                foreach (ErrorHandlerClass err in objEmployeeOtherDetailsManager.DeleteEmployeeOtherDetails(strEmployeeId, intIsDeleted, strModifiedBy, lbl_EmployeeOtherId.Text))
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
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            ImgTick.Visible = false;
                            Img4Delete.Visible = true;
                            grdEmployeeOtherDetails.EditIndex = -1;
                            BindEmployeeOtherDetails();
                        }
                    }
                }
            }
            else
            {
                string strModifiedBy = Session["LoginId"].ToString();
                string strEmployeeId = EmployeeId;
                int intIsDeleted = 0;
                foreach (ErrorHandlerClass err in objEmployeeOtherDetailsManager.DeleteEmployeeOtherDetails(strEmployeeId, intIsDeleted, strModifiedBy, lbl_EmployeeOtherId.Text))
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
                            lblMsg.ForeColor = System.Drawing.Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            ImgTick.Visible = false;
                            Img4Delete.Visible = true;
                            grdEmployeeOtherDetails.EditIndex = -1;
                            BindEmployeeOtherDetails();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Font.Bold = true;
            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = ex.Message;
        }
    }
    #endregion

    #region Button Click Event
    protected void lbImport_onClick(object sender, EventArgs e)
    {
        try
        {
            //if (pUpload.Visible == false)
            //{
            //    pUpload.Visible = true;
            //}
            //else
            //{
            //    pUpload.Visible = false;
            //}
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Error while uploading " + ex.Message.ToString();
            lblMsg.Visible = true;
        }
    }

    protected void cmdUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (lblFileUpload.Text == "")
            {
                lblMsg.Text = "";
                lblMsg.Visible = false;
                UploadData();
            }
            else
            {
                lblMsg.Text = "No Record to upload.";
                lblMsg.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Error while uploading " + ex.Message.ToString();
            lblMsg.Visible = true;
        }
    }

    #endregion

    #region Bulk Insert
    public void UploadData()
    {
        string strFileExt = "";

        try
        {
            if (FUploadSheet.HasFile == true)
            {
                string tmpFileName = Convert.ToString(Session["LoginId"]) + "_" + Convert.ToString(FUploadSheet.FileName);
                FUploadSheet.PostedFile.SaveAs(Server.MapPath("~/UploadData/Master/" + tmpFileName));
                lblFileUpload.Visible = false;
                lblFileUpload.Text = Server.MapPath("~/UploadData/Master/" + tmpFileName);
                string SpliteValue = null;
                Char[] Splitter = { '.' };
                SpliteValue = FUploadSheet.FileName;
                string[] SplitString = SpliteValue.Split(Splitter);

                if (SplitString.Length > 0)
                {
                    strFileExt = SplitString[1].Trim();
                    strFileExt = "." + strFileExt;
                }
                else
                {
                    strFileExt = ".xls";
                }
                string strQuery = "SELECT * FROM ";

                foreach (ErrorHandlerClass err in objBulkInsertManager.BulkInsert4Employee1(lblFileUpload.Text.ToString(), strQuery, "", strFileExt, Convert.ToString(Session["LoginId"])))
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
                            lblMsg.Text = err.Message.ToString();
                            lblMsg.Visible = true;
                            FUploadSheet.Dispose();

                            if (File.Exists(lblFileUpload.Text.ToString()) == true)
                            {
                                File.Delete(lblFileUpload.Text.ToString());
                            }
                        }
                    }
                }
                lblMsg.Visible = true;
                //grdEmployeeMasterDetails.DataSource = null;
                //grdEmployeeMasterDetails.DataSource = objEmployeeMasterManager.GetEmployeeMaster();
                //grdEmployeeMasterDetails.DataBind();

                BindEmployeeMasterDetails();
                BindEmployeeJobDetails();
                BindEmployeeQualificationDetails();
                BindEmployeeEarningDetails();
                BindEmployeeDeductionDetails();
                BindEmployeeLeaveDetails();
                BindEmployeeLeftDetails();
                BindEmployeeOtherDetails();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "Error while uploading :" + ex.Message.ToString();
            lblMsg.Visible = true;
        }
    }
    #endregion

    #region Export Data From Excel
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        try
        {
            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Employees.xls"));
            //Response.ContentType = "application/ms-excel";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            //grdEmployeeMasterDetails.AllowPaging = false;
            ////Change the Header Row back to white color
            //grdEmployeeMasterDetails.HeaderRow.Style.Add("background-color", "#FFFFFF");
            ////Applying stlye to gridview header cells
            //for (int i = 0; i < grdEmployeeMasterDetails.HeaderRow.Cells.Count; i++)
            //{
            //    grdEmployeeMasterDetails.HeaderRow.Cells[i].Style.Add("background-color", "#507CD1");
            //}
            //int j = 1;
            ////Set alternate row color
            //foreach (GridViewRow gvrow in grdEmployeeMasterDetails.Rows)
            //{
            //    gvrow.BackColor = System.Drawing.Color.White;
            //    if (j <= grdEmployeeMasterDetails.Rows.Count)
            //    {
            //        if (j % 2 != 0)
            //        {
            //            for (int k = 0; k < gvrow.Cells.Count; k++)
            //            {
            //                gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
            //            }
            //        }
            //    }
            //    j++;
            //}
            //grdEmployeeMasterDetails.RenderControl(htw);
            //Response.Write(sw.ToString());
            //Response.End();

            DataTableToExcel();

            //System.IO.StringWriter sw = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

            //// Render grid view control.
            //grdEmployeeMasterDetails.RenderControl(htw);

            //// Write the rendered content to a file.
            //string renderedGridView = sw.ToString();

            //File.WriteAllText("C:\\TimeSheets\\Employee.xlsx", renderedGridView);

        }
        catch (Exception ex)
        {

        }
    }


   
    public void DataTableToExcel()
    {

       // Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
        try
        {

            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customers.xls"));
            //Response.ContentType = "application/ms-excel";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            //grdEmployeeMasterDetails.AllowPaging = false;
            //BindEmployeeMasterDetails();
            ////Change the Header Row back to white color
            //grdEmployeeMasterDetails.HeaderRow.Style.Add("background-color", "#FFFFFF");
            ////Applying stlye to gridview header cells
            //for (int i = 0; i < grdEmployeeMasterDetails.HeaderRow.Cells.Count; i++)
            //{
            //    grdEmployeeMasterDetails.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
            //}
            //grdEmployeeMasterDetails.RenderControl(htw);
            //Response.Write(sw.ToString());
            //Response.Flush();
            //Response.End();

            DataTable ds = new DataTable();
            ds = (DataTable)Session["EmployeeMasterDetails"];
            string filename = "Recieved Consignment List Report.xls";
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
         //   response.Charset = "";
            response.ContentType = "application/vnd.ms-excel.xls";
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    GridView dgv = new GridView();
                    // GridView dgv1 = new GridView();
                    // dgv.DataSource = ViewState["MyData"];// Session["MyData"];\
                    dgv.DataSource = ds;
                    dgv.DataBind();
                    dgv.RenderControl(htw);

                    //dgv1.DataSource = dt1;
                    //dgv1.DataBind();
                    //dgv1.RenderControl(htw);

                    response.Write(sw.ToString());
                  

                   

                   HttpContext.Current.ApplicationInstance.CompleteRequest();

                   


                }
            }
         
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
        finally
        {
            //Release the resources
            //app.Quit();
           // System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
          //

        }

    }



   
    #endregion
}