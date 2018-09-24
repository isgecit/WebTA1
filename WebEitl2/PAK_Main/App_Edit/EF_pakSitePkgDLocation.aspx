<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakSitePkgDLocation.aspx.vb" Inherits="EF_pakSitePkgDLocation" title="Edit: Received Packing List Item Location" %>
<asp:Content ID="CPHpakSitePkgDLocation" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSitePkgDLocation" runat="server" Text="&nbsp;Edit: Received Packing List Item Location"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSitePkgDLocation" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSitePkgDLocation"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "pakSitePkgDLocation"
    runat = "server" />
<asp:FormView ID="FVpakSitePkgDLocation"
  runat = "server"
  DataKeyNames = "ProjectID,RecNo,RecSrNo,RecSrLNo"
  DataSourceID = "ODSpakSitePkgDLocation"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project."
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_RecNo" runat="server" ForeColor="#CC6633" Text="Receipt No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_RecNo"
            Width="88px"
            Text='<%# Bind("RecNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Receipt No."
            Runat="Server" />
          <asp:Label
            ID = "F_RecNo_Display"
            Text='<%# Eval("PAK_SitePkgH8_SupplierRefNo") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RecSrNo" runat="server" ForeColor="#CC6633" Text="Receipt Line No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_RecSrNo"
            Width="88px"
            Text='<%# Bind("RecSrNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Receipt Line No."
            Runat="Server" />
          <asp:Label
            ID = "F_RecSrNo_Display"
            Text='<%# Eval("PAK_SitePkgD7_SiteMarkNo") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_RecSrLNo" runat="server" ForeColor="#CC6633" Text="Receipt Line Location No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_RecSrLNo"
            Text='<%# Bind("RecSrLNo") %>'
            ToolTip="Value of Receipt Line Location No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SerialNo" runat="server" Text="Serial No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SerialNo"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            Enabled = "False"
            ToolTip="Value of Serial No."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("PAK_PO4_PODescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PkgNo" runat="server" Text="Packing List No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_PkgNo"
            Width="88px"
            Text='<%# Bind("PkgNo") %>'
            Enabled = "False"
            ToolTip="Value of Packing List No."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_PkgNo_Display"
            Text='<%# Eval("PAK_PkgListH3_SupplierRefNo") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BOMNo" runat="server" Text="BOM No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_BOMNo"
            Width="88px"
            Text='<%# Bind("BOMNo") %>'
            Enabled = "False"
            ToolTip="Value of BOM No."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_BOMNo_Display"
            Text='<%# Eval("PAK_PkgListD2_PackingMark") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ItemNo" runat="server" Text="Item No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ItemNo"
            Width="88px"
            Text='<%# Bind("ItemNo") %>'
            Enabled = "False"
            ToolTip="Value of Item No."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ItemNo_Display"
            Text='<%# Eval("PAK_PkgListD2_PackingMark") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SiteMarkNo" runat="server" Text="Site Mark No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SiteMarkNo"
            Width="248px"
            Text='<%# Bind("SiteMarkNo") %>'
            Enabled = "False"
            ToolTip="Value of Site Mark No."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_SiteMarkNo_Display"
            Text='<%# Eval("PAK_SiteItemMaster5_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_LocationID" runat="server" Text="Location :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_pakSiteLocations
            ID="F_LocationID"
            SelectedValue='<%# Bind("LocationID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "pakSitePkgDLocation"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UOMQuantity" runat="server" Text="UOM Quantity :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_UOMQuantity"
            Width="88px"
            Text='<%# Bind("UOMQuantity") %>'
            Enabled = "False"
            ToolTip="Value of UOM Quantity."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_UOMQuantity_Display"
            Text='<%# Eval("PAK_Units9_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Quantity" runat="server" Text="Quantity :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Quantity"
            Text='<%# Bind("Quantity") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            ValidationGroup= "pakSitePkgDLocation"
            MaxLength="20"
            onfocus = "return this.select();"
            onblur="return dc(this,4);"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="100"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakSitePkgDLocation"
  DataObjectTypeName = "SIS.PAK.pakSitePkgDLocation"
  SelectMethod = "pakSitePkgDLocationGetByID"
  UpdateMethod="UZ_pakSitePkgDLocationUpdate"
  DeleteMethod="UZ_pakSitePkgDLocationDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSitePkgDLocation"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RecNo" Name="RecNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RecSrNo" Name="RecSrNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RecSrLNo" Name="RecSrLNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
