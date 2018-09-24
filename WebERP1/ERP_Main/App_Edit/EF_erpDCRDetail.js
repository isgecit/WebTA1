<script type="text/javascript"> 
var script_erpDCRDetail = {
		ACEDCRNo_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('DCRNo','');
		  var F_DCRNo = $get(sender._element.id);
		  var F_DCRNo_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_DCRNo.value = p[0];
		  F_DCRNo_Display.innerHTML = e.get_text();
		},
		ACEDCRNo_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('DCRNo','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACEDCRNo_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		temp: function() {
		}
		}
</script>
