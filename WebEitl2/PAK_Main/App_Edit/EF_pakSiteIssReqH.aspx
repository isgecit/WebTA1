<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakSiteIssReqH.aspx.vb" Inherits="EF_pakSiteIssReqH" title="Edit: Site Issue Request" %>
<asp:Content ID="CPHpakSiteIssReqH" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSiteIssReqH" runat="server" Text="&nbsp;Edit: Site Issue Request"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSiteIssReqH" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSiteIssReqH"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_pakSiteIssReqH.aspx?pk="
    ValidationGroup = "pakSiteIssReqH"
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
<asp:FormView ID="FVpakSiteIssReqH"
  runat = "server"
  DataKeyNames = "ProjectID,IssueNo"
  DataSourceID = "ODSpakSiteIssReqH"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project."
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IssueNo" runat="server" ForeColor="#CC6633" Text="Request No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IssueNo"
            Text='<%# Bind("IssueNo") %>'
            ToolTip="Value of Request No."
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
          <asp:Label ID="L_RequesterRemarks" runat="server" Text="Requester Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_RequesterRemarks"
            Text='<%# Bind("RequesterRemarks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Requester Remarks."
            MaxLength="100"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RequestedBy" runat="server" Text="Requested By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_RequestedBy"
            Width="72px"
            Text='<%# Bind("RequestedBy") %>'
            Enabled = "False"
            ToolTip="Value of Requested By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_RequestedBy_Display"
            Text='<%# Eval("aspnet_users6_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_RequestedOn" runat="server" Text="Requested On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_RequestedOn"
            Text='<%# Bind("RequestedOn") %>'
            ToolTip="Value of Requested On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IssuedBy" runat="server" Text="Issued By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_IssuedBy"
            Width="72px"
            Text='<%# Bind("IssuedBy") %>'
            Enabled = "False"
            ToolTip="Value of Issued By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_IssuedBy_Display"
            Text='<%# Eval("aspnet_users2_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_IssuedOn" runat="server" Text="Issued On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_IssuedOn"
            Text='<%# Bind("IssuedOn") %>'
            ToolTip="Value of Issued On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IssueRemarks" runat="server" Text="Issue Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IssueRemarks"
            Text='<%# Bind("IssueRemarks") %>'
            ToolTip="Value of Issue Remarks."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IssueToName" runat="server" Text="Requester Name :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_IssueToName"
            Text='<%# Bind("IssueToName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="pakSiteIssReqH"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Requester Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVIssueToName"
            runat = "server"
            ControlToValidate = "F_IssueToName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "pakSiteIssReqH"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_IssueToCardNo" runat="server" Text="Issue To :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_IssueToCardNo"
            Width="72px"
            Text='<%# Bind("IssueToCardNo") %>'
            Enabled = "False"
            ToolTip="Value of Issue To."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_IssueToCardNo_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IssueStatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_IssueStatusID"
            Width="88px"
            Text='<%# Bind("IssueStatusID") %>'
            Enabled = "False"
            ToolTip="Value of Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_IssueStatusID_Display"
            Text='<%# Eval("PAK_IssueStatus4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_IssueTypeID" runat="server" Text="Issue Type :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_IssueTypeID"
            Width="88px"
            Text='<%# Bind("IssueTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Issue Type."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_IssueTypeID_Display"
            Text='<%# Eval("PAK_IssueTypes5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpakSiteIssRecD" runat="server" Text="&nbsp;List: Site Issue Request Item"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakSiteIssRecD" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakSiteIssRecD"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakSiteIssRecD.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakSiteIssRecD.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "pakSiteIssRecD"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakSiteIssRecD" runat="server" AssociatedUpdatePanelID="UPNLpakSiteIssRecD" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpakSiteIssRecD" SkinID="gv_silver" runat="server" DataSourceID="ODSpakSiteIssRecD" DataKeyNames="ProjectID,IssueNo,IssueSrNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Request Line No" SortExpression="IssueSrNo">
          <ItemTemplate>
            <asp:Label ID="LabelIssueSrNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IssueSrNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Site Mark No" SortExpression="PAK_SiteItemMaster3_ItemDescription">
          <ItemTemplate>
             <asp:Label ID="L_SiteMarkNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SiteMarkNo") %>' Text='<%# Eval("PAK_SiteItemMaster3_ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM Quantity" SortExpression="PAK_Units4_Description">
          <ItemTemplate>
             <asp:Label ID="L_UOMQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOMQuantity") %>' Text='<%# Eval("PAK_Units4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity Required" SortExpression="QuantityRequired">
          <ItemTemplate>
            <asp:Label ID="LabelQuantityRequired" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("QuantityRequired") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity Issued" SortExpression="QuantityIssued">
          <ItemTemplate>
            <asp:Label ID="LabelQuantityIssued" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("QuantityIssued") %>'></asp:Label>
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
      ID = "ODSpakSiteIssRecD"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakSiteIssRecD"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakSiteIssRecDSelectList"
      TypeName = "SIS.PAK.pakSiteIssRecD"
      SelectCountMethod = "pakSiteIssRecDSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_IssueNo" PropertyName="Text" Name="IssueNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakSiteIssRecD" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakSiteIssReqH"
  DataObjectTypeName = "SIS.PAK.pakSiteIssReqH"
  SelectMethod = "pakSiteIssReqHGetByID"
  UpdateMethod="UZ_pakSiteIssReqHUpdate"
  DeleteMethod="UZ_pakSiteIssReqHDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSiteIssReqH"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="IssueNo" Name="IssueNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
