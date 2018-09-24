<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_psfSupplier.aspx.vb" Inherits="AF_psfSupplier" title="Add: Supplier" %>
<asp:Content ID="CPHpsfSupplier" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpsfSupplier" runat="server" Text="&nbsp;Add: Supplier"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpsfSupplier" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpsfSupplier"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "psfSupplier"
    runat = "server" />
<asp:FormView ID="FVpsfSupplier"
  runat = "server"
  DataKeyNames = "SupplierID"
  DataSourceID = "ODSpsfSupplier"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgpsfSupplier" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SupplierID" ForeColor="#CC6633" runat="server" Text="Supplier ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SupplierID"
            Text='<%# Bind("SupplierID") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="psfSupplier"
            onblur= "script_psfSupplier.validate_SupplierID(this);"
            ToolTip="Enter value for Supplier ID."
            MaxLength="9"
            Width="63px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSupplierID"
            runat = "server"
            ControlToValidate = "F_SupplierID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "psfSupplier"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierName" runat="server" Text="Supplier Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SupplierName"
            Text='<%# Bind("SupplierName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfSupplier"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Supplier Name."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BankName" runat="server" Text="Bank Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BankName"
            Text='<%# Bind("BankName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfSupplier"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Bank Name."
            MaxLength="50"
            Width="350px"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BranchAddress" runat="server" Text="Branch Address :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BranchAddress"
            Text='<%# Bind("BranchAddress") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfSupplier"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Branch Address."
            MaxLength="200"
            Width="350px" Height="40px" TextMode="MultiLine"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BankAccountNo" runat="server" Text="Bank Account No :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BankAccountNo"
            Text='<%# Bind("BankAccountNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfSupplier"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Bank Account No."
            MaxLength="15"
            Width="105px"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IFSCCode" runat="server" Text="IFSC Code :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IFSCCode"
            Text='<%# Bind("IFSCCode") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="psfSupplier"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for IFSC Code."
            MaxLength="15"
            Width="105px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpsfSupplier"
  DataObjectTypeName = "SIS.PSF.psfSupplier"
  InsertMethod="UZ_psfSupplierInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PSF.psfSupplier"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
