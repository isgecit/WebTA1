<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakTCPOLRD.aspx.vb" Inherits="EF_pakTCPOLRD" title="Edit: Documents" %>
<asp:Content ID="CPHpakTCPOLRD" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakTCPOLRD" runat="server" Text="&nbsp;Edit: Documents"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakTCPOLRD" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakTCPOLRD"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "pakTCPOLRD"
    runat = "server" />
<asp:FormView ID="FVpakTCPOLRD"
  runat = "server"
  DataKeyNames = "SerialNo,ItemNo,UploadNo,DocSerialNo"
  DataSourceID = "ODSpakTCPOLRD"
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
            Text='<%# Eval("PAK_PO1_PODescription") %>'
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
            Text='<%# Eval("PAK_POLine2_ItemCode") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_UploadNo" runat="server" ForeColor="#CC6633" Text="Upload No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_UploadNo"
            Width="88px"
            Text='<%# Bind("UploadNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Upload No."
            Runat="Server" />
          <asp:Label
            ID = "F_UploadNo_Display"
            Text='<%# Eval("PAK_POLineRec3_UploadNo") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_DocSerialNo" runat="server" ForeColor="#CC6633" Text="Document :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_DocSerialNo"
            Text='<%# Bind("DocSerialNo") %>'
            ToolTip="Value of Document."
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
          <asp:Label ID="L_DocumentID" runat="server" Text="ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DocumentID"
            Text='<%# Bind("DocumentID") %>'
            ToolTip="Value of ID."
            Enabled = "False"
            Width="264px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DocumentRev" runat="server" Text="Rev. :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DocumentRev"
            Text='<%# Bind("DocumentRev") %>'
            ToolTip="Value of Rev.."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DocumentDescription" runat="server" Text="Description :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DocumentDescription"
            Text='<%# Bind("DocumentDescription") %>'
            ToolTip="Value of Description."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ReceiptNo" runat="server" Text="ERP Receipt :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ReceiptNo"
            Text='<%# Bind("ReceiptNo") %>'
            ToolTip="Value of ERP Receipt."
            Enabled = "False"
            Width="80px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RevisionNo" runat="server" Text="ERP Rev :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_RevisionNo"
            Text='<%# Bind("RevisionNo") %>'
            ToolTip="Value of ERP Rev."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_FileName" runat="server" Text="File Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_FileName"
            Text='<%# Bind("FileName") %>'
            ToolTip="Value of File Name."
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
  ID = "ODSpakTCPOLRD"
  DataObjectTypeName = "SIS.PAK.pakTCPOLRD"
  SelectMethod = "pakTCPOLRDGetByID"
  UpdateMethod="pakTCPOLRDUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakTCPOLRD"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemNo" Name="ItemNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="UploadNo" Name="UploadNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="DocSerialNo" Name="DocSerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
