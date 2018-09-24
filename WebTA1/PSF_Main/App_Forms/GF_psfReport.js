<script type="text/javascript"> 
var script_psfReport = {
    ACEFSupplierCode_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('FSupplierCode','');
      var F_FSupplierCode = $get(sender._element.id);
      var F_FSupplierCode_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_FSupplierCode.value = p[0];
      F_FSupplierCode_Display.innerHTML = e.get_text();
    },
    ACEFSupplierCode_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('FSupplierCode','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEFSupplierCode_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACETSupplierCode_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('TSupplierCode','');
      var F_TSupplierCode = $get(sender._element.id);
      var F_TSupplierCode_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_TSupplierCode.value = p[0];
      F_TSupplierCode_Display.innerHTML = e.get_text();
    },
    ACETSupplierCode_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('TSupplierCode','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACETSupplierCode_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_FSupplierCode: function(sender) {
      var Prefix = sender.id.replace('FSupplierCode','');
      this.validated_FK_PSF_HSBCMain_FSupplierID_main = true;
      this.validate_FK_PSF_HSBCMain_FSupplierID(sender,Prefix);
      },
    validate_TSupplierCode: function(sender) {
      var Prefix = sender.id.replace('TSupplierCode','');
      this.validated_FK_PSF_HSBCMain_TSupplierID_main = true;
      this.validate_FK_PSF_HSBCMain_TSupplierID(sender,Prefix);
      },
    validate_FK_PSF_HSBCMain_FSupplierID: function(o,Prefix) {
      var value = o.id;
      var FSupplierCode = $get(Prefix + 'FSupplierCode');
      if(FSupplierCode.value==''){
        if(this.validated_FK_PSF_HSBCMain_FSupplierID_main){
          var o_d = $get(Prefix + 'FSupplierCode' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + FSupplierCode.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PSF_HSBCMain_FSupplierID(value, this.validated_FK_PSF_HSBCMain_FSupplierID);
      },
    validated_FK_PSF_HSBCMain_FSupplierID_main: false,
    validated_FK_PSF_HSBCMain_FSupplierID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_psfReport.validated_FK_PSF_HSBCMain_FSupplierID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PSF_HSBCMain_TSupplierID: function(o,Prefix) {
      var value = o.id;
      var TSupplierCode = $get(Prefix + 'TSupplierCode');
      if(TSupplierCode.value==''){
        if(this.validated_FK_PSF_HSBCMain_TSupplierID_main){
          var o_d = $get(Prefix + 'TSupplierCode' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TSupplierCode.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PSF_HSBCMain_TSupplierID(value, this.validated_FK_PSF_HSBCMain_TSupplierID);
      },
    validated_FK_PSF_HSBCMain_TSupplierID_main: false,
    validated_FK_PSF_HSBCMain_TSupplierID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_psfReport.validated_FK_PSF_HSBCMain_TSupplierID_main){
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
