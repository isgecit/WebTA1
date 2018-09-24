<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_lgDMisg.aspx.vb" Inherits="EF_lgDMisg" title="Edit: BaaN Document" %>
<asp:Content ID="CPHlgDMisg" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgDMisg" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabellgDMisg" runat="server" Text="&nbsp;Edit: BaaN Document" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLlgDMisg"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "lgDMisg"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVlgDMisg"
	runat = "server"
	DataKeyNames = "t_docn,t_revn"
	DataSourceID = "ODSlgDMisg"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_t_docn" runat="server" ForeColor="#CC6633" Text="Document Number :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_t_docn"
						Text='<%# Bind("t_docn") %>'
            ToolTip="Value of Document Number."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="224px"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_t_revn" runat="server" ForeColor="#CC6633" Text="Revision :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_t_revn"
						Text='<%# Bind("t_revn") %>'
            ToolTip="Value of Revision."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="140px"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_t_dttl" runat="server" Text="Title :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_t_dttl"
						Text='<%# Bind("t_dttl") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgDMisg"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Title."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVt_dttl"
						runat = "server"
						ControlToValidate = "F_t_dttl"
						Text = "Title is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgDMisg"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_t_cspa" runat="server" Text="Element :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_t_cspa"
						Text='<%# Bind("t_cspa") %>'
            Width="56px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgDMisg"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Element."
						MaxLength="8"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVt_cspa"
						runat = "server"
						ControlToValidate = "F_t_cspa"
						Text = "Element is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgDMisg"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_t_cprj" runat="server" Text="Project :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_t_cprj"
						CssClass = "myfktxt"
						Text='<%# Bind("t_cprj") %>'
						AutoCompleteType = "None"
            Width="140px"
						onfocus = "return this.select();"
            ToolTip="Enter value for Project."
						ValidationGroup = "lgDMisg"
            onblur= "script_lgDMisg.validate_t_cprj(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_t_cprj_Display"
						Text='<%# Eval("LG_Projects1_ProjectDescription") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVt_cprj"
						runat = "server"
						ControlToValidate = "F_t_cprj"
						Text = "Project is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgDMisg"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEt_cprj"
            BehaviorID="B_ACEt_cprj"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="t_cprjCompletionList"
            TargetControlID="F_t_cprj"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_lgDMisg.ACEt_cprj_Selected"
            OnClientPopulating="script_lgDMisg.ACEt_cprj_Populating"
            OnClientPopulated="script_lgDMisg.ACEt_cprj_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_t_year" runat="server" Text="Year :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_t_year"
						Text='<%# Bind("t_year") %>'
            Width="28px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgDMisg"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Year."
						MaxLength="4"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVt_year"
						runat = "server"
						ControlToValidate = "F_t_year"
						Text = "Year is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgDMisg"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_t_stat" runat="server" Text="Status :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_t_stat"
						Text='<%# Bind("t_stat") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="lgDMisg"
						MaxLength="10"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEt_stat"
						runat = "server"
						mask = "9999999999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_t_stat" />
					<AJX:MaskedEditValidator 
						ID = "MEVt_stat"
						runat = "server"
						ControlToValidate = "F_t_stat"
						ControlExtender = "MEEt_stat"
						InvalidValueMessage = "Invalid value for Status."
						EmptyValueMessage = "Status is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Status."
						EnableClientScript = "true"
						ValidationGroup = "lgDMisg"
						IsValidEmpty = "false"
						MinimumValue = "1"
						MinimumValueBlurredText = "Status should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_t_wfst" runat="server" Text="WFStatus :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_t_wfst"
						Text='<%# Bind("t_wfst") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="lgDMisg"
						MaxLength="10"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEt_wfst"
						runat = "server"
						mask = "9999999999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_t_wfst" />
					<AJX:MaskedEditValidator 
						ID = "MEVt_wfst"
						runat = "server"
						ControlToValidate = "F_t_wfst"
						ControlExtender = "MEEt_wfst"
						InvalidValueMessage = "Invalid value for WFStatus."
						EmptyValueMessage = "WFStatus is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for WFStatus."
						EnableClientScript = "true"
						ValidationGroup = "lgDMisg"
						IsValidEmpty = "false"
						MinimumValue = "1"
						MinimumValueBlurredText = "WFStatus should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_t_dsca" runat="server" Text="t_dsca :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_t_dsca"
						Text='<%# Bind("t_dsca") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgDMisg"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for t_dsca."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVt_dsca"
						runat = "server"
						ControlToValidate = "F_t_dsca"
						Text = "t_dsca is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgDMisg"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_t_sorc" runat="server" Text="t_sorc :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_t_sorc"
						Text='<%# Bind("t_sorc") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgDMisg"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for t_sorc."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVt_sorc"
						runat = "server"
						ControlToValidate = "F_t_sorc"
						Text = "t_sorc is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgDMisg"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSlgDMisg"
  DataObjectTypeName = "SIS.LG.lgDMisg"
  SelectMethod = "lgDMisgGetByID"
  UpdateMethod="lgDMisgUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.LG.lgDMisg"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="t_docn" Name="t_docn" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="t_revn" Name="t_revn" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
