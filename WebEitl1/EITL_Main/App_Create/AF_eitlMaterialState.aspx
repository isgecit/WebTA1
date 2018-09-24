<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_eitlMaterialState.aspx.vb" Inherits="AF_eitlMaterialState" title="Add: Material State" %>
<asp:Content ID="CPHeitlMaterialState" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlMaterialState" runat="server" Text="&nbsp;Add: Material State"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlMaterialState" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlMaterialState"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "eitlMaterialState"
    runat = "server" />
<asp:FormView ID="FVeitlMaterialState"
	runat = "server"
	DataKeyNames = "StateID"
	DataSourceID = "ODSeitlMaterialState"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <br />
    <asp:Label ID="L_ErrMsgeitlMaterialState" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_StateID" ForeColor="#CC6633" runat="server" Text="State ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_StateID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlMaterialState"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlMaterialState"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
		<br />
		</div>
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSeitlMaterialState"
  DataObjectTypeName = "SIS.EITL.eitlMaterialState"
  InsertMethod="eitlMaterialStateInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlMaterialState"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
