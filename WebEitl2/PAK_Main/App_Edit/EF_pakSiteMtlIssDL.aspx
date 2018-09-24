<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakSiteMtlIssDL.aspx.vb" Inherits="EF_pakSiteMtlIssDL" title="Edit: Site Material Issue Item Location" %>
<asp:Content ID="CPHpakSiteMtlIssDL" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSiteMtlIssDL" runat="server" Text="&nbsp;Edit: Site Material Issue Item Location"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSiteMtlIssDL" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSiteMtlIssDL"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "pakSiteMtlIssDL"
    EnableDelete="false"
    runat = "server" />
<asp:FormView ID="FVpakSiteMtlIssDL"
  runat = "server"
  DataKeyNames = "ProjectID,IssueNo,IssueSrNo,IssueSrLNo"
  DataSourceID = "ODSpakSiteMtlIssDL"
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
          <b><asp:Label ID="L_IssueNo" runat="server" ForeColor="#CC6633" Text="Issue No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_IssueNo"
            Width="88px"
            Text='<%# Bind("IssueNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Issue No."
            Runat="Server" />
          <asp:Label
            ID = "F_IssueNo_Display"
            Text='<%# Eval("PAK_SiteIssueH3_RequesterRemarks") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IssueSrNo" runat="server" ForeColor="#CC6633" Text="Issue Sr No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_IssueSrNo"
            Width="88px"
            Text='<%# Bind("IssueSrNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Issue Sr No."
            Runat="Server" />
          <asp:Label
            ID = "F_IssueSrNo_Display"
            Text='<%# Eval("PAK_SiteIssueD2_SiteMarkNo") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_IssueSrLNo" runat="server" ForeColor="#CC6633" Text="Issue Sr L No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_IssueSrLNo"
            Text='<%# Bind("IssueSrLNo") %>'
            ToolTip="Value of Issue Sr L No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
            Text='<%# Eval("PAK_SiteItemMaster4_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
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
            Text='<%# Eval("PAK_Units6_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_QuantityAvailable" runat="server" Text="Quantity Available :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_QuantityAvailable"
            Text='<%# Bind("QuantityAvailable") %>'
            ToolTip="Value of Quantity Available."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_LocationID" runat="server" Text="Location :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_LocationID"
            Width="88px"
            Text='<%# Bind("LocationID") %>'
            Enabled = "False"
            ToolTip="Value of Location."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_LocationID_Display"
            Text='<%# Eval("PAK_SiteLocations5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_QuantityIssued" runat="server" Text="Quantity Issued :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_QuantityIssued"
            Text='<%# Bind("QuantityIssued") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            ValidationGroup= "pakSiteMtlIssDL"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEQuantityIssued"
            runat = "server"
            mask = "9999999999999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_QuantityIssued" />
          <AJX:MaskedEditValidator 
            ID = "MEVQuantityIssued"
            runat = "server"
            ControlToValidate = "F_QuantityIssued"
            ControlExtender = "MEEQuantityIssued"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSiteMtlIssDL"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td colspan="3">
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
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakSiteMtlIssDL"
  DataObjectTypeName = "SIS.PAK.pakSiteMtlIssDL"
  SelectMethod = "pakSiteMtlIssDLGetByID"
  UpdateMethod="UZ_pakSiteMtlIssDLUpdate"
  DeleteMethod="UZ_pakSiteMtlIssDLDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSiteMtlIssDL"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="IssueNo" Name="IssueNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="IssueSrNo" Name="IssueSrNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="IssueSrLNo" Name="IssueSrLNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
