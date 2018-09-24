<script type="text/javascript"> 
var script_nprkBillDetails = {
    ACEClaimID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ClaimID','');
      var F_ClaimID = $get(sender._element.id);
      var F_ClaimID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ClaimID.value = p[0];
      F_ClaimID_Display.innerHTML = e.get_text();
    },
    ACEClaimID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ClaimID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEClaimID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEApplicationID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ApplicationID','');
      var F_ApplicationID = $get(sender._element.id);
      var F_ApplicationID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ApplicationID.value = p[1];
      F_ApplicationID_Display.innerHTML = e.get_text();
    },
    ACEApplicationID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ApplicationID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEApplicationID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_ApplicationID: function(sender) {
      var Prefix = sender.id.replace('ApplicationID','');
      this.validated_FK_PRK_BillDetails_PRK_Applications_main = true;
      this.validate_FK_PRK_BillDetails_PRK_Applications(sender,Prefix);
      },
    validate_ClaimID: function(sender) {
      var Prefix = sender.id.replace('ClaimID','');
      this.validated_FK_PRK_BillDetails_ClaimID_main = true;
      this.validate_FK_PRK_BillDetails_ClaimID(sender,Prefix);
      },
    validate_FK_PRK_BillDetails_PRK_Applications: function(o,Prefix) {
      var value = o.id;
      var ClaimID = $get(Prefix + 'ClaimID');
      if(ClaimID.value==''){
        if(this.validated_FK_PRK_BillDetails_PRK_Applications_main){
          var o_d = $get(Prefix + 'ClaimID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ClaimID.value ;
      var ApplicationID = $get(Prefix + 'ApplicationID');
      if(ApplicationID.value==''){
        if(this.validated_FK_PRK_BillDetails_PRK_Applications_main){
          var o_d = $get(Prefix + 'ApplicationID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ApplicationID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PRK_BillDetails_PRK_Applications(value, this.validated_FK_PRK_BillDetails_PRK_Applications);
      },
    validated_FK_PRK_BillDetails_PRK_Applications_main: false,
    validated_FK_PRK_BillDetails_PRK_Applications: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_nprkBillDetails.validated_FK_PRK_BillDetails_PRK_Applications_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PRK_BillDetails_ClaimID: function(o,Prefix) {
      var value = o.id;
      var ClaimID = $get(Prefix + 'ClaimID');
      if(ClaimID.value==''){
        if(this.validated_FK_PRK_BillDetails_ClaimID_main){
          var o_d = $get(Prefix + 'ClaimID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ClaimID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PRK_BillDetails_ClaimID(value, this.validated_FK_PRK_BillDetails_ClaimID);
      },
    validated_FK_PRK_BillDetails_ClaimID_main: false,
    validated_FK_PRK_BillDetails_ClaimID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_nprkBillDetails.validated_FK_PRK_BillDetails_ClaimID_main){
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
