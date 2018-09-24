<script type="text/javascript"> 
var script_taBillGST = {
    ACETABillNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('TABillNo','');
      var F_TABillNo = $get(sender._element.id);
      var F_TABillNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_TABillNo.value = p[0];
      F_TABillNo_Display.innerHTML = e.get_text();
    },
    ACETABillNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('TABillNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACETABillNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACESerialNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('SerialNo','');
      var F_SerialNo = $get(sender._element.id);
      var F_SerialNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_SerialNo.value = p[1];
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
    ACEBPID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('BPID','');
      var F_BPID = $get(sender._element.id);
      var F_BPID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_BPID.value = p[0];
      F_BPID_Display.innerHTML = e.get_text();
    },
    ACEBPID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('BPID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEBPID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACESupplierGSTIN_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('SupplierGSTIN','');
      var F_SupplierGSTIN = $get(sender._element.id);
      var F_SupplierGSTIN_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_SupplierGSTIN.value = p[1];
      F_SupplierGSTIN_Display.innerHTML = e.get_text();
    },
    ACESupplierGSTIN_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('SupplierGSTIN','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
      var F_BPID = $get(Prefix + 'BPID');
      sender._contextKey = F_BPID.value;
    },
    ACESupplierGSTIN_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEHSNSACCode_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('HSNSACCode','');
      var F_HSNSACCode = $get(sender._element.id);
      var F_HSNSACCode_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_HSNSACCode.value = p[1];
      F_HSNSACCode_Display.innerHTML = e.get_text();
    },
    ACEHSNSACCode_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('HSNSACCode','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
      var F_BillType = $get(Prefix + 'BillType');
      sender._contextKey = F_BillType.value;
    },
    ACEHSNSACCode_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_TABillNo: function(sender) {
      var Prefix = sender.id.replace('TABillNo','');
      this.validated_FK_TA_BillGST_TABillNo_main = true;
      this.validate_FK_TA_BillGST_TABillNo(sender,Prefix);
      },
    validate_SerialNo: function(sender) {
      var Prefix = sender.id.replace('SerialNo','');
      this.validated_FK_TA_BillGST_SerialNo_main = true;
      this.validate_FK_TA_BillGST_SerialNo(sender,Prefix);
      },
    validate_BPID: function(sender) {
      var Prefix = sender.id.replace('BPID','');
      this.validated_FK_TA_BillGST_BPID_main = true;
      this.validate_FK_TA_BillGST_BPID(sender,Prefix);
      },
    validate_SupplierGSTIN: function(sender) {
      var Prefix = sender.id.replace('SupplierGSTIN','');
      this.validated_FK_TA_BillGST_SupplierGSTIN_main = true;
      this.validate_FK_TA_BillGST_SupplierGSTIN(sender,Prefix);
      },
    validate_HSNSACCode: function(sender) {
      var Prefix = sender.id.replace('HSNSACCode','');
      this.validated_FK_TA_BillGST_HSNSACCode_main = true;
      this.validate_FK_TA_BillGST_HSNSACCode(sender,Prefix);
      },
    validate_FK_TA_BillGST_HSNSACCode: function(o,Prefix) {
      var value = o.id;
      var BillType = $get(Prefix + 'BillType');
      if(BillType.value==''){
        if(this.validated_FK_TA_BillGST_HSNSACCode_main){
          var o_d = $get(Prefix + 'BillType' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + BillType.value ;
      var HSNSACCode = $get(Prefix + 'HSNSACCode');
      if(HSNSACCode.value==''){
        if(this.validated_FK_TA_BillGST_HSNSACCode_main){
          var o_d = $get(Prefix + 'HSNSACCode' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + HSNSACCode.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_BillGST_HSNSACCode(value, this.validated_FK_TA_BillGST_HSNSACCode);
      },
    validated_FK_TA_BillGST_HSNSACCode_main: false,
    validated_FK_TA_BillGST_HSNSACCode: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taBillGST.validated_FK_TA_BillGST_HSNSACCode_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_TA_BillGST_SerialNo: function(o,Prefix) {
      var value = o.id;
      var TABillNo = $get(Prefix + 'TABillNo');
      if(TABillNo.value==''){
        if(this.validated_FK_TA_BillGST_SerialNo_main){
          var o_d = $get(Prefix + 'TABillNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TABillNo.value ;
      var SerialNo = $get(Prefix + 'SerialNo');
      if(SerialNo.value==''){
        if(this.validated_FK_TA_BillGST_SerialNo_main){
          var o_d = $get(Prefix + 'SerialNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SerialNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_BillGST_SerialNo(value, this.validated_FK_TA_BillGST_SerialNo);
      },
    validated_FK_TA_BillGST_SerialNo_main: false,
    validated_FK_TA_BillGST_SerialNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taBillGST.validated_FK_TA_BillGST_SerialNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_TA_BillGST_TABillNo: function(o,Prefix) {
      var value = o.id;
      var TABillNo = $get(Prefix + 'TABillNo');
      if(TABillNo.value==''){
        if(this.validated_FK_TA_BillGST_TABillNo_main){
          var o_d = $get(Prefix + 'TABillNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TABillNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_BillGST_TABillNo(value, this.validated_FK_TA_BillGST_TABillNo);
      },
    validated_FK_TA_BillGST_TABillNo_main: false,
    validated_FK_TA_BillGST_TABillNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taBillGST.validated_FK_TA_BillGST_TABillNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_TA_BillGST_SupplierGSTIN: function(o,Prefix) {
      var value = o.id;
      var BPID = $get(Prefix + 'BPID');
      if(BPID.value==''){
        if(this.validated_FK_TA_BillGST_SupplierGSTIN_main){
          var o_d = $get(Prefix + 'BPID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + BPID.value ;
      var SupplierGSTIN = $get(Prefix + 'SupplierGSTIN');
      if(SupplierGSTIN.value==''){
        if(this.validated_FK_TA_BillGST_SupplierGSTIN_main){
          var o_d = $get(Prefix + 'SupplierGSTIN' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SupplierGSTIN.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_BillGST_SupplierGSTIN(value, this.validated_FK_TA_BillGST_SupplierGSTIN);
      },
    validated_FK_TA_BillGST_SupplierGSTIN_main: false,
    validated_FK_TA_BillGST_SupplierGSTIN: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taBillGST.validated_FK_TA_BillGST_SupplierGSTIN_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_TA_BillGST_BPID: function(o,Prefix) {
      var value = o.id;
      var BPID = $get(Prefix + 'BPID');
      if(BPID.value==''){
        if(this.validated_FK_TA_BillGST_BPID_main){
          var o_d = $get(Prefix + 'BPID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + BPID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_BillGST_BPID(value, this.validated_FK_TA_BillGST_BPID);
      },
    validated_FK_TA_BillGST_BPID_main: false,
    validated_FK_TA_BillGST_BPID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taBillGST.validated_FK_TA_BillGST_BPID_main){
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
