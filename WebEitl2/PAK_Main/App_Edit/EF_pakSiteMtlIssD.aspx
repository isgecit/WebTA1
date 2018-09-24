<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakSiteMtlIssD.aspx.vb" Inherits="EF_pakSiteMtlIssD" title="Edit: Site Material Issue Item" %>
<asp:Content ID="CPHpakSiteMtlIssD" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSiteMtlIssD" runat="server" Text="&nbsp;Edit: Site Material Issue Item"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSiteMtlIssD" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSiteMtlIssD"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "pakSiteMtlIssD"
    runat = "server" />
<asp:FormView ID="FVpakSiteMtlIssD"
  runat = "server"
  DataKeyNames = "ProjectID,IssueNo,IssueSrNo"
  DataSourceID = "ODSpakSiteMtlIssD"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
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
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IssueNo" runat="server" ForeColor="#CC6633" Text="Request No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_IssueNo"
            Width="88px"
            Text='<%# Bind("IssueNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Request No."
            Runat="Server" />
          <asp:Label
            ID = "F_IssueNo_Display"
            Text='<%# Eval("PAK_SiteIssueH2_RequesterRemarks") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IssueSrNo" runat="server" ForeColor="#CC6633" Text="Request Line No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IssueSrNo"
            Text='<%# Bind("IssueSrNo") %>'
            ToolTip="Value of Request Line No."
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
          <asp:Label ID="L_SiteMarkNo" runat="server" Text="Site Mark No :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
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
            Text='<%# Eval("PAK_SiteItemMaster3_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
            Text='<%# Eval("PAK_Units4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_QuantityRequired" runat="server" Text="Quantity Required :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_QuantityRequired"
            Text='<%# Bind("QuantityRequired") %>'
            ToolTip="Value of Quantity Required."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
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
            ToolTip="Value of Remarks."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
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
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IssuerRemarks" runat="server" Text="Issuer Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IssuerRemarks"
            Text='<%# Bind("IssuerRemarks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Issuer Remarks."
            MaxLength="100"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td colspan="4" style="text-align:center">
          <asp:Button ID="cmdImport" runat="server" OnClientClick="return confirm('Any modification done in Issue will be lost ?');" CommandName="ImportItemLocation" CommandArgument='<%# Eval("PrimaryKey") %>' Text="Re-Fresh Item Master Location" />
        </td>
      </tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpakSiteMtlIssDL" runat="server" Text="&nbsp;List: Site Material Issue Item Location"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakSiteMtlIssDL" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakSiteMtlIssDL"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakSiteMtlIssDL.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakSiteMtlIssDL.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "pakSiteMtlIssDL"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakSiteMtlIssDL" runat="server" AssociatedUpdatePanelID="UPNLpakSiteMtlIssDL" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpakSiteMtlIssDL" SkinID="gv_silver" runat="server" DataSourceID="ODSpakSiteMtlIssDL" DataKeyNames="ProjectID,IssueNo,IssueSrNo,IssueSrLNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Issue Sr L No" SortExpression="IssueSrLNo">
          <ItemTemplate>
            <asp:Label ID="LabelIssueSrLNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("IssueSrLNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Site Mark No" SortExpression="PAK_SiteItemMaster4_ItemDescription">
          <ItemTemplate>
             <asp:Label ID="L_SiteMarkNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("SiteMarkNo") %>' Text='<%# Eval("PAK_SiteItemMaster4_ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Location" SortExpression="PAK_SiteLocations5_Description">
          <ItemTemplate>
             <asp:Label ID="L_LocationID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("LocationID") %>' Text='<%# Eval("PAK_SiteLocations5_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM Quantity" SortExpression="PAK_Units6_Description">
          <ItemTemplate>
             <asp:Label ID="L_UOMQuantity" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("UOMQuantity") %>' Text='<%# Eval("PAK_Units6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity Available" SortExpression="QuantityAvailable">
          <ItemTemplate>
            <asp:Label ID="LabelQuantityAvailable" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("QuantityAvailable") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity Issued" SortExpression="QuantityIssued">
          <ItemTemplate>
            <asp:Label ID="LabelQuantityIssued" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("QuantityIssued") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakSiteMtlIssDL"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakSiteMtlIssDL"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_pakSiteMtlIssDLSelectList"
      TypeName = "SIS.PAK.pakSiteMtlIssDL"
      SelectCountMethod = "pakSiteMtlIssDLSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_IssueNo" PropertyName="Text" Name="IssueNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_IssueSrNo" PropertyName="Text" Name="IssueSrNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakSiteMtlIssDL" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakSiteMtlIssD"
  DataObjectTypeName = "SIS.PAK.pakSiteMtlIssD"
  SelectMethod = "pakSiteMtlIssDGetByID"
  UpdateMethod="UZ_pakSiteMtlIssDUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSiteMtlIssD"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="IssueNo" Name="IssueNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="IssueSrNo" Name="IssueSrNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
