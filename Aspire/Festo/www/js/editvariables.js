// Clicking the apply button.
function apply()
{
   var tehFile = "";
   
   // Build a list of variables to display in the web server variable visualization.
	// Send it to a php script that writes it as a file to the appropricate place.
   $(".varUse:checked").each(
      function()
      {
			tehFile += $(this).parent().prev().prev().html() + ':' +
						  $(this).parent().prev().html() + ';';
      }
   );
   
   // Post the file to the server.
   $.post(
		"write.php", 
		{ txt: tehFile,  cmd: 2 }, 
		function (data, status)	{
         if (status == "success") document.location = "/"; // Upon success return!
         else alert("fail"); 
		}
	);
}

// Well boring stuff, really.
function markAll()
{
	$(".varUse").attr('checked', true);
	updateCount();
}

function markNone()
{
	$(".varUse").attr('checked', false);
	updateCount();
}

function updateCount()
{
	var checked = $(".varUse:checked").length;
	var count = $(".varUse").length;
	$("#VarSelectedCount").html(
		"Marked: " + checked + "/" + count + "(max. 100)</p>" 
		+ " <img src='../images/" + ((checked <= 100) ? "Ok.gif" : "Error.gif") + "' />"
	);
}