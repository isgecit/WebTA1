<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_elogIRBLDetails.aspx.vb" Inherits="AF_elogIRBLDetails" title="Add: IR BL Charge Codes" %>
<asp:Content ID="CPHelogIRBLDetails" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelelogIRBLDetails" runat="server" Text="&nbsp;Add: IR BL Charge Codes"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLelogIRBLDetails" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLelogIRBLDetails"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "elogIRBLDetails"
    runat = "server" />
<asp:FormView ID="FVelogIRBLDetails"
  runat = "server"
  DataKeyNames = "IRNo,SerialNo"
  DataSourceID = "ODSelogIRBLDetails"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgelogIRBLDetails" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IRNo" ForeColor="#CC6633" runat="server" Text="IR No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_IRNo"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("IRNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for IR No."
            ValidationGroup = "elogIRBLDetails"
            onblur= "script_elogIRBLDetails.validate_IRNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_IRNo_Display"
            Text='<%# Eval("ELOG_IRBL6_SupplierBillNo") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="row1" runat="server" ClientIDMode="static">
        <td class="alignright">
          <asp:Label ID="L_StuffingTypeID" runat="server" Text="Stuffing Type :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_elogStuffingTypes
            ID="F_StuffingTypeID"
            SelectedValue='<%# Bind("StuffingTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "elogIRBLDetails"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr id="row2" runat="server" ClientIDMode="static">
        <td class="alignright">
          <asp:Label ID="L_StuffingPointID" runat="server" Text="Stuffing Point :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_elogStuffingPoints
            ID="F_StuffingPointID"
            SelectedValue='<%# Bind("StuffingPointID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "elogIRBLDetails"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr id="row3" runat="server" ClientIDMode="static">
        <td class="alignright">
          <asp:Label ID="L_ICDCFSID" runat="server" Text="ICD / CFS :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_elogICDCFSs
            ID="F_ICDCFSID"
            SelectedValue='<%# Bind("ICDCFSID") %>'
            OrderBy="1"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "elogIRBLDetails"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_OtherICDCFS" runat="server" Text="Other ICD / CFS Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_OtherICDCFS"
            Text='<%# Bind("OtherICDCFS") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Other ICD / CFS Name."
            MaxLength="100"
            Width="350px" 
            runat="server" />
        </td>
      </tr>
      <tr id="row4" runat="server" ClientIDMode="static">
        <td class="alignright">
          <asp:Label ID="L_BreakBulkID" runat="server" Text="Break Bulk :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_elogBreakbulkTypes
            ID="F_BreakBulkID"
            SelectedValue='<%# Bind("BreakBulkID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "elogIRBLDetails"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr id="row5" runat="server" ClientIDMode="static">
        <td class="alignright">
          <asp:Label ID="L_ChargeTypeID" runat="server" Text="Charge Type :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_elogChargeTypes
            ID="F_ChargeTypeID"
            SelectedValue='<%# Bind("ChargeTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "elogIRBLDetails"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr id="row6" runat="server" ClientIDMode="static">
        <td class="alignright">
          <asp:Label ID="L_ChargeCategoryID" runat="server" Text="Charge Category :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_elogChargeCategories
            ID="F_ChargeCategoryID"
            SelectedValue='<%# Bind("ChargeCategoryID") %>'
            OrderBy="1||||||"
            SelectMethod="LG_elogChargeCategoriesSelectList"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "elogIRBLDetails"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr id="row7" runat="server" ClientIDMode="static">
        <td class="alignright">
          <asp:Label ID="L_ChargeCodeID" runat="server" Text="Charge Code :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_elogChargeCodes
            ID="F_ChargeCodeID"
            SelectedValue='<%# Bind("ChargeCodeID") %>'
            OrderBy="1"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "elogIRBLDetails"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr id="row8" runat="server" ClientIDMode="static">
        <td class="alignright">
          <asp:Label ID="L_Amount" runat="server" Text="Amount :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Amount"
            Text='<%# Bind("Amount") %>'
            Width="168px"
            CssClass = "mytxt"
            style="text-align: Right"
            ValidationGroup="elogIRBLDetails"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEAmount"
            runat = "server"
            mask = "999999999999999999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Amount" />
          <AJX:MaskedEditValidator 
            ID = "MEVAmount"
            runat = "server"
            ControlToValidate = "F_Amount"
            ControlExtender = "MEEAmount"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "elogIRBLDetails"
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="500"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td></td>
        <td style="text-align:center">
          <asp:Button ID="cmdNext" runat="server" BackColor="lime" Text="Next" CommandName="lgNext" />
        </td>
        <td  style="text-align:center">
          <asp:Button ID="cmdBack" runat="server" BackColor="Yellow" Text="Back" CommandName="lgBack" />
        </td>
        <td>
          <asp:HiddenField ID="state" ClientIDMode="Static" runat="server" Value="1" />
          <asp:HiddenField ID="startRow" runat="server" Value="1" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSelogIRBLDetails"
  DataObjectTypeName = "SIS.ELOG.elogIRBLDetails"
  InsertMethod="UZ_elogIRBLDetailsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.ELOG.elogIRBLDetails"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
