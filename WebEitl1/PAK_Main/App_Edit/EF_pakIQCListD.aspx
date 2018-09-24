<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakIQCListD.aspx.vb" Inherits="EF_pakIQCListD" title="Edit: Offered QC List Items" %>
<asp:Content ID="CPHpakIQCListD" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakIQCListD" runat="server" Text="&nbsp;Edit: Offered QC List Items"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakIQCListD" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakIQCListD"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "pakIQCListD"
    runat = "server" />
<asp:FormView ID="FVpakIQCListD"
  runat = "server"
  DataKeyNames = "SerialNo,QCLNo,BOMNo,ItemNo"
  DataSourceID = "ODSpakIQCListD"
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
          <asp:Label ID="L_Quantity" runat="server" Text="Quantity :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Quantity"
            Text='<%# Bind("Quantity") %>'
            ToolTip="Value of Quantity."
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
            Text='<%# Bind("QualityClearedQty") %>'
            style="text-align: right"
            Width="184px"
            CssClass = "mytxt"
            MaxLength="22"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEQualityClearedQty"
            runat = "server"
            mask = "999999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_QualityClearedQty" />
          <AJX:MaskedEditValidator 
            ID = "MEVQualityClearedQty"
            runat = "server"
            ControlToValidate = "F_QualityClearedQty"
            ControlExtender = "MEEQualityClearedQty"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
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
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
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
  ID = "ODSpakIQCListD"
  DataObjectTypeName = "SIS.PAK.pakIQCListD"
  SelectMethod = "pakIQCListDGetByID"
  UpdateMethod="UZ_pakIQCListDUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakIQCListD"
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
