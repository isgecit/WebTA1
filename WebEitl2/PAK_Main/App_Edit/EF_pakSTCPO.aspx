<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakSTCPO.aspx.vb" Inherits="EF_pakSTCPO" title="Edit: PO" %>
<asp:Content ID="CPHpakSTCPO" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSTCPO" runat="server" Text="&nbsp;Edit: PO"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSTCPO" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSTCPO"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_pakSTCPO.aspx?pk="
    ValidationGroup = "pakSTCPO"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVpakSTCPO"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODSpakSTCPO"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
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
          <asp:Label ID="L_PONumber" runat="server" Text="PO Number :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PONumber"
            Text='<%# Bind("PONumber") %>'
            ToolTip="Value of PO Number."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PORevision" runat="server" Text="PO Revision :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PORevision"
            Text='<%# Bind("PORevision") %>'
            ToolTip="Value of PO Revision."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PODate" runat="server" Text="PO Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PODate"
            Text='<%# Bind("PODate") %>'
            ToolTip="Value of PO Date."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_POStatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_POStatusID"
            Width="88px"
            Text='<%# Bind("POStatusID") %>'
            Enabled = "False"
            ToolTip="Value of Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_POStatusID_Display"
            Text='<%# Eval("PAK_POStatus6_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PODescription" runat="server" Text="PO Description :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PODescription"
            Text='<%# Bind("PODescription") %>'
            ToolTip="Value of PO Description."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierID" runat="server" Text="Supplier :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SupplierID"
            Width="80px"
            Text='<%# Bind("SupplierID") %>'
            Enabled = "False"
            ToolTip="Value of Supplier."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_SupplierID_Display"
            Text='<%# Eval("VR_BusinessPartner9_BPName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            Enabled = "False"
            ToolTip="Value of Project."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BuyerID" runat="server" Text="Buyer :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_BuyerID"
            Width="72px"
            Text='<%# Bind("BuyerID") %>'
            Enabled = "False"
            ToolTip="Value of Buyer."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_BuyerID_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IssuedBy" runat="server" Text="Issued By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_IssuedBy"
            Width="72px"
            Text='<%# Bind("IssuedBy") %>'
            Enabled = "False"
            ToolTip="Value of Issued By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_IssuedBy_Display"
            Text='<%# Eval("aspnet_users2_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_IssuedOn" runat="server" Text="Issued On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_IssuedOn"
            Text='<%# Bind("IssuedOn") %>'
            ToolTip="Value of Issued On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ClosedBy" runat="server" Text="Closed By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ClosedBy"
            Width="72px"
            Text='<%# Bind("ClosedBy") %>'
            Enabled = "False"
            ToolTip="Value of Closed By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ClosedBy_Display"
            Text='<%# Eval("aspnet_users3_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ClosedOn" runat="server" Text="Closed On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ClosedOn"
            Text='<%# Bind("ClosedOn") %>'
            ToolTip="Value of Closed On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpakSTCPOL" runat="server" Text="&nbsp;List: PO Items"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakSTCPOL" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakSTCPOL"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakSTCPOL.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "pakSTCPOL"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakSTCPOL" runat="server" AssociatedUpdatePanelID="UPNLpakSTCPOL" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpakSTCPOL" SkinID="gv_silver" runat="server" DataSourceID="ODSpakSTCPOL" DataKeyNames="SerialNo,ItemNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item No" SortExpression="ItemNo">
          <ItemTemplate>
            <asp:Label ID="LabelItemNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Code" SortExpression="ItemCode">
          <ItemTemplate>
            <asp:Label ID="LabelItemCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemCode") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="ItemDescription">
          <ItemTemplate>
            <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity" SortExpression="ItemQuantity">
          <ItemTemplate>
            <asp:Label ID="LabelItemQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemQuantity") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Element" SortExpression="IDM_WBS1_Description">
          <ItemTemplate>
             <asp:Label ID="L_ItemElement" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemElement") %>' Text='<%# Eval("IDM_WBS1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="PAK_POLineStatus3_Description">
          <ItemTemplate>
             <asp:Label ID="L_ItemStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemStatusID") %>' Text='<%# Eval("PAK_POLineStatus3_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakSTCPOL"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakSTCPOL"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakSTCPOLSelectList"
      TypeName = "SIS.PAK.pakSTCPOL"
      SelectCountMethod = "pakSTCPOLSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakSTCPOL" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakSTCPO"
  DataObjectTypeName = "SIS.PAK.pakSTCPO"
  SelectMethod = "pakSTCPOGetByID"
  UpdateMethod="pakSTCPOUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSTCPO"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
