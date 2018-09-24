<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakItems.aspx.vb" Inherits="EF_pakItems" title="Edit: Main Item" %>
<asp:Content ID="CPHpakItems" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakItems" runat="server" Text="&nbsp;Edit: Main Item"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakItems" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakItems"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "pakItems"
    runat = "server" />
<asp:FormView ID="FVpakItems"
  runat = "server"
  DataKeyNames = "ItemNo"
  DataSourceID = "ODSpakItems"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RootItem" runat="server" Text="Root Item :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_RootItem"
            Width="88px"
            Text='<%# Bind("RootItem") %>'
            Enabled = "False"
            ToolTip="Value of Root Item."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_RootItem_Display"
            Text='<%# Eval("PAK_Items7_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_ItemNo" runat="server" ForeColor="#CC6633" Text="Item No :" /><span style="color:red">*</span></b>
        </td>
        <td>
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
          <asp:Label ID="L_ItemCode" runat="server" Text="Item Code :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ItemCode"
            Text='<%# Bind("ItemCode") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakItems"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Item Code."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemCode"
            runat = "server"
            ControlToValidate = "F_ItemCode"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakItems"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ItemDescription" runat="server" Text="Item Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ItemDescription"
            Text='<%# Bind("ItemDescription") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakItems"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Item Description."
            MaxLength="100"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemDescription"
            runat = "server"
            ControlToValidate = "F_ItemDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakItems"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ElementID" runat="server" Text="Element ID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ElementID"
            CssClass = "myfktxt"
            Text='<%# Bind("ElementID") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Element ID."
            onblur= "script_pakItems.validate_ElementID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ElementID_Display"
            Text='<%# Eval("PAK_Elements3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEElementID"
            BehaviorID="B_ACEElementID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ElementIDCompletionList"
            TargetControlID="F_ElementID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakItems.ACEElementID_Selected"
            OnClientPopulating="script_pakItems.ACEElementID_Populating"
            OnClientPopulated="script_pakItems.ACEElementID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Active" runat="server" Text="Active :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_Active"
            Checked='<%# Bind("Active") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpakCItems" runat="server" Text="&nbsp;List: Child Items"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakCItems" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakCItems"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakCItems.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakCItems.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "pakCItems"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakCItems" runat="server" AssociatedUpdatePanelID="UPNLpakCItems" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Edit/EF_','App_Print/RP_');
        url = url + '&pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVpakCItems" SkinID="gv_silver" runat="server" DataSourceID="ODSpakCItems" DataKeyNames="RootItem,ItemNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
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
        <asp:TemplateField HeaderText="Item No" SortExpression="ItemNo">
          <ItemTemplate>
            <asp:Label ID="LabelItemNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="Item Code" SortExpression="ItemCode">
          <ItemTemplate>
            <asp:Label ID="LabelItemCode" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemCode") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Item Description" SortExpression="ItemDescription">
          <ItemTemplate>
            <asp:Label ID="LabelItemDescription" runat="server" Font-Bold='<%# Eval("FontBold") %>' ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("pItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="600px" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="Element ID" SortExpression="PAK_Elements3_Description">
          <ItemTemplate>
             <asp:Label ID="L_ElementID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ElementID") %>' Text='<%# Eval("PAK_Elements3_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
          <ItemTemplate>
            <asp:Label ID="LabelQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("pQuantity") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Unit Weight" SortExpression="WeightPerUnit">
          <ItemTemplate>
             <asp:Label ID="L_WeightPerUnit" runat="server" ForeColor='<%# EVal("ForeColor") %>'  Text='<%# Eval("pWeightPerUnit") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""It will also DELETE all CHILD ITEMs below this item ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakCItems"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakCItems"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_pakHCItemsSelectList"
      TypeName = "SIS.PAK.pakCItems"
      SelectCountMethod = "pakCItemsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpakCItems" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
  <Triggers>
  </Triggers>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakItems"
  DataObjectTypeName = "SIS.PAK.pakItems"
  SelectMethod = "pakItemsGetByID"
  UpdateMethod="UZ_pakItemsUpdate"
  DeleteMethod="UZ_pakItemsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakItems"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemNo" Name="ItemNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
