<script type="text/javascript"> 
var script_taDepartments = {
    ACEDepartmentHead_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('DepartmentHead','');
      var F_DepartmentHead = $get(sender._element.id);
      var F_DepartmentHead_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_DepartmentHead.value = p[0];
      F_DepartmentHead_Display.innerHTML = e.get_text();
    },
    ACEDepartmentHead_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('DepartmentHead','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEDepartmentHead_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACEBusinessHead_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('BusinessHead','');
      var F_BusinessHead = $get(sender._element.id);
      var F_BusinessHead_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_BusinessHead.value = p[0];
      F_BusinessHead_Display.innerHTML = e.get_text();
    },
    ACEBusinessHead_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('BusinessHead','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEBusinessHead_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_DepartmentHead: function(sender) {
      var Prefix = sender.id.replace('DepartmentHead','');
      this.validated_FK_HRM_Departments_DepartmentHead_main = true;
      this.validate_FK_HRM_Departments_DepartmentHead(sender,Prefix);
      },
    validate_BusinessHead: function(sender) {
      var Prefix = sender.id.replace('BusinessHead','');
      this.validated_FK_HRM_Departments_BusinessHead_main = true;
      this.validate_FK_HRM_Departments_BusinessHead(sender,Prefix);
      },
    validate_FK_HRM_Departments_BusinessHead: function(o,Prefix) {
      var value = o.id;
      var BusinessHead = $get(Prefix + 'BusinessHead');
      if(BusinessHead.value==''){
        if(this.validated_FK_HRM_Departments_BusinessHead_main){
          var o_d = $get(Prefix + 'BusinessHead' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + BusinessHead.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_HRM_Departments_BusinessHead(value, this.validated_FK_HRM_Departments_BusinessHead);
      },
    validated_FK_HRM_Departments_BusinessHead_main: false,
    validated_FK_HRM_Departments_BusinessHead: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taDepartments.validated_FK_HRM_Departments_BusinessHead_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_HRM_Departments_DepartmentHead: function(o,Prefix) {
      var value = o.id;
      var DepartmentHead = $get(Prefix + 'DepartmentHead');
      if(DepartmentHead.value==''){
        if(this.validated_FK_HRM_Departments_DepartmentHead_main){
          var o_d = $get(Prefix + 'DepartmentHead' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + DepartmentHead.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_HRM_Departments_DepartmentHead(value, this.validated_FK_HRM_Departments_DepartmentHead);
      },
    validated_FK_HRM_Departments_DepartmentHead_main: false,
    validated_FK_HRM_Departments_DepartmentHead: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_taDepartments.validated_FK_HRM_Departments_DepartmentHead_main){
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
