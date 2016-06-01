<?php
// String just contains the plain command like 'dm0'.
function readCi($command)
{
	$fp = fsockopen("udp://127.0.0.1", 991, $errno, $errstr);
	if ($fp)
	{
		fwrite($fp, $command);
		$result = fread($fp, 1024);
		fclose($fp);
		return substr($result, 1);
	}
}
// If called as page read query CI command.
if (isset($_GET['query'])) echo readCi($_GET['query']);
?>
