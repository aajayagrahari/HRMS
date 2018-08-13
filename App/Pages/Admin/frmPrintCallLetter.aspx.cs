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
#region Development Details
//Shruti Dwivedi(18-10-2013)
#endregion Development Details

public partial class Pages_Admin_frmPrintCallLetter : System.Web.UI.Page
{
    #region Global Variable Declaration
    CallLetterMasterManager _objCallLetterMasterManager = new CallLetterMasterManager();
    MailMasterManager _objMailMasterManager = new MailMasterManager();
    DataTable _dt;
    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CallLetterId"] != null)
                {
                    _dt = _objCallLetterMasterManager.GetCallLetterMasterById(Convert.ToInt32(Request.QueryString["CallLetterId"].Split('-')[0])).Tables[0];
                    litReport.Text = CallLetter(_dt, Request.QueryString["CallLetterId"].Split('-')[1]);
                }
            }
        }
        catch (Exception ee)
        {
            lblmsg.Text = ee.StackTrace;
            lblmsg.ForeColor = Color.Red;
        }

    }
    protected void btnSendMail_Click(object sender, EventArgs e)
    {
        bool isSuccess;
        _dt = _objCallLetterMasterManager.GetCallLetterMasterById(Convert.ToInt32(Request.QueryString["CallLetterId"].Split('-')[0])).Tables[0];
        isSuccess = MailMasterManager.SendEmail(_dt.Rows[0]["EmailId"].ToString(), "Call Letter", litReport.Text);
        if (isSuccess == true)
        {
            lblmsg.Text = "Successfully send";
        }

    }
    #endregion Page Event

    #region Page Specific Event
    private string CallLetter(DataTable _dt, string ManagerName)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<table width='100%'  align='center' cellpadding='0' cellspacing='0' style='padding:20px 90px 20px 90px;'>");
        sb.Append("<tr><td align='center'><font size='4'> <b>Call Letter<b></font></td></tr>");
        sb.Append("<tr><td align='center'><br/><br/></td></tr>");

        sb.Append("<tr><td>File Name <b>" + _dt.Rows[0]["CFileName"].ToString() + "</b></td></tr>");
        sb.Append("<tr><td>Date <b>" + DateTime.Now.ToShortDateString() + "</b></td></tr>");
        sb.Append("<tr><td><br></td></tr>");
        sb.Append("<tr><td>BCIL<br>14-B,Ring Road, I.P.Estate, New Delhi-110002.<br>");
        sb.Append("Tel : +91-11-23378823/24/25<br>E-mail: contactus@becil.com</td></tr>");
        sb.Append("<tr><td><br></td></tr>");
        sb.Append("<tr>");
        sb.Append("<td>");
        sb.Append("Dear Candidate,<b>" + _dt.Rows[0]["Name"].ToString() + "</b>");
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr><td><br></td></tr>");
        sb.Append("<tr>");
        sb.Append("<td>");
        sb.Append("Reference to our advertisement and your application / registration with BECIL for the ");
        sb.Append("<br>");
        sb.Append("contractual post of <b>" + _dt.Rows[0]["Designation"].ToString() + "  " + _dt.Rows[0]["ProjectSiteName"].ToString() + "</b>. You are invited to be present ");
        sb.Append("yourself at <b>" + _dt.Rows[0]["Venue"].ToString() + "</b> for Skill Test followed by Interview at  on <b>" + _dt.Rows[0]["InterviewDate"].ToString() + "</b>.");
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr><td><br></td></tr>");
        sb.Append("<tr>");
        sb.Append("<td>");
        sb.Append("Please bring all your original certificates in support of your qualification & professional ");
        sb.Append("<br>");
        sb.Append("experience for verification. ");
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td>");
        sb.Append("Please note that no TA/DA etc would be payable for attending the interviews.");
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr><td><br></td></tr>");
        sb.Append("<tr>");
        sb.Append("<td>");
        sb.Append("A line in confirmation that you would attend the interview would be ");
        sb.Append("<br>");
        sb.Append("appreciable. Please report 30 min. before the given time.");
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("<tr><td><br><br><br></td></tr>");
        sb.Append("<tr><td>(" + ManagerName + ")<br>Manager(HR)</tr>");

        sb.Append("</table>");
        return sb.ToString();
    }
    #endregion Page Specific Event

}