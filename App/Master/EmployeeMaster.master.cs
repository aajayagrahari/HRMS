using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployeeMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginId"] != null)
        {
            if (Convert.ToString(Session["UserType"]).Trim() == "RGLR")
            {
                lblLoggedUserName.Text = Session["LoginId"].ToString();
            }
            else
            {
                Response.Redirect("~/frmLogin.aspx");
            }
        }
        else
        {
            Response.Redirect("~/frmLogin.aspx");
        }
        
    }
    
}
