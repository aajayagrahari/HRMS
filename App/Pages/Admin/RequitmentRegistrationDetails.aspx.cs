using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HRMS_Class;
using ErrorHandler;
public partial class Pages_Admin_RequitmentRegistrationDetails : System.Web.UI.Page
{
    RequitmentRegistrationMasterManager objRequitmentRegistrationMasterManager = new RequitmentRegistrationMasterManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRegistrationInfo();
        }

    }

    void BindRegistrationInfo()
    {

        if (Request.QueryString["rid"] != null)
        {
            long Rid = Convert.ToInt64(Request.QueryString["rid"].ToString());
            DataSet ds = new DataSet();
            ds = objRequitmentRegistrationMasterManager.GetRequitmentRegistration(Rid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_registration_no.Text = ds.Tables[0].Rows[0]["RRId"].ToString();
                lbl_post.Text = ds.Tables[0].Rows[0]["Post"].ToString();
                lbl_full_name.Text = ds.Tables[0].Rows[0]["FName"].ToString() + " " + ds.Tables[0].Rows[0]["MName"].ToString() + " " + ds.Tables[0].Rows[0]["LName"].ToString();
                lbl_father.Text = ds.Tables[0].Rows[0]["FatherFName"].ToString() + " " + ds.Tables[0].Rows[0]["FatherMName"].ToString() + " " + ds.Tables[0].Rows[0]["FatherLName"].ToString();
                lbl_dob.Text = ds.Tables[0].Rows[0]["Dob"].ToString();
                lbl_category.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                lbl_c_Address.Text = ds.Tables[0].Rows[0]["CAddress"].ToString();
                lbl_c_city.Text = ds.Tables[0].Rows[0]["CCity"].ToString();
                lbl_c_State.Text = ds.Tables[0].Rows[0]["CState"].ToString();
                lbl_c_pincode.Text = ds.Tables[0].Rows[0]["CPincode"].ToString();
                lbl_p_address.Text = ds.Tables[0].Rows[0]["pAddress"].ToString();
                lbl_p_city.Text = ds.Tables[0].Rows[0]["PCity"].ToString();
                lbl_p_state.Text = ds.Tables[0].Rows[0]["PState"].ToString();
                lbl_p_pincode.Text = ds.Tables[0].Rows[0]["PPincode"].ToString();
                lbl_email.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                lbl_phone.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                lbl_Mobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                lbl_total_experience.Text = ds.Tables[0].Rows[0]["TotalEperience"].ToString();
                lbl_org_name.Text = ds.Tables[0].Rows[0]["NameOfOrg"].ToString();
                lbl_org_name.Text = ds.Tables[0].Rows[0]["NameOfPost"].ToString();
                lbl_date_of_applied.Text = ds.Tables[0].Rows[0]["DateOfApplied"].ToString();
                lbl_Outcome.Text = ds.Tables[0].Rows[0]["OutCome"].ToString();
                lbl_about_vacancy.Text = ds.Tables[0].Rows[0]["AboutCompany"].ToString();

                if (ds.Tables[0].Rows[0]["Photo"].ToString() != "")
                {
                    photos.Src = "~/Photos/" + ds.Tables[0].Rows[0]["Photo"].ToString();
                }
                else
                {
                    photos.Src = "~/Photos/no_image.jpg";
                }
                if (ds.Tables[0].Rows[0]["Signature"].ToString() != "")
                {
                    sing.Src = "~/Signatures/" + ds.Tables[0].Rows[0]["Signature"].ToString();

                }
                else
                {
                    sing.Src = "~/Signatures/no_sign.jpg";
                    sing.Height = 1;
                }
                lbl_Date.Text = ds.Tables[0].Rows[0]["CreatedDate"].ToString();

            }
            else
            {
                photos.Src = "~/Photos/no_image.jpg";
                sing.Src = "~/Signatures/no_sign.jpg";
                sing.Height = 1;
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_education.DataSource = ds.Tables[1];
                gv_education.DataBind();
            }
            else
            {

                gv_education.DataSource = null;
                gv_education.DataBind();
                gv_education.GridLines =0;
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                gv_pro_education.DataSource = ds.Tables[2];
                gv_pro_education.DataBind();
            }
            else
            {

                gv_pro_education.DataSource = null;
                gv_pro_education.DataBind();
                gv_pro_education.GridLines = 0;
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                gv_work_experience.DataSource = ds.Tables[3];
                gv_work_experience.DataBind();
            }
            else
            {

                gv_work_experience.DataSource = null;
                gv_work_experience.DataBind();
                gv_work_experience.GridLines = 0;
            }

            if (ds.Tables[4].Rows.Count > 0)
            {
                gv_references.DataSource = ds.Tables[4];
                gv_references.DataBind();
            }
            else
            {

                gv_references.DataSource = null;
                gv_references.DataBind();
                gv_references.GridLines = 0;
            }


            if (ds.Tables[5].Rows.Count > 0)
            {
                gv_Language.DataSource = ds.Tables[5];
                gv_Language.DataBind();
             
            }
            else
            {

                gv_Language.DataSource = null;
                gv_Language.DataBind();
                gv_Language.GridLines = 0;
            }
        }
    }
}