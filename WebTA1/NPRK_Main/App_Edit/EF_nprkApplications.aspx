<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_nprkApplications.aspx.vb" Inherits="EF_nprkApplications" title="Perk Entry Form" %>
<asp:Content ID="CPHnprkApplications" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkApplications" runat="server" Text="&nbsp;Perk Entry Form"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkApplications" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkApplications"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "nprkApplications"
    runat = "server" />
<asp:FormView ID="FVnprkApplications"
  runat = "server"
  DataKeyNames = "ApplicationID,ClaimID"
  DataSourceID = "ODSnprkApplications"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ClaimID" runat="server" ForeColor="#CC6633" Text="Claim Ref.No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_ClaimRefNo"
            Text='<%# Bind("ClaimRefNo") %>'
            ToolTip="Value of Claim ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
          <asp:TextBox
            ID = "F_ClaimID"
            Width="88px"
            Text='<%# Bind("ClaimID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            style="display:none;"
            ToolTip="Value of Claim Number."
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_ApplicationID" runat="server" style="display:none" ForeColor="#CC6633" Text="Application ID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_ApplicationID"
            Text='<%# Bind("ApplicationID") %>'
            ToolTip="Value of Application ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right;display:none;"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PerkID" runat="server" Text="Perk Type :" /><span style="color:red">*</span>
        </td>
        <td >
          <LGM:LC_nprkPerksClaimable
            ID="F_PerkID"
            SelectedValue='<%# Bind("PerkID") %>'
            OrderBy="Description"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "nprkApplications"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Enabled='<%# Eval("Editable") %>'
            OnSelectedIndexChanged="ShowBalance"
            AutoPostBack="true"
            Runat="Server" />
          </td>
        <td>
          <b><asp:Label ID="Label1" runat="server" Text="Ledger Balance: " /></b>
          <%--$('#divBal').slideToggle(600);--%>
        </td>
        <td>
          <b>
            <asp:Label ID="L_Balance" runat="server" Text="0.00" />
          </b>
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="uploadRow" runat="server" ClientIDMode="static">
        <td colspan="4">
          <table style="width:100%">
            <tr>
              <td colspan="4" class="alignCenter" style="background-color:gainsboro;padding:8px 4px 8px 4px">
                <asp:Label ID="Label4" Font-Bold="true" Font-Underline="true" runat="server" Text="If Vehicle owned by Employee, then LOG BOOK attachment is Mandatory." />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <asp:Label ID="Label3" runat="server" Text="EXCEL Template: " />
              </td>
              <td colspan="3">
                <asp:Button ID="cmdTemplate" runat="server" Text="Download" CommandName="lgTemplate" ToolTip="Click to download EXCEL template for Log Book." />
              </td>
            </tr>
            <tr>
              <td class="alignright">
                <asp:Label ID="Label2" runat="server" Text="Attatch Log Book: " />
              </td>
              <td>
                <asp:FileUpload Enabled='<%# ChildAddable %>' ID="F_ReportFile" runat="server" Width="200px" ToolTip="Click to select file to be attached." />
                <asp:Button Enabled='<%# ChildAddable %>' ID="cmdUpload" runat="server" Text="Attach" CommandName="lgUpload" CommandArgument='<%# Eval("PrimaryKey") %>' OnClientClick="return confirm('Upload File ?');" ToolTip="Click to upload selected file." />
              </td>
              <td class="alignCenter">
                <asp:ImageButton Enabled='<%# ChildAddable %>' ID="cmdDelete" runat="server" AlternateText="delete" SkinID="delete" CommandName="lgDelete"  CommandArgument='<%# Eval("PrimaryKey") %>'  OnClientClick="return confirm('Delete attachment ?');" ToolTip="Click to remove uploaded file." />
              </td>
              <td>
                <asp:LinkButton ID="cmdDownload" runat="server" ForeColor="ForestGreen" Font-Bold="true" Font-Underline="true" Text='<%# Eval("ReportFileName") %>' CommandName="lgDownload"  CommandArgument='<%# Eval("PrimaryKey") %>' ToolTip="Click to download attacment." />
              </td>
            </tr>
          </table>
        </td>
      </tr>
      <tr>
        <td colspan="4" style="background-color:aliceblue" >
            <LGM:LC_PrkBalanceAsOn 
              ID="LC_PrkBalance1" 
              PerkID='<%# Eval("PerkID") %>'
              OnDataBinding="ShowBalance"
              runat="server" />
        </td>
      </tr>
      <tr>
        <td colspan="4" style="background-color:aliceblue;text-align:center;border: solid 1pt blue;" >
          <asp:Label ID="L_ErrorMsg" ForeColor="red" Visible="false" runat="server" Text="NOTE: Application for this PERK is already under processing. You can not APPLY till that is PAID or REJECTED." />
        </td>
      </tr>
      <tr>
        <td colspan="4" style="background-color:aliceblue; text-align:center;border: solid 1pt blue;" >
           <asp:Label ID="L_crn" ForeColor="Blue" Font-Bold="true" Visible="false" runat="server" Text="" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="nprkApplications_0"><td colspan="4" onclick="groupClicked(this);" class="groupHeader" >Click here for this Perk's claim status</td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="Status ID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_StatusID"
            Width="88px"
            Text='<%# Bind("StatusID") %>'
            Enabled = "False"
            ToolTip="Value of Status ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_StatusID_Display"
            Text='<%# Eval("PRK_Status8_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApprovedValue" runat="server" Text="Claimed/Bill Amount [As per Entitlement] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Value"
            Text='<%# Bind("Value") %>'
            ToolTip="Value of Approved Value."
            Enabled = "False"
            Width="104px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ApprovedAmt" runat="server" Text="Approved Amt :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApprovedAmt"
            Text='<%# Bind("ApprovedAmt") %>'
            ToolTip="Value of Approved Amt."
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
          <asp:Label ID="L_ApproverRemark" runat="server" Text="Approver Remark :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ApproverRemark"
            Text='<%# Bind("ApproverRemark") %>'
            ToolTip="Value of Approver Remark."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VerifiedBy" runat="server" Text="Verified By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_VerifiedBy"
            Width="88px"
            Text='<%# Bind("VerifiedBy") %>'
            Enabled = "False"
            ToolTip="Value of Verified By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_VerifiedBy_Display"
            Text='<%# Eval("PRK_Employees3_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VerifiedOn" runat="server" Text="Verified On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VerifiedOn"
            Text='<%# Bind("VerifiedOn") %>'
            ToolTip="Value of Verified On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ApprovedBy" runat="server" Text="Approved By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApprovedBy"
            Width="88px"
            Text='<%# Bind("ApprovedBy") %>'
            Enabled = "False"
            ToolTip="Value of Approved By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ApprovedBy_Display"
            Text='<%# Eval("PRK_Employees2_EmployeeName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ApprovedOn" runat="server" Text="Approved On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ApprovedOn"
            Text='<%# Bind("ApprovedOn") %>'
            ToolTip="Value of Approved On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelnprkBillDetails" runat="server" Text="&nbsp;Enter Bill Details"></asp:Label>
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
        <asp:TemplateField HeaderText="BILL NO" SortExpression="BillNo">
          <ItemTemplate>
            <asp:Label ID="LabelBillNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("BillNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BILL DATE" SortExpression="BillDate">
          <ItemTemplate>
            <asp:Label ID="LabelBillDate" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("BillDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PARTICULARS" SortExpression="Particulars">
          <ItemTemplate>
            <asp:Label ID="LabelParticulars" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Particulars") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FROM DATE" SortExpression="FromDate">
          <ItemTemplate>
            <asp:Label ID="LabelFromDate" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("FromDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TO DATE" SortExpression="ToDate">
          <ItemTemplate>
            <asp:Label ID="LabelToDate" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("ToDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BILL AMT." SortExpression="Quantity">
          <ItemTemplate>
            <asp:Label ID="LabelQuantity" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Quantity") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CLAIMED AMT." SortExpression="Amount">
          <ItemTemplate>
            <asp:Label ID="LabelAmount" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Amount") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>--%>
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
  </td></tr>
<%--      <tr>
        <td>
          <div id="F_Upload" runat="server" style="margin:auto;padding:10px 10px 10px 10px;" class="file_upload">
            <table>
              <tr>
                <td colspan="4">
                  To upload BILL Details through MS-Excel, First Download the Template. Then Upload the updated Excel File.
                </td>
              </tr>
              <tr>
                <td><b>Step 1.</b>
                  <asp:Button ID="cmdDownload" CssClass="file_upload_button" Width="100px" Text="Download" runat="server" ToolTip="Click to download template file." CommandName="Download" CommandArgument='<%# Eval("PrimaryKey") %>' />
                </td>
                <td><b>Step 2.</b>
                  <input type="text" id="fileName" style="width: 185px" class="file_input_textbox" readonly="readonly">
                </td>
                <td>
                  <div class="file_input_div">
                    <input type="button" value="Search"  class="file_input_button" />
                    <asp:FileUpload ID="F_FileUpload" runat="server" Width="80px" class="file_input_hidden" onchange="document.getElementById('fileName').value = this.value;" ToolTip="Click to locate Excel file." />
                  </div>
                </td>
                <td>
                  <asp:Button ID="cmdFileUpload" CssClass="file_upload_button" OnClientClick="return this.style.display='none';true;" Text="Upload" runat="server" ToolTip="Click to upload & process template file." CommandName="Upload" CommandArgument="" />
                </td>
              </tr>
            </table>
          </div>

        </td>
      </tr>--%>
    </table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVnprkBillDetails" EventName="PageIndexChanged" />
    <asp:PostBackTrigger ControlID="cmdDownload" />
    <asp:PostBackTrigger ControlID="cmdUpload" />
    <asp:PostBackTrigger ControlID="cmdTemplate" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSnprkApplications"
  DataObjectTypeName = "SIS.NPRK.nprkApplications"
  SelectMethod = "nprkApplicationsGetByID"
  UpdateMethod="UZ_nprkApplicationsUpdate"
  DeleteMethod="UZ_nprkApplicationsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkApplications"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ClaimID" Name="ClaimID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ApplicationID" Name="ApplicationID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
