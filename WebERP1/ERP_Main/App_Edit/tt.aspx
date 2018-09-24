<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="tt.aspx.vb" Inherits="ERP_Main_App_Edit_tt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" Runat="Server">
		<table style="text-align:left">
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
        <td>
					<b><asp:Label ID="L_ApplID" runat="server" ForeColor="#CC6633" Text="Appl ID :" /></b>
        </td>
        <td>
					<b>
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
        	</b>
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
        <td>
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
					&nbsp;</td>
				<td>
					&nbsp;</td>
				<td>
					&nbsp;</td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
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
						ValidationGroup = "erpChaneRequest"
            RequiredFieldErrorMessage = "Request Type is required."
            onblur= "script_erpChaneRequest.validate_RequestTypeID(this);"
            Runat="Server" />
          </td>
        <td>
          &nbsp;</td>
        <td>
          &nbsp;</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ChangeSubject" runat="server" Text="Brief Problem (Improvement) Statement :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ChangeSubject"
						Text='<%# Bind("ChangeSubject") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpChaneRequest"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Brief Problem (Improvement) Statement."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVChangeSubject"
						runat = "server"
						ControlToValidate = "F_ChangeSubject"
						Text = "Brief Problem (Improvement) Statement is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpChaneRequest"
						SetFocusOnError="true" />
				</td>
				<td>
					&nbsp;</td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ChangeDetails" runat="server" Text="Change Requested (In Detail) :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ChangeDetails"
						Text='<%# Bind("ChangeDetails") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpChaneRequest"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Change Requested (In Detail)."
						MaxLength="500"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVChangeDetails"
						runat = "server"
						ControlToValidate = "F_ChangeDetails"
						Text = "Change Requested (In Detail) is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpChaneRequest"
						SetFocusOnError="true" />
				</td>
				<td>
					&nbsp;</td>
				<td>
					&nbsp;</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ReturnRemarks" runat="server" Text="Remarks By HOD :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ReturnRemarks"
						Text='<%# Bind("ReturnRemarks") %>'
            ToolTip="Value of Remarks By HOD."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
				<td>
					&nbsp;</td>
				<td>
					&nbsp;</td>
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
        <td>
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
				<td>
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
				<td>
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
				<td>
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
					<b><asp:Label ID="L_Justification" runat="server" Text="Justification :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Justification"
						Text='<%# Bind("Justification") %>'
            ToolTip="Value of Justification."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
				<td>
					&nbsp;</td>
				<td>
					&nbsp;</td>
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
				<td>
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
				<td>
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
			</table>

</asp:Content>

