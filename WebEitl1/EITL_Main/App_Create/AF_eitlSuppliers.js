<script type="text/javascript"> 
var script_eitlSuppliers = {
		validate_SupplierID: function(sender) {
		  var Prefix = sender.id.replace('SupplierID','');
		  this.validatePK_eitlSuppliers(sender,Prefix);
		  },
		validatePK_eitlSuppliers: function(o,Prefix) {
		  var value = o.id;
		  try{$get(Prefix.replace('_F_','') + '_L_ErrMsgeitlSuppliers').innerHTML = '';}catch(ex){}
		  var SupplierID = $get(Prefix + 'SupplierID');
		  if(SupplierID.value=='')
		    return true;
		  value = value + ',' + SupplierID.value ;
		  o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		  o.style.backgroundRepeat= 'no-repeat';
		  o.style.backgroundPosition = 'right';
		  PageMethods.validatePK_eitlSuppliers(value, this.validatedPK_eitlSuppliers);
		},
		validatedPK_eitlSuppliers: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    try{$get('cph1_FVeitlSuppliers_L_ErrMsgeitlSuppliers').innerHTML = p[2];}catch(ex){}
		    o.value='';
		    o.focus();
		  }
		},
		temp: function() {
		}
		}
</script>
