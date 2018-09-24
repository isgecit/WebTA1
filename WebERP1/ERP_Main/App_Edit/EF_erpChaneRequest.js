<script type="text/javascript"> 
var script_erpChaneRequest = {
		ACEApplID_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('ApplID','');
		  var F_ApplID = $get(sender._element.id);
		  var F_ApplID_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_ApplID.value = p[0];
		  F_ApplID_Display.innerHTML = e.get_text();
		},
		ACEApplID_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('ApplID','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACEApplID_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		validate_RequestTypeID: function(sender) {
		  var Prefix = sender.id.replace('RequestTypeID','');
		  this.validated_FK_ERP_ChaneRequest_RequestTypeID_main = true;
		  this.validate_FK_ERP_ChaneRequest_RequestTypeID(sender,Prefix);
		  },
		temp: function() {
		}
		}
</script>
