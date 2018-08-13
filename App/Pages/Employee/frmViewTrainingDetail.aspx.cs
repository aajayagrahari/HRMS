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
using System.Text;

#region Development Details
//Shruti Dwivedi(17-10-2013)
#endregion Development Details

public partial class Pages_Employee_frmViewTrainingDetail : System.Web.UI.Page
{
    #region Global Variable Declaration
    EmployeeMasterDetailsManager _objEmployeeMasterDetailsManager = new EmployeeMasterDetailsManager();
    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMyTrainingGrid();
        }

    }
    #endregion Page Event

    #region Page Specific Function
    private void BindMyTrainingGrid()
    {
        DataTable _dt = new DataTable();
        _dt = _objEmployeeMasterDetailsManager.GetTrainingDetail(Convert.ToString(Session["EmployeeId"].ToString())).Tables[0];
        gdvTrainingDetail.DataSource = _dt;
        gdvTrainingDetail.DataBind();
    }
    #endregion Page Specific Function
}