<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakDPending.aspx.vb" Inherits="EF_pakDPending" title="Edit: Packing List Items" %>
<asp:Content ID="CPHpakDPending" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakDPending" runat="server" Text="&nbsp;Edit: Packing List Items"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakDPending" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakDPending"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "pakDPending"
    runat = "server" />
<asp:FormView ID="FVpakDPending"
  runat = "server"
  DataKeyNames = "SerialNo,PkgNo,BOMNo,ItemNo"
  DataSourceID = "ODSpakDPending"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td>
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
            Text='<%# Eval("PAK_PO3_PODescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_PkgNo" runat="server" ForeColor="#CC6633" Text="Pkg No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_PkgNo"
            Width="88px"
            Text='<%# Bind("PkgNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Pkg No."
            Runat="Server" />
          <asp:Label
            ID = "F_PkgNo_Display"
            Text='<%# Eval("PAK_PkgListH2_SupplierRefNo") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BOMNo" runat="server" ForeColor="#CC6633" Text="BOM No :" /><span style="color:red">*</span></b>
        </td>
        <td>
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
            Text='<%# Eval("PAK_POBOM5_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_ItemNo" runat="server" ForeColor="#CC6633" Text="Item No :" /><span style="color:red">*</span></b>
        </td>
        <td>
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
            Text='<%# Eval("PAK_POBItems4_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UOMQuantity" runat="server" Text="UOM Quantity :" />&nbsp;
        </td>
        <td>
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
        <td class="alignright">
          <asp:Label ID="L_Quantity" runat="server" Text="Quantity :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Quantity"
            Text='<%# Bind("Quantity") %>'
            ToolTip="Value of Quantity."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
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
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PackTypeID" runat="server" Text="Pack Type :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_PackTypeID"
            Width="88px"
            Text='<%# Bind("PackTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Pack Type."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_PackTypeID_Display"
            Text='<%# Eval("PAK_PakTypes1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PackingMark" runat="server" Text="Packing Mark :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PackingMark"
            Text='<%# Bind("PackingMark") %>'
            ToolTip="Value of Packing Mark."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PackLength" runat="server" Text="Pack Length :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PackLength"
            Text='<%# Bind("PackLength") %>'
            ToolTip="Value of Pack Length."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PackWidth" runat="server" Text="Pack Width :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PackWidth"
            Text='<%# Bind("PackWidth") %>'
            ToolTip="Value of Pack Width."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PackHeight" runat="server" Text="Pack Height :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PackHeight"
            Text='<%# Bind("PackHeight") %>'
            ToolTip="Value of Pack Height."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_UOMPack" runat="server" Text="UOM Pack :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_UOMPack"
            Width="88px"
            Text='<%# Bind("UOMPack") %>'
            Enabled = "False"
            ToolTip="Value of UOM Pack."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_UOMPack_Display"
            Text='<%# Eval("PAK_Units8_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
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
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakDPending"
  DataObjectTypeName = "SIS.PAK.pakDPending"
  SelectMethod = "pakDPendingGetByID"
  UpdateMethod="UZ_pakDPendingUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakDPending"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="PkgNo" Name="PkgNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="BOMNo" Name="BOMNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemNo" Name="ItemNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
