<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_eitlProjectWiseUser.aspx.vb" Inherits="EF_eitlProjectWiseUser" title="Edit: Project Wise Alert Group " %>
<asp:Content ID="CPHeitlProjectWiseUser" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlProjectWiseUser" runat="server" Text="&nbsp;Edit: Project Wise Alert Group "></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlProjectWiseUser" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlProjectWiseUser"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_eitlProjectWiseUser.aspx?pk="
    ValidationGroup = "eitlProjectWiseUser"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVeitlProjectWiseUser"
	runat = "server"
	DataKeyNames = "SerialNo"
	DataSourceID = "ODSeitlProjectWiseUser"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
		<table style="margin:auto">
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SerialNo"
						Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="133px"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_UserID" runat="server" Text="User ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_UserID"
						CssClass = "myfktxt"
						Text='<%# Bind("UserID") %>'
						AutoCompleteType = "None"
            Width="56px"
						onfocus = "return this.select();"
            ToolTip="Enter value for User ID."
						ValidationGroup = "eitlProjectWiseUser"
            onblur= "script_eitlProjectWiseUser.validate_UserID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_UserID_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVUserID"
						runat = "server"
						ControlToValidate = "F_UserID"
						Text = "User ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjectWiseUser"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEUserID"
            BehaviorID="B_ACEUserID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UserIDCompletionList"
            TargetControlID="F_UserID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_eitlProjectWiseUser.ACEUserID_Selected"
            OnClientPopulating="script_eitlProjectWiseUser.ACEUserID_Populating"
            OnClientPopulated="script_eitlProjectWiseUser.ACEUserID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProjectID"
						CssClass = "myfktxt"
						Text='<%# Bind("ProjectID") %>'
						AutoCompleteType = "None"
            Width="42px"
						onfocus = "return this.select();"
            ToolTip="Enter value for Project ID."
						ValidationGroup = "eitlProjectWiseUser"
            onblur= "script_eitlProjectWiseUser.validate_ProjectID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_ProjectID_Display"
						Text='<%# Eval("IDM_Projects2_Description") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectID"
						runat = "server"
						ControlToValidate = "F_ProjectID"
						Text = "Project ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjectWiseUser"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_eitlProjectWiseUser.ACEProjectID_Selected"
            OnClientPopulating="script_eitlProjectWiseUser.ACEProjectID_Populating"
            OnClientPopulated="script_eitlProjectWiseUser.ACEProjectID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			<td></td><td></td></tr>
		</table>
	</div>
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSeitlProjectWiseUser"
  DataObjectTypeName = "SIS.EITL.eitlProjectWiseUser"
  SelectMethod = "eitlProjectWiseUserGetByID"
  UpdateMethod="eitlProjectWiseUserUpdate"
  DeleteMethod="eitlProjectWiseUserDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlProjectWiseUser"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int64" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
