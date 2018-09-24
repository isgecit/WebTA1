<script type="text/javascript"> 
var script_pakSitePkgD = {
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
    ACERecNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('RecNo','');
      var F_RecNo = $get(sender._element.id);
      var F_RecNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_RecNo.value = p[1];
      F_RecNo_Display.innerHTML = e.get_text();
    },
    ACERecNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('RecNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACERecNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
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
      F_BOMNo.value = p[2];
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
      F_ItemNo.value = p[3];
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
    ACESiteMarkNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('SiteMarkNo','');
      var F_SiteMarkNo = $get(sender._element.id);
      var F_SiteMarkNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_SiteMarkNo.value = p[1];
      F_SiteMarkNo_Display.innerHTML = e.get_text();
    },
    ACESiteMarkNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('SiteMarkNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACESiteMarkNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEUOMQuantity_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('UOMQuantity','');
      var F_UOMQuantity = $get(sender._element.id);
      var F_UOMQuantity_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_UOMQuantity.value = p[0];
      F_UOMQuantity_Display.innerHTML = e.get_text();
    },
    ACEUOMQuantity_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('UOMQuantity','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEUOMQuantity_Populated: function(sender,e) {
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
    ACEPackTypeID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('PackTypeID','');
      var F_PackTypeID = $get(sender._element.id);
      var F_PackTypeID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_PackTypeID.value = p[0];
      F_PackTypeID_Display.innerHTML = e.get_text();
    },
    ACEPackTypeID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('PackTypeID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEPackTypeID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEUOMPack_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('UOMPack','');
      var F_UOMPack = $get(sender._element.id);
      var F_UOMPack_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_UOMPack.value = p[0];
      F_UOMPack_Display.innerHTML = e.get_text();
    },
    ACEUOMPack_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('UOMPack','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEUOMPack_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_ItemNo: function(sender) {
      var Prefix = sender.id.replace('ItemNo','');
      this.validated_FK_PAK_SitePkgD_ItemNo_main = true;
      this.validate_FK_PAK_SitePkgD_ItemNo(sender,Prefix);
      },
    validate_SiteMarkNo: function(sender) {
      var Prefix = sender.id.replace('SiteMarkNo','');
      this.validated_FK_PAK_SitePkgD_SiteMarkNo_main = true;
      this.validate_FK_PAK_SitePkgD_SiteMarkNo(sender,Prefix);
      },
    validate_UOMQuantity: function(sender) {
      var Prefix = sender.id.replace('UOMQuantity','');
      this.validated_FK_PAK_SitePkgD_UOMQuantity_main = true;
      this.validate_FK_PAK_SitePkgD_UOMQuantity(sender,Prefix);
      },
    validate_PackTypeID: function(sender) {
      var Prefix = sender.id.replace('PackTypeID','');
      this.validated_FK_PAK_SitePkgD_PAKTypeID_main = true;
      this.validate_FK_PAK_SitePkgD_PAKTypeID(sender,Prefix);
      },
    validate_UOMPack: function(sender) {
      var Prefix = sender.id.replace('UOMPack','');
      this.validated_FK_PAK_SitePkgD_UOMPack_main = true;
      this.validate_FK_PAK_SitePkgD_UOMPack(sender,Prefix);
      },
    validate_BOMNo: function(sender) {
      var Prefix = sender.id.replace('BOMNo','');
      this.validated_FK_PAK_SitePkgD_ItemNo_main = true;
      this.validate_FK_PAK_SitePkgD_ItemNo(sender,Prefix);
      },
    validate_DocumentNo: function(sender) {
      var Prefix = sender.id.replace('DocumentNo','');
      this.validated_FK_PAK_SitePkgD_DocumentNo_main = true;
      this.validate_FK_PAK_SitePkgD_DocumentNo(sender,Prefix);
      },
    validate_PkgNo: function(sender) {
      var Prefix = sender.id.replace('PkgNo','');
      this.validated_FK_PAK_SitePkgD_PkgNo_main = true;
      this.validate_FK_PAK_SitePkgD_PkgNo(sender,Prefix);
      },
    validate_RecNo: function(sender) {
      var Prefix = sender.id.replace('RecNo','');
      this.validated_FK_PAK_SitePkgD_RecNo_main = true;
      this.validate_FK_PAK_SitePkgD_RecNo(sender,Prefix);
      },
    validate_SerialNo: function(sender) {
      var Prefix = sender.id.replace('SerialNo','');
      this.validated_FK_PAK_SitePkgD_SerialNo_main = true;
      this.validate_FK_PAK_SitePkgD_SerialNo(sender,Prefix);
      },
    validate_ProjectID: function(sender) {
      var Prefix = sender.id.replace('ProjectID','');
      this.validated_FK_PAK_SitePkgD_ProjectID_main = true;
      this.validate_FK_PAK_SitePkgD_ProjectID(sender,Prefix);
      },
    validate_FK_PAK_SitePkgD_ProjectID: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_PAK_SitePkgD_ProjectID_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgD_ProjectID(value, this.validated_FK_PAK_SitePkgD_ProjectID);
      },
    validated_FK_PAK_SitePkgD_ProjectID_main: false,
    validated_FK_PAK_SitePkgD_ProjectID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgD.validated_FK_PAK_SitePkgD_ProjectID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SitePkgD_DocumentNo: function(o,Prefix) {
      var value = o.id;
      var DocumentNo = $get(Prefix + 'DocumentNo');
      if(DocumentNo.value==''){
        if(this.validated_FK_PAK_SitePkgD_DocumentNo_main){
          var o_d = $get(Prefix + 'DocumentNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + DocumentNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgD_DocumentNo(value, this.validated_FK_PAK_SitePkgD_DocumentNo);
      },
    validated_FK_PAK_SitePkgD_DocumentNo_main: false,
    validated_FK_PAK_SitePkgD_DocumentNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgD.validated_FK_PAK_SitePkgD_DocumentNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SitePkgD_PAKTypeID: function(o,Prefix) {
      var value = o.id;
      var PackTypeID = $get(Prefix + 'PackTypeID');
      if(PackTypeID.value==''){
        if(this.validated_FK_PAK_SitePkgD_PAKTypeID_main){
          var o_d = $get(Prefix + 'PackTypeID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + PackTypeID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgD_PAKTypeID(value, this.validated_FK_PAK_SitePkgD_PAKTypeID);
      },
    validated_FK_PAK_SitePkgD_PAKTypeID_main: false,
    validated_FK_PAK_SitePkgD_PAKTypeID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgD.validated_FK_PAK_SitePkgD_PAKTypeID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SitePkgD_ItemNo: function(o,Prefix) {
      var value = o.id;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_PAK_SitePkgD_ItemNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
      var PkgNo = $get(Prefix + 'PkgNo');
      if(PkgNo.value==''){
        if(this.validated_FK_PAK_SitePkgD_ItemNo_main){
          var o_d = $get(Prefix + 'PkgNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + PkgNo.value ;
      var BOMNo = $get(Prefix + 'BOMNo');
      if(BOMNo.value==''){
        if(this.validated_FK_PAK_SitePkgD_ItemNo_main){
          var o_d = $get(Prefix + 'BOMNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + BOMNo.value ;
      var ItemNo = $get(Prefix + 'ItemNo');
      if(ItemNo.value==''){
        if(this.validated_FK_PAK_SitePkgD_ItemNo_main){
          var o_d = $get(Prefix + 'ItemNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ItemNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgD_ItemNo(value, this.validated_FK_PAK_SitePkgD_ItemNo);
      },
    validated_FK_PAK_SitePkgD_ItemNo_main: false,
    validated_FK_PAK_SitePkgD_ItemNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgD.validated_FK_PAK_SitePkgD_ItemNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SitePkgD_PkgNo: function(o,Prefix) {
      var value = o.id;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_PAK_SitePkgD_PkgNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
      var PkgNo = $get(Prefix + 'PkgNo');
      if(PkgNo.value==''){
        if(this.validated_FK_PAK_SitePkgD_PkgNo_main){
          var o_d = $get(Prefix + 'PkgNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + PkgNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgD_PkgNo(value, this.validated_FK_PAK_SitePkgD_PkgNo);
      },
    validated_FK_PAK_SitePkgD_PkgNo_main: false,
    validated_FK_PAK_SitePkgD_PkgNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgD.validated_FK_PAK_SitePkgD_PkgNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SitePkgD_SerialNo: function(o,Prefix) {
      var value = o.id;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_PAK_SitePkgD_SerialNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgD_SerialNo(value, this.validated_FK_PAK_SitePkgD_SerialNo);
      },
    validated_FK_PAK_SitePkgD_SerialNo_main: false,
    validated_FK_PAK_SitePkgD_SerialNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgD.validated_FK_PAK_SitePkgD_SerialNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SitePkgD_SiteMarkNo: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_PAK_SitePkgD_SiteMarkNo_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
      var SiteMarkNo = $get(Prefix + 'SiteMarkNo');
      if(SiteMarkNo.value==''){
        if(this.validated_FK_PAK_SitePkgD_SiteMarkNo_main){
          var o_d = $get(Prefix + 'SiteMarkNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SiteMarkNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgD_SiteMarkNo(value, this.validated_FK_PAK_SitePkgD_SiteMarkNo);
      },
    validated_FK_PAK_SitePkgD_SiteMarkNo_main: false,
    validated_FK_PAK_SitePkgD_SiteMarkNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgD.validated_FK_PAK_SitePkgD_SiteMarkNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SitePkgD_RecNo: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_PAK_SitePkgD_RecNo_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
      var RecNo = $get(Prefix + 'RecNo');
      if(RecNo.value==''){
        if(this.validated_FK_PAK_SitePkgD_RecNo_main){
          var o_d = $get(Prefix + 'RecNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + RecNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgD_RecNo(value, this.validated_FK_PAK_SitePkgD_RecNo);
      },
    validated_FK_PAK_SitePkgD_RecNo_main: false,
    validated_FK_PAK_SitePkgD_RecNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgD.validated_FK_PAK_SitePkgD_RecNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SitePkgD_UOMQuantity: function(o,Prefix) {
      var value = o.id;
      var UOMQuantity = $get(Prefix + 'UOMQuantity');
      if(UOMQuantity.value==''){
        if(this.validated_FK_PAK_SitePkgD_UOMQuantity_main){
          var o_d = $get(Prefix + 'UOMQuantity' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + UOMQuantity.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgD_UOMQuantity(value, this.validated_FK_PAK_SitePkgD_UOMQuantity);
      },
    validated_FK_PAK_SitePkgD_UOMQuantity_main: false,
    validated_FK_PAK_SitePkgD_UOMQuantity: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgD.validated_FK_PAK_SitePkgD_UOMQuantity_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_PAK_SitePkgD_UOMPack: function(o,Prefix) {
      var value = o.id;
      var UOMPack = $get(Prefix + 'UOMPack');
      if(UOMPack.value==''){
        if(this.validated_FK_PAK_SitePkgD_UOMPack_main){
          var o_d = $get(Prefix + 'UOMPack' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + UOMPack.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PAK_SitePkgD_UOMPack(value, this.validated_FK_PAK_SitePkgD_UOMPack);
      },
    validated_FK_PAK_SitePkgD_UOMPack_main: false,
    validated_FK_PAK_SitePkgD_UOMPack: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_pakSitePkgD.validated_FK_PAK_SitePkgD_UOMPack_main){
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
