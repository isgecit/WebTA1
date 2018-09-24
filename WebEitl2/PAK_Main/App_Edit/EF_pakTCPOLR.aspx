<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakTCPOLR.aspx.vb" Inherits="EF_pakTCPOLR" title="Edit: Submitted for TC" %>
<asp:Content ID="CPHpakTCPOLR" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakTCPOLR" runat="server" Text="&nbsp;Edit: Submitted for TC"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakTCPOLR" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakTCPOLR"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "pakTCPOLR"
    runat = "server" />
<asp:FormView ID="FVpakTCPOLR"
  runat = "server"
  DataKeyNames = "SerialNo,ItemNo,UploadNo"
  DataSourceID = "ODSpakTCPOLR"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_SerialNo"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            Enabled = "False"
            ToolTip="Value of Serial No."
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("PAK_PO2_PODescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemNo" runat="server" ForeColor="#CC6633" Text="Item No :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ItemNo"
            Width="88px"
            Text='<%# Bind("ItemNo") %>'
            Enabled = "False"
            ToolTip="Value of Item No."
            CssClass = "dmypktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ItemNo_Display"
            Text='<%# Eval("PAK_POLine3_ItemCode") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_UploadNo" runat="server" ForeColor="#CC6633" Text="Upload No :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_UploadNo"
            Text='<%# Bind("UploadNo") %>'
            ToolTip="Value of Upload No."
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
          <asp:Label ID="L_DocumentCategoryID" runat="server" Text="Document Category :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_DocumentCategoryID"
            Width="88px"
            Text='<%# Bind("DocumentCategoryID") %>'
            Enabled = "False"
            ToolTip="Value of Document Category."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_DocumentCategoryID_Display"
            Text='<%# Eval("PAK_POLineRecCategory4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UploadRemarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_UploadRemarks"
            Text='<%# Bind("UploadRemarks") %>'
            ToolTip="Value of Remarks."
            Enabled = "False"
            Width="350px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedBy" runat="server" Text="Submitted By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            Width="72px"
            Text='<%# Bind("CreatedBy") %>'
            Enabled = "False"
            ToolTip="Value of Submitted By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CreatedOn" runat="server" Text="Submitted On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreatedOn"
            Text='<%# Bind("CreatedOn") %>'
            ToolTip="Value of Submitted On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UploadStatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_UploadStatusID"
            Width="88px"
            Text='<%# Bind("UploadStatusID") %>'
            Enabled = "False"
            ToolTip="Value of Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_UploadStatusID_Display"
            Text='<%# Eval("PAK_POLineRecStatus5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ReceiptNo" runat="server" Text="ERP Receipt No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ReceiptNo"
            Text='<%# Bind("ReceiptNo") %>'
            ToolTip="Value of ERP Receipt No."
            Enabled = "False"
            Width="80px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_RevisionNo" runat="server" Text="ERP Rev. No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_RevisionNo"
            Text='<%# Bind("RevisionNo") %>'
            ToolTip="Value of ERP Rev. No."
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
    <asp:Label ID="LabelpakTCPOLRD" runat="server" Text="&nbsp;List: Documents"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakTCPOLRD" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakTCPOLRD"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakTCPOLRD.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "pakTCPOLRD"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakTCPOLRD" runat="server" AssociatedUpdatePanelID="UPNLpakTCPOLRD" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpakTCPOLRD" SkinID="gv_silver" runat="server" DataSourceID="ODSpakTCPOLRD" DataKeyNames="SerialNo,ItemNo,UploadNo,DocSerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Open Attachment">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDownload" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Download Template File." SkinID="download" OnClientClick='<%# Eval("GetDownloadLink") %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document" SortExpression="DocSerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelDocSerialNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("DocSerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ID" SortExpression="DocumentID">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Rev." SortExpression="DocumentRev">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentRev" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentRev") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="DocumentDescription">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ERP Receipt" SortExpression="ReceiptNo">
          <ItemTemplate>
            <asp:Label ID="LabelReceiptNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ReceiptNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="60px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ERP Rev" SortExpression="RevisionNo">
          <ItemTemplate>
            <asp:Label ID="LabelRevisionNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RevisionNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="File Name" SortExpression="FileName">
          <ItemTemplate>
            <asp:Label ID="LabelFileName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="200px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakTCPOLRD"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakTCPOLRD"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "pakTCPOLRDSelectList"
      TypeName = "SIS.PAK.pakTCPOLRD"
      SelectCountMethod = "pakTCPOLRDSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_UploadNo" PropertyName="Text" Name="UploadNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ItemNo" PropertyName="Text" Name="ItemNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakTCPOLRD" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakTCPOLR"
  DataObjectTypeName = "SIS.PAK.pakTCPOLR"
  SelectMethod = "pakTCPOLRGetByID"
  UpdateMethod="pakTCPOLRUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakTCPOLR"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemNo" Name="ItemNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="UploadNo" Name="UploadNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
