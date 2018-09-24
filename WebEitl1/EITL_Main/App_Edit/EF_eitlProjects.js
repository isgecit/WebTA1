<script type="text/javascript"> 
var script_eitlProjects = {
		ACEBusinessPartnerID_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('BusinessPartnerID','');
		  var F_BusinessPartnerID = $get(sender._element.id);
		  var F_BusinessPartnerID_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_BusinessPartnerID.value = p[0];
		  F_BusinessPartnerID_Display.innerHTML = e.get_text();
		},
		ACEBusinessPartnerID_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('BusinessPartnerID','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACEBusinessPartnerID_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		validate_BusinessPartnerID: function(sender) {
		  var Prefix = sender.id.replace('BusinessPartnerID','');
		  this.validated_FK_IDM_Projects_BusinessPartnerID_main = true;
		  this.validate_FK_IDM_Projects_BusinessPartnerID(sender,Prefix);
		  },
		validate_FK_IDM_Projects_BusinessPartnerID: function(o,Prefix) {
		  var value = o.id;
		  var BusinessPartnerID = $get(Prefix + 'BusinessPartnerID');
		  if(BusinessPartnerID.value==''){
		    if(this.validated_FK_IDM_Projects_BusinessPartnerID_main){
		      var o_d = $get(Prefix + 'BusinessPartnerID' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + BusinessPartnerID.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_IDM_Projects_BusinessPartnerID(value, this.validated_FK_IDM_Projects_BusinessPartnerID);
		  },
		validated_FK_IDM_Projects_BusinessPartnerID_main: false,
		validated_FK_IDM_Projects_BusinessPartnerID: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_eitlProjects.validated_FK_IDM_Projects_BusinessPartnerID_main){
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
