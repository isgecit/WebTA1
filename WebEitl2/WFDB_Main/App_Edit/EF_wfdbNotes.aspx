<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_wfdbNotes.aspx.vb" Inherits="EF_wfdbNotes" title="Edit: Notes" %>
<asp:Content ID="CPHwfdbNotes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelwfdbNotes" runat="server" Text="&nbsp;Edit: Notes"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLwfdbNotes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLwfdbNotes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "wfdbNotes"
    runat = "server" />
<asp:FormView ID="FVwfdbNotes"
  runat = "server"
  DataKeyNames = "IndexValue,NotesId"
  DataSourceID = "ODSwfdbNotes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IndexValue" runat="server" ForeColor="#CC6633" Text="IndexValue :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_IndexValue"
            Text='<%# Bind("IndexValue") %>'
            ToolTip="Value of IndexValue."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="350px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Title" runat="server" Text="Title :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Title"
            Text='<%# Bind("Title") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbNotes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Title."
            MaxLength="4000"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVTitle"
            runat = "server"
            ControlToValidate = "F_Title"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbNotes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Created_Date" runat="server" Text="Created_Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Created_Date"
            Text='<%# Bind("Created_Date") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbNotes"
            runat="server" />
          <asp:Image ID="ImageButtonCreated_Date" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CECreated_Date"
            TargetControlID="F_Created_Date"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonCreated_Date" />
          <AJX:MaskedEditExtender 
            ID = "MEECreated_Date"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Created_Date" />
          <AJX:MaskedEditValidator 
            ID = "MEVCreated_Date"
            runat = "server"
            ControlToValidate = "F_Created_Date"
            ControlExtender = "MEECreated_Date"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbNotes"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UserId" runat="server" Text="UserId :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_UserId"
            Text='<%# Bind("UserId") %>'
            Width="72px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="wfdbNotes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for UserId."
            MaxLength="8"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVUserId"
            runat = "server"
            ControlToValidate = "F_UserId"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "wfdbNotes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSwfdbNotes"
  DataObjectTypeName = "SIS.WFDB.wfdbNotes"
  SelectMethod = "UZ_wfdbNotesGetByID"
  UpdateMethod="UZ_wfdbNotesUpdate"
  DeleteMethod="UZ_wfdbNotesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.WFDB.wfdbNotes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="IndexValue" Name="IndexValue" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="NotesId" Name="NotesId" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
