<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_eitlIssuedPODocument.aspx.vb" Inherits="EF_eitlIssuedPODocument" title="View: Issued PO Document" %>
<asp:Content ID="CPHeitlIssuedPODocument" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlIssuedPODocument" runat="server" Text="&nbsp;View: Issued PO Document"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlIssuedPODocument" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlIssuedPODocument"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnableSave = "false"
    ValidationGroup = "eitlIssuedPODocument"
    runat = "server" />
<asp:FormView ID="FVeitlIssuedPODocument"
	runat = "server"
	DataKeyNames = "SerialNo,DocumentLineNo"
	DataSourceID = "ODSeitlIssuedPODocument"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
		<table style="margin:auto">
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="PO No :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SerialNo"
            Width="70px"
						Text='<%# Bind("SerialNo") %>'
						CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of PO No."
						Runat="Server" />
					<asp:Label
						ID = "F_SerialNo_Display"
						Text='<%# Eval("EITL_POList1_PONumber") %>'
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_DocumentLineNo" runat="server" ForeColor="#CC6633" Text="Document Line No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DocumentLineNo"
						Text='<%# Bind("DocumentLineNo") %>'
            ToolTip="Value of Document Line No."
            Enabled = "False"
            Width="70px"
						CssClass = "dmypktxt"
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
            ToolTip="Value of Document ID."
            Enabled = "False"
            Width="350px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_RevisionNo" runat="server" Text="Revision No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RevisionNo"
						Text='<%# Bind("RevisionNo") %>'
            ToolTip="Value of Revision No."
            Enabled = "False"
            Width="21px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
            ToolTip="Value of Description."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_ReadyToDespatch" runat="server" Text="Ready To Despatch :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_ReadyToDespatch"
					  Checked='<%# Bind("ReadyToDespatch") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
		</table>
	</div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeleitlIssuedPODocumentFile" runat="server" Text="&nbsp;View: Issued PO Document File"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLeitlIssuedPODocumentFile" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLeitlIssuedPODocumentFile"
      ToolType = "lgNMGrid"
      EditUrl = "~/EITL_Main/App_Edit/EF_eitlIssuedPODocumentFile.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "eitlIssuedPODocumentFile"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSeitlIssuedPODocumentFile" runat="server" AssociatedUpdatePanelID="UPNLeitlIssuedPODocumentFile" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVeitlIssuedPODocumentFile" SkinID="gv_silver" runat="server" DataSourceID="ODSeitlIssuedPODocumentFile" DataKeyNames="SerialNo,DocumentLineNo,FileNo">
      <Columns>
        <asp:TemplateField HeaderText="View">
          <ItemTemplate>
             <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="View the record." SkinID="info" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSeitlIssuedPODocumentFile"
      runat = "server"
      DataObjectTypeName = "SIS.EITL.eitlIssuedPODocumentFile"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "eitlIssuedPODocumentFileSelectList"
      TypeName = "SIS.EITL.eitlIssuedPODocumentFile"
      SelectCountMethod = "eitlIssuedPODocumentFileSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVeitlIssuedPODocumentFile" EventName="PageIndexChanged" />
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
  ID = "ODSeitlIssuedPODocument"
  DataObjectTypeName = "SIS.EITL.eitlIssuedPODocument"
  SelectMethod = "eitlIssuedPODocumentGetByID"
  UpdateMethod="eitlIssuedPODocumentUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlIssuedPODocument"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DocumentLineNo" Name="DocumentLineNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
