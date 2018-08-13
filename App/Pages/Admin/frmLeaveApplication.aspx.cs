using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS_Class;
using ErrorHandler;

public partial class Pages_Admin_frmLeaveApplication : System.Web.UI.Page
{
    LeaveApplicationManager objLeaveApplicationManager = new LeaveApplicationManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            inicontrols();
        }
    }

    #region inicontrols
    public void inicontrols()
    {
        lblMsg.Text = "";
        txtSubjectLine.Text = "";
        txtEditor.Content = "";
    }
    #endregion

    #region Button Click Event
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            LeaveApplication objLeaveApplication = new LeaveApplication();

            SetObjInfo(objLeaveApplication);

            foreach (ErrorHandlerClass err in objLeaveApplicationManager.SaveLeaveApplication(objLeaveApplication))
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
                    if (err.Type == "S")
                    {
                        inicontrols();
                        lblMsg.Text = err.Message.ToString();
                        //Response.Redirect("ListOrchardMaster.aspx?OrchardCode=");
                    }
                }

            }
        }
        catch (Exception ex)
        { 
            
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        inicontrols();
    }
    #endregion

    #region set object info
    public void SetObjInfo(LeaveApplication objLeaveApplication)
    {
        try
        {
            string fileName = "";

            if (upd_Document.PostedFile.ContentLength > 0)
            {
                string date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string second = DateTime.Now.Second.ToString();
                fileName = date + upd_Document.FileName;
                string path = Server.MapPath("~/Leave/" + fileName);
                upd_Document.SaveAs(path);
            }
            objLeaveApplication.SubjectLine = Convert.ToString(txtSubjectLine.Text).Trim();
            objLeaveApplication.Body = Convert.ToString(txtEditor.Content).Trim();
            objLeaveApplication.EmpDocument = fileName;
            objLeaveApplication.Remarks = "";
            objLeaveApplication.Status = "";

            objLeaveApplication.EmployeeId = "1";
            objLeaveApplication.CreatedBy = "";
            objLeaveApplication.ModifiedBy = "";
            objLeaveApplication.IsDeleted = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }

    }
    #endregion

}