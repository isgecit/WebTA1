<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakSPO.aspx.vb" Inherits="EF_pakSPO" title="Edit: Verify PO" %>
<asp:Content ID="CPHpakSPO" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSPO" runat="server" Text="&nbsp;Edit: Verify PO"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSPO" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSPO"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "pakSPO"
    runat = "server" />
<asp:FormView ID="FVpakSPO"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODSpakSPO"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo"
            Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
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
          <asp:Label ID="L_PONumber" runat="server" Text="PO Number :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PONumber"
            Text='<%# Bind("PONumber") %>'
            ToolTip="Value of PO Number."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PORevision" runat="server" Text="PO Revision :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PORevision"
            Text='<%# Bind("PORevision") %>'
            ToolTip="Value of PO Revision."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PODate" runat="server" Text="PO Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PODate"
            Text='<%# Bind("PODate") %>'
            ToolTip="Value of PO Date."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_POStatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_POStatusID"
            Width="88px"
            Text='<%# Bind("POStatusID") %>'
            Enabled = "False"
            ToolTip="Value of Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_POStatusID_Display"
            Text='<%# Eval("PAK_POStatus6_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PODescription" runat="server" Text="PO Description :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PODescription"
            Text='<%# Bind("PODescription") %>'
            ToolTip="Value of PO Description."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BuyerID" runat="server" Text="Buyer :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_BuyerID"
            Width="72px"
            Text='<%# Bind("BuyerID") %>'
            Enabled = "False"
            ToolTip="Value of Buyer."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_BuyerID_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierID" runat="server" Text="Supplier :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SupplierID"
            Width="80px"
            Text='<%# Bind("SupplierID") %>'
            Enabled = "False"
            ToolTip="Value of Supplier."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_SupplierID_Display"
            Text='<%# Eval("VR_BusinessPartner9_BPName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="Project :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            Enabled = "False"
            ToolTip="Value of Project."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ClosedBy" runat="server" Text="Closed By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ClosedBy"
            Width="72px"
            Text='<%# Bind("ClosedBy") %>'
            Enabled = "False"
            ToolTip="Value of Closed By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ClosedBy_Display"
            Text='<%# Eval("aspnet_users3_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ClosedOn" runat="server" Text="Closed On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ClosedOn"
            Text='<%# Bind("ClosedOn") %>'
            ToolTip="Value of Closed On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_POOtherDetails" runat="server" Text="PO Other Details :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_POOtherDetails"
            Text='<%# Bind("POOtherDetails") %>'
            ToolTip="Value of PO Other Details."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_POConsignee" runat="server" Text="PO Consignee :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_POConsignee"
            Text='<%# Bind("POConsignee") %>'
            ToolTip="Value of PO Consignee."
            Enabled = "False"
            Width="350px" 
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IssueReasonID" runat="server" Text="Reason For Creation :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_IssueReasonID"
            Width="88px"
            Text='<%# Bind("IssueReasonID") %>'
            Enabled = "False"
            ToolTip="Value of Reason For Creation."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_IssueReasonID_Display"
            Text='<%# Eval("PAK_Reasons8_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_POTypeID" runat="server" Text="PO Type :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_POTypeID"
            Width="88px"
            Text='<%# Bind("POTypeID") %>'
            Enabled = "False"
            ToolTip="Value of PO Type."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_POTypeID_Display"
            Text='<%# Eval("PAK_POTypes7_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ISGECRemarks" runat="server" Text="ISGEC Remarks :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ISGECRemarks"
            Text='<%# Bind("ISGECRemarks") %>'
            ToolTip="Value of ISGEC Remarks."
            Enabled = "False"
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SupplierRemarks" runat="server" Text="Supplier Remarks :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierRemarks"
            Text='<%# Bind("SupplierRemarks") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Supplier Remarks."
            MaxLength="500"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpakSPOBOM" runat="server" Text="&nbsp;List: S-PO Item"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakSPOBOM" runat="server">
  <ContentTemplate>
    <table width="100%">
      <tr>
        <td>
          <div id="F_Upload" runat="server" style="width:auto; margin: 10px 10px 10px 10px; padding: 10px 10px 10px 10px" class="file_upload" visible='<%# Editable %>'>
            <table>
              <tr>
                <td colspan="4">
                  <asp:Label ID="errMsg" runat="server" Font-Bold="true" ForeColor="Red" Text=""></asp:Label>
                </td>
              </tr>
              <tr>
                <td><b>Upload Template</b></td>
                <td>
                </td>
                <td>
                  <asp:FileUpload ID="F_FileUpload" runat="server" Width="180px"  ToolTip="Upload Item Template" />
                </td>
                <td>
                  <asp:Button ID="cmdFileUpload" OnClientClick="return this.style.display='none';true;" Text="Upload" runat="server" ToolTip="Click to upload & process template file." CommandName="Upload" CommandArgument="" />
                </td>
              </tr>
            </table>
          </div>

        </td>
      </tr>
      <tr>
        <td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakSPOBOM"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakSPOBOM.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "pakSPOBOM"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakSPOBOM" runat="server" AssociatedUpdatePanelID="UPNLpakSPOBOM" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Edit/EF_pakS','App_Print/RP_pak');
        url = url + '&pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVpakSPOBOM" SkinID="gv_silver" runat="server" DataSourceID="ODSpakSPOBOM" DataKeyNames="SerialNo,BOMNo">
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
        <asp:TemplateField HeaderText="Get XL">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDownload" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Download Template File." SkinID="download" OnClientClick='<%# Eval("GetDownloadLink") %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BOM No" SortExpression="BOMNo">
          <ItemTemplate>
            <asp:Label ID="LabelBOMNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BOMNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item No" SortExpression="ItemNo">
          <ItemTemplate>
            <asp:Label ID="LabelItemNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="60px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Description" SortExpression="ItemDescription">
          <ItemTemplate>
            <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle  HorizontalAlign="Left" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Element" SortExpression="PAK_Elements5_Description">
          <ItemTemplate>
             <asp:Label ID="L_ElementID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ElementID") %>' Text='<%# Eval("PAK_Elements5_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle HorizontalAlign="Left" Width="100px" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="Status" SortExpression="PAK_POBOMStatus7_Description">
          <ItemTemplate>
             <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("PAK_POBOMStatus7_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="ISGEC Remarks" SortExpression="ISGECRemarks">
          <ItemTemplate>
            <asp:Label ID="LabelISGECRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ISGECRemarks") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle  HorizontalAlign="Left" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier Remarks" SortExpression="SupplierRemarks">
          <ItemTemplate>
            <asp:Label ID="LabelSupplierRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierRemarks") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle HorizontalAlign="Left" Width="100px" />
        </asp:TemplateField>
<%--        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>--%>
<%--        <asp:TemplateField HeaderText="VERIFY">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Set state of all child Items as VERIFIED" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Set state of all child Items as VERIFIED ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CHANGE">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Set state of all child Items as CHANGE REQUIRED" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Set state of all child Items as CHANGE REQUIRED ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>--%>
<%--        <asp:TemplateField HeaderText="Complete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' Enabled='<%# EVal("CompleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Complete" SkinID="complete" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && confirm(""Complete record ?"");" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSpakSPOBOM"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakSPOBOM"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_pakSPOBOMSelectList"
      TypeName = "SIS.PAK.pakSPOBOM"
      SelectCountMethod = "pakSPOBOMSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakSPOBOM" EventName="PageIndexChanged" />
    <asp:PostBackTrigger ControlID="cmdFileUpload" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakSPO"
  DataObjectTypeName = "SIS.PAK.pakSPO"
  SelectMethod = "pakSPOGetByID"
  UpdateMethod="UZ_pakSPOUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSPO"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
