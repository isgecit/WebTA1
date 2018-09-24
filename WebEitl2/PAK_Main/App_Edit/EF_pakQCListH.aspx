<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakQCListH.aspx.vb" Inherits="EF_pakQCListH" title="Edit: Quality Clearance" %>
<asp:Content ID="CPHpakQCListH" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakQCListH" runat="server" Text="&nbsp;Edit: Quality Clearance"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakQCListH" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakQCListH"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_pakQCListH.aspx?pk="
    ValidationGroup = "pakQCListH"
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
<asp:FormView ID="FVpakQCListH"
  runat = "server"
  DataKeyNames = "SerialNo,QCLNo"
  DataSourceID = "ODSpakQCListH"
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
          <b><asp:Label ID="L_QCLNo" runat="server" ForeColor="#CC6633" Text="QC List No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_QCLNo"
            Text='<%# Bind("QCLNo") %>'
            ToolTip="Value of QC List No."
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
          <asp:Label ID="L_SupplierRef" runat="server" Text="Description :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SupplierRef"
            Text='<%# Bind("SupplierRef") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TotalWeight" runat="server" Text="Total Offered Weight :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TotalWeight"
            Text='<%# Bind("TotalWeight") %>'
            ToolTip="Value of Total Offered Weight."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_UOMTotalWeight" runat="server" Text="UOM :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_UOMTotalWeight"
            Width="88px"
            Text='<%# Bind("UOMTotalWeight") %>'
            Enabled = "False"
            ToolTip="Value of UOM."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_UOMTotalWeight_Display"
            Text='<%# Eval("PAK_Units4_Description") %>'
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
            Text='<%# Eval("PAK_QCListStatus3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
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
            ToolTip="Value of ClearedBy."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ClearedBy_Display"
            Text='<%# Eval("aspnet_users5_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ClearedOn" runat="server" Text="Cleared On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ClearedOn"
            Text='<%# Bind("ClearedOn") %>'
            ToolTip="Value of ClearedOn."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
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
          <asp:Label ID="L_PkgNo" runat="server" Text="Pkg No :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PkgNo"
            Text='<%# Bind("PkgNo") %>'
            ToolTip="Value of Pkg No."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpakQCListD" runat="server" Text="&nbsp;List: Quality Clearance Items"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakQCListD" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakQCListD"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakQCListD.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakQCListD.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      EnableAdd="False"
      ValidationGroup = "pakQCListD"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakQCListD" runat="server" AssociatedUpdatePanelID="UPNLpakQCListD" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpakQCListD" SkinID="gv_silver" runat="server" DataSourceID="ODSpakQCListD" DataKeyNames="SerialNo,QCLNo,BOMNo,ItemNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BOM No" SortExpression="PAK_POBOM4_ItemDescription">
          <ItemTemplate>
             <asp:Label ID="L_BOMNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BOMNo") %>' Text='<%# Eval("PAK_POBOM4_ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item No" SortExpression="PAK_POBItems3_ItemDescription">
          <ItemTemplate>
             <asp:Label ID="L_ItemNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemNo") %>' Text='<%# Eval("PAK_POBItems3_ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM Quantity" SortExpression="PAK_Units6_Description">
          <ItemTemplate>
             <asp:Label ID="L_UOMQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOMQuantity") %>' Text='<%# Eval("PAK_Units6_Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Offered Quantity" SortExpression="Quantity">
          <ItemTemplate>
            <asp:Label ID="LabelQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Quantity") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Inspection Stage" SortExpression="QCM_InspectionStages8_Description">
          <ItemTemplate>
             <asp:Label ID="L_InspectionStageID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("InspectionStageID") %>' Text='<%# Eval("QCM_InspectionStages8_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quality Cleared Qty" SortExpression="QualityClearedQty">
          <ItemTemplate>
            <asp:Label ID="LabelQualityClearedQty" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("QualityClearedQty") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cleared On" SortExpression="ClearedOn">
          <ItemTemplate>
            <asp:Label ID="LabelClearedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ClearedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakQCListD"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakQCListD"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakQCListDSelectList"
      TypeName = "SIS.PAK.pakQCListD"
      SelectCountMethod = "pakQCListDSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_QCLNo" PropertyName="Text" Name="QCLNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakQCListD" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakQCListH"
  DataObjectTypeName = "SIS.PAK.pakQCListH"
  SelectMethod = "pakQCListHGetByID"
  UpdateMethod="pakQCListHUpdate"
  DeleteMethod="pakQCListHDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakQCListH"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="QCLNo" Name="QCLNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
