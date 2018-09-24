<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_eitlIssuedPO.aspx.vb" Inherits="EF_eitlIssuedPO" title="View: Issued Purchase Orders" %>
<asp:Content ID="CPHeitlIssuedPO" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlIssuedPO" runat="server" Text="&nbsp;View: Issued Purchase Orders"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlIssuedPO" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlIssuedPO"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnableSave = "false"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_eitlPOList.aspx?pk="
    ValidationGroup = "eitlIssuedPO"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Edit/EF_eitlIssuedPO.aspx', 'App_Print/RP_eitlPOList.aspx');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVeitlIssuedPO"
	runat = "server"
	DataKeyNames = "SerialNo"
	DataSourceID = "ODSeitlIssuedPO"
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
					<b><asp:Label ID="L_PONumber" runat="server" Text="PO Number :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PONumber"
						Text='<%# Bind("PONumber") %>'
            ToolTip="Value of PO Number."
            Enabled = "False"
            Width="70px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PORevision" runat="server" Text="PO Revision :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PORevision"
						Text='<%# Bind("PORevision") %>'
            ToolTip="Value of PO Revision."
            Enabled = "False"
            Width="70px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_PODate" runat="server" Text="PO Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PODate"
						Text='<%# Bind("PODate") %>'
            ToolTip="Value of PO Date."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SupplierID" runat="server" Text="Supplier :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SupplierID"
            Width="63px"
						Text='<%# Bind("SupplierID") %>'
            Enabled = "False"
            ToolTip="Value of Supplier."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_SupplierID_Display"
						Text='<%# Eval("EITL_Suppliers5_SupplierName") %>'
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" runat="server" Text="Project :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProjectID"
            Width="42px"
						Text='<%# Bind("ProjectID") %>'
            Enabled = "False"
            ToolTip="Value of Project."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ProjectID_Display"
						Text='<%# Eval("IDM_Projects6_Description") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DivisionID" runat="server" Text="Division :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DivisionID"
						Text='<%# Bind("DivisionID") %>'
            ToolTip="Value of Division."
            Enabled = "False"
            Width="70px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_BuyerID" runat="server" Text="Buyer :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_BuyerID"
            Width="56px"
						Text='<%# Bind("BuyerID") %>'
            Enabled = "False"
            ToolTip="Value of Buyer."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_BuyerID_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_POStatusID" runat="server" Text="PO Status :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_POStatusID"
            Width="70px"
						Text='<%# Bind("POStatusID") %>'
            Enabled = "False"
            ToolTip="Value of PO Status."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_POStatusID_Display"
						Text='<%# Eval("EITL_POStatus4_Description") %>'
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_IssuedBy" runat="server" Text="Issued By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_IssuedBy"
            Width="56px"
						Text='<%# Bind("IssuedBy") %>'
            Enabled = "False"
            ToolTip="Value of Issued By."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_IssuedBy_Display"
						Text='<%# Eval("aspnet_Users3_UserFullName") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_IssuedOn" runat="server" Text="Issued On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_IssuedOn"
						Text='<%# Bind("IssuedOn") %>'
            ToolTip="Value of Issued On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_ClosedBy" runat="server" Text="Closed By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ClosedBy"
            Width="56px"
						Text='<%# Bind("ClosedBy") %>'
            Enabled = "False"
            ToolTip="Value of Closed By."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ClosedBy_Display"
						Text='<%# Eval("aspnet_Users2_UserFullName") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ClosedOn" runat="server" Text="Closed On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ClosedOn"
						Text='<%# Bind("ClosedOn") %>'
            ToolTip="Value of Closed On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			<td></td><td></td></tr>
		</table>
	</div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeleitlIssuedPODocument" runat="server" Text="&nbsp;List: Issued PO Document"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLeitlIssuedPODocument" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLeitlIssuedPODocument"
      ToolType = "lgNMGrid"
      EditUrl = "~/EITL_Main/App_Edit/EF_eitlIssuedPODocument.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "eitlIssuedPODocument"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSeitlIssuedPODocument" runat="server" AssociatedUpdatePanelID="UPNLeitlIssuedPODocument" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVeitlIssuedPODocument" SkinID="gv_silver" runat="server" DataSourceID="ODSeitlIssuedPODocument" DataKeyNames="SerialNo,DocumentLineNo">
      <Columns>
        <asp:TemplateField HeaderText="View">
          <ItemTemplate >
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document Line No" SortExpression="DocumentLineNo">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentLineNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentLineNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="60px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document ID" SortExpression="DocumentID">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="REV" SortExpression="RevisionNo">
          <ItemTemplate>
            <asp:Label ID="LabelRevisionNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RevisionNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="300px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Ready To Despatch" SortExpression="ReadyToDespatch">
          <ItemTemplate>
            <asp:Label ID="LabelReadyToDespatch" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ReadyToDespatch") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="60px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSeitlIssuedPODocument"
      runat = "server"
      DataObjectTypeName = "SIS.EITL.eitlIssuedPODocument"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "eitlIssuedPODocumentSelectList"
      TypeName = "SIS.EITL.eitlIssuedPODocument"
      SelectCountMethod = "eitlIssuedPODocumentSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVeitlIssuedPODocument" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabeleitlIssuedPOItem" runat="server" Text="&nbsp;List: Issued PO Items"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLeitlIssuedPOItem" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLeitlIssuedPOItem"
      ToolType = "lgNMGrid"
      EditUrl = "~/EITL_Main/App_Edit/EF_eitlIssuedPOItem.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "eitlIssuedPOItem"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSeitlIssuedPOItem" runat="server" AssociatedUpdatePanelID="UPNLeitlIssuedPOItem" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVeitlIssuedPOItem" SkinID="gv_silver" runat="server" DataSourceID="ODSeitlIssuedPOItem" DataKeyNames="SerialNo,ItemLineNo">
      <Columns>
        <asp:TemplateField HeaderText="View">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Code" SortExpression="ItemCode">
          <ItemTemplate>
            <asp:Label ID="LabelItemCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemCode") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM" SortExpression="EITL_Units6_Description">
          <ItemTemplate>
             <asp:Label ID="L_UOM" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOM") %>' Text='<%# Eval("EITL_Units6_Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
          <ItemTemplate>
            <asp:Label ID="LabelQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Quantity") %>'></asp:Label>
          </ItemTemplate>
           <ItemStyle CssClass="alignright" />
         <HeaderStyle CssClass="alignright"  Width="80px"/>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Weight In KG" SortExpression="WeightInKG">
          <ItemTemplate>
            <asp:Label ID="LabelWeightInKG" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("WeightInKG") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="80px"  CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document " SortExpression="EITL_PODocumentList3_DocumentID">
          <ItemTemplate>
             <asp:Label ID="L_DocumentLineNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("DocumentLineNo") %>' Text='<%# Eval("EITL_PODocumentList3_DocumentID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Despatched" SortExpression="Despatched">
          <ItemTemplate>
            <asp:Label ID="LabelDespatched" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Despatched") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="60px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="VR Execution No" SortExpression="VR_ExecutionNo">
          <ItemTemplate>
            <asp:Label ID="LabelVR_ExecutionNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VR_ExecutionNo") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="80px"  CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSeitlIssuedPOItem"
      runat = "server"
      DataObjectTypeName = "SIS.EITL.eitlIssuedPOItem"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "eitlIssuedPOItemSelectList"
      TypeName = "SIS.EITL.eitlIssuedPOItem"
      SelectCountMethod = "eitlIssuedPOItemSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVeitlIssuedPOItem" EventName="PageIndexChanged" />
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
  ID = "ODSeitlIssuedPO"
  DataObjectTypeName = "SIS.EITL.eitlIssuedPO"
  SelectMethod = "eitlIssuedPOGetByID"
  UpdateMethod="eitlIssuedPOUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlIssuedPO"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
