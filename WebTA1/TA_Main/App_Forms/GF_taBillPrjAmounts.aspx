<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_taBillPrjAmounts.aspx.vb" Inherits="GF_taBillPrjAmounts" title="Maintain List: Bill Project wise total" %>
<asp:Content ID="CPHtaBillPrjAmounts" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaBillPrjAmounts" runat="server" Text="&nbsp;List: Bill Project wise total"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBillPrjAmounts" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBillPrjAmounts"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBillPrjAmounts.aspx"
      EnableAdd = "False"
      ValidationGroup = "taBillPrjAmounts"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBillPrjAmounts" runat="server" AssociatedUpdatePanelID="UPNLtaBillPrjAmounts" DisplayAfter="100">
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
          <b><asp:Label ID="L_TABillNo" runat="server" Text="TA Bill No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_TABillNo"
            CssClass = "mypktxt"
            Width="70px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_TABillNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_TABillNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETABillNo"
            BehaviorID="B_ACETABillNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TABillNoCompletionList"
            TargetControlID="F_TABillNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACETABillNo_Selected"
            OnClientPopulating="ACETABillNo_Populating"
            OnClientPopulated="ACETABillNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <script type="text/javascript"> 
   var script_Percentage = {
    temp: function() {
    }
    }
    </script>

    <asp:GridView ID="GVtaBillPrjAmounts" SkinID="gv_silver" runat="server" DataSourceID="ODStaBillPrjAmounts" DataKeyNames="TABillNo,ProjectID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="IDM_Projects1_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Percentage" SortExpression="Percentage">
          <ItemTemplate>
          <asp:TextBox ID="F_Percentage"
            Text='<%# Bind("Percentage") %>'
            style="text-align: right"
            Width="70px"
            CssClass = "mytxt"
            ValidationGroup='<%# "taBillPrjAmounts" & Container.DataItemIndex %>'
            MaxLength="8"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEPercentage"
            runat = "server"
            mask = "999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Percentage" />
          <AJX:MaskedEditValidator 
            ID = "MEVPercentage"
            runat = "server"
            ControlToValidate = "F_Percentage"
            ControlExtender = "MEEPercentage"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "taBillPrjAmounts" & Container.DataItemIndex %>'
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />

          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Amount [INR]" SortExpression="TotalAmountinINR">
          <ItemTemplate>
            <asp:Label ID="LabelTotalAmountinINR" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TotalAmountinINR") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Save">
          <ItemTemplate>
            <asp:ImageButton ID="cmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' Enabled='<%# EVal("CompleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Save" SkinID="complete" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && confirm(""Save record ?"");" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODStaBillPrjAmounts"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBillPrjAmounts"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBillPrjAmountsSelectList"
      TypeName = "SIS.TA.taBillPrjAmounts"
      SelectCountMethod = "taBillPrjAmountsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBillPrjAmounts" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_TABillNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
