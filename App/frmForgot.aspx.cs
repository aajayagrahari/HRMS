using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using ErrorHandler;
using HRMS_Class;
using System.Net.Mail;
public partial class Pages_Universal_frmForgot : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            string strEmailId = Convert.ToString(txtEmailId.Text).Trim();
            DataSet ds = new DataSet();
            ForgotPasswordManager objForgotPasswordManager = new ForgotPasswordManager();
            ds = objForgotPasswordManager.GetPassword(strEmailId);

            if (ds.Tables[0].Rows.Count > 0)
            {
                bool senmail = sendMail(strEmailId, ds);
                if (senmail == true)
                {
                    txtEmailId.Text = "";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Password sent successfull. Please check your E-mail !.";
                }
            }
            else
            {
                lblMsg.Text = "The Email Id you have entered does not exists.";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0} Sorry", ex);
        }

    }

    public bool sendMail(string strEmailId, DataSet ds)
    {
        try
        {
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress("harendra.maurya.net@gmail.com");
            Msg.To.Add(txtEmailId.Text);
            Msg.Subject = "Your Password Details";
            Msg.Body = "Hi, <br/>Please check your Login Detailss<br/><br/>Login Id: " + ds.Tables[0].Rows[0]["LoginId"] + "<br/><br/> Password: " + ds.Tables[0].Rows[0]["Password"] + "<br/><br/>";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("harendra.maurya.net@gmail.com", "maurya9911");
            smtp.EnableSsl = true;
            smtp.Send(Msg);
            return true;
        }
        catch (Exception ex)
        {

            lblMsg.Text = " " + ex.ToString();
            return false;
        }
    }

}