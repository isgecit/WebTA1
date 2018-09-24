<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakQCPO.aspx.vb" Inherits="EF_pakQCPO" title="Edit: Create Quality Clearance List & Offer For Clearance" %>
<asp:Content ID="CPHpakQCPO" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakQCPO" runat="server" Text="&nbsp;Edit: Create Quality Clearance List & Offer For Clearance"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakQCPO" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakQCPO"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "pakQCPO"
    runat = "server" />
<asp:FormView ID="FVpakQCPO"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODSpakQCPO"
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
        <td colspan="3">
          <asp:TextBox ID="F_PODescription"
            Text='<%# Bind("PODescription") %>'
            ToolTip="Value of PO Description."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
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
      <tr>
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
      <td></td><td></td></tr>
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
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpakQCListH" runat="server" Text="&nbsp;List: Quality Clearance"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakQCListH" runat="server">
  <ContentTemplate>
    <table>
      <tr>
        <td>
          <asp:Label runat="server" Font-Bold="true" ForeColor="BlueViolet" style="margin: 10px 10px auto 10px" Text="Upload Quality Clearance List template file." ></asp:Label>
        </td>
      </tr>
      <tr>
        <td style="text-align:center">
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
              <asp:HiddenField ID="IsUploaded" runat="server" ClientIDMode="Static" ></asp:HiddenField>
              <asp:FileUpload ID="F_FileUpload" runat="server" Width="250px" ToolTip="Browse QC List Template" />
              <asp:Button ID="cmdTmplUpload" Text="Upload" OnClientClick="$get('IsUploaded').value='YES';" runat="server" ToolTip="Click to upload & process template file." CommandName="tmplUpload" CommandArgument='<%# Eval("PrimaryKey") %>' />
            </ContentTemplate>
            <Triggers>
              <asp:PostBackTrigger ControlID="cmdTmplUpload" />
            </Triggers>
          </asp:UpdatePanel>
        </td>
      </tr>
    </table>
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Edit/EF_','App_Print/RP_');
        url = url + '&pkg=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=110,height=60,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakQCListH"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakQCListH.aspx"
      AddUrl = "~/PAK_Main/App_Edit/EF_pakQCPO.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "pakQCListH"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakQCListH" runat="server" AssociatedUpdatePanelID="UPNLpakQCListH" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpakQCListH" SkinID="gv_silver" runat="server" DataSourceID="ODSpakQCListH" DataKeyNames="SerialNo,QCLNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
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
        <asp:TemplateField HeaderText="PRINT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick='<%# Eval("GetPrintLink") %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="QC List No" SortExpression="QCLNo">
          <ItemTemplate>
            <asp:Label ID="LabelQCLNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("QCLNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="SupplierRef">
          <ItemTemplate>
            <asp:Label ID="LabelSupplierRef" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierRef") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Offered Weight" SortExpression="TotalWeight">
          <ItemTemplate>
            <asp:Label ID="LabelTotalWeight" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TotalWeight") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM" SortExpression="PAK_Units4_Description">
          <ItemTemplate>
             <asp:Label ID="L_UOMTotalWeight" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOMTotalWeight") %>' Text='<%# Eval("PAK_Units4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Manual Request No">
          <ItemTemplate>
            <LGM:LC_qcmSRequests 
              ID="F_QCRequestNo"
              SelectedValue='<%# Bind("QCRequestNo") %>'
              OrderBy='<%# Eval("FK_PAK_QCListH_SerialNo.SupplierID") %>'
              DataTextField="DisplayField"
              DataValueField="PrimaryKey"
              IncludeDefault="true"
              DefaultText="-- Select --"
              Width="100px"
              CssClass="myddl"
              Runat="Server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="PAK_QCListStatus3_Description">
          <ItemTemplate>
             <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("PAK_QCListStatus3_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cleared By" SortExpression="aspnet_users5_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_ClearedBy" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("ClearedBy") %>' Text='<%# Eval("aspnet_users5_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cleared On" SortExpression="ClearedOn">
          <ItemTemplate>
            <asp:Label ID="LabelClearedOn" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("ClearedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Submit For Q.C.">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Submit for Quality Clearance ?" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Submit for Quality Clearance ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Convert to Pkg.List">
          <ItemTemplate>
            <asp:ImageButton ID="cmdConvertWF" ValidationGroup='<%# "Convert" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ConvertWFVisible") %>' Enabled='<%# EVal("ConvertWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Create Packing List From Cleared Quantity" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Convert" & Container.DataItemIndex & """) && confirm(""Create Packing List From Cleared Quantities ?"");" %>' CommandName="ConvertWF" CommandArgument='<%# Container.DataItemIndex %>' />
            <asp:Linkbutton ID="LabelPkgNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("PkgNo") %>' PostBackUrl='<%# EVal("GetPkgLink") %>' Width="50px" BackColor="Lime"  ></asp:Linkbutton>
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
      ID = "ODSpakQCListH"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakQCListH"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakQCListHSelectList"
      TypeName = "SIS.PAK.pakQCListH"
      SelectCountMethod = "pakQCListHSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVpakQCListH" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakQCPO"
  DataObjectTypeName = "SIS.PAK.pakQCPO"
  SelectMethod = "pakQCPOGetByID"
  UpdateMethod="UZ_pakQCPOUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakQCPO"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
