/*
	This jscript file is there to write new values from the web interface to the PLC IEC task.
 */

// remember last accessed variable id so that input field can be cleared upon success.
var lastId;

// Writevar simply takes the variable ID (which equals the row number in the html table).
function writeVar(id)
{
	lastId = id;
	// transmit the data
	$.post(
		"../variables/write.php", 
		// ie. PLC_PRG.foo:STRING=bar;
		{ set: $("#name" + id).html() + ":" + $("#type" + id).html() + "=" + $("#value" + id).val() + ";"},
		written
	);
}

// Callback for writing the variable;
function written()
{
	controlServer(3); // actual write command
	$("#value" + lastId).val(""); // clear input field
}