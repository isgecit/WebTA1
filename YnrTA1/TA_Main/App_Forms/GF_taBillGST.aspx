<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_taBillGST.aspx.vb" Inherits="GF_taBillGST" title="Maintain List: TA Bill GST" %>
<asp:Content ID="CPHtaBillGST" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaBillGST" runat="server" Text="&nbsp;List: TA Bill GST"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLtaBillGST" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBillGST"
      ToolType = "lgNMGrid"
      EditUrl = "~/TA_Main/App_Edit/EF_taBillGST.aspx"
      AddUrl = "~/TA_Main/App_Create/AF_taBillGST.aspx"
      ValidationGroup = "taBillGST"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBillGST" runat="server" AssociatedUpdatePanelID="UPNLtaBillGST" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVtaBillGST" SkinID="gv_silver" runat="server" DataSourceID="ODStaBillGST" DataKeyNames="TABillNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TA Bill No" SortExpression="TA_Bills6_PurposeOfJourney">
          <ItemTemplate>
             <asp:Label ID="L_TABillNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("TABillNo") %>' Text='<%# Eval("TA_Bills6_PurposeOfJourney") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="TA_BillDetails5_">
          <ItemTemplate>
             <asp:Label ID="L_SerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SerialNo") %>' Text='<%# Eval("TA_BillDetails5_") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Isgec GSTIN" SortExpression="SPMT_IsgecGSTIN4_Description">
          <ItemTemplate>
             <asp:Label ID="L_IsgecGSTIN" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("IsgecGSTIN") %>' Text='<%# Eval("SPMT_IsgecGSTIN4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bill Number" SortExpression="BillNumber">
          <ItemTemplate>
            <asp:Label ID="LabelBillNumber" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BillNumber") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bill Date" SortExpression="BillDate">
          <ItemTemplate>
            <asp:Label ID="LabelBillDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BillDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier GSTIN" SortExpression="VR_BPGSTIN7_Description">
          <ItemTemplate>
             <asp:Label ID="L_SupplierGSTIN" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SupplierGSTIN") %>' Text='<%# Eval("VR_BPGSTIN7_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Assessable Value" SortExpression="AssessableValue">
          <ItemTemplate>
            <asp:Label ID="LabelAssessableValue" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("AssessableValue") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total GST" SortExpression="TotalGST">
          <ItemTemplate>
            <asp:Label ID="LabelTotalGST" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TotalGST") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Amount" SortExpression="TotalAmount">
          <ItemTemplate>
            <asp:Label ID="LabelTotalAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TotalAmount") %>'></asp:Label>
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
      ID = "ODStaBillGST"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBillGST"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBillGSTSelectList"
      TypeName = "SIS.TA.taBillGST"
      SelectCountMethod = "taBillGSTSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBillGST" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
