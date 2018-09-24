<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_eitlImportPOList.aspx.vb" Inherits="GF_eitlImportPOList" title="Maintain List: Import & Issue PO" %>
<asp:Content ID="CPHeitlImportPOListMain" ContentPlaceHolderID="cphMain" Runat="Server">
  <style>
    .toggler {height: 30px;position:relative;margin:auto;  }
    #button { padding: .5em 1em; text-decoration: none; }
    #effect { height: 30px; padding: 0.4em;position: relative; background: #fff; }
    #effect h3 { margin: 0; padding: 0.4em; text-align: center; }
  </style>
  <script>
    $(function () {
      var state = true;
      $("#button").click(function () {
        if (state) {
          $("#effect").animate({
            backgroundColor: "#aa0000",
            color: "#fff",
            height: 80
          }, 1000);
          document.getElementById('tblImport').style.display = 'block';
        } else {
          $("#effect").animate({
            backgroundColor: "#fff",
            color: "#000",
            height: 30
          }, 1000);
          document.getElementById('tblImport').style.display = 'none';
        }
        state = !state;
        return false;
      });
    });
  </script>
  </asp:Content>
<asp:Content ID="CPHeitlImportPOList" ContentPlaceHolderID="cph1" Runat="Server">
  <div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeleitlImportPOList" runat="server" Text="&nbsp;List: Import & Issue PO"></asp:Label>
</div>
<div class="pagedata">
  <asp:UpdatePanel ID="UPNLeitlImportPOList" runat="server">
    <ContentTemplate>
      <div class="sis_formview">
        <LGM:ToolBar0 ID="TBLeitlImportPOList" ToolType="lgNMGrid" EditUrl="~/EITL_Main/App_Edit/EF_eitlImportPOList.aspx" AddUrl="~/EITL_Main/App_Create/AF_eitlImportPOList.aspx" ValidationGroup="eitlImportPOList" runat="server" />
        <div class="toggler">
          <div id="effect" class="ui-widget-content ui-corner-all" style="float: left;">
            <h3 id="button" class="ui-widget-header ui-corner-all" style="cursor: pointer">
              Import PO From ERP</h3>
            <br />
            <table id="tblImport" style="display: none;">
              <tr>
                <td>
                  <b>
                    <asp:Label ID="Label1" runat="server" Text="Project ID:" />
                  </b>
                </td>
                <td>
                  <asp:TextBox ID="F_ProjectID" runat="server" MaxLength="6" Style="text-transform: uppercase" Width="80px" />
                </td>
                <td>
                  <asp:Button ID="cmdImport" runat="server" OnClientClick="return confirm('Import PO of Project from ERP ?');" Text="Import Project-PO from ERP" />
                </td>
                <td style="padding: 0px 4px 0px 4px"><b>OR</b>
                </td>
                <td>
                  <b>
                    <asp:Label ID="Label2" runat="server" Text="Import Spacific PO Number:" />
                  </b>
                </td>
                <td>
                  <asp:TextBox ID="F_PONumber" runat="server" MaxLength="9" Style="text-transform: uppercase" Width="100px" />
                </td>
                <td>
                  <asp:Button ID="cmdPOImport" runat="server" OnClientClick="return confirm('Import Specific PO from ERP ?');" Text="Import Specific-PO from ERP" />
                </td>
              </tr>
            </table>
            </br>
          </div>
        </div>
        <div>
          <asp:UpdateProgress ID="UPGSeitlImportPOList" runat="server" AssociatedUpdatePanelID="UPNLeitlImportPOList" DisplayAfter="100">
            <ProgressTemplate>
              <span style="color: #ff0033">Loading...</span>
            </ProgressTemplate>
          </asp:UpdateProgress>
          <asp:GridView ID="GVeitlImportPOList" SkinID="gv_silver" runat="server" DataSourceID="ODSeitlImportPOList" DataKeyNames="SerialNo">
            <Columns>
              <asp:TemplateField HeaderText="S.No" SortExpression="SerialNo">
                <ItemTemplate>
                  <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="alignCenter" />
                <HeaderStyle HorizontalAlign="Center" Width="40px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="PO Number" SortExpression="PONumber">
                <ItemTemplate>
                  <asp:Label ID="LabelPONumber" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PONumber") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="60px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="PO REV." SortExpression="PORevision">
                <ItemTemplate>
                  <asp:Label ID="LabelPORevision" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PORevision") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="alignCenter" />
                <HeaderStyle HorizontalAlign="Center" Width="40px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="PO Date" SortExpression="PODate">
                <ItemTemplate>
                  <asp:Label ID="LabelPODate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PODate") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Supplier" SortExpression="EITL_Suppliers5_SupplierName">
                <ItemTemplate>
                  <asp:Label ID="L_SupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SupplierID") %>' Text='<%# Eval("EITL_Suppliers5_SupplierName") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="200px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Project" SortExpression="IDM_Projects6_Description">
                <ItemTemplate>
                  <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects6_Description") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="200px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Division" SortExpression="DivisionID">
                <ItemTemplate>
                  <asp:Label ID="LabelDivisionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DivisionID") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="60px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Buyer" SortExpression="aspnet_Users1_UserFullName">
                <ItemTemplate>
                  <asp:Label ID="L_BuyerID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BuyerID") %>' Text='<%# Eval("aspnet_Users1_UserFullName") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="200px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Issue To Supplier">
                <ItemTemplate>
                  <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="IssueToSupplier" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""IssueToSupplier record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
                </ItemTemplate>
                <ItemStyle CssClass="alignCenter" />
                <HeaderStyle HorizontalAlign="Center" Width="60px" />
              </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
              <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
            </EmptyDataTemplate>
          </asp:GridView>
          <asp:ObjectDataSource ID="ODSeitlImportPOList" runat="server" DataObjectTypeName="SIS.EITL.eitlImportPOList" OldValuesParameterFormatString="original_{0}" SelectMethod="UZ_eitlImportPOListSelectList" TypeName="SIS.EITL.eitlImportPOList" SelectCountMethod="eitlImportPOListSelectCount" SortParameterName="OrderBy" EnablePaging="True">
            <SelectParameters>
              <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
              <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
            </SelectParameters>
          </asp:ObjectDataSource>
        </div>
      </div>
    </ContentTemplate>
    <Triggers>
      <asp:AsyncPostBackTrigger ControlID="GVeitlImportPOList" EventName="PageIndexChanged" />
    </Triggers>
  </asp:UpdatePanel>
</div>
</div>
</asp:Content>
