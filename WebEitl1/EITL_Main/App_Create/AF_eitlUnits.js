<script type="text/javascript"> 
var script_eitlUnits = {
		validate_UnitID: function(sender) {
		  var Prefix = sender.id.replace('UnitID','');
		  this.validatePK_eitlUnits(sender,Prefix);
		  },
		validatePK_eitlUnits: function(o,Prefix) {
		  var value = o.id;
		  try{$get(Prefix.replace('_F_','') + '_L_ErrMsgeitlUnits').innerHTML = '';}catch(ex){}
		  var UnitID = $get(Prefix + 'UnitID');
		  if(UnitID.value=='')
		    return true;
		  value = value + ',' + UnitID.value ;
		  o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		  o.style.backgroundRepeat= 'no-repeat';
		  o.style.backgroundPosition = 'right';
		  PageMethods.validatePK_eitlUnits(value, this.validatedPK_eitlUnits);
		},
		validatedPK_eitlUnits: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    try{$get('cph1_FVeitlUnits_L_ErrMsgeitlUnits').innerHTML = p[2];}catch(ex){}
		    o.value='';
		    o.focus();
		  }
		},
		temp: function() {
		}
		}
</script>
