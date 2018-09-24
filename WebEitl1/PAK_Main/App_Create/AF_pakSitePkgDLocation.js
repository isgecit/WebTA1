<script type="text/javascript"> 
var script_pakSitePkgDLocation = {
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
    ACERecNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('RecNo','');
      var F_RecNo = $get(sender._element.id);
      var F_RecNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_RecNo.value = p[1];
      F_RecNo_Display.innerHTML = e.get_text();
    },
    ACERecNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('RecNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACERecNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACERecSrNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('RecSrNo','');
      var F_RecSrNo = $get(sender._element.id);
      var F_RecSrNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_RecSrNo.value = p[2];
      F_RecSrNo_Display.innerHTML = e.get_text();
    },
    ACERecSrNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('RecSrNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACERecSrNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_RecSrNo: function(sender) {
      var Prefix = sender.id.replace('RecSrNo','');
      this.validated_FK_PAK_SitePkgDLocation_RecSrNo_main = true;
      this.validate_FK_PAK_SitePkgDLocation_RecSrNo(sender,Prefix);
      },
    validate_RecNo: function(sender) {
      var Prefix = sender.id.replace('RecNo','');
      this.validated_FK_PAK_SitePkgDLocation_RecNo_main = true;
      this.validate_FK_PAK_SitePkgDLocation_RecNo(sender,Prefix);
      },
    validate_ProjectID: function(sender) {
      var Prefix = sender.id.replace('ProjectID','');
      this.validated_FK_PAK_SitePkgDLocation_ProjectID_main = true;
      this.validate_FK_PAK_SitePkgDLocation_ProjectID(sender,Prefix);
      },
    validate_FK_PAK_SitePkgDLocation_ProjectID: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_PAK_SitePkgDLocation_ProjectID_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgDLocation_ProjectID(value, this.validated_FK_PAK_SitePkgDLocation_ProjectID);
      },
    validated_FK_PAK_SitePkgDLocation_ProjectID_main: false,
    validated_FK_PAK_SitePkgDLocation_ProjectID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgDLocation.validated_FK_PAK_SitePkgDLocation_ProjectID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SitePkgDLocation_SiteMarkNo: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_PAK_SitePkgDLocation_SiteMarkNo_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
      var SiteMarkNo = $get(Prefix + 'SiteMarkNo');
      if(SiteMarkNo.value==''){
        if(this.validated_FK_PAK_SitePkgDLocation_SiteMarkNo_main){
          var o_d = $get(Prefix + 'SiteMarkNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SiteMarkNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgDLocation_SiteMarkNo(value, this.validated_FK_PAK_SitePkgDLocation_SiteMarkNo);
      },
    validated_FK_PAK_SitePkgDLocation_SiteMarkNo_main: false,
    validated_FK_PAK_SitePkgDLocation_SiteMarkNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgDLocation.validated_FK_PAK_SitePkgDLocation_SiteMarkNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SitePkgDLocation_RecSrNo: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_PAK_SitePkgDLocation_RecSrNo_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
      var RecNo = $get(Prefix + 'RecNo');
      if(RecNo.value==''){
        if(this.validated_FK_PAK_SitePkgDLocation_RecSrNo_main){
          var o_d = $get(Prefix + 'RecNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + RecNo.value ;
      var RecSrNo = $get(Prefix + 'RecSrNo');
      if(RecSrNo.value==''){
        if(this.validated_FK_PAK_SitePkgDLocation_RecSrNo_main){
          var o_d = $get(Prefix + 'RecSrNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + RecSrNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgDLocation_RecSrNo(value, this.validated_FK_PAK_SitePkgDLocation_RecSrNo);
      },
    validated_FK_PAK_SitePkgDLocation_RecSrNo_main: false,
    validated_FK_PAK_SitePkgDLocation_RecSrNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgDLocation.validated_FK_PAK_SitePkgDLocation_RecSrNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SitePkgDLocation_RecNo: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_PAK_SitePkgDLocation_RecNo_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
      var RecNo = $get(Prefix + 'RecNo');
      if(RecNo.value==''){
        if(this.validated_FK_PAK_SitePkgDLocation_RecNo_main){
          var o_d = $get(Prefix + 'RecNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + RecNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgDLocation_RecNo(value, this.validated_FK_PAK_SitePkgDLocation_RecNo);
      },
    validated_FK_PAK_SitePkgDLocation_RecNo_main: false,
    validated_FK_PAK_SitePkgDLocation_RecNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgDLocation.validated_FK_PAK_SitePkgDLocation_RecNo_main){
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
