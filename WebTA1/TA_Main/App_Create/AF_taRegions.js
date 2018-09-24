<script type="text/javascript"> 
var script_taRegions = {
    validate_RegionID: function(sender) {
      var Prefix = sender.id.replace('RegionID','');
      this.validatePK_taRegions(sender,Prefix);
      },
    validatePK_taRegions: function(o,Prefix) {
      var value = o.id;
      try{$get(Prefix.replace('_F_','') + '_L_ErrMsgtaRegions').innerHTML = '';}catch(ex){}
      var RegionID = $get(Prefix + 'RegionID');
      if(RegionID.value=='')
        return true;
      value = value + ',' + RegionID.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validatePK_taRegions(value, this.validatedPK_taRegions);
    },
    validatedPK_taRegions: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        try{$get('cph1_FVtaRegions_L_ErrMsgtaRegions').innerHTML = p[2];}catch(ex){}
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
