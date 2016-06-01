<?php
	// Important to enable gettability with AJAX.
	header("Cache-Control: no-cache");
		
	// Includes
	include_once('./includes/generic.php');
	
        $variables = array();
	$fn = "./variables/mnt/symbols";
	if (file_exists($fn))
	{
	        $data = file_get_contents($fn);
		$data = trim($data);
		$data = trim($data, ';');
		$data = explode(';', $data);
		for ($i=0; $i<count($data); $i++)
		{
			$variables[$i] = split(':', $data[$i]);
			//printf("%s","$variables[$i]");
		}
	}
	echo "<pre>";
	print_r($data);
?>

