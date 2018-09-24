<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taRegionTypes.aspx.vb" Inherits="EF_taRegionTypes" title="Edit: Region Types" %>
<asp:Content ID="CPHtaRegionTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaRegionTypes" runat="server" Text="&nbsp;Edit: Region Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaRegionTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaRegionTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taRegionTypes"
    runat = "server" />
<asp:FormView ID="FVtaRegionTypes"
  runat = "server"
  DataKeyNames = "RegionTypeID"
  DataSourceID = "ODStaRegionTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RegionTypeID" runat="server" ForeColor="#CC6633" Text="Region Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RegionTypeID"
            Text='<%# Bind("RegionTypeID") %>'
            ToolTip="Value of Region Type ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="70px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RegionTypeName" runat="server" Text="Region Type Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RegionTypeName"
            Text='<%# Bind("RegionTypeName") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taRegionTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Region Type Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVRegionTypeName"
            runat = "server"
            ControlToValidate = "F_RegionTypeName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taRegionTypes"
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
  ID = "ODStaRegionTypes"
  DataObjectTypeName = "SIS.TA.taRegionTypes"
  SelectMethod = "taRegionTypesGetByID"
  UpdateMethod="UZ_taRegionTypesUpdate"
  DeleteMethod="taRegionTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taRegionTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RegionTypeID" Name="RegionTypeID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
