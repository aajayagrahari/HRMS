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

public partial class Pages_Admin_frmChallan : System.Web.UI.Page
{
    #region Global Variable Declaration
    ReportMasterManager _objReportMasterManager=new ReportMasterManager();
    ConvertMasterManager _objConvertMasterManager = new ConvertMasterManager();
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
                lblMsg.Text = "";
                if (CheckData())
                {
                    DataSet ds = _objReportMasterManager.GetChallan(Convert.ToInt32(ddlFinYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));
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
    private string Challan(DataSet ds,string BankName,string Date,string ChequeNo)
    {
        StringBuilder sb = new StringBuilder();
        try
        {
            DataTable _dt = ds.Tables[0];
            DataTable _dt1 = ds.Tables[1];
          
            sb.Append("<table width='97%'  align='center' cellpadding='0' cellspacing='0' style='border:1px solid #000000;font-size:14px;'>");
            string strStartFont1 = "<b><font size='2'>";
            string strEndFont1 = "</b></font>";

            string strStartFont2 = "<font size='1'>";
            string strEndFont2 = "</font>";

            if (_dt.Rows[0][0].ToString() != "0")
            {
                #region Calcaultaion

                double Account1 = 0;
                double Account10 = 0;
                double Account21 = 0;

                double AccountSN1AC1 = 0;
                double AccountSN1AC10 = 0;
                double AccountSN1AC21 = 0;
                double sn1Total = 0;


                double AccountSN2AC1 = 0;
                double sn2Total = 0;


                double AccountSN3AC2 = 0;
                double AccountSN3AC22 = 0;
                double sn3Total = 0;

                double FRTotal = 0;
                double FCTotal = 0;

                double AC1Total = 0;
                double AC2Total = 0;
                double AC10Total = 0;
                double AC21Total = 0;
                double AC22Total = 0;

                

                for (int q = 0; q < _dt1.Rows.Count; q++)
                {
                    if (Convert.ToDecimal(_dt1.Rows[q]["AllwancesAmt"].ToString()) > 0)
                    {
                        if (Convert.ToDecimal(_dt1.Rows[q]["AllwancesAmt"]) <= 6500)
                        {
                            Account1 = Account1 + Convert.ToDouble(_dt1.Rows[q]["AllwancesAmt"].ToString());
                            Account10 = Account10 + Convert.ToDouble(_dt1.Rows[q]["AllwancesAmt"].ToString());
                            Account21 = Account21 + Convert.ToDouble(_dt1.Rows[q]["AllwancesAmt"].ToString());
                        }
                        else if (Convert.ToDecimal(_dt1.Rows[q]["AllwancesAmt"]) > 6500)
                        {
                            if (Convert.ToDecimal(_dt1.Rows[q]["DedAmount"]) == 780)
                            {
                                Account1 = Account1 + Convert.ToDouble(6500);
                            }
                            else
                            {
                                Account1 = Account1 + Convert.ToDouble(_dt1.Rows[q]["AllwancesAmt"].ToString());
                            }
                            Account10 = Account10 + Convert.ToDouble(6500);
                            Account21 = Account21 + Convert.ToDouble(6500);
                        }
                    }
                }

                Int32 AccountSN1AC1int;
                AccountSN1AC1 = Convert.ToDouble(Account1) * Convert.ToDouble(3.67) / 100;
               
              
               

                AccountSN1AC1int = Convert.ToInt32(Math.Round(AccountSN1AC1));


                Int32 AccountSN1AC10int;
                AccountSN1AC10 = Account10 * Convert.ToDouble(8.33) / 100;
                
                AccountSN1AC10int = Convert.ToInt32(Math.Round(AccountSN1AC10));


                Int32 AccountSN1AC21int;
                AccountSN1AC21 = Account10 * Convert.ToDouble(0.50) / 100;
               
                AccountSN1AC21int = Convert.ToInt32(Math.Round(AccountSN1AC21));

                Int32 sn1Totalint;
                sn1Total = AccountSN1AC1 + AccountSN1AC10 + AccountSN1AC21;
               
                sn1Totalint = Convert.ToInt32(Math.Round(sn1Total));

                Int32 AccountSN2AC1int;
                AccountSN2AC1 = Account1 * Convert.ToDouble(12.00) / 100;
               


                AccountSN2AC1int = Convert.ToInt32(Math.Round(AccountSN2AC1));

                AccountSN2AC1int = AccountSN2AC1int - AccountSN1AC10int;
                Int32 sn2Totalint;
                sn2Total = AccountSN2AC1;
                
                sn2Totalint = Convert.ToInt32(Math.Round(sn2Total));
                
                Int32 AccountSN3AC2int;
                AccountSN3AC2 = Account1 * Convert.ToDouble(1.10) / 100;
                
                AccountSN3AC2int = Convert.ToInt32(Math.Round(AccountSN3AC2));



                Int32 AccountSN3AC22int;
                AccountSN3AC22 = Account10 * Convert.ToDouble(0.01) / 100;
               
                AccountSN3AC22int = Convert.ToInt32(Math.Round(AccountSN3AC22));

                if (AccountSN3AC22int < 2)
                {
                    AccountSN3AC22int = 2;
                }

                Int32 sn3Totalint;
                //sn3Total = AccountSN3AC2 + AccountSN3AC22; // By Shruti
                sn3Total = AccountSN3AC2 + AccountSN3AC22int;
               
                sn3Totalint = Convert.ToInt32(Math.Round(sn3Total));



                //Int32 AC1Totalint = AccountSN1AC1int + AccountSN2AC1int;
                Int32 AC1Totalint = AccountSN1AC1int + Convert.ToInt32(Math.Round(AccountSN2AC1));
                Int32 AC2Totalint = AccountSN3AC2int;
                Int32 AC10Totalint = AccountSN1AC10int;
                Int32 AC21Totalint = AccountSN1AC21int;
                Int32 AC22Totalint = AccountSN3AC22int;
              

                Int32 FCTotalint = sn1Totalint + sn2Totalint + sn3Totalint;
                Int32 FRTotalint = AC1Totalint + AC2Totalint + AC10Totalint + AC21Totalint + AC22Totalint;
                #endregion Calcaultaion
                sb.Append("<tr>");
                sb.Append("<td><img src='../../Images/logo.jpg' width='70' height='70' /></td>");
                sb.Append("<td colapan='2' valign='top' align='left'>");
                sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
               
                sb.Append(strStartFont2 + "COMBINED CHALLAN oF A/C NO.1,2,10,21 & 22(STATE BANK OF INDIA)" + strEndFont2);
                sb.Append("<br>" + strStartFont1 + "EMPLOYEE PROVIDENT FUND ORGANIZATION" + strEndFont1);
                sb.Append(strStartFont2 + "(USE SEPRATE CHALLAN FOR EACH MONTH)" + strEndFont2 + "</td>");
                
                sb.Append("<td align='right'>" + strStartFont2 + "ORIGINAL<br>DUPLICATE<br>TRIPLICATE<br>QUARDUPLICATE" + strEndFont2 + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr><td colspan='3'><hr></td></tr>");
                sb.Append("<tr><td colspan='3'><table width='100%'>");
                sb.Append("<tr>");
                sb.Append("<td width='17%'>" + strStartFont2 + "ESTABLISHMENT CODE NO." + strEndFont2 + "</td>");
                sb.Append("<td width='2%'>:</td>");
                sb.Append("<td width='10%'>" + strStartFont2 + "DSSHD0938826" + strEndFont2 + "</td>");
                sb.Append("<td  width='9%' colspan='2'>" + strStartFont2 + "ACCOUNT GROUP NO." + strEndFont2 + "&nbsp;&nbsp;&nbsp;......................................</td>");
                sb.Append("<td align='left' width='1%'>&nbsp;</td>");

                sb.Append("<td width='22%'>" + strStartFont2 + "PAID BY CHEQUE CASH" + '/' + " CASH" + strEndFont2 + "&nbsp;&nbsp;&nbsp;.........................</td>");
                sb.Append("</tr>");
                sb.Append("<tr><td colspan='6'><br></td></tr>");
                sb.Append("<tr>");
                sb.Append("<td width='17%'>" + strStartFont2 + "DUES FOR THE MONTH OF" + strEndFont2 + "</td>");
                sb.Append("<td width='2%'>:</td>");
                sb.Append("<td width='15%' colspan='2'>" + strStartFont2 + "EMPLOYEE SHARE &nbsp;&nbsp;<b>"+ddlMonth.SelectedValue.ToString()+ "/" +ddlFinYear.SelectedValue.ToString()+"</b><BR>EMPLOYER SHARE &nbsp;&nbsp;<b>"+ddlMonth.SelectedValue.ToString()+ "/" +ddlFinYear.SelectedValue.ToString()+"</b>"+ strEndFont2 + "</td>");
                sb.Append("<td  width='4%'></td>");
                sb.Append("<td width='1%'></td>");

                sb.Append("<td width='22%'>" + strStartFont2 + "DATE OF PAYMENT" + strEndFont2 + "&nbsp;&nbsp;&nbsp;...........................................</td>");
                sb.Append("</tr>");
                sb.Append("<tr><td colspan='6'><br></td></tr>");
                sb.Append("<tr>");
                sb.Append("<td width='17%'>" + strStartFont2 + "TOTAL NO. OF SUBSCRIBERS<br>TORAL WAGES DUE" + strEndFont2 + "</td>");
                sb.Append("<td width='4%'>" + strStartFont2 + " A/c 1" + strEndFont2 + "</td>");
                sb.Append("<td width='15%' align='right' style='border-left:1px solid #000000;border-RIGHT:1px solid #000000;'>" + strStartFont2 + _dt.Rows[0][0].ToString() + "<BR>" + Account1 + "" + strEndFont2 + "</td>");
                sb.Append("<td  width='4%' align='center'>" + strStartFont2 + "A/c 10" + strEndFont2 + "</td>");
                sb.Append("<td width='15%' align='right' style='border-left:1px solid #000000;border-RIGHT:1px solid #000000;'>" + strStartFont2 + _dt.Rows[0][0].ToString() + "<BR>" + Account10 + "" + strEndFont2 + "</td>");

                sb.Append("<td width='4%' align='center'>" + strStartFont2 + "A/c 21" + strEndFont2 + "</td>");
                sb.Append("<td width='15%' align='right' style='border-left:1px solid #000000;border-RIGHT:1px solid #000000;'>" + strStartFont2 + _dt.Rows[0][0].ToString() + "<BR>" + Account21 + "" + strEndFont2 + "</td>");
                sb.Append("</tr>");
                sb.Append("</table></td></tr>");
                sb.Append("<tr><td colspan='3'><b><hr></b></td></tr>");
                sb.Append("<tr><td colspan='3'><table width='100%'>");
                sb.Append("<tr>");
                sb.Append("<td  style='border-bottom:1px solid #000000;'><b>" + strStartFont2 + "S.NO." + strEndFont2 + "</b></td>");
                sb.Append("<td style='border-bottom:1px solid #000000;'><b>" + strStartFont2 + "PARTICULARS" + strEndFont2 + "</b></td>");
                sb.Append("<td style='border-bottom:1px solid #000000;'><b>" + strStartFont2 + "A/c. No.1" + strEndFont2 + "</b></td>");
                sb.Append("<td style='border-bottom:1px solid #000000;'><b>" + strStartFont2 + "A/c. No.2" + strEndFont2 + "</b></td>");
                sb.Append("<td style='border-bottom:1px solid #000000;'><b>" + strStartFont2 + "A/c. No.10" + strEndFont2 + "</b></td>");
                sb.Append("<td style='border-bottom:1px solid #000000;'><b>" + strStartFont2 + "A/c. No.21" + strEndFont2 + "</b></td>");
                sb.Append("<td style='border-bottom:1px solid #000000;'><b>" + strStartFont2 + "A/c. No.22" + strEndFont2 + "</b></td>");
                sb.Append("<td style='border-bottom:1px solid #000000;'><b>" + strStartFont2 + "TOTAL" + strEndFont2 + "</b></td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>" + strStartFont2 + "1</td>" + strEndFont2 + "");
                sb.Append("<td>" + strStartFont2 + "EMPLOYER'S SHARE OF CONT." + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "" + AccountSN1AC1int + "" + strEndFont2 + "</td>");
                sb.Append("<td></td>");
                sb.Append("<td>" + strStartFont2 + "" + AccountSN1AC10int + "" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "" + AccountSN1AC21int + "" + strEndFont2 + "</td>");
                sb.Append("<td></td>");
                sb.Append("<td>" + strStartFont2 + "" + sn1Totalint + "" + strEndFont2 + "</td>");
                sb.Append("</tr>");
                // sb.Append("<tr><td colspan='8'><b><br></b></td></tr>");
                sb.Append("<tr>");
                sb.Append("<td>" + strStartFont2 + "2" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "EMPLOYEE SHARE OF CONT." + strEndFont2 + "</td>");
                //sb.Append("<td>" + strStartFont2 + "" + AccountSN2AC1int + "" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "" + AccountSN2AC1 + "" + strEndFont2 + "</td>");
                sb.Append("<td></td>");
                sb.Append("<td>" + strStartFont2 + "0.00" + strEndFont2 + "</td>");
                sb.Append("<td></td>");
                sb.Append("<td></td>");
                sb.Append("<td>" + strStartFont2 + "" + sn2Totalint + "" + strEndFont2 + "</td>");
                sb.Append("</tr>");
                // sb.Append("<tr><td colspan='8'><b><br></b></td></tr>");
                sb.Append("<tr>");
                sb.Append("<td>" + strStartFont2 + "3" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "ADMN. CHARGES" + strEndFont2 + "</td>");
                sb.Append("<td></td>");
                sb.Append("<td>" + strStartFont2 + "" + AccountSN3AC2int + "" + strEndFont2 + "</td>");
                sb.Append("<td></td>");
                sb.Append("<td></td>");
                sb.Append("<td>" + strStartFont2 + "" + AccountSN3AC22int + "" + strEndFont2 + "</td>");
                //sb.Append("<td>" + strStartFont2 + "" + sn3Totalint + "" + strEndFont2 + "</td>");//By Shruti
                sb.Append("<td>" + strStartFont2 + "" + sn3Totalint + "" + strEndFont2 + "</td>");
                sb.Append("</tr>");
                //sb.Append("<tr><td colspan='8'><b><br></b></td></tr>");
                sb.Append("<tr>");
                sb.Append("<td>" + strStartFont2 + "4" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "INPECTION CHARGES" + strEndFont2 + "</td>");
                sb.Append("<td></td>");
                sb.Append("<td>" + strStartFont2 + "0.00" + strEndFont2 + "</td>");
                sb.Append("<td></td>");
                sb.Append("<td></td>");
                sb.Append("<td></td>");
                sb.Append("<td>" + strStartFont2 + "0.00" + strEndFont2 + "</td>");
                sb.Append("</tr>");
                // sb.Append("<tr><td colspan='8'><b><br></b></td></tr>");
                sb.Append("<tr>");
                sb.Append("<td>" + strStartFont2 + "5" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "PENAL DAMAGES" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "0.00" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "0.00" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "0.00" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "0.00" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "0.00" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "0.00" + strEndFont2 + "</td>");
                sb.Append("</tr>");
                //sb.Append("<tr><td colspan='8'><b><br></b></td></tr>");
                sb.Append("<tr>");
                sb.Append("<td>" + strStartFont2 + "6" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "MISC. PAYMENTS(Past <br>Accumulation only)" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "0.00" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "0.00" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "0.00" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "0.00" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "0.00" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "0.00" + strEndFont2 + "</td>");
                sb.Append("</tr>");
                // sb.Append("<tr><td colspan='8'><b><br></b></td></tr>");
                sb.Append("<tr>");
                sb.Append("<td></td>");
                sb.Append("<td align='center'>" + strStartFont2 + "TOTAL</td>");
                sb.Append("<td>" + strStartFont2 + "" + AC1Totalint + "" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "" + AC2Totalint + "" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "" + AC10Totalint + "" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "" + AC21Totalint + "" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "" + AC22Totalint + "" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + "" + FCTotalint + "" + strEndFont2 + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr><td colspan='8'><b><br></b></td></tr>");
                sb.Append("<tr><td colspan='8' align='center'>" + strStartFont2 + "(AMOUNT IN WORDS)____<b>" + _objConvertMasterManager.changeNumericToWords(FCTotalint) + strEndFont2 + "</b></td></tr>");
                sb.Append("</table></td></tr>");
                sb.Append("<tr><td colspan='3'><hr></td></tr>");
                sb.Append("<tr><td colspan='3'><table width='100%'>");
                sb.Append("<tr>");
                sb.Append("<td style='border-right:1px solid #000000;'><table width='100%'>");
                sb.Append("<tr>");
                sb.Append("<td>" + strStartFont2 + "NAME OF ESTABLISHMENT" + strEndFont2 + "</td>");
                sb.Append("<td><b>" + strStartFont2 + txtOrgName.Text + strEndFont2 + "</b></td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>" + strStartFont2 + "ADDRESS" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + txtAddress.Text + strEndFont2 + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>" + strStartFont2 + "NAME OF DEPOSITOR" + strEndFont2 + "</td>");
                sb.Append("<td>.....................................................</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>" + strStartFont2 + "SIGNATURE OF DEPOSITOR" + strEndFont2 + "</td>");
                sb.Append("<td>.....................................................</td>");
                sb.Append("</tr>");
                sb.Append("</table></td>");
                sb.Append("<td><table width='100%'>");
                sb.Append("<tr>");
                sb.Append("<td colspan='2'><b>" + strStartFont2 + "(FOR BANK USE ONLY)" + strEndFont2 + "</b></td>");

                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>" + strStartFont2 + "AMOUNT RECEIVED:RS" + strEndFont2 + "</td>");
                sb.Append("<td>..................................</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td colspan='2'>" + strStartFont2 + "FOR CHEQUE ONLY" + strEndFont2 + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>" + strStartFont2 + "DATE OF PRESENTATION</td>");
                sb.Append("<td>..................................</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>" + strStartFont2 + "DATE OF REALISATION" + strEndFont2 + "</td>");
                sb.Append("<td>..................................</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>" + strStartFont2 + "BRANCH NAME" + strEndFont2 + "</td>");
                sb.Append("<td>..................................</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>" + strStartFont2 + "BRANCH CODE NO." + strEndFont2 + "</td>");
                sb.Append("<td>..................................</td>");
                sb.Append("</tr>");
                sb.Append("</table></td>");
                sb.Append("</tr>");
                sb.Append("</table></td></tr>");
                sb.Append("<tr><td colspan='3'><b><hr></b></td></tr>");
                sb.Append("<tr><td colspan='3' align='center'><b>" + strStartFont2 + "(TO BE FILLED IN BY EMPLOYEE)" + strEndFont2 + "</b></td></tr>");
                sb.Append("<tr><td colspan='3'><table width='100%'>");
                sb.Append("<tr>");
                sb.Append("<td width='20%'>" + strStartFont2 + "NAME OF THE BANK" + strEndFont2 + "</td>");
                sb.Append("<td>" + BankName + "</td>");
                sb.Append("<td width='20%'>" + strStartFont2 + "CHEQUE NO." + strEndFont2 + "</td>");
                sb.Append("<td>" + ChequeNo + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td width='20%'>" + strStartFont2 + "Date" + strEndFont2 + "</td>");
                sb.Append("<td>" + Date + "</td>");
                sb.Append("<td width='20%'>" + strStartFont2 + "Amount" + strEndFont2 + "</td>");
                sb.Append("<td>" + strStartFont2 + FCTotalint + strEndFont2 + "</td>");
                sb.Append("</tr>");
                sb.Append("</table></td></tr>");
            }
            else
            {
                sb.Append("<tr><td colspan='3'><b>There is no record....</b></td></tr>");
            }

            sb.Append("</table>");
        }
        catch(Exception ex)
        {
            lblMsg.Text = ""+ex.Message.ToString();        
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
        if (txtOrgName.Text == "")
        {
            txtOrgName.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtOrgName.BorderColor = Color.Black;
        }
        if (txtAddress.Text == "")
        {
            txtAddress.BorderColor = Color.Red;
            Flag = false;
        }
        else
        {
            txtAddress.BorderColor = Color.Black;
        }
        return Flag;
    }
    #endregion Page Specific Event
   
}