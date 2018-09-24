<script type="text/javascript"> 
var script_nprkLedgerEntry = {
    ACEEmployeeID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('EmployeeID','');
      var F_EmployeeID = $get(sender._element.id);
      var F_EmployeeID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_EmployeeID.value = p[0];
      F_EmployeeID_Display.innerHTML = e.get_text();
    },
    ACEEmployeeID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('EmployeeID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEEmployeeID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_EmployeeID: function(sender) {
      var Prefix = sender.id.replace('EmployeeID','');
      this.validated_FK_PRK_Ledger_PRK_Employees_main = true;
      this.validate_FK_PRK_Ledger_PRK_Employees(sender,Prefix);
      },
    validate_FK_PRK_Ledger_PRK_Employees: function(o,Prefix) {
      var value = o.id;
      var EmployeeID = $get(Prefix + 'EmployeeID');
      if(EmployeeID.value==''){
        if(this.validated_FK_PRK_Ledger_PRK_Employees_main){
          var o_d = $get(Prefix + 'EmployeeID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + EmployeeID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_PRK_Ledger_PRK_Employees(value, this.validated_FK_PRK_Ledger_PRK_Employees);
      },
    validated_FK_PRK_Ledger_PRK_Employees_main: false,
    validated_FK_PRK_Ledger_PRK_Employees: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_nprkLedgerEntry.validated_FK_PRK_Ledger_PRK_Employees_main){
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
