<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogLocationCountries.aspx.vb" Inherits="EF_elogLocationCountries" title="Edit: Location Country" %>
<asp:Content ID="CPHelogLocationCountries" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogLocationCountries" runat="server" Text="&nbsp;Edit: Location Country"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogLocationCountries" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogLocationCountries"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "elogLocationCountries"
    runat = "server" />
<asp:FormView ID="FVelogLocationCountries"
  runat = "server"
  DataKeyNames = "LocationCountryID"
  DataSourceID = "ODSelogLocationCountries"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_LocationCountryID" runat="server" ForeColor="#CC6633" Text="Location Country :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_LocationCountryID"
            Text='<%# Bind("LocationCountryID") %>'
            ToolTip="Value of Location Country."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogLocationCountries"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogLocationCountries"
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
  ID = "ODSelogLocationCountries"
  DataObjectTypeName = "SIS.ELOG.elogLocationCountries"
  SelectMethod = "elogLocationCountriesGetByID"
  UpdateMethod="elogLocationCountriesUpdate"
  DeleteMethod="elogLocationCountriesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogLocationCountries"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="LocationCountryID" Name="LocationCountryID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
