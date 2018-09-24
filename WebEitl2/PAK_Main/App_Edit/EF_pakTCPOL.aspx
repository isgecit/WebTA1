<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakTCPOL.aspx.vb" Inherits="EF_pakTCPOL" title="Edit: PO Items" %>
<asp:Content ID="CPHpakTCPOL" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakTCPOL" runat="server" Text="&nbsp;Edit: PO Items"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakTCPOL" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakTCPOL"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "pakTCPOL"
    runat = "server" />
<asp:FormView ID="FVpakTCPOL"
  runat = "server"
  DataKeyNames = "SerialNo,ItemNo"
  DataSourceID = "ODSpakTCPOL"
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
          <b><asp:Label ID="L_ItemNo" runat="server" ForeColor="#CC6633" Text="Item No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ItemNo"
            Text='<%# Bind("ItemNo") %>'
            ToolTip="Value of Item No."
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
          <asp:Label ID="L_ItemCode" runat="server" Text="Item Code :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ItemCode"
            Text='<%# Bind("ItemCode") %>'
            ToolTip="Value of Item Code."
            Enabled = "False"
            Width="384px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ItemDescription" runat="server" Text="Description :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ItemDescription"
            Text='<%# Bind("ItemDescription") %>'
            ToolTip="Value of Description."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ItemQuantity" runat="server" Text="Quantity :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ItemQuantity"
            Text='<%# Bind("ItemQuantity") %>'
            ToolTip="Value of Quantity."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ItemUnit" runat="server" Text="Unit :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ItemUnit"
            Text='<%# Bind("ItemUnit") %>'
            ToolTip="Value of Unit."
            Enabled = "False"
            Width="32px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ItemPrice" runat="server" Text="Price :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ItemPrice"
            Text='<%# Bind("ItemPrice") %>'
            ToolTip="Value of Price."
            Enabled = "False"
            Width="176px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ItemAmount" runat="server" Text="Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ItemAmount"
            Text='<%# Bind("ItemAmount") %>'
            ToolTip="Value of Amount."
            Enabled = "False"
            Width="176px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ItemElement" runat="server" Text="Element :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ItemElement"
            Width="72px"
            Text='<%# Bind("ItemElement") %>'
            Enabled = "False"
            ToolTip="Value of Element."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ItemElement_Display"
            Text='<%# Eval("IDM_WBS1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ItemStatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ItemStatusID"
            Width="88px"
            Text='<%# Bind("ItemStatusID") %>'
            Enabled = "False"
            ToolTip="Value of Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ItemStatusID_Display"
            Text='<%# Eval("PAK_POLineStatus3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpakTCPOLR" runat="server" Text="&nbsp;List: Submitted for TC"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakTCPOLR" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakTCPOLR"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakTCPOLR.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "pakTCPOLR"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakTCPOLR" runat="server" AssociatedUpdatePanelID="UPNLpakTCPOLR" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpakTCPOLR" SkinID="gv_silver" runat="server" DataSourceID="ODSpakTCPOLR" DataKeyNames="SerialNo,ItemNo,UploadNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Upload No" SortExpression="UploadNo">
          <ItemTemplate>
            <asp:Label ID="LabelUploadNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UploadNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document Category" SortExpression="PAK_POLineRecCategory4_Description">
          <ItemTemplate>
             <asp:Label ID="L_DocumentCategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("DocumentCategoryID") %>' Text='<%# Eval("PAK_POLineRecCategory4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Submitted On" SortExpression="CreatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ERP Receipt No" SortExpression="ReceiptNo">
          <ItemTemplate>
            <asp:Label ID="LabelReceiptNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ReceiptNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ERP Rev. No" SortExpression="RevisionNo">
          <ItemTemplate>
            <asp:Label ID="LabelRevisionNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RevisionNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="PAK_POLineRecStatus5_Description">
          <ItemTemplate>
             <asp:Label ID="L_UploadStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UploadStatusID") %>' Text='<%# Eval("PAK_POLineRecStatus5_Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakTCPOLR"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakTCPOLR"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakTCPOLRSelectList"
      TypeName = "SIS.PAK.pakTCPOLR"
      SelectCountMethod = "pakTCPOLRSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ItemNo" PropertyName="Text" Name="ItemNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakTCPOLR" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakTCPOL"
  DataObjectTypeName = "SIS.PAK.pakTCPOL"
  SelectMethod = "pakTCPOLGetByID"
  UpdateMethod="UZ_pakTCPOLUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakTCPOL"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemNo" Name="ItemNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
