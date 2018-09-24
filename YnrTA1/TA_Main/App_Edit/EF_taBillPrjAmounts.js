<script type="text/javascript"> 
var script_taBillPrjAmounts = {
    ACETABillNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('TABillNo','');
      var F_TABillNo = $get(sender._element.id);
      var F_TABillNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_TABillNo.value = p[0];
      F_TABillNo_Display.innerHTML = e.get_text();
    },
    ACETABillNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('TABillNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACETABillNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    temp: function() {
    }
    }
</script>
