<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pakTCPO.aspx.vb" Inherits="GF_pakTCPO" title="Maintain List: Issue PO" %>
<asp:Content ID="CPHpakTCPO" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakTCPO" runat="server" Text="&nbsp;List: Issue PO"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakTCPO" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakTCPO"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakTCPO.aspx"
      EnableAdd = "False"
      ValidationGroup = "pakTCPO"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakTCPO" runat="server" AssociatedUpdatePanelID="UPNLpakTCPO" DisplayAfter="100">
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
          <b><asp:Label ID="Label1" runat="server" Text="Import PO From ERP-LN :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_PONumber"
            CssClass = "myfktxt"
            Width="110px"
            Text=""
            MaxLength="9"
            ToolTip="Enter PO Number to import"
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            Runat="Server" />
          <asp:Button ID="cmdImport" runat="server" Text="Import" OnClientClick="return confirm('Import PO from ERP-LN ?');" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_POStatusID" runat="server" Text="Status :" /></b>
        </td>
        <td>
          <LGM:LC_pakPOStatus
            ID="F_POStatusID"
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="StatusID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SupplierID" runat="server" Text="Supplier :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_SupplierID"
            CssClass = "myfktxt"
            Width="80px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_SupplierID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_SupplierID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESupplierID"
            BehaviorID="B_ACESupplierID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SupplierIDCompletionList"
            TargetControlID="F_SupplierID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACESupplierID_Selected"
            OnClientPopulating="ACESupplierID_Populating"
            OnClientPopulated="ACESupplierID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" Text="Project :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "myfktxt"
            Width="56px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ProjectID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEProjectID_Selected"
            OnClientPopulating="ACEProjectID_Populating"
            OnClientPopulated="ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BuyerID" runat="server" Text="Buyer :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_BuyerID"
            CssClass = "myfktxt"
            Width="72px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_BuyerID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_BuyerID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEBuyerID"
            BehaviorID="B_ACEBuyerID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="BuyerIDCompletionList"
            TargetControlID="F_BuyerID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEBuyerID_Selected"
            OnClientPopulating="ACEBuyerID_Populating"
            OnClientPopulated="ACEBuyerID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IssuedBy" runat="server" Text="Issued By :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_IssuedBy"
            CssClass = "myfktxt"
            Width="72px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_IssuedBy(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_IssuedBy_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEIssuedBy"
            BehaviorID="B_ACEIssuedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="IssuedByCompletionList"
            TargetControlID="F_IssuedBy"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEIssuedBy_Selected"
            OnClientPopulating="ACEIssuedBy_Populating"
            OnClientPopulated="ACEIssuedBy_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_POTypeID" runat="server" Text="PO Type :" /></b>
        </td>
        <td>
          <LGM:LC_pakPOTypes
            ID="F_POTypeID"
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="POTypeID"
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
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVpakTCPO" SkinID="gv_silver" runat="server" DataSourceID="ODSpakTCPO" DataKeyNames="SerialNo">
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
        <asp:TemplateField HeaderText="NOTE">
          <ItemTemplate>
            <asp:ImageButton ID="cmdNotes" runat="server" AlternateText='<%# Eval("PrimaryKey") %>' ToolTip="View/reply Notes" SkinID="notes" OnClientClick='<%# Eval("GetNotesLink") %>' CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PO Number" SortExpression="PONumber">
          <ItemTemplate>
            <asp:Label ID="LabelPONumber" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PONumber") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="REV." SortExpression="PORevision">
          <ItemTemplate>
            <asp:Label ID="LabelPORevision" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PORevision") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PO Description" SortExpression="PODescription">
          <ItemTemplate>
            <asp:Label ID="LabelPODescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PODescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PO Date" SortExpression="PODate">
          <ItemTemplate>
            <asp:Label ID="LabelPODate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PODate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier" SortExpression="VR_BusinessPartner9_BPName">
          <ItemTemplate>
             <asp:Label ID="L_SupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SupplierID") %>' Text='<%# Eval("VR_BusinessPartner9_BPName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project" SortExpression="IDM_Projects4_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="PAK_POStatus6_Description">
          <ItemTemplate>
             <asp:Label ID="L_POStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("POStatusID") %>' Text='<%# Eval("PAK_POStatus6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ISSUE">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Issue Purchase Order ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="RE-OPEN">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Approve" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Re-Open Purchase Order ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSpakTCPO"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakTCPO"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_pakTCPOSelectList"
      TypeName = "SIS.PAK.pakTCPO"
      SelectCountMethod = "pakTCPOSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SupplierID" PropertyName="Text" Name="SupplierID" Type="String" Size="9" />
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_POStatusID" PropertyName="SelectedValue" Name="POStatusID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_POTypeID" PropertyName="SelectedValue" Name="POTypeID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_IssuedBy" PropertyName="Text" Name="IssuedBy" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_BuyerID" PropertyName="Text" Name="BuyerID" Type="String" Size="8" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakTCPO" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_SupplierID" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
    <asp:AsyncPostBackTrigger ControlID="F_POStatusID" />
    <asp:AsyncPostBackTrigger ControlID="F_POTypeID" />
    <asp:AsyncPostBackTrigger ControlID="F_IssuedBy" />
    <asp:AsyncPostBackTrigger ControlID="F_BuyerID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
