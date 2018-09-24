<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costProjectGroupProjects.aspx.vb" Inherits="EF_costProjectGroupProjects" title="Edit: Project Group Projects" %>
<asp:Content ID="CPHcostProjectGroupProjects" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostProjectGroupProjects" runat="server" Text="&nbsp;Edit: Project Group Projects"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostProjectGroupProjects" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostProjectGroupProjects"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "costProjectGroupProjects"
    runat = "server" />
<asp:FormView ID="FVcostProjectGroupProjects"
  runat = "server"
  DataKeyNames = "ProjectGroupID,ProjectID"
  DataSourceID = "ODScostProjectGroupProjects"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectGroupID" runat="server" ForeColor="#CC6633" Text="Project Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectGroupID"
            Width="88px"
            Text='<%# Bind("ProjectGroupID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project Group ID."
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectGroupID_Display"
            Text='<%# Eval("COST_ProjectGroups1_ProjectGroupDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project ID."
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
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
  ID = "ODScostProjectGroupProjects"
  DataObjectTypeName = "SIS.COST.costProjectGroupProjects"
  SelectMethod = "costProjectGroupProjectsGetByID"
  UpdateMethod="costProjectGroupProjectsUpdate"
  DeleteMethod="costProjectGroupProjectsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costProjectGroupProjects"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectGroupID" Name="ProjectGroupID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
