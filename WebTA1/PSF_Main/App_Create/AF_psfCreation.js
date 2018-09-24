<script type="text/javascript"> 
var script_psfCreation = {
   getCqData: function(o) {
    var value = o;
    var CqNo = $get(o);	
    if(CqNo.value=='')
      return false;
    value = value + ',' + CqNo.value ;
    CqNo.style.backgroundImage = 'url(../../images/pkloader.gif)';
    CqNo.style.backgroundRepeat = 'no-repeat';
    CqNo.style.backgroundPosition = 'right';
    PageMethods.getCqData(value, this.CqData);
  },
  CqData: function(result) {
    var p = result.split('|');
    var o = $get(p[1]);
    o.style.backgroundImage  = 'none';
    if(p[0]=='1'){
      try { $get('cph1_FVpsfCreation_L_ErrMsgpsfCreation').innerHTML = p[2]; } catch (ex) { }
      o.value='';
      o.focus();
    }else{
      try { $get('cph1_FVpsfCreation_F_PaymentRequestNo').value = p[3]; } catch (ex) { }
      try { $get('cph1_FVpsfCreation_F_BankVoucherDate').value = p[4]; } catch (ex) { }
      try { $get('cph1_FVpsfCreation_F_SupplierCode').value = p[5]; } catch (ex) { }
    }
  },
  getIRData: function(o) {
    var value = o;
    var IRNo = $get(o);	
    if(IRNo.value=='')
      return false;
    value = value + ',' + IRNo.value ;
    IRNo.style.backgroundImage = 'url(../../images/pkloader.gif)';
    IRNo.style.backgroundRepeat = 'no-repeat';
    IRNo.style.backgroundPosition = 'right';
    PageMethods.getIRData(value, this.IRData);
  },
  IRData: function(result) {
    var p = result.split('|');
    var o = $get(p[1]);
    o.style.backgroundImage  = 'none';
    if(p[0]=='1'){
      try { $get('cph1_FVpsfCreation_L_ErrMsgpsfCreation').innerHTML = p[2]; } catch (ex) { }
      o.value='';
      o.focus();
    }else{
      try { $get('cph1_FVpsfCreation_F_InvoiceNumber').value = p[3]; } catch (ex) { }
      try { $get('cph1_FVpsfCreation_F_InvoiceDate').value = p[4]; } catch (ex) { }
      try { $get('cph1_FVpsfCreation_F_InvoiceAmount').value = p[5]; } catch (ex) { }
    }
  },


    ACESupplierCode_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('SupplierCode','');
      var F_SupplierCode = $get(sender._element.id);
      var F_SupplierCode_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_SupplierCode.value = p[0];
      F_SupplierCode_Display.innerHTML = e.get_text();
    },
    ACESupplierCode_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('SupplierCode','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACESupplierCode_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_SupplierCode: function(sender) {
      var Prefix = sender.id.replace('SupplierCode','');
      this.validated_FK_PSF_HSBCMain_SupplierID_main = true;
      this.validate_FK_PSF_HSBCMain_SupplierID(sender,Prefix);
      },
    validate_FK_PSF_HSBCMain_SupplierID: function(o,Prefix) {
      var value = o.id;
      var SupplierCode = $get(Prefix + 'SupplierCode');
      if(SupplierCode.value==''){
        if(this.validated_FK_PSF_HSBCMain_SupplierID_main){
          var o_d = $get(Prefix + 'SupplierCode' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + SupplierCode.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PSF_HSBCMain_SupplierID(value, this.validated_FK_PSF_HSBCMain_SupplierID);
      },
    validated_FK_PSF_HSBCMain_SupplierID_main: false,
    validated_FK_PSF_HSBCMain_SupplierID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_psfCreation.validated_FK_PSF_HSBCMain_SupplierID_main){
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
