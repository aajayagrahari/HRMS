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
//Shruti Dwivedi(16-10-2013)
#endregion Development Details

public partial class Pages_Admin_frmListTraineeMaster : System.Web.UI.Page
{
    #region Global Variable Declaration
    TrainingMasterManager _objTrainingMasterManager = new TrainingMasterManager();
    TrainingMaster _objTrainingMaster = new TrainingMaster();
    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                BindTrainingList();
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.StackTrace;
            lblMsg.ForeColor = Color.Red;
        }

    }
    
    protected void gdvTraineeList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "View")
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<script language='javascript'>");
                sb.Append("window.open('../Admin/frmTrainingEmployeeReport.aspx?TrainingId=" + e.CommandArgument.ToString() + "','CustomPop','height=500,width=900');");
                sb.Append("</script>");
                Type t = this.GetType();
                if (!ClientScript.IsClientScriptBlockRegistered(t, "PopupScript"))
                    ClientScript.RegisterClientScriptBlock(t, "PopupScript", sb.ToString());

            }
            else if (e.CommandName == "Edit")
            {

                //Response.Redirect("frmEmployeeTraining.aspx?TrainingId=" + e.CommandArgument.ToString(), false);
                gdvTraineeList.EditIndex = -1;
                BindTrainingList();
            }
            else
            {
                _objTrainingMaster.TrainingId = Convert.ToInt32(e.CommandArgument.ToString());
                foreach (ErrorHandlerClass err in  _objTrainingMasterManager.DeleteTrainingMaster(_objTrainingMaster))
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
                            gdvTraineeList.EditIndex = -1;
                            BindTrainingList();
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
    #endregion Page Event

    #region Page Specific Event
    private void BindTrainingList()
    {
        DataTable _dt = _objTrainingMasterManager.GetTrainingMaster().Tables[0];
        gdvTraineeList.DataSource = _dt;
        gdvTraineeList.DataBind();
    }
    #endregion Page Specific Event

    protected void gdvTraineeList_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
   
    protected void gdvTraineeList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}