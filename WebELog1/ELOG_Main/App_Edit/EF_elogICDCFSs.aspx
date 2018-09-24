<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogICDCFSs.aspx.vb" Inherits="EF_elogICDCFSs" title="Edit: ICD-CFS" %>
<asp:Content ID="CPHelogICDCFSs" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogICDCFSs" runat="server" Text="&nbsp;Edit: ICD-CFS"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogICDCFSs" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogICDCFSs"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "elogICDCFSs"
    runat = "server" />
<asp:FormView ID="FVelogICDCFSs"
  runat = "server"
  DataKeyNames = "ICDCFSID"
  DataSourceID = "ODSelogICDCFSs"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ICDCFSID" runat="server" ForeColor="#CC6633" Text="ICD-CFS ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ICDCFSID"
            Text='<%# Bind("ICDCFSID") %>'
            ToolTip="Value of ICD-CFS ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StuffingPointID" runat="server" Text="Stuffing Point ID :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_elogStuffingPoints
            ID="F_StuffingPointID"
            SelectedValue='<%# Bind("StuffingPointID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "elogICDCFSs"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogICDCFSs"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogICDCFSs"
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
  ID = "ODSelogICDCFSs"
  DataObjectTypeName = "SIS.ELOG.elogICDCFSs"
  SelectMethod = "elogICDCFSsGetByID"
  UpdateMethod="elogICDCFSsUpdate"
  DeleteMethod="elogICDCFSsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogICDCFSs"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ICDCFSID" Name="ICDCFSID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
