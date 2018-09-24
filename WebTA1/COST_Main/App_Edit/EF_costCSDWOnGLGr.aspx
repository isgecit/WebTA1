<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costCSDWOnGLGr.aspx.vb" Inherits="EF_costCSDWOnGLGr" title="Edit: Work Order and GL Group wise" %>
<asp:Content ID="CPHcostCSDWOnGLGr" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostCSDWOnGLGr" runat="server" Text="&nbsp;Edit: Work Order and GL Group wise"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostCSDWOnGLGr" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostCSDWOnGLGr"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "costCSDWOnGLGr"
    runat = "server" />
<asp:FormView ID="FVcostCSDWOnGLGr"
  runat = "server"
  DataKeyNames = "ProjectGroupID,FinYear,Quarter,Revision,WorkOrderTypeID,GLGroupID"
  DataSourceID = "ODScostCSDWOnGLGr"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectGroupID" runat="server" ForeColor="#CC6633" Text="Project Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
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
            Text='<%# Eval("COST_ProjectGroups4_ProjectGroupDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" ForeColor="#CC6633" Text="Fin.Year :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FinYear"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Fin.Year."
            Runat="Server" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("COST_FinYear2_Descpription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" runat="server" ForeColor="#CC6633" Text="Quarter :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_Quarter"
            Width="88px"
            Text='<%# Bind("Quarter") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Quarter."
            Runat="Server" />
          <asp:Label
            ID = "F_Quarter_Display"
            Text='<%# Eval("COST_Quarters5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_Revision" runat="server" ForeColor="#CC6633" Text="Revision :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_Revision"
            Text='<%# Bind("Revision") %>'
            ToolTip="Value of Revision."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_WorkOrderTypeID" runat="server" ForeColor="#CC6633" Text="Work Order Type :" />&nbsp;</b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_WorkOrderTypeID"
            Width="88px"
            Text='<%# Bind("WorkOrderTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Work Order Type."
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_WorkOrderTypeID_Display"
            Text='<%# Eval("COST_WorkOrderTypes6_WorkOrderTypeDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_GLGroupID" runat="server" ForeColor="#CC6633" Text="GL Group :" />&nbsp;</b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_GLGroupID"
            Width="88px"
            Text='<%# Bind("GLGroupID") %>'
            Enabled = "False"
            ToolTip="Value of GL Group."
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_GLGroupID_Display"
            Text='<%# Eval("COST_GLGroups3_GLGroupDescriptions") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CrAmount" runat="server" Text="CrAmount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CrAmount"
            Text='<%# Bind("CrAmount") %>'
            ToolTip="Value of CrAmount."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DrAmount" runat="server" Text="DrAmount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DrAmount"
            Text='<%# Bind("DrAmount") %>'
            ToolTip="Value of DrAmount."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Amount" runat="server" Text="Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Amount"
            Text='<%# Bind("Amount") %>'
            ToolTip="Value of Amount."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScostCSDWOnGLGr"
  DataObjectTypeName = "SIS.COST.costCSDWOnGLGr"
  SelectMethod = "costCSDWOnGLGrGetByID"
  UpdateMethod="costCSDWOnGLGrUpdate"
  DeleteMethod="costCSDWOnGLGrDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costCSDWOnGLGr"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectGroupID" Name="ProjectGroupID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FinYear" Name="FinYear" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Quarter" Name="Quarter" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Revision" Name="Revision" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="WorkOrderTypeID" Name="WorkOrderTypeID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="GLGroupID" Name="GLGroupID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
