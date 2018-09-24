<script type="text/javascript"> 
var script_costCSDataWOnGLGroup = {
    ACEProjectGroupID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ProjectGroupID','');
      var F_ProjectGroupID = $get(sender._element.id);
      var F_ProjectGroupID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ProjectGroupID.value = p[0];
      F_ProjectGroupID_Display.innerHTML = e.get_text();
    },
    ACEProjectGroupID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ProjectGroupID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEProjectGroupID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEFinYear_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('FinYear','');
      var F_FinYear = $get(sender._element.id);
      var F_FinYear_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_FinYear.value = p[0];
      F_FinYear_Display.innerHTML = e.get_text();
    },
    ACEFinYear_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('FinYear','');
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
      var Prefix = sender._element.id.replace('Quarter','');
      var F_Quarter = $get(sender._element.id);
      var F_Quarter_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_Quarter.value = p[0];
      F_Quarter_Display.innerHTML = e.get_text();
    },
    ACEQuarter_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('Quarter','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEQuarter_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEGLGroupID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('GLGroupID','');
      var F_GLGroupID = $get(sender._element.id);
      var F_GLGroupID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_GLGroupID.value = p[0];
      F_GLGroupID_Display.innerHTML = e.get_text();
    },
    ACEGLGroupID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('GLGroupID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEGLGroupID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_ProjectGroupID: function(sender) {
      var Prefix = sender.id.replace('ProjectGroupID','');
      this.validated_FK_COST_CSDataWOnGLGroup_ProjectGroupID_main = true;
      this.validate_FK_COST_CSDataWOnGLGroup_ProjectGroupID(sender,Prefix);
      },
    validate_FinYear: function(sender) {
      var Prefix = sender.id.replace('FinYear','');
      this.validated_FK_COST_CSDataWOnGLGroup_FinYear_main = true;
      this.validate_FK_COST_CSDataWOnGLGroup_FinYear(sender,Prefix);
      },
    validate_Quarter: function(sender) {
      var Prefix = sender.id.replace('Quarter','');
      this.validated_FK_COST_CSDataWOnGLGroup_Quarter_main = true;
      this.validate_FK_COST_CSDataWOnGLGroup_Quarter(sender,Prefix);
      },
    validate_GLGroupID: function(sender) {
      var Prefix = sender.id.replace('GLGroupID','');
      this.validated_FK_COST_CSDataWOnGLGroup_GLGroupID_main = true;
      this.validate_FK_COST_CSDataWOnGLGroup_GLGroupID(sender,Prefix);
      },
    validate_FK_COST_CSDataWOnGLGroup_FinYear: function(o,Prefix) {
      var value = o.id;
      var FinYear = $get(Prefix + 'FinYear');
      if(FinYear.value==''){
        if(this.validated_FK_COST_CSDataWOnGLGroup_FinYear_main){
          var o_d = $get(Prefix + 'FinYear' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + FinYear.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_COST_CSDataWOnGLGroup_FinYear(value, this.validated_FK_COST_CSDataWOnGLGroup_FinYear);
      },
    validated_FK_COST_CSDataWOnGLGroup_FinYear_main: false,
    validated_FK_COST_CSDataWOnGLGroup_FinYear: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_costCSDataWOnGLGroup.validated_FK_COST_CSDataWOnGLGroup_FinYear_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_COST_CSDataWOnGLGroup_GLGroupID: function(o,Prefix) {
      var value = o.id;
      var GLGroupID = $get(Prefix + 'GLGroupID');
      if(GLGroupID.value==''){
        if(this.validated_FK_COST_CSDataWOnGLGroup_GLGroupID_main){
          var o_d = $get(Prefix + 'GLGroupID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + GLGroupID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_COST_CSDataWOnGLGroup_GLGroupID(value, this.validated_FK_COST_CSDataWOnGLGroup_GLGroupID);
      },
    validated_FK_COST_CSDataWOnGLGroup_GLGroupID_main: false,
    validated_FK_COST_CSDataWOnGLGroup_GLGroupID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_costCSDataWOnGLGroup.validated_FK_COST_CSDataWOnGLGroup_GLGroupID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_COST_CSDataWOnGLGroup_ProjectGroupID: function(o,Prefix) {
      var value = o.id;
      var ProjectGroupID = $get(Prefix + 'ProjectGroupID');
      if(ProjectGroupID.value==''){
        if(this.validated_FK_COST_CSDataWOnGLGroup_ProjectGroupID_main){
          var o_d = $get(Prefix + 'ProjectGroupID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectGroupID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_COST_CSDataWOnGLGroup_ProjectGroupID(value, this.validated_FK_COST_CSDataWOnGLGroup_ProjectGroupID);
      },
    validated_FK_COST_CSDataWOnGLGroup_ProjectGroupID_main: false,
    validated_FK_COST_CSDataWOnGLGroup_ProjectGroupID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_costCSDataWOnGLGroup.validated_FK_COST_CSDataWOnGLGroup_ProjectGroupID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_COST_CSDataWOnGLGroup_Quarter: function(o,Prefix) {
      var value = o.id;
      var Quarter = $get(Prefix + 'Quarter');
      if(Quarter.value==''){
        if(this.validated_FK_COST_CSDataWOnGLGroup_Quarter_main){
          var o_d = $get(Prefix + 'Quarter' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + Quarter.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_COST_CSDataWOnGLGroup_Quarter(value, this.validated_FK_COST_CSDataWOnGLGroup_Quarter);
      },
    validated_FK_COST_CSDataWOnGLGroup_Quarter_main: false,
    validated_FK_COST_CSDataWOnGLGroup_Quarter: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_costCSDataWOnGLGroup.validated_FK_COST_CSDataWOnGLGroup_Quarter_main){
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
