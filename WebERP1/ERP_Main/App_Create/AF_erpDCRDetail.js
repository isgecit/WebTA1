<script type="text/javascript"> 
var script_erpDCRDetail = {
		ACEDCRNo_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('DCRNo','');
		  var F_DCRNo = $get(sender._element.id);
		  var F_DCRNo_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_DCRNo.value = p[0];
		  F_DCRNo_Display.innerHTML = e.get_text();
		},
		ACEDCRNo_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('DCRNo','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACEDCRNo_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		validate_DCRNo: function(sender) {
		  var Prefix = sender.id.replace('DCRNo','');
		  this.validated_FK_ERP_DCRDetail_DCRNo_main = true;
		  this.validate_FK_ERP_DCRDetail_DCRNo(sender,Prefix);
		  },
		validate_FK_ERP_DCRDetail_DCRNo: function(o,Prefix) {
		  var value = o.id;
		  var DCRNo = $get(Prefix + 'DCRNo');
		  if(DCRNo.value==''){
		    if(this.validated_FK_ERP_DCRDetail_DCRNo_main){
		      var o_d = $get(Prefix + 'DCRNo' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + DCRNo.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_ERP_DCRDetail_DCRNo(value, this.validated_FK_ERP_DCRDetail_DCRNo);
		  },
		validated_FK_ERP_DCRDetail_DCRNo_main: false,
		validated_FK_ERP_DCRDetail_DCRNo: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_erpDCRDetail.validated_FK_ERP_DCRDetail_DCRNo_main){
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
