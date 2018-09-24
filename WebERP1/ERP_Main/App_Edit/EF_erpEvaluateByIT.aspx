<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_erpEvaluateByIT.aspx.vb" Inherits="EF_erpEvaluateByIT" title="Edit: Evaluation By IT" %>
<asp:Content ID="CPHerpEvaluateByIT" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpEvaluateByIT" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelerpEvaluateByIT" runat="server" Text="&nbsp;Edit: Evaluation By IT" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpEvaluateByIT"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_erpEvaluateByIT.aspx?pk="
    ValidationGroup = "erpEvaluateByIT"
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
      	var url = self.location.href.replace('App_Edit/EF_erpEvaluateByIT.aspx', 'App_Downloads/filedownload.aspx');
      	url = url + '&id=' + id + '&typ=' + typ + '&id1=' + id1;
      	window.open(url, nam, 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');
      	return false;
      }
    </script>
<asp:FormView ID="FVerpEvaluateByIT"
	runat = "server"
	DataKeyNames = "ApplID,RequestID"
	DataSourceID = "ODSerpEvaluateByIT"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
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
			</tr>
			<tr>
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
					<b><asp:Label ID="L_RequestTypeID" runat="server" Text="Request Type :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_RequestTypeID"
            Width="70px"
						Text='<%# Bind("RequestTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Request Type."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_RequestTypeID_Display"
						Text='<%# Eval("ERP_RequestTypes6_Description") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ChangeSubject" runat="server" Text="Brief Problem (Improvement) Statement :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ChangeSubject"
						Text='<%# Bind("ChangeSubject") %>'
            ToolTip="Value of Brief Problem (Improvement) Statement."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ChangeDetails" runat="server" Text="Change Requested (In Detail) :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ChangeDetails"
						Text='<%# Bind("ChangeDetails") %>'
            ToolTip="Value of Change Requested (In Detail)."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
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
					<b><asp:Label ID="L_StatusID" runat="server" Text="STATUS :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_StatusID"
            Width="70px"
						Text='<%# Bind("StatusID") %>'
            Enabled = "False"
            ToolTip="Value of STATUS."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_StatusID_Display"
						Text='<%# Eval("ERP_RequestStatus5_Description") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EvaluationByIT" runat="server" Text="Evaluation By IT :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EvaluationByIT"
						Text='<%# Bind("EvaluationByIT") %>'
            Width="700px" Height="80px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Evaluation By IT."
						MaxLength="2000"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVEvaluationByIT"
						runat = "server"
						ControlToValidate = "F_EvaluationByIT"
						Text = "Evaluation By IT is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup="erpEvaluateByIT"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Justification" runat="server" Text="Justification :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Justification"
						Text='<%# Bind("Justification") %>'
            Width="700px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpEvaluateByIT"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Justification."
						MaxLength="1000"
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
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EvaluationByESC" runat="server" Text="Evaluation By ESC :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EvaluationByESC"
						Text='<%# Bind("EvaluationByESC") %>'
            ToolTip="Value of Evaluation By ESC."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
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
					<b><asp:Label ID="L_ReturnRemarks" runat="server" Text="Remarks :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ReturnRemarks"
						Text='<%# Bind("ReturnRemarks") %>'
            ToolTip="Value of Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PriorityID" runat="server" Text="PRIORITY :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_PriorityID"
            Width="70px"
						Text='<%# Bind("PriorityID") %>'
            Enabled = "False"
            ToolTip="Value of PRIORITY."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_PriorityID_Display"
						Text='<%# Eval("ERP_RequestPriority4_Description") %>'
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
            ToolTip="Value of MSL Portal Number."
            Enabled = "False"
            Width="350px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MSLPortalOn" runat="server" Text="MSL Case Logged On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MSLPortalOn"
						Text='<%# Bind("MSLPortalOn") %>'
            ToolTip="Value of MSL Case Logged On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EffortEstimation" runat="server" Text="Effort Estimation By MSL :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EffortEstimation"
						Text='<%# Bind("EffortEstimation") %>'
            ToolTip="Value of Effort Estimation By MSL."
            Enabled = "False"
            Width="70px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PlannedDeliveryDate" runat="server" Text="Planned Delivery Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PlannedDeliveryDate"
						Text='<%# Bind("PlannedDeliveryDate") %>'
            ToolTip="Value of Planned Delivery Date."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ActualDeliveryDate" runat="server" Text="Actual Delivery Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ActualDeliveryDate"
						Text='<%# Bind("ActualDeliveryDate") %>'
            ToolTip="Value of Actual Delivery Date."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ClosingRemarks" runat="server" Text="Closing Remarks :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ClosingRemarks"
						Text='<%# Bind("ClosingRemarks") %>'
            ToolTip="Value of Closing Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
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
  ID = "ODSerpEvaluateByIT"
  DataObjectTypeName = "SIS.ERP.erpEvaluateByIT"
  SelectMethod = "erpEvaluateByITGetByID"
  UpdateMethod="erpEvaluateByITUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpEvaluateByIT"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ApplID" Name="ApplID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RequestID" Name="RequestID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
