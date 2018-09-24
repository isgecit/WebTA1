<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taRegions.aspx.vb" Inherits="EF_taRegions" title="Edit: Regions" %>
<asp:Content ID="CPHtaRegions" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaRegions" runat="server" Text="&nbsp;Edit: Regions"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaRegions" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaRegions"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taRegions"
    runat = "server" />
<asp:FormView ID="FVtaRegions"
  runat = "server"
  DataKeyNames = "RegionID"
  DataSourceID = "ODStaRegions"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RegionID" runat="server" ForeColor="#CC6633" Text="Region ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RegionID"
            Text='<%# Bind("RegionID") %>'
            ToolTip="Value of Region ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="70px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RegionName" runat="server" Text="Region Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RegionName"
            Text='<%# Bind("RegionName") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taRegions"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Region Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVRegionName"
            runat = "server"
            ControlToValidate = "F_RegionName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taRegions"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RegionTypeID" runat="server" Text="Region Type ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_taRegionTypes
            ID="F_RegionTypeID"
            SelectedValue='<%# Bind("RegionTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taRegions"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CurrencyID" runat="server" Text="Currency ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_taCurrencies
            ID="F_CurrencyID"
            SelectedValue='<%# Bind("CurrencyID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "taRegions"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
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
  ID = "ODStaRegions"
  DataObjectTypeName = "SIS.TA.taRegions"
  SelectMethod = "taRegionsGetByID"
  UpdateMethod="UZ_taRegionsUpdate"
  DeleteMethod="taRegionsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taRegions"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RegionID" Name="RegionID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
