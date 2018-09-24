<script type="text/javascript"> 
var script_nprkUserClaims = {
    ACECardNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('CardNo','');
      var F_CardNo = $get(sender._element.id);
      var F_CardNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_CardNo.value = p[0];
      F_CardNo_Display.innerHTML = e.get_text();
    },
    ACECardNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('CardNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECardNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEReceivedBy_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ReceivedBy','');
      var F_ReceivedBy = $get(sender._element.id);
      var F_ReceivedBy_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ReceivedBy.value = p[0];
      F_ReceivedBy_Display.innerHTML = e.get_text();
    },
    ACEReceivedBy_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ReceivedBy','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEReceivedBy_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEReturnedBy_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ReturnedBy','');
      var F_ReturnedBy = $get(sender._element.id);
      var F_ReturnedBy_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ReturnedBy.value = p[0];
      F_ReturnedBy_Display.innerHTML = e.get_text();
    },
    ACEReturnedBy_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ReturnedBy','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEReturnedBy_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_CardNo: function(sender) {
      var Prefix = sender.id.replace('CardNo','');
      this.validated_FK_PRK_UserClaims_CardNo_main = true;
      this.validate_FK_PRK_UserClaims_CardNo(sender,Prefix);
      },
    validate_ReceivedBy: function(sender) {
      var Prefix = sender.id.replace('ReceivedBy','');
      this.validated_FK_PRK_UserClaims_ReceivedBy_main = true;
      this.validate_FK_PRK_UserClaims_ReceivedBy(sender,Prefix);
      },
    validate_ReturnedBy: function(sender) {
      var Prefix = sender.id.replace('ReturnedBy','');
      this.validated_FK_PRK_UserClaims_ReturnedBy_main = true;
      this.validate_FK_PRK_UserClaims_ReturnedBy(sender,Prefix);
      },
    validate_FK_PRK_UserClaims_CardNo: function(o,Prefix) {
      var value = o.id;
      var CardNo = $get(Prefix + 'CardNo');
      if(CardNo.value==''){
        if(this.validated_FK_PRK_UserClaims_CardNo_main){
          var o_d = $get(Prefix + 'CardNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CardNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PRK_UserClaims_CardNo(value, this.validated_FK_PRK_UserClaims_CardNo);
      },
    validated_FK_PRK_UserClaims_CardNo_main: false,
    validated_FK_PRK_UserClaims_CardNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_nprkUserClaims.validated_FK_PRK_UserClaims_CardNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PRK_UserClaims_ReceivedBy: function(o,Prefix) {
      var value = o.id;
      var ReceivedBy = $get(Prefix + 'ReceivedBy');
      if(ReceivedBy.value==''){
        if(this.validated_FK_PRK_UserClaims_ReceivedBy_main){
          var o_d = $get(Prefix + 'ReceivedBy' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ReceivedBy.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PRK_UserClaims_ReceivedBy(value, this.validated_FK_PRK_UserClaims_ReceivedBy);
      },
    validated_FK_PRK_UserClaims_ReceivedBy_main: false,
    validated_FK_PRK_UserClaims_ReceivedBy: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_nprkUserClaims.validated_FK_PRK_UserClaims_ReceivedBy_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PRK_UserClaims_ReturnedBy: function(o,Prefix) {
      var value = o.id;
      var ReturnedBy = $get(Prefix + 'ReturnedBy');
      if(ReturnedBy.value==''){
        if(this.validated_FK_PRK_UserClaims_ReturnedBy_main){
          var o_d = $get(Prefix + 'ReturnedBy' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ReturnedBy.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PRK_UserClaims_ReturnedBy(value, this.validated_FK_PRK_UserClaims_ReturnedBy);
      },
    validated_FK_PRK_UserClaims_ReturnedBy_main: false,
    validated_FK_PRK_UserClaims_ReturnedBy: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_nprkUserClaims.validated_FK_PRK_UserClaims_ReturnedBy_main){
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
