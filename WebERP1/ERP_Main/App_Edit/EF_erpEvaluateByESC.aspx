<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_erpEvaluateByESC.aspx.vb" Inherits="EF_erpEvaluateByESC" title="Edit: Evaluation By ESC" %>
<asp:Content ID="CPHerpEvaluateByESC" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpEvaluateByESC" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelerpEvaluateByESC" runat="server" Text="&nbsp;Edit: Evaluation By ESC" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpEvaluateByESC"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_erpEvaluateByESC.aspx?pk="
    ValidationGroup = "erpEvaluateByESC"
    Skin = "tbl_blue"
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
      function script_download(id, id1, typ) {
      	pcnt = pcnt + 1;
      	var nam = 'wdwd' + pcnt;
      	var url = self.location.href.replace('App_Edit/EF_erpEvaluateByESC.aspx', 'App_Downloads/filedownload.aspx');
      	url = url + '&id=' + id + '&typ=' + typ + '&id1=' + id1;
      	window.open(url, nam, 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');
      	return false;
      }
    </script>
<asp:FormView ID="FVerpEvaluateByESC"
	runat = "server"
	DataKeyNames = "ApplID,RequestID"
	DataSourceID = "ODSerpEvaluateByESC"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
        <td class="alignright">
					<b><asp:Label ID="L_RequestID" runat="server" ForeColor="#CC6633" Text="Request ID :" /></b>
        </td>
        <td>
					<asp:TextBox ID="F_RequestID"
						Text='<%# Bind("RequestID") %>'
            ToolTip="Value of Request ID."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_ApplID" runat="server" ForeColor="#CC6633" Text="Appl ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ApplID"
            Width="70px"
						Text='<%# Bind("ApplID") %>'
						CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Appl ID."
						Runat="Server" />
					<asp:Label
						ID = "F_ApplID_Display"
						Text='<%# Eval("ERP_Applications3_ApplName") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestedBy" runat="server" Text="Requested By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_RequestedBy"
            Width="56px"
						Text='<%# Bind("RequestedBy") %>'
            Enabled = "False"
            ToolTip="Value of Requested By."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_RequestedBy_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
						Runat="Server" />
        </td>
        <td class="alignright">
					<b><asp:Label ID="L_RequestedOn" runat="server" Text="Requested On :" /></b>
				</td>
        <td>
					<asp:TextBox ID="F_RequestedOn"
						Text='<%# Bind("RequestedOn") %>'
            ToolTip="Value of Requested On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ApprovedBy" runat="server" Text="Approved By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ApprovedBy"
            Width="56px"
						Text='<%# Bind("ApprovedBy") %>'
            Enabled = "False"
            ToolTip="Value of Approved By."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ApprovedBy_Display"
						Text='<%# Eval("aspnet_Users2_UserFullName") %>'
						Runat="Server" />
        </td>
        <td class="alignright">
					<b><asp:Label ID="L_ApprovedOn" runat="server" Text="Approved On :" /></b>
				</td>
        <td>
					<asp:TextBox ID="F_ApprovedOn"
						Text='<%# Bind("ApprovedOn") %>'
            ToolTip="Value of Approved On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ReturnRemarks" runat="server" Text="Approver's Comments :" /></b>
				</td>
				<td colspan="3">
					<asp:TextBox ID="F_ReturnRemarks"
						Text='<%# Bind("ReturnRemarks") %>'
            ToolTip="Value of Remarks."
            Enabled = "False"
            Width="550px" Height="30px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ChangeSubject" runat="server" Text="Brief Problem (Improvement) Statement :" /></b>
				</td>
				<td colspan="3">
					<asp:TextBox ID="F_ChangeSubject"
						Text='<%# Bind("ChangeSubject") %>'
            ToolTip="Value of Brief Problem (Improvement) Statement."
            Enabled = "False"
            Width="700px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ChangeDetails" runat="server" Text="Change Requested (In Detail) :" /></b>
				</td>
        <td colspan="3">
					<asp:TextBox ID="F_ChangeDetails"
						Text='<%# Bind("ChangeDetails") %>'
            ToolTip="Value of Change Requested (In Detail)."
            Enabled = "False"
            Width="700px" Height="60px"
						CssClass = "dmytxt"
						runat="server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EvaluationByIT" runat="server" Text="Evaluation By IT :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EvaluationByIT"
						Text='<%# Bind("EvaluationByIT") %>'
            ToolTip="Value of Evaluation By IT."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_EvaluationByITOn" runat="server" Text="Evaluated By IT On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EvaluationByITOn"
						Text='<%# Bind("EvaluationByITOn") %>'
            ToolTip="Value of Evaluated By IT On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Justification" runat="server" Text="Justification :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Justification"
						Text='<%# Bind("Justification") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "dmytxt"
						onfocus = "return this.select();"
					  Enabled="false"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_StatusID" runat="server" Text="STATUS :" /></b>
				</td>
				<td>
          <LGM:LC_erpRequestStatus
            ID="F_StatusID"
            SelectedValue='<%# Bind("StatusID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myfktxt"
						ValidationGroup = "erpEvaluateByESC"
            RequiredFieldErrorMessage = "STATUS is required."
            onblur= "script_erpEvaluateByESC.validate_StatusID(this);"
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EvaluationByESC" runat="server" Text="Evaluation By ESC :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EvaluationByESC"
						Text='<%# Bind("EvaluationByESC") %>'
            Width="350px" Height="80px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpEvaluateByESC"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Evaluation By ESC."
						MaxLength="2000"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVEvaluationByESC"
						runat = "server"
						ControlToValidate = "F_EvaluationByESC"
						Text = "*"
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpEvaluateByESC"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_EvaluationByESCOn" runat="server" Text="Evaluated By ESC On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EvaluationByESCOn"
						Text='<%# Bind("EvaluationByESCOn") %>'
            ToolTip="Value of Evaluated By ESC On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PriorityID" runat="server" Text="PRIORITY :" /></b>
				</td>
        <td>
          <LGM:LC_erpRequestPriority
            ID="F_PriorityID"
            SelectedValue='<%# Bind("PriorityID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myfktxt"
						ValidationGroup = "erpEvaluateByESC"
            RequiredFieldErrorMessage = "*"
            onblur= "script_erpEvaluateByESC.validate_PriorityID(this);"
            Runat="Server" />
          </td>
        <td class="alignright">
					<b><asp:Label ID="L_RequestTypeID" runat="server" Text="Request Type :" /></b>
				</td>
        <td>
          <LGM:LC_erpRequestTypes
            ID="F_RequestTypeID"
            SelectedValue='<%# Bind("RequestTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myfktxt"
						ValidationGroup = "erpEvaluateByESC"
            RequiredFieldErrorMessage = "Request Type is required."
            onblur= "script_erpEvaluateByESC.validate_RequestTypeID(this);"
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MSLPortalNumber" runat="server" Text="MSL Portal Number :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MSLPortalNumber"
						Text='<%# Bind("MSLPortalNumber") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpEvaluateByESC"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for MSL Portal Number."
						MaxLength="50"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_MSLPortalOn" runat="server" Text="MSL Case Logged On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MSLPortalOn"
						Text='<%# Bind("MSLPortalOn") %>'
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpEvaluateByESC"
						runat="server" />
          <AJX:CalendarExtender 
            ID = "CEMSLPortalOn"
            TargetControlID="F_MSLPortalOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonMSLPortalOn" />
					<AJX:MaskedEditExtender 
						ID = "MEEMSLPortalOn"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MSLPortalOn" />
					<asp:Image ID="ImageButtonMSLPortalOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EffortEstimation" runat="server" Text="Effort Estimation By MSL :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EffortEstimation"
						Text='<%# Bind("EffortEstimation") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="erpEvaluateByESC"
						MaxLength="12"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEEffortEstimation"
						runat = "server"
						mask = "9999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_EffortEstimation" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_PlannedDeliveryDate" runat="server" Text="Planned Delivery Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PlannedDeliveryDate"
						Text='<%# Bind("PlannedDeliveryDate") %>'
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpEvaluateByESC"
						runat="server" />
          <AJX:CalendarExtender 
            ID = "CEPlannedDeliveryDate"
            TargetControlID="F_PlannedDeliveryDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonPlannedDeliveryDate" />
					<AJX:MaskedEditExtender 
						ID = "MEEPlannedDeliveryDate"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_PlannedDeliveryDate" />
					<asp:Image ID="ImageButtonPlannedDeliveryDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ActualDeliveryDate" runat="server" Text="Actual Delivery Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ActualDeliveryDate"
						Text='<%# Bind("ActualDeliveryDate") %>'
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpEvaluateByESC"
						runat="server" />
					<asp:Image ID="ImageButtonActualDeliveryDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEActualDeliveryDate"
            TargetControlID="F_ActualDeliveryDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonActualDeliveryDate" />
					<AJX:MaskedEditExtender 
						ID = "MEEActualDeliveryDate"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_ActualDeliveryDate" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_ClosingRemarks" runat="server" Text="Closing Remarks :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ClosingRemarks"
						Text='<%# Bind("ClosingRemarks") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpEvaluateByESC"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Closing Remarks."
						MaxLength="100"
						runat="server" />
				</td>
			</tr>
			</table>
<asp:UpdatePanel ID="UPNLerpRequestAttachments" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelerpRequestAttachments" runat="server" Text="&nbsp;List: Attachments" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLerpRequestAttachments"
      ToolType = "lgNMGrid"
      EditUrl = "~/ERP_Main/App_Edit/EF_erpRequestAttachments.aspx"
      AddUrl = "~/ERP_Main/App_Create/AF_erpRequestAttachments.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "erpRequestAttachments"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSerpRequestAttachments" runat="server" AssociatedUpdatePanelID="UPNLerpRequestAttachments" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVerpRequestAttachments" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSerpRequestAttachments" DataKeyNames="ApplID,RequestID,SerialNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
						<asp:LinkButton ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>' OnClientClick='<%# Eval("GetLink") %>'></asp:LinkButton>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSerpRequestAttachments"
      runat = "server"
      DataObjectTypeName = "SIS.ERP.erpRequestAttachments"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "erpRequestAttachmentsSelectList"
      TypeName = "SIS.ERP.erpRequestAttachments"
      SelectCountMethod = "erpRequestAttachmentsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ApplID" PropertyName="Text" Name="ApplID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_RequestID" PropertyName="Text" Name="RequestID" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVerpRequestAttachments" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSerpEvaluateByESC"
  DataObjectTypeName = "SIS.ERP.erpEvaluateByESC"
  SelectMethod = "erpEvaluateByESCGetByID"
  UpdateMethod="UZ_erpEvaluateByESCUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpEvaluateByESC"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ApplID" Name="ApplID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RequestID" Name="RequestID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
