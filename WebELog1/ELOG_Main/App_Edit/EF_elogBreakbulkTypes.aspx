<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogBreakbulkTypes.aspx.vb" Inherits="EF_elogBreakbulkTypes" title="Edit: Breakbulk Types" %>
<asp:Content ID="CPHelogBreakbulkTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogBreakbulkTypes" runat="server" Text="&nbsp;Edit: Breakbulk Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogBreakbulkTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogBreakbulkTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "elogBreakbulkTypes"
    runat = "server" />
<asp:FormView ID="FVelogBreakbulkTypes"
  runat = "server"
  DataKeyNames = "BreakbulkTypeID"
  DataSourceID = "ODSelogBreakbulkTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BreakbulkTypeID" runat="server" ForeColor="#CC6633" Text="Breakbulk Type :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_BreakbulkTypeID"
            Text='<%# Bind("BreakbulkTypeID") %>'
            ToolTip="Value of Breakbulk Type."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogBreakbulkTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogBreakbulkTypes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSelogBreakbulkTypes"
  DataObjectTypeName = "SIS.ELOG.elogBreakbulkTypes"
  SelectMethod = "elogBreakbulkTypesGetByID"
  UpdateMethod="elogBreakbulkTypesUpdate"
  DeleteMethod="elogBreakbulkTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogBreakbulkTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="BreakbulkTypeID" Name="BreakbulkTypeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
