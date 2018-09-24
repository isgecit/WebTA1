<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_elogBLHeader.aspx.vb" Inherits="EF_elogBLHeader" title="Edit: BL Header" %>
<asp:Content ID="CPHelogBLHeader" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogBLHeader" runat="server" Text="&nbsp;Edit: BL Header"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogBLHeader" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogBLHeader"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "elogBLHeader"
    runat = "server" />
<asp:FormView ID="FVelogBLHeader"
  runat = "server"
  DataKeyNames = "BLID"
  DataSourceID = "ODSelogBLHeader"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BLID" runat="server" ForeColor="#CC6633" Text="BL ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_BLID"
            Text='<%# Bind("BLID") %>'
            ToolTip="Value of BL ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="80px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BLNumber" runat="server" Text="BL Number :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_BLNumber"
            Text='<%# Bind("BLNumber") %>'
            ToolTip="Value of BL Number."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BLDate" runat="server" Text="BL Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_BLDate"
            Text='<%# Bind("BLDate") %>'
            ToolTip="Value of BL Date."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PortOfLoading" runat="server" Text="Port Of Loading :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PortOfLoading"
            Text='<%# Bind("PortOfLoading") %>'
            ToolTip="Value of Port Of Loading."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VesselOrFlightNo" runat="server" Text="Vessel Or Flight No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VesselOrFlightNo"
            Text='<%# Bind("VesselOrFlightNo") %>'
            ToolTip="Value of Vessel Or Flight No."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VoyageNo" runat="server" Text="Voyage No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VoyageNo"
            Text='<%# Bind("VoyageNo") %>'
            ToolTip="Value of Voyage No."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TransShipmentPortID" runat="server" Text="Trans Shipment Port ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TransShipmentPortID"
            Width="88px"
            Text='<%# Bind("TransShipmentPortID") %>'
            Enabled = "False"
            ToolTip="Value of Trans Shipment Port ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_TransShipmentPortID_Display"
            Text='<%# Eval("ELOG_Ports1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PrepaidFlight" runat="server" Text="Prepaid Flight :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_PrepaidFlight"
            Checked='<%# Bind("PrepaidFlight") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ShippingLine" runat="server" Text="Shipping Line :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ShippingLine"
            Text='<%# Bind("ShippingLine") %>'
            ToolTip="Value of Shipping Line."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SOBDate" runat="server" Text="SOB Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SOBDate"
            Text='<%# Bind("SOBDate") %>'
            ToolTip="Value of SOB Date."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
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
        <td class="alignright">
          <asp:Label ID="L_PreCarriageBy" runat="server" Text="Pre Carriage By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PreCarriageBy"
            Text='<%# Bind("PreCarriageBy") %>'
            ToolTip="Value of Pre Carriage By."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PlaceOfReceiptBy" runat="server" Text="Place Of Receipt By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PlaceOfReceiptBy"
            Text='<%# Bind("PlaceOfReceiptBy") %>'
            ToolTip="Value of Place Of Receipt By."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Air1Freight" runat="server" Text="Air Freight [1] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Air1Freight"
            Text='<%# Bind("Air1Freight") %>'
            ToolTip="Value of Air Freight [1]."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Air2Freight" runat="server" Text="Air Freight [2] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Air2Freight"
            Text='<%# Bind("Air2Freight") %>'
            ToolTip="Value of Air Freight [2]."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Air3Freight" runat="server" Text="Air Freight [3] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Air3Freight"
            Text='<%# Bind("Air3Freight") %>'
            ToolTip="Value of Air Freight [3]."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Air4Freight" runat="server" Text="Air Freight [4] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Air4Freight"
            Text='<%# Bind("Air4Freight") %>'
            ToolTip="Value of Air Freight [4]."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelelogBLDetails" runat="server" Text="&nbsp;List: BL Details"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLelogBLDetails" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLelogBLDetails"
      ToolType = "lgNMGrid"
      EditUrl = "~/ELOG_Main/App_Edit/EF_elogBLDetails.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "elogBLDetails"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSelogBLDetails" runat="server" AssociatedUpdatePanelID="UPNLelogBLDetails" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVelogBLDetails" SkinID="gv_silver" runat="server" DataSourceID="ODSelogBLDetails" DataKeyNames="BLID,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BL ID" SortExpression="ELOG_BLHeader1_BLNumber">
          <ItemTemplate>
             <asp:Label ID="L_BLID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BLID") %>' Text='<%# Eval("ELOG_BLHeader1_BLNumber") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Size And Type Of Container" SortExpression="SizeAndTypeOfContainer">
          <ItemTemplate>
            <asp:Label ID="LabelSizeAndTypeOfContainer" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SizeAndTypeOfContainer") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Container Number" SortExpression="ContainerNumber">
          <ItemTemplate>
            <asp:Label ID="LabelContainerNumber" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ContainerNumber") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
          <ItemTemplate>
            <asp:Label ID="LabelRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Remarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSelogBLDetails"
      runat = "server"
      DataObjectTypeName = "SIS.ELOG.elogBLDetails"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "elogBLDetailsSelectList"
      TypeName = "SIS.ELOG.elogBLDetails"
      SelectCountMethod = "elogBLDetailsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_BLID" PropertyName="Text" Name="BLID" Type="String" Size="9" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVelogBLDetails" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSelogBLHeader"
  DataObjectTypeName = "SIS.ELOG.elogBLHeader"
  SelectMethod = "elogBLHeaderGetByID"
  UpdateMethod="elogBLHeaderUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogBLHeader"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="BLID" Name="BLID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
