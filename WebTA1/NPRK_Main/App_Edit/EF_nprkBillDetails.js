<script type="text/javascript"> 
var script_nprkBillDetails = {
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
    ACEApplicationID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ApplicationID','');
      var F_ApplicationID = $get(sender._element.id);
      var F_ApplicationID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ApplicationID.value = p[1];
      F_ApplicationID_Display.innerHTML = e.get_text();
    },
    ACEApplicationID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ApplicationID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEApplicationID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    temp: function() {
    }
    }
</script>
