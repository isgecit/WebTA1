<script type="text/javascript"> 
var script_eitlPOList = {
		ACESupplierID_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('SupplierID','');
		  var F_SupplierID = $get(sender._element.id);
		  var F_SupplierID_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_SupplierID.value = p[0];
		  F_SupplierID_Display.innerHTML = e.get_text();
		},
		ACESupplierID_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('SupplierID','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACESupplierID_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
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
		ACEBuyerID_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('BuyerID','');
		  var F_BuyerID = $get(sender._element.id);
		  var F_BuyerID_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_BuyerID_Display.innerHTML = e.get_text();
		},
		ACEBuyerID_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('BuyerID','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACEBuyerID_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		ACEPOStatusID_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('POStatusID','');
		  var F_POStatusID = $get(sender._element.id);
		  var F_POStatusID_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_POStatusID.value = p[0];
		  F_POStatusID_Display.innerHTML = e.get_text();
		},
		ACEPOStatusID_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('POStatusID','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACEPOStatusID_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		ACEIssuedBy_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('IssuedBy','');
		  var F_IssuedBy = $get(sender._element.id);
		  var F_IssuedBy_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_IssuedBy_Display.innerHTML = e.get_text();
		},
		ACEIssuedBy_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('IssuedBy','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACEIssuedBy_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		ACEClosedBy_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('ClosedBy','');
		  var F_ClosedBy = $get(sender._element.id);
		  var F_ClosedBy_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_ClosedBy_Display.innerHTML = e.get_text();
		},
		ACEClosedBy_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('ClosedBy','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACEClosedBy_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		validate_SupplierID: function(sender) {
		  var Prefix = sender.id.replace('SupplierID','');
		  this.validated_FK_EITL_POList_SupplierID_main = true;
		  this.validate_FK_EITL_POList_SupplierID(sender,Prefix);
		  },
		validate_ProjectID: function(sender) {
		  var Prefix = sender.id.replace('ProjectID','');
		  this.validated_FK_EITL_POList_ProjectID_main = true;
		  this.validate_FK_EITL_POList_ProjectID(sender,Prefix);
		  },
		validate_BuyerID: function(sender) {
		  var Prefix = sender.id.replace('BuyerID','');
		  this.validated_FK_EITL_POList_BuyerID_main = true;
		  this.validate_FK_EITL_POList_BuyerID(sender,Prefix);
		  },
		validate_POStatusID: function(sender) {
		  var Prefix = sender.id.replace('POStatusID','');
		  this.validated_FK_EITL_POList_POStatusID_main = true;
		  this.validate_FK_EITL_POList_POStatusID(sender,Prefix);
		  },
		validate_IssuedBy: function(sender) {
		  var Prefix = sender.id.replace('IssuedBy','');
		  this.validated_FK_EITL_POList_IssuedBy_main = true;
		  this.validate_FK_EITL_POList_IssuedBy(sender,Prefix);
		  },
		validate_ClosedBy: function(sender) {
		  var Prefix = sender.id.replace('ClosedBy','');
		  this.validated_FK_EITL_POList_ClosedBy_main = true;
		  this.validate_FK_EITL_POList_ClosedBy(sender,Prefix);
		  },
		validate_FK_EITL_POList_BuyerID: function(o,Prefix) {
		  var value = o.id;
		  var BuyerID = $get(Prefix + 'BuyerID');
		  if(BuyerID.value==''){
		    if(this.validated_FK_EITL_POList_BuyerID_main){
		      var o_d = $get(Prefix + 'BuyerID' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + BuyerID.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_EITL_POList_BuyerID(value, this.validated_FK_EITL_POList_BuyerID);
		  },
		validated_FK_EITL_POList_BuyerID_main: false,
		validated_FK_EITL_POList_BuyerID: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_eitlPOList.validated_FK_EITL_POList_BuyerID_main){
		    var o_d = $get(p[1]+'_Display');
		    try{o_d.innerHTML = p[2];}catch(ex){}
		  }
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    o.value='';
		    o.focus();
		  }
		},
		validate_FK_EITL_POList_ClosedBy: function(o,Prefix) {
		  var value = o.id;
		  var ClosedBy = $get(Prefix + 'ClosedBy');
		  if(ClosedBy.value==''){
		    if(this.validated_FK_EITL_POList_ClosedBy_main){
		      var o_d = $get(Prefix + 'ClosedBy' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + ClosedBy.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_EITL_POList_ClosedBy(value, this.validated_FK_EITL_POList_ClosedBy);
		  },
		validated_FK_EITL_POList_ClosedBy_main: false,
		validated_FK_EITL_POList_ClosedBy: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_eitlPOList.validated_FK_EITL_POList_ClosedBy_main){
		    var o_d = $get(p[1]+'_Display');
		    try{o_d.innerHTML = p[2];}catch(ex){}
		  }
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    o.value='';
		    o.focus();
		  }
		},
		validate_FK_EITL_POList_IssuedBy: function(o,Prefix) {
		  var value = o.id;
		  var IssuedBy = $get(Prefix + 'IssuedBy');
		  if(IssuedBy.value==''){
		    if(this.validated_FK_EITL_POList_IssuedBy_main){
		      var o_d = $get(Prefix + 'IssuedBy' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + IssuedBy.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_EITL_POList_IssuedBy(value, this.validated_FK_EITL_POList_IssuedBy);
		  },
		validated_FK_EITL_POList_IssuedBy_main: false,
		validated_FK_EITL_POList_IssuedBy: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_eitlPOList.validated_FK_EITL_POList_IssuedBy_main){
		    var o_d = $get(p[1]+'_Display');
		    try{o_d.innerHTML = p[2];}catch(ex){}
		  }
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    o.value='';
		    o.focus();
		  }
		},
		validate_FK_EITL_POList_POStatusID: function(o,Prefix) {
		  var value = o.id;
		  var POStatusID = $get(Prefix + 'POStatusID');
		  if(POStatusID.value==''){
		    if(this.validated_FK_EITL_POList_POStatusID_main){
		      var o_d = $get(Prefix + 'POStatusID' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + POStatusID.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_EITL_POList_POStatusID(value, this.validated_FK_EITL_POList_POStatusID);
		  },
		validated_FK_EITL_POList_POStatusID_main: false,
		validated_FK_EITL_POList_POStatusID: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_eitlPOList.validated_FK_EITL_POList_POStatusID_main){
		    var o_d = $get(p[1]+'_Display');
		    try{o_d.innerHTML = p[2];}catch(ex){}
		  }
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    o.value='';
		    o.focus();
		  }
		},
		validate_FK_EITL_POList_SupplierID: function(o,Prefix) {
		  var value = o.id;
		  var SupplierID = $get(Prefix + 'SupplierID');
		  if(SupplierID.value==''){
		    if(this.validated_FK_EITL_POList_SupplierID_main){
		      var o_d = $get(Prefix + 'SupplierID' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + SupplierID.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_EITL_POList_SupplierID(value, this.validated_FK_EITL_POList_SupplierID);
		  },
		validated_FK_EITL_POList_SupplierID_main: false,
		validated_FK_EITL_POList_SupplierID: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_eitlPOList.validated_FK_EITL_POList_SupplierID_main){
		    var o_d = $get(p[1]+'_Display');
		    try{o_d.innerHTML = p[2];}catch(ex){}
		  }
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    o.value='';
		    o.focus();
		  }
		},
		validate_FK_EITL_POList_ProjectID: function(o,Prefix) {
		  var value = o.id;
		  var ProjectID = $get(Prefix + 'ProjectID');
		  if(ProjectID.value==''){
		    if(this.validated_FK_EITL_POList_ProjectID_main){
		      var o_d = $get(Prefix + 'ProjectID' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + ProjectID.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_EITL_POList_ProjectID(value, this.validated_FK_EITL_POList_ProjectID);
		  },
		validated_FK_EITL_POList_ProjectID_main: false,
		validated_FK_EITL_POList_ProjectID: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_eitlPOList.validated_FK_EITL_POList_ProjectID_main){
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
