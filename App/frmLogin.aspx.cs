using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using ErrorHandler;
using HRMS_Class;
using System.Net;

public partial class frmLogin : System.Web.UI.Page
{
    LoginMasterManager objLoginMasterManager = new LoginMasterManager();
    string strHostName;
    string strIPAddress;
    string strUserAgent;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session.Clear();
            lblMsg.Text = "";
        }
    }

    protected void cmdLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string strUserName = Convert.ToString(txtUsername.Text);
            string strUserPassword = Convert.ToString(txtPassword.Text);

            strHostName = Dns.GetHostName();
            strIPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
            strUserAgent = Request.UserAgent;

            DataSet ds = new DataSet();
            DataSet dsRole = new DataSet();
            DataSet dsUserProfile = new DataSet();

            ds = objLoginMasterManager.CheckUserLogin(strUserName, strUserPassword);

            if (ds.Tables[0].Rows.Count != 0)
            {
                Session["LoginId"] = Convert.ToString(ds.Tables[0].Rows[0]["LoginId"]);
                Session["Password"] = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                Session["EmployeeId"] = Convert.ToString(ds.Tables[0].Rows[0]["EmployeeId"]);
                Session["UserType"] = Convert.ToString(ds.Tables[0].Rows[0]["UserType"]);

                SaveUserLoginDetails(strIPAddress, strUserAgent, strHostName, 1);

                if (Session["LoginId"] == null && Session["LoginId"].ToString() == "")
                {
                    Response.Redirect("~/Universal/frmHome.aspx");
                }
                else
                {
                    if (ds.Tables[0].Rows[0]["UserType"].ToString() == "ADMIN")
                    {
                        Response.Redirect("~/Pages/Admin/index.aspx");
                    }
                    else if (ds.Tables[0].Rows[0]["UserType"].ToString() == "RGLR")
                    {
                        Response.Redirect("~/Pages/Employee/index.aspx");
                    }
                }
            }
            else
            {
                SaveUserLoginDetails(strIPAddress, strUserAgent, strHostName, 0);
                lblMsg.Text = "Login detail was not found";
                lblMsg.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            lblMsg.Visible = true;
        }
    }

    public void SaveUserLoginDetails(string strIP, string strUserAgent, string srtHost, int iIsSuccessful)
    {
        LoginMaster objLoginMaster = new LoginMaster();

        objLoginMaster.LoginId = Convert.ToString(txtUsername.Text);
        objLoginMaster.IP = Convert.ToString(strIP);
        objLoginMaster.UserAgent = Convert.ToString(strUserAgent);
        objLoginMaster.Host = Convert.ToString(strHostName);
        objLoginMaster.LoginDate = Convert.ToDateTime(DateTime.Now.Date).ToString("yyyy-MM-dd");
        objLoginMaster.LastRefreshedDate = Convert.ToDateTime(DateTime.Now.Date).ToString("yyyy-MM-dd");
        objLoginMaster.IsSucessfull = iIsSuccessful;
        objLoginMasterManager.SaveLoginDetails(objLoginMaster);
    }

}