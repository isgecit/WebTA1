<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taCityTypes.aspx.vb" Inherits="EF_taCityTypes" title="Edit: City Types" %>
<asp:Content ID="CPHtaCityTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaCityTypes" runat="server" Text="&nbsp;Edit: City Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaCityTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaCityTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taCityTypes"
    runat = "server" />
<asp:FormView ID="FVtaCityTypes"
  runat = "server"
  DataKeyNames = "CityTypeID"
  DataSourceID = "ODStaCityTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CityTypeID" runat="server" ForeColor="#CC6633" Text="City Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CityTypeID"
            Text='<%# Bind("CityTypeID") %>'
            ToolTip="Value of City Type ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="42px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CityTypeName" runat="server" Text="City Type Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CityTypeName"
            Text='<%# Bind("CityTypeName") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taCityTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for City Type Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCityTypeName"
            runat = "server"
            ControlToValidate = "F_CityTypeName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCityTypes"
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
  ID = "ODStaCityTypes"
  DataObjectTypeName = "SIS.TA.taCityTypes"
  SelectMethod = "taCityTypesGetByID"
  UpdateMethod="taCityTypesUpdate"
  DeleteMethod="taCityTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taCityTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CityTypeID" Name="CityTypeID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
