<script type="text/javascript"> 
var script_eitlPOOpenRequest = {
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
		validate_SerialNo: function(sender) {
		  var Prefix = sender.id.replace('SerialNo','');
		  this.validated_FK_EITL_POOpenRequest_SerialNo_main = true;
		  this.validate_FK_EITL_POOpenRequest_SerialNo(sender,Prefix);
		  },
		validate_SupplierID: function(sender) {
		  var Prefix = sender.id.replace('SupplierID','');
		  this.validated_FK_EITL_POOpenRequest_SupplierID_main = true;
		  this.validate_FK_EITL_POOpenRequest_SupplierID(sender,Prefix);
		  },
		validate_FK_EITL_POOpenRequest_SerialNo: function(o,Prefix) {
		  var value = o.id;
		  var SerialNo = $get(Prefix + 'SerialNo');
		  if(SerialNo.value==''){
		    if(this.validated_FK_EITL_POOpenRequest_SerialNo_main){
		      var o_d = $get(Prefix + 'SerialNo' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + SerialNo.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_EITL_POOpenRequest_SerialNo(value, this.validated_FK_EITL_POOpenRequest_SerialNo);
		  },
		validated_FK_EITL_POOpenRequest_SerialNo_main: false,
		validated_FK_EITL_POOpenRequest_SerialNo: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_eitlPOOpenRequest.validated_FK_EITL_POOpenRequest_SerialNo_main){
		    var o_d = $get(p[1]+'_Display');
		    try{o_d.innerHTML = p[2];}catch(ex){}
		  }
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    o.value='';
		    o.focus();
		  }
		},
		validate_FK_EITL_POOpenRequest_SupplierID: function(o,Prefix) {
		  var value = o.id;
		  var SupplierID = $get(Prefix + 'SupplierID');
		  if(SupplierID.value==''){
		    if(this.validated_FK_EITL_POOpenRequest_SupplierID_main){
		      var o_d = $get(Prefix + 'SupplierID' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + SupplierID.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_EITL_POOpenRequest_SupplierID(value, this.validated_FK_EITL_POOpenRequest_SupplierID);
		  },
		validated_FK_EITL_POOpenRequest_SupplierID_main: false,
		validated_FK_EITL_POOpenRequest_SupplierID: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_eitlPOOpenRequest.validated_FK_EITL_POOpenRequest_SupplierID_main){
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
