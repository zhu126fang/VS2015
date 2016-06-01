/*
	
	Sending CI commands via AJAX.	

*/

// Send a CI command.
function terminalSend(command)
{
	$("#terminalOutput").append(command + "=");
	$("#terminalInput").val("");
	$.get("includes/ci.php?query=" + command, showResult);
}

// Callback function for the terminalSend function.
// Displays the response.
function showResult(sText, sStatus)
{
	if(sStatus == "success")
	{
		$("#terminalOutput").append(sText + '<br/>').attr('scrollTop', function () { return this.scrollHeight; });
	}
}