<script type="text/javascript"> 
var script_taD_Mileage = {
    ACECityID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('CityID','');
      var F_CityID = $get(sender._element.id);
      var F_CityID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_CityID.value = p[0];
      F_CityID_Display.innerHTML = e.get_text();
    },
    ACECityID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('CityID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECityID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_CityID: function(sender) {
      var Prefix = sender.id.replace('CityID','');
      this.validated_FK_TA_D_Mileage_CityID_main = true;
      this.validate_FK_TA_D_Mileage_CityID(sender,Prefix);
      },
    validate_FK_TA_D_Mileage_CityID: function(o,Prefix) {
      var value = o.id;
      var CityID = $get(Prefix + 'CityID');
      if(CityID.value==''){
        if(this.validated_FK_TA_D_Mileage_CityID_main){
          var o_d = $get(Prefix + 'CityID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CityID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_D_Mileage_CityID(value, this.validated_FK_TA_D_Mileage_CityID);
      },
    validated_FK_TA_D_Mileage_CityID_main: false,
    validated_FK_TA_D_Mileage_CityID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taD_Mileage.validated_FK_TA_D_Mileage_CityID_main){
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
