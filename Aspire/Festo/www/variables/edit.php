<?php 
//include_once('parse.php');
 ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<!-- Unfortunately this website is not haiku compliant :( -->
	<head>
		<meta http-equiv="Content-Type" content="txt/html; charset=UTF-8" />
		<meta http-equiv="Content-Language" content="en" />
	
		<title>CPX-CEC</title>
	
		<link rel="shortcut icon" type="image/x-icon" href="../images/favicon.ico">
		<link rel="stylesheet" href="../layout.css" type="text/css" media="screen" />
		<link rel="stylesheet" href="../style.css" type="text/css" media="screen" />
	
		<script type="text/JavaScript" src="../js/jquery.js"></script>
		<script type="text/JavaScript" src="../js/iereturn.js"></script>
		<script type="text/JavaScript" src="../js/parsesdb.js"></script>
		<script type="text/JavaScript" src="../js/editvariables.js"></script>
		
		<script type="text/JavaScript">
		$(document).ready(
			function() 
			{
				$("#loadingStatus").text("Downloading the symbol file.");
				// Stop the server and create a new dumpfile.
				$.ajax({
					type:'POST',
					cache: false,
					dataType:'TEXT',
					data: { cmd: 0 , dump: 1 },
					url:'write.php',
					async: false
				});
				
				$("#loadingStatus").text("Parsing the symbol file.");
				// Download the dumpfile and parse the contents.
				$.ajax({
					type:'GET',
					cache: false,
					dataType:'TEXT',
					url:'DOWNLOAD.SDB',
					success:parseDownloadSdb,
					async: false
				});
				
							
				// Do some stuff
				updateCount();
				$(".varUse").click(function () { updateCount(); });
				$("#markAllNone").click(function() { $(".varUse:visible").attr('checked', $("#markAllNone").attr('checked')); updateCount(); });
				
				$("#searchInput").keyup(
					function (e)
					{
						var i = $("#searchInput").val();
						$(".varRow").css("display", "none");
						$(".varRow").each(
							function(){
								if ($(this).text().toLowerCase().indexOf(i.toLowerCase()) != -1)
									$(this).css("display", "");
							}
						);
					}			
				);
			}
		);
      </script>
   </head>
   <body>
		<div id="title" />
		<div id="main">
			<h1>CPX-CEC Webserver</h1>
			<div id="content">
				<div class="sectionHead"><h2>Edit variable list</h2></div>
				<div class="sectionContent">
					<div id="loading">
						<p id="loadingStatus" class="centered">Loading... please wait.</p>
						<img src="../images/wait_mov.gif" class="centered" />
					</div>
					<div id="varTable" style="display:none;">
					<p>Select the variables you want to monitor by checking their boxes in the "Use" column.</p>
					<div class="inputRow">
						<span class="inputLabel">Search:</span><input class="inputBox" id="searchInput" onkeydown="disableReturnInternetExplorer()" type="text" />
					</div>
					<div class="inputRow">
						<span class="inputLabel">Mark all/none:</span><input id="markAllNone"  type="checkbox" />
					</div>
					<table>
						<tr><td class="firstRow">Name</td><td class="firstRow">Type</td><td class="firstRow">Use</td></tr>
						<tr id="replaceMe" />
					</table>
					<p id="VarSelectedCount" />
					<div class="inputRow">
						<input class="inputButton" type="submit" value="Apply" onclick="apply()"/>
						<input class="inputButton" type="submit" value="Cancel" onclick="document.location = '/'"/> 
					</div>
					</div>
				</div>
			</div>
			
			<div id="footer">
				<p align="center">&copy;2005-2009 Festo AG & Co. KG</p>
			</div> <!-- footer -->	
		</div> <!-- main -->
			
		<div id="sidebar">
			<img id="logo" src="../images/top_logo2.gif" style="margin-bottom: 20px;" />
		</div>			
   </body>
</html>
