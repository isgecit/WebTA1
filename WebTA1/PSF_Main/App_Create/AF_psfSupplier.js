<script type="text/javascript"> 
var script_psfSupplier = {
    validate_SupplierID: function(sender) {
      var Prefix = sender.id.replace('SupplierID','');
      this.validatePK_psfSupplier(sender,Prefix);
      },
    validatePK_psfSupplier: function(o,Prefix) {
      var value = o.id;
      try{$get(Prefix.replace('_F_','') + '_L_ErrMsgpsfSupplier').innerHTML = '';}catch(ex){}
      var SupplierID = $get(Prefix + 'SupplierID');
      if(SupplierID.value=='')
        return true;
      value = value + ',' + SupplierID.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validatePK_psfSupplier(value, this.validatedPK_psfSupplier);
    },
    validatedPK_psfSupplier: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        try{$get('cph1_FVpsfSupplier_L_ErrMsgpsfSupplier').innerHTML = p[2];}catch(ex){}
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
