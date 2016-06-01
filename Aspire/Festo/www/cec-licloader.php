<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<title> CPX-CEC Web Interface </title>
<link rel="stylesheet" type="text/css" href="class.css" />
</head>
<body background="festo.gif">

<div class="headline">
<h1> CPX-CEC WebInterface </h1>
<h3> CPX-CEC CoDeSys License  </h3>
</div>

<div class="d1">
<?php
$target_file = "/proc/license/codesys";

if(move_uploaded_file($_FILES['uploadedlicensefile']['tmp_name'], $target_file ))
{
  $output = exec('/ffx/codesys/check_codesys_license');
  $ok = strstr($output,"ok");
  if ($ok) {
    echo "License file \"".  basename( $_FILES['uploadedlicensefile']['name']). "\" has been uploaded<br/><br/>";
    echo "To activate the new license, you need to ... <br/><br/> <b><a href=\"cec-reboot.php\">REBOOT</a></b> <br/><br/>... the CPX-CEC device<br/><br/>";
    echo "Note: Within CPX environment you will have to reboot<br> the whole CPX system";
  } else {
    echo "License file \"".  basename( $_FILES['uploadedlicensefile']['name']). "\" has been uploaded<br/>";
    echo "but seems to be invalid<br/><br/>";
    echo "<b><a href=\"cec-license.php\">Upload another license</a></b>";
  }
}
?>
</div>
<div class="d1">
<a href="cec-license.php">back</a>
</div>
</body>
</html>