<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_costProjectGroups.aspx.vb" Inherits="AF_costProjectGroups" title="Add: Project Groups" %>
<asp:Content ID="CPHcostProjectGroups" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostProjectGroups" runat="server" Text="&nbsp;Add: Project Groups"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectGroups" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostProjectGroups"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/COST_Main/App_Edit/EF_costProjectGroups.aspx"
    ValidationGroup = "costProjectGroups"
    runat = "server" />
<asp:FormView ID="FVcostProjectGroups"
  runat = "server"
  DataKeyNames = "ProjectGroupID"
  DataSourceID = "ODScostProjectGroups"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgcostProjectGroups" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectGroupID" ForeColor="#CC6633" runat="server" Text="Project Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectGroupID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectGroupDescription" runat="server" Text="Project Group Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProjectGroupDescription"
            Text='<%# Bind("ProjectGroupDescription") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costProjectGroups"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Project Group Description."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectGroupDescription"
            runat = "server"
            ControlToValidate = "F_ProjectGroupDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costProjectGroups"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectTypeID" runat="server" Text="Project Type :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_costProjectTypes
            ID="F_ProjectTypeID"
            SelectedValue='<%# Bind("ProjectTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "costProjectGroups"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostProjectGroups"
  DataObjectTypeName = "SIS.COST.costProjectGroups"
  InsertMethod="costProjectGroupsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costProjectGroups"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
