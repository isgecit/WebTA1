<script type="text/javascript"> 
var script_nprkSiteAllowanceClaims = {
    validate_FinYear: function(sender) {
      var Prefix = sender.id.replace('FinYear','');
      this.validatePK_nprkSiteAllowanceClaims(sender,Prefix);
      },
    validate_Quarter: function(sender) {
      var Prefix = sender.id.replace('Quarter','');
      this.validatePK_nprkSiteAllowanceClaims(sender,Prefix);
      },
    validatePK_nprkSiteAllowanceClaims: function(o,Prefix) {
      var value = o.id;
      try{$get(Prefix.replace('_F_','') + '_L_ErrMsgnprkSiteAllowanceClaims').innerHTML = '';}catch(ex){}
      var FinYear = $get(Prefix + 'FinYear.replace('_F_','_DDL')');
      if(FinYear.value=='')
        return true;
      value = value + ',' + FinYear.value ;
      var Quarter = $get(Prefix + 'Quarter.replace('_F_','_DDL')');
      if(Quarter.value=='')
        return true;
      value = value + ',' + Quarter.value ;
      var EmployeeID = $get(Prefix + 'EmployeeID');
      if(EmployeeID.value=='')
        return true;
      value = value + ',' + EmployeeID.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validatePK_nprkSiteAllowanceClaims(value, this.validatedPK_nprkSiteAllowanceClaims);
    },
    validatedPK_nprkSiteAllowanceClaims: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        try{$get('cph1_FVnprkSiteAllowanceClaims_L_ErrMsgnprkSiteAllowanceClaims').innerHTML = p[2];}catch(ex){}
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
