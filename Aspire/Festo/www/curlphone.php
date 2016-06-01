<?php
	$variables = array();
	$fn = "./variables/mnt/symbols";
	echo "<meta http-equiv='Refresh' content='3';URL=<?php echo 'curlphone.php?'.rand(0,999);?>";
	echo "<style type='text/css'>";
	echo "td {font-size:50px; text-align:center; font-weight:normal;border: 1px solid black;}";
	echo "h1 {font-size: 300%}";
	echo "</style>";

	echo "<center>";
        echo "<h1>Phone Get Value</h1>";
	echo "<table width ='800'";
	//echo "<tr>";
	//echo "<td>Hello</td>";

	if (file_exists($fn))
	{
	   $data = file_get_contents($fn);
		$data = trim($data);
		$data = trim($data, ';');
		$data = explode(';', $data);
		for ($i=0; $i<count($data); $i++)
		{
			$variables[$i] = $date[$i];
			echo "<tr>";
			echo "<td>$i</td>";
			echo "<td>$data[$i]</td>";
			echo "</tr>";
		}
        //print_r($data);
        //var_dump($data);
	}
	
	echo "</tr>";
	echo "</table>";
        echo "<pre>";
	
	echo "</center>";
?>

