<script type="text/javascript"> 
var script_taCityTypes = {
    validate_CityTypeID: function(sender) {
      var Prefix = sender.id.replace('CityTypeID','');
      this.validatePK_taCityTypes(sender,Prefix);
      },
    validatePK_taCityTypes: function(o,Prefix) {
      var value = o.id;
      try{$get(Prefix.replace('_F_','') + '_L_ErrMsgtaCityTypes').innerHTML = '';}catch(ex){}
      var CityTypeID = $get(Prefix + 'CityTypeID');
      if(CityTypeID.value=='')
        return true;
      value = value + ',' + CityTypeID.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validatePK_taCityTypes(value, this.validatedPK_taCityTypes);
    },
    validatedPK_taCityTypes: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        try{$get('cph1_FVtaCityTypes_L_ErrMsgtaCityTypes').innerHTML = p[2];}catch(ex){}
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
