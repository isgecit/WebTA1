<script type="text/javascript"> 
var script_costProjectTypes = {
    validate_ProjectTypeID: function(sender) {
      var Prefix = sender.id.replace('ProjectTypeID','');
      this.validatePK_costProjectTypes(sender,Prefix);
      },
    validatePK_costProjectTypes: function(o,Prefix) {
      var value = o.id;
      try{$get(Prefix.replace('_F_','') + '_L_ErrMsgcostProjectTypes').innerHTML = '';}catch(ex){}
      var ProjectTypeID = $get(Prefix + 'ProjectTypeID');
      if(ProjectTypeID.value=='')
        return true;
      value = value + ',' + ProjectTypeID.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validatePK_costProjectTypes(value, this.validatedPK_costProjectTypes);
    },
    validatedPK_costProjectTypes: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        try{$get('cph1_FVcostProjectTypes_L_ErrMsgcostProjectTypes').innerHTML = p[2];}catch(ex){}
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
