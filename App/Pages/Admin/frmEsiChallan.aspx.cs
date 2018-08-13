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

public partial class Pages_Admin_frmEsiChallan : System.Web.UI.Page
{
    #region Global Variable Declaration
    ReportMasterManager _objReportMasterManager = new ReportMasterManager();
    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindFinyear();
        }

    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMonth.SelectedIndex > 0)
        {
            try
            {
                if (CheckData())
                {
                    DataSet ds = _objReportMasterManager.GetEsiChallan(Convert.ToInt32(ddlFinYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));
                    // litReport.Text = PaymentWages(ds);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        btnPrint.Enabled = true;
                        litReport.Text = Challan(ds, txtBankName.Text, txtDate.Text, txtChequeNo.Text);
                    }
                    else
                    {
                        litReport.Text = "";
                        btnPrint.Enabled = false;
                        lblMsg.Text = "There is No Record For This Month";
                        ddlMonth.Focus();
                    }
                }
                else
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = "Input data is not in correct format.....";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Sorry : " + ex.Message.ToString();
            }
        }
        else
        {
            litReport.Text = "";
            btnPrint.Enabled = false;
            lblMsg.Text = "Please Select Month";
            ddlMonth.Focus();
        }
    }
    #endregion Page Event

    #region Page Specific Event
    private string Challan(DataSet ds, string BankName, string Date, string ChequeNo)
    {
        StringBuilder sb = new StringBuilder();
        try
        {
            DataTable _dt = ds.Tables[0];
            DataTable _dt1 = ds.Tables[1];

            sb.Append("<table width='100%'  align='center' cellpadding='0' cellspacing='0' style='border:1px solid #000000;font-size:14px; padding-left:10px; padding-right:10px; padding-bottom:10px;'>");



            if (_dt.Rows[0][0].ToString() != "0")
            {
                #region Calcaultaion

                double TotalAmt = 0;
                //double TotalAmt = 0;

                for (int q = 0; q < _dt1.Rows.Count; q++)
                {
                    if (Convert.ToString(_dt1.Rows[q]["AllwancesName"].ToString()) != "")
                    {
                        if (Convert.ToDouble(_dt1.Rows[q]["AllwancesAmt"].ToString()) > 0)
                        {
                            TotalAmt = TotalAmt + Convert.ToDouble(_dt1.Rows[q]["AllwancesAmt"].ToString());
                        }
                    }
                }

                double TotalEmpShareAmt = 0;
                TotalEmpShareAmt = Math.Round(Convert.ToDouble(TotalAmt) * Convert.ToDouble(1.75) / 100);

                double TotalEmplrShareAmt = 0;
                TotalEmplrShareAmt = Math.Round(Convert.ToDouble(TotalAmt) * Convert.ToDouble(4.75) / 100);
                double TotalEsiAmt = 0;
                TotalEsiAmt = TotalEmpShareAmt + TotalEmplrShareAmt;
                ConvertMasterManager objConvertMasterManager = new ConvertMasterManager();
                string InWordToEsi = objConvertMasterManager.changeNumericToWords(Convert.ToDouble(TotalEsiAmt));
                #endregion Calcaultaion
                //                sb.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border:1px solid #000; padding-left:10px; padding-right:10px;'>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='top'>");
                sb.Append("<table>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='top' style='font-size:13px;'>ORIGINAL<br />DUPLICATE<br />TRIPPLICATE<br />QUARDUPLICATE");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</table>");

                sb.Append("</td>");
                sb.Append("<td align='left' valign='top'>");
                sb.Append("<table>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='top' style='font-size:24px; font-weight:bold; padding-left:85px;'>E.S.I.C");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='top' style='font-size:16px; font-weight:bold;'>");
                sb.Append("<table>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='top'>");
                sb.Append("<div>Challan No.</div>");
                sb.Append("</td>");
                sb.Append("<td align='left' valign='top'><div style='border:1px solid #000; width:150px; height:20px;'></div>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</table>");
                sb.Append("</td>");

                sb.Append("</tr>");
                sb.Append("</table>");
                sb.Append("</td>");
                sb.Append("</tr>");


                sb.Append("<tr>");
                sb.Append("<td align='center' valign='top' colspan='2' style=' font-size:14px;'><b>EMPLOYEE'S STATE INSURANCE FUND ACCOUNT NO. -1)<br />PAY-IN SLIP FOR CONTRIBUTIONN<br />STATE OF BANK OF INDIA</b>");
                sb.Append("</td>");

                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='top'>Station &nbsp; ........................................</td>");
                sb.Append("<td align='right' valign='top'>Dated &nbsp;" + txtDate.Text + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='top' height='10'></td>");
                sb.Append("<td align='right' valign='top' height='10'></td>");
                sb.Append("</tr>");

                sb.Append("<tr>");
                sb.Append("<td align='left' valign='top'>");
                sb.Append("<table style=' background-color:black;' cellpadding='1' cellspacing='1' height='100'>");
                sb.Append("<tr>");
                sb.Append("<td align='center' style=' background-color:#ffffff;' valign='top'>Particulars of cash/cheque No.");
                sb.Append("</td>");
                sb.Append("<td align='center' valign='top' style=' background-color:#ffffff;'>Amount Rs.P.");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='center' valign='middel' style=' background-color:#ffffff;'>Total");
                sb.Append("</td>");
                sb.Append("<td align='center' valign='middle' style=' background-color:#ffffff;'><b> " + TotalEsiAmt.ToString("F") + "</b><div style='border-top:1px solid #000;'><b>" + TotalEsiAmt.ToString("F") + "</b></div>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</table>");

                sb.Append("</td>");
                sb.Append("<td align='left' valign='top'>");
                sb.Append("<table>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='top'>Paid into credit of the Employee's State insurance Fund Account No. 1<br /><b style='border-bottom:1px dotted #000;'>Rs. " + TotalEsiAmt.ToString("F") + "</b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (in figures)<br /><div style='border-bottom:1px dotted #000;'><i>" + InWordToEsi + "</i> (in words)</div>in cash/by Cheque (on realistion) of contribution as per details given below under the");
                sb.Append("</td>");
                sb.Append("<td align='left' valign='top'></td>");
                sb.Append("</tr>");
                sb.Append("</table>");

                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top'>E.S.I Act, 1948 for the month of");
                sb.Append("</td>");
                sb.Append("<td align='left' valign='top' style='border-bottom:1px dotted #000;'><b>" + ddlMonth.SelectedItem.Text + "," + ddlFinYear.SelectedItem.Text + "</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top'>Employer's Code No.");
                sb.Append("</td>");
                sb.Append("<td align='left' valign='top' style='border-bottom:1px dotted #000;' >");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='top'>Deposited By");
                sb.Append("</td>");
                sb.Append("<td align='left' valign='top' style='border-bottom:1px dotted #000;'>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top'>Name and Address of Factory/ Establishment");
                sb.Append("</td>");
                sb.Append("<td align='left' valign='top' style='border-bottom:1px dotted #000;'><b>" + txtOrgName.Text + "<br>" + txtAddress.Text + "</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top'>No of Employees");
                sb.Append("</td>");
                sb.Append("<td align='left' valign='top' style='border-bottom:1px dotted #000;'><b>" + Convert.ToString(_dt.Rows[0]["CntEmployee"].ToString()) + "</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top'>Total Wages");
                sb.Append("</td>");
                sb.Append("<td align='left' valign='top' style='border-bottom:1px dotted #000;' ><b>" + TotalAmt.ToString("F") + "</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top'>Employee's Contribution Rs.");
                sb.Append("</td>");
                sb.Append("<td align='left' valign='top' style='border-bottom:1px dotted #000;'><b>" + TotalEmpShareAmt.ToString("F") + "</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top'>Employer's Contribution Rs.");
                sb.Append("</td>");
                sb.Append("<td align='left' valign='top' style='border-bottom:1px dotted #000;'><b>" + TotalEmplrShareAmt.ToString("F") + "</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top'>Total Rs.");
                sb.Append("</td>");
                sb.Append("<td align='left' valign='top' style='border-bottom:1px dotted #000;'><b>" + TotalEsiAmt.ToString("F") + "</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top' colspan='2' style='border-bottom:1px solid #000; padding-bottom:20px;'>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top'>(For use in Bank)");
                sb.Append("</td>");
                sb.Append("<td align='left' valign='top'><b> ( ACKNOWLEDGEMENT )</b>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='top' height='10'></td>");
                sb.Append("<td align='right' valign='top' height='10'></td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top'>Recieved payment with Cash/ Cheque / Draf No.");
                sb.Append("</td>");
                sb.Append("<td align='left' valign='top' style='border-bottom:1px dotted #000;'><b> " + txtChequeNo.Text + "</b></td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top'>");

                sb.Append("<table>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='bottom'>Dated</td>");
                sb.Append("<td align='left' valign='top' style='border-bottom:1px dotted #000; margin-left:50px;'>" + txtDate.Text + "");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</table>");
                sb.Append("</td>");
                sb.Append("<td align='left' valign='top'  >");

                sb.Append("<table>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='bottom'>for Rs.</td>");
                sb.Append("<td align='left' valign='top' style='border-bottom:1px dotted #000; margin-left:50px;'>" + TotalEsiAmt.ToString("F") + "");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</table>");

                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='left' colspan='2' valign='top' style='border-bottom:1px dotted #000;' ><i>" + InWordToEsi + "</i>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top'  colspan='2' ><table width='100%'>");
                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top' width='80%' >");



                sb.Append("<table>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='bottom'>Draw on </td>");
                sb.Append("<td align='left' valign='top' style='border-bottom:1px dotted #000; margin-left:50px;'>" + txtBankName.Text + "");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</table>");
                sb.Append("</td>");
                sb.Append("<td align='right' valign='middle' width='20%'>(Bank in favour of)");
                sb.Append("</td>");

                sb.Append("</tr>");
                sb.Append("</table>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top'>Employee's State Insurance Fund Account No.1");
                sb.Append("</td>");
                sb.Append("<td align='left' valign='top' style='border-bottom:1px dotted #000;'>");


                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top'>SL. No in Bank's Scroll");
                sb.Append("</td>");
                sb.Append("<td align='left' valign='top' style='border-bottom:1px dotted #000;'>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td align='left' valign='top' height='20'></td>");
                sb.Append("<td align='right' valign='top' height='20'></td>");
                sb.Append("</tr>");
                sb.Append("<tr >");
                sb.Append("<td align='left' valign='top'><b> Dated :</b>" + txtDate.Text + "");
                sb.Append("</td>");
                sb.Append("<td align='right' valign='top'>Aouthorised Signatory of the receiving Bank");

                sb.Append("</td>");
                sb.Append("</tr>");



                //sb.Append("</table>");



            }
            else
            {
                sb.Append("<tr><td colspan='3'><b>There is no record....</b></td></tr>");
            }

            sb.Append("</table>");
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
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
        string[] str = finyear.Split('-');
        DataTable dt = new DataTable();
        dt.Columns.Add("val");
        dt.Columns.Add("txt");
        DataRow dr = dt.NewRow();
        DataRow dr1 = dt.NewRow();


        dr["val"] = str[0];
        dr["txt"] = str[0];

        dr1["val"] = str[1];
        dr1["txt"] = str[1];
        dt.Rows.Add(dr);
        dt.Rows.Add(dr1);

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
    private bool CheckData()
    {
        bool Flag = true;
        if (txtBankName.Text == "")
        {
            txtBankName.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtBankName.BorderColor = Color.Black;
        }
        if (txtChequeNo.Text == "")
        {
            txtChequeNo.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtChequeNo.BorderColor = Color.Black;
        }
        if (txtDate.Text == "")
        {
            txtDate.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtDate.BorderColor = Color.Black;
        }
        return Flag;
    }
    #endregion Page Specific Event

}