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
using System.IO;
#region Development Details
// Harendra kumar maurya(14-10-2013)
#endregion Development Details
public partial class Pages_Admin_frmCircularMaster1 : System.Web.UI.Page
{
    CircularMasterManager objCircularMasterManager = new CircularMasterManager();
    CircularMaster objCircularMaster = new CircularMaster();
    long CId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            GetId();
            BindCircularById();
        }
    }

    public long GetId()
    {
        long cid = 0;
        if (Request.QueryString["Cid"]!= null)
        {
            cid = Convert.ToInt64(Request.QueryString["Cid"].ToString());
        }
        return cid;
    }
    void BindCircularById()
    {
        DataSet ds = new DataSet();
        ds = objCircularMasterManager.GetCircularMasterById(GetId());
        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_title.Text=ds.Tables[0].Rows[0]["Title"].ToString();
            edt_descripion.Content = ds.Tables[0].Rows[0]["Description"].ToString();
            btn_submit.Text = "Update";
        }
    
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
        if (txt_title.Text.Trim().Length > 0)
        {

            objCircularMaster.Title = txt_title.Text.Trim();
        }
        else
        {
            lblMsg.Text = "Please Enter Title !.";
            return;
        
        }

        if (edt_descripion.Content.Length > 0)
        {

            objCircularMaster.Description = edt_descripion.Content;
        }
        else
        {
            lblMsg.Text = "Please Enter Description !.";
            return;

        }
        objCircularMaster.CreatedBy = Session["LoginId"].ToString();

       
        if (Request.QueryString["Cid"] != null)
        {
            objCircularMaster.CId = Convert.ToInt64(Request.QueryString["Cid"].ToString());
        }
        if (btn_submit.Text == "Update")
        {
            foreach (ErrorHandlerClass err in objCircularMasterManager.UpdateCircularMaster(objCircularMaster))
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
                else if (err.Type == "S")
                {
                    
                    lblMsg.ForeColor = Color.Green;
                    lblMsg.Text = err.Message.ToString();
                      if (Request.QueryString["Cid"] != null)
        {
           CId = Convert.ToInt64(Request.QueryString["Cid"].ToString());
           Response.Redirect("ListCircularMaster.aspx?=" + CId);
        }
                     



                }

            }

        }
        else
        {


            foreach (ErrorHandlerClass err in objCircularMasterManager.SaveCircularMaster(objCircularMaster))
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
                else if (err.Type == "S")
                {

                    lblMsg.ForeColor = Color.Green;
                    lblMsg.Text = err.Message.ToString();
                    txt_title.Text = "";
                    edt_descripion.Content = "";



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
}