<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_pakItems.aspx.vb" Inherits="GF_pakItems" title="Maintain List: Main Item" %>
<asp:Content ID="CPHpakItems" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakItems" runat="server" Text="&nbsp;List: Main Item"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakItems" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakItems"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakItems.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakItems.aspx?skip=1"
      ValidationGroup = "pakItems"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakItems" runat="server" AssociatedUpdatePanelID="UPNLpakItems" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RootItem" runat="server" Text="Root Item :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_RootItem"
            CssClass = "myfktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_RootItem(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_RootItem_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACERootItem"
            BehaviorID="B_ACERootItem"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="RootItemCompletionList"
            TargetControlID="F_RootItem"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACERootItem_Selected"
            OnClientPopulating="ACERootItem_Populating"
            OnClientPopulated="ACERootItem_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td>
          <asp:Label ID="errMsg" runat="server" Font-Bold="true" ForeColor="Red" Text=""></asp:Label>
          <div id="F_Upload" runat="server" style="width: 90%; margin: 10px 10px 10px 10px; padding: 10px 10px 10px 10px" class="file_upload">
            <table>
              <tr>
                <td><b>Upload Template</b></td>
                <td>
                  <input type="text" id="fileName" style="width: 185px" class="file_input_textbox" readonly="readonly">
                </td>
                <td>
                  <div class="file_input_div">
                    <input type="button" value="Search" class="file_input_button" />
                    <asp:FileUpload ID="F_FileUpload" runat="server" Width="80px" class="file_input_hidden" onchange="document.getElementById('fileName').value = this.value;" ToolTip="Upload Item Template" />
                  </div>
                </td>
                <td>
                  <asp:Button ID="cmdFileUpload" CssClass="file_upload_button" OnClientClick="return this.style.display='none';true;" Text="Upload" runat="server" ToolTip="Click to upload & process template file." CommandName="Upload" CommandArgument="" />
                </td>
              </tr>
            </table>
          </div>

        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVpakItems" SkinID="gv_silver" runat="server" DataSourceID="ODSpakItems" DataKeyNames="ItemNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PRINT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Get Tmpl.">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDownload" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Download Template File." SkinID="download" OnClientClick='<%# Eval("GetDownloadLink") %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item No" SortExpression="ItemNo">
          <ItemTemplate>
            <asp:Label ID="LabelItemNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Code" SortExpression="ItemCode">
          <ItemTemplate>
            <asp:Label ID="LabelItemCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemCode") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle CssClass="alignLeft" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Description" SortExpression="ItemDescription">
          <ItemTemplate>
            <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Element ID" SortExpression="PAK_Elements3_Description">
          <ItemTemplate>
             <asp:Label ID="L_ElementID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ElementID") %>' Text='<%# Eval("PAK_Elements3_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Active" SortExpression="Active">
          <ItemTemplate>
            <asp:Label ID="LabelActive" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Active") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakItems"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakItems"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_pakItemsSelectList"
      TypeName = "SIS.PAK.pakItems"
      SelectCountMethod = "pakItemsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_RootItem" PropertyName="Text" Name="RootItem" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakItems" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_RootItem" />
    <asp:PostBackTrigger ControlID="cmdFileUpload" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
