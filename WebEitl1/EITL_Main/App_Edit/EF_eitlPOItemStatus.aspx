<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_eitlPOItemStatus.aspx.vb" Inherits="EF_eitlPOItemStatus" title="Edit: PO Item Status" %>
<asp:Content ID="CPHeitlPOItemStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlPOItemStatus" runat="server" Text="&nbsp;Edit: PO Item Status"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlPOItemStatus" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlPOItemStatus"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_eitlPOItemStatus.aspx?pk="
    ValidationGroup = "eitlPOItemStatus"
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
<asp:FormView ID="FVeitlPOItemStatus"
	runat = "server"
	DataKeyNames = "StatusID"
	DataSourceID = "ODSeitlPOItemStatus"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
		<table style="margin:auto">
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_StatusID" runat="server" ForeColor="#CC6633" Text="Status ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_StatusID"
						Text='<%# Bind("StatusID") %>'
            ToolTip="Value of Status ID."
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
            Width="210px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlPOItemStatus"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="30"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlPOItemStatus"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	</div>
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSeitlPOItemStatus"
  DataObjectTypeName = "SIS.EITL.eitlPOItemStatus"
  SelectMethod = "eitlPOItemStatusGetByID"
  UpdateMethod="eitlPOItemStatusUpdate"
  DeleteMethod="eitlPOItemStatusDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlPOItemStatus"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="StatusID" Name="StatusID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
