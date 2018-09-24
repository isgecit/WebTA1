<script type="text/javascript"> 
var script_tarTravelRequest = {
    ACERequestedFor_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('RequestedFor','');
      var F_RequestedFor = $get(sender._element.id);
      var F_RequestedFor_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_RequestedFor.value = p[0];
      F_RequestedFor_Display.innerHTML = e.get_text();
    },
    ACERequestedFor_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('RequestedFor','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACERequestedFor_Populated: function(sender,e) {
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
    ACEProjectManagerID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ProjectManagerID','');
      var F_ProjectManagerID = $get(sender._element.id);
      var F_ProjectManagerID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ProjectManagerID.value = p[0];
      F_ProjectManagerID_Display.innerHTML = e.get_text();
    },
    ACEProjectManagerID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ProjectManagerID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEProjectManagerID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_RequestedFor: function(sender) {
      var Prefix = sender.id.replace('RequestedFor','');
      this.validated_FK_TA_TravelRequest_RequestedFor_main = true;
      this.validate_FK_TA_TravelRequest_RequestedFor(sender,Prefix);
      },
    validate_ProjectID: function(sender) {
      var Prefix = sender.id.replace('ProjectID','');
      this.validated_FK_TA_TravelRequest_ProjectID_main = true;
      this.validate_FK_TA_TravelRequest_ProjectID(sender,Prefix);
      },
    validate_ProjectManagerID: function(sender) {
      var Prefix = sender.id.replace('ProjectManagerID','');
      this.validated_FK_TA_TravelRequest_ProjectManagerID_main = true;
      this.validate_FK_TA_TravelRequest_ProjectManagerID(sender,Prefix);
      },
    validate_FK_TA_TravelRequest_RequestedFor: function(o,Prefix) {
      var value = o.id;
      var RequestedFor = $get(Prefix + 'RequestedFor');
      if(RequestedFor.value==''){
        if(this.validated_FK_TA_TravelRequest_RequestedFor_main){
          var o_d = $get(Prefix + 'RequestedFor' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + RequestedFor.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_TravelRequest_RequestedFor(value, this.validated_FK_TA_TravelRequest_RequestedFor);
      },
    validated_FK_TA_TravelRequest_RequestedFor_main: false,
    validated_FK_TA_TravelRequest_RequestedFor: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_tarTravelRequest.validated_FK_TA_TravelRequest_RequestedFor_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_TA_TravelRequest_ProjectManagerID: function(o,Prefix) {
      var value = o.id;
      var ProjectManagerID = $get(Prefix + 'ProjectManagerID');
      if(ProjectManagerID.value==''){
        if(this.validated_FK_TA_TravelRequest_ProjectManagerID_main){
          var o_d = $get(Prefix + 'ProjectManagerID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectManagerID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_TravelRequest_ProjectManagerID(value, this.validated_FK_TA_TravelRequest_ProjectManagerID);
      },
    validated_FK_TA_TravelRequest_ProjectManagerID_main: false,
    validated_FK_TA_TravelRequest_ProjectManagerID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_tarTravelRequest.validated_FK_TA_TravelRequest_ProjectManagerID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_TA_TravelRequest_ProjectID: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_TA_TravelRequest_ProjectID_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_TravelRequest_ProjectID(value, this.validated_FK_TA_TravelRequest_ProjectID);
      },
    validated_FK_TA_TravelRequest_ProjectID_main: false,
    validated_FK_TA_TravelRequest_ProjectID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_tarTravelRequest.validated_FK_TA_TravelRequest_ProjectID_main){
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
