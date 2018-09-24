<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_taCategories.aspx.vb" Inherits="EF_taCategories" title="Edit: TA Categories" %>
<asp:Content ID="CPHtaCategories" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaCategories" runat="server" Text="&nbsp;Edit: TA Categories"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaCategories" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaCategories"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "taCategories"
    runat = "server" />
<asp:FormView ID="FVtaCategories"
  runat = "server"
  DataKeyNames = "CategoryID"
  DataSourceID = "ODStaCategories"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CategoryID" runat="server" ForeColor="#CC6633" Text="Category ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CategoryID"
            Text='<%# Bind("CategoryID") %>'
            ToolTip="Value of Category ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="70px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CategoryCode" runat="server" Text="Category Code :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_CategoryCode"
            Text='<%# Bind("CategoryCode") %>'
            Width="70px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taCategories"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Category Code."
            MaxLength="10"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCategoryCode"
            runat = "server"
            ControlToValidate = "F_CategoryCode"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCategories"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CategoryDescription" runat="server" Text="Category Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_CategoryDescription"
            Text='<%# Bind("CategoryDescription") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taCategories"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Category Description."
            MaxLength="100"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCategoryDescription"
            runat = "server"
            ControlToValidate = "F_CategoryDescription"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCategories"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CategorySequence" runat="server" Text="Category Sequence :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CategorySequence"
            Text='<%# Bind("CategorySequence") %>'
            style="text-align: right"
            Width="70px"
            CssClass = "mytxt"
            ValidationGroup="taCategories"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECategorySequence"
            runat = "server"
            mask = "9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_CategorySequence" />
          <AJX:MaskedEditValidator 
            ID = "MEVCategorySequence"
            runat = "server"
            ControlToValidate = "F_CategorySequence"
            ControlExtender = "MEECategorySequence"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "taCategories"
            IsValidEmpty = "false"
            MinimumValue = "1"
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
  ID = "ODStaCategories"
  DataObjectTypeName = "SIS.TA.taCategories"
  SelectMethod = "taCategoriesGetByID"
  UpdateMethod="UZ_taCategoriesUpdate"
  DeleteMethod="UZ_taCategoriesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taCategories"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="CategoryID" Name="CategoryID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
