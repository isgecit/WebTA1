<script type="text/javascript"> 
var script_taDivisions = {
    ACEDivisionHead_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('DivisionHead','');
      var F_DivisionHead = $get(sender._element.id);
      var F_DivisionHead_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_DivisionHead.value = p[0];
      F_DivisionHead_Display.innerHTML = e.get_text();
    },
    ACEDivisionHead_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('DivisionHead','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEDivisionHead_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_DivisionHead: function(sender) {
      var Prefix = sender.id.replace('DivisionHead','');
      this.validated_FK_HRM_Divisions_DivisionHead_main = true;
      this.validate_FK_HRM_Divisions_DivisionHead(sender,Prefix);
      },
    validate_FK_HRM_Divisions_DivisionHead: function(o,Prefix) {
      var value = o.id;
      var DivisionHead = $get(Prefix + 'DivisionHead');
      if(DivisionHead.value==''){
        if(this.validated_FK_HRM_Divisions_DivisionHead_main){
          var o_d = $get(Prefix + 'DivisionHead' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + DivisionHead.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_HRM_Divisions_DivisionHead(value, this.validated_FK_HRM_Divisions_DivisionHead);
      },
    validated_FK_HRM_Divisions_DivisionHead_main: false,
    validated_FK_HRM_Divisions_DivisionHead: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taDivisions.validated_FK_HRM_Divisions_DivisionHead_main){
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
