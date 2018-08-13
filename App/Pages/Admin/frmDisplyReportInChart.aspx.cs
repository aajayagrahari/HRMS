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
//Shruti Dwivedi(19-11-2013)
#endregion Development Details

public partial class Pages_Admin_frmDisplyReportInChart : System.Web.UI.Page
{
    #region Global Variable Declaration
    ChartMasterManager _objChartMasterManager = new ChartMasterManager();
    #endregion Global Variable Declaration

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                ////---------Chart1----------------------
                //DataTable _dt = _objChartMasterManager.LeaveChart().Tables[0];
                //Chart1.DataSource = _dt;
                //Chart1.Series[0].YValueMembers = "LeaveAllowed";
                //Chart1.Series[0].IsValueShownAsLabel = true;
                //Chart1.Series[1].YValueMembers = "LeaveTypeId";

                //Chart1.Series[0].XValueMember = "LeaveTypeId";
                //Chart1.ChartAreas["ChartArea1"].AxisY.Interval = 1;
                //Chart1.DataBind();
                ////---------Chart1----------------------



                ////---------Chart2----------------------
                //DataTable _dt2 = _objChartMasterManager.DesignationChart().Tables[0];
                //Chart2.DataSource = _dt2;
                //Chart2.Series[0].YValueMembers = "EmployeeId";
                //Chart2.Series[0].XValueMember = "Designation";
                //Chart2.ChartAreas["ChartArea2"].AxisY.Interval = 1;
                //Chart2.DataBind();
                ////---------Chart2----------------------


                ////---------Chart3----------------------
                //DataTable _dt3 = _objChartMasterManager.DepartmentChart().Tables[0];
                //Chart3.DataSource = _dt3;
                //Chart3.Series[0].YValueMembers = "EmployeeId";
                //Chart3.Series[0].XValueMember = "Department";
                //Chart3.ChartAreas["ChartArea3"].AxisY.Interval = 1;
                //Chart3.DataBind();
                ////---------Chart3----------------------

                ////---------Chart4----------------------
                //DataTable _dt4 = _objChartMasterManager.YearlyJoinChart().Tables[0];
                //Chart4.DataSource = _dt4;
                //Chart4.Series[0].YValueMembers = "EmployeeId";
                //Chart4.Series[0].IsValueShownAsLabel = true;
                //Chart4.Series[0].XValueMember = "JoiningDate";
                //Chart4.ChartAreas["ChartArea4"].AxisY.Interval = 1;
                //Chart4.DataBind();
                ////---------Chart4----------------------

            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }

    }
    protected void ddlChart_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlChart.SelectedValue == "Chart1")
            {
                Chart1.Visible = true;
                DataTable _dt = _objChartMasterManager.LeaveChart().Tables[0];
                Chart1.DataSource = _dt;
                Chart1.Series[0].YValueMembers = "LeaveAllowed";
                Chart1.Series[0].IsValueShownAsLabel = true;
                Chart1.Series[1].YValueMembers = "LeaveTypeId";

                Chart1.Series[0].XValueMember = "LeaveTypeId";
                Chart1.ChartAreas["ChartArea1"].AxisY.Interval = 2;
                Chart1.DataBind();
            }
            else if (ddlChart.SelectedValue == "Chart2")
            {
                Chart2.Visible = true;
                DataTable _dt2 = _objChartMasterManager.DesignationChart().Tables[0];
                Chart2.DataSource = _dt2;
                Chart2.Series[0].YValueMembers = "EmployeeId";
                Chart2.Series[0].XValueMember = "Designation";
                Chart2.ChartAreas["ChartArea2"].AxisY.Interval = 1;
                Chart2.DataBind();
            }
            else if (ddlChart.SelectedValue == "Chart3")
            {
                Chart3.Visible = true;
                DataTable _dt3 = _objChartMasterManager.DepartmentChart().Tables[0];
                Chart3.DataSource = _dt3;
                Chart3.Series[0].YValueMembers = "EmployeeId";
                Chart3.Series[0].XValueMember = "Department";
                Chart3.ChartAreas["ChartArea3"].AxisY.Interval = 1;
                Chart3.DataBind();
            }
            else if (ddlChart.SelectedValue == "Chart4")
            {
                //Chart4.Visible = true;
                //DataTable _dt4 = _objChartMasterManager.YearlyJoinChart().Tables[0];
                //Chart4.DataSource = _dt4;
                //Chart4.Series[0].YValueMembers = "EmployeeId";
                //Chart4.Series[0].IsValueShownAsLabel = true;
                //Chart4.Series[0].XValueMember = "JoiningDate";
                //Chart4.ChartAreas["ChartArea4"].AxisY.Interval = 1;
                //Chart4.DataBind();


                Chart4.Visible = true;
                DataTable _dt4 = _objChartMasterManager.YearlyJoinChart().Tables[0];
                Chart4.DataSource = _dt4;
                Chart4.Series[0].YValueMembers = "EmployeeId";
               // Chart4.Series[0].IsValueShownAsLabel = true;
                Chart4.Legends.IsUniqueName("ABC...............");
                Chart4.Series[0].XValueMember = "JoiningDate";
                Chart4.ChartAreas["ChartArea4"].AxisY.Interval = 2;
                Chart4.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "" + ex.Message.ToString();
        }
    }
    #endregion Page Event

    #region Page Specific Event
    
    #endregion Page Specific Event

   
}