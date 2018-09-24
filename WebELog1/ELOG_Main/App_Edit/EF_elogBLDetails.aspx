<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogBLDetails.aspx.vb" Inherits="EF_elogBLDetails" title="Edit: BL Details" %>
<asp:Content ID="CPHelogBLDetails" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogBLDetails" runat="server" Text="&nbsp;Edit: BL Details"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogBLDetails" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogBLDetails"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "elogBLDetails"
    runat = "server" />
<asp:FormView ID="FVelogBLDetails"
  runat = "server"
  DataKeyNames = "BLID,SerialNo"
  DataSourceID = "ODSelogBLDetails"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BLID" runat="server" ForeColor="#CC6633" Text="BL ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_BLID"
            Width="80px"
            Text='<%# Bind("BLID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of BL ID."
            Runat="Server" />
          <asp:Label
            ID = "F_BLID_Display"
            Text='<%# Eval("ELOG_BLHeader1_BLNumber") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td>
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SizeAndTypeOfContainer" runat="server" Text="Size And Type Of Container :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SizeAndTypeOfContainer"
            Text='<%# Bind("SizeAndTypeOfContainer") %>'
            ToolTip="Value of Size And Type Of Container."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ContainerNumber" runat="server" Text="Container Number :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ContainerNumber"
            Text='<%# Bind("ContainerNumber") %>'
            ToolTip="Value of Container Number."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            ToolTip="Value of Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
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
  ID = "ODSelogBLDetails"
  DataObjectTypeName = "SIS.ELOG.elogBLDetails"
  SelectMethod = "elogBLDetailsGetByID"
  UpdateMethod="elogBLDetailsUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogBLDetails"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="BLID" Name="BLID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
