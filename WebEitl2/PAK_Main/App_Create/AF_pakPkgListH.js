<script type="text/javascript"> 
var script_pakPkgListH = {
    ACESerialNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('SerialNo','');
      var F_SerialNo = $get(sender._element.id);
      var F_SerialNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_SerialNo.value = p[0];
      F_SerialNo_Display.innerHTML = e.get_text();
    },
    ACESerialNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('SerialNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACESerialNo_Populated: function(sender,e) {
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
      sender._contextKey = $get(Prefix+'SerialNo').value;
    },
    ACETransporterID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEVRExecutionNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('VRExecutionNo','');
      var F_VRExecutionNo = $get(sender._element.id);
      var F_VRExecutionNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_VRExecutionNo.value = p[0];
      F_VRExecutionNo_Display.innerHTML = e.get_text();
    },
    ACEVRExecutionNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('VRExecutionNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = $get(Prefix+'SerialNo').value;
    },
    ACEVRExecutionNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_SerialNo: function(sender) {
      var Prefix = sender.id.replace('SerialNo','');
      this.validated_FK_PAK_PkgListH_SerialNo_main = true;
      this.validate_FK_PAK_PkgListH_SerialNo(sender,Prefix);
      },
    validate_TransporterID: function(sender) {
      var Prefix = sender.id.replace('TransporterID','');
      this.validated_FK_PAK_PkgListH_TransporterID_main = true;
      this.validate_FK_PAK_PkgListH_TransporterID(sender,Prefix);
      },
    validate_VRExecutionNo: function(sender) {
      var Prefix = sender.id.replace('VRExecutionNo','');
      this.validated_FK_PAK_PkgListH_VRExecutionNo_main = true;
      this.validate_FK_PAK_PkgListH_VRExecutionNo(sender,Prefix);
      },
    validate_FK_PAK_PkgListH_SerialNo: function(o,Prefix) {
      var value = o.id;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_PAK_PkgListH_SerialNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_PkgListH_SerialNo(value, this.validated_FK_PAK_PkgListH_SerialNo);
      },
    validated_FK_PAK_PkgListH_SerialNo_main: false,
    validated_FK_PAK_PkgListH_SerialNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakPkgListH.validated_FK_PAK_PkgListH_SerialNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_PkgListH_TransporterID: function(o,Prefix) {
      var value = o.id;
      var TransporterID = $get(Prefix + 'TransporterID');
      if(TransporterID.value==''){
        if(this.validated_FK_PAK_PkgListH_TransporterID_main){
          var o_d = $get(Prefix + 'TransporterID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TransporterID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_PkgListH_TransporterID(value, this.validated_FK_PAK_PkgListH_TransporterID);
      },
    validated_FK_PAK_PkgListH_TransporterID_main: false,
    validated_FK_PAK_PkgListH_TransporterID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakPkgListH.validated_FK_PAK_PkgListH_TransporterID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_PkgListH_VRExecutionNo: function(o,Prefix) {
      var value = o.id;
      var VRExecutionNo = $get(Prefix + 'VRExecutionNo');
      if(VRExecutionNo.value==''){
        if(this.validated_FK_PAK_PkgListH_VRExecutionNo_main){
          var o_d = $get(Prefix + 'VRExecutionNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + VRExecutionNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_PkgListH_VRExecutionNo(value, this.validated_FK_PAK_PkgListH_VRExecutionNo);
      },
    validated_FK_PAK_PkgListH_VRExecutionNo_main: false,
    validated_FK_PAK_PkgListH_VRExecutionNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakPkgListH.validated_FK_PAK_PkgListH_VRExecutionNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
        try{$get(p[1].replace('VRExecutionNo','TransporterID')).value = p[3];}catch(ex){}
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
