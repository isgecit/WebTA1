<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_lgEPAttributes.aspx.vb" Inherits="EF_lgEPAttributes" title="Edit: EPM Attributes" %>
<asp:Content ID="CPHlgEPAttributes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLlgEPAttributes" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabellgEPAttributes" runat="server" Text="&nbsp;Edit: EPM Attributes" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLlgEPAttributes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    EnableSave="false"
    PrintUrl = "../App_Print/RP_lgEPAttributes.aspx?pk="
    ValidationGroup = "lgEPAttributes"
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
    </script>
<asp:FormView ID="FVlgEPAttributes"
	runat = "server"
	DataKeyNames = "DocPK,displayName"
	DataSourceID = "ODSlgEPAttributes"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DocPK" runat="server" ForeColor="#CC6633" Text="DocPK :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DocPK"
            Width="133px"
						Text='<%# Bind("DocPK") %>'
						CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of DocPK."
						Runat="Server" />
					<asp:Label
						ID = "F_DocPK_Display"
						Text='<%# Eval("LG_EPDocument1_DocumentID") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_displayName" runat="server" ForeColor="#CC6633" Text="Attribute Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_displayName"
						Text='<%# Bind("displayName") %>'
            ToolTip="Value of Attribute Name."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="350px"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentID" runat="server" Text="Document ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DocumentID"
						Text='<%# Bind("DocumentID") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPAttributes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Document ID."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDocumentID"
						runat = "server"
						ControlToValidate = "F_DocumentID"
						Text = "Document ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPAttributes"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Revision" runat="server" Text="Revision :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Revision"
						Text='<%# Bind("Revision") %>'
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPAttributes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Revision."
						MaxLength="10"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVRevision"
						runat = "server"
						ControlToValidate = "F_Revision"
						Text = "Revision is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPAttributes"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Iteration" runat="server" Text="Iteration :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Iteration"
						Text='<%# Bind("Iteration") %>'
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPAttributes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Iteration."
						MaxLength="10"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVIteration"
						runat = "server"
						ControlToValidate = "F_Iteration"
						Text = "Iteration is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPAttributes"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Status" runat="server" Text="Status :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Status"
						Text='<%# Bind("Status") %>'
            Width="210px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPAttributes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Status."
						MaxLength="30"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVStatus"
						runat = "server"
						ControlToValidate = "F_Status"
						Text = "Status is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPAttributes"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_value" runat="server" Text="Value :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_value"
						Text='<%# Bind("value") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="lgEPAttributes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Value."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVvalue"
						runat = "server"
						ControlToValidate = "F_value"
						Text = "Value is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "lgEPAttributes"
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
  ID = "ODSlgEPAttributes"
  DataObjectTypeName = "SIS.LG.lgEPAttributes"
  SelectMethod = "lgEPAttributesGetByID"
  UpdateMethod="lgEPAttributesUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.LG.lgEPAttributes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DocPK" Name="DocPK" Type="Int64" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="displayName" Name="displayName" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
