<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_costCostSheet.aspx.vb" Inherits="GF_costCostSheet" title="Maintain List: Cost Sheet" %>
<asp:Content ID="CPHcostCostSheet" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelcostCostSheet" runat="server" Text="&nbsp;List: Cost Sheet"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcostCostSheet"  runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcostCostSheet"
      ToolType = "lgNMGrid"
      EditUrl = "~/COST_Main/App_Edit/EF_costCostSheet.aspx"
      AddUrl = "~/COST_Main/App_Create/AF_costCostSheet.aspx?skip=1"
      ValidationGroup = "costCostSheet"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScostCostSheet" runat="server" AssociatedUpdatePanelID="UPNLcostCostSheet" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td></td>
        <td></td>
        <td rowspan="6" style="padding-left:50px">
            <div id="F_Upload" runat="server" style="width: 90%; margin: 10px 10px 10px 10px; padding: 10px 10px 10px 10px" class="file_upload">
              <table>
                <tr>
                   <td style="vertical-align:top">
                    <b>
                      1.
                    </b>
                  </td>

                  <td colspan="4" style="column-span:all">
                    <b>
                      Download EXCEL Template. 
                    </b>
                  </td>
                </tr>
                <tr>
                  <td>
                    <b>
                      &nbsp;
                    </b>
                  </td>
                  <td><b>
                    <asp:Label ID="lblTemplate" runat="server" Text="Fin.Year & Quarter" />
                    </b>
                  </td>
                  <td>
                    <script type="text/javascript"> 
                    var script_costCostSheet = {
                        ACEFinYear_Selected: function(sender, e) {
                          var Prefix = sender._element.id.replace('FinYearD','');
                          var F_FinYear = $get(sender._element.id);
                          var F_FinYear_Display = $get(sender._element.id + '_Display');
                          var retval = e.get_value();
                          var p = retval.split('|');
                          F_FinYear.value = p[0];
                        },
                        ACEFinYear_Populating: function(sender,e) {
                          var p = sender.get_element();
                          var Prefix = sender._element.id.replace('FinYearD','');
                          p.style.backgroundImage  = 'url(../../images/loader.gif)';
                          p.style.backgroundRepeat= 'no-repeat';
                          p.style.backgroundPosition = 'right';
                          sender._contextKey = '';
                        },
                        ACEFinYear_Populated: function(sender,e) {
                          var p = sender.get_element();
                          p.style.backgroundImage  = 'none';
                        },
                        ACEQuarter_Selected: function(sender, e) {
                          var Prefix = sender._element.id.replace('QuarterD','');
                          var F_Quarter = $get(sender._element.id);
                          var F_Quarter_Display = $get(sender._element.id + '_Display');
                          var retval = e.get_value();
                          var p = retval.split('|');
                          F_Quarter.value = p[0];
                        },
                        ACEQuarter_Populating: function(sender,e) {
                          var p = sender.get_element();
                          var Prefix = sender._element.id.replace('QuarterD','');
                          p.style.backgroundImage  = 'url(../../images/loader.gif)';
                          p.style.backgroundRepeat= 'no-repeat';
                          p.style.backgroundPosition = 'right';
                          sender._contextKey = '';
                        },
                        ACEQuarter_Populated: function(sender,e) {
                          var p = sender.get_element();
                          p.style.backgroundImage  = 'none';
                        },
                        validate_FinYear: function(sender) {
                          var Prefix = sender.id.replace('FinYearD','');
                          this.validated_FK_COST_CostSheet_FinYear_main = true;
                          this.validate_FK_COST_CostSheet_FinYear(sender,Prefix);
                          },
                        validate_Quarter: function(sender) {
                          var Prefix = sender.id.replace('QuarterD','');
                          this.validated_FK_COST_CostSheet_Quarter_main = true;
                          this.validate_FK_COST_CostSheet_Quarter(sender,Prefix);
                          },
                        validate_FK_COST_CostSheet_FinYear: function(o,Prefix) {
                          var value = o.id;
                          var FinYear = $get(Prefix + 'FinYearD');
                          if(FinYear.value==''){
                            if(this.validated_FK_COST_CostSheet_FinYear_main){
                              var o_d = $get(Prefix + 'FinYearD' + '_Display');
                              try{o_d.innerHTML = '';}catch(ex){}
                            }
                            return true;
                          }
                          value = value + ',' + FinYear.value ;
                            o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
                            o.style.backgroundRepeat= 'no-repeat';
                            o.style.backgroundPosition = 'right';
                            PageMethods.validate_FK_COST_CostSheet_FinYear(value, this.validated_FK_COST_CostSheet_FinYear);
                          },
                        validated_FK_COST_CostSheet_FinYear_main: false,
                        validated_FK_COST_CostSheet_FinYear: function(result) {
                          var p = result.split('|');
                          var o = $get(p[1]);
                          if(script_costCostSheet.validated_FK_COST_CostSheet_FinYear_main){
                            var o_d = $get(p[1]+'_Display');
                            try{o_d.innerHTML = p[2];}catch(ex){}
                          }
                          o.style.backgroundImage  = 'none';
                          if(p[0]=='1'){
                            o.value='';
                            o.focus();
                          }
                        },
                        validate_FK_COST_CostSheet_Quarter: function(o,Prefix) {
                          var value = o.id;
                          var Quarter = $get(Prefix + 'QuarterD');
                          if(Quarter.value==''){
                            if(this.validated_FK_COST_CostSheet_Quarter_main){
                              var o_d = $get(Prefix + 'QuarterD' + '_Display');
                              try{o_d.innerHTML = '';}catch(ex){}
                            }
                            return true;
                          }
                          value = value + ',' + Quarter.value ;
                            o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
                            o.style.backgroundRepeat= 'no-repeat';
                            o.style.backgroundPosition = 'right';
                            PageMethods.validate_FK_COST_CostSheet_Quarter(value, this.validated_FK_COST_CostSheet_Quarter);
                          },
                        validated_FK_COST_CostSheet_Quarter_main: false,
                        validated_FK_COST_CostSheet_Quarter: function(result) {
                          var p = result.split('|');
                          var o = $get(p[1]);
                          if(script_costCostSheet.validated_FK_COST_CostSheet_Quarter_main){
                            var o_d = $get(p[1]+'_Display');
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
                    <asp:TextBox
                      ID = "F_FinYearD"
                      CssClass = "mypktxt"
                      Width="88px"
                      Text=""
                      onfocus = "return this.select();"
                      AutoCompleteType = "None"
                      onblur= "script_costCostSheet.validate_FinYear(this);"
                      Runat="Server" />
                    <AJX:AutoCompleteExtender
                      ID="ACEFinYearD"
                      ContextKey=""
                      UseContextKey="true"
                      ServiceMethod="FinYearCompletionList"
                      TargetControlID="F_FinYearD"
                      CompletionInterval="100"
                      FirstRowSelected="true"
                      MinimumPrefixLength="1"
                      OnClientItemSelected="script_costCostSheet.ACEFinYear_Selected"
                      OnClientPopulating="script_costCostSheet.ACEFinYear_Populating"
                      OnClientPopulated="script_costCostSheet.ACEFinYear_Populated"
                      CompletionSetCount="10"
                      CompletionListCssClass = "autocomplete_completionListElement"
                      CompletionListItemCssClass = "autocomplete_listItem"
                      CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
                      Runat="Server" />
                  </td>
                  <td>
                    <asp:TextBox
                      ID = "F_QuarterD"
                      CssClass = "mypktxt"
                      Width="88px"
                      Text=""
                      onfocus = "return this.select();"
                      AutoCompleteType = "None"
                      onblur= "script_costCostSheet.validate_Quarter(this);"
                      Runat="Server" />
                    <AJX:AutoCompleteExtender
                      ID="ACEQuarterD"
                      ContextKey=""
                      UseContextKey="true"
                      ServiceMethod="QuarterCompletionList"
                      TargetControlID="F_QuarterD"
                      CompletionInterval="100"
                      FirstRowSelected="true"
                      MinimumPrefixLength="1"
                      OnClientItemSelected="script_costCostSheet.ACEQuarter_Selected"
                      OnClientPopulating="script_costCostSheet.ACEQuarter_Populating"
                      OnClientPopulated="script_costCostSheet.ACEQuarter_Populated"
                      CompletionSetCount="10"
                      CompletionListCssClass = "autocomplete_completionListElement"
                      CompletionListItemCssClass = "autocomplete_listItem"
                      CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
                      Runat="Server" />
                  </td>
                  <td>
                    <asp:Button ID="cmdDownload" CssClass="file_upload_button" Text="Download" runat="server" ToolTip="Click to download template file." CommandName="Download" CommandArgument="" />
                  </td>
                </tr>
                <tr>
                   <td style="vertical-align:top">
                    <b>
                      2.
                    </b>
                  </td>

                  <td colspan="4" style="column-span:all">
                    <b>
                      Upload template to Create / Update Project Group data. <br />Check Downloaded file for ERRORS. 
                    </b>
                  </td>
                </tr>
                <tr>
                  <td>
                    <b>
                      &nbsp;
                    </b>
                  </td>
                  <td colspan="2">
                    <input type="text" id="fileName" style="width: 185px" class="file_input_textbox" readonly="readonly">
                  </td>
                  <td>
                    <div class="file_input_div">
                      <input type="button" value="Search" class="file_input_button" />
                      <asp:FileUpload ID="F_FileUpload" runat="server" Width="80px" class="file_input_hidden" onchange="document.getElementById('fileName').value = this.value;" ToolTip="Upload Project Group Template" />
                    </div>
                  </td>
                  <td>
                    <asp:Button ID="cmdFileUpload" CssClass="file_upload_button" OnClientClick="return this.style.display='none';true;" Text="Upload" runat="server" ToolTip="Click to upload & process template file." CommandName="Upload" CommandArgument="" />
                  </td>
                </tr>
              </table>
            </div>
            <asp:Label runat="server" ID="errMsg" ForeColor="Red" Text="" />

        </td>
        <td rowspan="6" style="padding-left:50px">
            <div id="Div1" runat="server" style="width: 90%; margin: 10px 10px 10px 10px; padding: 10px 10px 10px 10px" class="file_upload">
              <table>
                <tr>
                  <td style="vertical-align:top">
                    <b>3.
                    </b>
                  </td>
                  <td colspan="3" style="column-span:all">
                    <b>
                      Update ERP-LN Data. 
                    </b>
                  </td>
                </tr>
                <tr>
                  <td>
                    <b>
                      &nbsp;
                    </b>
                  </td>
                  <td><b>
                    <asp:Label ID="Label1" runat="server" Text="Fin.Year & Quarter" />
                    </b>
                  </td>
                  <td>
                    <script type="text/javascript"> 
                    var script_costCostSheet = {
                        ACEFinYear_Selected: function(sender, e) {
                          var Prefix = sender._element.id.replace('FinYearE','');
                          var F_FinYear = $get(sender._element.id);
                          var F_FinYear_Display = $get(sender._element.id + '_Display');
                          var retval = e.get_value();
                          var p = retval.split('|');
                          F_FinYear.value = p[0];
                        },
                        ACEFinYear_Populating: function(sender,e) {
                          var p = sender.get_element();
                          var Prefix = sender._element.id.replace('FinYearE','');
                          p.style.backgroundImage  = 'url(../../images/loader.gif)';
                          p.style.backgroundRepeat= 'no-repeat';
                          p.style.backgroundPosition = 'right';
                          sender._contextKey = '';
                        },
                        ACEFinYear_Populated: function(sender,e) {
                          var p = sender.get_element();
                          p.style.backgroundImage  = 'none';
                        },
                        ACEQuarter_Selected: function(sender, e) {
                          var Prefix = sender._element.id.replace('QuarterE','');
                          var F_Quarter = $get(sender._element.id);
                          var F_Quarter_Display = $get(sender._element.id + '_Display');
                          var retval = e.get_value();
                          var p = retval.split('|');
                          F_Quarter.value = p[0];
                        },
                        ACEQuarter_Populating: function(sender,e) {
                          var p = sender.get_element();
                          var Prefix = sender._element.id.replace('QuarterE','');
                          p.style.backgroundImage  = 'url(../../images/loader.gif)';
                          p.style.backgroundRepeat= 'no-repeat';
                          p.style.backgroundPosition = 'right';
                          sender._contextKey = '';
                        },
                        ACEQuarter_Populated: function(sender,e) {
                          var p = sender.get_element();
                          p.style.backgroundImage  = 'none';
                        },
                        validate_FinYear: function(sender) {
                          var Prefix = sender.id.replace('FinYearE','');
                          this.validated_FK_COST_CostSheet_FinYear_main = true;
                          this.validate_FK_COST_CostSheet_FinYear(sender,Prefix);
                          },
                        validate_Quarter: function(sender) {
                          var Prefix = sender.id.replace('QuarterE','');
                          this.validated_FK_COST_CostSheet_Quarter_main = true;
                          this.validate_FK_COST_CostSheet_Quarter(sender,Prefix);
                          },
                        validate_FK_COST_CostSheet_FinYear: function(o,Prefix) {
                          var value = o.id;
                          var FinYear = $get(Prefix + 'FinYearE');
                          if(FinYear.value==''){
                            if(this.validated_FK_COST_CostSheet_FinYear_main){
                              var o_d = $get(Prefix + 'FinYearE' + '_Display');
                              try{o_d.innerHTML = '';}catch(ex){}
                            }
                            return true;
                          }
                          value = value + ',' + FinYear.value ;
                            o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
                            o.style.backgroundRepeat= 'no-repeat';
                            o.style.backgroundPosition = 'right';
                            PageMethods.validate_FK_COST_CostSheet_FinYear(value, this.validated_FK_COST_CostSheet_FinYear);
                          },
                        validated_FK_COST_CostSheet_FinYear_main: false,
                        validated_FK_COST_CostSheet_FinYear: function(result) {
                          var p = result.split('|');
                          var o = $get(p[1]);
                          if(script_costCostSheet.validated_FK_COST_CostSheet_FinYear_main){
                            var o_d = $get(p[1]+'_Display');
                            try{o_d.innerHTML = p[2];}catch(ex){}
                          }
                          o.style.backgroundImage  = 'none';
                          if(p[0]=='1'){
                            o.value='';
                            o.focus();
                          }
                        },
                        validate_FK_COST_CostSheet_Quarter: function(o,Prefix) {
                          var value = o.id;
                          var Quarter = $get(Prefix + 'QuarterE');
                          if(Quarter.value==''){
                            if(this.validated_FK_COST_CostSheet_Quarter_main){
                              var o_d = $get(Prefix + 'QuarterE' + '_Display');
                              try{o_d.innerHTML = '';}catch(ex){}
                            }
                            return true;
                          }
                          value = value + ',' + Quarter.value ;
                            o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
                            o.style.backgroundRepeat= 'no-repeat';
                            o.style.backgroundPosition = 'right';
                            PageMethods.validate_FK_COST_CostSheet_Quarter(value, this.validated_FK_COST_CostSheet_Quarter);
                          },
                        validated_FK_COST_CostSheet_Quarter_main: false,
                        validated_FK_COST_CostSheet_Quarter: function(result) {
                          var p = result.split('|');
                          var o = $get(p[1]);
                          if(script_costCostSheet.validated_FK_COST_CostSheet_Quarter_main){
                            var o_d = $get(p[1]+'_Display');
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
                    <asp:TextBox
                      ID = "F_FinYearE"
                      CssClass = "mypktxt"
                      Width="88px"
                      Text=""
                      onfocus = "return this.select();"
                      AutoCompleteType = "None"
                      onblur= "script_costCostSheet.validate_FinYear(this);"
                      Runat="Server" />
                    <AJX:AutoCompleteExtender
                      ID="ACEFinYearE"
                      ContextKey=""
                      UseContextKey="true"
                      ServiceMethod="FinYearCompletionList"
                      TargetControlID="F_FinYearE"
                      CompletionInterval="100"
                      FirstRowSelected="true"
                      MinimumPrefixLength="1"
                      OnClientItemSelected="script_costCostSheet.ACEFinYear_Selected"
                      OnClientPopulating="script_costCostSheet.ACEFinYear_Populating"
                      OnClientPopulated="script_costCostSheet.ACEFinYear_Populated"
                      CompletionSetCount="10"
                      CompletionListCssClass = "autocomplete_completionListElement"
                      CompletionListItemCssClass = "autocomplete_listItem"
                      CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
                      Runat="Server" />
                  </td>
                  <td>
                    <asp:TextBox
                      ID = "F_QuarterE"
                      CssClass = "mypktxt"
                      Width="88px"
                      Text=""
                      onfocus = "return this.select();"
                      AutoCompleteType = "None"
                      onblur= "script_costCostSheet.validate_Quarter(this);"
                      Runat="Server" />
                    <AJX:AutoCompleteExtender
                      ID="ACEQuarterE"
                      ContextKey=""
                      UseContextKey="true"
                      ServiceMethod="QuarterCompletionList"
                      TargetControlID="F_QuarterE"
                      CompletionInterval="100"
                      FirstRowSelected="true"
                      MinimumPrefixLength="1"
                      OnClientItemSelected="script_costCostSheet.ACEQuarter_Selected"
                      OnClientPopulating="script_costCostSheet.ACEQuarter_Populating"
                      OnClientPopulated="script_costCostSheet.ACEQuarter_Populated"
                      CompletionSetCount="10"
                      CompletionListCssClass = "autocomplete_completionListElement"
                      CompletionListItemCssClass = "autocomplete_listItem"
                      CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
                      Runat="Server" />
                  </td>
                </tr>
                <tr>
                  <td>
                    <b>
                      &nbsp;
                    </b>
                  </td>
                  <td><b>
                    <asp:Label ID="Label2" runat="server" Text="Group ID Range" />
                    </b>
                  </td>
                  <td>
                    <asp:TextBox
                      ID = "F_FGID"
                      CssClass = "mypktxt"
                      Width="88px"
                      Text=""
                      onfocus = "return this.select();"
                      AutoCompleteType = "None"
                      Runat="Server" />
                  </td>
                  <td>
                    <asp:TextBox
                      ID = "F_TGID"
                      CssClass = "mypktxt"
                      Width="88px"
                      Text=""
                      onfocus = "return this.select();"
                      AutoCompleteType = "None"
                      Runat="Server" />
                  </td>
                </tr>
                <tr>
                  <td>
                    <b>
                      &nbsp;
                    </b>
                  </td>
                  <td colspan="3" >
                    <asp:Button ID="cmdERPLN" CssClass="file_upload_button" Text="ERP-LN Data" runat="server" ToolTip="Click to update ERP-LN Data." CommandName="ERPLNUpdate" CommandArgument="" />
                  </td>
                </tr>
              </table>
            </div>
        </td>

      </tr> 
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectGroupID" runat="server" Text="Project Group ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectGroupID"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ProjectGroupID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectGroupID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectGroupID"
            BehaviorID="B_ACEProjectGroupID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectGroupIDCompletionList"
            TargetControlID="F_ProjectGroupID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEProjectGroupID_Selected"
            OnClientPopulating="ACEProjectGroupID_Populating"
            OnClientPopulated="ACEProjectGroupID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FinYear" runat="server" Text="Fin. Year :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FinYear"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_FinYear(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_FinYear_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEFinYear"
            BehaviorID="B_ACEFinYear"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="FinYearCompletionList"
            TargetControlID="F_FinYear"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEFinYear_Selected"
            OnClientPopulating="ACEFinYear_Populating"
            OnClientPopulated="ACEFinYear_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_Quarter" runat="server" Text="Quarter :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_Quarter"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_Quarter(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_Quarter_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEQuarter"
            BehaviorID="B_ACEQuarter"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="QuarterCompletionList"
            TargetControlID="F_Quarter"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEQuarter_Selected"
            OnClientPopulating="ACEQuarter_Populating"
            OnClientPopulated="ACEQuarter_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            CssClass = "myfktxt"
            Width="72px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_CreatedBy(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECreatedBy"
            BehaviorID="B_ACECreatedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CreatedByCompletionList"
            TargetControlID="F_CreatedBy"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACECreatedBy_Selected"
            OnClientPopulating="ACECreatedBy_Populating"
            OnClientPopulated="ACECreatedBy_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_StatusID" runat="server" Text="Status :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_StatusID"
            CssClass = "myfktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_StatusID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_StatusID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEStatusID"
            BehaviorID="B_ACEStatusID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="StatusIDCompletionList"
            TargetControlID="F_StatusID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEStatusID_Selected"
            OnClientPopulating="ACEStatusID_Populating"
            OnClientPopulated="ACEStatusID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=150,height=100,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVcostCostSheet" SkinID="gv_silver" runat="server" DataSourceID="ODScostCostSheet" DataKeyNames="ProjectGroupID,FinYear,Quarter,Revision">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PRINT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Group ID" SortExpression="COST_ProjectGroups5_ProjectGroupDescription">
          <ItemTemplate>
             <asp:Label ID="L_ProjectGroupID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectGroupID") %>' Text='<%# Eval("COST_ProjectGroups5_ProjectGroupDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="180px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fin. Year" SortExpression="COST_FinYear4_Descpription">
          <ItemTemplate>
             <asp:Label ID="L_FinYear" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("FinYear") %>' Text='<%# Eval("COST_FinYear4_Descpription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="60px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quarter" SortExpression="COST_Quarters6_Description">
          <ItemTemplate>
             <asp:Label ID="L_Quarter" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("Quarter") %>' Text='<%# Eval("COST_Quarters6_Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="60px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Rev." SortExpression="Revision">
          <ItemTemplate>
            <asp:Label ID="LabelRevision" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Revision") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created By" SortExpression="aspnet_users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_CreatedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("CreatedBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="140px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Created On" SortExpression="CreatedOn">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="COST_CostSheetStates3_Description">
          <ItemTemplate>
             <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("COST_CostSheetStates3_Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Download">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDownload" ValidationGroup='<%# "Download" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DownloadWFVisible") %>' Enabled='<%# EVal("DownloadWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Download" SkinID="Download" OnClientClick='<%# "return Page_ClientValidate(""Download" & Container.DataItemIndex & """) && confirm(""Download record ?"");" %>' CommandName="DownloadWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Checked">
          <ItemTemplate>
            <asp:ImageButton ID="cmdUpdate" ValidationGroup='<%# "Update" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("UpdateWFVisible") %>' Enabled='<%# EVal("UpdateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Update" SkinID="complete" OnClientClick='<%# "return Page_ClientValidate(""Update" & Container.DataItemIndex & """) && confirm(""Cost sheet is checked ?"");" %>' CommandName="UpdateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODScostCostSheet"
      runat = "server"
      DataObjectTypeName = "SIS.COST.costCostSheet"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_costCostSheetSelectList"
      TypeName = "SIS.COST.costCostSheet"
      SelectCountMethod = "costCostSheetSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectGroupID" PropertyName="Text" Name="ProjectGroupID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_FinYear" PropertyName="Text" Name="FinYear" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_Quarter" PropertyName="Text" Name="Quarter" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_CreatedBy" PropertyName="Text" Name="CreatedBy" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_StatusID" PropertyName="Text" Name="StatusID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVcostCostSheet" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectGroupID" />
    <asp:AsyncPostBackTrigger ControlID="F_FinYear" />
    <asp:AsyncPostBackTrigger ControlID="F_Quarter" />
    <asp:AsyncPostBackTrigger ControlID="F_CreatedBy" />
    <asp:AsyncPostBackTrigger ControlID="F_StatusID" />
    <asp:PostBackTrigger ControlID="cmdFileUpload" />
    <asp:PostBackTrigger ControlID="cmdDownload" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
