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
//Shruti Dwivedi(16-10-2013)
#endregion Development Details


public partial class Pages_Admin_frmTrainingEmployeeReport : System.Web.UI.Page
{ 
    #region Global Variable Declaration
    TrainingMasterManager _objTrainingMasterManager = new TrainingMasterManager();
    ReportMaster _objReportMaster = new ReportMaster();
    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Request.QueryString != null)
            {
                DataSet DS = _objTrainingMasterManager.GetTrainingMasterById(Convert.ToInt32(Request.QueryString.ToString().Split('=')[1]));
                //litReport.Text = _objReportMaster.TrainingEmployeeList(DS);
                litReport.Text = TrainingEmployeeList(DS);

            }
          
        }
    }
    #endregion Page Event

    #region Page Specific Event
    public string TrainingEmployeeList(DataSet ds)
    {
        DataTable _dt = ds.Tables[0];
        DataTable _dt1 = ds.Tables[1];
        StringBuilder sb = new StringBuilder();
        sb.Append("<table width='100%'  align='center' cellpadding='0' cellspacing='0' style='font-size:14px;border:1px solid #000000;'>");
        sb.Append("<tr><td colspan='5' style=' background:#4b6c9e;  color:#fff;border-bottom:1px solid #000000;' align='center'>Training Detail</td></tr>");
        sb.Append("<tr>");
        sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Subject</td>");
        sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Start Date</td>");
        sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>End Date</td>");
        sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Duration</td>");
        sb.Append("<td style='border-bottom:1px solid #000000;'>Description</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[0]["Traning_Subject"] + "</td>");
        sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[0]["StarDate"] + "</td>");
        sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[0]["EndDate"] + "</td>");
        sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[0]["Duration"] + "</td>");
        sb.Append("<td style='border-bottom:1px solid #000000;'>" + _dt.Rows[0]["Traning_Description"] + "</td>");
        sb.Append("</tr>");
        sb.Append("<tr><td colspan='5'><br></td></tr>");
        sb.Append("<tr>");
        sb.Append("<td colspan='5'>");
        sb.Append("<table width='100%' align='center'>");
        sb.Append("<tr><td colspan='6' style=' background:#4b6c9e;  color:#fff;border-bottom:1px solid #000000;' align='center'>Employee Detail</td></tr>");
        sb.Append("<tr>");
        sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Employee Id</td>");
        sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Employee Name</td>");
        sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Contact No.</td>");
        sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Email-Id</td>");
        sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Designation</td>");
        sb.Append("<td style='border-bottom:1px solid #000000;'>Department</td>");
        sb.Append("</tr>");
        for (int i = 0; i < _dt1.Rows.Count; i++)
        {
            sb.Append("<tr>");
            sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt1.Rows[i]["EmployeeId"] + "</td>");
            sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt1.Rows[i]["Name"] + "</td>");
            sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt1.Rows[i]["ContactNo"] + "</td>");
            sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt1.Rows[i]["EmailId"] + "</td>");
            sb.Append("<td style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt1.Rows[i]["Designation"] + "</td>");
            sb.Append("<td style='border-bottom:1px solid #000000;'>" + _dt1.Rows[i]["Department"] + "</td>");
            sb.Append("</tr>");
        }
        sb.Append("</table>");
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("</table>");
        return sb.ToString();

    }
    #endregion Page Specific Event
}