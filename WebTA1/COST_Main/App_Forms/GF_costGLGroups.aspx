<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_costGLGroups.aspx.vb" Inherits="GF_costGLGroups" title="Maintain List: GL Groups" %>
<asp:Content ID="CPHcostGLGroups" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelcostGLGroups" runat="server" Text="&nbsp;List: GL Groups"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostGLGroups" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostGLGroups"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costGLGroups.aspx"
      AddUrl = "~/COST_Main/App_Create/AF_costGLGroups.aspx?skip=1"
      ValidationGroup = "costGLGroups"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostGLGroups" runat="server" AssociatedUpdatePanelID="UPNLcostGLGroups" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GLGroupID" runat="server" Text="GL Group ID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_GLGroupID"
            Text=""
            Width="88px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEGLGroupID"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_GLGroupID" />
          <AJX:MaskedEditValidator 
            ID = "MEVGLGroupID"
            runat = "server"
            ControlToValidate = "F_GLGroupID"
            ControlExtender = "MEEGLGroupID"
            InvalidValueMessage = "*"
            EmptyValueMessage = ""
            EmptyValueBlurredText = ""
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GLNatureID" runat="server" Text="GL Nature ID :" /></b>
        </td>
        <td>
          <LGM:LC_costGLNatures
            ID="F_GLNatureID"
            SelectedValue=""
            OrderBy="GLNatureDescription"
            DataTextField="GLNatureDescription"
            DataValueField="GLNatureID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <script type="text/javascript"> 
   var script_Sequence = {
    temp: function() {
    }
    }
    </script>

    <asp:GridView ID="GVcostGLGroups" SkinID="gv_silver" runat="server" DataSourceID="ODScostGLGroups" DataKeyNames="GLGroupID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GL Group ID" SortExpression="GLGroupID">
          <ItemTemplate>
            <asp:Label ID="LabelGLGroupID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GLGroupID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GL Nature ID" SortExpression="COST_GLNatures1_GLNatureDescription">
          <ItemTemplate>
             <asp:Label ID="L_GLNatureID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("GLNatureID") %>' Text='<%# Eval("COST_GLNatures1_GLNatureDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GL Group Descriptions" SortExpression="GLGroupDescriptions">
          <ItemTemplate>
            <asp:Label ID="LabelGLGroupDescriptions" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GLGroupDescriptions") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cost GL Group ID" SortExpression="COST_vGLGroups2_GLGroupDescriptions">
          <ItemTemplate>
             <asp:Label ID="L_CostGLGroupID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CostGLGroupID") %>' Text='<%# Eval("COST_vGLGroups2_GLGroupDescriptions") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sequence" SortExpression="Sequence">
          <ItemTemplate>
          <asp:TextBox ID="F_Sequence"
            Text='<%# Bind("Sequence") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            ValidationGroup='<%# "Approve" & Container.DataItemIndex %>'
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEESequence"
            runat = "server"
            mask = "99999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Sequence" />
          <AJX:MaskedEditValidator 
            ID = "MEVSequence"
            runat = "server"
            ControlToValidate = "F_Sequence"
            ControlExtender = "MEESequence"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "Approve" & Container.DataItemIndex %>'
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />

          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Update Sequence">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Update Sequence" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Update Sequence record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODScostGLGroups"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costGLGroups"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "costGLGroupsSelectList"
      TypeName = "SIS.COST.costGLGroups"
      SelectCountMethod = "costGLGroupsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_GLGroupID" PropertyName="Text" Name="GLGroupID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_GLNatureID" PropertyName="SelectedValue" Name="GLNatureID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostGLGroups" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_GLGroupID" />
    <asp:AsyncPostBackTrigger ControlID="F_GLNatureID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
