<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_nprkPerks.aspx.vb" Inherits="EF_nprkPerks" title="Edit: Perk Heads" %>
<asp:Content ID="CPHnprkPerks" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkPerks" runat="server" Text="&nbsp;Edit: Perk Heads"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkPerks" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLnprkPerks"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "nprkPerks"
    runat = "server" />
<asp:FormView ID="FVnprkPerks"
  runat = "server"
  DataKeyNames = "PerkID"
  DataSourceID = "ODSnprkPerks"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PerkID" runat="server" ForeColor="#CC6633" Text="Perk ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PerkID"
            Text='<%# Bind("PerkID") %>'
            ToolTip="Value of Perk ID."
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
          <asp:Label ID="L_PerkCode" runat="server" Text="Perk Code :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_PerkCode"
            Text='<%# Bind("PerkCode") %>'
            Width="32px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="nprkPerks"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Perk Code."
            MaxLength="3"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVPerkCode"
            runat = "server"
            ControlToValidate = "F_PerkCode"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkPerks"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="nprkPerks"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkPerks"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AdvanceApplicable" runat="server" Text="Advance Applicable :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_AdvanceApplicable"
            Checked='<%# Bind("AdvanceApplicable") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_AdvanceMonths" runat="server" Text="Advance Months :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AdvanceMonths"
            Text='<%# Bind("AdvanceMonths") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEAdvanceMonths"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_AdvanceMonths" />
          <AJX:MaskedEditValidator 
            ID = "MEVAdvanceMonths"
            runat = "server"
            ControlToValidate = "F_AdvanceMonths"
            ControlExtender = "MEEAdvanceMonths"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_LockedMonths" runat="server" Text="Locked Months :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_LockedMonths"
            Text='<%# Bind("LockedMonths") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEELockedMonths"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_LockedMonths" />
          <AJX:MaskedEditValidator 
            ID = "MEVLockedMonths"
            runat = "server"
            ControlToValidate = "F_LockedMonths"
            ControlExtender = "MEELockedMonths"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_NoOfPayments" runat="server" Text="No Of Payments :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_NoOfPayments"
            Text='<%# Bind("NoOfPayments") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEENoOfPayments"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_NoOfPayments" />
          <AJX:MaskedEditValidator 
            ID = "MEVNoOfPayments"
            runat = "server"
            ControlToValidate = "F_NoOfPayments"
            ControlExtender = "MEENoOfPayments"
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
          <asp:Label ID="L_CarryForward" runat="server" Text="Carry Forward :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_CarryForward"
            Checked='<%# Bind("CarryForward") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_UOM" runat="server" Text="UOM :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:DropDownList
            ID="F_UOM"
            SelectedValue='<%# Bind("UOM") %>'
            CssClass = "myddl"
            Width="200px"
            ValidationGroup = "nprkPerks"
            Runat="Server" >
            <asp:ListItem Value="Rs.">Rs.</asp:ListItem>
            <asp:ListItem Value="Ltr.">Ltr.</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVUOM"
            runat = "server"
            ControlToValidate = "F_UOM"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "nprkPerks"
            SetFocusOnError="true" />
         </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Active" runat="server" Text="Active :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_Active"
            Checked='<%# Bind("Active") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BaaNGL" runat="server" Text="BaaN GL :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_BaaNGL"
            Text='<%# Bind("BaaNGL") %>'
            Width="64px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BaaN GL."
            MaxLength="7"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BaaNReference" runat="server" Text="BaaN Reference :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_BaaNReference"
            Text='<%# Bind("BaaNReference") %>'
            Width="248px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BaaN Reference."
            MaxLength="30"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreditGLForCheque" runat="server" Text="Credit GL For Cheque :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreditGLForCheque"
            Text='<%# Bind("CreditGLForCheque") %>'
            Width="64px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Credit GL For Cheque."
            MaxLength="7"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CreditGLForCash24" runat="server" Text="Credit GL For Cash 24 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreditGLForCash24"
            Text='<%# Bind("CreditGLForCash24") %>'
            Width="64px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Credit GL For Cash 24."
            MaxLength="7"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreditGLForImprest" runat="server" Text="Credit GL For Imprest :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreditGLForImprest"
            Text='<%# Bind("CreditGLForImprest") %>'
            Width="64px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Credit GL For Imprest."
            MaxLength="7"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CreditGLForCash63" runat="server" Text="Credit GL For Cash 63 :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreditGLForCash63"
            Text='<%# Bind("CreditGLForCash63") %>'
            Width="64px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Credit GL For Cash 63."
            MaxLength="7"
            runat="server" />
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
  ID = "ODSnprkPerks"
  DataObjectTypeName = "SIS.NPRK.nprkPerks"
  SelectMethod = "nprkPerksGetByID"
  UpdateMethod="nprkPerksUpdate"
  DeleteMethod="nprkPerksDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.NPRK.nprkPerks"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="PerkID" Name="PerkID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
