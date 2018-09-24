<script type="text/javascript"> 
var script_nprkApplications = {
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
    validate_ClaimID: function(sender) {
      var Prefix = sender.id.replace('ClaimID','');
      this.validated_FK_PRK_Applications_ClaimID_main = true;
      this.validate_FK_PRK_Applications_ClaimID(sender,Prefix);
      },
    validate_FK_PRK_Applications_ClaimID: function(o,Prefix) {
      var value = o.id;
      var ClaimID = $get(Prefix + 'ClaimID');
      if(ClaimID.value==''){
        if(this.validated_FK_PRK_Applications_ClaimID_main){
          var o_d = $get(Prefix + 'ClaimID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ClaimID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PRK_Applications_ClaimID(value, this.validated_FK_PRK_Applications_ClaimID);
      },
    validated_FK_PRK_Applications_ClaimID_main: false,
    validated_FK_PRK_Applications_ClaimID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_nprkApplications.validated_FK_PRK_Applications_ClaimID_main){
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
