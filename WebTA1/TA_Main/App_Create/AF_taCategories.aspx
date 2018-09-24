<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taCategories.aspx.vb" Inherits="AF_taCategories" title="Add: TA Categories" %>
<asp:Content ID="CPHtaCategories" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaCategories" runat="server" Text="&nbsp;Add: TA Categories"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaCategories" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLtaCategories"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "taCategories"
    runat = "server" />
<asp:FormView ID="FVtaCategories"
  runat = "server"
  DataKeyNames = "CategoryID"
  DataSourceID = "ODStaCategories"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgtaCategories" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CategoryID" ForeColor="#CC6633" runat="server" Text="Category ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CategoryID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CategoryCode" runat="server" Text="Category Code :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_CategoryCode"
            Text='<%# Bind("CategoryCode") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taCategories"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Category Code."
            MaxLength="10"
            Width="70px"
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
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="taCategories"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Category Description."
            MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CategorySequence" runat="server" Text="Category Sequence :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CategorySequence"
            Text='<%# Bind("CategorySequence") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            ValidationGroup="taCategories"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEECategorySequence"
            runat = "server"
            mask = "999"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODStaCategories"
  DataObjectTypeName = "SIS.TA.taCategories"
  InsertMethod="UZ_taCategoriesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.TA.taCategories"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
