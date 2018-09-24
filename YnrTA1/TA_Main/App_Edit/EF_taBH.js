<script type="text/javascript"> 
var script_taBH = {
    ACECityOfOrigin_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('CityOfOrigin','');
      var F_CityOfOrigin = $get(sender._element.id);
      var F_CityOfOrigin_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_CityOfOrigin.value = p[0];
      F_CityOfOrigin_Display.innerHTML = e.get_text();
    },
    ACECityOfOrigin_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('CityOfOrigin','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECityOfOrigin_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEDestinationCity_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('DestinationCity','');
      var F_DestinationCity = $get(sender._element.id);
      var F_DestinationCity_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_DestinationCity.value = p[0];
      F_DestinationCity_Display.innerHTML = e.get_text();
    },
    ACEDestinationCity_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('DestinationCity','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEDestinationCity_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEProjectID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ProjectID','');
      var F_ProjectID = $get(sender._element.id);
      var F_ProjectID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ProjectID.value = p[0];
      F_ProjectID_Display.innerHTML = e.get_text();
    },
    ACEProjectID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ProjectID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEProjectID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_CityOfOrigin: function(sender) {
      var Prefix = sender.id.replace('CityOfOrigin','');
      this.validated_FK_TA_Bills_CityOfOrigin_main = true;
      this.validate_FK_TA_Bills_CityOfOrigin(sender,Prefix);
      },
    validate_DestinationCity: function(sender) {
      var Prefix = sender.id.replace('DestinationCity','');
      this.validated_FK_TA_Bills_DestinationCity_main = true;
      this.validate_FK_TA_Bills_DestinationCity(sender,Prefix);
      },
    validate_ProjectID: function(sender) {
      var Prefix = sender.id.replace('ProjectID','');
      this.validated_FK_TA_Bills_ProjectID_main = true;
      this.validate_FK_TA_Bills_ProjectID(sender,Prefix);
      },
    validate_FK_TA_Bills_ProjectID: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_TA_Bills_ProjectID_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_Bills_ProjectID(value, this.validated_FK_TA_Bills_ProjectID);
      },
    validated_FK_TA_Bills_ProjectID_main: false,
    validated_FK_TA_Bills_ProjectID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taBH.validated_FK_TA_Bills_ProjectID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_TA_Bills_DestinationCity: function(o,Prefix) {
      var value = o.id;
      var DestinationCity = $get(Prefix + 'DestinationCity');
      if(DestinationCity.value==''){
        if(this.validated_FK_TA_Bills_DestinationCity_main){
          var o_d = $get(Prefix + 'DestinationCity' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + DestinationCity.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_Bills_DestinationCity(value, this.validated_FK_TA_Bills_DestinationCity);
      },
    validated_FK_TA_Bills_DestinationCity_main: false,
    validated_FK_TA_Bills_DestinationCity: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taBH.validated_FK_TA_Bills_DestinationCity_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_TA_Bills_CityOfOrigin: function(o,Prefix) {
      var value = o.id;
      var CityOfOrigin = $get(Prefix + 'CityOfOrigin');
      if(CityOfOrigin.value==''){
        if(this.validated_FK_TA_Bills_CityOfOrigin_main){
          var o_d = $get(Prefix + 'CityOfOrigin' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CityOfOrigin.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_Bills_CityOfOrigin(value, this.validated_FK_TA_Bills_CityOfOrigin);
      },
    validated_FK_TA_Bills_CityOfOrigin_main: false,
    validated_FK_TA_Bills_CityOfOrigin: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taBH.validated_FK_TA_Bills_CityOfOrigin_main){
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
