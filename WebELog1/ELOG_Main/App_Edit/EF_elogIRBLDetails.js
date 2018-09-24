<script type="text/javascript"> 
var script_elogIRBLDetails = {
    ACEIRNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('IRNo','');
      var F_IRNo = $get(sender._element.id);
      var F_IRNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_IRNo.value = p[0];
      F_IRNo_Display.innerHTML = e.get_text();
    },
    ACEIRNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('IRNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEIRNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    temp: function() {
    }
    }
</script>
