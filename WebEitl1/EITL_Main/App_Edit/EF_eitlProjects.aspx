<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_eitlProjects.aspx.vb" Inherits="EF_eitlProjects" title="Edit: Projects" %>
<asp:Content ID="CPHeitlProjects" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlProjects" runat="server" Text="&nbsp;Edit: Projects"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlProjects" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlProjects"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_eitlProjects.aspx?pk="
    ValidationGroup = "eitlProjects"
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
<asp:FormView ID="FVeitlProjects"
	runat = "server"
	DataKeyNames = "ProjectID"
	DataSourceID = "ODSeitlProjects"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
		<table style="margin:auto">
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ProjectID"
						Text='<%# Bind("ProjectID") %>'
            ToolTip="Value of Project."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="42px"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="50"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Customer Order Reference."
						MaxLength="50"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Contact Person."
						MaxLength="50"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Email-ID."
						MaxLength="50"
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
            Width="140px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Contact No."
						MaxLength="20"
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
            Width="420px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address [1]."
						MaxLength="60"
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
            Width="420px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address [2]."
						MaxLength="60"
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
            Width="420px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address [3]."
						MaxLength="60"
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
            Width="420px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address [4]."
						MaxLength="60"
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for TO E-Mail ID."
						MaxLength="250"
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for CC E-Mail ID."
						MaxLength="250"
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Project Site E-Mail ID."
						MaxLength="250"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlProjects"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Project Site E-Mail Password."
						MaxLength="50"
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
						style="text-align: right"
            Width="70px"
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
						Text='<%# Bind("BusinessPartnerID") %>'
						AutoCompleteType = "None"
            Width="63px"
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
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSeitlProjects"
  DataObjectTypeName = "SIS.EITL.eitlProjects"
  SelectMethod = "eitlProjectsGetByID"
  UpdateMethod="eitlProjectsUpdate"
  DeleteMethod="eitlProjectsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlProjects"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
