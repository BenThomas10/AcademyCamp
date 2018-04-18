<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Campers.aspx.cs" Inherits="AcademyCamp.Reports.Campers" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="#CCCCCC" BorderStyle="None" Font-Names="Verdana" Font-Size="8pt" Height="681px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="591px" BorderWidth="1">
            <LocalReport ReportPath="ASPXreports\Campers.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="AllCampers" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Registrants]"></asp:SqlDataSource>
    </form>
</body>
</html>
