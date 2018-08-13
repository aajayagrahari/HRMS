using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRMS_Class;
using ErrorHandler;

public partial class Pages_Admin_frmLoaneApplication : System.Web.UI.Page
{
    LoaneApplicationManager objLoaneApplicationManager = new LoaneApplicationManager();

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
            LoaneApplication objLoaneApplication = new LoaneApplication();
            SetObjInfo(objLoaneApplication);

            foreach (ErrorHandlerClass err in objLoaneApplicationManager.SaveLoaneApplication(objLoaneApplication))
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
    public void SetObjInfo(LoaneApplication objLoaneApplication)
    {
        try
        {
            string fileName = "";

            if (upd_Document.PostedFile.ContentLength > 0)
            {
                string date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string second = DateTime.Now.Second.ToString();
                fileName = date + upd_Document.FileName;
                string path = Server.MapPath("~/Loan/" + fileName);
                upd_Document.SaveAs(path);
            }

            objLoaneApplication.ApplicationHeading = Convert.ToString(txtSubjectLine.Text).Trim();
            objLoaneApplication.ApplicationBody = Convert.ToString(txtEditor.Content).Trim();
            objLoaneApplication.EmpDocument = fileName;
            objLoaneApplication.Remarks = "";
            objLoaneApplication.Status = "";

            objLoaneApplication.EmployeeId = "1";
            objLoaneApplication.CreatedBy = "";
            objLoaneApplication.ModifiedBy = "";
            objLoaneApplication.IsDeleted = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }

    }
    #endregion

}