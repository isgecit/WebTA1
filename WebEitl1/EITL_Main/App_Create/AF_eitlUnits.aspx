<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_eitlUnits.aspx.vb" Inherits="AF_eitlUnits" title="Add: Units" %>
<asp:Content ID="CPHeitlUnits" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeleitlUnits" runat="server" Text="&nbsp;Add: Units"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLeitlUnits" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLeitlUnits"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "eitlUnits"
    runat = "server" />
<asp:FormView ID="FVeitlUnits"
	runat = "server"
	DataKeyNames = "UnitID"
	DataSourceID = "ODSeitlUnits"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <br />
    <asp:Label ID="L_ErrMsgeitlUnits" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_UnitID" ForeColor="#CC6633" runat="server" Text="Unit ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_UnitID"
						Text='<%# Bind("UnitID") %>'
						CssClass = "mypktxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlUnits"
            onblur= "script_eitlUnits.validate_UnitID(this);"
            ToolTip="Enter value for Unit ID."
						MaxLength="3"
            Width="21px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVUnitID"
						runat = "server"
						ControlToValidate = "F_UnitID"
						Text = "Unit ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlUnits"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="eitlUnits"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="30"
            Width="210px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "eitlUnits"
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
  ID = "ODSeitlUnits"
  DataObjectTypeName = "SIS.EITL.eitlUnits"
  InsertMethod="eitlUnitsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EITL.eitlUnits"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
