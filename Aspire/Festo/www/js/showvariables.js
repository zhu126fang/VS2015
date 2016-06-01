/*
	This jscript file is there to update the variables in the table of the variables module on the 
	main page.
 */

var isImplemented = false; // Show whether or not the variable server prg in codesys is running.
var intervalId; 
var stopTolerance = 0; // When hitting the start button it might take an additional cycle before the
                       // symbol information is written to the /ffx/www/variables/mnt/symbols file
                       // for the first time.

// AJAX GET the new values
function updateVariables()
{
	$.ajax({
		type:'GET',
		cache: false,
		dataType:'TEXT',
		url:'../variables/mnt/symbols',
		success:showVars,
		error:noVars
	});
}

// If successful show the variables. Coordination with the tbale rows et cetera is implicitly done 
// via the /ffx/www/config file.
function showVars(sText)
{
	$("#variableConnection").val("Active");
	sText = sText.substring(0, sText.search(";;"));
	var vars = sText.split(';');
	for(i = 0; i < vars.length; i++)
		$("#blabla" + i).text(vars[i]);
	stopTolerance = 0;
}

// An error occured getting the variables.
function noVars()
{
	if (stopTolerance == 0)
	{
		$("#variableConnection").val('Inactive');
		clearInterval(intervalId);
	}
	else
		stopTolerance -= 1;
}

// Callback for an AJAX get request checking if /ffx/www/variables/mnt/exists is there. That file
// only exists if the cpx variable server program is running.
function yay()
{
	isImplemented = true;
	$("#variableConnection").val('Inactive');
}

function aww()
{
	isImplemented = false;
	$("#variableConnection").val('Not running');
}

// Send a command to the variables server. See comments in write.php!
function controlServer(cmd)
{
	if (isImplemented)
	{
		$.post("../variables/write.php", { cmd: cmd });
		if (cmd == 1)
		{
			stopTolerance = 1;
			var newInterval = $("#intervalValue").val();
			if (newInterval >= 500)
			{
				clearInterval(intervalId);
				intervalId = setInterval("updateVariables()", newInterval);
			}
		}
	}
}

// Override a click on the close button.
function beforeRemoveVariables()
{
	clearInterval(intervalId);
	controlServer(0);
}