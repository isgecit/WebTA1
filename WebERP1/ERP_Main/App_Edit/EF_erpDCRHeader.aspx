<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_erpDCRHeader.aspx.vb" Inherits="EF_erpDCRHeader" title="Edit: DCR Header" %>
<asp:Content ID="CPHerpDCRHeader" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLerpDCRHeader" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelerpDCRHeader" runat="server" Text="&nbsp;Edit: DCR Header" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLerpDCRHeader"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_erpDCRHeader.aspx?pk="
    ValidationGroup = "erpDCRHeader"
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
<asp:FormView ID="FVerpDCRHeader"
	runat = "server"
	DataKeyNames = "DCRNo"
	DataSourceID = "ODSerpDCRHeader"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRNo" runat="server" ForeColor="#CC6633" Text="DCRNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRNo"
						Text='<%# Bind("DCRNo") %>'
            ToolTip="Value of DCRNo."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRDate" runat="server" Text="DCRDate :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRDate"
						Text='<%# Bind("DCRDate") %>'
            Width="140px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRHeader"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DCRDate."
						MaxLength="20"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDCRDate"
						runat = "server"
						ControlToValidate = "F_DCRDate"
						Text = "DCRDate is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRHeader"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DCRDescription" runat="server" Text="DCRDescription :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DCRDescription"
						Text='<%# Bind("DCRDescription") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRHeader"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DCRDescription."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDCRDescription"
						runat = "server"
						ControlToValidate = "F_DCRDescription"
						Text = "DCRDescription is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRHeader"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CreatedBy" runat="server" Text="CreatedBy :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CreatedBy"
						Text='<%# Bind("CreatedBy") %>'
            Width="56px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRHeader"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for CreatedBy."
						MaxLength="8"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVCreatedBy"
						runat = "server"
						ControlToValidate = "F_CreatedBy"
						Text = "CreatedBy is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRHeader"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CreatedName" runat="server" Text="CreatedName :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CreatedName"
						Text='<%# Bind("CreatedName") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRHeader"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for CreatedName."
						MaxLength="50"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVCreatedName"
						runat = "server"
						ControlToValidate = "F_CreatedName"
						Text = "CreatedName is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRHeader"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CreatedEMail" runat="server" Text="CreatedEMail :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CreatedEMail"
						Text='<%# Bind("CreatedEMail") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRHeader"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for CreatedEMail."
						MaxLength="50"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVCreatedEMail"
						runat = "server"
						ControlToValidate = "F_CreatedEMail"
						Text = "CreatedEMail is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRHeader"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" runat="server" Text="ProjectID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ProjectID"
						Text='<%# Bind("ProjectID") %>'
            Width="42px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRHeader"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ProjectID."
						MaxLength="6"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectID"
						runat = "server"
						ControlToValidate = "F_ProjectID"
						Text = "ProjectID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRHeader"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectDescription" runat="server" Text="ProjectDescription :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ProjectDescription"
						Text='<%# Bind("ProjectDescription") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="erpDCRHeader"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ProjectDescription."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectDescription"
						runat = "server"
						ControlToValidate = "F_ProjectDescription"
						Text = "ProjectDescription is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "erpDCRHeader"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
<asp:UpdatePanel ID="UPNLerpDCRDetail" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelerpDCRDetail" runat="server" Text="&nbsp;List: DCR Detail" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLerpDCRDetail"
      ToolType = "lgNMGrid"
      EditUrl = "~/ERP_Main/App_Edit/EF_erpDCRDetail.aspx"
      AddUrl = "~/ERP_Main/App_Create/AF_erpDCRDetail.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "erpDCRDetail"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSerpDCRDetail" runat="server" AssociatedUpdatePanelID="UPNLerpDCRDetail" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVerpDCRDetail" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSerpDCRDetail" DataKeyNames="DCRNo,DocumentID,RevisionNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
              <td><asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DCRNo" SortExpression="ERP_DCRHeader1_DCRDescription">
          <ItemTemplate>
             <asp:Label ID="L_DCRNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("DCRNo") %>' Text='<%# Eval("ERP_DCRHeader1_DCRDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DocumentID" SortExpression="DocumentID">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="RevisionNo" SortExpression="RevisionNo">
          <ItemTemplate>
            <asp:Label ID="LabelRevisionNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RevisionNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IndentNo" SortExpression="IndentNo">
          <ItemTemplate>
            <asp:Label ID="LabelIndentNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IndentNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IndentLine" SortExpression="IndentLine">
          <ItemTemplate>
            <asp:Label ID="LabelIndentLine" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IndentLine") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="LotItem" SortExpression="LotItem">
          <ItemTemplate>
            <asp:Label ID="LabelLotItem" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("LotItem") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ItemDescription" SortExpression="ItemDescription">
          <ItemTemplate>
            <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IndenterID" SortExpression="IndenterID">
          <ItemTemplate>
            <asp:Label ID="LabelIndenterID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IndenterID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BuyerID" SortExpression="BuyerID">
          <ItemTemplate>
            <asp:Label ID="LabelBuyerID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BuyerID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OrderNo" SortExpression="OrderNo">
          <ItemTemplate>
            <asp:Label ID="LabelOrderNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OrderNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="OrderLine" SortExpression="OrderLine">
          <ItemTemplate>
            <asp:Label ID="LabelOrderLine" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OrderLine") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SupplierID" SortExpression="SupplierID">
          <ItemTemplate>
            <asp:Label ID="LabelSupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BuyerIDinPO" SortExpression="BuyerIDinPO">
          <ItemTemplate>
            <asp:Label ID="LabelBuyerIDinPO" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BuyerIDinPO") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IndenterName" SortExpression="IndenterName">
          <ItemTemplate>
            <asp:Label ID="LabelIndenterName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IndenterName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IndenterEMail" SortExpression="IndenterEMail">
          <ItemTemplate>
            <asp:Label ID="LabelIndenterEMail" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IndenterEMail") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BuyerName" SortExpression="BuyerName">
          <ItemTemplate>
            <asp:Label ID="LabelBuyerName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BuyerName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BuyerEMail" SortExpression="BuyerEMail">
          <ItemTemplate>
            <asp:Label ID="LabelBuyerEMail" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BuyerEMail") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BuyerIDinPOName" SortExpression="BuyerIDinPOName">
          <ItemTemplate>
            <asp:Label ID="LabelBuyerIDinPOName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BuyerIDinPOName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BuyerIDinPOEMail" SortExpression="BuyerIDinPOEMail">
          <ItemTemplate>
            <asp:Label ID="LabelBuyerIDinPOEMail" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BuyerIDinPOEMail") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SupplierName" SortExpression="SupplierName">
          <ItemTemplate>
            <asp:Label ID="LabelSupplierName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="DocumentTitle" SortExpression="DocumentTitle">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentTitle" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentTitle") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSerpDCRDetail"
      runat = "server"
      DataObjectTypeName = "SIS.ERP.erpDCRDetail"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "erpDCRDetailSelectList"
      TypeName = "SIS.ERP.erpDCRDetail"
      SelectCountMethod = "erpDCRDetailSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_DCRNo" PropertyName="Text" Name="DCRNo" Type="String" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVerpDCRDetail" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSerpDCRHeader"
  DataObjectTypeName = "SIS.ERP.erpDCRHeader"
  SelectMethod = "erpDCRHeaderGetByID"
  UpdateMethod="erpDCRHeaderUpdate"
  DeleteMethod="erpDCRHeaderDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ERP.erpDCRHeader"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DCRNo" Name="DCRNo" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
