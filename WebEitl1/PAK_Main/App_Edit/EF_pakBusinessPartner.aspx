<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakBusinessPartner.aspx.vb" Inherits="EF_pakBusinessPartner" title="Edit: Business Partner" %>
<asp:Content ID="CPHpakBusinessPartner" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakBusinessPartner" runat="server" Text="&nbsp;Edit: Business Partner"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakBusinessPartner" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakBusinessPartner"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "pakBusinessPartner"
    runat = "server" />
<asp:FormView ID="FVpakBusinessPartner"
  runat = "server"
  DataKeyNames = "BPID"
  DataSourceID = "ODSpakBusinessPartner"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BPID" runat="server" ForeColor="#CC6633" Text="BP ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BPID"
            Text='<%# Bind("BPID") %>'
            ToolTip="Value of BP ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="80px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BPName" runat="server" Text="BP Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BPName"
            Text='<%# Bind("BPName") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakBusinessPartner"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BP Name."
            MaxLength="100"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Address1Line" runat="server" Text="Address Line [1] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Address1Line"
            Text='<%# Bind("Address1Line") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address Line [1]."
            MaxLength="100"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Address2Line" runat="server" Text="Address Line [2] :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Address2Line"
            Text='<%# Bind("Address2Line") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address Line [2]."
            MaxLength="100"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_City" runat="server" Text="City :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_City"
            Text='<%# Bind("City") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for City."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_EMailID" runat="server" Text="E-Mail ID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_EMailID"
            Text='<%# Bind("EMailID") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for E-Mail ID."
            MaxLength="200"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakBusinessPartner"
  DataObjectTypeName = "SIS.PAK.pakBusinessPartner"
  SelectMethod = "pakBusinessPartnerGetByID"
  UpdateMethod="pakBusinessPartnerUpdate"
  DeleteMethod="pakBusinessPartnerDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakBusinessPartner"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="BPID" Name="BPID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
