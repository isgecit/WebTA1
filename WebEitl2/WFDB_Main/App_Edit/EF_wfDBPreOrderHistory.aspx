<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_wfDBPreOrderHistory.aspx.vb" Inherits="EF_wfDBPreOrderHistory" title="Edit: Pre Order History" %>
<asp:Content ID="CPHwfDBPreOrderHistory" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelwfDBPreOrderHistory" runat="server" Text="&nbsp;Edit: Pre Order History"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLwfDBPreOrderHistory" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLwfDBPreOrderHistory"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "wfDBPreOrderHistory"
    runat = "server" />
<asp:FormView ID="FVwfDBPreOrderHistory"
  runat = "server"
  DataKeyNames = "WFID"
  DataSourceID = "ODSwfDBPreOrderHistory"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_WFID" runat="server" ForeColor="#CC6633" Text="WFID :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_WFID"
            Text='<%# Bind("WFID") %>'
            ToolTip="Value of WFID."
            Enabled = "False"
            Width="88px"
            CssClass = "dmypktxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Project" runat="server" Text="Project :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Project"
            Text='<%# Bind("Project") %>'
            ToolTip="Value of Project."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Element" runat="server" Text="Element :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Element"
            Text='<%# Bind("Element") %>'
            ToolTip="Value of Element."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SpecificationNo" runat="server" Text="SpecificationNo :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SpecificationNo"
            Text='<%# Bind("SpecificationNo") %>'
            ToolTip="Value of SpecificationNo."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Buyer" runat="server" Text="Buyer :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Buyer"
            Text='<%# Bind("Buyer") %>'
            ToolTip="Value of Buyer."
            Enabled = "False"
            Width="72px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierName" runat="server" Text="SupplierName :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SupplierName"
            Text='<%# Bind("SupplierName") %>'
            ToolTip="Value of SupplierName."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Supplier" runat="server" Text="Supplier :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Supplier"
            Text='<%# Bind("Supplier") %>'
            ToolTip="Value of Supplier."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Notes" runat="server" Text="Notes :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Notes"
            Text='<%# Bind("Notes") %>'
            ToolTip="Value of Notes."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelwfdbNotes" runat="server" Text="&nbsp;List: Notes"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLwfdbNotes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLwfdbNotes"
      ToolType = "lgNMGrid"
      EditUrl = "~/WFDB_Main/App_Edit/EF_wfdbNotes.aspx"
      AddUrl = "~/WFDB_Main/App_Create/AF_wfdbNotes.aspx"
      EnableExit = "false"
      ValidationGroup = "wfdbNotes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSwfdbNotes" runat="server" AssociatedUpdatePanelID="UPNLwfdbNotes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVwfdbNotes" SkinID="gv_silver" runat="server" DataSourceID="ODSwfdbNotes" DataKeyNames="IndexValue,NotesId">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IndexValue" SortExpression="IndexValue">
          <ItemTemplate>
            <asp:Label ID="LabelIndexValue" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IndexValue") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Title" SortExpression="Title">
          <ItemTemplate>
            <asp:Label ID="LabelTitle" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Title") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UserId" SortExpression="UserId">
          <ItemTemplate>
            <asp:Label ID="LabelUserId" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UserId") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created_Date" SortExpression="Created_Date">
          <ItemTemplate>
            <asp:Label ID="LabelCreated_Date" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Created_Date") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SendEmailTo" SortExpression="SendEmailTo">
          <ItemTemplate>
            <asp:Label ID="LabelSendEmailTo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SendEmailTo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSwfdbNotes"
      runat = "server"
      DataObjectTypeName = "SIS.WFDB.wfdbNotes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_wfdbNotesSelectList"
      TypeName = "SIS.WFDB.wfdbNotes"
      SelectCountMethod = "wfdbNotesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_IndexValue" PropertyName="Text" Name="IndexValue" Type="String" Size="200" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVwfdbNotes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelwfdbAttachments" runat="server" Text="&nbsp;List: Attachments"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLwfdbAttachments" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLwfdbAttachments"
      ToolType = "lgNMGrid"
      EditUrl = "~/WFDB_Main/App_Edit/EF_wfdbAttachments.aspx"
      AddUrl = "~/WFDB_Main/App_Create/AF_wfdbAttachments.aspx"
      EnableExit = "false"
      ValidationGroup = "wfdbAttachments"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSwfdbAttachments" runat="server" AssociatedUpdatePanelID="UPNLwfdbAttachments" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVwfdbAttachments" SkinID="gv_silver" runat="server" DataSourceID="ODSwfdbAttachments" DataKeyNames="t_indx,t_dcid">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_drid" SortExpression="t_drid">
          <ItemTemplate>
            <asp:Label ID="Labelt_drid" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_drid") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_dcid" SortExpression="t_dcid">
          <ItemTemplate>
            <asp:Label ID="Labelt_dcid" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_dcid") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_indx" SortExpression="t_indx">
          <ItemTemplate>
            <asp:Label ID="Labelt_indx" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_indx") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_prcd" SortExpression="t_prcd">
          <ItemTemplate>
            <asp:Label ID="Labelt_prcd" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_prcd") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_fnam" SortExpression="t_fnam">
          <ItemTemplate>
            <asp:Label ID="Labelt_fnam" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_fnam") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_lbcd" SortExpression="t_lbcd">
          <ItemTemplate>
            <asp:Label ID="Labelt_lbcd" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_lbcd") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="t_atby" SortExpression="t_atby">
          <ItemTemplate>
            <asp:Label ID="Labelt_atby" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("t_atby") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSwfdbAttachments"
      runat = "server"
      DataObjectTypeName = "SIS.WFDB.wfdbAttachments"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_wfdbAttachmentsSelectList"
      TypeName = "SIS.WFDB.wfdbAttachments"
      SelectCountMethod = "wfdbAttachmentsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVwfdbAttachments" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSwfDBPreOrderHistory"
  DataObjectTypeName = "SIS.WFDB.wfDBPreOrderHistory"
  SelectMethod = "UZ_wfDBPreOrderHistoryGetByID"
  UpdateMethod="UZ_wfDBPreOrderHistoryUpdate"
  DeleteMethod="UZ_wfDBPreOrderHistoryDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.WFDB.wfDBPreOrderHistory"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="WFID" Name="WFID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
