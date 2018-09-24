<script type="text/javascript"> 
var script_lgWTAttributes = {
		ACEDocPK_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('DocPK','');
		  var F_DocPK = $get(sender._element.id);
		  var F_DocPK_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_DocPK.value = p[0];
		  F_DocPK_Display.innerHTML = e.get_text();
		},
		ACEDocPK_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('DocPK','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACEDocPK_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		temp: function() {
		}
		}
</script>
