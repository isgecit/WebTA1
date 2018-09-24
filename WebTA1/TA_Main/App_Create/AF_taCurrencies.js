<script type="text/javascript"> 
var script_taCurrencies = {
    validate_CurrencyID: function(sender) {
      var Prefix = sender.id.replace('CurrencyID','');
      this.validatePK_taCurrencies(sender,Prefix);
      },
    validatePK_taCurrencies: function(o,Prefix) {
      var value = o.id;
      try{$get(Prefix.replace('_F_','') + '_L_ErrMsgtaCurrencies').innerHTML = '';}catch(ex){}
      var CurrencyID = $get(Prefix + 'CurrencyID');
      if(CurrencyID.value=='')
        return true;
      value = value + ',' + CurrencyID.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validatePK_taCurrencies(value, this.validatedPK_taCurrencies);
    },
    validatedPK_taCurrencies: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        try{$get('cph1_FVtaCurrencies_L_ErrMsgtaCurrencies').innerHTML = p[2];}catch(ex){}
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
