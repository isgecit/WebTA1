<script type="text/javascript"> 
var script_costAdjustmentEntry = {
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
    ACECrGLCode_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('CrGLCode','');
      var F_CrGLCode = $get(sender._element.id);
      var F_CrGLCode_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_CrGLCode.value = p[0];
      F_CrGLCode_Display.innerHTML = e.get_text();
    },
    ACECrGLCode_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('CrGLCode','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECrGLCode_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEDrGLCode_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('DrGLCode','');
      var F_DrGLCode = $get(sender._element.id);
      var F_DrGLCode_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_DrGLCode.value = p[0];
      F_DrGLCode_Display.innerHTML = e.get_text();
    },
    ACEDrGLCode_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('DrGLCode','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEDrGLCode_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_ProjectID: function(sender) {
      var Prefix = sender.id.replace('ProjectID','');
      this.validated_FK_COST_AdjustmentEntry_ProjectID_main = true;
      this.validate_FK_COST_AdjustmentEntry_ProjectID(sender,Prefix);
      },
    validate_CrGLCode: function(sender) {
      var Prefix = sender.id.replace('CrGLCode','');
      this.validated_FK_COST_AdjustmentEntry_CrGLCode_main = true;
      this.validate_FK_COST_AdjustmentEntry_CrGLCode(sender,Prefix);
      },
    validate_DrGLCode: function(sender) {
      var Prefix = sender.id.replace('DrGLCode','');
      this.validated_FK_COST_AdjustmentEntry_DrGLCode_main = true;
      this.validate_FK_COST_AdjustmentEntry_DrGLCode(sender,Prefix);
      },
    validate_FK_COST_AdjustmentEntry_CrGLCode: function(o,Prefix) {
      var value = o.id;
      var CrGLCode = $get(Prefix + 'CrGLCode');
      if(CrGLCode.value==''){
        if(this.validated_FK_COST_AdjustmentEntry_CrGLCode_main){
          var o_d = $get(Prefix + 'CrGLCode' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CrGLCode.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_COST_AdjustmentEntry_CrGLCode(value, this.validated_FK_COST_AdjustmentEntry_CrGLCode);
      },
    validated_FK_COST_AdjustmentEntry_CrGLCode_main: false,
    validated_FK_COST_AdjustmentEntry_CrGLCode: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_costAdjustmentEntry.validated_FK_COST_AdjustmentEntry_CrGLCode_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_COST_AdjustmentEntry_DrGLCode: function(o,Prefix) {
      var value = o.id;
      var DrGLCode = $get(Prefix + 'DrGLCode');
      if(DrGLCode.value==''){
        if(this.validated_FK_COST_AdjustmentEntry_DrGLCode_main){
          var o_d = $get(Prefix + 'DrGLCode' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + DrGLCode.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_COST_AdjustmentEntry_DrGLCode(value, this.validated_FK_COST_AdjustmentEntry_DrGLCode);
      },
    validated_FK_COST_AdjustmentEntry_DrGLCode_main: false,
    validated_FK_COST_AdjustmentEntry_DrGLCode: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_costAdjustmentEntry.validated_FK_COST_AdjustmentEntry_DrGLCode_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_COST_AdjustmentEntry_ProjectID: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_COST_AdjustmentEntry_ProjectID_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_COST_AdjustmentEntry_ProjectID(value, this.validated_FK_COST_AdjustmentEntry_ProjectID);
      },
    validated_FK_COST_AdjustmentEntry_ProjectID_main: false,
    validated_FK_COST_AdjustmentEntry_ProjectID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_costAdjustmentEntry.validated_FK_COST_AdjustmentEntry_ProjectID_main){
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
