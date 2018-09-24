<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RP_tempES.aspx.vb" Inherits="RP_tempES" title="PERK: Opening Balance Reference" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title></title>
<style type = "text/css" >
 table{ border: solid 1pt black;}
 td {padding-left: 4px; padding-right: 4px;}
.grpHD{background-color:#666666;
  border: 1pt solid #000000;
 color:#FFFFFF;
 }
.colHD{background-color:#808080;
  border: 1pt solid #333333;
  color:#000000;
}
.rowHD
{  font-family: Tahoma;
  font-size:10px;
  }
</style>
</head>
<body>
 <div id = "div1" style="margin:20px">
<form id = "form1" runat="server">
<div id="frmdiv" class="ui-widget-content minipage">
  <asp:DataList ID="DataListSep" runat="server" DataSourceID="ODSSep">
    <HeaderTemplate>
      <asp:Label ID="LabelEntSep" runat="server" Text="Perks Details Up to Sep 2017" Font-Size="14pt" Font-Bold="False" style="text-transform:uppercase;" Font-Underline="True"></asp:Label>
      <br />
      <asp:Label ID="Label1" runat="server" Text="Perks Details Up to Sep 2017" Font-Size="10pt">Balance of Medical Benefit as on 31/3/18, & Balances of car Maint/ Two Wheeler Maint., Petrol, News paper, Uniform, Club subscription  as on 30/9/17 carried forwarded  in Vehicle Running and Maintenance and Medical Balance A/c</asp:Label>
      <br />
      <asp:Table ID="TblHdrSep" runat="server" CssClass="spltab1">
        <asp:TableRow runat="server">
          <asp:TableCell runat="server" Width="50px" Font-Bold="True">Type</asp:TableCell>
          <asp:TableCell runat="server" Width="100px" Font-Bold="True">Date</asp:TableCell>
          <asp:TableCell runat="server" Width="300px" Font-Bold="True">Particulars</asp:TableCell>
          <asp:TableCell runat="server" Width="100px" Font-Bold="True" CssClass="alignright">Debit</asp:TableCell>
          <asp:TableCell runat="server" Width="100px" Font-Bold="True" CssClass="alignright">Credit</asp:TableCell>
        </asp:TableRow>
      </asp:Table>
    </HeaderTemplate>
    <ItemTemplate>
      <LGM:LC_PrkBalanceSep 
        ID="LC_PrkBalanceSep1" 
        PerkID='<%# Eval("PerkID") %>'
        PrintHeading="false"
        OnDataBinding="ShowPerkBalanceSep"
        runat="server" />
    </ItemTemplate>
    <ItemStyle BackColor="Lavender" />
    <HeaderStyle Width="650px" />
  </asp:DataList>
  <asp:ObjectDataSource ID="ODSSep" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="nprkPerksSelectList" 
    TypeName="SIS.NPRK.nprkPerks">
    <SelectParameters>
      <asp:Parameter DefaultValue="PerkID" Name="orderBy" Type="String" />
    </SelectParameters>
  </asp:ObjectDataSource>
</div>
</form>
</div>
</body>
</html>
