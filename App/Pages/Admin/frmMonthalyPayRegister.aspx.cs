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
using System.Text;

#region Development Details
//Shruti Dwivedi(25-09-2013)
#endregion Development Details

public partial class Pages_Admin_frmMonthalyPayRegister : System.Web.UI.Page
{
    #region Global Variable Declaration
    ReportMasterManager _objReportMasterManager = new ReportMasterManager();
    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //DataTable _dt = _objReportMasterManager.PayRegister(Convert.ToInt32(ddlMonth.SelectedValue));
                //litPayRegisterReport.Text = PayRegister(_dt);
                
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }

    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = _objReportMasterManager.PayRegister(Convert.ToInt32(ddlMonth.SelectedValue));
            litPayRegisterReport.Text = PayRegister(ds);
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }

    }
    #endregion Page Event

    #region Page Specific Function
    private string PayRegister(DataSet ds)
    {
        StringBuilder sb = new StringBuilder();
        DataTable _dt = ds.Tables[0];
        DataTable _dt1 = ds.Tables[1];

        sb.Append("<table width='100%' align='center'>");
        if (_dt.Rows.Count > 0)
        {
            btnPrint.Enabled = true;
            sb.Append("<tr>");
            // sb.Append("<th></th>");
            sb.Append("<th align='center' colspan='4'>KHURANA ENGINEERING<br>");
            sb.Append("G-62, LAJPAT NAGAR-III, NEW DELHI<br>");
            sb.Append("Pay Register Grand Summary for the Month of September, 2013");
            sb.Append("</th>");
            //sb.Append("<th></th>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td colspan='4'><table width='100%' align='center' style='border:1px black solid;'>");
            sb.Append("<tr>");
            sb.Append("<th align='left'>Earning</th>");
            sb.Append("<th align='left'>Amount</th>");
            sb.Append("<th align='left'>Arrears</th>");
            sb.Append("<th align='left'>Total</th>");
            sb.Append("<th align='left'>Deductions</th>");
            sb.Append("<th align='left'>Amount</th>");
            sb.Append("<th align='left'>Employer</th>");
            sb.Append("</tr>");
            decimal TotalAllowanceAmount = 0, TotalDeductionAmt = 0;
            decimal TotalPaymet = 0;
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                sb.Append("<tr>");
                sb.Append("<td align='left'>" + _dt.Rows[i]["Allowance"].ToString() + "</td>");
                sb.Append("<td align='left'>" + _dt.Rows[i]["Amount"].ToString() + "</td>");
                sb.Append("<td align='left'>" + _dt.Rows[i]["Arreasrs"].ToString() + "</td>");
                sb.Append("<td align='left'>" + _dt.Rows[i]["Total"].ToString() + "</td>");
                sb.Append("<td align='left'>" + _dt.Rows[i]["Deductions"].ToString() + "</td>");
                sb.Append("<td align='left'>" + _dt.Rows[i]["DedAmount"].ToString() + "</td>");
                sb.Append("<td align='left'>" + _dt.Rows[i]["Employer"].ToString() + "</td>");
                sb.Append("</tr>");
                TotalAllowanceAmount = TotalAllowanceAmount = TotalAllowanceAmount + Convert.ToDecimal(_dt.Rows[i]["Amount"].ToString());
                TotalDeductionAmt = TotalDeductionAmt + Convert.ToDecimal((_dt.Rows[i]["DedAmount"]==DBNull.Value?"0":_dt.Rows[i]["DedAmount"].ToString()));
            }
            TotalPaymet = TotalAllowanceAmount - TotalDeductionAmt;
            sb.Append("<tr>");
            sb.Append("<td align='left' style='background-color: ActiveBorder'>Total</td>");
            sb.Append("<td align='left' style='background-color: ActiveBorder'>" + TotalAllowanceAmount + "</td>");
            sb.Append("<td align='left' style='background-color: ActiveBorder'>0.00</td>");
            sb.Append("<td align='left' style='background-color: ActiveBorder'>" + TotalAllowanceAmount + "</td>");
            sb.Append("<td align='left' style='background-color: ActiveBorder'></td>");
            sb.Append("<td align='left' style='background-color: ActiveBorder'>" + TotalDeductionAmt + "</td>");
            sb.Append("<td align='left' style='background-color: ActiveBorder'></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='right' style='background-color: ActiveBorder' colspan='6'>Total Payment</td>");
            sb.Append("<td align='left'  style='background-color: ActiveBorder'>" + TotalPaymet + "</td>");
            sb.Append("</tr>");
            sb.Append("</table></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='4'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td colspan='2' width='50%'><table width='100%' align='center' cellpadding='0' cellspacing='0'>");
            sb.Append("<tr>");
            sb.Append("<th align='left' style='border-left:1px black solid;border-top:1px black solid;border-bottom:1px black solid;'>S.No.</th>");
            sb.Append("<th align='left' style='border-top:1px black solid;border-bottom:1px black solid;'>Particulars</th>");
            sb.Append("<th align='left' style='border-right:1px black solid;border-top:1px black solid;border-bottom:1px black solid;'>Numbers</th>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='center'>1</td>");
            sb.Append("<td align='left'>EMPLOYEE COVERED UNDER EPF</td>");
            sb.Append("<td align='center'>" + _dt1.Rows[0]["CoveredUnderEPF"].ToString() + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='center'>2</td>");
            sb.Append("<td align='left'>EMPLOYEE COVERED UNDER FPS</td>");
            sb.Append("<td align='center'>" + _dt1.Rows[0]["CoveredUnderFPS"].ToString() + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='center'>3</td>");
            sb.Append("<td align='left'>EMPLOYEE CONTRIBUTED UNDER EPF</td>");
            sb.Append("<td align='center'>" + _dt1.Rows[0]["ContributeunderEPF"].ToString() + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='center'>4</td>");
            sb.Append("<td align='left'>EMPLOYEE CONTRIBUTED UNDER FPS</td>");
            sb.Append("<td align='center'>" + _dt1.Rows[0]["ContributeunderFPS"].ToString() + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='center'>5</td>");
            sb.Append("<td align='left'>PF EXEMPTED</td>");
            sb.Append("<td align='center'>" + _dt1.Rows[0]["PFExemptedEmp"].ToString() + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='center'>6</td>");
            sb.Append("<td align='left'>EMPLOYEE CONTRIBUTION UNDER ESI</td>");
            sb.Append("<td align='center'>" + _dt1.Rows[0]["ContributeunderESI"].ToString() + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='center'>7</td>");
            sb.Append("<td align='left'>EMPLOYEE COVERED UNDER ESI</td>");
            sb.Append("<td align='center'>" + _dt1.Rows[0]["CoveredUnderESI"].ToString() + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='center'>8</td>");
            sb.Append("<td align='left'>EMPLOYEE NOT COVERED UNDER ESI</td>");
            sb.Append("<td align='center'>" + _dt1.Rows[0]["NotCoveredUnderESI"].ToString() + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='center'>9</td>");
            sb.Append("<td align='left'>TOTAL NO. OF EMPLOYEES</td>");
            sb.Append("<td align='center'>" + _dt1.Rows[0]["TotalEmployee"].ToString() + "</td>");
            sb.Append("</tr>");
            sb.Append("</table></td>");
            sb.Append("<td colspan='2' width='50%' valign='top'><table width='100%' align='center' cellpadding='0' cellspacing='0' >");
            sb.Append("<tr >");
            sb.Append("<th align='left' style='border-left:1px black solid;border-top:1px black solid;border-bottom:1px black solid;'>S.No.</th>");
            sb.Append("<th align='left' style='border-top:1px black solid;border-bottom:1px black solid;'>Particulars</th>");
            sb.Append("<th align='left' style='border-right:1px black solid;border-top:1px black solid;border-bottom:1px black solid;'>Wages</th>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='left'>1</td>");
            sb.Append("<td align='left'>E.P.F ARREARS WAGES</td>");
            sb.Append("<td align='left'>______</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='left'>2</td>");
            sb.Append("<td align='left'>E.S.I ARREARS WAGES</td>");
            sb.Append("<td align='left'>______</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='left'>3</td>");
            sb.Append("<td align='left'>OVER TIME FOR ESI</td>");
            sb.Append("<td align='left'>______</td>");
            sb.Append("</tr>");
            sb.Append("</table></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='4'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td colspan='3'><table width='100%' align='center' cellpadding='0' cellspacing='0'>");
            sb.Append("<tr>");
            sb.Append("<th  align='left' style='border-left:1px black solid;border-top:1px black solid;border-bottom:1px black solid;'>S.No.</th>");
            sb.Append("<th  align='left' style='border-top:1px black solid;border-bottom:1px black solid;'>Particulars</th>");
            sb.Append("<th  align='left' style='border-top:1px black solid;border-bottom:1px black solid;'>Employee</th>");
            sb.Append("<th  align='left' style='border-right:1px black solid;border-top:1px black solid;border-bottom:1px black solid;'>Employer</th>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td  align='left'>1</td>");
            sb.Append("<td  align='left'>TOTAL SALARY/WAGES FOR EPF</td>");
            sb.Append("<td  align='left'>" + _dt1.Rows[0]["TotalEPFAllEmp"].ToString() + "</td>");
            sb.Append("<td  align='left'>" + _dt1.Rows[0]["TotalEPFAllEmp"].ToString() + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td  align='left'>2</td>");
            sb.Append("<td  align='left'>TOTAL SALARY/WAGES FOR FPF</td>");
            sb.Append("<td  align='left'>.........</td>");
            sb.Append("<td  align='left'>.........</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td  align='left'>3</td>");
            sb.Append("<td  align='left'>TOTAL SALARY/WAGES FOR ESI</td>");
            sb.Append("<td  align='left'>" + _dt1.Rows[0]["TotalGrossPayofESIEmployee"].ToString() + "</td>");
            sb.Append("<td  align='left'>" + _dt1.Rows[0]["TotalGrossPayofESIEmployee"].ToString() + "</td>");
            sb.Append("</tr>");
            decimal EPFcontributedEmployee=0;
            decimal EPFcontributedEmployer = 0;

            decimal ESIcontributedEmployee = 0;
            decimal ESIcontributedEmployer = 0;
            decimal AC21 = 0;
            decimal AC2 = 0;
            decimal AC22 = 0;
            

            AC21 = (Convert.ToDecimal(_dt1.Rows[0]["TotalWagesforEPF"].ToString()) * Convert.ToDecimal(0.50)) / 100;
            AC2 = (Convert.ToDecimal(_dt1.Rows[0]["TotalWagesforEPF"].ToString()) * Convert.ToDecimal(1.10)) / 100;
            AC22 = (Convert.ToDecimal(_dt1.Rows[0]["TotalWagesforEPF"].ToString()) * Convert.ToDecimal(0.01)) / 100;

            EPFcontributedEmployee = (Convert.ToDecimal(_dt1.Rows[0]["TotalWagesforEPF"].ToString()) * Convert.ToDecimal(12)) / 100;
            EPFcontributedEmployer = (Convert.ToDecimal(_dt1.Rows[0]["TotalWagesforEPF"].ToString()) * Convert.ToDecimal(3.67)) / 100;

            ESIcontributedEmployee = (Convert.ToDecimal(_dt1.Rows[0]["TotalGrossPayofESIEmployee"].ToString())*Convert.ToDecimal(1.75))/100;
            ESIcontributedEmployer = (Convert.ToDecimal(_dt1.Rows[0]["TotalGrossPayofESIEmployee"].ToString()) * Convert.ToDecimal(4.75)) / 100;

            sb.Append("<tr>");
            sb.Append("<td  align='left'>4</td>");
            sb.Append("<td  align='left'>TOTAL E.P.F CONTRIBUTION</td>");
            sb.Append("<td  align='left'>" + EPFcontributedEmployee + "</td>");
            sb.Append("<td  align='left'>" + EPFcontributedEmployer + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td  align='left'>5</td>");
            sb.Append("<td  align='left'>TOTAL F.P.S CONTRIBUTION</td>");
            sb.Append("<td  align='left'>.........</td>");
            sb.Append("<td  align='left'>.........</td>");
            sb.Append("</tr>");
            sb.Append("<td  align='left'>6</td>");
            sb.Append("<td  align='left'>TOTAL E.S.I CONTRIBUTION</td>");
            sb.Append("<td  align='left'>" + ESIcontributedEmployee + "</td>");
            sb.Append("<td  align='left'>" + ESIcontributedEmployer + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");

            sb.Append("<tr>");
            sb.Append("<td  align='left'>7</td>");
            sb.Append("<td  align='left'>D.L.I A/C NO. 21</td>");
            sb.Append("<td  align='left'></td>");
            sb.Append("<td  align='left'>" + AC21 + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td  align='left'>8</td>");
            sb.Append("<td  align='left'>ADMINISTRATIVE CHARGES FOR EPF A/C NO.2</td>");
            sb.Append("<td  align='left'></td>");
            sb.Append("<td  align='left'>" + AC2 + "</td>");
            sb.Append("</tr>");
            sb.Append("<td  align='left'>9</td>");
            sb.Append("<td  align='left'>ADMINISTRATIVE CHARGES FOR EDLI A/C NO.22</td>");
            sb.Append("<td  align='left'></td>");
            sb.Append("<td  align='left'>" + AC22 + "</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td  align='left'>10</td>");
            sb.Append("<td  align='left'>INSPECTION CHARGES FOR  A/C NO.22</td>");
            sb.Append("<td  align='left'></td>");
            sb.Append("<td  align='left'>0.00</td>");
            sb.Append("</tr>");
            sb.Append("</table></td>");
            sb.Append("<td></td>");


            Decimal AllTotal = Convert.ToDecimal(EPFcontributedEmployee) + Convert.ToDecimal(TotalAllowanceAmount); 
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<th colspan='3' align='left'>");
            sb.Append("Total Earning+Total Employer PF Contribution+Reimbursement&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + AllTotal);
            sb.Append("</th>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='4'><hr></td></tr>");
            sb.Append("<tr><td colspan='4' valign='top' align='center'>*End of Summary*</td></tr>");
            sb.Append("</table>");
        }
        else
        {
            btnPrint.Enabled = false;
            sb.Append("<tr><td>There is no record.....</td></tr>");
        }
        return sb.ToString();
    }
    #endregion Page Specific Function
    
}