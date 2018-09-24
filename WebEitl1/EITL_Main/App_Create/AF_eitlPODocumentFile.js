<script type="text/javascript"> 
var script_eitlPODocumentFile = {
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
		ACEDocumentLineNo_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('DocumentLineNo','');
		  var F_DocumentLineNo = $get(sender._element.id);
		  var F_DocumentLineNo_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_DocumentLineNo.value = p[1];
		  F_DocumentLineNo_Display.innerHTML = e.get_text();
		},
		ACEDocumentLineNo_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('DocumentLineNo','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACEDocumentLineNo_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		validate_SerialNo: function(sender) {
		  var Prefix = sender.id.replace('SerialNo','');
		  this.validated_FK_EITL_PODocumentFile_SerialNo_main = true;
		  this.validate_FK_EITL_PODocumentFile_SerialNo(sender,Prefix);
		  },
		validate_DocumentLineNo: function(sender) {
		  var Prefix = sender.id.replace('DocumentLineNo','');
		  this.validated_FK_EITL_PODocumentFile_DocumentLine_main = true;
		  this.validate_FK_EITL_PODocumentFile_DocumentLine(sender,Prefix);
		  },
		validate_FK_EITL_PODocumentFile_DocumentLine: function(o,Prefix) {
		  var value = o.id;
		  var SerialNo = $get(Prefix + 'SerialNo');
		  if(SerialNo.value==''){
		    if(this.validated_FK_EITL_PODocumentFile_DocumentLine_main){
		      var o_d = $get(Prefix + 'SerialNo' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + SerialNo.value ;
		  var DocumentLineNo = $get(Prefix + 'DocumentLineNo');
		  if(DocumentLineNo.value==''){
		    if(this.validated_FK_EITL_PODocumentFile_DocumentLine_main){
		      var o_d = $get(Prefix + 'DocumentLineNo' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + DocumentLineNo.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_EITL_PODocumentFile_DocumentLine(value, this.validated_FK_EITL_PODocumentFile_DocumentLine);
		  },
		validated_FK_EITL_PODocumentFile_DocumentLine_main: false,
		validated_FK_EITL_PODocumentFile_DocumentLine: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_eitlPODocumentFile.validated_FK_EITL_PODocumentFile_DocumentLine_main){
		    var o_d = $get(p[1]+'_Display');
		    try{o_d.innerHTML = p[2];}catch(ex){}
		  }
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    o.value='';
		    o.focus();
		  }
		},
		validate_FK_EITL_PODocumentFile_SerialNo: function(o,Prefix) {
		  var value = o.id;
		  var SerialNo = $get(Prefix + 'SerialNo');
		  if(SerialNo.value==''){
		    if(this.validated_FK_EITL_PODocumentFile_SerialNo_main){
		      var o_d = $get(Prefix + 'SerialNo' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + SerialNo.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_EITL_PODocumentFile_SerialNo(value, this.validated_FK_EITL_PODocumentFile_SerialNo);
		  },
		validated_FK_EITL_PODocumentFile_SerialNo_main: false,
		validated_FK_EITL_PODocumentFile_SerialNo: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_eitlPODocumentFile.validated_FK_EITL_PODocumentFile_SerialNo_main){
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
