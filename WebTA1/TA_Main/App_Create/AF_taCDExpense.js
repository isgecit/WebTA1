<script type="text/javascript"> 
var script_taCDExpense = {
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
    validate_TABillNo: function(sender) {
      var Prefix = sender.id.replace('TABillNo','');
      this.validated_FK_TA_BillDetails_TABillNo_main = true;
      this.validate_FK_TA_BillDetails_TABillNo(sender,Prefix);
      },
    validate_FK_TA_BillDetails_TABillNo: function(o,Prefix) {
      var value = o.id;
      var TABillNo = $get(Prefix + 'TABillNo');
      if(TABillNo.value==''){
        if(this.validated_FK_TA_BillDetails_TABillNo_main){
          var o_d = $get(Prefix + 'TABillNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TABillNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_TA_BillDetails_TABillNo(value, this.validated_FK_TA_BillDetails_TABillNo);
      },
    validated_FK_TA_BillDetails_TABillNo_main: false,
    validated_FK_TA_BillDetails_TABillNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taCDExpense.validated_FK_TA_BillDetails_TABillNo_main){
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
