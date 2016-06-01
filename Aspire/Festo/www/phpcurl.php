<?php
	$curl = curl_init();
	curl_setopt($curl, CURLOPT_URL,"/ffx/www/variables/mnt/symbols');
	curl_setopt($curl, CURLOPT_HEADER, 1);
	curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);
	$data = curl_exec($curl);
	curl_close($curl);
	var_dump($data);
	print_r($data);
?>