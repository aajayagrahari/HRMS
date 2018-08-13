using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HRMS_Class;
using ErrorHandler;
using System.Text;
public partial class Pages_Employee_frmReRegistrationPrint : System.Web.UI.Page
{
    #region Global Variable Declaration
    RequitmentRegistrationMasterManager objRequitmentRegistrationMasterManager = new RequitmentRegistrationMasterManager();
    #endregion Global Variable Declaration

    #region Page Event

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

           // tb_row.Visible = false;
            //btn_print.Visible = false;
            //litReport.Text = Registration();
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (txt_registration.Text == "")
        {
            lbl_msg.Text = "Enter Registration No. !";
            return;
        }


        if (txt_registration.Text != "")
        {
            long Rid = Convert.ToInt64(txt_registration.Text.ToString());
            DataSet ds = new DataSet();
            ds = objRequitmentRegistrationMasterManager.GetRequitmentRegistration(Rid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMsg.ForeColor = System.Drawing.Color.Black;
                lblMsg.Text = "";
                litReport.Text = Registration(ds);
                btnPrint.Visible = true;
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                litReport.Text = "";
                btnPrint.Visible = false;
                lblMsg.Text = "you have  entered wrong Registration No. Please enter right Registration No. ";
            }

              //tb_row.Visible = true;
              // btn_print.Visible = true; ;
            //    long Rid = Convert.ToInt64(txt_registration.Text.ToString());
            //    DataSet ds = new DataSet();
            //    ds = objRequitmentRegistrationMasterManager.GetRequitmentRegistration(Rid);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        lbl_msg.Text = "";
            //        lbl_registration_no.Text = ds.Tables[0].Rows[0]["RRId"].ToString();
            //        lbl_post.Text = ds.Tables[0].Rows[0]["PostName"].ToString();
            //        lbl_full_name.Text = ds.Tables[0].Rows[0]["FName"].ToString() + " " + ds.Tables[0].Rows[0]["MName"].ToString() + " " + ds.Tables[0].Rows[0]["LName"].ToString();
            //        lbl_father.Text = ds.Tables[0].Rows[0]["FatherFName"].ToString() + " " + ds.Tables[0].Rows[0]["FatherMName"].ToString() + " " + ds.Tables[0].Rows[0]["FatherLName"].ToString();
            //        lbl_dob.Text = ds.Tables[0].Rows[0]["Dob"].ToString();
            //        lbl_category.Text = ds.Tables[0].Rows[0]["Category"].ToString();
            //        lbl_c_Address.Text = ds.Tables[0].Rows[0]["CAddress"].ToString();
            //        lbl_c_city.Text = ds.Tables[0].Rows[0]["CCity"].ToString();
            //        lbl_c_State.Text = ds.Tables[0].Rows[0]["CState"].ToString();
            //        lbl_c_pincode.Text = ds.Tables[0].Rows[0]["CPincode"].ToString();
            //        lbl_p_address.Text = ds.Tables[0].Rows[0]["pAddress"].ToString();
            //        lbl_p_city.Text = ds.Tables[0].Rows[0]["PCity"].ToString();
            //        lbl_p_state.Text = ds.Tables[0].Rows[0]["PState"].ToString();
            //        lbl_p_pincode.Text = ds.Tables[0].Rows[0]["PPincode"].ToString();
            //        lbl_email.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            //        lbl_phone.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
            //        lbl_Mobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            //        lbl_total_experience.Text = ds.Tables[0].Rows[0]["TotalEperience"].ToString();
            //        lbl_org_name.Text = ds.Tables[0].Rows[0]["NameOfOrg"].ToString();
            //        lbl_org_name.Text = ds.Tables[0].Rows[0]["NameOfPost"].ToString();
            //        lbl_date_of_applied.Text = ds.Tables[0].Rows[0]["DateOfApplied"].ToString();
            //        lbl_Outcome.Text = ds.Tables[0].Rows[0]["OutCome"].ToString();
            //        lbl_about_vacancy.Text = ds.Tables[0].Rows[0]["AboutCompany"].ToString();

            //        if (ds.Tables[0].Rows[0]["Photo"].ToString() != "")
            //        {
            //            photos.Src = "~/Photos/" + ds.Tables[0].Rows[0]["Photo"].ToString();
            //        }
            //        else
            //        {
            //            photos.Src = "~/Photos/no_image.jpg";
            //        }
            //        if (ds.Tables[0].Rows[0]["Signature"].ToString() != "")
            //        {
            //            sing.Src = "~/Signatures/" + ds.Tables[0].Rows[0]["Signature"].ToString();

            //        }
            //        else
            //        {
            //            sing.Src = "~/Signatures/no_sign.jpg";
            //            sing.Height = 1;
            //        }
            //        lbl_Date.Text = ds.Tables[0].Rows[0]["CreatedDate"].ToString();

            //    }
            //    else
            //    {
            //        tb_row.Visible = false;
            //        btn_print.Visible = false;
            //        lbl_msg.Text = "Registration Id Not Found !.";
            //        photos.Src = "~/Photos/no_image.jpg";
            //        sing.Src = "~/Signatures/no_sign.jpg";
            //        sing.Height = 1;

            //    }

            //    if (ds.Tables[1].Rows.Count > 0)
            //    {
            //        gv_education.DataSource = ds.Tables[1];
            //        gv_education.DataBind();
            //    }
            //    else
            //    {

            //        gv_education.DataSource = null;
            //        gv_education.DataBind();
            //        gv_education.GridLines = 0;
            //    }

            //    if (ds.Tables[2].Rows.Count > 0)
            //    {
            //        gv_pro_education.DataSource = ds.Tables[2];
            //        gv_pro_education.DataBind();
            //    }
            //    else
            //    {

            //        gv_pro_education.DataSource = null;
            //        gv_pro_education.DataBind();
            //        gv_pro_education.GridLines = 0;
            //    }
            //    if (ds.Tables[3].Rows.Count > 0)
            //    {
            //        gv_work_experience.DataSource = ds.Tables[3];
            //        gv_work_experience.DataBind();
            //    }
            //    else
            //    {

            //        gv_work_experience.DataSource = null;
            //        gv_work_experience.DataBind();
            //        gv_work_experience.GridLines = 0;
            //    }

            //    if (ds.Tables[4].Rows.Count > 0)
            //    {
            //        gv_references.DataSource = ds.Tables[4];
            //        gv_references.DataBind();
            //    }
            //    else
            //    {

            //        gv_references.DataSource = null;
            //        gv_references.DataBind();
            //        gv_references.GridLines = 0;
            //    }


            //    if (ds.Tables[5].Rows.Count > 0)
            //    {
            //        gv_Language.DataSource = ds.Tables[5];
            //        gv_Language.DataBind();

            //    }
            //    else
            //    {

            //        gv_Language.DataSource = null;
            //        gv_Language.DataBind();
            //        gv_Language.GridLines = 0;
            //    }
            //}
        }
    }
    #endregion Page Event

    #region Page Specific Method
    private string  Registration(DataSet ds)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<table width='90%' align='center' style='border:1px black solid;' cellpadding='1' cellspacing='1'>");
        if (ds.Tables[0].Rows.Count > 0)
        {
            sb.Append("<tr>");
            sb.Append("<td width='20%'><img src='../../Images/logo.jpg' width='60' height='60'/></td>");
            sb.Append("<td align='center' width='60%'><b>BROADCAST ENGINEERING CONSULTANTS INDIA LTD </b>");
            sb.Append("<br><b>(A Govt. of India Enterprise)</b>");
            sb.Append("<br><b>Head Office:</b> 14-B, Ring Road, I.P. Estate, New Delhi-110002");
            sb.Append("<br><b>Tel :</b> + 91(11) 23378823-25, <b>Fax No.</b> + 91(11) 23379885");
            sb.Append("<br><b>Corporate Office:</b> C-56/A 17, Secto-62, Noida-201307");
            sb.Append("<br><b>Tel:</b> 0120-4177850, <b>Fax :</b> 0120-4177879");
            sb.Append("<br><b>E-Mail:</b> jobs@becil.com ,&nbsp; Website: www.becil.com");
            sb.Append("</td>");
            if (ds.Tables[0].Rows[0]["Photo"].ToString() != "")
            {
                //sb.Append("<td width='20%'><img src='~/Photos/"+ds.Tables[0].Rows[0]["Photo"].ToString()+"' width='60' height='60'/></td>");
                //photos.Src = "~/Photos/" + ds.Tables[0].Rows[0]["Photo"].ToString();
                sb.Append("<td width='20%'><img src='../../Photos/" + ds.Tables[0].Rows[0]["Photo"].ToString() + "' width='132' height='150'/></td>");
            }
            else
            {
                photos.Src = "~/Photos/no_image.jpg";
                sb.Append("<td width='20%'><img src='~/Photos/no_image.jpg' width='60' height='60'/></td>");
            }
            
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");

            sb.Append("<tr>");
            sb.Append("<td colspan='3'><b>(Imp: Please read the details on prescribed educational, professional as well as");
            sb.Append("experience requirements for the various professionals before filling in the form,");
            sb.Append("incomplete application will summarily be rejected) </b>");
            sb.Append("</td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><hr></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Registration No</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["RRId"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Full Name </b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["FName"].ToString() + " " + ds.Tables[0].Rows[0]["MName"].ToString() + " " + ds.Tables[0].Rows[0]["LName"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Post</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["PostName"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Father Name</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["FatherFName"].ToString() + " " + ds.Tables[0].Rows[0]["FatherMName"].ToString() + " " + ds.Tables[0].Rows[0]["FatherLName"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td> <b>Date Of Birth</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["Dob"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Category</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["Category"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Address for Communication</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["CAddress"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>City</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["CCity"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td> <b>State</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["CState"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Pin Code</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["CPincode"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Permanent Address </b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["pAddress"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td> <b>City</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["PCity"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>State</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["PState"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Pin Code</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["PPincode"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Email ID</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["Email"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td> <b>Phone No</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["PhoneNo"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td> <b>Mobile No</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["Mobile"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Educational Qualifications</b></td>");
            sb.Append("<td></td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
           
                sb.Append("<tr><td colspan='3'><table width='95%' align='center' style='border:1px black solid;'>");
                if (ds.Tables[1].Rows.Count > 0)
                {
                    sb.Append("<tr>");
                    sb.Append("<td>Qualification</td>");
                    sb.Append("<td>University</td>");
                    sb.Append("<td>Passing Year</td>");
                    sb.Append("<td>Grade</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr><td colspan='4'><hr></td></tr>");
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>" + ds.Tables[1].Rows[i]["Qualification"].ToString() + "</td>");
                        sb.Append("<td>" + ds.Tables[1].Rows[i]["Univercity"].ToString() + "</td>");
                        sb.Append("<td>" + ds.Tables[1].Rows[i]["PassingYear"].ToString() + "</td>");
                        sb.Append("<td>" + ds.Tables[1].Rows[i]["Grade"].ToString() + "</td>");
                        sb.Append("</tr>");
                    }
                

                }
                else
                {
                    sb.Append("<tr><td>There is no record....</td></tr>");
                }

                sb.Append("</table></td></tr>");
            
           
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Professional Qualifications</b></td>");
            sb.Append("<td></td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");

            sb.Append("<tr><td colspan='3'><table width='95%' align='center' style='border:1px black solid;'>");
                if (ds.Tables[2].Rows.Count > 0)
                {
                    sb.Append("<tr>");
                    sb.Append("<td>Qualification</td>");
                    sb.Append("<td>University</td>");
                    sb.Append("<td>Passing Year</td>");
                    sb.Append("<td>Grade</td>");
                    sb.Append("</tr>");
                    sb.Append("<tr><td colspan='4'><hr></td></tr>");
                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>" + ds.Tables[2].Rows[i]["Qualification"].ToString() + "</td>");
                        sb.Append("<td>" + ds.Tables[2].Rows[i]["Univercity"].ToString() + "</td>");
                        sb.Append("<td>" + ds.Tables[2].Rows[i]["PassingYear"].ToString() + "</td>");
                        sb.Append("<td>" + ds.Tables[2].Rows[i]["Grade"].ToString() + "</td>");
                        sb.Append("</tr>");
                    }
                }
                else
                {
                    sb.Append("<tr><td>There is no record....</td></tr>");
                }
                //Loop
                sb.Append("</table></td></tr>");
            
           
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Work Experience</b></td>");
            sb.Append("<td></td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");

            sb.Append("<tr><td colspan='3'><table width='95%' align='center' style='border:1px black solid;'>");
            if (ds.Tables[3].Rows.Count > 0)
            {
                sb.Append("<tr>");
                sb.Append("<td>Organization</td>");
                sb.Append("<td>Designation</td>");
                sb.Append("<td>Duration</td>");
                sb.Append("<td>Salary</td>");
                sb.Append("<td>Job Description</td>");
                sb.Append("</tr>");
                sb.Append("<tr><td colspan='5'><hr></td></tr>");
                for (int i = 0; i < ds.Tables[3].Rows.Count;i++ )
                {
                    sb.Append("<tr>");
                    sb.Append("<td>" + ds.Tables[3].Rows[i]["Organization"].ToString() + "</td>");
                    sb.Append("<td>" + ds.Tables[3].Rows[i]["Designation"].ToString() + "</td>");
                    sb.Append("<td>" + ds.Tables[3].Rows[i]["Duration"].ToString() + "</td>");
                    sb.Append("<td>" + ds.Tables[3].Rows[i]["Salary"].ToString() + "</td>");
                    sb.Append("<td>" + ds.Tables[3].Rows[i]["JobDescription"].ToString() + "</td>");
                    sb.Append("</tr>");
                }
            }
            else
            {
                sb.Append("<tr><td>There is no record......</td></tr>");
            }
            sb.Append("</table></td></tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Total years of experience</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["TotalEperience"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr><td colspan='3'><table width='100%'>");
            sb.Append("<tr>");
            sb.Append("<td align='center' width='50%'><b>References</b></td>");
            sb.Append("<td align='center' width='50%' colspan='2'><b>Languages</b></td>");
            //sb.Append("<td width='0%'></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td colspan='1' align='center' width='50%'><table width='95%' align='center' style='border:1px black solid;'>");
            if (ds.Tables[4].Rows.Count > 0)
            {
                sb.Append("<tr>");
                sb.Append("<td>Name</td>");
                sb.Append("<td>Address</td>");
                sb.Append("<td>Contact</td>");
                sb.Append("</tr>");
                sb.Append("<tr><td colspan='3'><hr></td></tr>");
                for (int i = 0; i < ds.Tables[4].Rows.Count;i++ )
                {
                    sb.Append("<tr>");
                    sb.Append("<td>" + ds.Tables[4].Rows[i]["Name"].ToString() + "</td>");
                    sb.Append("<td>" + ds.Tables[4].Rows[i]["Address"].ToString() + "</td>");
                    sb.Append("<td>" + ds.Tables[4].Rows[i]["Contact"].ToString() + "</td>");
                    sb.Append("</tr>");
                }
            }
            else
            {
                sb.Append("<tr><td>There is no record.......</td></tr>");
            }
            sb.Append("</table></td>");
            
            sb.Append("<td width='50%' align='right' colspan='2'>");
            sb.Append("<table width='95%' align='center' style='border:1px black solid;'>");
            if (ds.Tables[5].Rows.Count > 0)
            {
                sb.Append("<tr>");
                sb.Append("<td>Languages</td>");
                sb.Append("<td>Read</td>");
                sb.Append("<td>Speak</td>");
                sb.Append("<td>write</td>");
                sb.Append("</tr>");
                sb.Append("<tr><td colspan='4'><hr></td></tr>");
                for (int i = 0; i < ds.Tables[5].Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    sb.Append("<td>" + ds.Tables[5].Rows[i]["Language"].ToString() + "</td>");
                    sb.Append("<td>" + ds.Tables[5].Rows[i]["Reads"].ToString() + "</td>");
                    sb.Append("<td>" + ds.Tables[5].Rows[i]["Speak"].ToString() + "</td>");
                    sb.Append("<td>" + ds.Tables[5].Rows[i]["Write"].ToString() + "</td>");
                    sb.Append("</tr>");
                }
            }
            else
            {
                sb.Append("<tr><td>There is no record....</td></tr>");
            }
            sb.Append("</table>");
            sb.Append("</td>");
           // sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("</table></td></tr>");
            //sb.Append("<tr><td colspan='3'><br></td></tr>");
            //sb.Append("<tr>");
            //sb.Append("<td> <b>Languages known </b></td>");
            //sb.Append("<td></td>");
            //sb.Append("<td></td>");
            //sb.Append("</tr>");
            //sb.Append("<tr><td colspan='3'><table width='100%' style='border:1px black solid;'>");
            //if (ds.Tables[5].Rows.Count > 0)
            //{
            //    sb.Append("<tr>");
            //    sb.Append("<td>Languages</td>");
            //    sb.Append("<td>Read</td>");
            //    sb.Append("<td>Speak</td>");
            //    sb.Append("<td>write</td>");
            //    sb.Append("</tr>");
            //    sb.Append("<tr><td colspan='4'><hr></td></tr>");
            //    for (int i = 0; i < ds.Tables[5].Rows.Count; i++)
            //    {
            //        sb.Append("<tr>");
            //        sb.Append("<td>" + ds.Tables[5].Rows[i]["Language"].ToString() + "</td>");
            //        sb.Append("<td>" + ds.Tables[5].Rows[i]["Reads"].ToString() + "</td>");
            //        sb.Append("<td>" + ds.Tables[5].Rows[i]["Speak"].ToString() + "</td>");
            //        sb.Append("<td>" + ds.Tables[5].Rows[i]["Write"].ToString() + "</td>");
            //        sb.Append("</tr>");
            //    }
            //}
            //else
            //{
            //    sb.Append("<tr><td>There is no record....</td></tr>");
            //}
            //sb.Append("</table></td></tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr><td colspan='3'><b>Have you applied earlier, if so please furnish details thereof:</b></td></tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Name of the Organization:</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["NameOfOrg"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td> <b>Name of the Post</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["NameOfPost"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Date of Applied </b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["DateOfApplied"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Outcome</b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["OutCome"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>How did you learn about the vacancy. </b></td>");
            sb.Append("<td>" + ds.Tables[0].Rows[0]["AboutCompany"].ToString() + "</td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td colspan='3'><b>Note: Please provide self attested photocopies of following documents </b></td>");
            //sb.Append("<td>" + ds.Tables[0].Rows[0]["PostName"].ToString() + "</td>");
            //sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td>a) Educational / Professional Certificates</td>");
            sb.Append("<td></td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>b) Date of Birth Certificate</td>");
            sb.Append("<td></td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td> c) Experience Certificates</td>");
            sb.Append("<td></td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>d) Caste Certificate, if applicable</td>");
            sb.Append("<td></td>");
            sb.Append("<td></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr>");
            sb.Append("<td><b>Signature</b></td>");
            if (ds.Tables[0].Rows[0]["Signature"].ToString() != "")
            {
               // sing.Src = "~/Signatures/" + ds.Tables[0].Rows[0]["Signature"].ToString();
                //sb.Append("<td>" + ds.Tables[0].Rows[0]["PostName"].ToString() + "</td>");
                sb.Append("<td width='20%'><img src='../../Signatures/" + ds.Tables[0].Rows[0]["Signature"].ToString() + "' width='300' height='40'/></td>");

            }
            else
            {
                //sing.Src = "~/Signatures/no_sign.jpg";
                //sing.Height = 1;
               // sb.Append("<td>" + ds.Tables[0].Rows[0]["PostName"].ToString() + "</td>");
                sb.Append("<td width='20%'><img src='~/Signatures/no_sign.jpg' width='60' height='60'/></td>");
            }
            
            
           
            sb.Append("<td><b>Date</b></td>");
            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            sb.Append("<tr><td colspan='3'><table width='100%' style='border:1px black solid;'>");
            //Loop
            sb.Append("<tr>");
            sb.Append("<td colspan='3' align='center' valign='top'>For BECIL Office Records</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td>Registration No.</td>");
            sb.Append("<td>Receipt No. for Registration fee --------------------</td>");
            sb.Append("<td>Date</td>");

            sb.Append("</tr>");
            sb.Append("<tr><td colspan='3'><br></td></tr>");
            //Loop
            sb.Append("</table></td></tr>");
        }
        sb.Append("</table>");

        return sb.ToString();
    }
    #endregion Page Specific Method
}
