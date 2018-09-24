<script type="text/javascript"> 
var script_pakQCListD = {
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
    ACEQCLNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('QCLNo','');
      var F_QCLNo = $get(sender._element.id);
      var F_QCLNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_QCLNo.value = p[1];
      F_QCLNo_Display.innerHTML = e.get_text();
    },
    ACEQCLNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('QCLNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEQCLNo_Populated: function(sender,e) {
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
    validate_SerialNo: function(sender) {
      var Prefix = sender.id.replace('SerialNo','');
      this.validated_FK_PAK_QCListD_SerialNo_main = true;
      this.validate_FK_PAK_QCListD_SerialNo(sender,Prefix);
      },
    validate_QCLNo: function(sender) {
      var Prefix = sender.id.replace('QCLNo','');
      this.validated_FK_PAK_QCListD_QCLNo_main = true;
      this.validate_FK_PAK_QCListD_QCLNo(sender,Prefix);
      },
    validate_BOMNo: function(sender) {
      var Prefix = sender.id.replace('BOMNo','');
      this.validated_FK_PAK_QCListD_BOMNo_main = true;
      this.validate_FK_PAK_QCListD_BOMNo(sender,Prefix);
      },
    validate_ItemNo: function(sender) {
      var Prefix = sender.id.replace('ItemNo','');
      this.validated_FK_PAK_QCListD_ItemNo_main = true;
      this.validate_FK_PAK_QCListD_ItemNo(sender,Prefix);
      },
    validate_FK_PAK_QCListD_SerialNo: function(o,Prefix) {
      var value = o.id;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_PAK_QCListD_SerialNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_QCListD_SerialNo(value, this.validated_FK_PAK_QCListD_SerialNo);
      },
    validated_FK_PAK_QCListD_SerialNo_main: false,
    validated_FK_PAK_QCListD_SerialNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakQCListD.validated_FK_PAK_QCListD_SerialNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_QCListD_ItemNo: function(o,Prefix) {
      var value = o.id;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_PAK_QCListD_ItemNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
      var BOMNo = $get(Prefix + 'BOMNo');
      if(BOMNo.value==''){
        if(this.validated_FK_PAK_QCListD_ItemNo_main){
          var o_d = $get(Prefix + 'BOMNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + BOMNo.value ;
      var ItemNo = $get(Prefix + 'ItemNo');
      if(ItemNo.value==''){
        if(this.validated_FK_PAK_QCListD_ItemNo_main){
          var o_d = $get(Prefix + 'ItemNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_QCListD_ItemNo(value, this.validated_FK_PAK_QCListD_ItemNo);
      },
    validated_FK_PAK_QCListD_ItemNo_main: false,
    validated_FK_PAK_QCListD_ItemNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakQCListD.validated_FK_PAK_QCListD_ItemNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_QCListD_BOMNo: function(o,Prefix) {
      var value = o.id;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_PAK_QCListD_BOMNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
      var BOMNo = $get(Prefix + 'BOMNo');
      if(BOMNo.value==''){
        if(this.validated_FK_PAK_QCListD_BOMNo_main){
          var o_d = $get(Prefix + 'BOMNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + BOMNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_QCListD_BOMNo(value, this.validated_FK_PAK_QCListD_BOMNo);
      },
    validated_FK_PAK_QCListD_BOMNo_main: false,
    validated_FK_PAK_QCListD_BOMNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakQCListD.validated_FK_PAK_QCListD_BOMNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_QCListD_QCLNo: function(o,Prefix) {
      var value = o.id;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_PAK_QCListD_QCLNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
      var QCLNo = $get(Prefix + 'QCLNo');
      if(QCLNo.value==''){
        if(this.validated_FK_PAK_QCListD_QCLNo_main){
          var o_d = $get(Prefix + 'QCLNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + QCLNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_QCListD_QCLNo(value, this.validated_FK_PAK_QCListD_QCLNo);
      },
    validated_FK_PAK_QCListD_QCLNo_main: false,
    validated_FK_PAK_QCListD_QCLNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakQCListD.validated_FK_PAK_QCListD_QCLNo_main){
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
