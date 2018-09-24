<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taBDLC.aspx.vb" Inherits="AF_taBDLC" title="Add: Conveyance Expenses" %>
<asp:Content ID="CPHtaBDLC" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaBDLC" runat="server" Text="&nbsp;Add: Conveyance Expenses"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaBDLC" runat="server">
  <ContentTemplate>
    <table width="100%">
      <tr>
        <td><b>
          1. From Place, To Place & Date are Mandatory input to SAVE the record.
            </b></td>
      </tr>
    </table>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBDLC"
      ToolType="lgNMAdd"
      ValidationGroup = "taBDmLC"
      InsertAndStay="false"
      EnableExit="true"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBDLC" runat="server" AssociatedUpdatePanelID="UPNLtaBDLC" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:TextBox
      ID = "F_TABillNo"
      CssClass = "mypktxt"
      Width="88px"
      enabled="false"
      style="display:none"
      Runat="Server" />
    <asp:GridView ID="GVtaBDLC" SkinID="gv_silver" runat="server" DataSourceID="ODStaBDLC" DataKeyNames="SerialNo,TABillNo">
      <Columns>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo" >
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="From Place" SortExpression="City1Text">
          <ItemTemplate>
          <asp:TextBox ID="F_City1Text"
            Text='<%# Bind("City1Text") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup='<%# "taBDmLC" & Container.DataItemIndex %>'
            MaxLength="100"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="To Place" SortExpression="City2Text">
          <ItemTemplate>
          <asp:TextBox ID="F_City2Text"
            Text='<%# Bind("City2Text") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup='<%# "taBDmLC" & Container.DataItemIndex %>'
            MaxLength="100"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCity2Text"
            runat = "server"
            ControlToValidate = "F_City2Text"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "taBDmLC" & Container.DataItemIndex %>'
            SetFocusOnError="true" />
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Date1Time">
          <ItemTemplate>
          <asp:TextBox ID="F_Date1Time"
            Text='<%# Bind("Date1Time") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup='<%# "taBDmLC" & Container.DataItemIndex %>'
            runat="server" />
          <asp:Image ID="ImageButtonDate1Time" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDate1Time"
            TargetControlID="F_Date1Time"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDate1Time" />
          <AJX:MaskedEditExtender 
            ID = "MEEDate1Time"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Date1Time" />
          <AJX:MaskedEditValidator 
            ID = "MEVDate1Time"
            runat = "server"
            ControlToValidate = "F_Date1Time"
            ControlExtender = "MEEDate1Time"
            EmptyValueBlurredText = "*"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = '<%# "taBDmLC" & Container.DataItemIndex %>'
            IsValidEmpty = "false"
            SetFocusOnError="true" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Local Coveyance Mode" SortExpression="TA_LCModes13_ModeName">
          <ItemTemplate>
          <LGM:LC_taLCModes
            ID="F_ModeLCID"
            SelectedValue='<%# Bind("ModeLCID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="100px"
            CssClass="myddl"
            Runat="Server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Other Mode" SortExpression="ModeText">
          <ItemTemplate>
          <asp:TextBox ID="F_ModeText"
            Text='<%# Bind("ModeText") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            MaxLength="100"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Airport To Hotel" SortExpression="AirportToHotel">
          <ItemTemplate>
          <asp:CheckBox ID="F_AirportToHotel"
            Checked='<%# Bind("AirportToHotel") %>'
            CssClass = "mychk"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Airport To Client Location" SortExpression="AirportToClientLocation">
          <ItemTemplate>
          <asp:CheckBox ID="F_AirportToClientLocation"
            Checked='<%# Bind("AirportToClientLocation") %>'
            CssClass = "mychk"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Hotel To Airport" SortExpression="HotelToAirport">
          <ItemTemplate>
          <asp:CheckBox ID="F_HotelToAirport"
            Checked='<%# Bind("HotelToAirport") %>'
            CssClass = "mychk"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Amount" SortExpression="AmountRateOU">
          <ItemTemplate>
          <asp:TextBox ID="F_AmountRateOU"
            Text='<%# Bind("AmountRateOU") %>'
            style="text-align: right"
            Width="100px"
            CssClass = "mytxt"
            ValidationGroup='<%# "taBDmLC" & Container.DataItemIndex %>'
            MaxLength="13"
            onfocus = "return this.select();"
            onblur="return dc(this,2);"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignright" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Currency" SortExpression="TA_Currencies10_CurrencyName">
          <ItemTemplate>
          <LGM:LC_taCurrencies
            ID="F_CurrencyID"
            SelectedValue='<%# Bind("CurrencyID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="100px"
            CssClass="myddl"
            ValidationGroup = '<%# "taBDmLC" & Container.DataItemIndex %>'
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Main Currency" SortExpression="CurrencyMain">
          <ItemTemplate>
          <asp:TextBox ID="F_CurrencyMain"
            Text='<%# Bind("CurrencyMain") %>'
            Width="56px"
            CssClass = "dmytxt"
            MaxLength="6"
            enabled="false"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="C.F. To Main Currency" SortExpression="ConversionFactorOU">
          <ItemTemplate>
          <asp:TextBox ID="F_ConversionFactorOU"
            Text='<%# Bind("ConversionFactorOU") %>'
            style="text-align: right"
            Width="100px"
            CssClass ='<%# dCssClass %>'
            ValidationGroup='<%# "taBDmLC" & Container.DataItemIndex %>'
            MaxLength="13"
            onfocus = "return this.select();"
            onblur="return dc(this,6);"
            Enabled='<%# ShowAllColumns %>'
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignright" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
          <ItemTemplate>
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            Width="100px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            MaxLength="500"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODStaBDLC"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBDLC"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBDLCSelectListForNew"
      TypeName = "SIS.TA.taBDLC"
      SelectCountMethod = "taBDLCSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TABillNo" PropertyName="Text" Name="TABillNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVtaBDLC" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>




</div>
</div>
</asp:Content>
