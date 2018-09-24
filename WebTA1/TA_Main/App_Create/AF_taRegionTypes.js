<script type="text/javascript"> 
var script_taRegionTypes = {
    validate_RegionTypeID: function(sender) {
      var Prefix = sender.id.replace('RegionTypeID','');
      this.validatePK_taRegionTypes(sender,Prefix);
      },
    validatePK_taRegionTypes: function(o,Prefix) {
      var value = o.id;
      try{$get(Prefix.replace('_F_','') + '_L_ErrMsgtaRegionTypes').innerHTML = '';}catch(ex){}
      var RegionTypeID = $get(Prefix + 'RegionTypeID');
      if(RegionTypeID.value=='')
        return true;
      value = value + ',' + RegionTypeID.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validatePK_taRegionTypes(value, this.validatedPK_taRegionTypes);
    },
    validatedPK_taRegionTypes: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        try{$get('cph1_FVtaRegionTypes_L_ErrMsgtaRegionTypes').innerHTML = p[2];}catch(ex){}
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
