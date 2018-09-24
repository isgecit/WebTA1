<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_eitlClosedPO.aspx.vb" Inherits="GF_eitlClosedPO" title="Maintain List: Closed / Cancelled PO" %>
<asp:Content ID="CPHeitlClosedPO" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeleitlClosedPO" runat="server" Text="&nbsp;List: Closed / Cancelled PO"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLeitlClosedPO" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLeitlClosedPO"
      ToolType = "lgNMGrid"
      EditUrl = "~/EITL_Main/App_Edit/EF_eitlClosedPO.aspx"
      EnableAdd = "False"
      ValidationGroup = "eitlClosedPO"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSeitlClosedPO" runat="server" AssociatedUpdatePanelID="UPNLeitlClosedPO" DisplayAfter="100">
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
					<b><asp:Label ID="L_ProjectID" runat="server" Text="Project :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProjectID"
						CssClass = "myfktxt"
            Width="42px"
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
    </table>
		</asp:Panel>
		<AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_eitlClosedPO.aspx', 'App_Print/RP_eitlPOList.aspx');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVeitlClosedPO" SkinID="gv_silver" runat="server" DataSourceID="ODSeitlClosedPO" DataKeyNames="SerialNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <EditItemTemplate>
          </EditItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="S.No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <EditItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </EditItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PO Number" SortExpression="PONumber">
          <ItemTemplate>
            <asp:Label ID="LabelPONumber" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PONumber") %>'></asp:Label>
          </ItemTemplate>
          <EditItemTemplate>
            <asp:Label ID="LabelPONumber" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PONumber") %>'></asp:Label>
          </EditItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PO REV." SortExpression="PORevision">
          <ItemTemplate>
            <asp:Label ID="LabelPORevision" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PORevision") %>'></asp:Label>
          </ItemTemplate>
          <EditItemTemplate>
            <asp:Label ID="LabelPORevision" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PORevision") %>'></asp:Label>
          </EditItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PO Date" SortExpression="PODate">
          <ItemTemplate>
            <asp:Label ID="LabelPODate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PODate") %>'></asp:Label>
          </ItemTemplate>
          <EditItemTemplate>
            <asp:Label ID="LabelPODate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PODate") %>'></asp:Label>
          </EditItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project" SortExpression="IDM_Projects6_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects6_Description") %>'></asp:Label>
          </ItemTemplate>
          <EditItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects6_Description") %>'></asp:Label>
          </EditItemTemplate>
          <HeaderStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Buyer" SortExpression="aspnet_Users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_BuyerID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BuyerID") %>' Text='<%# Eval("aspnet_Users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <EditItemTemplate>
             <asp:Label ID="L_BuyerID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BuyerID") %>' Text='<%# Eval("aspnet_Users1_UserFullName") %>'></asp:Label>
          </EditItemTemplate>
          <HeaderStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="POStatus" SortExpression="EITL_POStatus4_Description">
          <ItemTemplate>
             <asp:Label ID="L_POStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("POStatusID") %>' Text='<%# Eval("EITL_POStatus4_Description") %>'></asp:Label>
          </ItemTemplate>
          <EditItemTemplate>
             <asp:Label ID="L_POStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("POStatusID") %>' Text='<%# Eval("EITL_POStatus4_Description") %>'></asp:Label>
          </EditItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Issued On" SortExpression="IssuedOn">
          <ItemTemplate>
            <asp:Label ID="LabelIssuedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IssuedOn") %>'></asp:Label>
          </ItemTemplate>
          <EditItemTemplate>
            <asp:Label ID="LabelIssuedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IssuedOn") %>'></asp:Label>
          </EditItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Closed On" SortExpression="ClosedOn">
          <ItemTemplate>
            <asp:Label ID="LabelClosedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ClosedOn") %>'></asp:Label>
          </ItemTemplate>
          <EditItemTemplate>
            <asp:Label ID="LabelClosedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ClosedOn") %>'></asp:Label>
          </EditItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Request to Open PO">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="OpenRequest" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""OpenRequest record ?"");" %>' CommandName="Edit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <EditItemTemplate>
            </td></tr>
            <tr>
              <td colspan="11" class="alignCenter"><div style="vertical-align:middle;height:120px; width:400px;margin:10px auto 10px auto; float:inherit" class="ui-widget-content ui-corner-all" >
              <h3 class="ui-widget-header ui-corner-all" style="margin: 0; padding: 0.4em; text-align: center;" >
              Reason for Re-Open</h3>
                <asp:TextBox ID="F_Reason"
                  Width="300px" Height="40px" TextMode="MultiLine"
                  text='<%# Bind("Reason") %>'
                  CssClass = "mytxt"
                  onfocus = "return this.select();"
                  ValidationGroup='<%# "Approve" & Container.DataItemIndex %>'
                  onblur= "this.value=this.value.replace(/\'/g,'');"
                  ToolTip="Enter Reason for Re-Open."
                  MaxLength="500"
                  runat="server" />
                <asp:RequiredFieldValidator 
                  ID = "RFVReason"
                  runat = "server"
                  ControlToValidate = "F_Reason"
                  Text = "*"
                  ErrorMessage = "*"
                  Display = "Dynamic"
                  EnableClientScript = "true"
                  ValidationGroup = '<%# "Approve" & Container.DataItemIndex %>'
                  SetFocusOnError="true" />
                  <br />
                 <asp:Button ID="cmdSave" Text="  Post Request  " ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" ToolTip="Click to post Re-Open Request."  OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Post Re-Open Request ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
                 <asp:Button ID="cmdCancel" runat="server" ToolTip="Cancel Re-Open Request." Text=" Cancel " CommandName="Cancel" CommandArgument='<%# Container.DataItemIndex %>' />
                 </div>
              </td>
            </tr>
          </EditItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="40px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSeitlClosedPO"
      runat = "server"
      DataObjectTypeName = "SIS.EITL.eitlClosedPO"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_eitlClosedPOSelectList"
      TypeName = "SIS.EITL.eitlClosedPO"
      SelectCountMethod = "eitlClosedPOSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVeitlClosedPO" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
