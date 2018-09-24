<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taCityTypes.aspx.vb" Inherits="AF_taCityTypes" title="Add: City Types" %>
<asp:Content ID="CPHtaCityTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaCityTypes" runat="server" Text="&nbsp;Add: City Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaCityTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaCityTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taCityTypes"
    runat = "server" />
<asp:FormView ID="FVtaCityTypes"
  runat = "server"
  DataKeyNames = "CityTypeID"
  DataSourceID = "ODStaCityTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaCityTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CityTypeID" ForeColor="#CC6633" runat="server" Text="City Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CityTypeID"
            Text='<%# Bind("CityTypeID") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="taCityTypes"
            onblur= "script_taCityTypes.validate_CityTypeID(this);"
            ToolTip="Enter value for City Type ID."
            MaxLength="6"
            Width="42px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCityTypeID"
            runat = "server"
            ControlToValidate = "F_CityTypeID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCityTypes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CityTypeName" runat="server" Text="City Type Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CityTypeName"
            Text='<%# Bind("CityTypeName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taCityTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for City Type Name."
            MaxLength="50"
            Width="350px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaCityTypes"
  DataObjectTypeName = "SIS.TA.taCityTypes"
  InsertMethod="taCityTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taCityTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
