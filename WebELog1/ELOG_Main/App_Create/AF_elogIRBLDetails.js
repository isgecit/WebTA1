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
    validate_IRNo: function(sender) {
      var Prefix = sender.id.replace('IRNo','');
      this.validated_FK_ELOG_IRBLDetails_IRNo_main = true;
      this.validate_FK_ELOG_IRBLDetails_IRNo(sender,Prefix);
      },
    validate_FK_ELOG_IRBLDetails_IRNo: function(o,Prefix) {
      var value = o.id;
      var IRNo = $get(Prefix + 'IRNo');
      if(IRNo.value==''){
        if(this.validated_FK_ELOG_IRBLDetails_IRNo_main){
          var o_d = $get(Prefix + 'IRNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + IRNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_ELOG_IRBLDetails_IRNo(value, this.validated_FK_ELOG_IRBLDetails_IRNo);
      },
    validated_FK_ELOG_IRBLDetails_IRNo_main: false,
    validated_FK_ELOG_IRBLDetails_IRNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_elogIRBLDetails.validated_FK_ELOG_IRBLDetails_IRNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
