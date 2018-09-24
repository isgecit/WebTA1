<script type="text/javascript"> 
var script_nprkLinkedSAClaims = {
    ACEFinYear_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('FinYear','');
      var F_FinYear = $get(sender._element.id);
      var F_FinYear_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_FinYear.value = p[0];
      F_FinYear_Display.innerHTML = e.get_text();
    },
    ACEFinYear_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('FinYear','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEFinYear_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEQuarter_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('Quarter','');
      var F_Quarter = $get(sender._element.id);
      var F_Quarter_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_Quarter.value = p[0];
      F_Quarter_Display.innerHTML = e.get_text();
    },
    ACEQuarter_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('Quarter','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEQuarter_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_FK_PRK_SiteAllowanceClaims_AdviceNo: function(o,Prefix) {
      var value = o.id;
      var FinYear = $get(Prefix + 'FinYear');
      if(FinYear.value==''){
        if(this.validated_FK_PRK_SiteAllowanceClaims_AdviceNo_main){
          var o_d = $get(Prefix + 'FinYear' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + FinYear.value ;
      var Quarter = $get(Prefix + 'Quarter');
      if(Quarter.value==''){
        if(this.validated_FK_PRK_SiteAllowanceClaims_AdviceNo_main){
          var o_d = $get(Prefix + 'Quarter' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + Quarter.value ;
      var AdviceNo = $get(Prefix + 'AdviceNo');
      if(AdviceNo.value==''){
        if(this.validated_FK_PRK_SiteAllowanceClaims_AdviceNo_main){
          var o_d = $get(Prefix + 'AdviceNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + AdviceNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PRK_SiteAllowanceClaims_AdviceNo(value, this.validated_FK_PRK_SiteAllowanceClaims_AdviceNo);
      },
    validated_FK_PRK_SiteAllowanceClaims_AdviceNo_main: false,
    validated_FK_PRK_SiteAllowanceClaims_AdviceNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_nprkLinkedSAClaims.validated_FK_PRK_SiteAllowanceClaims_AdviceNo_main){
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
