<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costProjectGroups.aspx.vb" Inherits="EF_costProjectGroups" title="Edit: Project Groups" %>
<asp:Content ID="CPHcostProjectGroups" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostProjectGroups" runat="server" Text="&nbsp;Edit: Project Groups"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectGroups" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostProjectGroups"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "costProjectGroups"
    runat = "server" />
<asp:FormView ID="FVcostProjectGroups"
  runat = "server"
  DataKeyNames = "ProjectGroupID"
  DataSourceID = "ODScostProjectGroups"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectGroupID" runat="server" ForeColor="#CC6633" Text="Project Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectGroupID"
            Text='<%# Bind("ProjectGroupID") %>'
            ToolTip="Value of Project Group ID."
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
          <asp:Label ID="L_ProjectGroupDescription" runat="server" Text="Project Group Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectGroupDescription"
            Text='<%# Bind("ProjectGroupDescription") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costProjectGroups"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Project Group Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectGroupDescription"
            runat = "server"
            ControlToValidate = "F_ProjectGroupDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectGroups"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectTypeID" runat="server" Text="Project Type :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_costProjectTypes
            ID="F_ProjectTypeID"
            SelectedValue='<%# Bind("ProjectTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "costProjectGroups"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelcostProjectGroupProjects" runat="server" Text="&nbsp;List: Project Group Projects"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectGroupProjects" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostProjectGroupProjects"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costProjectGroupProjects.aspx"
      AddUrl = "~/COST_Main/App_Create/AF_costProjectGroupProjects.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "costProjectGroupProjects"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostProjectGroupProjects" runat="server" AssociatedUpdatePanelID="UPNLcostProjectGroupProjects" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVcostProjectGroupProjects" SkinID="gv_silver" runat="server" DataSourceID="ODScostProjectGroupProjects" DataKeyNames="ProjectGroupID,ProjectID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Group ID" SortExpression="COST_ProjectGroups1_ProjectGroupDescription">
          <ItemTemplate>
             <asp:Label ID="L_ProjectGroupID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectGroupID") %>' Text='<%# Eval("COST_ProjectGroups1_ProjectGroupDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="ProjectID">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# EVal("ProjectID") %>' Title='<%# Eval("IDM_Projects2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Description" SortExpression="IDM_Projects2_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectIDDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODScostProjectGroupProjects"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costProjectGroupProjects"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "costProjectGroupProjectsSelectList"
      TypeName = "SIS.COST.costProjectGroupProjects"
      SelectCountMethod = "costProjectGroupProjectsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectGroupID" PropertyName="Text" Name="ProjectGroupID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostProjectGroupProjects" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelcostCostSheet" runat="server" Text="&nbsp;List: Cost Sheet"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostCostSheet" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostCostSheet"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costCostSheet.aspx"
      AddUrl = "~/COST_Main/App_Create/AF_costCostSheet.aspx?skip=1"
      EnableExit = "false"
      ValidationGroup = "costCostSheet"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostCostSheet" runat="server" AssociatedUpdatePanelID="UPNLcostCostSheet" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Edit/EF_costProjectGroups','App_Print/RP_costCostSheet');
        url = url + '&pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=150,height=100,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVcostCostSheet" SkinID="gv_silver" runat="server" DataSourceID="ODScostCostSheet" DataKeyNames="ProjectGroupID,FinYear,Quarter,Revision">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PRINT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Group ID" SortExpression="COST_ProjectGroups5_ProjectGroupDescription">
          <ItemTemplate>
             <asp:Label ID="L_ProjectGroupID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectGroupID") %>' Text='<%# Eval("COST_ProjectGroups5_ProjectGroupDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fin. Year" SortExpression="COST_FinYear4_Descpription">
          <ItemTemplate>
             <asp:Label ID="L_FinYear" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("FinYear") %>' Text='<%# Eval("COST_FinYear4_Descpription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quarter" SortExpression="COST_Quarters6_Description">
          <ItemTemplate>
             <asp:Label ID="L_Quarter" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("Quarter") %>' Text='<%# Eval("COST_Quarters6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Revision" SortExpression="Revision">
          <ItemTemplate>
            <asp:Label ID="LabelRevision" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Revision") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created By" SortExpression="aspnet_users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_CreatedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CreatedBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created On" SortExpression="CreatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="COST_CostSheetStates3_Description">
          <ItemTemplate>
             <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("COST_CostSheetStates3_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Download">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDownload" ValidationGroup='<%# "Download" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DownloadWFVisible") %>' Enabled='<%# EVal("DownloadWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Download" SkinID="Download" OnClientClick='<%# "return Page_ClientValidate(""Download" & Container.DataItemIndex & """) && confirm(""Download record ?"");" %>' CommandName="DownloadWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Checked">
          <ItemTemplate>
            <asp:ImageButton ID="cmdUpdate" ValidationGroup='<%# "Update" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("UpdateWFVisible") %>' Enabled='<%# EVal("UpdateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Cost Sheet is Checked ?" SkinID="complete" OnClientClick='<%# "return Page_ClientValidate(""Update" & Container.DataItemIndex & """) && confirm(""Cost Sheet Checked ?"");" %>' CommandName="UpdateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODScostCostSheet"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costCostSheet"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_costCostSheetSelectList"
      TypeName = "SIS.COST.costCostSheet"
      SelectCountMethod = "costCostSheetSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectGroupID" PropertyName="Text" Name="ProjectGroupID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostCostSheet" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostProjectGroups"
  DataObjectTypeName = "SIS.COST.costProjectGroups"
  SelectMethod = "costProjectGroupsGetByID"
  UpdateMethod="costProjectGroupsUpdate"
  DeleteMethod="costProjectGroupsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costProjectGroups"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectGroupID" Name="ProjectGroupID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
