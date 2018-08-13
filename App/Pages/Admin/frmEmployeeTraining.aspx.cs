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
//Shruti Dwivedi(09-10-2013)
#endregion Development Details

public partial class Pages_Admin_frmEmployeeTraining : System.Web.UI.Page
{
    #region Global Variable Declaration
    EmployeeMasterDetailsManager _objEmployeeMasterDetailsManager = new EmployeeMasterDetailsManager();
    TrainingMaster _objTrainingMaster = new TrainingMaster();
    TrainingMasterManager _objTrainingMasterManager = new TrainingMasterManager();
    TrainingEmployee _objTrainingEmployee = new TrainingEmployee();
    TrainingEmployeeManager _objTrainingEmployeeManager = new TrainingEmployeeManager();
    DataTable dt4TrainingDetails = new DataTable();
    #endregion Global Variable Declaration
    
    
    
    #region Page Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            SetObjectInfo(_objTrainingMaster);
            CheckBox chkSelect = new CheckBox();
            if (btnSave.Text == "Update")
            {
                _objTrainingMaster.TrainingId = Convert.ToInt32(Request.QueryString["TrainingId"]);
                foreach (ErrorHandlerClass err in _objTrainingMasterManager.UpdateTrainingMaster(_objTrainingMaster, SetObjectInfo4TrainingEmployee()))
                {
                    if (err.Type == "E")
                    {
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Text = err.Message.ToString();
                        break;
                    }
                    else if (err.Type == "A")
                    {
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Text = err.Message.ToString();
                        break;
                    }
                    else
                    {
                        if (lblMsg.Text.ToString() == "")
                        {
                            lblMsg.ForeColor = Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            Response.Redirect("frmListTraineeMaster.aspx", false);
                        }
                    }

                }
            }
            else
            {
                foreach (ErrorHandlerClass err in _objTrainingMasterManager.SaveTrainingMaster(_objTrainingMaster, SetObjectInfo4TrainingEmployee()))
                {
                    if (err.Type == "E")
                    {
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Text = err.Message.ToString();
                        break;
                    }
                    else if (err.Type == "A")
                    {
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Text = err.Message.ToString();
                        break;
                    }
                    else
                    {
                        if (lblMsg.Text.ToString() == "")
                        {
                            lblMsg.ForeColor = Color.Green;
                            lblMsg.Text = err.Message.ToString();
                            Response.Redirect("frmListTraineeMaster.aspx", false);
                        }
                    }

                }
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["TrainingId"] != null)
                {
                    string str = Request.QueryString["TrainingId"];
                    DataTable _dt = _objTrainingMasterManager.GetTrainingMasterById(Convert.ToInt32(Request.QueryString["TrainingId"])).Tables[0];
                    _objTrainingMaster.SetObjectInfo(_dt.Rows[0]);
                    AssignVariableToControl(_objTrainingMaster);
                    BindEmployeeList(Convert.ToInt32(Request.QueryString["TrainingId"]));
                }
                else
                {
                    BindEmployeeList(Convert.ToInt32(null));
                }
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }
    }
    #endregion Page Event

    #region Page Specific Event
    private void BindEmployeeList(Int32 TrainingId)
    {
        //DataTable dt4TrainingDetails = _objEmployeeMasterDetailsManager.GetEmployeeMaster().Tables[0];
        DataTable dt4TrainingDetails = _objTrainingMasterManager.GetEmployeeMaster(TrainingId).Tables[0];
        gdvTrainingEmployee.DataSource = dt4TrainingDetails;
        gdvTrainingEmployee.DataBind();
        Session["TrainingDetails"] = dt4TrainingDetails;
    }

    private void SetObjectInfo(TrainingMaster _objTrainingMaster)
    {
        _objTrainingMaster.Traning_Subject = txtSubject.Text;
        _objTrainingMaster.StarDate = Convert.ToDateTime(txtStartDate.Text);
        _objTrainingMaster.EndDate = Convert.ToDateTime(txtEndDate.Text);
        _objTrainingMaster.Traning_Hour = Convert.ToInt32(txtHour.Text);
        _objTrainingMaster.Traning_Minute = Convert.ToInt32(txtMinute.Text);
        _objTrainingMaster.Traning_Description = txtDescription.Text;
    }
    
    public ICollection<TrainingEmployee> SetObjectInfo4TrainingEmployee()
    {
        List<TrainingEmployee> lst = new List<TrainingEmployee>();
        TrainingEmployee _objTrainingEmployee = null;
        //int itemNo = 1;


        for (int i = 0; i < gdvTrainingEmployee.Rows.Count; i++)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gdvTrainingEmployee.Rows[i].FindControl("chkSelect");
            Label EmployeeId = (Label)gdvTrainingEmployee.Rows[i].FindControl("gdvlblId");
            if (chk.Checked)
            {
                _objTrainingEmployee = new TrainingEmployee();

                _objTrainingEmployee.CreatedBy = Session["LoginId"].ToString();
                _objTrainingEmployee.ModifiedBy = Session["LoginId"].ToString();
                _objTrainingEmployee.EmployeeId = EmployeeId.Text;
                _objTrainingEmployee.CreatedDate = DateTime.Now.ToString();
                _objTrainingEmployee.ModifiedDate = DateTime.Now.ToString();
                lst.Add(_objTrainingEmployee);

            }
        }

        return lst;
    }

    private void AssignVariableToControl(TrainingMaster _objTrainingMaster)
    {
        txtSubject.Text = _objTrainingMaster.Traning_Subject;
        txtStartDate.Text = Convert.ToDateTime(_objTrainingMaster.StarDate).ToString().Split(' ')[0];
        txtEndDate.Text = Convert.ToDateTime(_objTrainingMaster.EndDate).ToString().Split(' ')[0];
        txtHour.Text = _objTrainingMaster.Traning_Hour.ToString();
        txtMinute.Text = _objTrainingMaster.Traning_Minute.ToString();
        txtDescription.Text = _objTrainingMaster.Traning_Description;
    }
    #endregion Page Specific Event
}