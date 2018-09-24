<script type="text/javascript"> 
var script_pakPkgListD = {
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
    ACEPkgNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('PkgNo','');
      var F_PkgNo = $get(sender._element.id);
      var F_PkgNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_PkgNo.value = p[1];
      F_PkgNo_Display.innerHTML = e.get_text();
    },
    ACEPkgNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('PkgNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEPkgNo_Populated: function(sender,e) {
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
    ACEItemNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ItemNo','');
      var F_ItemNo = $get(sender._element.id);
      var F_ItemNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ItemNo.value = p[2];
      F_ItemNo_Display.innerHTML = e.get_text();
    },
    ACEItemNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ItemNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEItemNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_ItemNo: function(sender) {
      var Prefix = sender.id.replace('ItemNo','');
      this.validated_FK_PAK_PkgListD_ItemNo_main = true;
      this.validate_FK_PAK_PkgListD_ItemNo(sender,Prefix);
      },
    validate_BOMNo: function(sender) {
      var Prefix = sender.id.replace('BOMNo','');
      this.validated_FK_PAK_PkgListD_BOMNo_main = true;
      this.validate_FK_PAK_PkgListD_BOMNo(sender,Prefix);
      },
    validate_PkgNo: function(sender) {
      var Prefix = sender.id.replace('PkgNo','');
      this.validated_FK_PAK_PkgListD_PkgNo_main = true;
      this.validate_FK_PAK_PkgListD_PkgNo(sender,Prefix);
      },
    validate_SerialNo: function(sender) {
      var Prefix = sender.id.replace('SerialNo','');
      this.validated_FK_PAK_PkgListD_SerialNo_main = true;
      this.validate_FK_PAK_PkgListD_SerialNo(sender,Prefix);
      },
    validate_FK_PAK_PkgListD_PkgNo: function(o,Prefix) {
      var value = o.id;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_PAK_PkgListD_PkgNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
      var PkgNo = $get(Prefix + 'PkgNo');
      if(PkgNo.value==''){
        if(this.validated_FK_PAK_PkgListD_PkgNo_main){
          var o_d = $get(Prefix + 'PkgNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + PkgNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_PkgListD_PkgNo(value, this.validated_FK_PAK_PkgListD_PkgNo);
      },
    validated_FK_PAK_PkgListD_PkgNo_main: false,
    validated_FK_PAK_PkgListD_PkgNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakPkgListD.validated_FK_PAK_PkgListD_PkgNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_PkgListD_SerialNo: function(o,Prefix) {
      var value = o.id;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_PAK_PkgListD_SerialNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_PkgListD_SerialNo(value, this.validated_FK_PAK_PkgListD_SerialNo);
      },
    validated_FK_PAK_PkgListD_SerialNo_main: false,
    validated_FK_PAK_PkgListD_SerialNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakPkgListD.validated_FK_PAK_PkgListD_SerialNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_PkgListD_ItemNo: function(o,Prefix) {
      var value = o.id;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_PAK_PkgListD_ItemNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
      var BOMNo = $get(Prefix + 'BOMNo');
      if(BOMNo.value==''){
        if(this.validated_FK_PAK_PkgListD_ItemNo_main){
          var o_d = $get(Prefix + 'BOMNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + BOMNo.value ;
      var ItemNo = $get(Prefix + 'ItemNo');
      if(ItemNo.value==''){
        if(this.validated_FK_PAK_PkgListD_ItemNo_main){
          var o_d = $get(Prefix + 'ItemNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_PkgListD_ItemNo(value, this.validated_FK_PAK_PkgListD_ItemNo);
      },
    validated_FK_PAK_PkgListD_ItemNo_main: false,
    validated_FK_PAK_PkgListD_ItemNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakPkgListD.validated_FK_PAK_PkgListD_ItemNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_PkgListD_BOMNo: function(o,Prefix) {
      var value = o.id;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_PAK_PkgListD_BOMNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
      var BOMNo = $get(Prefix + 'BOMNo');
      if(BOMNo.value==''){
        if(this.validated_FK_PAK_PkgListD_BOMNo_main){
          var o_d = $get(Prefix + 'BOMNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + BOMNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_PkgListD_BOMNo(value, this.validated_FK_PAK_PkgListD_BOMNo);
      },
    validated_FK_PAK_PkgListD_BOMNo_main: false,
    validated_FK_PAK_PkgListD_BOMNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakPkgListD.validated_FK_PAK_PkgListD_BOMNo_main){
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
