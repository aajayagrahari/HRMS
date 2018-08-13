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
public partial class Pages_Admin_frmChangePassword : System.Web.UI.Page
{
    ChangePasswordManager objChangePasswordManager = new ChangePasswordManager();
    HRMS_Class.ChangePassword objChangePassword = new HRMS_Class.ChangePassword();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            iniControls();

        }
    }
  void  iniControls()
     {
         txt_old_password.Text = "";
         txt_new_password.Text = "";
         txt_confirm_password.Text = "";
     }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
    string Login = Session["LoginId"].ToString();
   string OldPassword= txt_old_password.Text.Trim();
        string NewPassword = txt_new_password.Text.Trim();

        foreach (ErrorHandlerClass err in objChangePasswordManager.SaveChangePassword(Login, OldPassword, NewPassword))
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
                    string checkstatus=err.ReturnValue.ToString();
                    if (checkstatus == "1")
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = err.Message.ToString();
                        iniControls();
                    }
                    else
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Password is not saved !";
                       
                       
                    }
                    //Response.Redirect("ListOrchardMaster.aspx?OrchardCode=");
                }
            }

        }
    }
}