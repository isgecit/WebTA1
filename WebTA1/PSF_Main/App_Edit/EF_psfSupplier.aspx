<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_psfSupplier.aspx.vb" Inherits="EF_psfSupplier" title="Edit: Supplier" %>
<asp:Content ID="CPHpsfSupplier" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpsfSupplier" runat="server" Text="&nbsp;Edit: Supplier"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpsfSupplier" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpsfSupplier"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "psfSupplier"
    runat = "server" />
<asp:FormView ID="FVpsfSupplier"
  runat = "server"
  DataKeyNames = "SupplierID"
  DataSourceID = "ODSpsfSupplier"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SupplierID" runat="server" ForeColor="#CC6633" Text="Supplier ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SupplierID"
            Text='<%# Bind("SupplierID") %>'
            ToolTip="Value of Supplier ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="63px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierName" runat="server" Text="Supplier Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SupplierName"
            Text='<%# Bind("SupplierName") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfSupplier"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Supplier Name."
            MaxLength="100"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSupplierName"
            runat = "server"
            ControlToValidate = "F_SupplierName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfSupplier"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BankName" runat="server" Text="Bank Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BankName"
            Text='<%# Bind("BankName") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfSupplier"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Bank Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVBankName"
            runat = "server"
            ControlToValidate = "F_BankName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfSupplier"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BranchAddress" runat="server" Text="Branch Address :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BranchAddress"
            Text='<%# Bind("BranchAddress") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfSupplier"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Branch Address."
            MaxLength="200"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVBranchAddress"
            runat = "server"
            ControlToValidate = "F_BranchAddress"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfSupplier"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BankAccountNo" runat="server" Text="Bank Account No :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BankAccountNo"
            Text='<%# Bind("BankAccountNo") %>'
            Width="105px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfSupplier"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Bank Account No."
            MaxLength="15"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVBankAccountNo"
            runat = "server"
            ControlToValidate = "F_BankAccountNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfSupplier"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IFSCCode" runat="server" Text="IFSC Code :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IFSCCode"
            Text='<%# Bind("IFSCCode") %>'
            Width="105px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfSupplier"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IFSC Code."
            MaxLength="15"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVIFSCCode"
            runat = "server"
            ControlToValidate = "F_IFSCCode"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfSupplier"
            SetFocusOnError="true" />
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
  ID = "ODSpsfSupplier"
  DataObjectTypeName = "SIS.PSF.psfSupplier"
  SelectMethod = "psfSupplierGetByID"
  UpdateMethod="UZ_psfSupplierUpdate"
  DeleteMethod="psfSupplierDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PSF.psfSupplier"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SupplierID" Name="SupplierID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
