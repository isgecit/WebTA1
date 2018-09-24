<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_elogICDCFSs.aspx.vb" Inherits="AF_elogICDCFSs" title="Add: ICD-CFS" %>
<asp:Content ID="CPHelogICDCFSs" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogICDCFSs" runat="server" Text="&nbsp;Add: ICD-CFS"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogICDCFSs" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogICDCFSs"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "elogICDCFSs"
    runat = "server" />
<asp:FormView ID="FVelogICDCFSs"
  runat = "server"
  DataKeyNames = "ICDCFSID"
  DataSourceID = "ODSelogICDCFSs"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgelogICDCFSs" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ICDCFSID" ForeColor="#CC6633" runat="server" Text="ICD-CFS ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ICDCFSID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="elogICDCFSs"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSelogICDCFSs"
  DataObjectTypeName = "SIS.ELOG.elogICDCFSs"
  InsertMethod="elogICDCFSsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogICDCFSs"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
