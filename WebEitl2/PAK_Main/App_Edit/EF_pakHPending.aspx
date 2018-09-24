<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakHPending.aspx.vb" Inherits="EF_pakHPending" title="Edit: Pending To Receive" %>
<asp:Content ID="CPHpakHPending" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakHPending" runat="server" Text="&nbsp;Edit: Pending To Receive"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakHPending" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakHPending"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "pakHPending"
    runat = "server" />
<asp:FormView ID="FVpakHPending"
  runat = "server"
  DataKeyNames = "SerialNo,PkgNo"
  DataSourceID = "ODSpakHPending"
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
          <b><asp:Label ID="L_PkgNo" runat="server" ForeColor="#CC6633" Text="Pkg. No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PkgNo"
            Text='<%# Bind("PkgNo") %>'
            ToolTip="Value of Pkg. No."
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
          <asp:Label ID="L_SupplierRefNo" runat="server" Text="Supplier Ref. No :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SupplierRefNo"
            Text='<%# Bind("SupplierRefNo") %>'
            ToolTip="Value of Supplier Ref. No."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TransporterID" runat="server" Text="Transporter :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_TransporterID"
            Width="80px"
            Text='<%# Bind("TransporterID") %>'
            Enabled = "False"
            ToolTip="Value of Transporter."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_TransporterID_Display"
            Text='<%# Eval("VR_BusinessPartner4_BPName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TransporterName" runat="server" Text="Transporter Name :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TransporterName"
            Text='<%# Bind("TransporterName") %>'
            ToolTip="Value of Transporter Name."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VehicleNo" runat="server" Text="Vehicle No :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_VehicleNo"
            Text='<%# Bind("VehicleNo") %>'
            ToolTip="Value of Vehicle No."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_GRNo" runat="server" Text="GR No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_GRNo"
            Text='<%# Bind("GRNo") %>'
            ToolTip="Value of GR No."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_GRDate" runat="server" Text="GR Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_GRDate"
            Text='<%# Bind("GRDate") %>'
            ToolTip="Value of GR Date."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VRExecutionNo" runat="server" Text="Vehicle Execution No. :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_VRExecutionNo"
            Width="88px"
            Text='<%# Bind("VRExecutionNo") %>'
            Enabled = "False"
            ToolTip="Value of Vehicle Execution No.."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_VRExecutionNo_Display"
            Text='<%# Eval("VR_RequestExecution5_ExecutionDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TotalWeight" runat="server" Text="Total Weight :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalWeight"
            Text='<%# Bind("TotalWeight") %>'
            ToolTip="Value of Total Weight."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_UOMTotalWeight" runat="server" Text="UOM [Total Weight] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_UOMTotalWeight"
            Width="88px"
            Text='<%# Bind("UOMTotalWeight") %>'
            Enabled = "False"
            ToolTip="Value of UOM [Total Weight]."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_UOMTotalWeight_Display"
            Text='<%# Eval("PAK_Units3_Description") %>'
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_StatusID"
            Width="88px"
            Text='<%# Bind("StatusID") %>'
            Enabled = "False"
            ToolTip="Value of Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_StatusID_Display"
            Text='<%# Eval("PAK_PkgStatus6_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreatedOn"
            Text='<%# Bind("CreatedOn") %>'
            ToolTip="Value of Created On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            Width="72px"
            Text='<%# Bind("CreatedBy") %>'
            Enabled = "False"
            ToolTip="Value of Created By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpakDPending" runat="server" Text="&nbsp;List: Packing List Items"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakDPending" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakDPending"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakDPending.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "pakDPending"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakDPending" runat="server" AssociatedUpdatePanelID="UPNLpakDPending" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpakDPending" SkinID="gv_silver" runat="server" DataSourceID="ODSpakDPending" DataKeyNames="SerialNo,PkgNo,BOMNo,ItemNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item No" SortExpression="PAK_POBItems4_ItemDescription">
          <ItemTemplate>
             <asp:Label ID="L_ItemNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemNo") %>' Text='<%# Eval("PAK_POBItems4_ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM Quantity" SortExpression="PAK_Units6_Description">
          <ItemTemplate>
             <asp:Label ID="L_UOMQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOMQuantity") %>' Text='<%# Eval("PAK_Units6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
          <ItemTemplate>
            <asp:Label ID="LabelQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Quantity") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM Weight" SortExpression="PAK_Units7_Description">
          <ItemTemplate>
             <asp:Label ID="L_UOMWeight" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOMWeight") %>' Text='<%# Eval("PAK_Units7_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Weight Per Unit" SortExpression="WeightPerUnit">
          <ItemTemplate>
            <asp:Label ID="LabelWeightPerUnit" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("WeightPerUnit") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakDPending"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakDPending"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_pakDPendingSelectList"
      TypeName = "SIS.PAK.pakDPending"
      SelectCountMethod = "pakDPendingSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_PkgNo" PropertyName="Text" Name="PkgNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakDPending" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakHPending"
  DataObjectTypeName = "SIS.PAK.pakHPending"
  SelectMethod = "pakHPendingGetByID"
  UpdateMethod="UZ_pakHPendingUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakHPending"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="PkgNo" Name="PkgNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
