<script type="text/javascript"> 
var script_costGLGroupGLs = {
    ACEGLGroupID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('GLGroupID','');
      var F_GLGroupID = $get(sender._element.id);
      var F_GLGroupID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_GLGroupID.value = p[0];
      F_GLGroupID_Display.innerHTML = e.get_text();
    },
    ACEGLGroupID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('GLGroupID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEGLGroupID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEGLCode_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('GLCode','');
      var F_GLCode = $get(sender._element.id);
      var F_GLCode_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_GLCode.value = p[0];
      F_GLCode_Display.innerHTML = e.get_text();
    },
    ACEGLCode_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('GLCode','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEGLCode_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    temp: function() {
    }
    }
</script>
