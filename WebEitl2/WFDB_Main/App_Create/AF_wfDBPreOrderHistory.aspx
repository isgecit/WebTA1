<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_wfDBPreOrderHistory.aspx.vb" Inherits="AF_wfDBPreOrderHistory" title="Add: Pre Order History" %>
<asp:Content ID="CPHwfDBPreOrderHistory" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelwfDBPreOrderHistory" runat="server" Text="&nbsp;Add: Pre Order History"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLwfDBPreOrderHistory" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLwfDBPreOrderHistory"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/WFDB_Main/App_Edit/EF_wfDBPreOrderHistory.aspx"
    ValidationGroup = "wfDBPreOrderHistory"
    runat = "server" />
<asp:FormView ID="FVwfDBPreOrderHistory"
  runat = "server"
  DataKeyNames = "WFID"
  DataSourceID = "ODSwfDBPreOrderHistory"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgwfDBPreOrderHistory" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_WFID" ForeColor="#CC6633" runat="server" Text="WFID :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_WFID"
            Text='<%# Bind("WFID") %>'
            Enabled = "False"
            ToolTip="Value of WFID."
            Width="88px"
            CssClass = "dmypktxt"
            style="text-align: Right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Project" runat="server" Text="Project :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Project"
            Text='<%# Bind("Project") %>'
            Enabled = "False"
            ToolTip="Value of Project."
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Element" runat="server" Text="Element :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Element"
            Text='<%# Bind("Element") %>'
            Enabled = "False"
            ToolTip="Value of Element."
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SpecificationNo" runat="server" Text="SpecificationNo :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SpecificationNo"
            Text='<%# Bind("SpecificationNo") %>'
            Enabled = "False"
            ToolTip="Value of SpecificationNo."
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Buyer" runat="server" Text="Buyer :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Buyer"
            Text='<%# Bind("Buyer") %>'
            Enabled = "False"
            ToolTip="Value of Buyer."
            Width="72px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierName" runat="server" Text="SupplierName :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SupplierName"
            Text='<%# Bind("SupplierName") %>'
            Enabled = "False"
            ToolTip="Value of SupplierName."
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Supplier" runat="server" Text="Supplier :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Supplier"
            Text='<%# Bind("Supplier") %>'
            Enabled = "False"
            ToolTip="Value of Supplier."
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Notes" runat="server" Text="Notes :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Notes"
            Text='<%# Bind("Notes") %>'
            Enabled = "False"
            ToolTip="Value of Notes."
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSwfDBPreOrderHistory"
  DataObjectTypeName = "SIS.WFDB.wfDBPreOrderHistory"
  InsertMethod="UZ_wfDBPreOrderHistoryInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.WFDB.wfDBPreOrderHistory"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
