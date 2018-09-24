<script type="text/javascript"> 
var script_costGLGroupGLs = {
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
    ACEGLCode_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('GLCode','');
      var F_GLCode = $get(sender._element.id);
      var F_GLCode_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_GLCode.value = p[0];
      F_GLCode_Display.innerHTML = e.get_text();
    },
    ACEGLCode_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('GLCode','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEGLCode_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_GLGroupID: function(sender) {
      var Prefix = sender.id.replace('GLGroupID','');
      this.validated_FK_COST_GLGroupGLs_GLGroupID_main = true;
      this.validate_FK_COST_GLGroupGLs_GLGroupID(sender,Prefix);
      },
    validate_GLCode: function(sender) {
      var Prefix = sender.id.replace('GLCode','');
      this.validated_FK_COST_GLGroupGLs_GLCode_main = true;
      this.validate_FK_COST_GLGroupGLs_GLCode(sender,Prefix);
      },
    validate_FK_COST_GLGroupGLs_GLGroupID: function(o,Prefix) {
      var value = o.id;
      var GLGroupID = $get(Prefix + 'GLGroupID');
      if(GLGroupID.value==''){
        if(this.validated_FK_COST_GLGroupGLs_GLGroupID_main){
          var o_d = $get(Prefix + 'GLGroupID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + GLGroupID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_COST_GLGroupGLs_GLGroupID(value, this.validated_FK_COST_GLGroupGLs_GLGroupID);
      },
    validated_FK_COST_GLGroupGLs_GLGroupID_main: false,
    validated_FK_COST_GLGroupGLs_GLGroupID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_costGLGroupGLs.validated_FK_COST_GLGroupGLs_GLGroupID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_COST_GLGroupGLs_GLCode: function(o,Prefix) {
      var value = o.id;
      var GLCode = $get(Prefix + 'GLCode');
      if(GLCode.value==''){
        if(this.validated_FK_COST_GLGroupGLs_GLCode_main){
          var o_d = $get(Prefix + 'GLCode' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + GLCode.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_COST_GLGroupGLs_GLCode(value, this.validated_FK_COST_GLGroupGLs_GLCode);
      },
    validated_FK_COST_GLGroupGLs_GLCode_main: false,
    validated_FK_COST_GLGroupGLs_GLCode: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_costGLGroupGLs.validated_FK_COST_GLGroupGLs_GLCode_main){
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
