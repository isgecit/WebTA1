<script type="text/javascript"> 
var script_costERPGLCodes = {
    validate_GLCode: function(sender) {
      var Prefix = sender.id.replace('GLCode','');
      this.validatePK_costERPGLCodes(sender,Prefix);
      },
    validatePK_costERPGLCodes: function(o,Prefix) {
      var value = o.id;
      try{$get(Prefix.replace('_F_','') + '_L_ErrMsgcostERPGLCodes').innerHTML = '';}catch(ex){}
      var GLCode = $get(Prefix + 'GLCode');
      if(GLCode.value=='')
        return true;
      value = value + ',' + GLCode.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validatePK_costERPGLCodes(value, this.validatedPK_costERPGLCodes);
    },
    validatedPK_costERPGLCodes: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        try{$get('cph1_FVcostERPGLCodes_L_ErrMsgcostERPGLCodes').innerHTML = p[2];}catch(ex){}
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
