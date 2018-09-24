<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_eitlPODocumentFile.aspx.vb" Inherits="EF_eitlPODocumentFile" title="Edit: PO Document File" %>
<asp:Content ID="CPHeitlPODocumentFile" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlPODocumentFile" runat="server" Text="&nbsp;Edit: PO Document File"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlPODocumentFile" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlPODocumentFile"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_eitlPODocumentFile.aspx?pk="
    ValidationGroup = "eitlPODocumentFile"
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
<asp:FormView ID="FVeitlPODocumentFile"
	runat = "server"
	DataKeyNames = "SerialNo,DocumentLineNo,FileNo"
	DataSourceID = "ODSeitlPODocumentFile"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
		<table style="margin:auto">
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="SerialNo :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SerialNo"
            Width="70px"
						Text='<%# Bind("SerialNo") %>'
						CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of SerialNo."
						Runat="Server" />
					<asp:Label
						ID = "F_SerialNo_Display"
						Text='<%# Eval("EITL_POList2_PONumber") %>'
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentLineNo" runat="server" ForeColor="#CC6633" Text="DocumentLineNo :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_DocumentLineNo"
            Width="70px"
						Text='<%# Bind("DocumentLineNo") %>'
						CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of DocumentLineNo."
						Runat="Server" />
					<asp:Label
						ID = "F_DocumentLineNo_Display"
						Text='<%# Eval("EITL_PODocumentList1_DocumentID") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FileNo" runat="server" ForeColor="#CC6633" Text="FileNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_FileNo"
						Text='<%# Bind("FileNo") %>'
            ToolTip="Value of FileNo."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
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
						ValidationGroup="eitlPODocumentFile"
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
						ValidationGroup = "eitlPODocumentFile"
						SetFocusOnError="true" />
				</td>
			</tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FileName" runat="server" Text="File Name :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_FileName"
            Text='<%# Bind("FileName") %>'
            ToolTip="Value of File Name."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_DiskFile" runat="server" Text="Physical File ID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_DiskFile"
            Text='<%# Bind("DiskFile") %>'
            ToolTip="Value of Physical File ID."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td colspan="4">
          <asp:UpdatePanel ID="UPNLeitlPODocumentFile" runat="server">
            <ContentTemplate>
              <div id="F_Upload" runat="server" style="margin: auto" class="file_upload" visible="<%# Editable %>">
                <table>
                  <tr>
                    <td>
                      <asp:Label ID="L_FileUpload" runat="server" Font-Bold="true" Text="Attach Physical File :"></asp:Label>
                    </td>
                    <td style="text-align: left">
                      <input type="text" id="fileName" style="width: 300px" class="file_input_textbox" readonly="readonly">
                    </td>
                    <td>
                      <div class="file_input_div">
                        <input type="button" value="Browse file" title="Click to search file" class="file_input_button" />
                        <asp:FileUpload ID="F_FileUpload" runat="server" Width="100px" class="file_input_hidden" onchange="document.getElementById('fileName').value = this.value;" ToolTip="Click to search file" />
                      </div>
                    </td>
                    <td>
                      <asp:Button ID="cmdFileUpload" CssClass="file_upload_button" Text="Attach File" runat="server" ToolTip="Click to upload and attach file." CommandName="Upload" CommandArgument="" />
                    </td>
                  </tr>
                </table>
              </div>
            </ContentTemplate>
            <Triggers>
              <asp:PostBackTrigger ControlID="cmdFileUpload" />
            </Triggers>
          </asp:UpdatePanel>
        </td>
      </tr>
		</table>
	</div>
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSeitlPODocumentFile"
  DataObjectTypeName = "SIS.EITL.eitlPODocumentFile"
  SelectMethod = "eitlPODocumentFileGetByID"
  UpdateMethod="eitlPODocumentFileUpdate"
  DeleteMethod="eitlPODocumentFileDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlPODocumentFile"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DocumentLineNo" Name="DocumentLineNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FileNo" Name="FileNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
