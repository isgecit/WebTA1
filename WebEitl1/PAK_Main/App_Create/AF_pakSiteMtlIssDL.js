<script type="text/javascript"> 
var script_pakSiteMtlIssDL = {
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
    ACEIssueNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('IssueNo','');
      var F_IssueNo = $get(sender._element.id);
      var F_IssueNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_IssueNo.value = p[1];
      F_IssueNo_Display.innerHTML = e.get_text();
    },
    ACEIssueNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('IssueNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEIssueNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEIssueSrNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('IssueSrNo','');
      var F_IssueSrNo = $get(sender._element.id);
      var F_IssueSrNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_IssueSrNo.value = p[2];
      F_IssueSrNo_Display.innerHTML = e.get_text();
    },
    ACEIssueSrNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('IssueSrNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEIssueSrNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACESiteMarkNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('SiteMarkNo','');
      var F_SiteMarkNo = $get(sender._element.id);
      var F_SiteMarkNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_SiteMarkNo.value = p[1];
      F_SiteMarkNo_Display.innerHTML = e.get_text();
    },
    ACESiteMarkNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('SiteMarkNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACESiteMarkNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_SiteMarkNo: function(sender) {
      var Prefix = sender.id.replace('SiteMarkNo','');
      this.validated_FK_PAK_SiteIssueDLocation_SiteMarkNo_main = true;
      this.validate_FK_PAK_SiteIssueDLocation_SiteMarkNo(sender,Prefix);
      },
    validate_IssueNo: function(sender) {
      var Prefix = sender.id.replace('IssueNo','');
      this.validated_FK_PAK_SiteIssueDLocation_IssueNo_main = true;
      this.validate_FK_PAK_SiteIssueDLocation_IssueNo(sender,Prefix);
      },
    validate_ProjectID: function(sender) {
      var Prefix = sender.id.replace('ProjectID','');
      this.validated_FK_PAK_SiteIssueDLocation_ProjectID_main = true;
      this.validate_FK_PAK_SiteIssueDLocation_ProjectID(sender,Prefix);
      },
    validate_IssueSrNo: function(sender) {
      var Prefix = sender.id.replace('IssueSrNo','');
      this.validated_FK_PAK_SiteIssueDLocation_IssueSrNo_main = true;
      this.validate_FK_PAK_SiteIssueDLocation_IssueSrNo(sender,Prefix);
      },
    validate_FK_PAK_SiteIssueDLocation_ProjectID: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_PAK_SiteIssueDLocation_ProjectID_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SiteIssueDLocation_ProjectID(value, this.validated_FK_PAK_SiteIssueDLocation_ProjectID);
      },
    validated_FK_PAK_SiteIssueDLocation_ProjectID_main: false,
    validated_FK_PAK_SiteIssueDLocation_ProjectID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSiteMtlIssDL.validated_FK_PAK_SiteIssueDLocation_ProjectID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SiteIssueDLocation_IssueSrNo: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_PAK_SiteIssueDLocation_IssueSrNo_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
      var IssueNo = $get(Prefix + 'IssueNo');
      if(IssueNo.value==''){
        if(this.validated_FK_PAK_SiteIssueDLocation_IssueSrNo_main){
          var o_d = $get(Prefix + 'IssueNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + IssueNo.value ;
      var IssueSrNo = $get(Prefix + 'IssueSrNo');
      if(IssueSrNo.value==''){
        if(this.validated_FK_PAK_SiteIssueDLocation_IssueSrNo_main){
          var o_d = $get(Prefix + 'IssueSrNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + IssueSrNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SiteIssueDLocation_IssueSrNo(value, this.validated_FK_PAK_SiteIssueDLocation_IssueSrNo);
      },
    validated_FK_PAK_SiteIssueDLocation_IssueSrNo_main: false,
    validated_FK_PAK_SiteIssueDLocation_IssueSrNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSiteMtlIssDL.validated_FK_PAK_SiteIssueDLocation_IssueSrNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SiteIssueDLocation_IssueNo: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_PAK_SiteIssueDLocation_IssueNo_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
      var IssueNo = $get(Prefix + 'IssueNo');
      if(IssueNo.value==''){
        if(this.validated_FK_PAK_SiteIssueDLocation_IssueNo_main){
          var o_d = $get(Prefix + 'IssueNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + IssueNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SiteIssueDLocation_IssueNo(value, this.validated_FK_PAK_SiteIssueDLocation_IssueNo);
      },
    validated_FK_PAK_SiteIssueDLocation_IssueNo_main: false,
    validated_FK_PAK_SiteIssueDLocation_IssueNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSiteMtlIssDL.validated_FK_PAK_SiteIssueDLocation_IssueNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SiteIssueDLocation_SiteMarkNo: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_PAK_SiteIssueDLocation_SiteMarkNo_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
      var SiteMarkNo = $get(Prefix + 'SiteMarkNo');
      if(SiteMarkNo.value==''){
        if(this.validated_FK_PAK_SiteIssueDLocation_SiteMarkNo_main){
          var o_d = $get(Prefix + 'SiteMarkNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SiteMarkNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SiteIssueDLocation_SiteMarkNo(value, this.validated_FK_PAK_SiteIssueDLocation_SiteMarkNo);
      },
    validated_FK_PAK_SiteIssueDLocation_SiteMarkNo_main: false,
    validated_FK_PAK_SiteIssueDLocation_SiteMarkNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSiteMtlIssDL.validated_FK_PAK_SiteIssueDLocation_SiteMarkNo_main){
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
