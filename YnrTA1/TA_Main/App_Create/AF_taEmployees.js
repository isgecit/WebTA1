<script type="text/javascript"> 
var script_taEmployees = {
    ACETAVerifier_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('TAVerifier','');
      var F_TAVerifier = $get(sender._element.id);
      var F_TAVerifier_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_TAVerifier.value = p[0];
      F_TAVerifier_Display.innerHTML = e.get_text();
    },
    ACETAVerifier_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('TAVerifier','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACETAVerifier_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACETAApprover_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('TAApprover','');
      var F_TAApprover = $get(sender._element.id);
      var F_TAApprover_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_TAApprover.value = p[0];
      F_TAApprover_Display.innerHTML = e.get_text();
    },
    ACETAApprover_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('TAApprover','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACETAApprover_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACETASanctioningAuthority_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('TASanctioningAuthority','');
      var F_TASanctioningAuthority = $get(sender._element.id);
      var F_TASanctioningAuthority_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_TASanctioningAuthority.value = p[0];
      F_TASanctioningAuthority_Display.innerHTML = e.get_text();
    },
    ACETASanctioningAuthority_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('TASanctioningAuthority','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACETASanctioningAuthority_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_CardNo: function(sender) {
      var Prefix = sender.id.replace('CardNo','');
      this.validatePK_taEmployees(sender,Prefix);
      },
    validate_TAVerifier: function(sender) {
      var Prefix = sender.id.replace('TAVerifier','');
      this.validated_FK_HRM_Employees_TAVerifier_main = true;
      this.validate_FK_HRM_Employees_TAVerifier(sender,Prefix);
      },
    validate_TAApprover: function(sender) {
      var Prefix = sender.id.replace('TAApprover','');
      this.validated_FK_HRM_Employees_TAApprover_main = true;
      this.validate_FK_HRM_Employees_TAApprover(sender,Prefix);
      },
    validate_TASanctioningAuthority: function(sender) {
      var Prefix = sender.id.replace('TASanctioningAuthority','');
      this.validated_FK_HRM_Employees_TASanctioningAuthority_main = true;
      this.validate_FK_HRM_Employees_TASanctioningAuthority(sender,Prefix);
      },
    validate_FK_HRM_Employees_TAVerifier: function(o,Prefix) {
      var value = o.id;
      var TAVerifier = $get(Prefix + 'TAVerifier');
      if(TAVerifier.value==''){
        if(this.validated_FK_HRM_Employees_TAVerifier_main){
          var o_d = $get(Prefix + 'TAVerifier' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TAVerifier.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_HRM_Employees_TAVerifier(value, this.validated_FK_HRM_Employees_TAVerifier);
      },
    validated_FK_HRM_Employees_TAVerifier_main: false,
    validated_FK_HRM_Employees_TAVerifier: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taEmployees.validated_FK_HRM_Employees_TAVerifier_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_HRM_Employees_TAApprover: function(o,Prefix) {
      var value = o.id;
      var TAApprover = $get(Prefix + 'TAApprover');
      if(TAApprover.value==''){
        if(this.validated_FK_HRM_Employees_TAApprover_main){
          var o_d = $get(Prefix + 'TAApprover' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TAApprover.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_HRM_Employees_TAApprover(value, this.validated_FK_HRM_Employees_TAApprover);
      },
    validated_FK_HRM_Employees_TAApprover_main: false,
    validated_FK_HRM_Employees_TAApprover: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taEmployees.validated_FK_HRM_Employees_TAApprover_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_HRM_Employees_TASanctioningAuthority: function(o,Prefix) {
      var value = o.id;
      var TASanctioningAuthority = $get(Prefix + 'TASanctioningAuthority');
      if(TASanctioningAuthority.value==''){
        if(this.validated_FK_HRM_Employees_TASanctioningAuthority_main){
          var o_d = $get(Prefix + 'TASanctioningAuthority' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TASanctioningAuthority.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_HRM_Employees_TASanctioningAuthority(value, this.validated_FK_HRM_Employees_TASanctioningAuthority);
      },
    validated_FK_HRM_Employees_TASanctioningAuthority_main: false,
    validated_FK_HRM_Employees_TASanctioningAuthority: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taEmployees.validated_FK_HRM_Employees_TASanctioningAuthority_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validatePK_taEmployees: function(o,Prefix) {
      var value = o.id;
      try{$get(Prefix.replace('_F_','') + '_L_ErrMsgtaEmployees').innerHTML = '';}catch(ex){}
      var CardNo = $get(Prefix + 'CardNo');
      if(CardNo.value=='')
        return true;
      value = value + ',' + CardNo.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validatePK_taEmployees(value, this.validatedPK_taEmployees);
    },
    validatedPK_taEmployees: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        try{$get('cph1_FVtaEmployees_L_ErrMsgtaEmployees').innerHTML = p[2];}catch(ex){}
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
