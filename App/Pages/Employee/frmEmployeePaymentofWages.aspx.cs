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

public partial class Pages_Admin_frmEmployeePaymentofWages : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                BindFinyear();
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
            DataSet ds = _objReportMasterManager.MyMonthWiseSalarySlip(Convert.ToInt32(ddlFinYear.SelectedValue.Split('-')[0]), Convert.ToInt32(ddlMonth.SelectedValue), Session["EmployeeId"].ToString());
            litReport.Text = PaymentWages(ds);
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }

    }
    #endregion Page Event

    #region Page Specific Event
    private string PaymentWages(DataSet _ds)
    {
        DataTable _dt = _ds.Tables[0];
        DataTable _dt1 = _ds.Tables[1];
        DataTable _dt2 = _ds.Tables[2];
        DataTable _dt3 = _ds.Tables[3];
       

        StringBuilder sb = new StringBuilder();
        sb.Append("<table align='center' width='100%' height='100%'>");
        sb.Append("<tr>");
        sb.Append("<td><img src='../../Images/logo.jpg' width='70' height='70' /></td>");
        sb.Append("<td align='right' width='30%'><b><font size='3'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;REGISTER OF WAGES</font></b></td>");
        sb.Append("<td align='right'><font size='2'>Name & Address of Principal Employer<br>");
        sb.Append("<b>BROADCAST ENGINEERING CONSULTANTS INDIA LIMITED</b></td>");
        sb.Append("</tr>");
        sb.Append("<tr><td colspan='3'><br><br></td></tr>");
        sb.Append("<tr>");
        sb.Append("<td><b><font size='1'>Brodcast Engineering Consultant India Limited<br>56-A/17, Block-C, Sector-62, Noida-201301,UP</br>Tel : 0120-4177850</b></td>");
        sb.Append("<td align='center'></td>");
        sb.Append("<td align='right'><font size='2'>For the Month of &nbsp;" + ddlMonth.SelectedItem.Text + "," + ddlFinYear.SelectedValue + "</td>");
        sb.Append("</tr>");
        sb.Append("<tr><td colspan='3'><br></td></tr>");
        sb.Append("<tr>");
        sb.Append("<td colspan='3'><table width='100%'  align='center' cellpadding='0' cellspacing='0' style='border:1px solid #000000;font-size:14px;'>");
        sb.Append("<tr>");
        sb.Append("<td width='27%' align='left' style='background: #4b6c9e; color: #fff; border-bottom: 1px solid #000000;'>Employee Particulars</td>");
        sb.Append("<td width='10%' align='center' style='background: #4b6c9e; color: #fff; border-bottom: 1px solid #000000;'>Days</td>");
        sb.Append("<td width='15%' align='right' style='background: #4b6c9e; color: #fff; border-bottom: 1px solid #000000;'></td>");
        sb.Append("<td width='10%' align='right' style='background: #4b6c9e; color: #fff; border-bottom: 1px solid #000000;'>Basic rate</td>");
        sb.Append("<td width='10%' align='right' style='background: #4b6c9e; color: #fff; border-bottom: 1px solid #000000;'>Earnings</td>");
        sb.Append("<td width='10%' align='center' style='background: #4b6c9e; color: #fff; border-bottom: 1px solid #000000;'>Arrears</td>");
        sb.Append("<td width='8%' align='right' style='background: #4b6c9e; color: #fff; border-bottom: 1px solid #000000;'></td>");
        sb.Append("<td width='10%' align='left' style='background: #4b6c9e; color: #fff; border-bottom: 1px solid #000000;'>Diductions</td>");
        sb.Append("<td width='3%'align='right' style='background: #4b6c9e; color: #fff; border-bottom: 1px solid #000000;border-right: 1px solid #000000;'>Signature</td>");
        sb.Append("</tr>");
        if (_dt.Rows.Count > 0 && _dt1.Rows.Count > 0 && _dt2.Rows.Count > 0 && _dt3.Rows.Count > 0)
        {
            for (int m = 0; m < _dt1.Rows.Count; m++)
            {
                decimal EarningPay = 0;
                Int32 TotalDay = 0;
                Int32 PaidDay = 0;
                decimal EPF = 0;
                decimal ESI = 0;
                decimal TotalGrosPay = 0;
                decimal TotalEarningPay = 0;
                decimal EmpEarGrossPay = 0;
                decimal TotalDeduction = 0;
                decimal NetPayment = 0;
                sb.Append("<tr>");
                //---------------
                sb.Append("<td><table width='100%' >");
                sb.Append("<tr>");
                sb.Append("<td>Sno</td>");
                sb.Append("<td>:");
                sb.Append(_dt1.Rows[m]["Sno"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Emp. Cd:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + _dt1.Rows[m]["Emp_Code"].ToString() + " </td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>Name</td>");
                sb.Append("<td>:");
                sb.Append(_dt1.Rows[m]["Name"].ToString() + " </td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>F/H</td>");
                sb.Append("<td>:");
                sb.Append(_dt1.Rows[m]["FatherName"].ToString() + " </td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>PF N</td>");
                sb.Append("<td>:");
                sb.Append(_dt1.Rows[m]["PF"].ToString() + " </td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>ESI</td>");
                sb.Append("<td>:");
                sb.Append(_dt1.Rows[m]["ESI"].ToString() + " </td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>DOJ</td>");
                sb.Append("<td>:");
                sb.Append(_dt1.Rows[m]["DOJ"].ToString() + " </td>");
                sb.Append("</tr>");
                sb.Append("</table></td>");
                //-------------------------
                _dt.DefaultView.RowFilter = "Emp_Code=" + _dt1.Rows[m]["Emp_Code"].ToString();
                DataTable dtFil = _dt.DefaultView.ToTable();
                for (int n = 0; n < dtFil.Rows.Count; n++)
                {
                    sb.Append("<td><table width='100%'>");

                    if (Convert.ToInt32(dtFil.Rows[n]["PresentDay"].ToString()) > 0)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>WD</td>");
                        sb.Append("<td>:</td>");
                        sb.Append("<td>" + dtFil.Rows[n]["PresentDay"].ToString() + "</td>");
                        sb.Append("</tr>");
                    }
                    if (Convert.ToInt32(dtFil.Rows[n]["Weekoff"].ToString()) > 0)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>WO</td>");
                        sb.Append("<td>:</td>");
                        sb.Append("<td>" + dtFil.Rows[n]["Weekoff"].ToString() + "</td>");
                        sb.Append("</tr>");
                    }
                    if (Convert.ToInt32(dtFil.Rows[n]["AbsentDay"].ToString()) > 0)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>WP</td>");
                        sb.Append("<td>:</td>");
                        sb.Append("<td>" + dtFil.Rows[n]["AbsentDay"].ToString() + "</td>");
                        sb.Append("</tr>");
                    }
                    if (Convert.ToInt32(dtFil.Rows[n]["PaidDay"].ToString()) > 0)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>PD</td>");
                        sb.Append("<td>:</td>");
                        sb.Append("<td>" + dtFil.Rows[n]["PaidDay"].ToString() + "</td>");
                        sb.Append("</tr>");
                    }
                    if (Convert.ToInt32(dtFil.Rows[n]["EL"].ToString()) > 0)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>EL</td>");
                        sb.Append("<td>:</td>");
                        sb.Append("<td>" + dtFil.Rows[n]["EL"].ToString() + "</td>");
                        sb.Append("</tr>");
                    }
                    if (Convert.ToInt32(dtFil.Rows[n]["CL"].ToString()) > 0)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>CL</td>");
                        sb.Append("<td>:</td>");
                        sb.Append("<td>" + dtFil.Rows[n]["CL"].ToString() + "</td>");
                        sb.Append("</tr>");
                    }
                    if (Convert.ToInt32(dtFil.Rows[n]["SL"].ToString()) > 0)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>SL</td>");
                        sb.Append("<td>:</td>");
                        sb.Append("<td>" + dtFil.Rows[n]["SL"].ToString() + "</td>");
                        sb.Append("</tr>");
                    }
                    if (Convert.ToInt32(dtFil.Rows[n]["L1"].ToString()) > 0)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>L1</td>");
                        sb.Append("<td>:</td>");
                        sb.Append("<td>" + dtFil.Rows[n]["L1"].ToString() + "</td>");
                        sb.Append("</tr>");
                    }
                    if (Convert.ToInt32(dtFil.Rows[n]["L2"].ToString()) > 0)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>L2</td>");
                        sb.Append("<td>:</td>");
                        sb.Append("<td>" + dtFil.Rows[n]["L2"].ToString() + "</td>");
                        sb.Append("</tr>");

                    }
                    if (Convert.ToInt32(dtFil.Rows[n]["L3"].ToString()) > 0)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>L3</td>");
                        sb.Append("<td>:</td>");
                        sb.Append("<td>" + dtFil.Rows[n]["L3"].ToString() + "</td>");
                        sb.Append("</tr>");
                    }
                    if (Convert.ToInt32(dtFil.Rows[n]["Maternity"].ToString()) > 0)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>Maternity</td>");
                        sb.Append("<td>:</td>");
                        sb.Append("<td>" + dtFil.Rows[n]["Maternity"].ToString() + "</td>");
                        sb.Append("</tr>");
                    }

                    sb.Append("</table></td>");
                    PaidDay = Convert.ToInt32(dtFil.Rows[n]["PaidDay"].ToString());
                    TotalDay = Convert.ToInt32(dtFil.Rows[n]["TotalDay"].ToString());
                }

                //-----------------------------
                _dt2.DefaultView.RowFilter = "EmployeeId=" + _dt1.Rows[m]["Emp_Code"].ToString();
                DataTable dtFil1 = _dt2.DefaultView.ToTable();

                sb.Append("<td colspan='4'><table width='100%'>");
                for (int j = 0; j < dtFil1.Rows.Count; j++)
                {

                    sb.Append("<tr>");
                    sb.Append("<td>" + dtFil1.Rows[j]["AllwancesName"].ToString() + "</td>");
                    sb.Append("<td>:</td>");

                    sb.Append("<td>" + dtFil1.Rows[j]["FixedAllwancesAmt"].ToString() + "</td>");

                    sb.Append("<td>" + dtFil1.Rows[j]["AllwancesAmt"].ToString() + "</td>");
                    sb.Append("<td>0.00</td>");
                    sb.Append("</tr>");
                    //if (dtFil1.Rows[j]["Allowances"].ToString() == "Gross basic Pay")
                    //{
                    //    EmpEarGrossPay = Convert.ToDecimal(EarningPay.ToString("F"));
                    //}

                    TotalGrosPay = TotalGrosPay + Convert.ToDecimal(dtFil1.Rows[j]["FixedAllwancesAmt"].ToString().Replace("000", "00"));


                    TotalEarningPay = TotalEarningPay + Convert.ToDecimal(dtFil1.Rows[j]["AllwancesAmt"].ToString().Replace("000", "00"));


                }
                sb.Append("<tr>");
                sb.Append("<td>*Total*</td>");
                sb.Append("<td>:</td>");
                sb.Append("<td>" + TotalGrosPay.ToString("F") + "</td>");
                sb.Append("<td>" + TotalEarningPay.ToString("F") + "</td>");
                sb.Append("<td>0.00</td>");
                sb.Append("</tr>");
                sb.Append("</table></td>");
                //-------------------------------------------
                _dt3.DefaultView.RowFilter = "EmployeeId=" + _dt1.Rows[m]["Emp_Code"].ToString();
                DataTable dtFil2 = _dt3.DefaultView.ToTable();
                sb.Append("<td  colspan='2'><table width='100%'>");
                for (int k = 0; k < dtFil2.Rows.Count; k++)
                {
                    if (dtFil2.Rows[k]["DeductionName"].ToString() != "")
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>" + dtFil2.Rows[k]["DeductionName"].ToString() + "</td>");
                        sb.Append("<td>:</td>");
                        sb.Append("<td>" + dtFil2.Rows[k]["DeductionAmt"].ToString() + "</td>");
                        sb.Append("</tr>");

                        TotalDeduction = TotalDeduction + Convert.ToDecimal(dtFil2.Rows[k]["DeductionAmt"].ToString());

                    }
                }
                sb.Append("<tr>");
                sb.Append("<td>*Total*</td>");
                sb.Append("<td>:</td>");
                sb.Append("<td>" + TotalDeduction.ToString("F") + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                NetPayment = TotalEarningPay - TotalDeduction;
                sb.Append("<td>*NET PAY*</td>");
                sb.Append("<td>:</td>");
                sb.Append("<td>" + NetPayment.ToString("F") + "</td>");
                sb.Append("</tr>");
                sb.Append("</table></td>");
                sb.Append("<td>__________</td>");
                sb.Append("</tr>");
                sb.Append("<tr><td colspan='9'><hr></td></tr>");

            }

        }
        else
        {
            sb.Append("<tr><td colspan='9'>There is no record...........</td></tr>");
        }
            sb.Append("</table></td></tr>");
        
        sb.Append("</table>");
        return sb.ToString();

    }
   
    public DataTable GetFinYear(string sdate)
    {
        string finyear = "";
        DateTime s = Convert.ToDateTime(sdate);

        int m = s.Month;
        int y = s.Year;
        if (m > 3)
        {
            finyear = y.ToString() + "-" + Convert.ToString((y + 1));
        }
        else
        {
            finyear = Convert.ToString((y - 1)) + "-" + y.ToString();
        }
        //return finyear;
        DataTable dt = new DataTable();
        dt.Columns.Add("val");
        dt.Columns.Add("txt");
        DataRow dr = dt.NewRow();

        dr["val"] = finyear;
        dr["txt"] = finyear;
        dt.Rows.Add(dr);
        return dt;
    }
    
    private void BindFinyear()
    {
        ddlFinYear.DataSource = GetFinYear(DateTime.Now.ToString());
        ddlFinYear.DataTextField = GetFinYear(DateTime.Now.ToString()).Columns["txt"].ToString();
        ddlFinYear.DataValueField = GetFinYear(DateTime.Now.ToString()).Columns["val"].ToString();
        ddlFinYear.DataBind();
        //ddlFinYear.Items.Insert(0, "Select");

    }
    #endregion Page Specific Event
    
}