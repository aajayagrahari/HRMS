using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace HRMS_Class
{
    public class ReportMaster
    {
        public string EmployeeAttendanceSummary(DataTable _dt)
        {
            StringBuilder sb=new StringBuilder();
            sb.Append("<table width='100%'  align='center' cellpadding='0' cellspacing='0' style='border:1px solid #000000;font-size:14px;'>");
            sb.Append("<tr>");
            sb.Append("<td colspan='8' style=' background:#4b6c9e;  color:#fff;border-bottom:1px solid #000000;' align='center'>Attendance Summary</td></tr>");
            sb.Append("<tr>");
            sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;border-top:1px solid #000000;'><b>Date</b></td>");
            sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;border-top:1px solid #000000;'><b>Status</b></td>");
            sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;border-top:1px solid #000000;'><b>MarkIn Date</b></td>");
            sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;border-top:1px solid #000000;'><b>MarkIn Time</b></td>");
            sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;border-top:1px solid #000000;'><b>MarkIn Remark</b></td>");
            sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;border-top:1px solid #000000;'><b>MarkOut Date</b></td>");
            sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;border-top:1px solid #000000;'><b>MarkOut Time</b></td>");
            sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-top:1px solid #000000;'>MarkOut Remark</td>");
            sb.Append("</tr>");
            if(_dt.Rows.Count>0)
            {
            for (int i=0;i<_dt.Rows.Count;i++)
            {
                sb.Append("<tr>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[i]["Date1"].ToString() + "</td>");
                if (_dt.Rows[i]["Status1"].ToString().ToUpper() == "WO")
                {
                    sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'><b>" + _dt.Rows[i]["Status1"].ToString() + "</b></td>");
                }
                else
                {
                    sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[i]["Status1"].ToString() + "</td>");
                }
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[i]["MarkInDate"].ToString() + "</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[i]["MarkInTime"].ToString() + "</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[i]["MarkInRemark"].ToString() + "</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[i]["MarkOutDate"].ToString() + "</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[i]["MarkOutTime"].ToString() + "</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;'>" + _dt.Rows[i]["MarkOutRemark"].ToString() + "</td>");
                sb.Append("</tr>");

            }
            }
            else
            {
                sb.Append("<td colspan='8'>There is no record...</td>");
            }
            sb.Append("</table>");
            return sb.ToString();
        }
        public string EmployeeSalaryDetail(DataSet _ds)
        {
             DataTable _dt=_ds.Tables[0];
          
            StringBuilder sb = new StringBuilder();
            
            sb.Append("<table width='100%'  align='center' cellpadding='0' cellspacing='0' style='font-size:14px;'>");
            if (_dt.Rows.Count > 0)
            {
                decimal BasicSalary = Convert.ToDecimal(_dt.Rows[0]["BasicSalary"].ToString());

                decimal perDayS = BasicSalary / Convert.ToDecimal(_dt.Rows[0]["TotalDaysinMonth"].ToString());

                decimal paidSalary = Convert.ToInt32(_dt.Rows[0]["PaidDay"].ToString()) * perDayS;
                //Int32 Uded_CL = 0;
                //if (Convert.ToInt32(_dt.Rows[0]["LateComingDay"].ToString()) > 3)
                //{
                //    Int32 MinusInCl = Convert.ToInt32(_dt.Rows[0]["LateComingDay"].ToString()) - 3;
                //    Uded_CL = MinusInCl;
                //}

                sb.Append("<tr>");
                sb.Append("<td colspan='5' style=' background:#4b6c9e;  color:#fff;border-bottom:1px solid #000000;' align='center'>Leave Detail:</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td width='20%' align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'></td>");
                sb.Append("<td width='20%' align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>CL</td>");
                sb.Append("<td width='20%' align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>HPL</td>");
                sb.Append("<td width='20%' align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>EL</td>");
                sb.Append("<td width='20%' align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>RH</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Alloted</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[0]["Alloted_CL"].ToString() + "</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[0]["Alloted_HPL"].ToString() + "</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[0]["Alloted_EL"].ToString() + "</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[0]["Alloted_RH"].ToString() + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Used</td>");
                

                    sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[0]["Uded_CL"].ToString() + "</td>");
                
               
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[0]["Uded_HPL"].ToString() + "</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[0]["Uded_EL"].ToString() + "</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[0]["Uded_RH"].ToString() + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Remaining</td>");
                
                    sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[0]["Balance_CL"].ToString() + "</td>");
              
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[0]["Balance_HPL"].ToString() + "</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[0]["Balance_EL"].ToString() + "</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>" + _dt.Rows[0]["Balance_RH"].ToString() + "</td>");
                sb.Append("</tr>");

                sb.Append("<tr><td colspan='5'><table width='50%'  align='center' cellpadding='0' cellspacing='0' style='border-bottom:1px solid #000000;border-left:1px solid #000000;border-right:1px solid #000000;font-size:14px;'>");
                sb.Append("<tr>");
                sb.Append("<td colspan='2' style=' background:#4b6c9e;  color:#fff;border-bottom:1px solid #000000;' align='center'>Attendance Detail:</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td width='25%' align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Employee Id:</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;'>" + _dt.Rows[0]["EmployeeId"].ToString() + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Basic Salary:</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;'>" + BasicSalary + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Total Day:</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;'>" + _dt.Rows[0]["TotalDaysinMonth"].ToString() + "</td>");
                sb.Append("</tr>");
                //sb.Append("<tr>");
                //sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Paid Day:</td>");
                //sb.Append("<td align='center' style='border-bottom:1px solid #000000;'>" + _dt.Rows[0]["PaidDay"].ToString() + "</td>");
                //sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Week off(WO):</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;'>" + _dt.Rows[0]["NoofWeekOffDays"].ToString() + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Present Day:</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;'>" + _dt.Rows[0]["NoofPresentDays"].ToString() + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Absent Day:</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;'>" + _dt.Rows[0]["NoofAbsentDays"].ToString() + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Late Coming Day:</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;'>" + _dt.Rows[0]["LateComingDay"].ToString() + "</td>");
                sb.Append("</tr>");

                

                sb.Append("<tr>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;border-right:1px solid #000000;'>Total Salary Day:</td>");
                sb.Append("<td align='center' style='border-bottom:1px solid #000000;'>" + _dt.Rows[0]["PaidDay"].ToString() + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td align='center' style='border-right:1px solid #000000;'>Paid Salary:</td>");
                sb.Append("<td align='center' >" + paidSalary.ToString("F") + "</td>");
                sb.Append("</tr>");
                sb.Append("</table></td></tr>");
            }
            else
            {
                sb.Append("<tr><td>There is no record...</td></tr>");
            }
            
            sb.Append("</table>");
            return sb.ToString();
        }

        public string GenratePaySlip(DataSet ds)
        {
            DataTable _dt = ds.Tables[0];
            DataTable _dt1 = ds.Tables[1];
           // DataTable _dt2 = ds.Tables[2];

            StringBuilder sb = new StringBuilder();
            sb.Append("<table width='100%' align='center'>");
            sb.Append("<tr>");
            sb.Append("<td width='20%'></td>");
            sb.Append("<td width='20%' align='center'><b>BROADCAST ENGINEERING CONSULTANTS INDIA LTD.</b></td>");
            sb.Append("<td width='20%'></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td><img src='../../Images/logo.jpg' width='100' height='100' /></td>");
            sb.Append("<td align='center'>14-B, Ring Road,<br>Indraprastha Estate,<br>New Delhi 110002");
            sb.Append("</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td></td>");
            sb.Append("<td align='center'><b>Pay Slip<br>For August-2013</b></td>");
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

            sb.Append("<tr><td colspan='6'><table width='100%'>");
            sb.Append("<hr>");
            sb.Append("<tr>");
            sb.Append("<th>Earning</th>");
            sb.Append("<th>Amount</th>");
            sb.Append("<th>Deduction</th>");
            sb.Append("<th>Amount</th>");
            sb.Append("</tr>");
            for (int i = 0; i < _dt1.Rows.Count; i++)
            {
                sb.Append("<tr>");
                sb.Append("<td>" + _dt1.Rows[i]["Allowanceces"].ToString() + "</td>");
                sb.Append("<td>" + _dt1.Rows[i]["AllowancecesAmt"].ToString() + "</td>");
                sb.Append("<td>" + _dt1.Rows[i]["Deductions"].ToString() + "</td>");
                sb.Append("<td>" + _dt1.Rows[i]["DeductionsAmt"].ToString() + "</td>");
                sb.Append("</tr>");
            }
            sb.Append("<tr>");
            sb.Append("<td><b>Total Earning</td>");
            sb.Append("<td><b>_________<b></td>");
            sb.Append("<td>Total Deduction</td>");
            sb.Append("<td><b>_________</b></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td></td>");
            sb.Append("<td></td>");
            sb.Append("<td>Net Amount</td>");
            sb.Append("<td><b>_________</b></td>");
            sb.Append("</tr>");
            sb.Append("</table></td></tr>");
            sb.Append("</table></td></tr>");

            sb.Append("<tr>");
            sb.Append("<td>Amount(in words)</td>");
            sb.Append("<td></td>");
            sb.Append("<td>for BROADCAST ENGINEERING CONSULTANTS INDIA LTD.</td>");

            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>__________</td>");
            sb.Append("<td></td>");
            sb.Append("<td></td>");

            sb.Append("</tr>");
            sb.Append("</table>");
            return sb.ToString();

        }
    }
}
