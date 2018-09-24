<script type="text/javascript"> 
var script_elogIRBL = {
  getIRData: function(o) {
    var value = o;
    var IRNo = $get(o);	
    if(IRNo.value=='')
      return false;
    value = value + ',' + IRNo.value ;
    IRNo.style.backgroundImage  = 'url(../../images/pkloader.gif)';
    IRNo.style.backgroundRepeat= 'no-repeat';
    IRNo.style.backgroundPosition = 'right';
    PageMethods.getIRData(value, this.IRData);
    return false;
  },
  IRData: function(result) {
    var p = result.split('|');
    var o = $get(p[1]);
    o.style.backgroundImage  = 'none';
    if(p[0]=='1'){
      try { $get('L_ErrMsg').innerHTML = p[2]; } catch (ex) { }
      o.value='';
      o.focus();
    }else{
      try { $get('F_SupplierID').value = p[2]; } catch (ex) { }
      try { $get('F_ProjectID').value = p[3]; } catch (ex) { }
      try { $get('F_SupplierBillNo').value = p[4]; } catch (ex) { }
      try { $get('F_supplierBillDate').value = p[5]; } catch (ex) { }
      try { $get('F_SupplierBillAmount').value = p[6]; } catch (ex) { }
      try { $get('F_IRDate').value = p[7]; } catch (ex) { }
      try { $get('F_PONo').value = p[8]; } catch (ex) { }
    }
  },
  ACEBLID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('BLID','');
      var F_BLID = $get(sender._element.id);
      var F_BLID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_BLID.value = p[0];
      F_BLID_Display.innerHTML = e.get_text();
    },
    ACEBLID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('BLID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEBLID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_BLID: function(sender) {
      var Prefix = sender.id.replace('BLID','');
      this.validated_FK_ELOG_IRBL_BLID_main = true;
      this.validate_FK_ELOG_IRBL_BLID(sender,Prefix);
      },
    validate_FK_ELOG_IRBL_BLID: function(o,Prefix) {
      var value = o.id;
      var BLID = $get(Prefix + 'BLID');
      if(BLID.value==''){
        if(this.validated_FK_ELOG_IRBL_BLID_main){
          var o_d = $get(Prefix + 'BLID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + BLID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_ELOG_IRBL_BLID(value, this.validated_FK_ELOG_IRBL_BLID);
      },
    validated_FK_ELOG_IRBL_BLID_main: false,
    validated_FK_ELOG_IRBL_BLID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_elogIRBL.validated_FK_ELOG_IRBL_BLID_main){
        var o_d = $get(p[1]+'_Display');
          try{o_d.innerHTML = p[2];}catch(ex){}
          try{o.value = p[3];}catch(ex){}
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
