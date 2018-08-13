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
using System.IO;
#region Development Details
// Harendra kumar maurya(14-10-2013)
#endregion Development Details
public partial class Pages_Employee_frmNotice : System.Web.UI.Page
{
    CircularMasterManager objCircularMasterManager = new CircularMasterManager();
    CircularMaster objCircularMaster = new CircularMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCircularMaster();
        }
    }

    void BindCircularMaster()
    {

        DataSet ds = new DataSet();
        ds = objCircularMasterManager.GetCircularMaster4User();

        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_list_circular_master.DataSource = ds.Tables[0];
            gv_list_circular_master.DataBind();

        }
        else
        {

            gv_list_circular_master.DataSource = null;
            gv_list_circular_master.DataBind();
            lblMsg.Text = "Record Not Found !.";
        }
    }
}