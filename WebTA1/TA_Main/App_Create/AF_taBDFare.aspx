<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_taBDFare.aspx.vb" Inherits="AF_taBDFare" title="Add: Fare" %>
<asp:Content ID="CPHtaBDFare" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaBDFare" runat="server" Text="&nbsp;Add: Fare"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLtaBDFare" runat="server">
  <ContentTemplate>
    <table width="100%">
      <tr>
        <td><b>
          1. From City or (Other City & Its Country), From Date, To Date are Mandatory input to SAVE the record.
            </b></td>
      </tr>
      <tr>
        <td><b>
          2. Country is Optional for Domestic Travel.
            </b></td>
      </tr>
    </table>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLtaBDFare"
      ToolType="lgNMAdd"
      InsertAndStay="false"
      EnableExit="true"
      ValidationGroup = "taBDFare"
      runat = "server" />
    <asp:UpdateProgress ID="UPGStaBDFare" runat="server" AssociatedUpdatePanelID="UPNLtaBDFare" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <table>
      <tr>
        <td>
          <asp:TextBox
            ID = "F_TABillNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            style="display:none;"
            Runat="Server" />
        </td>
      </tr>
    </table>
    <script type="text/javascript"> 
   var script_Country1ID = {
    ACECountry1ID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('Country1ID','');
      var F_Country1ID = $get(sender._element.id);
      var F_Country1ID_Display = $get(sender._element.id.replace('Country1ID','Country1ID_Display'));
      var retval = e.get_value();
      var p = retval.split('|');
      F_Country1ID.value = p[0];
      F_Country1ID_Display.innerHTML = e.get_text();
    },
    ACECountry1ID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('Country1ID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECountry1ID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_Country1ID: function(sender) {
      var Prefix = sender.id.replace('Country1ID','');
      this.validated_FK_TA_BillDetails_Country1ID_main = true;
      this.validate_FK_TA_BillDetails_Country1ID(sender,Prefix);
      },
    validate_FK_TA_BillDetails_Country1ID: function(o,Prefix) {
      var value = o.id;
      var Country1ID = $get(o.id);
      if(Country1ID.value==''){
        if(this.validated_FK_TA_BillDetails_Country1ID_main){
          var o_d = $get(o.id.replace('Country1ID','Country1ID_Display'));
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + Country1ID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_BillDetails_Country1ID(value, this.validated_FK_TA_BillDetails_Country1ID);
      },
    validated_FK_TA_BillDetails_Country1ID_main: false,
    validated_FK_TA_BillDetails_Country1ID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_Country1ID.validated_FK_TA_BillDetails_Country1ID_main){
        var o_d = $get(p[1].replace('Country1ID','Country1ID_Display'));
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
    </script>
    <script type="text/javascript"> 
   var script_Country2ID = {
    ACECountry2ID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('Country2ID','');
      var F_Country2ID = $get(sender._element.id);
      var F_Country2ID_Display = $get(sender._element.id.replace('Country2ID', 'Country2ID_Display'));
      var retval = e.get_value();
      var p = retval.split('|');
      F_Country2ID.value = p[0];
      F_Country2ID_Display.innerHTML = e.get_text();
    },
    ACECountry2ID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('Country2ID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECountry2ID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_Country2ID: function(sender) {
      var Prefix = sender.id.replace('Country2ID','');
      this.validated_FK_TA_BillDetails_Country2ID_main = true;
      this.validate_FK_TA_BillDetails_Country2ID(sender,Prefix);
      },
    validate_FK_TA_BillDetails_Country2ID: function(o,Prefix) {
      var value = o.id;
      var Country2ID = $get(o.id);
      if(Country2ID.value==''){
        if(this.validated_FK_TA_BillDetails_Country2ID_main){
          var o_d = $get(o.id.replace('Country2ID' , 'Country2ID_Display'));
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + Country2ID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_BillDetails_Country2ID(value, this.validated_FK_TA_BillDetails_Country2ID);
      },
    validated_FK_TA_BillDetails_Country2ID_main: false,
    validated_FK_TA_BillDetails_Country2ID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_Country2ID.validated_FK_TA_BillDetails_Country2ID_main){
        var o_d = $get(p[1].replace('Country2ID'+'Country2ID_Display'));
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
    </script>
    <script type="text/javascript"> 
   var script_City1ID = {
    ACECity1ID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('City1ID','');
      var F_City1ID = $get(sender._element.id);
      var F_City1ID_Display = $get(sender._element.id.replace('City1ID', 'City1ID_Display'));
      var retval = e.get_value();
      var p = retval.split('|');
      F_City1ID.value = p[0];
      F_City1ID_Display.innerHTML = e.get_text();
    },
    ACECity1ID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('City1ID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECity1ID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_City1ID: function(sender) {
      var Prefix = sender.id.replace('City1ID','');
      this.validated_FK_TA_BillDetails_City1ID_main = true;
      this.validate_FK_TA_BillDetails_City1ID(sender,Prefix);
      },
    validate_FK_TA_BillDetails_City1ID: function(o,Prefix) {
      var value = o.id;
      var City1ID = $get(o.id);
      if(City1ID.value==''){
        if(this.validated_FK_TA_BillDetails_City1ID_main){
          var o_d = $get(o.id.replace('City1ID', 'City1ID_Display'));
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + City1ID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_BillDetails_City1ID(value, this.validated_FK_TA_BillDetails_City1ID);
      },
    validated_FK_TA_BillDetails_City1ID_main: false,
    validated_FK_TA_BillDetails_City1ID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_City1ID.validated_FK_TA_BillDetails_City1ID_main){
        var o_d = $get(p[1].replace('City1ID','City1ID_Display'));
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
    </script>
    <script type="text/javascript"> 
   var script_City2ID = {
    ACECity2ID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('City2ID','');
      var F_City2ID = $get(sender._element.id);
      var F_City2ID_Display = $get(sender._element.id.replace('City2ID', 'City2ID_Display'));
      var retval = e.get_value();
      var p = retval.split('|');
      F_City2ID.value = p[0];
      F_City2ID_Display.innerHTML = e.get_text();
    },
    ACECity2ID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('City2ID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECity2ID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_City2ID: function(sender) {
      var Prefix = sender.id.replace('City2ID','');
      this.validated_FK_TA_BillDetails_City2ID_main = true;
      this.validate_FK_TA_BillDetails_City2ID(sender,Prefix);
      },
    validate_FK_TA_BillDetails_City2ID: function(o,Prefix) {
      var value = o.id;
      var City2ID = $get(o.id);
      if(City2ID.value==''){
        if(this.validated_FK_TA_BillDetails_City2ID_main){
          var o_d = $get(o.id.replace('City2ID','City2ID_Display'));
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + City2ID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_BillDetails_City2ID(value, this.validated_FK_TA_BillDetails_City2ID);
      },
    validated_FK_TA_BillDetails_City2ID_main: false,
    validated_FK_TA_BillDetails_City2ID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_City2ID.validated_FK_TA_BillDetails_City2ID_main){
        var o_d = $get(p[1].replace('City2ID','City2ID_Display'));
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
    </script>
      <asp:Label ID="InsertErr" runat="server" ForeColor="Red" Text="" />
    <asp:GridView ID="GVtaBDFare" SkinID="gv_silver" runat="server" DataSourceID="ODStaBDFare" DataKeyNames="SerialNo,TABillNo">
      <Columns>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="F_saved" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("Saved") %>' style="display:none"></asp:Label>
            <asp:Label ID="F_SerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="From City" SortExpression="TA_Cities6_CityName">
          <ItemTemplate>
          <asp:TextBox
            ID = "F_City1ID"
            CssClass = "myfktxt"
            Text='<%# Bind("City1ID") %>'
            AutoCompleteType = "None"
            Width="100px"
            onfocus = "return this.select();"
            onblur= "script_City1ID.validate_City1ID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_City1ID_Display"
            Text='<%# Eval("TA_Cities6_CityName") %>'
            CssClass="myLbl"
            style="display:none;"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECity1ID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="City1IDCompletionList"
            TargetControlID="F_City1ID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_City1ID.ACECity1ID_Selected"
            OnClientPopulating="script_City1ID.ACECity1ID_Populating"
            OnClientPopulated="script_City1ID.ACECity1ID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
          <asp:TextBox ID="F_City1Text"
            Text='<%# Bind("City1Text") %>'
            Width="100px"
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            MaxLength="100"
            runat="server" />
          <AJX:TextBoxWatermarkExtender 
            ID="TBWMECity1Text" 
            runat="server" 
            TargetControlID="F_City1Text"
            WatermarkCssClass="waterMark"
            WatermarkText="[Other City]" />
          <asp:TextBox
            ID = "F_Country1ID"
            CssClass = "myfktxt"
            Text='<%# Bind("Country1ID") %>'
            AutoCompleteType = "None"
            Width="100px"
            onfocus = "return this.select();"
            onblur= "script_Country1ID.validate_Country1ID(this);"
            Runat="Server" />
          <AJX:TextBoxWatermarkExtender 
            ID="TBWMECountry1ID" 
            runat="server" 
            TargetControlID="F_Country1ID"
            WatermarkCssClass="waterMark"
            WatermarkText="[Departure Country]" />
          <asp:Label
            ID = "F_Country1ID_Display"
            Text='<%# Eval("TA_Countries16_CountryName") %>'
            style="display:none;"
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECountry1ID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="Country1IDCompletionList"
            TargetControlID="F_Country1ID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_Country1ID.ACECountry1ID_Selected"
            OnClientPopulating="script_Country1ID.ACECountry1ID_Populating"
            OnClientPopulated="script_Country1ID.ACECountry1ID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="To City" SortExpression="TA_Cities7_CityName">
          <ItemTemplate>
          <asp:TextBox
            ID = "F_City2ID"
            CssClass = "myfktxt"
            Text='<%# Bind("City2ID") %>'
            AutoCompleteType = "None"
            Width="100px"
            onfocus = "return this.select();"
            ToolTip="Enter value for To City."
            onblur= "script_City2ID.validate_City2ID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_City2ID_Display"
            Text='<%# Eval("TA_Cities7_CityName") %>'
            CssClass="myLbl"
            style="display:none;"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECity2ID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="City2IDCompletionList"
            TargetControlID="F_City2ID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_City2ID.ACECity2ID_Selected"
            OnClientPopulating="script_City2ID.ACECity2ID_Populating"
            OnClientPopulated="script_City2ID.ACECity2ID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
          <asp:TextBox ID="F_City2Text"
            Text='<%# Bind("City2Text") %>'
            Width="100px"
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            MaxLength="100"
            runat="server" />
          <AJX:TextBoxWatermarkExtender 
            ID="TBWMECity2Text" 
            runat="server" 
            TargetControlID="F_City2Text"
            WatermarkCssClass="waterMark"
            WatermarkText="[Other City]" />
          <asp:TextBox
            ID = "F_Country2ID"
            CssClass = "myfktxt"
            Text='<%# Bind("Country2ID") %>'
            AutoCompleteType = "None"
            Width="100px"
            onfocus = "return this.select();"
            onblur= "script_Country2ID.validate_Country2ID(this);"
            Runat="Server" />
          <AJX:TextBoxWatermarkExtender 
            ID="TBWMECountry2ID" 
            runat="server" 
            TargetControlID="F_Country2ID"
            WatermarkCssClass="waterMark"
            WatermarkText="[Arrival Country]" />
          <asp:Label
            ID = "F_Country2ID_Display"
            Text='<%# Eval("TA_Countries17_CountryName") %>'
            CssClass="myLbl"
            style="display:none;"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECountry2ID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="Country2IDCompletionList"
            TargetControlID="F_Country2ID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_Country2ID.ACECountry2ID_Selected"
            OnClientPopulating="script_Country2ID.ACECountry2ID_Populating"
            OnClientPopulated="script_Country2ID.ACECountry2ID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Departure" SortExpression="Date1Time">
          <ItemTemplate>
          <asp:TextBox ID="F_Date1Time"
            Text='<%# Bind("Date1Time") %>'
            Width="120px"
            CssClass = "mytxt"
            runat="server" />
          <asp:Image ID="ImageButtonDate1Time" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDate1Time"
            TargetControlID="F_Date1Time"
            Format="dd/MM/yyyy HH:mm"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDate1Time" />
          <AJX:MaskedEditExtender 
            ID = "MEEDate1Time"
            runat = "server"
            mask = "99/99/9999 99:99"
            MaskType="DateTime"
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
            InvalidValueMessage="*"
            Display = "Dynamic"
            EnableClientScript = "True"
            IsValidEmpty="true"
            SetFocusOnError="True" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="130px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Arrival" SortExpression="Date2Time">
          <ItemTemplate>
          <asp:TextBox ID="F_Date2Time"
            Text='<%# Bind("Date2Time") %>'
            Width="120px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonDate2Time" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEDate2Time"
            TargetControlID="F_Date2Time"
            Format="dd/MM/yyyy HH:mm"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonDate2Time" />
          <AJX:MaskedEditExtender 
            ID = "MEEDate2Time"
            runat = "server"
            mask = "99/99/9999 99:99"
            MaskType="DateTime"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Date2Time" />
          <AJX:MaskedEditValidator 
            ID = "MEVDate2Time"
            runat = "server"
            ControlToValidate = "F_Date2Time"
            ControlExtender = "MEEDate2Time"
            EmptyValueBlurredText = "*"
            InvalidValueMessage="*"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="130px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Travel Mode" SortExpression="TA_TravelModes15_ModeName">
          <ItemTemplate>
          <LGM:LC_taTravelModes
            ID="F_ModeTravelID"
            SelectedValue='<%# Bind("ModeTravelID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="106px"
            CssClass="myddl"
            Runat="Server" />
          <asp:TextBox ID="F_ModeText"
            Text='<%# Bind("ModeText") %>'
            Width="100px"
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            MaxLength="100"
            runat="server" />
          <AJX:TextBoxWatermarkExtender 
            ID="TBWMEModeText" 
            runat="server" 
            TargetControlID="F_ModeText"
            WatermarkCssClass="waterMark"
            WatermarkText="[Other Mode]" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="AmountRateOU" SortExpression="AmountRateOU">
          <ItemTemplate>
          <asp:TextBox ID="F_AmountRateOU"
            Text='<%# Bind("AmountRateOU") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="10"
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
            Width="80px"
            CssClass="myddl"
            Runat="Server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Main Currency" SortExpression="CurrencyMain">
          <ItemTemplate>
          <asp:TextBox ID="F_CurrencyMain"
            Text='<%# Bind("CurrencyMain") %>'
            Width="50px"
            CssClass = "dmytxt"
            Enabled="false"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="C.F. Main Currency" SortExpression="ConversionFactorOU">
          <ItemTemplate>
          <asp:TextBox ID="F_ConversionFactorOU"
            Text='<%# Bind("ConversionFactorOU") %>'
            style="text-align: right"
            Width="100px"
            CssClass ='<%# dCssClass %>'
            Enabled='<%# ShowAllColumns %>'
            MaxLength="13"
            onfocus = "return this.select();"
            onblur="return dc(this,6);"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
          <ItemTemplate>
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            MaxLength="500"
            runat="server" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField>
          <ItemTemplate>
            </td></tr>
            <tr>
            <td colspan="12" style="background-color:AntiqueWhite; color:DeepPink;padding:4px" >
              <asp:Label ID="errMsg" runat="server" ForeColor="Red" Text="" />
            </td>
            </tr>
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
      ID = "ODStaBDFare"
      runat = "server"
      DataObjectTypeName = "SIS.TA.taBDFare"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_taBDFareSelectListForNew"
      TypeName = "SIS.TA.taBDFare"
      SelectCountMethod = "taBDFareSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVtaBDFare" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>

</div>
</div>
</asp:Content>
