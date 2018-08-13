<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Pages_Admin_Test" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ajax:BarChart ID="BarChart1" runat="server" ChartHeight="400" 
            ChartType="StackedBar" ChartWidth="600" ValueAxisLines="0">
        <Series>
        <ajax:BarChartSeries BarColor="Red" Data="10" Name="1st" />
        <ajax:BarChartSeries BarColor="Black" Data="10" Name="2nd" />
        </Series>
        </ajax:BarChart>
    </div>
    </form>
</body>
</html>
