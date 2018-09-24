<script type="text/javascript"> 
var script_erpUserRoles = {
		ACERequesterID_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('RequesterID','');
		  var F_RequesterID = $get(sender._element.id);
		  var F_RequesterID_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_RequesterID.value = p[0];
		  F_RequesterID_Display.innerHTML = e.get_text();
		},
		ACERequesterID_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('RequesterID','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACERequesterID_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		ACEApproverID_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('ApproverID','');
		  var F_ApproverID = $get(sender._element.id);
		  var F_ApproverID_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_ApproverID.value = p[0];
		  F_ApproverID_Display.innerHTML = e.get_text();
		},
		ACEApproverID_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('ApproverID','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACEApproverID_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		validate_RequesterID: function(sender) {
		  var Prefix = sender.id.replace('RequesterID','');
		  this.validated_FK_ERP_UserRoles_RequesterID_main = true;
		  this.validate_FK_ERP_UserRoles_RequesterID(sender,Prefix);
		  },
		validate_ApproverID: function(sender) {
		  var Prefix = sender.id.replace('ApproverID','');
		  this.validated_FK_ERP_UserRoles_ApproverID_main = true;
		  this.validate_FK_ERP_UserRoles_ApproverID(sender,Prefix);
		  },
		validate_RoleID: function(sender) {
		  var Prefix = sender.id.replace('RoleID','');
		  this.validated_FK_ERP_UserRoles_RoleID_main = true;
		  this.validate_FK_ERP_UserRoles_RoleID(sender,Prefix);
		  },
		validate_FK_ERP_UserRoles_RequesterID: function(o,Prefix) {
		  var value = o.id;
		  var RequesterID = $get(Prefix + 'RequesterID');
		  if(RequesterID.value==''){
		    if(this.validated_FK_ERP_UserRoles_RequesterID_main){
		      var o_d = $get(Prefix + 'RequesterID' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + RequesterID.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_ERP_UserRoles_RequesterID(value, this.validated_FK_ERP_UserRoles_RequesterID);
		  },
		validated_FK_ERP_UserRoles_RequesterID_main: false,
		validated_FK_ERP_UserRoles_RequesterID: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_erpUserRoles.validated_FK_ERP_UserRoles_RequesterID_main){
		    var o_d = $get(p[1]+'_Display');
		    try{o_d.innerHTML = p[2];}catch(ex){}
		  }
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    o.value='';
		    o.focus();
		  }
		},
		validate_FK_ERP_UserRoles_ApproverID: function(o,Prefix) {
		  var value = o.id;
		  var ApproverID = $get(Prefix + 'ApproverID');
		  if(ApproverID.value==''){
		    if(this.validated_FK_ERP_UserRoles_ApproverID_main){
		      var o_d = $get(Prefix + 'ApproverID' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + ApproverID.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_ERP_UserRoles_ApproverID(value, this.validated_FK_ERP_UserRoles_ApproverID);
		  },
		validated_FK_ERP_UserRoles_ApproverID_main: false,
		validated_FK_ERP_UserRoles_ApproverID: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_erpUserRoles.validated_FK_ERP_UserRoles_ApproverID_main){
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
