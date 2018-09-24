<script type="text/javascript"> 
var script_pakPOBItems = {
    ACESerialNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('SerialNo','');
      var F_SerialNo = $get(sender._element.id);
      var F_SerialNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_SerialNo.value = p[0];
      F_SerialNo_Display.innerHTML = e.get_text();
    },
    ACESerialNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('SerialNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACESerialNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEBOMNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('BOMNo','');
      var F_BOMNo = $get(sender._element.id);
      var F_BOMNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_BOMNo.value = p[1];
      F_BOMNo_Display.innerHTML = e.get_text();
    },
    ACEBOMNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('BOMNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEBOMNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_FK_PAK_POBItems_ParentItemNo: function(o,Prefix) {
      var value = o.id;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_PAK_POBItems_ParentItemNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
      var BOMNo = $get(Prefix + 'BOMNo');
      if(BOMNo.value==''){
        if(this.validated_FK_PAK_POBItems_ParentItemNo_main){
          var o_d = $get(Prefix + 'BOMNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + BOMNo.value ;
      var ParentItemNo = $get(Prefix + 'ParentItemNo');
      if(ParentItemNo.value==''){
        if(this.validated_FK_PAK_POBItems_ParentItemNo_main){
          var o_d = $get(Prefix + 'ParentItemNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ParentItemNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_POBItems_ParentItemNo(value, this.validated_FK_PAK_POBItems_ParentItemNo);
      },
    validated_FK_PAK_POBItems_ParentItemNo_main: false,
    validated_FK_PAK_POBItems_ParentItemNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakPOBItems.validated_FK_PAK_POBItems_ParentItemNo_main){
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
