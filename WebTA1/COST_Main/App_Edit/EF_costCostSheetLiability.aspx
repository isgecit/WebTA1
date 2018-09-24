<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costCostSheetLiability.aspx.vb" Inherits="EF_costCostSheetLiability" title="Edit: Cost Sheet Liability" %>
<asp:Content ID="CPHcostCostSheetLiability" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostCostSheetLiability" runat="server" Text="&nbsp;Edit: Cost Sheet Liability"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostCostSheetLiability" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostCostSheetLiability"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "costCostSheetLiability"
    runat = "server" />
<asp:FormView ID="FVcostCostSheetLiability"
  runat = "server"
  DataKeyNames = "ProjectGroupID,FinYear,Quarter,Revision,ProjectID,GLCode,AdjustmentSerialNo,AdjustmentCredit"
  DataSourceID = "ODScostCostSheetLiability"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectGroupID" runat="server" ForeColor="#CC6633" Text="Project Group ID :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectGroupID"
            Width="88px"
            Text='<%# Bind("ProjectGroupID") %>'
            Enabled = "False"
            ToolTip="Value of Project Group ID."
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectGroupID_Display"
            Text='<%# Eval("COST_ProjectGroups4_ProjectGroupDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" ForeColor="#CC6633" Text="Fin. Year :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_FinYear"
            Width="88px"
            Text='<%# Bind("FinYear") %>'
            Enabled = "False"
            ToolTip="Value of Fin. Year."
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text='<%# Eval("COST_FinYear3_Descpription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" runat="server" ForeColor="#CC6633" Text="Quarter :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_Quarter"
            Width="88px"
            Text='<%# Bind("Quarter") %>'
            Enabled = "False"
            ToolTip="Value of Quarter."
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_Quarter_Display"
            Text='<%# Eval("COST_Quarters5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Revision" runat="server" ForeColor="#CC6633" Text="Revision :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Revision"
            Text='<%# Bind("Revision") %>'
            ToolTip="Value of Revision."
            Enabled = "False"
            Width="88px"
            CssClass = "dmypktxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project ID :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            Enabled = "False"
            ToolTip="Value of Project ID."
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects6_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GLCode" runat="server" ForeColor="#CC6633" Text="GL Code :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_GLCode"
            Width="64px"
            Text='<%# Bind("GLCode") %>'
            Enabled = "False"
            ToolTip="Value of GL Code."
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_GLCode_Display"
            Text='<%# Eval("COST_ERPGLCodes2_GLDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CrAmount" runat="server" Text="Cr. Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CrAmount"
            Text='<%# Bind("CrAmount") %>'
            ToolTip="Value of Cr. Amount."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DrAmount" runat="server" Text="Dr. Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DrAmount"
            Text='<%# Bind("DrAmount") %>'
            ToolTip="Value of Dr. Amount."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Amount" runat="server" Text="Amount :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Amount"
            Text='<%# Bind("Amount") %>'
            ToolTip="Value of Amount."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_AdjustmentSerialNo" runat="server" ForeColor="#CC6633" Text="Adjustment Serial No :" />&nbsp;</b>
        </td>
        <td>
          <asp:TextBox ID="F_AdjustmentSerialNo"
            Text='<%# Bind("AdjustmentSerialNo") %>'
            ToolTip="Value of Adjustment Serial No."
            Enabled = "False"
            Width="88px"
            CssClass = "dmypktxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_AdjustmentCredit" runat="server" ForeColor="#CC6633" Text="Adjustment Credit :" />&nbsp;</b>
        </td>
        <td>
          <asp:CheckBox ID="F_AdjustmentCredit"
            Checked='<%# Bind("AdjustmentCredit") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AdjustmentEntry" runat="server" Text="Adjustment Entry :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_AdjustmentEntry"
            Checked='<%# Bind("AdjustmentEntry") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CrFC" runat="server" Text="CrFC :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CrFC"
            Text='<%# Bind("CrFC") %>'
            ToolTip="Value of CrFC."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DrFC" runat="server" Text="DrFC :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DrFC"
            Text='<%# Bind("DrFC") %>'
            ToolTip="Value of DrFC."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_NetFC" runat="server" Text="NetFC :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_NetFC"
            Text='<%# Bind("NetFC") %>'
            ToolTip="Value of NetFC."
            Enabled = "False"
            Width="136px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_FC" runat="server" Text="FC :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FC"
            Text='<%# Bind("FC") %>'
            ToolTip="Value of FC."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            runat="server" />
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
  ID = "ODScostCostSheetLiability"
  DataObjectTypeName = "SIS.COST.costCostSheetLiability"
  SelectMethod = "costCostSheetLiabilityGetByID"
  UpdateMethod="UZ_costCostSheetLiabilityUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costCostSheetLiability"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectGroupID" Name="ProjectGroupID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FinYear" Name="FinYear" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Quarter" Name="Quarter" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="Revision" Name="Revision" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="GLCode" Name="GLCode" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="AdjustmentSerialNo" Name="AdjustmentSerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="AdjustmentCredit" Name="AdjustmentCredit" Type="Boolean" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
