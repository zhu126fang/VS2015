<?php
        $variables = array();
	$fn = "./variables/config";

	echo "<center>";
        echo "<h1>Title</h1>";
        echo "<h1 style='text-align:center'>Center</h1>";
        echo "<pre>";

	if (file_exists($fn))
	{
	   $data = file_get_contents($fn);
		$data = trim($data);
		$data = trim($data, ';');
		$data = explode(';', $data);
		for ($i=0; $i<count($data); $i++)
		{
			$variables[$i] = $date[$i];
			echo "<h3>$data[$i]</h3>";
		}
        print_r($data);
        //var_dump($data);
	}
	
	echo "</center>";
?>

