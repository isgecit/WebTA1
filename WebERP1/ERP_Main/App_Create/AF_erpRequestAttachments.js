<script type="text/javascript"> 
var script_erpRequestAttachments = {
		ACEApplID_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('ApplID','');
		  var F_ApplID = $get(sender._element.id);
		  var F_ApplID_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_ApplID.value = p[0];
		  F_ApplID_Display.innerHTML = e.get_text();
		},
		ACEApplID_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('ApplID','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACEApplID_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		ACERequestID_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('RequestID','');
		  var F_RequestID = $get(sender._element.id);
		  var F_RequestID_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_RequestID.value = p[1];
		  F_RequestID_Display.innerHTML = e.get_text();
		},
		ACERequestID_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('RequestID','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACERequestID_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		validate_ApplID: function(sender) {
		  var Prefix = sender.id.replace('ApplID','');
		  this.validated_FK_ERP_RequestAttachments_ApplID_main = true;
		  this.validate_FK_ERP_RequestAttachments_ApplID(sender,Prefix);
		  },
		validate_RequestID: function(sender) {
		  var Prefix = sender.id.replace('RequestID','');
		  this.validated_FK_ERP_RequestAttachments_ApplID_RequestID_main = true;
		  this.validate_FK_ERP_RequestAttachments_ApplID_RequestID(sender,Prefix);
		  },
		validate_FK_ERP_RequestAttachments_ApplID: function(o,Prefix) {
		  var value = o.id;
		  var ApplID = $get(Prefix + 'ApplID');
		  if(ApplID.value==''){
		    if(this.validated_FK_ERP_RequestAttachments_ApplID_main){
		      var o_d = $get(Prefix + 'ApplID' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + ApplID.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_ERP_RequestAttachments_ApplID(value, this.validated_FK_ERP_RequestAttachments_ApplID);
		  },
		validated_FK_ERP_RequestAttachments_ApplID_main: false,
		validated_FK_ERP_RequestAttachments_ApplID: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_erpRequestAttachments.validated_FK_ERP_RequestAttachments_ApplID_main){
		    var o_d = $get(p[1]+'_Display');
		    try{o_d.innerHTML = p[2];}catch(ex){}
		  }
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    o.value='';
		    o.focus();
		  }
		},
		validate_FK_ERP_RequestAttachments_ApplID_RequestID: function(o,Prefix) {
		  var value = o.id;
		  var ApplID = $get(Prefix + 'ApplID');
		  if(ApplID.value==''){
		    if(this.validated_FK_ERP_RequestAttachments_ApplID_RequestID_main){
		      var o_d = $get(Prefix + 'ApplID' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + ApplID.value ;
		  var RequestID = $get(Prefix + 'RequestID');
		  if(RequestID.value==''){
		    if(this.validated_FK_ERP_RequestAttachments_ApplID_RequestID_main){
		      var o_d = $get(Prefix + 'RequestID' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + RequestID.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_ERP_RequestAttachments_ApplID_RequestID(value, this.validated_FK_ERP_RequestAttachments_ApplID_RequestID);
		  },
		validated_FK_ERP_RequestAttachments_ApplID_RequestID_main: false,
		validated_FK_ERP_RequestAttachments_ApplID_RequestID: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_erpRequestAttachments.validated_FK_ERP_RequestAttachments_ApplID_RequestID_main){
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
