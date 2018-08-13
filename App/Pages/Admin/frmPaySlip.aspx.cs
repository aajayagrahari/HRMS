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
using System.Text;
#region Development Details
//Shruti Dwivedi(04-10-2013)
#endregion Development Details

public partial class Pages_Admin_frmPaySlip : System.Web.UI.Page
{
    #region Global Variable Declaration
    ReportMaster _objReportMaster = new ReportMaster();
    ReportMasterManager _objReportMasterManager = new ReportMasterManager();
    ConvertMasterManager _objConvertMasterManager = new ConvertMasterManager();

    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string str = Request.QueryString["EmployeeId"].ToString();
            DataSet ds = new DataSet();
            ds = _objReportMasterManager.GenratePaySlip(Convert.ToInt64(Request.QueryString["EmployeeId"].Split('-')[0]));
            // litReport.Text = _objReportMaster.GenratePaySlip(ds);
            decimal BasicPay = Convert.ToDecimal(Request.QueryString["EmployeeId"].Split('-')[4].ToString());
            string MonthYear = Request.QueryString["EmployeeId"].Split('-')[1] + ' ' + Request.QueryString["EmployeeId"].Split('-')[2];
            litReport.Text = GenratePaySlip(ds, MonthYear, BasicPay);
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }

    }
    #endregion Page Event

    #region Page Specific Event
    public string GenratePaySlip(DataSet ds, string ForMonthYear, decimal PaidSalary)
    {
        DataTable _dt = ds.Tables[0];
        DataTable _dt1 = ds.Tables[1];
        // DataTable _dt2 = ds.Tables[2];

        StringBuilder sb = new StringBuilder();
        sb.Append("<table width='100%' align='center' cellpadding='5' cellspacing='5' style='padding:20px,20px,20px,20px;' >");
        sb.Append("<tr>");
        sb.Append("<td width='5%'><img src='../../Images/logo.jpg' width='100' height='100' /></td>");
        sb.Append("<td width='95%' align='center' colspan='2' ><b>BROADCAST ENGINEERING CONSULTANTS INDIA LTD.<br>14-B, Ring Road,<br>Indraprastha Estate,<br>New Delhi 110002</b></td>");
        //sb.Append("<td width='18%'></td>");
        sb.Append("</tr>");
        //sb.Append("<tr>");
        //sb.Append("<td><img src='../../Images/logo.jpg' width='100' height='100' /></td>");
        //sb.Append("<td align='center'>14-B, Ring Road,<br>Indraprastha Estate,<br>New Delhi 110002");
        //sb.Append("</td>");
        //sb.Append("<td></td>");
        //sb.Append("</tr>");
        sb.Append("<tr><td><br></td></tr>");
        sb.Append("<tr>");
        sb.Append("<td></td>");
        sb.Append("<td align='center'><b>Pay Slip<br><font size='2'>for " + ForMonthYear + "</font></b></td>");
        sb.Append("<td></td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td></td>");
        sb.Append("<td align='center'><b>" + _dt.Rows[0]["Name"].ToString() + "</b></td>");
        sb.Append("<td></td>");
        sb.Append("</tr>");
        sb.Append("<tr><td colspan='3'><table width='100%'  align='center' cellpadding='0' cellspacing='0' style='border:1px solid #000000;font-size:14px;'>");
        sb.Append("<tr>");
        sb.Append("<td>Employee Number</td>");
        sb.Append("<td>:</td>");
        sb.Append("<td>" + _dt.Rows[0]["EmployeeId"].ToString() + "</td>");

        sb.Append("<td>Income Tax Number(PAN)</td>");
        sb.Append("<td>:</td>");
        sb.Append("<td>" + _dt.Rows[0]["PANCardNo"].ToString() + "</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td>Function</td>");
        sb.Append("<td>:</td>");
        sb.Append("<td>" + _dt.Rows[0]["Department"].ToString() + "</td>");

        sb.Append("<td>PF Account Number</td>");
        sb.Append("<td>:</td>");
        sb.Append("<td>" + _dt.Rows[0]["PFNo"].ToString() + "</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td>Designation</td>");
        sb.Append("<td>:</td>");
        sb.Append("<td>" + _dt.Rows[0]["Designation"].ToString() + "</td>");

        sb.Append("<td>ESI Number</td>");
        sb.Append("<td>:</td>");
        sb.Append("<td>" + _dt.Rows[0]["ESINo"].ToString() + "</td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td>Loation</td>");
        sb.Append("<td>:</td>");
        sb.Append("<td>" + _dt.Rows[0]["ParamAddress"].ToString() + "</td>");

        sb.Append("<td></td>");
        sb.Append("<td></td>");
        sb.Append("<td></td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td>Bank Details</td>");
        sb.Append("<td>:</td>");
        sb.Append("<td>" + _dt.Rows[0]["BankDetail"].ToString() + "</td>");

        sb.Append("<td></td>");
        sb.Append("<td></td>");
        sb.Append("<td></td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td>Date of Joining</td>");
        sb.Append("<td>:</td>");
        sb.Append("<td>" + _dt.Rows[0]["JoiningDate"].ToString() + "</td>");

        sb.Append("<td></td>");
        sb.Append("<td></td>");
        sb.Append("<td></td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td>Working Salary</td>");
        sb.Append("<td>:</td>");
        sb.Append("<td>" + PaidSalary + "</td>");

        sb.Append("<td></td>");
        sb.Append("<td></td>");
        sb.Append("<td></td>");
        sb.Append("</tr>");

        sb.Append("<tr><td colspan='6'><table width='100%'>");
        sb.Append("<hr>");
        sb.Append("<tr>");
        sb.Append("<th>Earning</th>");
        sb.Append("<th>Amount</th>");
        sb.Append("<th>Deduction</th>");
        sb.Append("<th>Amount</th>");
        sb.Append("</tr>");
        decimal TotalEarning = 0;
        decimal TotalDesuction = 0;
        decimal NetAmount;
        string AmountinWord;
        decimal Employee_EPFAmount = 0;
        for (int i = 0; i < _dt1.Rows.Count; i++)
        {
            TotalEarning = TotalEarning + Convert.ToDecimal(_dt1.Rows[i]["AllowancecesAmt"].ToString());


            sb.Append("<tr>");
            sb.Append("<td align='center'>" + _dt1.Rows[i]["Allowanceces"].ToString() + "</td>");
            sb.Append("<td align='center'>" + _dt1.Rows[i]["AllowancecesAmt"].ToString() + "</td>");
            sb.Append("<td align='center'>" + _dt1.Rows[i]["Deductions"].ToString() + "</td>");
            if (_dt1.Rows[i]["Deductions"].ToString() == "EPF")
            {
                Employee_EPFAmount = PaidSalary * Convert.ToDecimal(12.50) / 100;
                sb.Append("<td align='center'>" + Employee_EPFAmount.ToString("F") + "</td>");
                TotalDesuction = TotalDesuction + Employee_EPFAmount;
            }
            else if (_dt1.Rows[i]["Deductions"].ToString() == "VPF")
            {
                Employee_EPFAmount = PaidSalary * Convert.ToDecimal(12) / 100;
                sb.Append("<td align='center'>" + Employee_EPFAmount.ToString("F") + "</td>");
                TotalDesuction = TotalDesuction + Employee_EPFAmount;

            }
            else if (_dt1.Rows[i]["Deductions"].ToString() == "ESI")
            {
                Employee_EPFAmount = PaidSalary * Convert.ToDecimal(1.75) / 100;
                sb.Append("<td align='center'>" + Employee_EPFAmount.ToString("F") + "</td>");
                TotalDesuction = TotalDesuction + Employee_EPFAmount;
            }
            else if (_dt1.Rows[i]["Deductions"].ToString() == "LWF")
            {
                Employee_EPFAmount = PaidSalary * Convert.ToDecimal(12) / 100;
                sb.Append("<td align='center'>" + Employee_EPFAmount.ToString("F") + "</td>");
                TotalDesuction = TotalDesuction + Employee_EPFAmount;
            }

            else
            {
                sb.Append("<td align='center'>" + 0 + "</td>");
                TotalDesuction = TotalDesuction + 0;
            }
            sb.Append("</tr>");
        }

        NetAmount = TotalEarning - TotalDesuction;
        sb.Append("<tr>");
        sb.Append("<td align='center'><b>Total Earning</td>");
        sb.Append("<td align='center'><b>" + TotalEarning + "<b></td>");
        sb.Append("<td align='center'>Total Deduction</td>");
        sb.Append("<td align='center'><b>" + TotalDesuction.ToString("F") + "</b></td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td align='center'></td>");
        sb.Append("<td align='center'></td>");
        sb.Append("<td align='center'>Net Amount</td>");
        sb.Append("<td align='center'><b>" + NetAmount.ToString("F") + "</b></td>");
        sb.Append("</tr>");
        sb.Append("</table></td></tr>");
        sb.Append("</table></td></tr>");
        AmountinWord = _objConvertMasterManager.changeNumericToWords(Convert.ToDouble(NetAmount.ToString("F")));
        sb.Append("<tr>");
        sb.Append("<td>Amount(in words)</td>");
        sb.Append("<td colspan='2' align='right'><font size='2'>for BROADCAST ENGINEERING CONSULTANTS INDIA LTD.<font></td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td colspan='3'><font size='2'>" + AmountinWord + "<font></td>");
        sb.Append("<tr><td colspan='3'><br></td></tr>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td colspan='3' align='right'><font size='2'>Authorised Signatory<font></td>");
        sb.Append("</tr>");
        sb.Append("</table>");
        return sb.ToString();

    }
    #endregion Page Specific Event
}