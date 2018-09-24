<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogIRBLDetails.aspx.vb" Inherits="EF_elogIRBLDetails" title="Edit: IR BL Charge Codes" %>
<asp:Content ID="CPHelogIRBLDetails" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogIRBLDetails" runat="server" Text="&nbsp;Edit: IR BL Charge Codes"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogIRBLDetails" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogIRBLDetails"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "elogIRBLDetails"
    runat = "server" />
<asp:FormView ID="FVelogIRBLDetails"
  runat = "server"
  DataKeyNames = "IRNo,SerialNo"
  DataSourceID = "ODSelogIRBLDetails"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IRNo" runat="server" ForeColor="#CC6633" Text="IR No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_IRNo"
            Width="88px"
            Text='<%# Bind("IRNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of IR No."
            Runat="Server" />
          <asp:Label
            ID = "F_IRNo_Display"
            Text='<%# Eval("ELOG_IRBL6_SupplierBillNo") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo"
            Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
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
          <asp:Label ID="L_StuffingTypeID" runat="server" Text="Stuffing Type :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_StuffingTypeID"
            Width="88px"
            Text='<%# Bind("StuffingTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Stuffing Type."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_StuffingTypeID_Display"
            Text='<%# Eval("ELOG_StuffingTypes8_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StuffingPointID" runat="server" Text="Stuffing Point :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_StuffingPointID"
            Width="88px"
            Text='<%# Bind("StuffingPointID") %>'
            Enabled = "False"
            ToolTip="Value of Stuffing Point."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_StuffingPointID_Display"
            Text='<%# Eval("ELOG_StuffingPoints7_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ICDCFSID" runat="server" Text="ICD / CFS :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ICDCFSID"
            Width="88px"
            Text='<%# Bind("ICDCFSID") %>'
            Enabled = "False"
            ToolTip="Value of ICD / CFS."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ICDCFSID_Display"
            Text='<%# Eval("ELOG_ICDCFSs5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_OtherICDCFS" runat="server" Text="Other ICD / CFS Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_OtherICDCFS"
            Text='<%# Bind("OtherICDCFS") %>'
            ToolTip="Value of Other ICD / CFS Name."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BreakBulkID" runat="server" Text="Break Bulk :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_BreakBulkID"
            Width="88px"
            Text='<%# Bind("BreakBulkID") %>'
            Enabled = "False"
            ToolTip="Value of Break Bulk."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_BreakBulkID_Display"
            Text='<%# Eval("ELOG_BreakbulkTypes1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ChargeTypeID" runat="server" Text="Charge Type :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ChargeTypeID"
            Width="88px"
            Text='<%# Bind("ChargeTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Charge Type."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ChargeTypeID_Display"
            Text='<%# Eval("ELOG_ChargeTypes4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ChargeCategoryID" runat="server" Text="Charge Category :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ChargeCategoryID"
            Width="88px"
            Text='<%# Bind("ChargeCategoryID") %>'
            Enabled = "False"
            ToolTip="Value of Charge Category."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ChargeCategoryID_Display"
            Text='<%# Eval("ELOG_ChargeCategories2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ChargeCodeID" runat="server" Text="Charge Code :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ChargeCodeID"
            Width="88px"
            Text='<%# Bind("ChargeCodeID") %>'
            Enabled = "False"
            ToolTip="Value of Charge Code."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ChargeCodeID_Display"
            Text='<%# Eval("ELOG_ChargeCodes3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
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
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            ToolTip="Value of Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
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
  ID = "ODSelogIRBLDetails"
  DataObjectTypeName = "SIS.ELOG.elogIRBLDetails"
  SelectMethod = "elogIRBLDetailsGetByID"
  UpdateMethod="UZ_elogIRBLDetailsUpdate"
  DeleteMethod="UZ_elogIRBLDetailsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogIRBLDetails"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="IRNo" Name="IRNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
