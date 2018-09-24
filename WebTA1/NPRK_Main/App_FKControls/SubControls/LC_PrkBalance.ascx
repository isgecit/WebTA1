<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_PrkBalance.ascx.vb" Inherits="LC_PrkBalance" %>
<table style="border: solid 1pt black;">
  <tr>
    <td style="vertical-align: top; background-color: #cccccc"><asp:Table ID="tblEnt" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1pt" GridLines="Both"></asp:Table>
    </td>
    <td style="vertical-align: top; background-color: #cccccc"><asp:Table ID="tblLgr" runat="server" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1pt" GridLines="Both"></asp:Table>
    </td>
   </tr>
  <tr>
    <td class="alignright" style="color: #0000ff; background-color: #999999">NET BALANCE [<asp:Label ID="LabelUOM" runat="server" />]</td>
    <td class="alignright" style="color: #0000ff; background-color: #999999"><asp:Label ID="NetBalance" Font-Bold="true" runat="server"></asp:Label></td>
  </tr>
</table>
