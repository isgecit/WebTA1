<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_eitlProjects.aspx.vb" Inherits="AF_eitlProjects" title="Add: Projects" %>
<asp:Content ID="CPHeitlProjects" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlProjects" runat="server" Text="&nbsp;Add: Projects"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlProjects" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlProjects"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "eitlProjects"
    runat = "server" />
<asp:FormView ID="FVeitlProjects"
	runat = "server"
	DataKeyNames = "ProjectID"
	DataSourceID = "ODSeitlProjects"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgeitlProjects" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table style="margin:auto">
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" ForeColor="#CC6633" runat="server" Text="Project :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ProjectID"
						Text='<%# Bind("ProjectID") %>'
						CssClass = "mypktxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Project."
						MaxLength="6"
            Width="42px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectID"
						runat = "server"
						ControlToValidate = "F_ProjectID"
						Text = "Project is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjects"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjects"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CustomerOrderReference" runat="server" Text="Customer Order Reference :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CustomerOrderReference"
						Text='<%# Bind("CustomerOrderReference") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Customer Order Reference."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVCustomerOrderReference"
						runat = "server"
						ControlToValidate = "F_CustomerOrderReference"
						Text = "Customer Order Reference is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjects"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_ContactPerson" runat="server" Text="Contact Person :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ContactPerson"
						Text='<%# Bind("ContactPerson") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Contact Person."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVContactPerson"
						runat = "server"
						ControlToValidate = "F_ContactPerson"
						Text = "Contact Person is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjects"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EmailID" runat="server" Text="Email-ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EmailID"
						Text='<%# Bind("EmailID") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Email-ID."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVEmailID"
						runat = "server"
						ControlToValidate = "F_EmailID"
						Text = "Email-ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjects"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_ContactNo" runat="server" Text="Contact No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ContactNo"
						Text='<%# Bind("ContactNo") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Contact No."
						MaxLength="20"
            Width="140px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVContactNo"
						runat = "server"
						ControlToValidate = "F_ContactNo"
						Text = "Contact No is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjects"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Address1" runat="server" Text="Address [1] :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Address1"
						Text='<%# Bind("Address1") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address [1]."
						MaxLength="60"
            Width="420px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVAddress1"
						runat = "server"
						ControlToValidate = "F_Address1"
						Text = "Address [1] is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjects"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Address2" runat="server" Text="Address [2] :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Address2"
						Text='<%# Bind("Address2") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address [2]."
						MaxLength="60"
            Width="420px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVAddress2"
						runat = "server"
						ControlToValidate = "F_Address2"
						Text = "Address [2] is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjects"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Address3" runat="server" Text="Address [3] :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Address3"
						Text='<%# Bind("Address3") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address [3]."
						MaxLength="60"
            Width="420px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVAddress3"
						runat = "server"
						ControlToValidate = "F_Address3"
						Text = "Address [3] is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjects"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Address4" runat="server" Text="Address [4] :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Address4"
						Text='<%# Bind("Address4") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address [4]."
						MaxLength="60"
            Width="420px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVAddress4"
						runat = "server"
						ControlToValidate = "F_Address4"
						Text = "Address [4] is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjects"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ToEMailID" runat="server" Text="TO E-Mail ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ToEMailID"
						Text='<%# Bind("ToEMailID") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for TO E-Mail ID."
						MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVToEMailID"
						runat = "server"
						ControlToValidate = "F_ToEMailID"
						Text = "TO E-Mail ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjects"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_CCEmailID" runat="server" Text="CC E-Mail ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CCEmailID"
						Text='<%# Bind("CCEmailID") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for CC E-Mail ID."
						MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVCCEmailID"
						runat = "server"
						ControlToValidate = "F_CCEmailID"
						Text = "CC E-Mail ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjects"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectSiteEMailID" runat="server" Text="Project Site E-Mail ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ProjectSiteEMailID"
						Text='<%# Bind("ProjectSiteEMailID") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Project Site E-Mail ID."
						MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectSiteEMailID"
						runat = "server"
						ControlToValidate = "F_ProjectSiteEMailID"
						Text = "Project Site E-Mail ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjects"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectSiteEMailPassword" runat="server" Text="Project Site E-Mail Password :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ProjectSiteEMailPassword"
						Text='<%# Bind("ProjectSiteEMailPassword") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Project Site E-Mail Password."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectSiteEMailPassword"
						runat = "server"
						ControlToValidate = "F_ProjectSiteEMailPassword"
						Text = "Project Site E-Mail Password is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjects"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_LastNumber" runat="server" Text="Last Number :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_LastNumber"
						Text='<%# Bind("LastNumber") %>'
            Width="70px"
						style="text-align: right"
						CssClass = "mytxt"
						ValidationGroup="eitlProjects"
						MaxLength="10"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEELastNumber"
						runat = "server"
						mask = "9999999999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_LastNumber" />
					<AJX:MaskedEditValidator 
						ID = "MEVLastNumber"
						runat = "server"
						ControlToValidate = "F_LastNumber"
						ControlExtender = "MEELastNumber"
						InvalidValueMessage = "Invalid value for Last Number."
						EmptyValueMessage = "Last Number is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Last Number."
						EnableClientScript = "true"
						ValidationGroup = "eitlProjects"
						IsValidEmpty = "false"
						MinimumValue = "1"
						MinimumValueBlurredText = "Last Number should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_BusinessPartnerID" runat="server" Text="Business Partner ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_BusinessPartnerID"
						CssClass = "myfktxt"
            Width="63px"
						Text='<%# Bind("BusinessPartnerID") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Business Partner ID."
						ValidationGroup = "eitlProjects"
            onblur= "script_eitlProjects.validate_BusinessPartnerID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_BusinessPartnerID_Display"
						Text='<%# Eval("EITL_Suppliers1_SupplierName") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVBusinessPartnerID"
						runat = "server"
						ControlToValidate = "F_BusinessPartnerID"
						Text = "Business Partner ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlProjects"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEBusinessPartnerID"
            BehaviorID="B_ACEBusinessPartnerID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="BusinessPartnerIDCompletionList"
            TargetControlID="F_BusinessPartnerID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_eitlProjects.ACEBusinessPartnerID_Selected"
            OnClientPopulating="script_eitlProjects.ACEBusinessPartnerID_Populating"
            OnClientPopulated="script_eitlProjects.ACEBusinessPartnerID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
		</table>
		</div>
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSeitlProjects"
  DataObjectTypeName = "SIS.EITL.eitlProjects"
  InsertMethod="eitlProjectsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlProjects"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
