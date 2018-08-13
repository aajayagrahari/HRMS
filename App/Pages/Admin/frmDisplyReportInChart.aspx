<%@ Page Title="Display Report in Chart" Language="C#" MasterPageFile="~/Master/Admin.master" AutoEventWireup="true" CodeFile="frmDisplyReportInChart.aspx.cs" Inherits="Pages_Admin_frmDisplyReportInChart" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%" align="center">
<tr><td colspan="2"><asp:Label ID="lblMsg" runat="server"></asp:Label></td></tr>
<tr><td colspan="2"><asp:DropDownList ID="ddlChart" runat="server" 
        AutoPostBack="true" onselectedindexchanged="ddlChart_SelectedIndexChanged">
        <asp:ListItem Value="0">Select</asp:ListItem>
<asp:ListItem Value="Chart1">Leave Chart</asp:ListItem>
<asp:ListItem Value="Chart2">Employee Designation Chart</asp:ListItem>
<asp:ListItem Value="Chart3">Employee Department Chart</asp:ListItem>
<asp:ListItem Value="Chart4">Year wise Employee Joining Chart</asp:ListItem>
</asp:DropDownList></td></tr>
<tr>
<td  >
    <asp:Chart ID="Chart1" runat="server" Height="300" Width="600" charttitle="Sample chart title" Visible="false">
        <Series>
            <asp:Series Name="Series1" ChartType="Bar"
                         ChartArea="ChartArea1" Color="Blue">
         </asp:Series>
          <asp:Series Name="Series2" ChartType="Bar" 
                         ChartArea="ChartArea1" Color="Blue" >
         </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
        <Titles>
            <asp:Title Name="Leave" Text="Leave Chart">
            </asp:Title>
        </Titles>
    </asp:Chart></td>
    <td>
    <asp:Chart ID="Chart4" runat="server" Height="300" Width="500" charttitle="Sample chart title" Visible="false">
        <Series>
            <asp:Series Name="Series1" ChartType="Bar" ChartArea="ChartArea4" Color="Blue" >
         </asp:Series>
         <asp:Series Name="Series2" ChartType="Bar" IsValueShownAsLabel="true" 
                         ChartArea="ChartArea4" Color="Blue" > </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea4">
            </asp:ChartArea>
        </ChartAreas>
        <Titles>
            <asp:Title Name="Leave" Text="Year wise Employee Joining chart">
            </asp:Title>
        </Titles>
    </asp:Chart>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Chart ID="Chart2" runat="server" Height="300" Width="500" 
            charttitle="Sample chart title" Visible="false">
        <Series>
            <asp:Series Name="Series1" ChartType="Pie" ChartArea="ChartArea2" Color="Blue" >
         </asp:Series>
         <asp:Series Name="Series2" ChartType="Pie" IsValueShownAsLabel="true" 
                         ChartArea="ChartArea2" Color="Blue" > </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea2">
            </asp:ChartArea>
        </ChartAreas>
        <Titles>
            <asp:Title Name="Leave" Text="Employee Designation Chart">
            </asp:Title>
        </Titles>
    </asp:Chart>
    </td>
    <td>
     <asp:Chart ID="Chart3" runat="server" Height="300" Width="500" Visible="false" >
        <Series>
            <asp:Series Name="Series1"   ChartType="Pie" ChartArea="ChartArea3" Color="Blue" >
         </asp:Series>
         <asp:Series Name="Series2" ChartType="Pie" IsValueShownAsLabel="true" 
                         ChartArea="ChartArea3" Color="Blue" > </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea3">
            </asp:ChartArea>
        </ChartAreas>
        <Titles>
            <asp:Title Name="Leave" Text="Employee Department Chart">
            </asp:Title>
        </Titles>
         
    </asp:Chart>
    </td>
    </tr>
</table>
   


</asp:Content>

