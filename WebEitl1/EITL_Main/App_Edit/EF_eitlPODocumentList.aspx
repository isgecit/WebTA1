<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_eitlPODocumentList.aspx.vb" Inherits="EF_eitlPODocumentList" title="Edit: PO Document" %>
<asp:Content ID="CPHeitlPODocumentList" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlPODocumentList" runat="server" Text="&nbsp;Edit: PO Document"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlPODocumentList" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlPODocumentList"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_eitlPODocumentList.aspx?pk="
    ValidationGroup = "eitlPODocumentList"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Edit/EF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVeitlPODocumentList"
	runat = "server"
	DataKeyNames = "SerialNo,DocumentLineNo"
	DataSourceID = "ODSeitlPODocumentList"
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
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentLineNo" runat="server" ForeColor="#CC6633" Text="Document Line No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DocumentLineNo"
						Text='<%# Bind("DocumentLineNo") %>'
            ToolTip="Value of Document Line No."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPODocumentList"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Document ID."
						MaxLength="50"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDocumentID"
						runat = "server"
						ControlToValidate = "F_DocumentID"
						Text = "Document ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPODocumentList"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_RevisionNo" runat="server" Text="Revision No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RevisionNo"
						Text='<%# Bind("RevisionNo") %>'
            Width="21px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPODocumentList"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Revision No."
						MaxLength="3"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVRevisionNo"
						runat = "server"
						ControlToValidate = "F_RevisionNo"
						Text = "Revision No is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPODocumentList"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPODocumentList"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="200"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPODocumentList"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_ReadyToDespatch" runat="server" Text="Ready To Despatch :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_ReadyToDespatch"
					  Checked='<%# Bind("ReadyToDespatch") %>'
            runat="server" />
				</td>
			</tr>
		</table>
	</div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeleitlPODocumentFile" runat="server" Text="&nbsp;Edit: PO Document File"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLeitlPODocumentFile" runat="server">
  <ContentTemplate>
    <div id="F_Upload" runat="server" style="margin:auto" class="file_upload"  visible="<%# Editable %>" >
      <table>
        <tr>
          <td>
            <asp:Label ID="L_FileUpload" runat="server" Font-Bold="true" Text="Upload File(s) against Document :"></asp:Label>
          </td>
          <td style="text-align:left">
            <input type="text" id="fileName" style="width:300px" class="file_input_textbox" readonly="readonly">
           </td>
          <td>
            <div class="file_input_div">
              <input type="button" value="Browse file" title="Click to search file" class="file_input_button" />
              <asp:FileUpload ID="F_FileUpload" runat="server" Width="100px"  class="file_input_hidden" onchange="document.getElementById('fileName').value = this.value;" ToolTip="Click to search file" />
            </div>
          </td>
          <td>
            <asp:Button ID="cmdFileUpload" CssClass="file_upload_button" Text="Upload File" runat="server" ToolTip="Click to upload file." CommandName="Upload" CommandArgument="" />
          </td>
        </tr>
        </table>
      </div>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLeitlPODocumentFile"
      ToolType = "lgNMGrid"
      EditUrl = "~/EITL_Main/App_Edit/EF_eitlPODocumentFile.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "eitlPODocumentFile"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSeitlPODocumentFile" runat="server" AssociatedUpdatePanelID="UPNLeitlPODocumentFile" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVeitlPODocumentFile" SkinID="gv_silver" runat="server" DataSourceID="ODSeitlPODocumentFile" DataKeyNames="SerialNo,DocumentLineNo,FileNo">
      <Columns>
        <asp:TemplateField HeaderText="Edit">
          <ItemTemplate>
             <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Download File">
          <ItemTemplate >
              <asp:ImageButton ID="cmdDownload" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Download File." SkinID="download" OnClientClick='<%# Eval("GetDownloadLink") %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="300px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="File Name" SortExpression="FileName">
          <ItemTemplate>
            <asp:Label ID="LabelFileName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Physical File ID" SortExpression="DiskFile">
          <ItemTemplate>
            <asp:Label ID="LabelDiskFile" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DiskFile") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="200px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSeitlPODocumentFile"
      runat = "server"
      DataObjectTypeName = "SIS.EITL.eitlPODocumentFile"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "eitlPODocumentFileSelectList"
      TypeName = "SIS.EITL.eitlPODocumentFile"
      SelectCountMethod = "eitlPODocumentFileSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_DocumentLineNo" PropertyName="Text" Name="DocumentLineNo" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVeitlPODocumentFile" EventName="PageIndexChanged" />
    <asp:PostBackTrigger ControlID="cmdFileUpload" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSeitlPODocumentList"
  DataObjectTypeName = "SIS.EITL.eitlPODocumentList"
  SelectMethod = "eitlPODocumentListGetByID"
  UpdateMethod="eitlPODocumentListUpdate"
  DeleteMethod="eitlPODocumentListDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlPODocumentList"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DocumentLineNo" Name="DocumentLineNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
