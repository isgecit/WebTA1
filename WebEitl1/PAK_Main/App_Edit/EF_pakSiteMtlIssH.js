<script type="text/javascript"> 
var script_pakSiteMtlIssH = {
    ACEProjectID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ProjectID','');
      var F_ProjectID = $get(sender._element.id);
      var F_ProjectID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ProjectID.value = p[0];
      F_ProjectID_Display.innerHTML = e.get_text();
    },
    ACEProjectID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ProjectID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEProjectID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEIssueToCardNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('IssueToCardNo','');
      var F_IssueToCardNo = $get(sender._element.id);
      var F_IssueToCardNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_IssueToCardNo_Display.innerHTML = e.get_text();
    },
    ACEIssueToCardNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('IssueToCardNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEIssueToCardNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_IssueToCardNo: function(sender) {
      var Prefix = sender.id.replace('IssueToCardNo','');
      this.validated_FK_PAK_SiteIssueH_IssueToCardNo_main = true;
      this.validate_FK_PAK_SiteIssueH_IssueToCardNo(sender,Prefix);
      },
    validate_FK_PAK_SiteIssueH_IssueToCardNo: function(o,Prefix) {
      var value = o.id;
      var IssueToCardNo = $get(Prefix + 'IssueToCardNo');
      if(IssueToCardNo.value==''){
        if(this.validated_FK_PAK_SiteIssueH_IssueToCardNo_main){
          var o_d = $get(Prefix + 'IssueToCardNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + IssueToCardNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SiteIssueH_IssueToCardNo(value, this.validated_FK_PAK_SiteIssueH_IssueToCardNo);
      },
    validated_FK_PAK_SiteIssueH_IssueToCardNo_main: false,
    validated_FK_PAK_SiteIssueH_IssueToCardNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSiteMtlIssH.validated_FK_PAK_SiteIssueH_IssueToCardNo_main){
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
