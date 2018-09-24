<script type="text/javascript"> 
var script_elogBLDetails = {
    ACEBLID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('BLID','');
      var F_BLID = $get(sender._element.id);
      var F_BLID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_BLID.value = p[0];
      F_BLID_Display.innerHTML = e.get_text();
    },
    ACEBLID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('BLID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEBLID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    temp: function() {
    }
    }
</script>
