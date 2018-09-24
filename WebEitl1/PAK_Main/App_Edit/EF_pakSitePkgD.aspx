<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_pakSitePkgD.aspx.vb" Inherits="EF_pakSitePkgD" title="Edit: Received Packing List Item" %>
<asp:Content ID="CPHpakSitePkgD" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelpakSitePkgD" runat="server" Text="&nbsp;Edit: Received Packing List Item"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLpakSitePkgD" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLpakSitePkgD"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "pakSitePkgD"
    runat = "server" />
<asp:FormView ID="FVpakSitePkgD"
  runat = "server"
  DataKeyNames = "ProjectID,RecNo,RecSrNo"
  DataSourceID = "ODSpakSitePkgD"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project."
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_RecNo" runat="server" ForeColor="#CC6633" Text="Receipt No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_RecNo"
            Width="88px"
            Text='<%# Bind("RecNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Receipt No."
            Runat="Server" />
          <asp:Label
            ID = "F_RecNo_Display"
            Text='<%# Eval("PAK_SitePkgH10_SupplierRefNo") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_RecSrNo" runat="server" ForeColor="#CC6633" Text="Receipt Line No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_RecSrNo"
            Text='<%# Bind("RecSrNo") %>'
            ToolTip="Value of Receipt Line No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SerialNo" runat="server" Text="Serial No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SerialNo"
            Width="88px"
            Text='<%# Bind("SerialNo") %>'
            Enabled = "False"
            ToolTip="Value of Serial No."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text='<%# Eval("PAK_PO8_PODescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PkgNo" runat="server" Text="Packing List No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_PkgNo"
            Width="88px"
            Text='<%# Bind("PkgNo") %>'
            Enabled = "False"
            ToolTip="Value of Packing List No."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_PkgNo_Display"
            Text='<%# Eval("PAK_PkgListH7_SupplierRefNo") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BOMNo" runat="server" Text="BOM No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_BOMNo"
            Width="88px"
            Text='<%# Bind("BOMNo") %>'
            Enabled = "False"
            ToolTip="Value of BOM No."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_BOMNo_Display"
            Text='<%# Eval("PAK_PkgListD6_PackingMark") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ItemNo" runat="server" Text="Item No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ItemNo"
            Width="88px"
            Text='<%# Bind("ItemNo") %>'
            Enabled = "False"
            ToolTip="Value of Item No."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_ItemNo_Display"
            Text='<%# Eval("PAK_PkgListD6_PackingMark") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PackTypeID" runat="server" Text="Pack Type :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_PackTypeID"
            Width="88px"
            Text='<%# Bind("PackTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Pack Type."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_PackTypeID_Display"
            Text='<%# Eval("PAK_PakTypes5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PackingMark" runat="server" Text="Packing Mark :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PackingMark"
            Text='<%# Bind("PackingMark") %>'
            ToolTip="Value of Packing Mark."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PackLength" runat="server" Text="Package Length :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PackLength"
            Text='<%# Bind("PackLength") %>'
            ToolTip="Value of Package Length."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PackWidth" runat="server" Text="Package Width :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PackWidth"
            Text='<%# Bind("PackWidth") %>'
            ToolTip="Value of Package Width."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PackHeight" runat="server" Text="Package Height :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_PackHeight"
            Text='<%# Bind("PackHeight") %>'
            ToolTip="Value of Package Height."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_UOMPack" runat="server" Text="UOM Packing :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_UOMPack"
            Width="88px"
            Text='<%# Bind("UOMPack") %>'
            Enabled = "False"
            ToolTip="Value of UOM Packing."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_UOMPack_Display"
            Text='<%# Eval("PAK_Units12_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DocumentNo" runat="server" Text="Document No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_DocumentNo"
            Width="88px"
            Text='<%# Bind("DocumentNo") %>'
            Enabled = "False"
            ToolTip="Value of Document No."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_DocumentNo_Display"
            Text='<%# Eval("PAK_Documents3_cmba") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DocumentRevision" runat="server" Text="Document Revision :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DocumentRevision"
            Text='<%# Bind("DocumentRevision") %>'
            ToolTip="Value of Document Revision."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UOMQuantity" runat="server" Text="UOM Quantity :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_UOMQuantity"
            Width="88px"
            Text='<%# Bind("UOMQuantity") %>'
            Enabled = "False"
            ToolTip="Value of UOM Quantity."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_UOMQuantity_Display"
            Text='<%# Eval("PAK_Units11_Description") %>'
            CssClass="myLbl"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DocumentReceived" runat="server" Text="Document Received :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_DocumentReceived"
            Checked='<%# Bind("DocumentReceived") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_OnlyPackageReceived" runat="server" Text="Only Package Received :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_OnlyPackageReceived"
            Checked='<%# Bind("OnlyPackageReceived") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MaterialStatusID" runat="server" Text="Status of Material / Package :" />&nbsp;
        </td>
        <td>
          <LGM:LC_pakMaterialStates
            ID="F_MaterialStatusID"
            SelectedValue='<%# Bind("MaterialStatusID") %>'
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
          <asp:Label ID="L_SiteMarkNo" runat="server" Text="Site Mark No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SiteMarkNo"
            CssClass = "myfktxt"
            Text='<%# Bind("SiteMarkNo") %>'
            AutoCompleteType = "None"
            Width="248px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Site Mark No."
            onblur= "script_pakSitePkgD.validate_SiteMarkNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_SiteMarkNo_Display"
            Text='<%# Eval("PAK_SiteItemMaster9_ItemDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESiteMarkNo"
            BehaviorID="B_ACESiteMarkNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SiteMarkNoCompletionList"
            TargetControlID="F_SiteMarkNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_pakSitePkgD.ACESiteMarkNo_Selected"
            OnClientPopulating="script_pakSitePkgD.ACESiteMarkNo_Populating"
            OnClientPopulated="script_pakSitePkgD.ACESiteMarkNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
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
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="100"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_InventoryUpdatedOn" runat="server" Text="Inventory Updated On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_InventoryUpdatedOn"
            Text='<%# Bind("InventoryUpdatedOn") %>'
            ToolTip="Value of Inventory Updated On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_InventoryUpdatedBy" runat="server" Text="Inventory Updated By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_InventoryUpdatedBy"
            Width="72px"
            Text='<%# Bind("InventoryUpdatedBy") %>'
            Enabled = "False"
            ToolTip="Value of Inventory Updated By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_InventoryUpdatedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_InventoryStatusID" runat="server" Text="Inventory Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_InventoryStatusID"
            Width="88px"
            Text='<%# Bind("InventoryStatusID") %>'
            Enabled = "False"
            ToolTip="Value of Inventory Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_InventoryStatusID_Display"
            Text='<%# Eval("PAK_InventoryStatus4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_NotFromPackingList" runat="server" Text="Not From Packing List :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_NotFromPackingList"
            Checked='<%# Bind("NotFromPackingList") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelpakSitePkgDLocation" runat="server" Text="&nbsp;List: Received Packing List Item Location"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakSitePkgDLocation" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakSitePkgDLocation"
      ToolType = "lgNMGrid"
      EditUrl = "~/PAK_Main/App_Edit/EF_pakSitePkgDLocation.aspx"
      AddUrl = "~/PAK_Main/App_Create/AF_pakSitePkgDLocation.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "pakSitePkgDLocation"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakSitePkgDLocation" runat="server" AssociatedUpdatePanelID="UPNLpakSitePkgDLocation" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript"> 
   var script_LocationID = {
    temp: function() {
    }
    }
    </script>

    <script type="text/javascript"> 
   var script_Quantity = {
    temp: function() {
    }
    }
    </script>

    <asp:GridView ID="GVpakSitePkgDLocation" SkinID="gv_silver" runat="server" DataSourceID="ODSpakSitePkgDLocation" DataKeyNames="ProjectID,RecNo,RecSrNo,RecSrLNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Receipt Line Location No" SortExpression="RecSrLNo">
          <ItemTemplate>
            <asp:Label ID="LabelRecSrLNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RecSrLNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item No" SortExpression="PAK_PkgListD2_PackingMark">
          <ItemTemplate>
             <asp:Label ID="L_ItemNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemNo") %>' Text='<%# Eval("PAK_PkgListD2_PackingMark") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Site Mark No" SortExpression="PAK_SiteItemMaster5_ItemDescription">
          <ItemTemplate>
             <asp:Label ID="L_SiteMarkNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SiteMarkNo") %>' Text='<%# Eval("PAK_SiteItemMaster5_ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM Quantity" SortExpression="PAK_Units9_Description">
          <ItemTemplate>
             <asp:Label ID="L_UOMQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UOMQuantity") %>' Text='<%# Eval("PAK_Units9_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
          <ItemTemplate>
          <asp:TextBox ID="F_Quantity"
            Text='<%# Bind("Quantity") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            ValidationGroup='<%# "Approve" & Container.DataItemIndex %>'
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
            ValidationGroup = '<%# "Approve" & Container.DataItemIndex %>'
            IsValidEmpty = "false"
            MinimumValue = "0.01"
            SetFocusOnError="true" />

          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Location" SortExpression="PAK_SiteLocations6_Description">
          <ItemTemplate>
          <LGM:LC_pakSiteLocations
            ID="F_LocationID"
            SelectedValue='<%# Bind("LocationID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = '<%# "Approve" & Container.DataItemIndex %>'
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />

          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UPDATE">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Update Location wise quantity." SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Update location wise quantity ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSpakSitePkgDLocation"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakSitePkgDLocation"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_pakSitePkgDLocationSelectList"
      TypeName = "SIS.PAK.pakSitePkgDLocation"
      SelectCountMethod = "pakSitePkgDLocationSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_RecSrNo" PropertyName="Text" Name="RecSrNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_RecNo" PropertyName="Text" Name="RecNo" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakSitePkgDLocation" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSpakSitePkgD"
  DataObjectTypeName = "SIS.PAK.pakSitePkgD"
  SelectMethod = "pakSitePkgDGetByID"
  UpdateMethod="UZ_pakSitePkgDUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.PAK.pakSitePkgD"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RecNo" Name="RecNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RecSrNo" Name="RecSrNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
