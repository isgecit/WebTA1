<script type="text/javascript"> 
var script_pakCItems = {
    ACERootItem_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('RootItem','');
      var F_RootItem = $get(sender._element.id);
      var F_RootItem_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_RootItem.value = p[0];
      F_RootItem_Display.innerHTML = e.get_text();
    },
    ACERootItem_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('RootItem','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACERootItem_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEElementID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ElementID','');
      var F_ElementID = $get(sender._element.id);
      var F_ElementID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ElementID.value = p[0];
      F_ElementID_Display.innerHTML = e.get_text();
    },
    ACEElementID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ElementID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEElementID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEDocumentNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('DocumentNo','');
      var F_DocumentNo = $get(sender._element.id);
      var F_DocumentNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_DocumentNo.value = p[0];
      F_DocumentNo_Display.innerHTML = e.get_text();
    },
    ACEDocumentNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('DocumentNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEDocumentNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEParentItemNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ParentItemNo','');
      var F_ParentItemNo = $get(sender._element.id);
      var F_ParentItemNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ParentItemNo.value = p[0];
      F_ParentItemNo_Display.innerHTML = e.get_text();
    },
    ACEParentItemNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ParentItemNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEParentItemNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_ElementID: function(sender) {
      var Prefix = sender.id.replace('ElementID','');
      this.validated_FK_PAK_Items_ElementID_main = true;
      this.validate_FK_PAK_Items_ElementID(sender,Prefix);
      },
    validate_DocumentNo: function(sender) {
      var Prefix = sender.id.replace('DocumentNo','');
      this.validated_FK_PAK_Items_DocumentNo_main = true;
      this.validate_FK_PAK_Items_DocumentNo(sender,Prefix);
      },
    validate_ParentItemNo: function(sender) {
      var Prefix = sender.id.replace('ParentItemNo','');
      this.validated_FK_PAK_Items_ParentItemNo_main = true;
      this.validate_FK_PAK_Items_ParentItemNo(sender,Prefix);
      },
    validate_FK_PAK_Items_DocumentNo: function(o,Prefix) {
      var value = o.id;
      var DocumentNo = $get(Prefix + 'DocumentNo');
      if(DocumentNo.value==''){
        if(this.validated_FK_PAK_Items_DocumentNo_main){
          var o_d = $get(Prefix + 'DocumentNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + DocumentNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_Items_DocumentNo(value, this.validated_FK_PAK_Items_DocumentNo);
      },
    validated_FK_PAK_Items_DocumentNo_main: false,
    validated_FK_PAK_Items_DocumentNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakCItems.validated_FK_PAK_Items_DocumentNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_Items_ElementID: function(o,Prefix) {
      var value = o.id;
      var ElementID = $get(Prefix + 'ElementID');
      if(ElementID.value==''){
        if(this.validated_FK_PAK_Items_ElementID_main){
          var o_d = $get(Prefix + 'ElementID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ElementID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_Items_ElementID(value, this.validated_FK_PAK_Items_ElementID);
      },
    validated_FK_PAK_Items_ElementID_main: false,
    validated_FK_PAK_Items_ElementID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakCItems.validated_FK_PAK_Items_ElementID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_Items_ParentItemNo: function(o,Prefix) {
      var value = o.id;
      var ParentItemNo = $get(Prefix + 'ParentItemNo');
      if(ParentItemNo.value==''){
        if(this.validated_FK_PAK_Items_ParentItemNo_main){
          var o_d = $get(Prefix + 'ParentItemNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ParentItemNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_Items_ParentItemNo(value, this.validated_FK_PAK_Items_ParentItemNo);
      },
    validated_FK_PAK_Items_ParentItemNo_main: false,
    validated_FK_PAK_Items_ParentItemNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakCItems.validated_FK_PAK_Items_ParentItemNo_main){
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
