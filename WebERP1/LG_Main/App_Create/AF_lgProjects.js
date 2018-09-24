<script type="text/javascript"> 
var script_lgProjects = {
		validate_ProjectID: function(sender) {
		  var Prefix = sender.id.replace('ProjectID','');
		  this.validatePK_lgProjects(sender,Prefix);
		  },
		validatePK_lgProjects: function(o,Prefix) {
		  var value = o.id;
		  try{$get(Prefix.replace('_F_','') + '_L_ErrMsglgProjects').innerHTML = '';}catch(ex){}
		  var ProjectID = $get(Prefix + 'ProjectID');
		  if(ProjectID.value=='')
		    return true;
		  value = value + ',' + ProjectID.value ;
		  o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		  o.style.backgroundRepeat= 'no-repeat';
		  o.style.backgroundPosition = 'right';
		  PageMethods.validatePK_lgProjects(value, this.validatedPK_lgProjects);
		},
		validatedPK_lgProjects: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    try{$get('ctl00_cph1_FVlgProjects_L_ErrMsglgProjects').innerHTML = p[2];}catch(ex){}
		    o.value='';
		    o.focus();
		  }
		},
		temp: function() {
		}
		}
</script>
