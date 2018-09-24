<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_costGLGroupGLs.aspx.vb" Inherits="EF_costGLGroupGLs" title="Edit: GL Group GLs" %>
<asp:Content ID="CPHcostGLGroupGLs" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcostGLGroupGLs" runat="server" Text="&nbsp;Edit: GL Group GLs"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcostGLGroupGLs" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcostGLGroupGLs"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "costGLGroupGLs"
    runat = "server" />
<asp:FormView ID="FVcostGLGroupGLs"
  runat = "server"
  DataKeyNames = "GLGroupID,GLCode"
  DataSourceID = "ODScostGLGroupGLs"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GLGroupID" runat="server" ForeColor="#CC6633" Text="GL Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_GLGroupID"
            Width="88px"
            Text='<%# Bind("GLGroupID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of GL Group ID."
            Runat="Server" />
          <asp:Label
            ID = "F_GLGroupID_Display"
            Text='<%# Eval("COST_GLGroups1_GLGroupDescriptions") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GLCode" runat="server" ForeColor="#CC6633" Text="GL Code [ERP] :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_GLCode"
            Width="88px"
            Text='<%# Bind("GLCode") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of GL Code [ERP]."
            Runat="Server" />
          <asp:Label
            ID = "F_GLCode_Display"
            Text='<%# Eval("COST_ERPGLCodes2_GLDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_EffectiveStartDate" runat="server" Text="Effective Start Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_EffectiveStartDate"
            Text='<%# Bind("EffectiveStartDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costGLGroupGLs"
            runat="server" />
          <asp:Image ID="ImageButtonEffectiveStartDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEEffectiveStartDate"
            TargetControlID="F_EffectiveStartDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonEffectiveStartDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEEffectiveStartDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_EffectiveStartDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVEffectiveStartDate"
            runat = "server"
            ControlToValidate = "F_EffectiveStartDate"
            ControlExtender = "MEEEffectiveStartDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costGLGroupGLs"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_EffectiveEndDate" runat="server" Text="Effective End Date :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_EffectiveEndDate"
            Text='<%# Bind("EffectiveEndDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="costGLGroupGLs"
            runat="server" />
          <asp:Image ID="ImageButtonEffectiveEndDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEEffectiveEndDate"
            TargetControlID="F_EffectiveEndDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonEffectiveEndDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEEffectiveEndDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_EffectiveEndDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVEffectiveEndDate"
            runat = "server"
            ControlToValidate = "F_EffectiveEndDate"
            ControlExtender = "MEEEffectiveEndDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "costGLGroupGLs"
            IsValidEmpty = "false"
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
  ID = "ODScostGLGroupGLs"
  DataObjectTypeName = "SIS.COST.costGLGroupGLs"
  SelectMethod = "costGLGroupGLsGetByID"
  UpdateMethod="costGLGroupGLsUpdate"
  DeleteMethod="costGLGroupGLsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.COST.costGLGroupGLs"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="GLGroupID" Name="GLGroupID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="GLCode" Name="GLCode" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
