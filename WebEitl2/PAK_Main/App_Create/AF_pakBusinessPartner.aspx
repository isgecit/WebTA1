<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_pakBusinessPartner.aspx.vb" Inherits="AF_pakBusinessPartner" title="Add: Business Partner" %>
<asp:Content ID="CPHpakBusinessPartner" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakBusinessPartner" runat="server" Text="&nbsp;Add: Business Partner"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakBusinessPartner" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakBusinessPartner"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "pakBusinessPartner"
    runat = "server" />
<asp:FormView ID="FVpakBusinessPartner"
  runat = "server"
  DataKeyNames = "BPID"
  DataSourceID = "ODSpakBusinessPartner"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpakBusinessPartner" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BPID" ForeColor="#CC6633" runat="server" Text="BP ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BPID"
            Text='<%# Bind("BPID") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="pakBusinessPartner"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BP ID."
            MaxLength="9"
            Width="80px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVBPID"
            runat = "server"
            ControlToValidate = "F_BPID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakBusinessPartner"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BPName" runat="server" Text="BP Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BPName"
            Text='<%# Bind("BPName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakBusinessPartner"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BP Name."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVBPName"
            runat = "server"
            ControlToValidate = "F_BPName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakBusinessPartner"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Address1Line" runat="server" Text="Address Line [1] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Address1Line"
            Text='<%# Bind("Address1Line") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address Line [1]."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Address2Line" runat="server" Text="Address Line [2] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Address2Line"
            Text='<%# Bind("Address2Line") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address Line [2]."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_City" runat="server" Text="City :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_City"
            Text='<%# Bind("City") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for City."
            MaxLength="50"
            Width="408px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_EMailID" runat="server" Text="E-Mail ID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_EMailID"
            Text='<%# Bind("EMailID") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for E-Mail ID."
            MaxLength="200"
            Width="350px" Height="40px" TextMode="MultiLine"
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
  ID = "ODSpakBusinessPartner"
  DataObjectTypeName = "SIS.PAK.pakBusinessPartner"
  InsertMethod="pakBusinessPartnerInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakBusinessPartner"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
