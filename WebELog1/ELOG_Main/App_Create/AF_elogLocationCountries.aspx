<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_elogLocationCountries.aspx.vb" Inherits="AF_elogLocationCountries" title="Add: Location Country" %>
<asp:Content ID="CPHelogLocationCountries" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogLocationCountries" runat="server" Text="&nbsp;Add: Location Country"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogLocationCountries" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogLocationCountries"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "elogLocationCountries"
    runat = "server" />
<asp:FormView ID="FVelogLocationCountries"
  runat = "server"
  DataKeyNames = "LocationCountryID"
  DataSourceID = "ODSelogLocationCountries"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgelogLocationCountries" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_LocationCountryID" ForeColor="#CC6633" runat="server" Text="Location Country :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_LocationCountryID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogLocationCountries"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            Width="408px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSelogLocationCountries"
  DataObjectTypeName = "SIS.ELOG.elogLocationCountries"
  InsertMethod="elogLocationCountriesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogLocationCountries"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
