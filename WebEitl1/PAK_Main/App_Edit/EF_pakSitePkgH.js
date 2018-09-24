<script type="text/javascript"> 
var script_pakSitePkgH = {
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
    ACEMRNNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('MRNNo','');
      var F_MRNNo = $get(sender._element.id);
      var F_MRNNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_MRNNo.value = p[1];
      F_MRNNo_Display.innerHTML = e.get_text();
    },
    ACEMRNNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('MRNNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEMRNNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACETransporterID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('TransporterID','');
      var F_TransporterID = $get(sender._element.id);
      var F_TransporterID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_TransporterID.value = p[0];
      F_TransporterID_Display.innerHTML = e.get_text();
    },
    ACETransporterID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('TransporterID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACETransporterID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEUOMTotalWeight_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('UOMTotalWeight','');
      var F_UOMTotalWeight = $get(sender._element.id);
      var F_UOMTotalWeight_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_UOMTotalWeight.value = p[0];
      F_UOMTotalWeight_Display.innerHTML = e.get_text();
    },
    ACEUOMTotalWeight_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('UOMTotalWeight','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEUOMTotalWeight_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_MRNNo: function(sender) {
      var Prefix = sender.id.replace('MRNNo','');
      this.validated_FK_PAK_SitePkgH_MRNNo_main = true;
      this.validate_FK_PAK_SitePkgH_MRNNo(sender,Prefix);
      },
    validate_TransporterID: function(sender) {
      var Prefix = sender.id.replace('TransporterID','');
      this.validated_FK_PAK_SitePkgH_TransporterID_main = true;
      this.validate_FK_PAK_SitePkgH_TransporterID(sender,Prefix);
      },
    validate_UOMTotalWeight: function(sender) {
      var Prefix = sender.id.replace('UOMTotalWeight','');
      this.validated_FK_PAK_SitePkgH_UOMTotalWeight_main = true;
      this.validate_FK_PAK_SitePkgH_UOMTotalWeight(sender,Prefix);
      },
    validate_FK_PAK_SitePkgH_UOMTotalWeight: function(o,Prefix) {
      var value = o.id;
      var UOMTotalWeight = $get(Prefix + 'UOMTotalWeight');
      if(UOMTotalWeight.value==''){
        if(this.validated_FK_PAK_SitePkgH_UOMTotalWeight_main){
          var o_d = $get(Prefix + 'UOMTotalWeight' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + UOMTotalWeight.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgH_UOMTotalWeight(value, this.validated_FK_PAK_SitePkgH_UOMTotalWeight);
      },
    validated_FK_PAK_SitePkgH_UOMTotalWeight_main: false,
    validated_FK_PAK_SitePkgH_UOMTotalWeight: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgH.validated_FK_PAK_SitePkgH_UOMTotalWeight_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SitePkgH_TransporterID: function(o,Prefix) {
      var value = o.id;
      var TransporterID = $get(Prefix + 'TransporterID');
      if(TransporterID.value==''){
        if(this.validated_FK_PAK_SitePkgH_TransporterID_main){
          var o_d = $get(Prefix + 'TransporterID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TransporterID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgH_TransporterID(value, this.validated_FK_PAK_SitePkgH_TransporterID);
      },
    validated_FK_PAK_SitePkgH_TransporterID_main: false,
    validated_FK_PAK_SitePkgH_TransporterID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgH.validated_FK_PAK_SitePkgH_TransporterID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SitePkgH_MRNNo: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_PAK_SitePkgH_MRNNo_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
      var MRNNo = $get(Prefix + 'MRNNo');
      if(MRNNo.value==''){
        if(this.validated_FK_PAK_SitePkgH_MRNNo_main){
          var o_d = $get(Prefix + 'MRNNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + MRNNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgH_MRNNo(value, this.validated_FK_PAK_SitePkgH_MRNNo);
      },
    validated_FK_PAK_SitePkgH_MRNNo_main: false,
    validated_FK_PAK_SitePkgH_MRNNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgH.validated_FK_PAK_SitePkgH_MRNNo_main){
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
