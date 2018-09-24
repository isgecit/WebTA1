<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pakIQCListH.aspx.vb" Inherits="GF_pakIQCListH" title="Maintain List: Offered QC List" %>
<asp:Content ID="CPHpakIQCListH" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakIQCListH" runat="server" Text="&nbsp;List: Offered QC List"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakIQCListH" runat="server">
  <ContentTemplate>
    <table>
      <tr>
        <td>
          <asp:Label runat="server" Font-Bold="true" ForeColor="BlueViolet" style="margin: 10px 10px auto 10px" Text="Upload Quality Cleared File." ></asp:Label>
        </td>
      </tr>
      <tr>
        <td style="text-align:center">
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
              <asp:FileUpload ID="F_FileUpload" runat="server" Width="250px" ToolTip="Browse QC List" />
              <asp:Button ID="cmdTmplUpload" Text="Upload" runat="server" ToolTip="Click to upload & process template file." CommandName="tmplUpload"  />
            </ContentTemplate>
            <Triggers>
              <asp:PostBackTrigger ControlID="cmdTmplUpload" />
            </Triggers>
          </asp:UpdatePanel>
        </td>
      </tr>
    </table>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakIQCListH"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakIQCListH.aspx"
      EnableAdd = "False"
      ValidationGroup = "pakIQCListH"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakIQCListH" runat="server" AssociatedUpdatePanelID="UPNLpakIQCListH" DisplayAfter="100">
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
          <b><asp:Label ID="L_SerialNo" runat="server" Text="Serial No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_SerialNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_SerialNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESerialNo"
            BehaviorID="B_ACESerialNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SerialNoCompletionList"
            TargetControlID="F_SerialNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACESerialNo_Selected"
            OnClientPopulating="ACESerialNo_Populating"
            OnClientPopulated="ACESerialNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_QCLNo" runat="server" Text="QC List No :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_QCLNo"
            Text=""
            Width="88px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEQCLNo"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_QCLNo" />
          <AJX:MaskedEditValidator 
            ID = "MEVQCLNo"
            runat = "server"
            ControlToValidate = "F_QCLNo"
            ControlExtender = "MEEQCLNo"
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
          <b><asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            CssClass = "myfktxt"
            Width="72px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_CreatedBy(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECreatedBy"
            BehaviorID="B_ACECreatedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CreatedByCompletionList"
            TargetControlID="F_CreatedBy"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACECreatedBy_Selected"
            OnClientPopulating="ACECreatedBy_Populating"
            OnClientPopulated="ACECreatedBy_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_StatusID" runat="server" Text="Status :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_StatusID"
            CssClass = "myfktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_StatusID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_StatusID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEStatusID"
            BehaviorID="B_ACEStatusID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="StatusIDCompletionList"
            TargetControlID="F_StatusID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEStatusID_Selected"
            OnClientPopulating="ACEStatusID_Populating"
            OnClientPopulated="ACEStatusID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ClearedBy" runat="server" Text="Cleared By :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ClearedBy"
            CssClass = "myfktxt"
            Width="72px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ClearedBy(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ClearedBy_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEClearedBy"
            BehaviorID="B_ACEClearedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ClearedByCompletionList"
            TargetControlID="F_ClearedBy"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEClearedBy_Selected"
            OnClientPopulating="ACEClearedBy_Populating"
            OnClientPopulated="ACEClearedBy_Populated"
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
    <script type="text/javascript"> 
   var script_Remarks = {
    temp: function() {
    }
    }
    </script>

    <asp:GridView ID="GVpakIQCListH" SkinID="gv_silver" runat="server" DataSourceID="ODSpakIQCListH" DataKeyNames="SerialNo,QCLNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Get Tmpl.">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDownload" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Download QC List Offered." SkinID="download" OnClientClick='<%# Eval("GetPrintLink") %>' />
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
             <asp:Label ID="L_SerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("PAK_PO2_PODescription") %>' Text='<%# Eval("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="60px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="QC List No" SortExpression="QCLNo">
          <ItemTemplate>
            <asp:Label ID="LabelQCLNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("QCLNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="60px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Offered Weight" SortExpression="TotalWeight">
          <ItemTemplate>
            <asp:Label ID="LabelTotalWeight" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TotalWeight") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM" SortExpression="PAK_Units4_Description">
          <ItemTemplate>
             <asp:Label ID="L_UOMTotalWeight" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOMTotalWeight") %>' Text='<%# Eval("PAK_Units4_Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Offered By" SortExpression="aspnet_users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_CreatedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CreatedBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Offered On" SortExpression="CreatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="PAK_QCListStatus3_Description">
          <ItemTemplate>
             <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("PAK_QCListStatus3_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
          <ItemTemplate>
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            Width="150px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
            ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
            style="margin-right:0px;"
            runat="server" />
          <asp:RequiredFieldValidator
            ID="RFVF_Remarks"
            ControlToValidate="F_Remarks"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            SetFocusOnError="True"
            ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
            runat="server"/>
          </ItemTemplate>
        <ItemStyle CssClass="alignCenter" Width="150px" />
        <HeaderStyle CssClass="alignCenter" Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Alloted Request">
          <ItemTemplate>
            <LGM:LC_qcmRequests 
              ID="F_QCRequestNo"
              SelectedValue='<%# Bind("QCRequestNo") %>'
              OrderBy='<%# Eval("FK_PAK_QCListH_SerialNo.SupplierID") %>'
              DataTextField="DisplayField"
              DataValueField="PrimaryKey"
              IncludeDefault="true"
              DefaultText="-- Select --"
              Width="100px"
              CssClass="myddl"
              Runat="Server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Inspection Done">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="After uploading Cleared Quantity List, click to complete." SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Update and close cleared quantity ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="RETURN">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Return Offered Quality Clearance List." SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Return offered clearance list ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Pkg No" SortExpression="PkgNo">
          <ItemTemplate>
            <asp:Label ID="LabelPkgNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PkgNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakIQCListH"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakIQCListH"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_pakIQCListHSelectList"
      TypeName = "SIS.PAK.pakIQCListH"
      SelectCountMethod = "pakIQCListHSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_QCLNo" PropertyName="Text" Name="QCLNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_CreatedBy" PropertyName="Text" Name="CreatedBy" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_StatusID" PropertyName="Text" Name="StatusID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ClearedBy" PropertyName="Text" Name="ClearedBy" Type="String" Size="8" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakIQCListH" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_SerialNo" />
    <asp:AsyncPostBackTrigger ControlID="F_QCLNo" />
    <asp:AsyncPostBackTrigger ControlID="F_CreatedBy" />
    <asp:AsyncPostBackTrigger ControlID="F_StatusID" />
    <asp:AsyncPostBackTrigger ControlID="F_ClearedBy" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
