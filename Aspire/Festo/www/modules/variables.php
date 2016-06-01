<?php
	// Important to enable gettability with AJAX.
	header("Cache-Control: no-cache");
		
	// Includes
	include_once('../includes/generic.php');
	
   $variables = array();
	$fn = "/ffx/www/variables/config";
	if (file_exists($fn))
	{
	   $data = file_get_contents($fn);
		$data = trim($data);
		$data = trim($data, ';');
		$data = explode(';', $data);
		for ($i=0; $i<count($data); $i++)
			$variables[$i] = split(':', $data[$i]);
	}
?>

<script type="text/javascript">
	$(document).ready(
		function() 
		{
			$(window).unload(
				function () { beforeRemoveVariables(); }
			);
			$.ajax({
				type:'GET',
				dataType:'TEXT',
				cache: false,
				url:'../variables/mnt/exists',
				success:yay,
				error:aww
			});
		}		
	);
</script>

<div class="section" id="<?php echo $id; ?>">
	<?php getSectionHead('Variables', $id); ?>
	<div class="sectionContent">
	<div class="inputRow"><span class="inputLabel">Status:</span><input id="variableConnection" class="inputBox" type="text" onkeydown="disableReturnInternetExplorer()" readonly="true" /><a href="variables/docu.htm"><img src="../images/Info.gif" style="margin-top: 3px" /></a></div>
	<div class="inputRow"><span class="inputLabel">Interval:</span><input id="intervalValue" class="inputBox" type="text" onkeydown="disableReturnInternetExplorer()" value="1000" /><span class="inputLabel">ms (>= 500)</span></div>
	<div class="inputRow">
		<input class="inputButton" onclick="controlServer(1);" value="Start" type="button" />
		<input class="inputButton" onclick="controlServer(0);" value="Stop" type="button" />
		<input class="inputButton" onclick="document.location='variables/edit.php'" value="Edit" type="button" />
	</div>
	<table id="variableTable">
	<tr><td class="firstRow">Name</td><td class="firstRow">Type</td><td class="firstRow">Value</td><td class="firstRow">New Value</td><td class="firstRow"></td></tr>
	<?php 
	if (count($variables) > 0)
	{
		for ($i=0; $i<count($variables); $i++)
			echo '<tr><td id="name' . $i . '">' . $variables[$i][0] . '</td><td id="type' . $i . '">' . $variables[$i][1] . '</td><td id="blabla' . $i . '">n/a</td><td><input id="value' . $i . '" class="varInputBox" type="text" onkeydown="disableReturnInternetExplorer()" /></td><td class="varInputTd"><input class="varInputButton" value="Write" onclick="writeVar(' . $i . ')" type="button" /></td></tr>';
	}
	else
	{
		echo '<tr><td colspan="5">No variables are configured.</td></tr>';
	}
?>
	</table>
	</div> <!-- section content -->
</div> <!-- section -->