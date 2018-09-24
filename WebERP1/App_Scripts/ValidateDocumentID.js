function validate_docid(o) {
	var val = o.value;
	
	if(val.length==0)
		return true;

	if (val.length != 23) {
		alert('Invalid document ID.');
		return false;
	}
	
}