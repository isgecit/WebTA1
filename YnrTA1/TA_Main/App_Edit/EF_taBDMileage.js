<script type="text/javascript"> 
var script_taBDMileage = {
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
    ACECity1ID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('City1ID','');
      var F_City1ID = $get(sender._element.id);
      var F_City1ID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_City1ID.value = p[0];
      F_City1ID_Display.innerHTML = e.get_text();
    },
    ACECity1ID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('City1ID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECity1ID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACECity2ID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('City2ID','');
      var F_City2ID = $get(sender._element.id);
      var F_City2ID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_City2ID.value = p[0];
      F_City2ID_Display.innerHTML = e.get_text();
    },
    ACECity2ID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('City2ID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECity2ID_Populated: function(sender,e) {
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
    validate_City1ID: function(sender) {
      var Prefix = sender.id.replace('City1ID','');
      this.validated_FK_TA_BillDetails_City1ID_main = true;
      this.validate_FK_TA_BillDetails_City1ID(sender,Prefix);
      },
    validate_City2ID: function(sender) {
      var Prefix = sender.id.replace('City2ID','');
      this.validated_FK_TA_BillDetails_City2ID_main = true;
      this.validate_FK_TA_BillDetails_City2ID(sender,Prefix);
      },
    validate_ProjectID: function(sender) {
      var Prefix = sender.id.replace('ProjectID','');
      this.validated_FK_TA_BillDetails_ProjectID_main = true;
      this.validate_FK_TA_BillDetails_ProjectID(sender,Prefix);
      },
    validate_FK_TA_BillDetails_ProjectID: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_TA_BillDetails_ProjectID_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_BillDetails_ProjectID(value, this.validated_FK_TA_BillDetails_ProjectID);
      },
    validated_FK_TA_BillDetails_ProjectID_main: false,
    validated_FK_TA_BillDetails_ProjectID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taBDMileage.validated_FK_TA_BillDetails_ProjectID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_TA_BillDetails_City1ID: function(o,Prefix) {
      var value = o.id;
      var City1ID = $get(Prefix + 'City1ID');
      if(City1ID.value==''){
        if(this.validated_FK_TA_BillDetails_City1ID_main){
          var o_d = $get(Prefix + 'City1ID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + City1ID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_BillDetails_City1ID(value, this.validated_FK_TA_BillDetails_City1ID);
      },
    validated_FK_TA_BillDetails_City1ID_main: false,
    validated_FK_TA_BillDetails_City1ID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taBDMileage.validated_FK_TA_BillDetails_City1ID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_TA_BillDetails_City2ID: function(o,Prefix) {
      var value = o.id;
      var City2ID = $get(Prefix + 'City2ID');
      if(City2ID.value==''){
        if(this.validated_FK_TA_BillDetails_City2ID_main){
          var o_d = $get(Prefix + 'City2ID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + City2ID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_BillDetails_City2ID(value, this.validated_FK_TA_BillDetails_City2ID);
      },
    validated_FK_TA_BillDetails_City2ID_main: false,
    validated_FK_TA_BillDetails_City2ID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taBDMileage.validated_FK_TA_BillDetails_City2ID_main){
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
