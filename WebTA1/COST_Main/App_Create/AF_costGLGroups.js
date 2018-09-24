<script type="text/javascript"> 
var script_costGLGroups = {
    ACECostGLGroupID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('CostGLGroupID','');
      var F_CostGLGroupID = $get(sender._element.id);
      var F_CostGLGroupID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_CostGLGroupID.value = p[0];
      F_CostGLGroupID_Display.innerHTML = e.get_text();
    },
    ACECostGLGroupID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('CostGLGroupID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECostGLGroupID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_CostGLGroupID: function(sender) {
      var Prefix = sender.id.replace('CostGLGroupID','');
      this.validated_FK_COST_GLGroups_CostGLGroupID_main = true;
      this.validate_FK_COST_GLGroups_CostGLGroupID(sender,Prefix);
      },
    validate_FK_COST_GLGroups_CostGLGroupID: function(o,Prefix) {
      var value = o.id;
      var CostGLGroupID = $get(Prefix + 'CostGLGroupID');
      if(CostGLGroupID.value==''){
        if(this.validated_FK_COST_GLGroups_CostGLGroupID_main){
          var o_d = $get(Prefix + 'CostGLGroupID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CostGLGroupID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_COST_GLGroups_CostGLGroupID(value, this.validated_FK_COST_GLGroups_CostGLGroupID);
      },
    validated_FK_COST_GLGroups_CostGLGroupID_main: false,
    validated_FK_COST_GLGroups_CostGLGroupID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_costGLGroups.validated_FK_COST_GLGroups_CostGLGroupID_main){
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
