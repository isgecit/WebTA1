<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taRegionTypes.aspx.vb" Inherits="AF_taRegionTypes" title="Add: Region Types" %>
<asp:Content ID="CPHtaRegionTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaRegionTypes" runat="server" Text="&nbsp;Add: Region Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaRegionTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaRegionTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taRegionTypes"
    runat = "server" />
<asp:FormView ID="FVtaRegionTypes"
  runat = "server"
  DataKeyNames = "RegionTypeID"
  DataSourceID = "ODStaRegionTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaRegionTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RegionTypeID" ForeColor="#CC6633" runat="server" Text="Region Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RegionTypeID"
            Text='<%# Bind("RegionTypeID") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="taRegionTypes"
            onblur= "script_taRegionTypes.validate_RegionTypeID(this);"
            ToolTip="Enter value for Region Type ID."
            MaxLength="10"
            Width="70px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVRegionTypeID"
            runat = "server"
            ControlToValidate = "F_RegionTypeID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taRegionTypes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RegionTypeName" runat="server" Text="Region Type Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RegionTypeName"
            Text='<%# Bind("RegionTypeName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taRegionTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Region Type Name."
            MaxLength="50"
            Width="350px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaRegionTypes"
  DataObjectTypeName = "SIS.TA.taRegionTypes"
  InsertMethod="UZ_taRegionTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taRegionTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
