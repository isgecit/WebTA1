<script type="text/javascript"> 
var script_nprkApplications = {
    ACEClaimID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ClaimID','');
      var F_ClaimID = $get(sender._element.id);
      var F_ClaimID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ClaimID.value = p[0];
      F_ClaimID_Display.innerHTML = e.get_text();
    },
    ACEClaimID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ClaimID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEClaimID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    temp: function() {
    }
    }
</script>
