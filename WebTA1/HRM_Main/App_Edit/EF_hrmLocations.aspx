<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_hrmLocations.aspx.vb" Inherits="EF_hrmLocations" title="Edit: Locations" %>
<asp:Content ID="CPHhrmLocations" ContentPlaceHolderID="cph1" Runat="Server">
  <div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelhrmLocations" runat="server" Text="&nbsp;Edit: Locations"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLhrmLocations" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLhrmLocations"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "hrmLocations"
    runat = "server" />
<asp:FormView ID="FVhrmLocations"
  runat = "server"
  DataKeyNames = "LocationID"
  DataSourceID = "ODShrmLocations"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_LocationID" runat="server" ForeColor="#CC6633" Text="Location ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_LocationID"
            Text='<%# Bind("LocationID") %>'
            ToolTip="Value of Location ID."
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
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="hrmLocations"
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
            ValidationGroup = "hrmLocations"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelhrmOfficeLocation" runat="server" Text="&nbsp;List: Office Location"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLhrmOfficeLocation" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLhrmOfficeLocation"
      ToolType = "lgNMGrid"
      EditUrl = "~/HRM_Main/App_Edit/EF_hrmOfficeLocation.aspx"
      AddUrl = "~/HRM_Main/App_Create/AF_hrmOfficeLocation.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "hrmOfficeLocation"
      runat = "server" />
    <asp:UpdateProgress ID="UPGShrmOfficeLocation" runat="server" AssociatedUpdatePanelID="UPNLhrmOfficeLocation" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVhrmOfficeLocation" SkinID="gv_silver" runat="server" DataSourceID="ODShrmOfficeLocation" DataKeyNames="LocationID,OfficeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Location ID" SortExpression="HRM_Locations1_Description">
          <ItemTemplate>
             <asp:Label ID="L_LocationID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("LocationID") %>' Text='<%# Eval("HRM_Locations1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Office ID" SortExpression="HRM_Offices2_Description">
          <ItemTemplate>
             <asp:Label ID="L_OfficeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("OfficeID") %>' Text='<%# Eval("HRM_Offices2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODShrmOfficeLocation"
      runat = "server"
      DataObjectTypeName = "SIS.HRM.hrmOfficeLocation"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "hrmOfficeLocationSelectList"
      TypeName = "SIS.HRM.hrmOfficeLocation"
      SelectCountMethod = "hrmOfficeLocationSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_LocationID" PropertyName="Text" Name="LocationID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVhrmOfficeLocation" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODShrmLocations"
  DataObjectTypeName = "SIS.HRM.hrmLocations"
  SelectMethod = "hrmLocationsGetByID"
  UpdateMethod="hrmLocationsUpdate"
  DeleteMethod="hrmLocationsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.HRM.hrmLocations"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="LocationID" Name="LocationID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
