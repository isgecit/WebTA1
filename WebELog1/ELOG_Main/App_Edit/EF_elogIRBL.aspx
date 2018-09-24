<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogIRBL.aspx.vb" Inherits="EF_elogIRBL" title="Edit: IR BL" %>
<asp:Content ID="CPHelogIRBL" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogIRBL" runat="server" Text="&nbsp;Edit: IR BL"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogIRBL" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogIRBL"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "elogIRBL"
    runat = "server" />
<asp:FormView ID="FVelogIRBL"
  runat = "server"
  DataKeyNames = "IRNo"
  DataSourceID = "ODSelogIRBL"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IRNo" runat="server" ForeColor="#CC6633" Text="IR No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IRNo"
            Text='<%# Bind("IRNo") %>'
            ToolTip="Value of IR No."
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
            Text='<%# Eval("VR_BusinessPartner10_BPName") %>'
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
            Text='<%# Eval("IDM_Projects9_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PONo" runat="server" Text="PO No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PONo"
            Text='<%# Bind("PONo") %>'
            ToolTip="Value of PO No."
            Enabled = "False"
            Width="80px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SupplierBillNo" runat="server" Text="Supplier Bill No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierBillNo"
            Text='<%# Bind("SupplierBillNo") %>'
            ToolTip="Value of Supplier Bill No."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_supplierBillDate" runat="server" Text="Supplier Bill Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_supplierBillDate"
            Text='<%# Bind("supplierBillDate") %>'
            ToolTip="Value of Supplier Bill Date."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SupplierBillAmount" runat="server" Text="Supplier Bill Amount :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierBillAmount"
            Text='<%# Bind("SupplierBillAmount") %>'
            ToolTip="Value of Supplier Bill Amount."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IRDate" runat="server" Text="IR Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_IRDate"
            Text='<%# Bind("IRDate") %>'
            ToolTip="Value of IR Date."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BLID" runat="server" Text="BL ID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_BLID"
            Width="80px"
            Text='<%# Bind("BLID") %>'
            Enabled = "False"
            ToolTip="Value of BL ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_BLID_Display"
            Text='<%# Eval("ELOG_BLHeader2_BLNumber") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BLType" runat="server" Text="BL Type :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_BLType"
            Width="88px"
            Text='<%# Bind("BLType") %>'
            Enabled = "False"
            ToolTip="Value of BL Type."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_BLType_Display"
            Text='<%# Eval("ELOG_BLTypes3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MBLNo" runat="server" Text="MBL No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MBLNo"
            Text='<%# Bind("MBLNo") %>'
            ToolTip="Value of MBL No."
            Enabled = "False"
            Width="408px"
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
          <asp:Label ID="L_ShipmentModeID" runat="server" Text="Shipment Mode :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ShipmentModeID"
            Width="88px"
            Text='<%# Bind("ShipmentModeID") %>'
            Enabled = "False"
            ToolTip="Value of Shipment Mode."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ShipmentModeID_Display"
            Text='<%# Eval("ELOG_ShipmentModes8_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CarrierID" runat="server" Text="Carrier :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CarrierID"
            Width="88px"
            Text='<%# Bind("CarrierID") %>'
            Enabled = "False"
            ToolTip="Value of Carrier."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CarrierID_Display"
            Text='<%# Eval("ELOG_Carriers5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_OtherCarrier" runat="server" Text="Other Carrier :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_OtherCarrier"
            Text='<%# Bind("OtherCarrier") %>'
            ToolTip="Value of Other Carrier."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_LocationCountryID" runat="server" Text="Location Country :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_LocationCountryID"
            Width="88px"
            Text='<%# Bind("LocationCountryID") %>'
            Enabled = "False"
            ToolTip="Value of Location Country."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_LocationCountryID_Display"
            Text='<%# Eval("ELOG_LocationCountries6_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_OtherCountry" runat="server" Text="Other Country :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_OtherCountry"
            Text='<%# Bind("OtherCountry") %>'
            ToolTip="Value of Other Country."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CargoTypeID" runat="server" Text="Cargo Type :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_CargoTypeID"
            Width="88px"
            Text='<%# Bind("CargoTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Cargo Type."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CargoTypeID_Display"
            Text='<%# Eval("ELOG_CargoTypes4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PortID" runat="server" Text="Port :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_PortID"
            Width="88px"
            Text='<%# Bind("PortID") %>'
            Enabled = "False"
            ToolTip="Value of Port."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_PortID_Display"
            Text='<%# Eval("ELOG_Ports7_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OtherPortLoadingOrigin" runat="server" Text="Other Port / Port Of Loading / Origin Point :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_OtherPortLoadingOrigin"
            Text='<%# Bind("OtherPortLoadingOrigin") %>'
            ToolTip="Value of Other Port Loading Origin."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
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
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td>
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
            Text='<%# Eval("ELOG_IRBLStates11_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelelogIRBLDetails" runat="server" Text="&nbsp;List: IR BL Charge Codes"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLelogIRBLDetails" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLelogIRBLDetails"
      ToolType = "lgNMGrid"
      EditUrl = "~/ELOG_Main/App_Edit/EF_elogIRBLDetails.aspx"
      AddUrl = "~/ELOG_Main/App_Create/AF_elogIRBLDetails.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "elogIRBLDetails"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSelogIRBLDetails" runat="server" AssociatedUpdatePanelID="UPNLelogIRBLDetails" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVelogIRBLDetails" SkinID="gv_silver" runat="server" DataSourceID="ODSelogIRBLDetails" DataKeyNames="IRNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="COPY">
          <ItemTemplate>
            <asp:ImageButton ID="cmdCopyPage" ValidationGroup="Copy" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Copy" ToolTip="Copy the record." SkinID="copy" CommandName="lgCopy" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Stuffing Type" SortExpression="ELOG_StuffingTypes8_Description">
          <ItemTemplate>
             <asp:Label ID="L_StuffingTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StuffingTypeID") %>' Text='<%# Eval("ELOG_StuffingTypes8_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ICD / CFS" SortExpression="ELOG_ICDCFSs5_Description">
          <ItemTemplate>
             <asp:Label ID="L_ICDCFSID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ICDCFSID") %>' Text='<%# Eval("ELOG_ICDCFSs5_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Break Bulk" SortExpression="ELOG_BreakbulkTypes1_Description">
          <ItemTemplate>
             <asp:Label ID="L_BreakBulkID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BreakBulkID") %>' Text='<%# Eval("ELOG_BreakbulkTypes1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Charge Type" SortExpression="ELOG_ChargeTypes4_Description">
          <ItemTemplate>
             <asp:Label ID="L_ChargeTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ChargeTypeID") %>' Text='<%# Eval("ELOG_ChargeTypes4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Charge Category" SortExpression="ELOG_ChargeCategories2_Description">
          <ItemTemplate>
             <asp:Label ID="L_ChargeCategoryID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ChargeCategoryID") %>' Text='<%# Eval("ELOG_ChargeCategories2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
          <ItemTemplate>
            <asp:Label ID="LabelAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Amount") %>'></asp:Label>
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
      ID = "ODSelogIRBLDetails"
      runat = "server"
      DataObjectTypeName = "SIS.ELOG.elogIRBLDetails"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "elogIRBLDetailsSelectList"
      TypeName = "SIS.ELOG.elogIRBLDetails"
      SelectCountMethod = "elogIRBLDetailsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_IRNo" PropertyName="Text" Name="IRNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVelogIRBLDetails" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSelogIRBL"
  DataObjectTypeName = "SIS.ELOG.elogIRBL"
  SelectMethod = "elogIRBLGetByID"
  UpdateMethod="UZ_elogIRBLUpdate"
  DeleteMethod="UZ_elogIRBLDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogIRBL"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="IRNo" Name="IRNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
