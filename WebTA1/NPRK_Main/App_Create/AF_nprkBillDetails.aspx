<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_nprkBillDetails.aspx.vb" Inherits="AF_nprkBillDetails" title="Bill Entry Form" %>
<asp:Content ID="CPHnprkBillDetails" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelnprkBillDetails" runat="server" Text="&nbsp;Bill Entry Form"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLnprkBillDetails" runat="server" >
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
  <LGM:ToolBar0 
    ID = "TBLnprkBillDetails"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    EnableExit="true"
    ValidationGroup = "nprkBillDetails"
    runat = "server" />
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr id="Tr1" runat="server" style="height:40px;">
        <td colspan="4">
          <b><asp:Label ID="Lbl_Perk" runat="server" Font-Size="Large" style="padding:10px"  Text="" /></b>
        </td>
      </tr>
      <tr id="rowDeclaration" runat="server" style="height:40px; background-color:antiquewhite">
        <td class="alignright">
          <b><asp:Label ID="Label1" runat="server" style="padding:10px"  Text="Declaration :" /></b>
        </td>
        <td colspan="3" style="padding:10px">
          <b><asp:Label ID="lblDeclaration" Font-Size="10pt" runat="server" ForeColor="#CC6633" Text="" /></b>
        </td>
      </tr>
    </table>
    <asp:UpdateProgress ID="UPGSnprkBillDetails" runat="server" AssociatedUpdatePanelID="UPNLnprkBillDetails" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <table>
      <tr>
        <td>
          <asp:TextBox
            ID = "F_ClaimID"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            style="display:none;"
            Runat="Server" />
        </td>
        <td>
          <asp:TextBox
            ID = "F_ApplicationID"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            style="display:none;"
            Runat="Server" />
        </td>
      </tr>
    </table>
      <asp:Label ID="InsertErr" runat="server" ForeColor="Red" Text="" />
    <asp:GridView ID="GVnprkBillDetails" style="width:auto;margin:auto" SkinID="gv_silver" runat="server" DataSourceID="ODSnprkBillDetails" DataKeyNames="ClaimID,ApplicationID,AttachmentID">
      <Columns>
        <asp:TemplateField HeaderText="S.N.">
          <ItemTemplate>
            <asp:Label ID="F_saved" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Saved") %>' style="display:none"></asp:Label>
            <asp:Label ID="F_SerialNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BILL NO" SortExpression="BillNo">
          <ItemTemplate>
          <asp:TextBox ID="F_BillNo"
            Text='<%# Bind("BillNo") %>'
            Width="150px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup='<%# "nprkBillDetails" & Container.DataItemIndex %>'
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BILL NO."
            MaxLength="20"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVBillNo"
            runat = "server"
            ControlToValidate = "F_BillNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "nprkBillDetails" & Container.DataItemIndex %>'
            SetFocusOnError="true" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BILL DATE" SortExpression="BillDate">
          <ItemTemplate>
          <asp:TextBox ID="F_BillDate"
            Text='<%# Bind("BillDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup='<%# "nprkBillDetails" & Container.DataItemIndex %>'
            runat="server" />
          <asp:Image ID="ImageButtonBillDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEBillDate"
            TargetControlID="F_BillDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonBillDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEBillDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_BillDate" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="120px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BILL Details" SortExpression="Particulars">
          <ItemTemplate>
          <asp:TextBox
            ID="F_Particulars"
            Text='<%# Bind("Particulars") %>'
            CssClass = "mytxt"
            MaxLength="100"
            Width="150px"
            ValidationGroup = '<%# "nprkBillDetails" & Container.DataItemIndex %>'
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            Runat="Server" >
          </asp:TextBox>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FROM DATE" SortExpression="FromDate">
          <ItemTemplate>
          <asp:TextBox ID="F_FromDate"
            Text='<%# Bind("FromDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup='<%# "nprkBillDetails" & Container.DataItemIndex %>'
            runat="server" />
          <asp:Image ID="ImageButtonFromDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEFromDate"
            TargetControlID="F_FromDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonFromDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEFromDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_FromDate" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="120px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TO DATE" SortExpression="ToDate">
          <ItemTemplate>
          <asp:TextBox ID="F_ToDate"
            Text='<%# Bind("ToDate") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup='<%# "nprkBillDetails" & Container.DataItemIndex %>'
            runat="server" />
          <asp:Image ID="ImageButtonToDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEToDate"
            TargetControlID="F_ToDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonToDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEToDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ToDate" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="120px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="BILL AMT." SortExpression="Quantity">
          <ItemTemplate>
          <asp:TextBox ID="F_Quantity"
            Text='<%# Bind("Quantity") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            ValidationGroup='<%# "nprkBillDetails" & Container.DataItemIndex %>'
            MaxLength="13"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CLAIMED AMT." SortExpression="Amount">
          <ItemTemplate>
          <asp:TextBox ID="F_Amount"
            Text='<%# Bind("Amount") %>'
            style="text-align: right"
            Width="168px"
            CssClass = "mytxt"
            ValidationGroup='<%# "nprkBillDetails" & Container.DataItemIndex %>'
            MaxLength="13"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField>
          <ItemTemplate>
              <asp:Label ID="errMsg" runat="server" ForeColor="Red" Text="" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="10px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSnprkBillDetails"
      runat = "server"
      DataObjectTypeName = "SIS.NPRK.nprkBillDetails"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_nprkBillDetailsSelectListForNew"
      TypeName = "SIS.NPRK.nprkBillDetails"
      SelectCountMethod = "nprkBillDetailsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ApplicationID" PropertyName="Text" Name="ApplicationID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ClaimID" PropertyName="Text" Name="ClaimID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVnprkBillDetails" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>