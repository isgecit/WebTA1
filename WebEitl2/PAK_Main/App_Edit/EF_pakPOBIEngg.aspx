<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakPOBIEngg.aspx.vb" Inherits="EF_pakPOBIEngg" title="Edit: PO BOM Item [Engg]" %>
<asp:Content ID="CPHpakPOBItems" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakPOBItems" runat="server" Text="&nbsp;Edit: PO BOM Item [Engg]"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakPOBItems" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakPOBItems"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "pakPOBItems"
    runat = "server" />
<asp:FormView ID="FVpakPOBItems"
  runat = "server"
  DataKeyNames = "SerialNo,BOMNo,ItemNo"
  DataSourceID = "ODSpakPOBItems"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_SerialNo"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Serial No."
            Runat="Server" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("PAK_PO6_PODescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_BOMNo" runat="server" ForeColor="#CC6633" Text="BOM No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_BOMNo"
            Width="88px"
            Text='<%# Bind("BOMNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of BOM No."
            Runat="Server" />
          <asp:Label
            ID = "F_BOMNo_Display"
            Text='<%# Eval("PAK_POBOM8_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemNo" runat="server" ForeColor="#CC6633" Text="Item No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_ItemNo"
            Text='<%# Bind("ItemNo") %>'
            ToolTip="Value of Item No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ItemCode" runat="server" Text="Item Code :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ItemCode"
            Text='<%# Bind("ItemCode") %>'
            ToolTip="Item Code."
            Width="408px"
            CssClass = "mytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierItemCode" runat="server" Text="Supplier Item Code :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierItemCode"
            Text='<%# Bind("SupplierItemCode") %>'
            ToolTip="Supplier Item Code."
            Width="408px"
            CssClass = "mytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ItemDescription" runat="server" Text="Item Description :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ItemDescription"
            Text='<%# Bind("ItemDescription") %>'
            ToolTip="Item Description."
            Width="350px" 
            CssClass = "mytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ElementID" runat="server" Text="Element ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ElementID"
            Width="72px"
            Text='<%# Bind("ElementID") %>'
            ToolTip="Element ID."
            CssClass = "myfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ElementID_Display"
            Text='<%# Eval("PAK_Elements5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Freezed" runat="server" Text="Freezed :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Freezed"
            Checked='<%# Bind("Freezed") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="opt1" runat="server" clientIDMode="static">
        <td class="alignright">
          <asp:Label ID="L_UOMQuantity" runat="server" Text="UOM Quantity :" />&nbsp;
        </td>
        <td>
          <LGM:LC_pakUnits
            ID="F_UOMQuantity"
            SelectedValue='<%# Bind("UOMQuantity") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_Quantity" runat="server" Text="Quantity :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Quantity"
            Text='<%# Bind("Quantity") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEQuantity"
            runat = "server"
            mask = "9999999999999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Quantity" />
          <AJX:MaskedEditValidator 
            ID = "MEVQuantity"
            runat = "server"
            ControlToValidate = "F_Quantity"
            ControlExtender = "MEEQuantity"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr id="opt2" runat="server" clientIDMode="static">
        <td class="alignright">
          <asp:Label ID="L_UOMWeight" runat="server" Text="UOM Weight :" />&nbsp;
        </td>
        <td>
          <LGM:LC_pakUnits
            ID="F_UOMWeight"
            SelectedValue='<%# Bind("UOMWeight") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_WeightPerUnit" runat="server" Text="Weight Per Unit :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_WeightPerUnit"
            Text='<%# Bind("WeightPerUnit") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            MaxLength="20"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEWeightPerUnit"
            runat = "server"
            mask = "9999999999999999.9999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_WeightPerUnit" />
          <AJX:MaskedEditValidator 
            ID = "MEVWeightPerUnit"
            runat = "server"
            ControlToValidate = "F_WeightPerUnit"
            ControlExtender = "MEEWeightPerUnit"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpakPOBIDocuments" runat="server" Text="&nbsp;List: PO Item Documents"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakPOBIDocuments" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakPOBIDocuments"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakPOBIDocuments.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakPOBIDocuments.aspx?skip=1"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "pakPOBIDocuments"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakPOBIDocuments" runat="server" AssociatedUpdatePanelID="UPNLpakPOBIDocuments" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVpakPOBIDocuments" SkinID="gv_silver" runat="server" DataSourceID="ODSpakPOBIDocuments" DataKeyNames="SerialNo,BOMNo,ItemNo,DocNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Doc No" SortExpression="DocNo">
          <ItemTemplate>
            <asp:Label ID="LabelDocNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document ID" SortExpression="DocumentID">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document Revision" SortExpression="DocumentRevision">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentRevision" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentRevision") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Document Name" SortExpression="DocumentName">
          <ItemTemplate>
            <asp:Label ID="LabelDocumentName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DocumentName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="File Name" SortExpression="FileName">
          <ItemTemplate>
            <asp:Label ID="LabelFileName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSpakPOBIDocuments"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakPOBIDocuments"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_pakPOBIDocumentsSelectList"
      TypeName = "SIS.PAK.pakPOBIDocuments"
      SelectCountMethod = "pakPOBIDocumentsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ItemNo" PropertyName="Text" Name="ItemNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_BOMNo" PropertyName="Text" Name="BOMNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakPOBIDocuments" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakPOBItems"
  DataObjectTypeName = "SIS.PAK.pakPOBItems"
  SelectMethod = "pakPOBItemsGetByID"
  UpdateMethod="UZ_pakPOBIEnggUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakPOBItems"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="BOMNo" Name="BOMNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemNo" Name="ItemNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
