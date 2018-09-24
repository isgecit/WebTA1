<%@ Page Language="VB" MasterPageFile="~/PlaneMaster.master" AutoEventWireup="false" CodeFile="ediWSTmtlH.aspx.vb" Inherits="EF_ediWSTmtlH" title="Download Transmittal Document" %>
<asp:Content ID="CPHediWTmtlH" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelediWTmtlH" runat="server" Text="&nbsp;DOWNLOAD ISGEC COMMENTS"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLediWTmtlH" runat="server" >
<ContentTemplate>
<asp:FormView ID="FVediWTmtlH"
  runat = "server"
  DataKeyNames = "t_tran"
  DataSourceID = "ODSediWTmtlH"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_t_tran" runat="server" ForeColor="#CC6633" Text="Transmittal No. :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_t_tran"
            Text='<%# Bind("t_tran") %>'
            ToolTip="Value of Transmittal No.."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="80px"
            runat="server" />
          <asp:Button ID="cmdPrint" runat="server" Text="Print" OnClientClick='<%# Eval("GetPrintLink") %>' />
        </td>
        <td class="alignright">
          <asp:Label ID="L_t_refr" runat="server" Text="Reference No. :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_t_refr"
            Text='<%# Bind("t_refr") %>'
            ToolTip="Value of Reference No.."
            Enabled = "False"
            Width="264px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
    </table>
  </div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLediWTmtlD" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
      <table style="width:98%">
        <tr>
          <td style="text-align:right;">
            <asp:Label ID="L_TotalFiles" runat="server" Text="Total Files:" Font-Bold="true" Font-Size="14px" />
          </td>
          <td style="text-align:right;">
            <asp:Label ID="L_selectedFiles" runat="server" Text="Selected Files:" Font-Bold="true" Font-Size="14px" />
          </td>
          <td style="text-align:right;">
            <asp:Button ID="cmdDownloadSelected" runat="server" Text="Download Selected [.zip]" Enabled="false" ToolTip="Click to download Selected in ZIP format." OnClientClick='<%# Eval("GetSDownloadAllLink") %>' />
          </td>
          <td style="text-align:right;">
            <asp:Button ID="cmdDownloadAll" runat="server" Text="Download All [.zip]" ToolTip="Click to download All in ZIP format." OnClientClick='<%# Eval("GetSDownloadAllLink") %>' />
          </td>
        </tr>
      </table>
    <LGM:ToolBar0 
      ID = "TBLediWTmtlD"
      ToolType = "lgNMGrid"
      EditUrl = ""
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "ediWTmtlD"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSediWTmtlD" runat="server" AssociatedUpdatePanelID="UPNLediWTmtlD" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVediWTmtlD" SkinID="gv_silver" runat="server" DataSourceID="ODSediWTmtlD" DataKeyNames="t_tran,t_docn,t_revn">
      <Columns>
        <asp:TemplateField HeaderText="Document ID" SortExpression="t_docn">
          <ItemTemplate>
            <asp:Label ID="Labelt_docn" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("t_docn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Revision No." SortExpression="t_revn">
          <ItemTemplate>
            <asp:Label ID="Labelt_revn" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("t_revn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Send Status" SortExpression="t_stid">
          <ItemTemplate>
            <asp:Label ID="Labelt_stid" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("t_stid") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks" SortExpression="t_remk">
          <ItemTemplate>
            <asp:Label ID="Labelt_remk" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("t_remk") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Download">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDownload" runat="server" ToolTip="Download" SkinID="Download" OnClientClick='<%# Eval("GetSDownloadLink") %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SELECT">
          <ItemTemplate>
            <asp:CheckBox ID="chkSelect" runat="server" ToolTip="Click to select" CssClass="mychk" Checked='<%# Eval("Selected") %>' />
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
      ID = "ODSediWTmtlD"
      runat = "server"
      DataObjectTypeName = "SIS.EDI.ediWTmtlD"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_ediWTmtlDSelectList"
      TypeName = "SIS.EDI.ediWTmtlD"
      SelectCountMethod = "ediWTmtlDSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_t_tran" PropertyName="Text" Name="t_tran" Type="String" Size="9" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVediWTmtlD" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSediWTmtlH"
  DataObjectTypeName = "SIS.EDI.ediWTmtlH"
  SelectMethod = "ediWTmtlHGetByID"
  UpdateMethod=""
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.EDI.ediWTmtlH"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="s_tran" Name="t_tran" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
