<script type="text/javascript"> 
var script_taCities = {
    ACECountryID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('CountryID','');
      var F_CountryID = $get(sender._element.id);
      var F_CountryID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_CountryID.value = p[0];
      F_CountryID_Display.innerHTML = e.get_text();
    },
    ACECountryID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('CountryID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECountryID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_CityID: function(sender) {
      var Prefix = sender.id.replace('CityID','');
      this.validatePK_taCities(sender,Prefix);
      },
    validate_CountryID: function(sender) {
      var Prefix = sender.id.replace('CountryID','');
      this.validated_FK_TA_Cities_CountryID_main = true;
      this.validate_FK_TA_Cities_CountryID(sender,Prefix);
      },
    validate_FK_TA_Cities_CountryID: function(o,Prefix) {
      var value = o.id;
      var CountryID = $get(Prefix + 'CountryID');
      if(CountryID.value==''){
        if(this.validated_FK_TA_Cities_CountryID_main){
          var o_d = $get(Prefix + 'CountryID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CountryID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_Cities_CountryID(value, this.validated_FK_TA_Cities_CountryID);
      },
    validated_FK_TA_Cities_CountryID_main: false,
    validated_FK_TA_Cities_CountryID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taCities.validated_FK_TA_Cities_CountryID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validatePK_taCities: function(o,Prefix) {
      var value = o.id;
      try{$get(Prefix.replace('_F_','') + '_L_ErrMsgtaCities').innerHTML = '';}catch(ex){}
      var CityID = $get(Prefix + 'CityID');
      if(CityID.value=='')
        return true;
      value = value + ',' + CityID.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validatePK_taCities(value, this.validatedPK_taCities);
    },
    validatedPK_taCities: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        try{$get('cph1_FVtaCities_L_ErrMsgtaCities').innerHTML = p[2];}catch(ex){}
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
