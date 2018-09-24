<script type="text/javascript"> 
var script_pakElements = {
    ACEParentElementID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ParentElementID','');
      var F_ParentElementID = $get(sender._element.id);
      var F_ParentElementID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ParentElementID.value = p[0];
      F_ParentElementID_Display.innerHTML = e.get_text();
    },
    ACEParentElementID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ParentElementID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEParentElementID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_ElementID: function(sender) {
      var Prefix = sender.id.replace('ElementID','');
      this.validatePK_pakElements(sender,Prefix);
      },
    validate_ParentElementID: function(sender) {
      var Prefix = sender.id.replace('ParentElementID','');
      this.validated_FK_PAK_Elements_ParentElementID_main = true;
      this.validate_FK_PAK_Elements_ParentElementID(sender,Prefix);
      },
    validate_FK_PAK_Elements_ParentElementID: function(o,Prefix) {
      var value = o.id;
      var ParentElementID = $get(Prefix + 'ParentElementID');
      if(ParentElementID.value==''){
        if(this.validated_FK_PAK_Elements_ParentElementID_main){
          var o_d = $get(Prefix + 'ParentElementID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ParentElementID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_Elements_ParentElementID(value, this.validated_FK_PAK_Elements_ParentElementID);
      },
    validated_FK_PAK_Elements_ParentElementID_main: false,
    validated_FK_PAK_Elements_ParentElementID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakElements.validated_FK_PAK_Elements_ParentElementID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validatePK_pakElements: function(o,Prefix) {
      var value = o.id;
      try{$get(Prefix.replace('_F_','') + '_L_ErrMsgpakElements').innerHTML = '';}catch(ex){}
      var ElementID = $get(Prefix + 'ElementID');
      if(ElementID.value=='')
        return true;
      value = value + ',' + ElementID.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validatePK_pakElements(value, this.validatedPK_pakElements);
    },
    validatedPK_pakElements: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        try{$get('cph1_FVpakElements_L_ErrMsgpakElements').innerHTML = p[2];}catch(ex){}
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
