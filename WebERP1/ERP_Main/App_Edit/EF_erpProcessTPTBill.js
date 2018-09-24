<script type="text/javascript"> 
var script_erpProcessTPTBill = {
		getIRData: function(o) {
			var value = o;
			var IRNo = $get(o);	
		  if(IRNo.value=='')
		    return false;
		  value = value + ',' + IRNo.value ;
		  IRNo.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		  IRNo.style.backgroundRepeat= 'no-repeat';
		  IRNo.style.backgroundPosition = 'right';
		  PageMethods.getPaymentData(value, this.IRData);
		},
		IRData: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		  	try { $get('ctl00_cph1_FVerpProcessTPTBill_L_ErrMsgerpCreateTPTBill').innerHTML = p[2]; } catch (ex) { }
		    o.value='';
		    o.focus();
		  }else{
		  try { $get('ctl00_cph1_FVerpProcessTPTBill_F_PTRNo').value = p[2]; } catch (ex) { }
		  try { $get('ctl00_cph1_FVerpProcessTPTBill_F_PTRDate').value = p[3]; } catch (ex) { }
		  try { $get('ctl00_cph1_FVerpProcessTPTBill_F_PTRAmount').value = p[4]; } catch (ex) { }
//		  try { $get('ctl00_cph1_FVerpProcessTPTBill_F_TPTCode').value = p[5]; } catch (ex) { }
//		  try { $get('ctl00_cph1_FVerpProcessTPTBill_F_PONumber').value = p[6]; } catch (ex) { }
//		  try { $get('ctl00_cph1_FVerpProcessTPTBill_F_ProjectID').value = p[7]; } catch (ex) { }
//		  try { $get('ctl00_cph1_FVerpProcessTPTBill_F_TPTBillAmount').value = p[8]; } catch (ex) { }
//		  try { $get('ctl00_cph1_FVerpProcessTPTBill_F_TPTBillReceivedOn').value = p[9]; } catch (ex) { }
		 }
		},
		temp: function() {
		}
		}
</script>
