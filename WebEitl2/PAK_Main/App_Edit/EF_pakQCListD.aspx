<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakQCListD.aspx.vb" Inherits="EF_pakQCListD" title="Edit: Quality Clearance Items" %>
<asp:Content ID="CPHpakQCListD" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakQCListD" runat="server" Text="&nbsp;Edit: Quality Clearance Items"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakQCListD" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakQCListD"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "pakQCListD"
    runat = "server" />
<asp:FormView ID="FVpakQCListD"
  runat = "server"
  DataKeyNames = "SerialNo,QCLNo,BOMNo,ItemNo"
  DataSourceID = "ODSpakQCListD"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_SerialNo"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Serial No."
            Runat="Server" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("PAK_PO2_PODescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_QCLNo" runat="server" ForeColor="#CC6633" Text="QCL No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_QCLNo"
            Width="88px"
            Text='<%# Bind("QCLNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of QCL No."
            Runat="Server" />
          <asp:Label
            ID = "F_QCLNo_Display"
            Text='<%# Eval("PAK_QCListH5_SupplierRef") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BOMNo" runat="server" ForeColor="#CC6633" Text="BOM No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_BOMNo"
            Width="88px"
            Text='<%# Bind("BOMNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of BOM No."
            Runat="Server" />
          <asp:Label
            ID = "F_BOMNo_Display"
            Text='<%# Eval("PAK_POBOM4_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemNo" runat="server" ForeColor="#CC6633" Text="Item No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ItemNo"
            Width="88px"
            Text='<%# Bind("ItemNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Item No."
            Runat="Server" />
          <asp:Label
            ID = "F_ItemNo_Display"
            Text='<%# Eval("PAK_POBItems3_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UOMQuantity" runat="server" Text="UOM Quantity :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_UOMQuantity"
            Width="88px"
            Text='<%# Bind("UOMQuantity") %>'
            Enabled = "False"
            ToolTip="Value of UOM Quantity."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_UOMQuantity_Display"
            Text='<%# Eval("PAK_Units6_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Quantity" runat="server" Text="Offered Quantity :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Quantity"
            Text='<%# Bind("Quantity") %>'
            style="text-align: right"
            Width="184px"
            CssClass = "mytxt"
            ValidationGroup= "pakQCListD"
            MaxLength="22"
            onfocus = "return this.select();"
            onblur="return dc(this,4);"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_InspectionStageID" runat="server" Text="Inspection Stage :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_qcmInspectionStages
            ID="F_InspectionStageID"
            SelectedValue='<%# Bind("InspectionStageID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "pakQCListD"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UOMWeight" runat="server" Text="UOM Weight :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_UOMWeight"
            Width="88px"
            Text='<%# Bind("UOMWeight") %>'
            Enabled = "False"
            ToolTip="Value of UOM Weight."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_UOMWeight_Display"
            Text='<%# Eval("PAK_Units7_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_WeightPerUnit" runat="server" Text="Weight Per Unit :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_WeightPerUnit"
            Text='<%# Bind("WeightPerUnit") %>'
            ToolTip="Value of Weight Per Unit."
            Enabled = "False"
            Width="184px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_QualityClearedQty" runat="server" Text="Quality Cleared Qty :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_QualityClearedQty"
            Text='<%# Eval("QualityClearedQty") %>'
            ToolTip="Value of Quality Cleared Qty."
            Enabled = "False"
            Width="184px"
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
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ClearedBy" runat="server" Text="Cleared By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ClearedBy"
            Width="72px"
            Text='<%# Bind("ClearedBy") %>'
            Enabled = "False"
            ToolTip="Value of Cleared By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ClearedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ClearedOn" runat="server" Text="Cleared On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ClearedOn"
            Text='<%# Bind("ClearedOn") %>'
            ToolTip="Value of Cleared On."
            Enabled = "False"
            Width="168px"
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
  ID = "ODSpakQCListD"
  DataObjectTypeName = "SIS.PAK.pakQCListD"
  SelectMethod = "pakQCListDGetByID"
  UpdateMethod="pakQCListDUpdate"
  DeleteMethod="pakQCListDDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakQCListD"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="QCLNo" Name="QCLNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="BOMNo" Name="BOMNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemNo" Name="ItemNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
