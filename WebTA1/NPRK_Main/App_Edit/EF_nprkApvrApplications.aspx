<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_nprkApvrApplications.aspx.vb" Inherits="EF_nprkApvrApplications" title="Edit: Approve Application" %>
<asp:Content ID="CPHnprkApvrApplications" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkApvrApplications" runat="server" Text="&nbsp;Edit: Approve Application"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkApvrApplications" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkApvrApplications"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_nprkApvrApplications.aspx?pk="
    ValidationGroup = "nprkApvrApplications"
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
<asp:FormView ID="FVnprkApvrApplications"
  runat = "server"
  DataKeyNames = "ClaimID,ApplicationID"
  DataSourceID = "ODSnprkApvrApplications"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ClaimID" runat="server" ForeColor="#CC6633" Text="Claim Number :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ClaimID"
            Width="88px"
            Text='<%# Bind("ClaimID") %>'
            Enabled = "False"
            ToolTip="Value of Claim Number."
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ClaimID_Display"
            Text='<%# Eval("PRK_UserClaims9_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ApplicationID" runat="server" ForeColor="#CC6633" Text="Application ID :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApplicationID"
            Text='<%# Bind("ApplicationID") %>'
            ToolTip="Value of Application ID."
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
          <asp:Label ID="L_EmployeeID" runat="server" Text="Employee :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_EmployeeID"
            Width="88px"
            Text='<%# Bind("EmployeeID") %>'
            Enabled = "False"
            ToolTip="Value of Employee."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_EmployeeID_Display"
            Text='<%# Eval("PRK_Employees1_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PerkID" runat="server" Text="Perk :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_PerkID"
            Width="88px"
            Text='<%# Bind("PerkID") %>'
            Enabled = "False"
            ToolTip="Value of Perk."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_PerkID_Display"
            Text='<%# Eval("PRK_Perks7_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AppliedOn" runat="server" Text="Applied On :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_AppliedOn"
            Text='<%# Bind("AppliedOn") %>'
            ToolTip="Value of Applied On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Value" runat="server" Text="Claimed Amount :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Value"
            Text='<%# Bind("Value") %>'
            ToolTip="Value of Claimed Amount."
            Enabled = "False"
            Width="104px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UserRemark" runat="server" Text="User Remark :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_UserRemark"
            Text='<%# Bind("UserRemark") %>'
            ToolTip="Value of User Remark."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Documents" runat="server" Text="Doc.OK :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_Documents"
            SelectedValue='<%# Bind("Documents") %>'
            Width="200px"
            Enabled = "False"
            CssClass = "dmyddl"
            Runat="Server" >
            <asp:ListItem Value="False">NO</asp:ListItem>
            <asp:ListItem Value="True">YES</asp:ListItem>
          </asp:DropDownList>
         </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Verified" runat="server" Text="Verified :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_Verified"
            SelectedValue='<%# Bind("Verified") %>'
            Width="200px"
            Enabled = "False"
            CssClass = "dmyddl"
            Runat="Server" >
            <asp:ListItem Value="False">NO</asp:ListItem>
            <asp:ListItem Value="True">YES</asp:ListItem>
          </asp:DropDownList>
         </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VerifiedAmt" runat="server" Text="Verified Amt :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_VerifiedAmt"
            Text='<%# Bind("VerifiedAmt") %>'
            ToolTip="Value of Verified Amt."
            Enabled = "False"
            Width="104px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VerifierRemark" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_VerifierRemark"
            Text='<%# Bind("VerifierRemark") %>'
            ToolTip="Value of Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td colspan="4">
          <LGM:LC_PrkBalance 
            ID="LC_PrkBalance1" 
            EmployeeID='<%# Bind("EmployeeID") %>'
            PerkID='<%# Bind("PerkID") %>'
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Approved" runat="server" Text="Approved :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_Approved"
            SelectedValue='<%# Bind("Approved") %>'
            CssClass = "myddl"
            Width="200px"
            ValidationGroup = "nprkApvrApplications"
            Runat="Server" >
            <asp:ListItem Value="False">NO</asp:ListItem>
            <asp:ListItem Value="True">YES</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVApproved"
            runat = "server"
            ControlToValidate = "F_Approved"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkApvrApplications"
            SetFocusOnError="true" />
         </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApprovedAmt" runat="server" Text="Approved Amt :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApprovedAmt"
            Text='<%# Bind("ApprovedAmt") %>'
            style="text-align: right"
            Width="104px"
            CssClass = "mytxt"
            MaxLength="12"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEApprovedAmt"
            runat = "server"
            mask = "9999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ApprovedAmt" />
          <AJX:MaskedEditValidator 
            ID = "MEVApprovedAmt"
            runat = "server"
            ControlToValidate = "F_ApprovedAmt"
            ControlExtender = "MEEApprovedAmt"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PaymentMethod" runat="server" Text="Payment Method :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_PaymentMethod"
            SelectedValue='<%# Bind("PaymentMethod") %>'
            CssClass = "myddl"
            Width="200px"
            ValidationGroup = "nprkApvrApplications"
            Runat="Server" >
            <asp:ListItem Value="">---Select---</asp:ListItem>
            <asp:ListItem Value="Cash">Cash</asp:ListItem>
            <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
            <asp:ListItem Value="Imprest">Imprest</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVPaymentMethod"
            runat = "server"
            ControlToValidate = "F_PaymentMethod"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkApvrApplications"
            SetFocusOnError="true" />
         </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApproverRemark" runat="server" Text="Approver Remark :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApproverRemark"
            Text='<%# Bind("ApproverRemark") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="nprkApvrApplications"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Approver Remark."
            MaxLength="100"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVApproverRemark"
            runat = "server"
            ControlToValidate = "F_ApproverRemark"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkApvrApplications"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td colspan="2" style="border-top: solid 1pt LightGrey; text-align:center;" >
          <asp:Button ID="cmdSaveNForward" runat="server" Text="Save and Forward" CommandName="svNfd" ValidationGroup = "nprkApvrApplications" CausesValidation="true" />
        </td>
        <td colspan="2" style="border-top: solid 1pt LightGrey; text-align:center;" >
          <asp:Button ID="cmdDownload" runat="server" Text="Download Logbook" CommandName="lgDownload"  CommandArgument='<%# Eval("PrimaryKey") %>' ToolTip="Click to download attacment." />
        </td>
      </tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelnprkBillDetails" runat="server" Text="&nbsp;List: Bill Details"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLnprkBillDetails" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLnprkBillDetails"
      ToolType = "lgNMGrid"
      EditUrl = "~/NPRK_Main/App_Edit/EF_nprkBillDetails.aspx"
      AddUrl = "~/NPRK_Main/App_Create/AF_nprkBillDetails.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "nprkBillDetails"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSnprkBillDetails" runat="server" AssociatedUpdatePanelID="UPNLnprkBillDetails" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVnprkBillDetails" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkBillDetails" DataKeyNames="ClaimID,ApplicationID,AttachmentID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PARTICULARS" SortExpression="Particulars">
          <ItemTemplate>
            <asp:Label ID="LabelParticulars" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Particulars") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CLAIMED AMT." SortExpression="Amount">
          <ItemTemplate>
            <asp:Label ID="LabelAmount" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Amount") %>'></asp:Label>
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
      ID = "ODSnprkBillDetails"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkBillDetails"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_nprkBillDetailsSelectList"
      TypeName = "SIS.NPRK.nprkBillDetails"
      SelectCountMethod = "nprkBillDetailsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ApplicationID" PropertyName="Text" Name="ApplicationID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ClaimID" PropertyName="Text" Name="ClaimID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVnprkBillDetails" EventName="PageIndexChanged" />
    <asp:PostBackTrigger ControlID="cmdDownload"/>
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSnprkApvrApplications"
  DataObjectTypeName = "SIS.NPRK.nprkApvrApplications"
  SelectMethod = "nprkApvrApplicationsGetByID"
  UpdateMethod="UZ_nprkApvrApplicationsUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkApvrApplications"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ClaimID" Name="ClaimID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ApplicationID" Name="ApplicationID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
