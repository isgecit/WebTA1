<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pakDocuments.aspx.vb" Inherits="GF_pakDocuments" title="Maintain List: Documents" %>
<asp:Content ID="CPHpakDocuments" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakDocuments" runat="server" Text="&nbsp;List: Documents"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakDocuments" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakDocuments"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakDocuments.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakDocuments.aspx"
      ValidationGroup = "pakDocuments"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakDocuments" runat="server" AssociatedUpdatePanelID="UPNLpakDocuments" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpakDocuments" SkinID="gv_silver" runat="server" DataSourceID="ODSpakDocuments" DataKeyNames="DocumentNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document No" SortExpression="DocumentNo">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document ID" SortExpression="DocumentID">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document Revision" SortExpression="DocumentRevision">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentRevision" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentRevision") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="External Document" SortExpression="ExternalDocument">
          <ItemTemplate>
            <asp:Label ID="LabelExternalDocument" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ExternalDocument") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="File Name" SortExpression="Filename">
          <ItemTemplate>
            <asp:Label ID="LabelFilename" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Filename") %>'></asp:Label>
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
      ID = "ODSpakDocuments"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakDocuments"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_pakDocumentsSelectList"
      TypeName = "SIS.PAK.pakDocuments"
      SelectCountMethod = "pakDocumentsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpakDocuments" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
