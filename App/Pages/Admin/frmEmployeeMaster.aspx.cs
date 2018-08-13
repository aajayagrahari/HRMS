using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using HRMS_Class;
using ErrorHandler;

public partial class Pages_Admin_frmEmployeeMaster : System.Web.UI.Page
{
    EmployeeMasterDetailsManager objEmployeeMasterManager = new EmployeeMasterDetailsManager();
    EmployeeEarningDetailsManager objEmployeeEarningDetailsManager = new EmployeeEarningDetailsManager();
    EmployeeDeductionDetailsManager objEmployeeDeductionDetailsManager = new EmployeeDeductionDetailsManager();
    EmployeeLeaveDetailsManager objEmployeeLeaveDetailsManager = new EmployeeLeaveDetailsManager();
    EmployeeJobDetailsManager objEmployeeJobDetailsManager = new EmployeeJobDetailsManager();
    EmployeeQualificationDetailsManager objEmployeeQualificationDetailsManager = new EmployeeQualificationDetailsManager();
    EmployeeLeftDetailsManager objEmployeeLeftDetailsManager=new EmployeeLeftDetailsManager();
    EmployeeOtherDetailsManager objEmployeeOtherDetailsManager = new EmployeeOtherDetailsManager();
    BindComboMasterManager objBindComboMasterManager = new BindComboMasterManager();
    
    DataSet ds4EmployeeEarningDetails = new DataSet();
    DataTable dt4EmployeeEarning = new DataTable();

    DataSet ds4EmployeeDeductionDetails = new DataSet();
    DataTable dt4EmployeeDeduction = new DataTable();

    DataSet ds4EmployeeLeaveDetails = new DataSet();
    DataTable dt4EmployeeLeaveDetails = new DataTable();

    DataSet ds4AllowancesDetails = new DataSet();
    DataTable dt4Allowances = new DataTable();

    DataSet ds4DeductionsDetails = new DataSet();
    DataTable dt4Deductions = new DataTable();

    DataSet ds4LeaveTypeDetails = new DataSet();
    DataTable dt4Leave = new DataTable();

    DataSet ds4ClassDetails = new DataSet();
    DataTable dt4Class = new DataTable();

    string EmployeeId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            

            lblMsg.Text = "";
            BindDepartment();
            BindDesignation();
            BindCountry();
            BindPermanentCountry();
            BindGender();
            BindBloodGroup();
            BindMaritalStatus();
            BindSalaryType();
            BindEmployeeType();
            BindSkilled();
            BindCategory();
            BindOTRateType();
            BindLateRateType();
            BindMonth();
            BindContractPeriod();

            BindEarningLeaveAllowedAfter();
            BindCasualLeaveAllowedAfter();

            BindLeftReason();
            BindPFDeptLeavingReason();
            BindESIDeptLeavingReason();
            //if (Request.QueryString["EmpId"].ToString() != "" && Request.QueryString["EmpId"].ToString() != null || Request.QueryString["JobId"].ToString() == "" && Request.QueryString["JobId"].ToString() == null || Request.QueryString["QuliId"].ToString() != "" && Request.QueryString["QuliId"].ToString() != null || Request.QueryString["ErngId"].ToString() != "" && Request.QueryString["ErngId"].ToString() != null || Request.QueryString["DdctId"].ToString() != "" && Request.QueryString["DdctId"].ToString() != null || Request.QueryString["LeaveId"].ToString() != "" && Request.QueryString["LeaveId"].ToString() != null || Request.QueryString["LeftId"].ToString() != "" && Request.QueryString["LeftId"].ToString() != null || Request.QueryString["OthrId"].ToString() != "" && Request.QueryString["OthrId"].ToString() != null)
            if (Request.QueryString["EmpId"].ToString() != "" && Request.QueryString["EmpId"].ToString() != null)
            {
                string EmpId = Convert.ToString(Request.QueryString["EmpId"].ToString());
                BindAllowances();
                BindDeductions();
                BindLeaveType();
                BindClass();
                PopulateDetails(EmpId); 
            }
            else
            {
                iniControls();
            }

        }
    }

    #region iniControls
    public void iniControls()
    {
        txtEmployeeId.Text = Convert.ToString(GetEmployeeCode());
        txtPCardNo.Text = Convert.ToString(GetEmployeeCode());
        txtFirstName.Text = "";
        txtMiddleName.Text = "";
        txtLastName.Text = "";
        txtFatherName.Text = "";
        DDLDesignation.SelectedIndex = 0;
        txtUnit.Text = "";
        txtSubUnit.Text = "";
        DDLDepartment.SelectedIndex = 0;
        txtPFNo.Text = "BCILN62/A/" + Convert.ToString(GetEmployeeCode());
        txtEsiNo.Text = "";
        iniControls4First();
        iniControls4Second();
        iniControls4Third();
        iniControls4Fourth();
        iniControls4Fifth();
        iniControls4Six();
        iniControls4Seven();
        iniControls4Eight();
        BindAllowances();
        BindDeductions();
        BindLeaveType();
        BindClass();
        DDlEmployeeType.Focus();
        btnSubmit.Text = "Submit";
    }

    public void iniControls4First()
    {
        txtAliasName.Text = "";
        txtNickName.Text = "";
        txtAddress.Text = "";
        txtCity.Text = "";
        txtZipCode.Text = "";
        DDLCountry.SelectedIndex = 0;
        DDLState.SelectedIndex = 0;
        txtContactNo.Text = "";
        txtEmailId.Text = "";
        txtPermanentAddress.Text = "";
        txtPermanentCity.Text = "";
        txtPermanentZip.Text = "";
        DDLPermanentCountry.SelectedIndex = 0;
        DDLPermanentState.SelectedIndex = 0;
        txtPlaceOfBirth.Text = "";
        txtPlaceOfBirth1.Text = "";
        txtRationCardNo.Text = "";
        txtVoterId.Text = "";
        txtPANNo.Text = "";
        txtPassportNo.Text = "";
        txtDLNo.Text = "";
        txtValidUpto.Text = "";
        txtIdentityMarks.Text = "";
        txtReligion.Text = "";
        txtNationality.Text = "";
        txtDateOfBirth.Text = "";
        txtRetirementDate.Text = "";
        DDLGender.SelectedIndex = 0;
        txtHeight.Text = "";
        DDLBloodGroup.SelectedIndex = 0;
        DDLMaritalStatus.SelectedIndex = 0;
        txtDate.Text = "";
    }

    public void iniControls4Second()
    {
        txtApplicationDate.Text = "";
        txtInterViewDate.Text = "";
        txtJoiningDate.Text = "";
        txtConfirmationDate.Text = "";
        txtSalaryStopAfter.Text = "";
        txtContractStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtContractEndDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtDateOfTransfer.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtPFStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtEPSStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtESIStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtCategory4Job.Text = "";
        txtGrade.Text = "";
        txtLevel4Job.Text = "";
        txtLocation4Job.Text = "";
        txtStatus4Job.Text = "";
        txtAdharCardNo.Text = "";
        txtPSNo.Text = "";
        txtNSSNo.Text = "";
        txtESIDispensary.Text = "";
        txtPlacementBy.Text = ""; ;
        txtBossReportTo.Text = "";
        txtContrctPeriod.Text = "6";
    }

    public void iniControls4Third()
    {
        foreach (GridViewRow grd in grdQualification.Rows)
        {
            CheckBox chk_Class = (CheckBox)grd.FindControl("chk_Class");
            TextBox txt_ClassName = (TextBox)grd.FindControl("txt_ClassName");
            TextBox txt_PassingYear = (TextBox)grd.FindControl("txt_PassingYear");
            TextBox txtCollegeOrUniversityName = (TextBox)grd.FindControl("txtCollegeOrUniversityName");
            TextBox txtSubject = (TextBox)grd.FindControl("txtSubject");
            TextBox txtPercentage = (TextBox)grd.FindControl("txtPercentage");

            chk_Class.Checked = false;
            txt_ClassName.Text = "";
            txt_ClassName.Enabled = false;
            txt_PassingYear.Text = "";
            txt_PassingYear.Enabled = false;
            txtCollegeOrUniversityName.Text = "";
            txtCollegeOrUniversityName.Enabled = false;
            txtSubject.Text = "";
            txtSubject.Enabled = false;
            txtPercentage.Text = "";
            txtPercentage.Enabled = false;
        }
    }

    public void iniControls4Fourth()
    {
        foreach (GridViewRow grd in grdEmployeeMasterDetails.Rows)
        {
            CheckBox chk_Allowance = (CheckBox)grd.FindControl("chk_Allowance");
            TextBox txt_Amount = (TextBox)grd.FindControl("txt_Amount");
            DropDownList ddlCalcOn = (DropDownList)grd.FindControl("ddlCalcOn");
            DropDownList ddlPayMode = (DropDownList)grd.FindControl("ddlPayMode");
            CheckBox chk_Bonus = (CheckBox)grd.FindControl("chk_Bonus");
            CheckBox chk_OT = (CheckBox)grd.FindControl("chk_OT");

            chk_Allowance.Checked = false;
            txt_Amount.Text = "";
            txt_Amount.Enabled = false;
            ddlCalcOn.SelectedIndex = 1;
            ddlCalcOn.Enabled = false;
            ddlPayMode.SelectedIndex = 0;
            ddlPayMode.Enabled = false;
            chk_Bonus.Checked = false;
            chk_Bonus.Enabled = false;
            chk_OT.Checked = false;
            chk_OT.Enabled = false;
        }
    }

    public void iniControls4Fifth()
    {
        foreach (GridViewRow grd in grdDeduction.Rows)
        {
            CheckBox chk_Deductions = (CheckBox)grd.FindControl("chk_Deductions");
            TextBox txt_Percentage = (TextBox)grd.FindControl("txt_Percentage");
            TextBox txt_Amount4D = (TextBox)grd.FindControl("txt_Amount4D");
            DropDownList ddlCalcOn4D = (DropDownList)grd.FindControl("ddlCalcOn4D");
            DropDownList ddlPayMode4D = (DropDownList)grd.FindControl("ddlPayMode4D");
            CheckBox chk_Limit = (CheckBox)grd.FindControl("chk_Limit");
            TextBox txt_LimitAmount = (TextBox)grd.FindControl("txt_LimitAmount");

            chk_Deductions.Checked = false;
            txt_Percentage.Text = "";
            txt_Amount4D.Text = "";
            txt_Amount4D.Enabled = false;
            ddlCalcOn4D.SelectedIndex = 1;
            ddlCalcOn4D.Enabled = false;
            ddlPayMode4D.SelectedIndex = 0;
            ddlPayMode4D.Enabled = false;
            chk_Limit.Checked = false;
            chk_Limit.Enabled = false;
            txt_LimitAmount.Text = "";
            txt_LimitAmount.Visible = false;
        }
    }

    public void iniControls4Six()
    {
        foreach (GridViewRow grd in grdLeave.Rows)
        {
            CheckBox chk_LeaveTypeId = (CheckBox)grd.FindControl("chk_LeaveTypeId");
            TextBox txt_Opening = (TextBox)grd.FindControl("txt_Opening");
            RadioButtonList rbtn_MonthlyEarnedType = (RadioButtonList)grd.FindControl("rbtn_MonthlyEarnedType");
            TextBox txt_MonthlyEarned = (TextBox)grd.FindControl("txt_MonthlyEarned");

            chk_LeaveTypeId.Checked = false;
            txt_Opening.Text = "";
            txt_Opening.Enabled = false;
            rbtn_MonthlyEarnedType.SelectedIndex = 1;
            rbtn_MonthlyEarnedType.Enabled = false;
            txt_MonthlyEarned.Text = "";
            txt_MonthlyEarned.Visible = false;
        }

        txtEarningLeaveAllowdAfter.Text = "";
        DDLEarningLeaveAllowed.SelectedIndex = 0;
        chkOnlyLastYearConsumed.Checked = false;
        txtCasualLeaveAllowedAfter.Text = "";
        DDLCasualLeaveAllowedAfter.SelectedIndex = 0;
        chkCLConsumedinCurrentYear.Checked = false;
        txtCHOpening.Text = "";

        txtEarningLeaveAllowdAfter.Enabled = false;
        DDLEarningLeaveAllowed.Enabled = false;
        chkOnlyLastYearConsumed.Enabled = false;
        txtCasualLeaveAllowedAfter.Enabled = false;
        DDLCasualLeaveAllowedAfter.Enabled = false;
        chkCLConsumedinCurrentYear.Enabled = false;

        txtItemNo4Leave.Text = "";
        txtItemNo4Leave.Text = Convert.ToString(GetItemNo4Leave());
    }

    public void iniControls4Seven()
    {
        txtLeftDate.Text = "";
        chkFullnFinal.Checked = false;
        DDLLeftResion.SelectedIndex = 0;
        DDLReason4Leave4PF.SelectedIndex = 0;
        DDlReason4Leaving4ESI.SelectedIndex = 0;
    }

    public void iniControls4Eight()
    {
        DDLSalaryType.SelectedIndex = 0;
        DDlEmployeeType.SelectedIndex = 0;
        DDLSkilled.SelectedIndex = 0;
        DDLCategory.SelectedIndex = 0;
        DDLOTRateType.SelectedIndex = 0;
        txtOTRate.Text = "";
        DDLLateRateType.SelectedIndex = 0;
        txtLatePenaltyRate.Text = "";
        txtIncrementDueDate.Text = "";
        DDLIncrementMonth.SelectedIndex = 0;
        txtBasicPayIncrement.Text = "";
        txtIdentityCardValidUpto.Text = "";
        txtSalaryCalculationDays.Text = "";
        txtGeneralWorkingHours.Text = "";
        txtOTCalculationDays.Text = "";
        txtOTWorkingHours.Text = "";
        txtTotalWorkingDaysInMonth.Text = "";

        txtBankName.Text = "";
        txtBranch.Text = "";
        txtAccountHolder.Text = "";
        txtAccountNo.Text = "";

    }

    #endregion
   
    #region PopulateDetails
    public void PopulateDetails(string EmpId)
    {
        try
        {
            DataSet DtEmployeeMasterDetails = objEmployeeMasterManager.GetEmployeeMaster4ID(EmpId);
            if (DtEmployeeMasterDetails.Tables[0].Rows.Count > 0)
            {
                txtEmployeeId.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["EmployeeId"].ToString();
                txtPCardNo.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["PCardNo"].ToString();
                txtFirstName.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["FirstName"].ToString();
                txtMiddleName.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["MiddleName"].ToString();
                txtLastName.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["LastName"].ToString();
                txtFatherName.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["FatherName"].ToString();
                DDLDesignation.SelectedValue = DtEmployeeMasterDetails.Tables[0].Rows[0]["Designation"].ToString();
                txtUnit.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["Unit"].ToString();
                txtSubUnit.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["SubUnit"].ToString();
                DDLDepartment.SelectedValue = DtEmployeeMasterDetails.Tables[0].Rows[0]["Department"].ToString();
                DDlEmployeeType.SelectedValue = DtEmployeeMasterDetails.Tables[0].Rows[0]["EmployeeTypeId"].ToString();
                txtPFNo.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["PFNo"].ToString();
                txtEsiNo.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["EsiNo"].ToString();
                PopulateDetails4First(EmpId);
                PopulateDetails4Second(EmpId);
                    PopulateDetails4Third(EmpId);
                    PopulateDetails4Fourth(EmpId);
                        PopulateDetails4Fifth(EmpId);
                        PopulateDetails4Six(EmpId);
                            PopulateDetails4Seven(EmpId);
                            PopulateDetails4Eight(EmpId);
                btnSubmit.Text = "Update";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();

        }
    }

    public void PopulateDetails4First(string EmpId)
    {
        try
        {
            //
            DataSet DtEmployeeMasterDetails = objEmployeeMasterManager.GetEmployeeMaster4ID(EmpId);
            if (DtEmployeeMasterDetails.Tables[0].Rows.Count > 0)
            {
                txtAliasName.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["AliasName"].ToString();
                txtNickName.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["NickName"].ToString();
                txtAddress.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["LocalAddress"].ToString();
                txtCity.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["City"].ToString();
                txtCity.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["City"].ToString();
                rblCityType.SelectedValue = DtEmployeeMasterDetails.Tables[0].Rows[0]["CityType"].ToString();
                DDLCountry.SelectedValue = DtEmployeeMasterDetails.Tables[0].Rows[0]["Country"].ToString();
                DDLState.SelectedValue = DtEmployeeMasterDetails.Tables[0].Rows[0]["State"].ToString();
                txtContactNo.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["ContactNo"].ToString();
                txtEmailId.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["EmailId"].ToString();
                txtPermanentAddress.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["ParamAddress"].ToString();
                txtPermanentCity.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["ParamCity"].ToString();
                txtPermanentZip.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["ParamZipCode"].ToString();
                DDLPermanentCountry.SelectedValue = DtEmployeeMasterDetails.Tables[0].Rows[0]["ParamCountry"].ToString();
                DDLPermanentState.SelectedValue = DtEmployeeMasterDetails.Tables[0].Rows[0]["ParamState"].ToString();
                txtPlaceOfBirth.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["PlaceOfBirth"].ToString();
                txtPlaceOfBirth1.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["PlaceOfBirth"].ToString();
                txtRationCardNo.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["RationCardNo"].ToString();
                txtVoterId.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["VoterId"].ToString();
                txtPANNo.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["PANCardNo"].ToString();
                txtPassportNo.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["PassportNo"].ToString();
                txtDLNo.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["DLNo"].ToString();
                txtValidUpto.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["ValidUpto"].ToString();
                txtIdentityMarks.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["IdentityMarks"].ToString();
                txtReligion.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["Religion"].ToString();
                txtNationality.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["Nationality"].ToString();
                txtDateOfBirth.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["DateOfBirth"].ToString();
                txtRetirementDate.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["RetirementDate"].ToString();
                DDLGender.SelectedValue = DtEmployeeMasterDetails.Tables[0].Rows[0]["Gender"].ToString();
                txtHeight.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["Height"].ToString();
                DDLBloodGroup.SelectedValue = DtEmployeeMasterDetails.Tables[0].Rows[0]["BloodGroup"].ToString();
                DDLMaritalStatus.SelectedValue = DtEmployeeMasterDetails.Tables[0].Rows[0]["MaritalStatus"].ToString();
                txtDate.Text = DtEmployeeMasterDetails.Tables[0].Rows[0]["Date"].ToString();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();

        }
    }

    public void PopulateDetails4Second(string EmpId)
    {
        try
        {
             DataSet DtEmployeeJobMasterDetails = objEmployeeJobDetailsManager.GetEmployeeJobDetails4ID(EmpId);
             if (DtEmployeeJobMasterDetails.Tables[0].Rows.Count > 0)
                {               
                txtApplicationDate.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["ApplicationDate"].ToString();
                txtInterViewDate.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["InterviewDate"].ToString();
                txtJoiningDate.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["JoiningDate"].ToString();
                txtConfirmationDate.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["ConfirmationDate"].ToString();
                txtSalaryStopAfter.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["SalartyStopAfter"].ToString();
                txtContractStartDate.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["ContractStartDate"].ToString();
                txtContractEndDate.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["ContractEndDate"].ToString();
                txtDateOfTransfer.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["DateOfTransfer"].ToString();
                txtPFStartDate.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["PFStartDate"].ToString();
                txtEPSStartDate.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["EPSStartDate"].ToString();
                txtESIStartDate.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["ESISStartDate"].ToString();
                txtCategory4Job.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["Category"].ToString();
                txtGrade.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["Grade"].ToString();
                txtLevel4Job.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["Lavel"].ToString();
                txtLocation4Job.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["Location"].ToString();
                txtStatus4Job.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["Status"].ToString();
                txtAdharCardNo.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["AdharCardNo"].ToString();
                txtPSNo.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["PSNo"].ToString();
                txtNSSNo.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["NSSNo"].ToString();
                txtESIDispensary.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["ESIDispensary"].ToString();
                txtPlacementBy.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["PlacementBy"].ToString();
                txtBossReportTo.Text = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["BossReportTo"].ToString();
                txtContrctPeriod.Text ="6";
               // ViewState["EmployeeJobId"] = DtEmployeeJobMasterDetails.Tables[0].Rows[0]["EmployeeJobId"].ToString();
            }
            btnSubmit.Text = "Update";
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();

        }
    }

    public void PopulateDetails4Third(string EmpId)
    {
        try
        {
           
            DataSet DtEmployeeQualificationDetails = objEmployeeQualificationDetailsManager.GetEmployeeQualificationDetails4ID(EmpId);
            if (DtEmployeeQualificationDetails.Tables[0].Rows.Count > 0)
            {
               // ViewState["EmployeeQualificationId"] = DtEmployeeQualificationDetails.Tables[0].Rows[0]["EmployeeQualificationId"].ToString();
                foreach (GridViewRow grd in grdQualification.Rows)
                {
                    CheckBox chk_Class = (CheckBox)grd.FindControl("chk_Class");
                    TextBox txt_ClassName = (TextBox)grd.FindControl("txt_ClassName");
                    TextBox txt_PassingYear = (TextBox)grd.FindControl("txt_PassingYear");
                    TextBox txtCollegeOrUniversityName = (TextBox)grd.FindControl("txtCollegeOrUniversityName");
                    TextBox txtSubject = (TextBox)grd.FindControl("txtSubject");
                    TextBox txtPercentage = (TextBox)grd.FindControl("txtPercentage");

                    foreach (DataRow dr in DtEmployeeQualificationDetails.Tables[0].Rows)
                    {
                        if (Convert.ToString(chk_Class.Text).Trim() == Convert.ToString(dr["ClassType"]).Trim())
                        {
                            chk_Class.Checked = true;
                            //txt_ClassName.Text = DtEmployeeQualificationDetails.Tables[0].Rows[0]["ClassName"].ToString();
                            txt_ClassName.Text = dr["ClassName"].ToString();
                            txt_ClassName.Enabled = true;
                            txt_PassingYear.Text = dr["PassingYear"].ToString();
                            txt_PassingYear.Enabled = true;
                            txtCollegeOrUniversityName.Text = dr["CollegeOrUniversityName"].ToString();
                            txtCollegeOrUniversityName.Enabled = true;
                            txtSubject.Text = dr["Subject"].ToString();
                            txtSubject.Enabled = true;
                            txtPercentage.Text = dr["Percentage"].ToString();
                            txtPercentage.Enabled = true;
                        }
                    }
                }

                
            }
  
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();

        }
    }

    public void PopulateDetails4Fourth(string EmpId)
    {
        try
        {
          
            DataSet DtEmployeeEarningDetailsManager = objEmployeeEarningDetailsManager.GetEmployeeEarningDetails4Grid(EmpId);
            if (DtEmployeeEarningDetailsManager.Tables[0].Rows.Count > 0)
            {
               // ViewState["EmployeeEarningId"] = DtEmployeeEarningDetailsManager.Tables[0].Rows[0]["EmployeeEarningId"].ToString();
                foreach (GridViewRow grd in grdEmployeeMasterDetails.Rows)
                {
                    CheckBox chk_Allowance = (CheckBox)grd.FindControl("chk_Allowance");
                    TextBox txt_Amount = (TextBox)grd.FindControl("txt_Amount");
                    DropDownList ddlCalcOn = (DropDownList)grd.FindControl("ddlCalcOn");
                    DropDownList ddlPayMode = (DropDownList)grd.FindControl("ddlPayMode");
                    CheckBox chk_Bonus = (CheckBox)grd.FindControl("chk_Bonus");
                    CheckBox chk_OT = (CheckBox)grd.FindControl("chk_OT");

                    foreach (DataRow dr in DtEmployeeEarningDetailsManager.Tables[0].Rows)
                    {
                        if (Convert.ToString(chk_Allowance.Text).Trim() == Convert.ToString(dr["Allowances"]).Trim())
                        {
                            chk_Allowance.Checked = true;
                            txt_Amount.Text = dr["Amount"].ToString();
                            txt_Amount.Enabled = true;
                            ddlCalcOn.SelectedValue = dr["CalcOn"].ToString();
                            ddlCalcOn.Enabled = true;
                            ddlPayMode.SelectedValue = dr["PaymentMode"].ToString();
                            ddlPayMode.Enabled = true;
                            chk_Bonus.Checked = true;
                            chk_Bonus.Enabled = true;
                            chk_OT.Checked = true;
                            chk_OT.Enabled = true;
                        }
                    }
                }

            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();

        }
    }

    public void PopulateDetails4Fifth(string EmpId)
    {
        try
        {
          
            DataSet DtEmployeeDeductionDetailsManager = objEmployeeDeductionDetailsManager.GetEmployeeDeductionDetails4Grid(EmpId);
            if (DtEmployeeDeductionDetailsManager.Tables[0].Rows.Count > 0)
            {
               // ViewState["EmployeeDeductionId"] = DtEmployeeDeductionDetailsManager.Tables[0].Rows[0]["EmployeeDeductionId"].ToString();
                foreach (GridViewRow grd in grdDeduction.Rows)
                {
                    CheckBox chk_Deductions = (CheckBox)grd.FindControl("chk_Deductions");
                    TextBox txt_Percentage = (TextBox)grd.FindControl("txt_Percentage");
                    TextBox txt_Amount4D = (TextBox)grd.FindControl("txt_Amount4D");
                    DropDownList ddlCalcOn4D = (DropDownList)grd.FindControl("ddlCalcOn4D");
                    DropDownList ddlPayMode4D = (DropDownList)grd.FindControl("ddlPayMode4D");
                    CheckBox chk_Limit = (CheckBox)grd.FindControl("chk_Limit");
                    TextBox txt_LimitAmount = (TextBox)grd.FindControl("txt_LimitAmount");

                    foreach (DataRow dr in DtEmployeeDeductionDetailsManager.Tables[0].Rows)
                    {
                        if (Convert.ToString(chk_Deductions.Text).Trim() == Convert.ToString(dr["Deductions"]).Trim())
                        {
                            chk_Deductions.Checked = true;
                            //txt_Percentage.Text = dr["DeductionPercetage"].ToString();
                            txt_Amount4D.Text = dr["DeductionAmount"].ToString();
                            txt_Amount4D.Enabled = true;
                            ddlCalcOn4D.SelectedValue = dr["DeductionCalcOn"].ToString();
                            ddlCalcOn4D.Enabled = true;
                            ddlPayMode4D.SelectedValue = dr["DeductionPayMode"].ToString();
                            ddlPayMode4D.Enabled = true;
                            chk_Limit.Checked = true;
                            chk_Limit.Enabled = true;
                            txt_LimitAmount.Text = dr["LimitAmount"].ToString();
                            txt_LimitAmount.Visible = true;
                        }
                    }
                }


            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();

        }
    }

    public void PopulateDetails4Six(string EmpId)
    {
        try
        {
           
            DataSet DtEmployeeLeaveDetailsManager = objEmployeeLeaveDetailsManager.GetEmployeeLeaveDetails4Grid(EmpId);
            if (DtEmployeeLeaveDetailsManager.Tables[0].Rows.Count > 0)
            {
                //ViewState["EmployeeLeaveId"] = DtEmployeeLeaveDetailsManager.Tables[0].Rows[0]["EmployeeLeaveId"].ToString();
                foreach (GridViewRow grd in grdLeave.Rows)
                {
                    CheckBox chk_LeaveTypeId = (CheckBox)grd.FindControl("chk_LeaveTypeId");
                    TextBox txt_Opening = (TextBox)grd.FindControl("txt_Opening");
                    RadioButtonList rbtn_MonthlyEarnedType = (RadioButtonList)grd.FindControl("rbtn_MonthlyEarnedType");
                    TextBox txt_MonthlyEarned = (TextBox)grd.FindControl("txt_MonthlyEarned");

                    foreach (DataRow dr in DtEmployeeLeaveDetailsManager.Tables[0].Rows)
                    {
                        if (Convert.ToString(chk_LeaveTypeId.Text).Trim() == Convert.ToString(dr["LeaveType"]).Trim())
                        {
                            chk_LeaveTypeId.Checked = true;
                            txt_Opening.Text = dr["Opening"].ToString();
                            txt_Opening.Enabled = true;
                            rbtn_MonthlyEarnedType.SelectedValue = dr["MonthlyEarnedType"].ToString();
                            rbtn_MonthlyEarnedType.Enabled = true;
                            txt_MonthlyEarned.Text = dr["MonthlyEarned"].ToString();
                            txt_MonthlyEarned.Visible = true;
                        }
                    }
                }

            }
            txtEarningLeaveAllowdAfter.Text = DtEmployeeLeaveDetailsManager.Tables[0].Rows[0]["EarningLeaveAllowedAfter"].ToString();
            DDLEarningLeaveAllowed.SelectedValue = DtEmployeeLeaveDetailsManager.Tables[0].Rows[0]["ConsumedEL"].ToString();
            chkOnlyLastYearConsumed.Checked = true;
            txtCasualLeaveAllowedAfter.Text = DtEmployeeLeaveDetailsManager.Tables[0].Rows[0]["CasulLeaveAllowedAfter"].ToString();
            DDLCasualLeaveAllowedAfter.SelectedValue = DtEmployeeLeaveDetailsManager.Tables[0].Rows[0]["EarnedCL"].ToString();
            chkCLConsumedinCurrentYear.Checked = true;
            txtCHOpening.Text = "";

            txtEarningLeaveAllowdAfter.Enabled = true;
            DDLEarningLeaveAllowed.Enabled = true;
            chkOnlyLastYearConsumed.Enabled = true;
            txtCasualLeaveAllowedAfter.Enabled = true;
            DDLCasualLeaveAllowedAfter.Enabled = true;
            chkCLConsumedinCurrentYear.Enabled = true;

            txtItemNo4Leave.Text = DtEmployeeLeaveDetailsManager.Tables[0].Rows[0]["ItemNo"].ToString();
            txtItemNo4Leave.Text = Convert.ToString(GetItemNo4Leave());
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();

        }
    }

    public void PopulateDetails4Seven(string EmpId)
    {
        try
        {
           
            DataSet DtEmployeeLeftDetailsManager = objEmployeeLeftDetailsManager.GetEmployeeLeftDetails4ID(EmpId);
            if (DtEmployeeLeftDetailsManager.Tables[0].Rows.Count > 0)
            {
                //ViewState["EmployeeLeftId"] = DtEmployeeLeftDetailsManager.Tables[0].Rows[0]["EmployeeLeftId"].ToString();
                txtLeftDate.Text = DtEmployeeLeftDetailsManager.Tables[0].Rows[0]["LeftDate"].ToString();
                chkFullnFinal.Checked = true;
                DDLLeftResion.SelectedValue= DtEmployeeLeftDetailsManager.Tables[0].Rows[0]["LeftReason"].ToString();
                DDLReason4Leave4PF.SelectedValue= DtEmployeeLeftDetailsManager.Tables[0].Rows[0]["LeavingReason4PFDepartment"].ToString();
                DDlReason4Leaving4ESI.SelectedValue= DtEmployeeLeftDetailsManager.Tables[0].Rows[0]["LeavingReason4ESIDepartment"].ToString();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();

        }
    }

    public void PopulateDetails4Eight(string EmpId)
    {
        try
        {
            
            DataSet DtEmployeeOtherDetailsManager = objEmployeeOtherDetailsManager.GetEmployeeOtherDetails4ID(EmpId);
            if (DtEmployeeOtherDetailsManager.Tables[0].Rows.Count > 0)
            {
                //ViewState["EmployeeOtherId"] = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["EmployeeOtherId"].ToString();
                DDLSalaryType.SelectedValue = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["SalaryType"].ToString();
                //DDlEmployeeType.SelectedValue = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["Skilled"].ToString();
                DDLSkilled.SelectedValue = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["Skilled"].ToString();
                DDLCategory.SelectedValue = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["Category"].ToString();
                DDLOTRateType.SelectedValue = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["OTRateType"].ToString();
                txtOTRate.Text = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["OTRate"].ToString();
                DDLLateRateType.SelectedValue = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["LateRateType"].ToString();
                txtLatePenaltyRate.Text = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["LatePenaltyRate"].ToString();
                txtIncrementDueDate.Text = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["IncrementDueDate"].ToString();
                DDLIncrementMonth.SelectedValue = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["IncrementMonth"].ToString();
                txtBasicPayIncrement.Text = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["BasicPayIncrementAs"].ToString();
                txtIdentityCardValidUpto.Text = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["IdentityCardValidity"].ToString();
                txtSalaryCalculationDays.Text = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["SalaryCalculationDays"].ToString();
                txtGeneralWorkingHours.Text = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["GeneralWorkingHours"].ToString();
                txtOTCalculationDays.Text = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["OTCalculationDays"].ToString();
                txtOTWorkingHours.Text = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["OTWorkingHours"].ToString();
                txtTotalWorkingDaysInMonth.Text = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["TotalDaysInMonth"].ToString();

                //txtBankName.Text = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["LeftDate"].ToString();
                //txtBranch.Text = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["LeftDate"].ToString();
                //txtAccountHolder.Text = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["LeftDate"].ToString();
               // txtAccountNo.Text = DtEmployeeOtherDetailsManager.Tables[0].Rows[0]["LeftDate"].ToString();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();

        }
    }
    #endregion
   
    #region Bind Combo Box for Employee Details
    public void BindCountry()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindCountry();
            DDLCountry.DataSource = dt;
            DDLCountry.DataTextField = "CountryName";
            DDLCountry.DataValueField = "CountryCode";
            DDLCountry.DataBind();
            DDLCountry.Items.Insert(0, "-- Select--");
            DDLCountry.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindState(string strCountryCode)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindState(strCountryCode);
            DDLState.DataSource = dt;
            DDLState.DataTextField = "StateName";
            DDLState.DataValueField = "StateCode";
            DDLState.DataBind();
            DDLState.Items.Insert(0, "-- Select--");
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindPermanentCountry()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindCountry();
            DDLPermanentCountry.DataSource = dt;
            DDLPermanentCountry.DataTextField = "CountryName";
            DDLPermanentCountry.DataValueField = "CountryCode";
            DDLPermanentCountry.DataBind();
            DDLPermanentCountry.Items.Insert(0, "-- Select--");
            DDLPermanentCountry.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindPermanentState(string strCountryCode)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindState(strCountryCode);
            DDLPermanentState.DataSource = dt;
            DDLPermanentState.DataTextField = "StateName";
            DDLPermanentState.DataValueField = "StateCode";
            DDLPermanentState.DataBind();
            DDLPermanentState.Items.Insert(0, "-- Select--");
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindGender()
    {
        DDLGender.Items.Add(new ListItem("Male", "M"));
        DDLGender.Items.Add(new ListItem("Female", "F"));
        DDLGender.Items.Insert(0, "-- Select--");
    }

    public void BindBloodGroup()
    {
        DDLBloodGroup.Items.Add(new ListItem("A", "A"));
        DDLBloodGroup.Items.Add(new ListItem("B", "B"));
        DDLBloodGroup.Items.Add(new ListItem("AB", "AB"));
        DDLBloodGroup.Items.Add(new ListItem("O", "O"));
        DDLBloodGroup.Items.Insert(0, "-- Select--");
    }

    public void BindMaritalStatus()
    {
        DDLMaritalStatus.Items.Add(new ListItem("Single", "S"));
        DDLMaritalStatus.Items.Add(new ListItem("Married", "M"));
        DDLMaritalStatus.Items.Add(new ListItem("Widowed", "W"));
        DDLMaritalStatus.Items.Add(new ListItem("Divorced", "D"));
        DDLMaritalStatus.Items.Insert(0, "-- Select--");
    }

    public void BindDepartment()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindDepartment();
            DDLDepartment.DataSource = dt;
            DDLDepartment.DataTextField = "Department";
            DDLDepartment.DataValueField = "DepartmentId";
            DDLDepartment.DataBind();
            DDLDepartment.Items.Insert(0, "-- Select--");

            DDLDepartment.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindDesignation()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindDesignation();
            DDLDesignation.DataSource = dt;
            DDLDesignation.DataTextField = "Designation";
            DDLDesignation.DataValueField = "DesignationId";
            DDLDesignation.DataBind();
            DDLDesignation.Items.Insert(0, "-- Select--");
            DDLDesignation.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindContractPeriod()
    {
        ddlContractPeriod.Items.Add(new ListItem("Month", "M"));
        ddlContractPeriod.Items.Add(new ListItem("Year", "Y"));
    }
    #endregion

    #region Bind Combo Box For Earning
    public void BindCalcOn(DropDownList DDLCalcOn)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindCalcOn();
            DDLCalcOn.DataSource = dt;
            DDLCalcOn.DataTextField = "CalculationOn";
            DDLCalcOn.DataValueField = "CalculationOnId";
            DDLCalcOn.DataBind();
            DDLCalcOn.Items.Insert(0, "-- Select--");
            DDLCalcOn.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindPaymentMode(DropDownList DDLpayMode)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindPaymentMode();
            DDLpayMode.DataSource = dt;
            DDLpayMode.DataTextField = "PaymentMode";
            DDLpayMode.DataValueField = "PaymentModeId";
            DDLpayMode.DataBind();
            DDLpayMode.Items.Insert(0, "-- Select--");
            DDLpayMode.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    #endregion

    #region Bind Combo Box For Deduction
    public void BindCalcOnDeductions(DropDownList DDLCalcOnDeduction)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindCalcOn();
            DDLCalcOnDeduction.DataSource = dt;
            DDLCalcOnDeduction.DataTextField = "CalculationOn";
            DDLCalcOnDeduction.DataValueField = "CalculationOnId";
            DDLCalcOnDeduction.DataBind();
            DDLCalcOnDeduction.Items.Insert(0, "-- Select--");
            DDLCalcOnDeduction.SelectedIndex = 1;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindPaymentMode4Deductions(DropDownList DDLPayMode4Deduction)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindPaymentMode();
            DDLPayMode4Deduction.DataSource = dt;
            DDLPayMode4Deduction.DataTextField = "PaymentMode";
            DDLPayMode4Deduction.DataValueField = "PaymentModeId";
            DDLPayMode4Deduction.DataBind();
            DDLPayMode4Deduction.Items.Insert(0, "-- Select--");
            DDLPayMode4Deduction.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    #endregion

    #region Bind Combo Box 4 Leave
    public void BindEarningLeaveAllowedAfter()
    {
        DDLEarningLeaveAllowed.Items.Add(new ListItem("Days", "D"));
        DDLEarningLeaveAllowed.Items.Add(new ListItem("Month", "M"));
    }

    public void BindCasualLeaveAllowedAfter()
    {
        DDLCasualLeaveAllowedAfter.Items.Add(new ListItem("Days", "D"));
        DDLCasualLeaveAllowedAfter.Items.Add(new ListItem("Month", "M"));
    }
    #endregion

    #region Bind Combo Box 4 Left
    public void BindLeftReason()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindLeftReason();
            DDLLeftResion.DataSource = dt;
            DDLLeftResion.DataTextField = "Resigned";
            DDLLeftResion.DataValueField = "ResignedId";
            DDLLeftResion.DataBind();
            DDLLeftResion.Items.Insert(0, "-- Select--");
            DDLLeftResion.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindPFDeptLeavingReason()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindPFDeptLeavingReason();
            DDLReason4Leave4PF.DataSource = dt;
            DDLReason4Leave4PF.DataTextField = "PFDeptLeavingReason";
            DDLReason4Leave4PF.DataValueField = "PFDeptLeavingReasonId";
            DDLReason4Leave4PF.DataBind();
            DDLReason4Leave4PF.Items.Insert(0, "-- Select--");
            DDLReason4Leave4PF.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindESIDeptLeavingReason()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindESIDeptLeavingReason();
            DDlReason4Leaving4ESI.DataSource = dt;
            DDlReason4Leaving4ESI.DataTextField = "ESIDeptLeavingReason";
            DDlReason4Leaving4ESI.DataValueField = "ESIDeptLeavingReasonId";
            DDlReason4Leaving4ESI.DataBind();
            DDlReason4Leaving4ESI.Items.Insert(0, "-- Select--");
            DDlReason4Leaving4ESI.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    #endregion

    #region Bind Combo Box for Other Details
    public void BindSalaryType()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindSalaryType();
            DDLSalaryType.DataSource = dt;
            DDLSalaryType.DataTextField = "SalaryType";
            DDLSalaryType.DataValueField = "SalaryTypeId";
            DDLSalaryType.DataBind();
            DDLSalaryType.Items.Insert(0, "-- Select--");
            DDLSalaryType.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindEmployeeType()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindEmployeeType();
            DDlEmployeeType.DataSource = dt;
            DDlEmployeeType.DataTextField = "EmployeeType";
            DDlEmployeeType.DataValueField = "EmployeeTypeId";
            DDlEmployeeType.DataBind();
            DDlEmployeeType.Items.Insert(0, "-- Select--");
            DDlEmployeeType.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindSkilled()
    {
        DDLSkilled.Items.Add(new ListItem("Yes", "Y"));
        DDLSkilled.Items.Add(new ListItem("No", "N"));
        DDLSkilled.Items.Insert(0, "-- Select--");
    }

    public void BindCategory()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindCategory();
            DDLCategory.DataSource = dt;
            DDLCategory.DataTextField = "Category";
            DDLCategory.DataValueField = "CategoryId";
            DDLCategory.DataBind();
            DDLCategory.Items.Insert(0, "-- Select--");
            DDLCategory.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindOTRateType()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindOTRateType();
            DDLOTRateType.DataSource = dt;
            DDLOTRateType.DataTextField = "OTRateType";
            DDLOTRateType.DataValueField = "OTRateTypeId";
            DDLOTRateType.DataBind();
            DDLOTRateType.Items.Insert(0, "-- Select--");
            DDLOTRateType.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindLateRateType()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindLateRateType();
            DDLLateRateType.DataSource = dt;
            DDLLateRateType.DataTextField = "LateRateType";
            DDLLateRateType.DataValueField = "LateRateTypeId";
            DDLLateRateType.DataBind();
            DDLLateRateType.Items.Insert(0, "-- Select--");
            DDLLateRateType.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindMonth()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = objBindComboMasterManager.BindMonth();
            DDLIncrementMonth.DataSource = dt;
            DDLIncrementMonth.DataTextField = "Month";
            DDLIncrementMonth.DataValueField = "MonthId";
            DDLIncrementMonth.DataBind();
            DDLIncrementMonth.Items.Insert(0, "-- Select--");
            DDLIncrementMonth.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    #endregion

    #region Bind Grid Functions
    public void BindAllowances()
    {
        try
        {
            ds4AllowancesDetails = objEmployeeMasterManager.GetAllowances();
            grdEmployeeMasterDetails.DataSource = ds4AllowancesDetails.Tables[0];
            grdEmployeeMasterDetails.DataBind();
            Session["EmployeeEarning"] = ds4AllowancesDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindDeductions()
    {
        try
        {
            ds4DeductionsDetails = objEmployeeMasterManager.GetDeductions();
            grdDeduction.DataSource = ds4DeductionsDetails.Tables[0];
            grdDeduction.DataBind();
            Session["EmployeeDeduction"] = ds4DeductionsDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindLeaveType()
    {
        try
        {
            ds4LeaveTypeDetails = objEmployeeMasterManager.GetLeaveType();
            grdLeave.DataSource = ds4LeaveTypeDetails.Tables[0];
            grdLeave.DataBind();
            Session["EmployeeLeave"] = ds4LeaveTypeDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }

    public void BindClass()
    {
        try
        {
            ds4ClassDetails = objEmployeeMasterManager.GetClassName();
            grdQualification.DataSource = ds4ClassDetails.Tables[0];
            grdQualification.DataBind();
            Session["ClassName"] = ds4ClassDetails.Tables[0];
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    #endregion

    #region Buton Click Event
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        if (CheckValidation() == true)
        {
            EmployeeMasterDetails objEmployeeMaster = new EmployeeMasterDetails();
            EmployeeJobDetails objEmployeeJobDetails = new EmployeeJobDetails();
            EmployeeEarningDetails objEmployeeEarningDetails = new EmployeeEarningDetails();
            EmployeeDeductionDetails objEmployeeDeductionDetails = new EmployeeDeductionDetails();
            EmployeeLeaveDetails objEmployeeLeaveDetails = new EmployeeLeaveDetails();
            EmployeeLeftDetails objEmployeeLeftDetails = new EmployeeLeftDetails();
            EmployeeOtherDetails objEmployeeOtherDetails = new EmployeeOtherDetails();

            try
            {
                setObjectInfor4Employee(objEmployeeMaster);
                setObjectInfor4Job(objEmployeeJobDetails);
                setObjectInfor4Left(objEmployeeLeftDetails);
                setObjectInfor4Other(objEmployeeOtherDetails);

                foreach (ErrorHandlerClass err in objEmployeeMasterManager.SaveEmployeeMaster(objEmployeeMaster, objEmployeeJobDetails, SetObjectInfo4Qualification(), SetObjectInfo4Earnings(), SetObjectInfo4Deductions(), SetObjectInfo4Leaves(), objEmployeeLeftDetails, objEmployeeOtherDetails))
                {

                    if (err.Type == "E")
                    {
                        lblMsg.Text = err.Message.ToString();
                        break;
                    }
                    else if (err.Type == "A")
                    {
                        lblMsg.Text = err.Message.ToString();
                        break;
                    }
                    else
                    {
                        if (lblMsg.Text.ToString() == "")
                        {
                            lblMsg.Text = err.Message.ToString();
                            ////ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                            //Response.Write("<script>alert('err.Message.ToString()');</script>");
                            TabContainer1.ActiveTabIndex = 0;
                            //Response.Redirect("ListOrchardMaster.aspx?OrchardCode=");
                        }
                    }
                    iniControls();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "" + ex.Message.ToString();
                //objErrorLog.WriteErrorLog(ex.ToString());
            }
        }
        else
        {
            DDlEmployeeType.Focus();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        iniControls();
        //Response.Redirect("ListOrchardMaster.aspx");
    }
    #endregion

    #region SetObjectInfo
    public void setObjectInfor4Employee(EmployeeMasterDetails objEmployeeMaster)
    {
        objEmployeeMaster.EmployeeId = Convert.ToString(txtEmployeeId.Text).Trim();
        if (DDlEmployeeType.SelectedIndex > 0)
        {
            objEmployeeMaster.EmployeeType = Convert.ToString(DDlEmployeeType.SelectedValue);
        }
        else
        {
            objEmployeeMaster.EmployeeType = "";
        }
        objEmployeeMaster.PCardNo = Convert.ToString(txtPCardNo.Text).Trim();
        objEmployeeMaster.FirstName = Convert.ToString(txtFirstName.Text).Trim();
        objEmployeeMaster.MiddleName = Convert.ToString(txtMiddleName.Text).Trim();
        objEmployeeMaster.LastName = Convert.ToString(txtLastName.Text).Trim();
        objEmployeeMaster.FatherName = Convert.ToString(txtFatherName.Text).Trim();
        if (DDLDepartment.SelectedIndex > 0)
        {
            objEmployeeMaster.Department = Convert.ToString(DDLDepartment.SelectedValue).Trim();
        }
        else
        {
            objEmployeeMaster.Department = "";
        }

        if (DDLDesignation.SelectedIndex > 0)
        {
            objEmployeeMaster.Designation = Convert.ToString(DDLDesignation.SelectedValue).Trim();
        }
        else
        {
            objEmployeeMaster.Designation = "";
        }

        objEmployeeMaster.Unit = Convert.ToString(txtUnit.Text).Trim();
        objEmployeeMaster.SubUnit = Convert.ToString(txtSubUnit.Text).Trim();
        objEmployeeMaster.PFNo = Convert.ToString(txtPFNo.Text).Trim();
        objEmployeeMaster.ESINo = Convert.ToString(txtEsiNo.Text).Trim();
        objEmployeeMaster.AliasName = Convert.ToString(txtAliasName.Text).Trim();
        objEmployeeMaster.NickName = Convert.ToString(txtNickName.Text).Trim();
        objEmployeeMaster.LocalAddress = Convert.ToString(txtAddress.Text).Trim();
        objEmployeeMaster.City = Convert.ToString(txtCity.Text).Trim();
        objEmployeeMaster.CityType = rblCityType.SelectedValue;
        objEmployeeMaster.ZipCode = Convert.ToString(txtZipCode.Text).Trim();
        if (DDLCountry.SelectedIndex > 0)
        {
            objEmployeeMaster.Country = Convert.ToString(DDLCountry.SelectedValue).Trim();
        }
        else
        {
            objEmployeeMaster.Country = "";
        }

        if (DDLState.SelectedIndex > 0)
        {
            objEmployeeMaster.State = Convert.ToString(DDLState.SelectedValue).Trim();
        }
        else
        {
            objEmployeeMaster.State = "";
        }

        objEmployeeMaster.EmailId = Convert.ToString(txtEmailId.Text).Trim();
        objEmployeeMaster.ContactNo = Convert.ToString(txtContactNo.Text).Trim();
        objEmployeeMaster.ParamAddress = Convert.ToString(txtPermanentAddress.Text).Trim();
        objEmployeeMaster.ParamCity = Convert.ToString(txtPermanentCity.Text).Trim();
        objEmployeeMaster.ParamZipCode = Convert.ToString(txtPermanentZip.Text).Trim();
        if (DDLPermanentCountry.SelectedIndex > 0)
        {
            objEmployeeMaster.ParamCountry = Convert.ToString(DDLPermanentCountry.SelectedValue).Trim();
        }
        else
        {
            objEmployeeMaster.ParamCountry = "";
        }

        if (DDLPermanentState.SelectedIndex > 0)
        {
            objEmployeeMaster.ParamState = Convert.ToString(DDLPermanentState.SelectedValue).Trim();
        }
        else
        {
            objEmployeeMaster.ParamState = "";
        }
        objEmployeeMaster.PlaceOfBirth = Convert.ToString(txtPlaceOfBirth.Text).Trim();
        objEmployeeMaster.RationCardNo = Convert.ToString(txtRationCardNo.Text).Trim();
        objEmployeeMaster.VoterId = Convert.ToString(txtVoterId.Text).Trim();
        objEmployeeMaster.PANNo = Convert.ToString(txtPANNo.Text).Trim();
        objEmployeeMaster.PassportNo = Convert.ToString(txtPassportNo.Text).Trim();
        objEmployeeMaster.DLNo = Convert.ToString(txtDLNo.Text).Trim();
        objEmployeeMaster.ValidUpTo = Convert.ToString(txtValidUpto.Text).Trim();
        objEmployeeMaster.IdentityMarks = Convert.ToString(txtIdentityMarks.Text).Trim();
        objEmployeeMaster.Religion = Convert.ToString(txtReligion.Text).Trim();
        objEmployeeMaster.Nationality = Convert.ToString(txtNationality.Text).Trim();
        objEmployeeMaster.DateOfBirth = Convert.ToString(txtDateOfBirth.Text).Trim();
        objEmployeeMaster.RetirementDate = Convert.ToString(txtRetirementDate.Text).Trim();
        if (DDLGender.SelectedIndex > 0)
        {
            objEmployeeMaster.Gender = Convert.ToString(DDLGender.SelectedValue).Trim();
        }
        else
        {
            objEmployeeMaster.Gender = "";
        }
        if (txtHeight.Text != "")
        {
            objEmployeeMaster.Height = Convert.ToDouble(txtHeight.Text);
        }
        else
        {
            objEmployeeMaster.Height = 0.0;
        }

        if (DDLBloodGroup.SelectedIndex > 0)
        {
            objEmployeeMaster.BloodGroup = Convert.ToString(DDLBloodGroup.SelectedValue).Trim();
        }
        else
        {
            objEmployeeMaster.BloodGroup = "";
        }

        if (DDLMaritalStatus.SelectedIndex > 0)
        {
            objEmployeeMaster.MaritalStatus = Convert.ToString(DDLMaritalStatus.SelectedValue).Trim();
        }
        else
        {
            objEmployeeMaster.MaritalStatus = "";
        }
        objEmployeeMaster.Date = Convert.ToString(txtDate.Text).Trim();

        //Bank Details
        objEmployeeMaster.BankName = Convert.ToString(txtBankName.Text).Trim();
        objEmployeeMaster.Branch = Convert.ToString(txtBranch.Text).Trim();
        objEmployeeMaster.AccountHolderName = Convert.ToString(txtAccountHolder.Text).Trim();
        objEmployeeMaster.AccountNo = Convert.ToString(txtAccountNo.Text).Trim();
        //
        if (FileUpload1.PostedFile.ContentLength > 0)
       {
            string date = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            string fileName = date + FileUpload1.FileName;
            string path = Server.MapPath("~/EmpPhotos/" + fileName);
            FileUpload1.SaveAs(path);

            objEmployeeMaster.EmployeePic = fileName;

        }
        else
        {
            objEmployeeMaster.EmployeePic ="";
        }
      
        objEmployeeMaster.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
        objEmployeeMaster.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();
    }

    public void setObjectInfor4Job(EmployeeJobDetails objEmployeeJobDetails)
    {
        if (Session["JobId"] != null)
        {
            objEmployeeJobDetails.EmployeeJobId = Convert.ToInt32(Session["JobId"].ToString());
        }
        else
        {
            objEmployeeJobDetails.EmployeeJobId = 0;
        }
        objEmployeeJobDetails.ApplicationDate = Convert.ToString(txtApplicationDate.Text).Trim();
        objEmployeeJobDetails.InterviewDate = Convert.ToString(txtInterViewDate.Text).Trim();
        objEmployeeJobDetails.JoiningDate = Convert.ToString(txtJoiningDate.Text).Trim();
        objEmployeeJobDetails.ConfirmationDate = Convert.ToString(txtConfirmationDate.Text).Trim();
        objEmployeeJobDetails.AppointmentLetterIssueDate = Convert.ToString(txtAppointMentLetterIssueDate.Text).Trim();
        objEmployeeJobDetails.SalartyStopAfter = Convert.ToString(txtSalaryStopAfter.Text).Trim();
        objEmployeeJobDetails.ContractStartDate = Convert.ToString(txtContractStartDate.Text).Trim();
        objEmployeeJobDetails.ContractEndDate = Convert.ToString(txtContractEndDate.Text).Trim();
        objEmployeeJobDetails.DateOfTransfer = Convert.ToString(txtDateOfTransfer.Text).Trim();
        objEmployeeJobDetails.PFStartDate = Convert.ToString(txtPFStartDate.Text).Trim();
        objEmployeeJobDetails.EPSStartDate = Convert.ToString(txtEPSStartDate.Text).Trim();
        objEmployeeJobDetails.ESISStartDate = Convert.ToString(txtESIStartDate.Text).Trim();
        objEmployeeJobDetails.Category = Convert.ToString(txtCategory4Job.Text).Trim().Trim();
        objEmployeeJobDetails.Grade = Convert.ToString(txtGrade.Text).Trim().Trim();
        objEmployeeJobDetails.Lavel = Convert.ToString(txtLevel4Job.Text).Trim();
        objEmployeeJobDetails.Location = Convert.ToString(txtLocation4Job.Text).Trim();
        objEmployeeJobDetails.Status = Convert.ToString(txtStatus4Job.Text).Trim();
        objEmployeeJobDetails.AdharCardNo = Convert.ToString(txtAdharCardNo.Text).Trim();
        objEmployeeJobDetails.PSNo = Convert.ToString(txtPSNo.Text).Trim();
        objEmployeeJobDetails.NSSNo = Convert.ToString(txtNSSNo.Text).Trim();
        objEmployeeJobDetails.ESIDispensary = Convert.ToString(txtESIDispensary.Text).Trim();
        objEmployeeJobDetails.PlacementBy = Convert.ToString(txtPlacementBy.Text).Trim();
        objEmployeeJobDetails.BossReportTo = Convert.ToString(txtBossReportTo.Text).Trim();

        objEmployeeJobDetails.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
        objEmployeeJobDetails.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();
    }

    public ICollection<EmployeeQualificationDetails> SetObjectInfo4Qualification()
    {
        List<EmployeeQualificationDetails> lst = new List<EmployeeQualificationDetails>();
        EmployeeQualificationDetails objEmployeeQualificationDetails = null;
        int itemno = 1;

        foreach (GridViewRow grd in grdQualification.Rows)
        {
            CheckBox chk_Class = (CheckBox)grd.FindControl("chk_Class");
            Label lbl_ClassId = (Label)grd.FindControl("lbl_ClassId");
            TextBox txt_ClassName = (TextBox)grd.FindControl("txt_ClassName");
            RadioButtonList rbtn_MonthlyEarnedType = (RadioButtonList)grd.FindControl("rbtn_MonthlyEarnedType");
            TextBox txt_PassingYear = (TextBox)grd.FindControl("txt_PassingYear");
            TextBox txtCollegeOrUniversityName = (TextBox)grd.FindControl("txtCollegeOrUniversityName");
            TextBox txtSubject = (TextBox)grd.FindControl("txtSubject");
            TextBox txtPercentage = (TextBox)grd.FindControl("txtPercentage");

            if (chk_Class.Checked == true)
            {
                objEmployeeQualificationDetails = new EmployeeQualificationDetails();
                objEmployeeQualificationDetails.ItemNo = Convert.ToInt32(itemno);
                objEmployeeQualificationDetails.ClassId = Convert.ToString(lbl_ClassId.Text).Trim();
                objEmployeeQualificationDetails.ClassName = Convert.ToString(txt_ClassName.Text).Trim();
                objEmployeeQualificationDetails.PassingYear = Convert.ToString(txt_PassingYear.Text).Trim();
                objEmployeeQualificationDetails.CollegeOrUniversityName = Convert.ToString(txtCollegeOrUniversityName.Text).Trim();
                objEmployeeQualificationDetails.Subject = Convert.ToString(txtSubject.Text).Trim();
                objEmployeeQualificationDetails.Percentage = Convert.ToString(txtPercentage.Text).Trim();

                objEmployeeQualificationDetails.IsDeleted = Convert.ToInt32(0);
                objEmployeeQualificationDetails.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
                objEmployeeQualificationDetails.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();
                if (Session["QuliId"] != null)
                {
                    objEmployeeQualificationDetails.EmployeeQualificationId = Convert.ToInt32(Session["QuliId"].ToString());
                }
                else
                {
                    objEmployeeQualificationDetails.EmployeeQualificationId = Convert.ToInt32(GetEmployeeQualificationId());
                }
                lst.Add(objEmployeeQualificationDetails);
                itemno = itemno + 1;
            }
        }
        return lst;
    }

    public ICollection<EmployeeEarningDetails> SetObjectInfo4Earnings()
    {
        List<EmployeeEarningDetails> lst = new List<EmployeeEarningDetails>();
        EmployeeEarningDetails objEmployeeEarningDetails = null;
        int itemNo = 1;

        foreach (GridViewRow grd in grdEmployeeMasterDetails.Rows)
        {
            CheckBox chk_Allowance = (CheckBox)grd.FindControl("chk_Allowance");
            TextBox txt_Amount = (TextBox)grd.FindControl("txt_Amount");
            TextBox txt_ItemNo = (TextBox)grd.FindControl("txt_ItemNo");
            DropDownList DDLCalcOn = (DropDownList)grd.FindControl("DDLCalcOn");
            DropDownList DDLpayMode = (DropDownList)grd.FindControl("DDLpayMode");
            CheckBox chk_Bonus = (CheckBox)grd.FindControl("chk_Bonus");
            CheckBox chk_OT = (CheckBox)grd.FindControl("chk_OT");

            if (chk_Allowance.Checked == true)
            {
                objEmployeeEarningDetails = new EmployeeEarningDetails();
                objEmployeeEarningDetails.ItemNo = Convert.ToInt32(itemNo);
                objEmployeeEarningDetails.Allowances = Convert.ToString(chk_Allowance.Text).Trim();
                objEmployeeEarningDetails.Amount = Convert.ToDouble(txt_Amount.Text);
                objEmployeeEarningDetails.CalcOn = Convert.ToString(DDLCalcOn.SelectedValue).Trim();
                objEmployeeEarningDetails.PaymentMode = Convert.ToString(DDLpayMode.SelectedValue).Trim();

                if (chk_Bonus.Checked == true)
                {
                    objEmployeeEarningDetails.Bonus = 1;
                }
                else
                {
                    objEmployeeEarningDetails.Bonus = 0;
                }

                if (chk_OT.Checked == true)
                {
                    objEmployeeEarningDetails.OT = 1;
                }
                else
                {
                    objEmployeeEarningDetails.OT = 0;
                }
                objEmployeeEarningDetails.IsDeleted = Convert.ToInt32(0);
                objEmployeeEarningDetails.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
                objEmployeeEarningDetails.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();

                lst.Add(objEmployeeEarningDetails);
                itemNo = itemNo + 1;
                if (Session["ErngId"] != null)
                {
                    objEmployeeEarningDetails.EmployeeEarningId = Convert.ToInt32(Session["ErngId"].ToString());
                }
                else
                {
                    objEmployeeEarningDetails.EmployeeEarningId = Convert.ToInt32(GetEmployeeEarningId());
                }
            }
        }
        return lst;
    }

    public ICollection<EmployeeDeductionDetails> SetObjectInfo4Deductions()
    {
        List<EmployeeDeductionDetails> lst = new List<EmployeeDeductionDetails>();
        EmployeeDeductionDetails objEmployeeDeductionDetails = null;
        int itemNo = 1;

        foreach (GridViewRow grd in grdDeduction.Rows)
        {
            CheckBox chk_Deductions = (CheckBox)grd.FindControl("chk_Deductions");
            TextBox txt_Percentage = (TextBox)grd.FindControl("txt_Percentage");
            TextBox txt_Amount4D = (TextBox)grd.FindControl("txt_Amount4D");
            TextBox txt_ItemNo4D = (TextBox)grd.FindControl("txt_ItemNo4D");
            DropDownList ddlCalcOn4D = (DropDownList)grd.FindControl("ddlCalcOn4D");
            DropDownList ddlPayMode4D = (DropDownList)grd.FindControl("ddlPayMode4D");
            CheckBox chk_Limit = (CheckBox)grd.FindControl("chk_Limit");
            TextBox txt_LimitAmount = (TextBox)grd.FindControl("txt_LimitAmount");

            if (chk_Deductions.Checked == true)
            {
                objEmployeeDeductionDetails = new EmployeeDeductionDetails();
                objEmployeeDeductionDetails.ItemNo = Convert.ToInt32(itemNo);
                objEmployeeDeductionDetails.Deductions = Convert.ToString(chk_Deductions.Text).Trim();

                if (txt_Percentage.Text != "")
                {
                    objEmployeeDeductionDetails.DeductionPercetage = Convert.ToDouble(txt_Percentage.Text);
                }
                else
                {
                    objEmployeeDeductionDetails.DeductionPercetage = 0;
                }

                if (txt_Amount4D.Text != "")
                {
                    objEmployeeDeductionDetails.DeductionAmount = Convert.ToDouble(txt_Amount4D.Text);
                }
                else
                {
                    objEmployeeDeductionDetails.DeductionAmount = 0;
                }

                if (ddlCalcOn4D.SelectedIndex > 0)
                {
                    objEmployeeDeductionDetails.DeductionCalcOn = Convert.ToString(ddlCalcOn4D.SelectedValue).Trim();
                }
                else
                {
                    objEmployeeDeductionDetails.DeductionCalcOn = "";
                }

                if (ddlPayMode4D.SelectedIndex > 0)
                {
                    objEmployeeDeductionDetails.DeductionPayMode = Convert.ToString(ddlPayMode4D.SelectedValue).Trim();
                }
                else
                {
                    objEmployeeDeductionDetails.DeductionPayMode = "";
                }

                if (chk_Limit.Checked == true)
                {
                    objEmployeeDeductionDetails.DeductionLimit = Convert.ToInt32(1);
                    if (txt_LimitAmount.Text != "")
                    {
                        objEmployeeDeductionDetails.LimitAmount = Convert.ToDouble(txt_LimitAmount.Text);
                    }
                    else
                    {
                        objEmployeeDeductionDetails.LimitAmount = 0.0000;
                    }
                }
                else
                {
                    objEmployeeDeductionDetails.DeductionLimit = 0;
                    objEmployeeDeductionDetails.LimitAmount = 0.0000;
                }
                if (Session["DdctId"] != null)
                {
                    objEmployeeDeductionDetails.EmployeeDeductionId = Convert.ToInt32(Session["DdctId"].ToString());
                }
                else
                {
                    objEmployeeDeductionDetails.EmployeeDeductionId = Convert.ToInt32(GetEmployeeDeductionId());
                }
                objEmployeeDeductionDetails.IsDeleted = Convert.ToInt32(0);
                objEmployeeDeductionDetails.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
                objEmployeeDeductionDetails.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();

                lst.Add(objEmployeeDeductionDetails);
                itemNo = itemNo + 1;
            }
        }
        return lst;
    }

    public ICollection<EmployeeLeaveDetails> SetObjectInfo4Leaves()
    {
        List<EmployeeLeaveDetails> lst = new List<EmployeeLeaveDetails>();
        EmployeeLeaveDetails objEmployeeLeaveDetails = null;
        int itemno = 1;

        foreach (GridViewRow grd in grdLeave.Rows)
        {
            CheckBox chk_LeaveTypeId = (CheckBox)grd.FindControl("chk_LeaveTypeId");
            TextBox txt_Opening = (TextBox)grd.FindControl("txt_Opening");
            RadioButtonList rbtn_MonthlyEarnedType = (RadioButtonList)grd.FindControl("rbtn_MonthlyEarnedType");
            TextBox txt_ItemNo4Leave = (TextBox)grd.FindControl("txt_ItemNo4Leave");
            TextBox txt_MonthlyEarned = (TextBox)grd.FindControl("txt_MonthlyEarned");

            if (chk_LeaveTypeId.Checked == true)
            {
                objEmployeeLeaveDetails = new EmployeeLeaveDetails();
                objEmployeeLeaveDetails.ItemNo = Convert.ToInt32(itemno);
                objEmployeeLeaveDetails.LeaveType = Convert.ToString(chk_LeaveTypeId.Text).Trim();
                if (txt_Opening.Text != "")
                {
                    objEmployeeLeaveDetails.Opening = Convert.ToInt32(txt_Opening.Text);
                }
                else
                {
                    objEmployeeLeaveDetails.Opening = 0;
                }

                objEmployeeLeaveDetails.MonthlyEarnedType = Convert.ToInt32(rbtn_MonthlyEarnedType.SelectedValue);
                objEmployeeLeaveDetails.MonthlyEarned = Convert.ToString(txt_MonthlyEarned.Text).Trim();

                if (Convert.ToString(txtEarningLeaveAllowdAfter.Text).Trim() != "")
                {
                    objEmployeeLeaveDetails.EarningLeaveAllowedAfter = Convert.ToInt32(txtEarningLeaveAllowdAfter.Text);
                }
                else
                {
                    objEmployeeLeaveDetails.EarningLeaveAllowedAfter = 0;
                }

                if (DDLEarningLeaveAllowed.SelectedIndex > 0)
                {
                    objEmployeeLeaveDetails.EarningLeaveIn = Convert.ToString(DDLEarningLeaveAllowed.SelectedValue).Trim();
                }
                else
                {
                    objEmployeeLeaveDetails.EarningLeaveIn = "";
                }

                if (chkOnlyLastYearConsumed.Checked == true)
                {
                    objEmployeeLeaveDetails.ConsumedEL = 1;
                }
                else
                {
                    objEmployeeLeaveDetails.ConsumedEL = 0;
                }

                if (Convert.ToString(txtCasualLeaveAllowedAfter.Text).Trim() != "")
                {
                    objEmployeeLeaveDetails.CasulLeaveAllowedAfter = Convert.ToInt32(txtCasualLeaveAllowedAfter.Text);
                }
                else
                {
                    objEmployeeLeaveDetails.CasulLeaveAllowedAfter = 0;
                }

                if (DDLCasualLeaveAllowedAfter.SelectedIndex > 0)
                {
                    objEmployeeLeaveDetails.CasualLeaveAllowedIn = Convert.ToString(DDLCasualLeaveAllowedAfter.SelectedValue);
                }
                else
                {
                    objEmployeeLeaveDetails.CasualLeaveAllowedIn = "";
                }

                if (chkCLConsumedinCurrentYear.Checked == true)
                {
                    objEmployeeLeaveDetails.EarnedCL = 1;
                }
                else
                {
                    objEmployeeLeaveDetails.EarnedCL = 0;
                }
                if (Session["LeaveId"] != null)
                {
                    objEmployeeLeaveDetails.EmployeeLeaveId = Convert.ToInt32(Session["LeaveId"].ToString());
                }
                else
                {
                    objEmployeeLeaveDetails.EmployeeLeaveId = Convert.ToInt32(GetEmployeeLeaveId());
                }
                objEmployeeLeaveDetails.IsDeleted = Convert.ToInt32(0);
                objEmployeeLeaveDetails.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
                objEmployeeLeaveDetails.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();

                lst.Add(objEmployeeLeaveDetails);
                itemno = itemno + 1;
            }
        }
        return lst;
    }

    public void setObjectInfor4Left(EmployeeLeftDetails objEmployeeLeftDetails)
    {
        objEmployeeLeftDetails.LeftDate = Convert.ToString(txtLeftDate.Text).Trim();
        if (chkFullnFinal.Checked == true)
        {
            objEmployeeLeftDetails.FullnFinal = 1;
        }
        else
        {
            objEmployeeLeftDetails.FullnFinal = 0;
        }

        if (DDLLeftResion.SelectedIndex > 0)
        {
            objEmployeeLeftDetails.LeftReason = Convert.ToString(DDLLeftResion.SelectedValue);
        }
        else
        {
            objEmployeeLeftDetails.LeftReason = "";
        }

        if (DDLReason4Leave4PF.SelectedIndex > 0)
        {
            objEmployeeLeftDetails.LeavingReason4PFDepartment = Convert.ToString(DDLReason4Leave4PF.SelectedValue);
        }
        else
        {
            objEmployeeLeftDetails.LeavingReason4PFDepartment = "";
        }

        if (DDlReason4Leaving4ESI.SelectedIndex > 0)
        {
            objEmployeeLeftDetails.LeavingReason4ESIDepartment = Convert.ToString(DDlReason4Leaving4ESI.SelectedValue);
        }
        else
        {
            objEmployeeLeftDetails.LeavingReason4ESIDepartment = "";
        }
        if (Session["LeftId"] != null)
        {
            objEmployeeLeftDetails.EmployeeLeftId = Convert.ToInt32(Session["LeftId"].ToString());
        }
        else
        {
            objEmployeeLeftDetails.EmployeeLeftId = 0;
        }
        objEmployeeLeftDetails.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
        objEmployeeLeftDetails.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();
    }

    public void setObjectInfor4Other(EmployeeOtherDetails objEmployeeOtherDetails)
    {
        if (DDLSalaryType.SelectedIndex > 0)
        {
            objEmployeeOtherDetails.SalaryType = Convert.ToString(DDLSalaryType.SelectedValue);
        }
        else
        {
            objEmployeeOtherDetails.SalaryType = "";
        }

        if (DDLSkilled.SelectedIndex != 0)
        {
            objEmployeeOtherDetails.Skilled = Convert.ToString(DDLSkilled.SelectedValue);
        }
        else
        {
            objEmployeeOtherDetails.Skilled = "";
        }

        if (DDLCategory.SelectedIndex > 0)
        {
            objEmployeeOtherDetails.Category = Convert.ToString(DDLCategory.SelectedValue);
        }
        else
        {
            objEmployeeOtherDetails.Category = "";
        }

        if (DDLOTRateType.SelectedIndex > 0)
        {
            objEmployeeOtherDetails.OTRateType = Convert.ToString(DDLOTRateType.SelectedValue);
        }
        else
        {
            objEmployeeOtherDetails.OTRateType = "";
        }

        if (txtOTRate.Text != "")
        {
            objEmployeeOtherDetails.OTRate = Convert.ToDouble(txtOTRate.Text);
        }
        else
        {
            objEmployeeOtherDetails.OTRate = 0.0;
        }

        if (DDLLateRateType.SelectedIndex > 0)
        {
            objEmployeeOtherDetails.LateRateType = Convert.ToString(DDLLateRateType.SelectedValue);
        }
        else
        {
            objEmployeeOtherDetails.LateRateType = "";
        }

        if (txtLatePenaltyRate.Text != "")
        {
            objEmployeeOtherDetails.LatePenaltyRate = Convert.ToDouble(txtLatePenaltyRate.Text);
        }
        else
        {
            objEmployeeOtherDetails.LatePenaltyRate = 0.0;
        }

        objEmployeeOtherDetails.IncrementDueDate = Convert.ToString(txtIncrementDueDate.Text).Trim();

        if (DDLIncrementMonth.SelectedIndex > 0)
        {
            objEmployeeOtherDetails.IncrementMonth = Convert.ToString(DDLIncrementMonth.SelectedValue).Trim();
        }
        else
        {
            objEmployeeOtherDetails.IncrementMonth = "";
        }
        objEmployeeOtherDetails.IdentityCardValidity = Convert.ToString(txtIdentityCardValidUpto.Text).Trim();

        if (txtSalaryCalculationDays.Text != "")
        {
            objEmployeeOtherDetails.SalaryCalculationDays = Convert.ToInt32(txtSalaryCalculationDays.Text);
        }
        else
        {
            objEmployeeOtherDetails.SalaryCalculationDays = 0;
        }

        if (txtGeneralWorkingHours.Text != "")
        {
            objEmployeeOtherDetails.GeneralWorkingHours = Convert.ToInt32(txtGeneralWorkingHours.Text);
        }
        else
        {
            objEmployeeOtherDetails.GeneralWorkingHours = 0;
        }

        if (txtOTCalculationDays.Text != "")
        {
            objEmployeeOtherDetails.OTCalculationDays = Convert.ToInt32(txtOTCalculationDays.Text);
        }
        else
        {
            objEmployeeOtherDetails.OTCalculationDays = 0;
        }

        if (txtOTWorkingHours.Text != "")
        {
            objEmployeeOtherDetails.OTWorkingHours = Convert.ToInt32(txtOTWorkingHours.Text);
        }
        else
        {
            objEmployeeOtherDetails.OTWorkingHours = 0;
        }

        if (txtTotalWorkingDaysInMonth.Text != "")
        {
            objEmployeeOtherDetails.TotalDaysInMonth = Convert.ToInt32(txtTotalWorkingDaysInMonth.Text);
        }
        else
        {
            objEmployeeOtherDetails.TotalDaysInMonth = 0;
        }

        if (Session["OthrId"] != null)
        {
            objEmployeeOtherDetails.EmployeeOtherId = Convert.ToInt32(Session["OthrId"].ToString());
        }
        else
        {
            objEmployeeOtherDetails.EmployeeOtherId = 0;
        }

        objEmployeeOtherDetails.CreatedBy = Convert.ToString(Session["LoginId"]).Trim();
        objEmployeeOtherDetails.ModifiedBy = Convert.ToString(Session["LoginId"]).Trim();
    }
    #endregion

    #region Selected index Change
    protected void DDLCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLCountry.SelectedIndex > 0 && DDLCountry.SelectedValue != "")
        {
            BindState(Convert.ToString(DDLCountry.SelectedValue).Trim());
            DDLState.Focus();
        }
        else
        {
            lblMsg.Text = "Please Select Country";
            DDLState.Items.Clear();
            DDLCountry.Focus();
        }
    }

    protected void DDLPermanentCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLPermanentCountry.SelectedIndex > 0 && DDLPermanentCountry.SelectedValue != "")
        {
            BindPermanentState(Convert.ToString(DDLPermanentCountry.SelectedValue).Trim());
            DDLPermanentState.Focus();
        }
        else
        {
            lblMsg.Text = "Please Select Country";
            DDLPermanentCountry.Focus();
            DDLPermanentState.Items.Clear();
        }
    }

    protected void DDLDeduction_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (DDLDeduction.SelectedIndex > 0)
        //{
        //    DataTable dt = new DataTable();
        //    dt = objBindComboMasterManager.BindDeductions();
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            if (Convert.ToString(dr["Deductions"]).Trim() == Convert.ToString(DDLDeduction.Text).Trim())
        //            {
        //                txtPercentage.Text = Convert.ToString(dr["DeductionPercentage"]);
        //                txtAmount4Deduction.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(dr["DeductionPercentage"])));
        //            }
        //        }
        //    }
        //}
    }

    //Leave Tab Selected index changed Function
    protected void ddlPayMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = 0;
        foreach (GridViewRow grd in grdEmployeeMasterDetails.Rows)
        {
            DropDownList ddlPayMode = (DropDownList)grd.FindControl("ddlPayMode");
            CheckBox chk_Allowance = (CheckBox)grd.FindControl("chk_Allowance");
            if (chk_Allowance.Checked == true)
            {
                if (ddlPayMode.SelectedIndex > 0)
                {

                    ddlPayMode.SelectedIndex = ddlPayMode.SelectedIndex;
                    index = ddlPayMode.SelectedIndex;
                    
                    foreach (GridViewRow grd1 in grdDeduction.Rows)
                    {
                        DropDownList ddlPayMode4D = (DropDownList)grd1.FindControl("ddlPayMode4D");
                        CheckBox chk_Deductions = (CheckBox)grd1.FindControl("chk_Deductions");

                        if (chk_Deductions.Checked == true)
                        {
                            ddlPayMode4D.SelectedIndex = index;
                        }
                    }
                }
                else
                {
                    ddlPayMode.SelectedIndex = index;
                }
            }
        }
    }

    protected void ddlPayMode4D_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = 0;
        foreach (GridViewRow grd in grdDeduction.Rows)
        {
            DropDownList ddlPayMode4D = (DropDownList)grd.FindControl("ddlPayMode4D");
            CheckBox chk_Deductions = (CheckBox)grd.FindControl("chk_Deductions");

            if (chk_Deductions.Checked == true)
            {
                if (ddlPayMode4D.SelectedIndex > 0)
                {
                    ddlPayMode4D.SelectedIndex = ddlPayMode4D.SelectedIndex;
                    index = ddlPayMode4D.SelectedIndex;
                }
                else
                {
                    ddlPayMode4D.SelectedIndex = index;
                }
            }
        }
    }

    protected void ddlContractPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlContractPeriod.SelectedValue != "")
        {
            if (Convert.ToString(txtContrctPeriod.Text).Trim() != "")
            {
                if (Convert.ToString(ddlContractPeriod.SelectedValue).Trim() == "M")
                {
                    DateTime dt = new DateTime(Convert.ToInt32(txtContractStartDate.Text.Split('/')[2]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[1]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[0])).AddMonths(Convert.ToInt16(txtContrctPeriod.Text));
                    txtContractEndDate.Text = dt.ToString("dd/MM/yyyy");
                    txtSalaryStopAfter.Text = dt.ToString("dd/MM/yyyy");
                }
                else if (Convert.ToString(ddlContractPeriod.SelectedValue).Trim() == "Y")
                {
                    DateTime dt = new DateTime(Convert.ToInt32(txtContractStartDate.Text.Split('/')[2]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[1]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[0])).AddYears(Convert.ToInt16(txtContrctPeriod.Text));
                    txtContractEndDate.Text = dt.ToString("dd/MM/yyyy");
                    txtSalaryStopAfter.Text = dt.ToString("dd/MM/yyyy");
                }
                //DateTime dt = new DateTime(Convert.ToInt32(txtContractStartDate.Text.Split('/')[2]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[1]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[0])).AddYears(Convert.ToInt16(txtContrctPeriod.Text));
                //txtContractEndDate.Text = dt.ToString("dd/MM/yyyy");
                //txtSalaryStopAfter.Text = dt.ToString("dd/MM/yyyy");
            }
            else
            {
                txtContrctPeriod.Text = "0";
                //DateTime dt = new DateTime(Convert.ToInt32(txtContractStartDate.Text.Split('/')[2]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[1]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[0])).AddYears(Convert.ToInt16(txtContrctPeriod.Text));
                //txtContractEndDate.Text = dt.ToString("dd/MM/yyyy");
                //txtSalaryStopAfter.Text = dt.ToString("dd/MM/yyyy");
                if (Convert.ToString(ddlContractPeriod.SelectedValue).Trim() == "M")
                {
                    DateTime dt = new DateTime(Convert.ToInt32(txtContractStartDate.Text.Split('/')[2]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[1]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[0])).AddMonths(Convert.ToInt16(txtContrctPeriod.Text));
                    txtContractEndDate.Text = dt.ToString("dd/MM/yyyy");
                    txtSalaryStopAfter.Text = dt.ToString("dd/MM/yyyy");
                }
                else if (Convert.ToString(ddlContractPeriod.SelectedValue).Trim() == "Y")
                {
                    DateTime dt = new DateTime(Convert.ToInt32(txtContractStartDate.Text.Split('/')[2]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[1]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[0])).AddYears(Convert.ToInt16(txtContrctPeriod.Text));
                    txtContractEndDate.Text = dt.ToString("dd/MM/yyyy");
                    txtSalaryStopAfter.Text = dt.ToString("dd/MM/yyyy");
                }
            }
        }
        
    }
    #endregion

    #region Text Box Change Events
    protected void txtUnit_TextChanged(object sender, EventArgs e)
    {
        if (txtUnit.Text != "")
        {
            txtLocation4Job.Text = txtUnit.Text;
            txtSubUnit.Focus();
        }
    }

    protected void txtEsiNo_TextChanged(object sender, EventArgs e)
    {
        if (txtEsiNo.Text != "")
        {
            txtAliasName.Focus();
        }
    }

    protected void txt_Amount_TextChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
        TextBox txt_Amount = (TextBox)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("txt_Amount");

        if (Convert.ToString(txt_Amount.Text).Trim() != "")
        {
            foreach (GridViewRow grd in grdDeduction.Rows)
            {
                CheckBox chk_Deductions = (CheckBox)grd.FindControl("chk_Deductions");
                TextBox txt_Percentage = (TextBox)grd.FindControl("txt_Percentage");
                TextBox txt_Amount4D = (TextBox)grd.FindControl("txt_Amount4D");
                DropDownList ddlCalcOn4D = (DropDownList)grd.FindControl("ddlCalcOn4D");
                DropDownList ddlPayMode4D = (DropDownList)grd.FindControl("ddlPayMode4D");
                CheckBox chk_Limit = (CheckBox)grd.FindControl("chk_Limit");
                TextBox txt_LimitAmount = (TextBox)grd.FindControl("txt_LimitAmount");

                if (chk_Deductions.Checked == true)
                {
                    if (chk_Deductions.Text == "EPF" || chk_Deductions.Text == "ESI")
                    {
                        txt_Amount4D.Enabled = false;
                    }
                    else
                    {
                        txt_Amount4D.Enabled = true;
                    }

                    if (chk_Deductions.Text == "ESI")
                    {
                        chk_Limit.Enabled = false;
                        if (GetBasicPay() > 15000)
                        {
                            txt_Amount4D.Text = "0.0000";
                        }
                        else
                        {
                            //txt_Amount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
                            txt_Amount4D.Text = Convert.ToString(CalculateESIDeductions(Convert.ToDouble(txt_Percentage.Text)));
                        }
                    }
                    else
                    {
                        //if (chk_Limit.Checked == true)
                        //{
                        //    txt_Amount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
                        //    chk_Limit.Enabled = true;
                        //}
                        //else
                        //{ 

                        //}

                        if (chk_Limit.Checked == true)
                        {
                            if (chk_Deductions.Text == "ESI")
                            {
                                if (GetBasicPay() > 15000)
                                {
                                    txt_Amount4D.Text = "0.0000";
                                }
                                else
                                {
                                    //txt_Amount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
                                    txt_Amount4D.Text = Convert.ToString(CalculateESIDeductions(Convert.ToDouble(txt_Percentage.Text)));
                                }
                            }
                            else
                            {
                                txt_LimitAmount.Visible = true;
                                if (txt_LimitAmount.Text != "")
                                {
                                    txt_Amount4D.Text = Convert.ToString(CalculateDeductionsOnLimit(Convert.ToDouble(txt_Percentage.Text), Convert.ToDouble(txt_LimitAmount.Text)));
                                }
                                else
                                {
                                    txt_LimitAmount.Text = "6500.00";
                                    txt_Amount4D.Text = Convert.ToString(CalculateDeductionsOnLimit(Convert.ToDouble(txt_Percentage.Text), Convert.ToDouble(txt_LimitAmount.Text)));
                                }
                            }
                        }
                        else
                        {

                            txt_LimitAmount.Text = "";
                            txt_LimitAmount.Visible = false;

                            if (chk_Deductions.Text == "ESI")
                            {
                                if (GetBasicPay() > 15000)
                                {
                                    txt_Amount4D.Text = "0.0000";
                                }
                                else
                                {
                                    txt_Amount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
                                }
                            }
                            else
                            {
                                txt_Amount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
                            }
                        }
                    }

                    ddlCalcOn4D.Enabled = true;
                    ddlPayMode4D.Enabled = true;
                    ddlPayMode4D.SelectedIndex = 0;
                    //chk_Limit.Enabled = true;
                    txt_LimitAmount.Enabled = true;
                }
                else
                {
                    ddlCalcOn4D.Enabled = false;
                    ddlPayMode4D.Enabled = false;
                    ddlPayMode4D.SelectedIndex = 0;
                    txt_Amount4D.Text = "0";
                    txt_Amount4D.Enabled = false;
                    chk_Limit.Enabled = false;
                    txt_LimitAmount.Enabled = false;
                    txt_Amount4D.Text = "";
                }

                dt4Deductions = (DataTable)Session["EmployeeDeduction"];
                dt4Deductions.AcceptChanges();
                Session["EmployeeDeduction"] = (DataTable)dt4Deductions;
            }
        }
        else
        {
            txt_Amount.Text = "0";
            lblMsg.Text = "Please Enter Amount.";
        }

    }

    protected void txt_LimitAmount_TextChanged(object sender, EventArgs e)
    {
        int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
        TextBox txt_LimitAmount = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_LimitAmount");
        TextBox txt_Amount4D = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_Amount4D");
        TextBox txt_Percentage = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_Percentage");

        if (txt_LimitAmount.Text == "")
        {
            txt_LimitAmount.Text = "0.0000";
            txt_Amount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
        }
    }

    //protected void txtJoiningDate_TextChanged(object sender, EventArgs e)
    //{
    //    if (txtJoiningDate.Text != "" && txtJoiningDate.Text != "&nbsp;")
    //    {
    //        txtConfirmationDate.Text = txtJoiningDate.Text;
    //        txtContractStartDate.Text = txtJoiningDate.Text;
    //        txtAppointMentLetterIssueDate.Text = txtJoiningDate.Text;
    //        txtContractEndDate.Text = GetContractEndDate(txtContractStartDate.Text);
    //        txtSalaryStopAfter.Text = GetContractEndDate(txtContractStartDate.Text);
    //        txtPFStartDate.Text = txtJoiningDate.Text;
    //        txtESIStartDate.Text = txtJoiningDate.Text;
    //        txtEPSStartDate.Text = txtJoiningDate.Text;
    //    }
    //    else
    //    {
    //        txtConfirmationDate.Text = "";
    //        txtAppointMentLetterIssueDate.Text = "";
    //        txtContractStartDate.Text = "";
    //        txtContractEndDate.Text = "";
    //        txtSalaryStopAfter.Text = "";
    //        txtPFStartDate.Text = "";
    //        txtESIStartDate.Text = "";
    //        txtEPSStartDate.Text = "";
    //    }
    //}

    //protected void txtContractStartDate_TextChanged(object sender, EventArgs e)
    //{
    //    txtContractEndDate.Text = GetContractEndDate(txtContractStartDate.Text);
    //    txtSalaryStopAfter.Text = GetContractEndDate(txtContractStartDate.Text);
    //}

    //protected void txtContrctPeriod_TextChanged(object sender, EventArgs e)
    //{
    //    if (txtContrctPeriod.Text != "")
    //    {
    //        txtContractEndDate.Text = GetContractEndDate(txtContractStartDate.Text);
    //        txtSalaryStopAfter.Text = GetContractEndDate(txtContractStartDate.Text);
    //    }
    //    else
    //    {
    //        txtContrctPeriod.Text = "0";
    //        txtContractEndDate.Text = GetContractEndDate(txtContractStartDate.Text);
    //        txtSalaryStopAfter.Text = GetContractEndDate(txtContractStartDate.Text);
    //    }
    //}

    protected void txtJoiningDate_TextChanged(object sender, EventArgs e)
    {
        if (txtJoiningDate.Text != "" && txtJoiningDate.Text != "&nbsp;")
        {
            

            DateTime JoiningDate = Convert.ToDateTime(clsConvert.ToDateTime1(txtJoiningDate.Text));
            DateTime InterviewDate = Convert.ToDateTime(clsConvert.ToDateTime1(txtInterViewDate.Text));
            if (JoiningDate < InterviewDate)
            {
                txtConfirmationDate.Text = "";
                txtAppointMentLetterIssueDate.Text = "";
                txtContractStartDate.Text = "";
                txtContractEndDate.Text = "";
                txtSalaryStopAfter.Text = "";
                txtPFStartDate.Text = "";
                txtESIStartDate.Text = "";
                txtEPSStartDate.Text = "";
                txtJoiningDate.Text = "";
                txtJoiningDate.Focus();
                lblMsg.Text = "Please ensure that the Interview Date is greater than or equal to the Joining Date.";
                txtContractStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtContractEndDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtDateOfTransfer.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtPFStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtEPSStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtESIStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //Response.Write("<script type='text/javascript'>alert('Invalid Date.');</script>");
                
            }
            else
            {
                lblMsg.Text = "";

                txtConfirmationDate.Text = txtJoiningDate.Text;
                txtContractStartDate.Text = txtJoiningDate.Text;
                txtAppointMentLetterIssueDate.Text = txtJoiningDate.Text;

                //txtContractEndDate.Text = GetContractEndDate(txtContractStartDate.Text);
                //txtSalaryStopAfter.Text = GetContractEndDate(txtContractStartDate.Text);
                DateTime dt = new DateTime(Convert.ToInt32(txtContractStartDate.Text.Split('/')[2]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[1]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[0])).AddMonths(Convert.ToInt16(txtContrctPeriod.Text));
                txtContractEndDate.Text = dt.ToString("dd/MM/yyyy");
                txtSalaryStopAfter.Text = dt.ToString("dd/MM/yyyy");


                txtPFStartDate.Text = txtJoiningDate.Text;
                txtESIStartDate.Text = txtJoiningDate.Text;
                txtEPSStartDate.Text = txtJoiningDate.Text;
            }
        }
        else
        {
            txtConfirmationDate.Text = "";
            txtAppointMentLetterIssueDate.Text = "";
            txtContractStartDate.Text = "";
            txtContractEndDate.Text = "";
            txtSalaryStopAfter.Text = "";
            txtPFStartDate.Text = "";
            txtESIStartDate.Text = "";
            txtEPSStartDate.Text = "";
        }
    }

    protected void txtContractStartDate_TextChanged(object sender, EventArgs e)
    {
        // txtContractEndDate.Text = GetContractEndDate(txtContractStartDate.Text);
        // txtSalaryStopAfter.Text = GetContractEndDate(txtContractStartDate.Text);
        DateTime dt = new DateTime(Convert.ToInt32(txtContractStartDate.Text.Split('/')[2]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[1]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[0])).AddMonths(Convert.ToInt16(txtContrctPeriod.Text));
        txtContractEndDate.Text = dt.ToString("dd/MM/yyyy");
        txtSalaryStopAfter.Text = dt.ToString("dd/MM/yyyy");
    }

    protected void txtContrctPeriod_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(txtContrctPeriod.Text).Trim() != "")
        {
            if (Convert.ToString(ddlContractPeriod.SelectedValue).Trim() == "M")
            {
                DateTime dt = new DateTime(Convert.ToInt32(txtContractStartDate.Text.Split('/')[2]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[1]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[0])).AddMonths(Convert.ToInt16(txtContrctPeriod.Text));
                txtContractEndDate.Text = dt.ToString("dd/MM/yyyy");
                txtSalaryStopAfter.Text = dt.ToString("dd/MM/yyyy");
            }
            else if (Convert.ToString(ddlContractPeriod.SelectedValue).Trim() == "Y")
            {
                DateTime dt = new DateTime(Convert.ToInt32(txtContractStartDate.Text.Split('/')[2]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[1]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[0])).AddYears(Convert.ToInt16(txtContrctPeriod.Text));
                txtContractEndDate.Text = dt.ToString("dd/MM/yyyy");
                txtSalaryStopAfter.Text = dt.ToString("dd/MM/yyyy");
            }
        }
        else
        {
            if (Convert.ToString(ddlContractPeriod.SelectedValue).Trim() == "M")
            {
                txtContrctPeriod.Text = "0";
                DateTime dt = new DateTime(Convert.ToInt32(txtContractStartDate.Text.Split('/')[2]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[1]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[0])).AddMonths(Convert.ToInt16(txtContrctPeriod.Text));
                txtContractEndDate.Text = dt.ToString("dd/MM/yyyy");
                txtSalaryStopAfter.Text = dt.ToString("dd/MM/yyyy");
            }
            else if (Convert.ToString(ddlContractPeriod.SelectedValue).Trim() == "Y")
            {

                txtContrctPeriod.Text = "0";
                DateTime dt = new DateTime(Convert.ToInt32(txtContractStartDate.Text.Split('/')[2]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[1]), Convert.ToInt32(txtContractStartDate.Text.Split('/')[0])).AddYears(Convert.ToInt16(txtContrctPeriod.Text));
                txtContractEndDate.Text = dt.ToString("dd/MM/yyyy");
                txtSalaryStopAfter.Text = dt.ToString("dd/MM/yyyy");
            }

        }
    }
    #endregion

    #region Checkbox Change Event
    protected void chk_Allowance_CheckChanged(object sender, EventArgs e)
    {
        int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox chk_Allowance = (CheckBox)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("chk_Allowance");
        TextBox txt_Amount = (TextBox)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("txt_Amount");
        DropDownList DDLCalcOn = (DropDownList)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("DDLCalcOn");
        DropDownList DDLpayMode = (DropDownList)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("DDLpayMode");
        CheckBox chk_Bonus = (CheckBox)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("chk_Bonus");
        CheckBox chk_OT = (CheckBox)grdEmployeeMasterDetails.Rows[selRowIndex].FindControl("chk_OT");

        if (chk_Allowance.Checked == true)
        {
            txt_Amount.Text = "0";
            txt_Amount.Enabled = true;
            DDLCalcOn.Enabled = true;
            DDLpayMode.Enabled = true;
            DDLpayMode.SelectedIndex = 0;
            chk_Bonus.Enabled = true;
            chk_OT.Enabled = true;
        }
        else
        {
            txt_Amount.Text = "";
            txt_Amount.Enabled = false;
            DDLCalcOn.Enabled = false;
            DDLpayMode.Enabled = false;
            DDLpayMode.SelectedIndex = 0;
            chk_Bonus.Enabled = false;
            chk_OT.Enabled = false;
        }

        dt4Allowances = (DataTable)Session["EmployeeEarning"];
        dt4Allowances.AcceptChanges();
        Session["EmployeeEarning"] = (DataTable)dt4Allowances;
    }

    protected void chk_Deductions_CheckChanged(object sender, EventArgs e)
    {
        int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox chk_Deductions = (CheckBox)grdDeduction.Rows[selRowIndex].FindControl("chk_Deductions");
        TextBox txt_Percentage = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_Percentage");
        TextBox txt_Amount4D = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_Amount4D");
        DropDownList ddlCalcOn4D = (DropDownList)grdDeduction.Rows[selRowIndex].FindControl("ddlCalcOn4D");
        DropDownList ddlPayMode4D = (DropDownList)grdDeduction.Rows[selRowIndex].FindControl("ddlPayMode4D");
        CheckBox chk_Limit = (CheckBox)grdDeduction.Rows[selRowIndex].FindControl("chk_Limit");
        TextBox txt_LimitAmount = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_LimitAmount");

        if (chk_Deductions.Checked == true)
        {
            if (chk_Deductions.Text == "EPF" || chk_Deductions.Text == "ESI")
            {
                txt_Amount4D.Enabled = false;
            }
            else
            {
                txt_Amount4D.Enabled = true;
            }

            if (chk_Deductions.Text == "ESI")
            {
                chk_Limit.Enabled = false;
                if (GetBasicPay() > 15000)
                {
                    txt_Amount4D.Text = "0.0000";
                }
                else
                {
                    //txt_Amount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
                    txt_Amount4D.Text = Convert.ToString(CalculateESIDeductions(Convert.ToDouble(txt_Percentage.Text)));
                }
            }
            else
            {
                txt_Amount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
                chk_Limit.Enabled = true;
            }

            ddlCalcOn4D.Enabled = true;
            ddlPayMode4D.Enabled = true;
            ddlPayMode4D.SelectedIndex = 0;
            //chk_Limit.Enabled = true;
            txt_LimitAmount.Enabled = true;
        }
        else
        {
            ddlCalcOn4D.Enabled = false;
            ddlPayMode4D.Enabled = false;
            ddlPayMode4D.SelectedIndex = 0;
            txt_Amount4D.Text = "0";
            txt_Amount4D.Enabled = false;
            chk_Limit.Enabled = false;
            txt_LimitAmount.Visible = false;
            txt_LimitAmount.Enabled = false;
            txt_Amount4D.Text = "";
        }

        dt4Deductions = (DataTable)Session["EmployeeDeduction"];
        dt4Deductions.AcceptChanges();
        Session["EmployeeDeduction"] = (DataTable)dt4Deductions;
    }

    protected void chk_LeaveTypeId_CheckChanged(object sender, EventArgs e)
    {
        int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox chk_LeaveTypeId = (CheckBox)grdLeave.Rows[selRowIndex].FindControl("chk_LeaveTypeId");
        TextBox txt_Opening = (TextBox)grdLeave.Rows[selRowIndex].FindControl("txt_Opening");
        RadioButtonList rbtn_MonthlyEarnedType = (RadioButtonList)grdLeave.Rows[selRowIndex].FindControl("rbtn_MonthlyEarnedType");
        TextBox txt_MonthlyEarned = (TextBox)grdLeave.Rows[selRowIndex].FindControl("txt_MonthlyEarned");

        if (chk_LeaveTypeId.Checked == true)
        {
            rbtn_MonthlyEarnedType.Enabled = true;
            txt_MonthlyEarned.Enabled = true;
        }
        else
        {
            rbtn_MonthlyEarnedType.Enabled = false;
            txt_MonthlyEarned.Enabled = false;
        }

        dt4Leave = (DataTable)Session["EmployeeLeave"];
        dt4Leave.AcceptChanges();
        Session["EmployeeLeave"] = (DataTable)dt4Leave;
    }

    protected void chk_Class_CheckChanged(object sender, EventArgs e)
    {
        int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox chk_Class = (CheckBox)grdQualification.Rows[selRowIndex].FindControl("chk_Class");
        TextBox txt_ClassName = (TextBox)grdQualification.Rows[selRowIndex].FindControl("txt_ClassName");
        TextBox txt_PassingYear = (TextBox)grdQualification.Rows[selRowIndex].FindControl("txt_PassingYear");
        TextBox txtCollegeOrUniversityName = (TextBox)grdQualification.Rows[selRowIndex].FindControl("txtCollegeOrUniversityName");
        TextBox txtSubject = (TextBox)grdQualification.Rows[selRowIndex].FindControl("txtSubject");
        TextBox txtPercentage = (TextBox)grdQualification.Rows[selRowIndex].FindControl("txtPercentage");

        if (chk_Class.Checked == true)
        {
            txt_ClassName.Enabled = true;
            txt_PassingYear.Enabled = true;
            txtCollegeOrUniversityName.Enabled = true;
            txtSubject.Enabled = true;
            txtPercentage.Enabled = true;
        }
        else
        {
            txt_ClassName.Enabled = false;
            txt_PassingYear.Enabled = false;
            txtCollegeOrUniversityName.Enabled = false;
            txtSubject.Enabled = false;
            txtPercentage.Enabled = false;
        }

        dt4Leave = (DataTable)Session["ClassName"];
        dt4Leave.AcceptChanges();
        Session["ClassName"] = (DataTable)dt4Leave;
    }

    protected void chkLeaveValidation_CheckedChanged(object sender, EventArgs e)
    {
        if (chkLeaveValidation.Checked == true)
        {
            txtEarningLeaveAllowdAfter.Enabled = true;
            DDLEarningLeaveAllowed.Enabled = true;
            chkOnlyLastYearConsumed.Enabled = true;
            txtCasualLeaveAllowedAfter.Enabled = true;
            DDLCasualLeaveAllowedAfter.Enabled = true;
            chkCLConsumedinCurrentYear.Enabled = true;
        }
        else
        {
            txtEarningLeaveAllowdAfter.Enabled = false;
            DDLEarningLeaveAllowed.Enabled = false;
            chkOnlyLastYearConsumed.Enabled = false;
            txtCasualLeaveAllowedAfter.Enabled = false;
            DDLCasualLeaveAllowedAfter.Enabled = false;
            chkCLConsumedinCurrentYear.Enabled = false;
        }
    }

    protected void chkLimit_CheckedChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        int selRowIndex = ((GridViewRow)(((CheckBox)sender).Parent.Parent)).RowIndex;
        CheckBox chk_Deductions = (CheckBox)grdDeduction.Rows[selRowIndex].FindControl("chk_Deductions");
        CheckBox chk_Limit = (CheckBox)grdDeduction.Rows[selRowIndex].FindControl("chk_Limit");
        TextBox txt_LimitAmount = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_LimitAmount");
        TextBox txt_Amount4D = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_Amount4D");
        TextBox txt_Percentage = (TextBox)grdDeduction.Rows[selRowIndex].FindControl("txt_Percentage");

        if (chk_Limit.Checked == true)
        {
            if (chk_Deductions.Text == "ESI")
            {
                if (GetBasicPay() > 15000)
                {
                    txt_Amount4D.Text = "0.0000";
                }
                else
                {
                    //txt_Amount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
                    txt_Amount4D.Text = Convert.ToString(CalculateESIDeductions(Convert.ToDouble(txt_Percentage.Text)));
                }
            }
            else
            {
                txt_LimitAmount.Visible = true;
                if (txt_LimitAmount.Text != "")
                {
                    txt_Amount4D.Text = Convert.ToString(CalculateDeductionsOnLimit(Convert.ToDouble(txt_Percentage.Text), Convert.ToDouble(txt_LimitAmount.Text)));
                }
                else
                {
                    txt_LimitAmount.Text = "6500.00";
                    txt_Amount4D.Text = Convert.ToString(CalculateDeductionsOnLimit(Convert.ToDouble(txt_Percentage.Text), Convert.ToDouble(txt_LimitAmount.Text)));
                }
            }
        }
        else
        {

            txt_LimitAmount.Text = "";
            txt_LimitAmount.Visible = false;

            if (chk_Deductions.Text == "ESI")
            {
                if (GetBasicPay() > 15000)
                {
                    txt_Amount4D.Text = "0.0000";
                }
                else
                {
                    txt_Amount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
                }
            }
            else
            {
                txt_Amount4D.Text = Convert.ToString(CalculateDeductions(Convert.ToDouble(txt_Percentage.Text)));
            }
        }
    }
    #endregion

    #region Grid Events
    //Allowances Grid
    protected void grdEmployeeMasterDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            CheckBox chk_Allowance = ((CheckBox)e.Row.FindControl("chk_Allowance"));
            TextBox txt_Amount = ((TextBox)e.Row.FindControl("txt_Amount"));
            DropDownList DDLCalcOn = ((DropDownList)e.Row.FindControl("DDLCalcOn"));
            DropDownList DDLpayMode = ((DropDownList)e.Row.FindControl("DDLpayMode"));
            CheckBox chk_Bonus = ((CheckBox)e.Row.FindControl("chk_Bonus"));
            CheckBox chk_OT = ((CheckBox)e.Row.FindControl("chk_OT"));

            BindPaymentMode(DDLpayMode);
            BindCalcOn(DDLCalcOn);

            if (chk_Allowance.Checked == true)
            {
                txt_Amount.Enabled = true;
                DDLCalcOn.Enabled = true;
                DDLpayMode.Enabled = true;
                chk_Bonus.Enabled = true;
                chk_OT.Enabled = true;
            }
            else
            {
                txt_Amount.Enabled = false;
                DDLCalcOn.Enabled = false;
                DDLpayMode.Enabled = false;
                chk_Bonus.Enabled = false;
                chk_OT.Enabled = false;
            }
        }
    }

    protected void grdEmployeeMasterDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            lblMsg.Text = "";
            int pageSize = grdEmployeeMasterDetails.PageSize;
            int pageIndex = grdEmployeeMasterDetails.PageIndex;
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            int newRowIndex = 0;

            if (pageIndex > 0)
            {
                newRowIndex = pageIndex * pageSize;
                index = index - newRowIndex;
            }
           
            CheckBox chk_Allowance = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[2].FindControl("chk_Allowance");
            TextBox txt_Amount = (TextBox)grdEmployeeMasterDetails.Rows[index].Cells[3].FindControl("txt_Amount");
            DropDownList DDLCalcOn = (DropDownList)grdEmployeeMasterDetails.Rows[index].Cells[4].FindControl("DDLCalcOn");
            DropDownList DDLpayMode = (DropDownList)grdEmployeeMasterDetails.Rows[index].Cells[5].FindControl("DDLpayMode");
            CheckBox chk_Bonus = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[6].FindControl("chk_Bonus");
            CheckBox chk_OT = (CheckBox)grdEmployeeMasterDetails.Rows[index].Cells[7].FindControl("chk_OT");

            TabContainer1.ActiveTabIndex = 1;

            if (chk_Allowance.Checked == true)
            {
                txt_Amount.Enabled = true;
                DDLCalcOn.Enabled = true;
                DDLpayMode.Enabled = true;
                chk_Bonus.Enabled = true;
                chk_OT.Enabled = true;
            }
            else
            {
                txt_Amount.Enabled = false;
                DDLCalcOn.Enabled = false;
                DDLpayMode.Enabled = false;
                chk_Bonus.Enabled = false;
                chk_OT.Enabled = false;
            }

            ////DataTable dt = new DataTable();
            ////dt = (DataTable)Session["EmployeeMasterDetails"];
            ////if (dt != null)
            ////{
            ////    if (dt.Rows.Count > 0)
            ////    {
            ////        foreach (DataRow dr in dt.Rows)
            ////        {
            ////            if (Convert.ToString(dr["Allowances"]).Trim() == "Gross basic Pay")
            ////            {
            ////                txtgBasicPay.Text = Convert.ToString(dr["Amount"]).Trim();
            ////                Session["Amount"] = Convert.ToString(dr["Amount"]).Trim();
            ////            }
            ////        }
            ////    }
            ////}
        }
    }

    protected void grdEmployeeMasterDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdEmployeeMasterDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }

    //Deduction Grid
    protected void grdDeduction_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            CheckBox chk_Deductions = ((CheckBox)e.Row.FindControl("chk_Deductions"));
            TextBox txt_Percentage = ((TextBox)e.Row.FindControl("txt_Percentage"));
            TextBox txt_Amount4D = ((TextBox)e.Row.FindControl("txt_Amount4D"));
            DropDownList ddlCalcOn4D = ((DropDownList)e.Row.FindControl("ddlCalcOn4D"));
            DropDownList ddlPayMode4D = ((DropDownList)e.Row.FindControl("ddlPayMode4D"));
            CheckBox chk_Limit = ((CheckBox)e.Row.FindControl("chk_Limit"));
            TextBox txt_LimitAmount = ((TextBox)e.Row.FindControl("txt_LimitAmount"));

            BindPaymentMode4Deductions(ddlPayMode4D);
            BindCalcOnDeductions(ddlCalcOn4D);

            chk_Deductions.Checked = true;


            if (chk_Deductions.Text == "EPF")
            {
                chk_Limit.Enabled = true;
                chk_Limit.Checked = true;
                txt_LimitAmount.Enabled = true;
                txt_LimitAmount.Visible = true;
                txt_LimitAmount.Text = "6500.0000";
            }
            else
            {
                chk_Limit.Enabled = false;
                chk_Limit.Checked = false;
                txt_LimitAmount.Enabled = false;
                txt_LimitAmount.Visible=false;
            }

            //if (chk_Deductions.Checked == true)
            //{
            //    ddlCalcOn4D.Enabled = true;
            //    ddlPayMode4D.Enabled = true;
            //    chk_Limit.Enabled = true;
            //    txt_LimitAmount.Enabled = true;
            //}
            //else
            //{
            //    ddlCalcOn4D.Enabled = false;
            //    ddlPayMode4D.Enabled = false;
            //    chk_Limit.Enabled = false;
            //    txt_LimitAmount.Enabled = false;
            //}
        }
    }

    protected void grdDeduction_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            lblMsg.Text = "";
            int pageSize = grdEmployeeMasterDetails.PageSize;
            int pageIndex = grdEmployeeMasterDetails.PageIndex;
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            int newRowIndex = 0;

            if (pageIndex > 0)
            {
                newRowIndex = pageIndex * pageSize;
                index = index - newRowIndex;
            }
            
        }
    }

    protected void grdDeduction_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdDeduction_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    //Leave Type Grid
    protected void grdLeave_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            CheckBox chk_LeaveTypeId = ((CheckBox)e.Row.FindControl("chk_LeaveTypeId"));
            TextBox txt_Opening = ((TextBox)e.Row.FindControl("txt_Opening"));
            RadioButtonList rbtn_MonthlyEarnedType = ((RadioButtonList)e.Row.FindControl("rbtn_MonthlyEarnedType"));
            TextBox txt_MonthlyEarned = ((TextBox)e.Row.FindControl("txt_MonthlyEarned"));

            if (chk_LeaveTypeId.Checked == true)
            {
                rbtn_MonthlyEarnedType.Enabled = true;
                txt_MonthlyEarned.Enabled = true;
            }
            else
            {
                rbtn_MonthlyEarnedType.Enabled = false;
                txt_MonthlyEarned.Enabled = false;
            }
        }
    }

    protected void grdLeave_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            lblMsg.Text = "";
            int pageSize = grdEmployeeMasterDetails.PageSize;
            int pageIndex = grdEmployeeMasterDetails.PageIndex;
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            int newRowIndex = 0;

            if (pageIndex > 0)
            {
                newRowIndex = pageIndex * pageSize;
                index = index - newRowIndex;
            }
            //Label lblEmpId = ((Label)grdLeave.Rows[EmpId].FindControl("lbl_EmployeeId"));
            //ViewState["EmployeeLeaveId"] = DtEmployeeLeaveDetailsManager.Tables[0].Rows[0]["EmployeeLeaveId"].ToString();
        }
    }

    protected void grdLeave_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdLeave_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    //Employee Qualification
    protected void grdQualification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = ((DataRowView)e.Row.DataItem);
            CheckBox chk_Class = ((CheckBox)e.Row.FindControl("chk_Class"));
            TextBox txt_ClassName = ((TextBox)e.Row.FindControl("txt_ClassName"));
            TextBox txt_PassingYear = ((TextBox)e.Row.FindControl("txt_PassingYear"));
            TextBox txtCollegeOrUniversityName = ((TextBox)e.Row.FindControl("txtCollegeOrUniversityName"));
            TextBox txtSubject = ((TextBox)e.Row.FindControl("txtSubject"));
            TextBox txtPercentage = ((TextBox)e.Row.FindControl("txtPercentage"));

            if (chk_Class.Checked == true)
            {
                txt_ClassName.Enabled = true;
                txt_PassingYear.Enabled = true;
                txtCollegeOrUniversityName.Enabled = true;
                txtSubject.Enabled = true;
                txtPercentage.Enabled = true;
            }
            else
            {
                txt_ClassName.Enabled = false;
                txt_PassingYear.Enabled = false;
                txtCollegeOrUniversityName.Enabled = false;
                txtSubject.Enabled = false;
                txtPercentage.Enabled = false;
            }
        }
    }

    protected void grdQualification_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            lblMsg.Text = "";
            int pageSize = grdEmployeeMasterDetails.PageSize;
            int pageIndex = grdEmployeeMasterDetails.PageIndex;
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            int newRowIndex = 0;

            if (pageIndex > 0)
            {
                newRowIndex = pageIndex * pageSize;
                index = index - newRowIndex;
            }
        }
    }

    protected void grdQualification_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdQualification_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    #endregion

    #region Other Function
    public int GetEmployeeCode()
    {
        int EmployeeCode = 0;
        DataSet ds4EmployeeId = new DataSet();
        try
        {
            ds4EmployeeId = objEmployeeMasterManager.GenerateEmployeeCode();
            if (ds4EmployeeId != null)
            {
                EmployeeCode = Convert.ToInt32(ds4EmployeeId.Tables[0].Rows[0]["EmployeeId"]) + 1;
            }

        }
        catch (Exception ex)
        {
            EmployeeCode = EmployeeCode + 1;
        }
        return EmployeeCode;
    }
   
    public int GetEmployeeDeductionId()
    {
        int EmployeeDeductionId = 0;
        DataSet ds4EmployeeDeductionId = new DataSet();
        try
        {
            ds4EmployeeDeductionId = objEmployeeDeductionDetailsManager.GetMaxEmployeeDeductionId();
            if (ds4EmployeeDeductionId != null)
            {
                EmployeeDeductionId = Convert.ToInt32(ds4EmployeeDeductionId.Tables[0].Rows[0]["EmployeeDeductionId"]) + 1;
            }

        }
        catch (Exception ex)
        {
            EmployeeDeductionId = EmployeeDeductionId + 1;
        }
        return EmployeeDeductionId;
    }
    
    public int GetEmployeeEarningId()
    {
        int EmployeeEarningId = 0;
        DataSet ds4EmployeeEarningId = new DataSet();
        try
        {
            ds4EmployeeEarningId = objEmployeeEarningDetailsManager.GetMaxEmployeeEarningId();
            if (ds4EmployeeEarningId != null)
            {
                EmployeeEarningId = Convert.ToInt32(ds4EmployeeEarningId.Tables[0].Rows[0]["EmployeeEarningId"]) + 1;
            }

        }
        catch (Exception ex)
        {
            EmployeeEarningId = EmployeeEarningId + 1;
        }
        return EmployeeEarningId;
    }

    public int GetEmployeeLeaveId()
    {
        int EmployeeLeaveId = 0;
        DataSet ds4EmployeeLeaveId = new DataSet();
        try
        {
            ds4EmployeeLeaveId = objEmployeeLeaveDetailsManager.GetMaxEmployeeLeaveId();
            if (ds4EmployeeLeaveId != null)
            {
                EmployeeLeaveId = Convert.ToInt32(ds4EmployeeLeaveId.Tables[0].Rows[0]["EmployeeLeaveId"]) + 1;
            }

        }
        catch (Exception ex)
        {
            EmployeeLeaveId = EmployeeLeaveId + 1;
        }
        return EmployeeLeaveId;
    }

    public int GetEmployeeQualificationId()
    {
        int EmployeeQualificationId = 0;
        DataSet ds4EmployeeQualificationId = new DataSet();
        try
        {
            ds4EmployeeQualificationId = objEmployeeQualificationDetailsManager.GetMaxEmployeeQualificationId();
            if (ds4EmployeeQualificationId != null)
            {
                EmployeeQualificationId = Convert.ToInt32(ds4EmployeeQualificationId.Tables[0].Rows[0]["EmployeeQualificationId"]) + 1;
            }

        }
        catch (Exception ex)
        {
            EmployeeQualificationId = EmployeeQualificationId + 1;
        }
        return EmployeeQualificationId;
    }

    public int GetItemNo4Earning()
    {
        int Itemno = 0;
        dt4EmployeeEarning = (DataTable)Session["EmployeeEarning"];
        if (dt4EmployeeEarning != null)
        {
            Itemno = Convert.ToInt32(dt4EmployeeEarning.Rows.Count) + 1;
        }
        else
        {
            Itemno = Itemno + 1;
        }
        return Itemno;
    }

    public int GetItemNo4Deduction()
    {
        int Itemno = 0;
        dt4EmployeeDeduction = (DataTable)Session["EmployeeDeduction"];
        if (dt4EmployeeDeduction != null)
        {
            Itemno = Convert.ToInt32(dt4EmployeeDeduction.Rows.Count) + 1;
        }
        else
        {
            Itemno = Itemno + 1;
        }
        return Itemno;
    }

    public int GetItemNo4Leave()
    {
        int Itemno = 0;
        dt4EmployeeLeaveDetails = (DataTable)Session["EmployeeLeave"];
        if (dt4EmployeeLeaveDetails != null)
        {
            Itemno = Convert.ToInt32(dt4EmployeeLeaveDetails.Rows.Count) + 1;
        }
        else
        {
            Itemno = Itemno + 1;
        }
        return Itemno;
    }
    #endregion

    #region Calculation
    public double CalculateDeductions(double Percentage)
    {
        DataTable dt = new DataTable();
        double deductionAmount = 0.0;
        try
        {
            foreach (GridViewRow grd in grdEmployeeMasterDetails.Rows)
            {
                CheckBox chk_Allowance = (CheckBox)grd.FindControl("chk_Allowance");
                TextBox txt_Amount = (TextBox)grd.FindControl("txt_Amount");

                if (Convert.ToString(chk_Allowance.Text) == "BASIC")
                {
                    deductionAmount = Math.Round((Convert.ToDouble(txt_Amount.Text) * Percentage) / 100);
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString(); ;
        }
        return deductionAmount;
    }

    public double CalculateESIDeductions(double Percentage)
    {
        DataTable dt = new DataTable();
        double deductionAmount = 0.0;
        try
        {
            //foreach (GridViewRow grd in grdEmployeeMasterDetails.Rows)
            //{
                //CheckBox chk_Allowance = (CheckBox)grd.FindControl("chk_Allowance");
                //TextBox txt_Amount = (TextBox)grd.FindControl("txt_Amount");

                //if (chk_Allowance.Checked ==true)
                //{
                    deductionAmount = Math.Round(Math.Ceiling((Convert.ToDouble(GetBasicPay() * Percentage) / 100)));
            //    }
            //}
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString(); ;
        }
        return deductionAmount;
    }

    public double CalculateDeductionsOnLimit(double Percentage, double LimitAmount)
    {
        DataTable dt = new DataTable();
        double deductionAmount = 0.0;
        try
        {
            foreach (GridViewRow grd in grdEmployeeMasterDetails.Rows)
            {
                CheckBox chk_Allowance = (CheckBox)grd.FindControl("chk_Allowance");
                TextBox txt_Amount = (TextBox)grd.FindControl("txt_Amount");
                if (Convert.ToString(chk_Allowance.Text) == "BASIC")
                {
                    if (LimitAmount > Convert.ToDouble(txt_Amount.Text))
                    {
                        deductionAmount = (Convert.ToDouble(txt_Amount.Text) * Percentage) / 100;
                    }
                    else
                    {
                        if (LimitAmount != 0.0000)
                        {
                            deductionAmount = Math.Round((LimitAmount * Percentage) / 100);
                        }
                        else
                        {
                            deductionAmount = Math.Round((Convert.ToDouble(txt_Amount.Text) * Percentage) / 100);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString(); ;
        }
        return deductionAmount;
    }

    public double GetBasicPay()
    {
        DataTable dt = new DataTable();
        double GrossBasicPay = 0.0;
        try
        {
            foreach (GridViewRow grd in grdEmployeeMasterDetails.Rows)
            {
                CheckBox chk_Allowance = (CheckBox)grd.FindControl("chk_Allowance");
                TextBox txt_Amount = (TextBox)grd.FindControl("txt_Amount");

                if (chk_Allowance.Checked ==true)
                {
                    GrossBasicPay = Math.Round(GrossBasicPay + Convert.ToDouble(txt_Amount.Text));
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.ToString(); ;
        }
        return GrossBasicPay;
    }

    public string GetContractEndDate(string ContractStartDate)
    {
        string ContractEndDate = "";
        try
        {
            DateTime dt = DateTime.Now;

            if (ContractStartDate != "")
            {
                dt = Convert.ToDateTime(ContractStartDate);

                if (Convert.ToString(ddlContractPeriod.SelectedValue).Trim() == "M")
                {
                    if (Convert.ToInt32(txtContrctPeriod.Text) > 0)
                    {
                        dt = dt.AddMonths(Convert.ToInt32(txtContrctPeriod.Text));
                        ContractEndDate = dt.AddDays(-1).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        if (Convert.ToInt32(txtContrctPeriod.Text) <= 0)
                        {
                            txtContrctPeriod.Text = "0";
                            dt = dt.AddMonths(Convert.ToInt32(txtContrctPeriod.Text));
                            ContractEndDate = dt.ToString("dd/MM/yyyy");
                        }
                    }
                }
                else if (Convert.ToString(ddlContractPeriod.SelectedValue).Trim() == "Y")
                {
                    if (Convert.ToInt32(txtContrctPeriod.Text) > 0)
                    {
                        dt = dt.AddYears(Convert.ToInt32(txtContrctPeriod.Text));
                        ContractEndDate = dt.AddDays(-1).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        if (Convert.ToInt32(txtContrctPeriod.Text) <= 0)
                        {
                            txtContrctPeriod.Text = "0";
                            dt = dt.AddYears(Convert.ToInt32(txtContrctPeriod.Text));
                            ContractEndDate = dt.AddDays(-1).ToString("dd/MM/yyyy");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
        return ContractEndDate;
    }
    #endregion

    #region Check Validation
    public bool CheckValidation()
    {
        bool IsTrue=true;
        if (DDlEmployeeType.SelectedIndex == 0)
        {
            lblMsg.Text = "Please Select EmployeeType";
            IsTrue = false;
        }
        return IsTrue; 
    }
    #endregion

    #region Next & Previous Button Click
    protected void lbtnBack_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex=0 ;
    }

    protected void lbtnNext_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 1;
    }

    protected void lbtnBackFromJob_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 0;
    }

    protected void lbtnNextFromJob_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 2;
    }

    protected void lbtnBackFromQualification_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 1;
    }

    protected void lbtnNextFromQualification_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 3;
    }

    protected void lbtnBackFromEarning_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 2;
    }

    protected void lbtnNextFromEarning_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 4;
    }

    protected void lbtnBackFromDeduction_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 3;
    }

    protected void lbtnNextFromDeduction_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 5;
    }

    protected void lbtnBackFromLeave_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 4;
    }

    protected void lbtnNextFromLeave_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 6;
    }

    protected void lbtnBackFromLeft_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 5;
    }

    protected void lbtnNextFromLeft_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 7;
    }

    protected void lbtnBackFromOthers_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 6;
    }

    protected void lbtnNextFromOthers_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 0;
    }
    #endregion
}