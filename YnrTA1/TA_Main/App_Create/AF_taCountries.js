<script type="text/javascript"> 
var script_taCountries = {
    validate_CountryID: function(sender) {
      var Prefix = sender.id.replace('CountryID','');
      this.validatePK_taCountries(sender,Prefix);
      },
    validatePK_taCountries: function(o,Prefix) {
      var value = o.id;
      try{$get(Prefix.replace('_F_','') + '_L_ErrMsgtaCountries').innerHTML = '';}catch(ex){}
      var CountryID = $get(Prefix + 'CountryID');
      if(CountryID.value=='')
        return true;
      value = value + ',' + CountryID.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validatePK_taCountries(value, this.validatedPK_taCountries);
    },
    validatedPK_taCountries: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        try{$get('cph1_FVtaCountries_L_ErrMsgtaCountries').innerHTML = p[2];}catch(ex){}
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
