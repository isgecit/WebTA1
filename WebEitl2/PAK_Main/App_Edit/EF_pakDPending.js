<script type="text/javascript"> 
var script_pakDPending = {
    ACESerialNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('SerialNo','');
      var F_SerialNo = $get(sender._element.id);
      var F_SerialNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_SerialNo.value = p[0];
      F_SerialNo_Display.innerHTML = e.get_text();
    },
    ACESerialNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('SerialNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACESerialNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEPkgNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('PkgNo','');
      var F_PkgNo = $get(sender._element.id);
      var F_PkgNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_PkgNo.value = p[1];
      F_PkgNo_Display.innerHTML = e.get_text();
    },
    ACEPkgNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('PkgNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEPkgNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEBOMNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('BOMNo','');
      var F_BOMNo = $get(sender._element.id);
      var F_BOMNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_BOMNo.value = p[1];
      F_BOMNo_Display.innerHTML = e.get_text();
    },
    ACEBOMNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('BOMNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEBOMNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEItemNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ItemNo','');
      var F_ItemNo = $get(sender._element.id);
      var F_ItemNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ItemNo.value = p[2];
      F_ItemNo_Display.innerHTML = e.get_text();
    },
    ACEItemNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ItemNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEItemNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    temp: function() {
    }
    }
</script>
