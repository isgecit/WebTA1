<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RP_nprkEntitlementSheet.aspx.vb" Inherits="RP_nprkEntitlementSheet" title="Print: Entitlement Sheet" %>
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
  <ASP:ScriptManager ID="ToolkitScriptManager1" EnableScriptGlobalization="true" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="3600" EnableScriptLocalization="True" ScriptMode="Auto">
    <Scripts>
        <asp:ScriptReference Path="/../UserRights/jquery/webkit.js" />
    </Scripts>
  </ASP:ScriptManager>
		<br />
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_EmployeeID" runat="server" Text="Employee :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_EmployeeID"
            CssClass = "myfktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_EmployeeID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_EmployeeID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEEmployeeID"
            BehaviorID="B_ACEEmployeeID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="EmployeeIDCompletionList"
            TargetControlID="F_EmployeeID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEEmployeeID_Selected"
            OnClientPopulating="ACEEmployeeID_Populating"
            OnClientPopulated="ACEEmployeeID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
		<br />
  <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1">
    <HeaderTemplate>
      <asp:Label ID="LabelPrkEntitlements" runat="server" Text="Perks Details" Font-Size="14pt" Font-Bold="False" style="text-transform:uppercase;" Font-Underline="True"></asp:Label>
      <br />
      <br />
      <table style="width: 652px">
        <tr>
          <td id="Td5" runat="server" style=" vertical-align: bottom;" class="m010">
            <LGM:EmployeeInfoForReports ID="UserInfoForReports1" Visible="false" EmployeeToDisplay='<%# EmployeeToDisplay %>'  runat="server" />
          </td>
        </tr>
      </table>
      <asp:Table ID="TblHdr" runat="server" CssClass="spltab1">
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
      <LGM:LC_PrkBalance 
        ID="LC_PrkBalanceAsOn1" 
        PerkID='<%# Eval("PerkID") %>'
        PrintHeading="false"
        OnDataBinding="ShowPerkBalance"
        runat="server" />
    </ItemTemplate>
    <ItemStyle BackColor="Lavender" />
    <HeaderStyle Width="650px" />
  </asp:DataList>
  <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="nprkPerksSelectList" 
    TypeName="SIS.NPRK.nprkPerks">
    <SelectParameters>
      <asp:Parameter DefaultValue="PerkID" Name="orderBy" Type="String" />
    </SelectParameters>
  </asp:ObjectDataSource>
</form>
</div>
</body>
</html>
