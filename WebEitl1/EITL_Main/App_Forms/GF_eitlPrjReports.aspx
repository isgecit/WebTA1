<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_eitlPrjReports.aspx.vb" Inherits="GF_eitlPrjReports" title="Project Wise Reports" %>
<asp:Content ID="CPHeitlPrjReports" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page" style="width:50%">
<div class="caption">
    <asp:Label ID="LabeleitlPrjReports" runat="server" Text="&nbsp;Print: Erection Document / Item List"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLeitlPrjReports" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLeitlPrjReports"
      ToolType = "lgNMGrid"
      EnableAdd = "False"
      HideSearch = "false"
      HidePaging = "False"
      ValidationGroup = "eitlPrjReports"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSeitlPrjReports" runat="server" AssociatedUpdatePanelID="UPNLeitlPrjReports" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <table style="margin:10px auto">
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" runat="server" Text="ENTER / SELECT PROJECT CODE:" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProjectID"
						CssClass = "myfktxt"
            Width="72px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
           ClientIDMode="Static"
            onblur= "validate_ProjectID(this) && $get('F_TProjectID').value=this.value;"
						Runat="Server" />
					<asp:Label
						ID = "F_ProjectID_Display"
						Text=""
            Width="200px"
           ClientIDMode="Static"
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
           ClientIDMode="Static"
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
        <td >
          <br />
          <asp:Button ID="cmdGenerateDocument" runat="server" CssClass="generate" Width="200px" Text="Print Erection Document"  />
          <br />
        </td>
        <td >
          <br />
          <asp:Button ID="cmdGenerateItem" runat="server" CssClass="generate" Width="200px" Text="Print Erection Item"  />
          <br />
        </td>
      </tr>
    </table>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:PostBackTrigger ControlID="cmdGenerateDocument" />
    <asp:PostBackTrigger ControlID="cmdGenerateItem" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
