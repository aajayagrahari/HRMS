using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HRMS_Class;
using ErrorHandler;
using System.IO;
public partial class Pages_Admin_RequitmentMaster : System.Web.UI.Page
{
    RequitmentMasterManager objRequitmentMasterManager = new RequitmentMasterManager();
    RequitmentMaster objRequitmentMaster = new RequitmentMaster();
    BindComboMasterManager objBindComboMasterManager = new BindComboMasterManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lbl_msg.Text = "";
           iniControls();
            BindCountry();
        }
    }
    void iniControls()
    {
        txt_address.Text = "";
        txt_apply_for.Text = "";
        txt_city.Text = "";
        txt_contact_no.Text = "";
        txt_date_birth.Text = "";
        txt_email.Text = "";
        txt_fname.Text = "";
        txt_lname.Text = "";
        txt_paramanent_Address.Text = "";
        txt_pin_code.Text = "";
        txt_qualifiaction.Text = "";
        ddl_country.SelectedIndex = 0;
        ddl_exprience.SelectedIndex = 0;
        ddl_gender.SelectedIndex = 0;
        ddl_state.SelectedIndex = 0;
    
    }

    public void BindCountry()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindCountry();
            ddl_country.DataSource = dt;
            ddl_country.DataTextField = "CountryName";
            ddl_country.DataValueField = "CountryCode";
            ddl_country.DataBind();
            ddl_country.Items.Insert(0, "-- Select --");
            ddl_country.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lbl_msg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindState(string strCountryCode)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindState(strCountryCode);
            ddl_state.DataSource = dt;
            ddl_state.DataTextField = "StateName";
            ddl_state.DataValueField = "StateCode";
            ddl_state.DataBind();
            ddl_state.Items.Insert(0, "-- Select --");
        }
        catch (Exception ex)
        {
            lbl_msg.Text = "" + ex.Message.ToString();
        }
    }
    void SetObjInfo()

    { 
        try
        {
        if (upd_resume.PostedFile.ContentLength > 0)
        {
            string date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string second = DateTime.Now.Second.ToString();
            string fileName = date + upd_resume.FileName;
            string path = Server.MapPath("~/Resume/" + fileName);
            upd_resume.SaveAs(path);
            objRequitmentMaster.FName = txt_fname.Text.Trim();
            objRequitmentMaster.LName = txt_lname.Text.Trim();
            objRequitmentMaster.Gender = ddl_gender.SelectedValue.ToString();
            objRequitmentMaster.DOB = txt_date_birth.Text.Trim();
            objRequitmentMaster.EmailId = txt_email.Text.Trim();
            objRequitmentMaster.MobileNo = txt_contact_no.Text.Trim();
            objRequitmentMaster.Qualification = txt_qualifiaction.Text.Trim();
            objRequitmentMaster.Exprience = ddl_exprience.SelectedValue.ToString();
            objRequitmentMaster.Designation = txt_apply_for.Text.Trim();
            objRequitmentMaster.CountryCode = ddl_country.SelectedValue.ToString();
            objRequitmentMaster.StateCode = ddl_state.SelectedValue.ToString();
            objRequitmentMaster.City = txt_city.Text.Trim();
            objRequitmentMaster.PinCode = txt_pin_code.Text.Trim();
            objRequitmentMaster.CAddress = txt_address.Text.Trim();
            objRequitmentMaster.PAddress = txt_paramanent_Address.Text.Trim();
            objRequitmentMaster.Resume = fileName;
            objRequitmentMaster.CreatedBy = "";
            objRequitmentMaster.ModifiedBy = "";
        }

        }
        catch (Exception ex)
        {
            lbl_msg.Text = "" + ex.Message.ToString();
        }
    
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_fname.Text == "")
            {
                lbl_msg.Text = "Please Enter First Name !.";
                txt_fname.Focus();
                return;
            }
            if (txt_lname.Text == "")
            {
                lbl_msg.Text = "Please Enter Last Name !.";
                txt_lname.Focus();
                return;
            }

            if (txt_date_birth.Text == "")
            {
                lbl_msg.Text = "Please Enter Date Of Birth !.";
                txt_date_birth.Focus();
                return;
            }
            if (txt_email.Text == "")
            {
                lbl_msg.Text = "Please Enter Email Id !.";
                txt_email.Focus();
                return;
            }
            if (txt_contact_no.Text == "" || txt_contact_no.Text.Trim().Length < 10)
            {
                lbl_msg.Text = "Please Enter Mobile No !.";
                return;
            }
            if (txt_qualifiaction.Text == "")
            {
                lbl_msg.Text = "Please Enter Qualification !.";
                return;
            }
            if (ddl_exprience.SelectedIndex == 0)
            {
                lbl_msg.Text = "Please Select Experience !.";
                return;
            }
            if (txt_apply_for.Text == "")
            {
                lbl_msg.Text = "Please Enter Apply For !.";
                return;
            }
            if (txt_fname.Text == "")
            {
                lbl_msg.Text = "Please Enter First Name !.";
                return;
            }
            if (ddl_country.SelectedIndex == 0)
            {
                lbl_msg.Text = "Please Select Country !.";
                return;
            }
            if (ddl_state.SelectedIndex == 0)
            {
                lbl_msg.Text = "Please Select State !.";
                return;
            }
            if (txt_city.Text == "")
            {
                lbl_msg.Text = "Please Enter City !.";
                return;
            }
            if (txt_pin_code.Text == "")
            {
                lbl_msg.Text = "Please Enter Pin Code !.";
                return;
            }
            if (txt_address.Text == "")
            {
                lbl_msg.Text = "Please Enter Current Address !.";
                return;
            }


            if (upd_resume.FileName.Length == 0)
            {
                lbl_msg.Text = "Please Choose Resume !.";
                return;
            }
            if (upd_resume.FileName.Length > 50)
            {
                lbl_msg.Text = "Please Resume Name Can Not Be Greater Than 50 Charecter !.";
                return;
            }

            SetObjInfo();

            foreach (ErrorHandlerClass err in objRequitmentMasterManager.SaveRequitmentMaster(objRequitmentMaster))
            {

                if (err.Type == "E")
                {
                    lbl_msg.Text = err.Message.ToString();
                    break;
                }
                else if (err.Type == "A")
                {
                    lbl_msg.Text = err.Message.ToString();
                    break;
                }
                else
                {
                    if (err.Type == "S")
                    {
                        lbl_msg.Text = err.Message.ToString();
                        iniControls();
                        //Response.Redirect("ListOrchardMaster.aspx?OrchardCode=");
                    }
                }
               
            }
        }
        catch (Exception ex)
        {

            lbl_msg.Text = ex.ToString();
        }


    }

    protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_country.SelectedIndex > 0)
        {
            string country_code = ddl_country.SelectedValue.ToString();
            BindState(country_code);
        }
    }
}