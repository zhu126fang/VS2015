<?php
	// File name for div id.
	$id = $_SERVER["SCRIPT_NAME"]; 
	$parts = Explode('/', $id); 
	$id = $parts[count($parts) - 1];
	$id = substr($id, 0, -4);
	
	function getSectionHead($name, $id)
	{
		echo '<div class="sectionHead"><h2>' . $name . '</h2><img class="closeImage" src="images/close.gif" onClick="removeModule(\'' . $id . '\');" /><img class="closeImage" src="images/refresh.gif" onClick="refreshModule(\'' . $id . '\');" /><img class="closeImage" src="images/up.gif" onClick="moveUpModule(\'' . $id . '\');" /><img class="closeImage" src="images/down.gif" onClick="moveDownModule(\'' . $id . '\');" /></div>';
	}
?>