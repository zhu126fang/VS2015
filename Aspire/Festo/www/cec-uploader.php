<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<title> CPX-CEC Web Interface </title>
<link rel="stylesheet" type="text/css" href="class.css" />
</head>
<body background="festo.gif">
<div class="headline">
<h1> CPX-CEC WebInterface </h1>
<h3> CPX-CEC Software Update </h3>
</div>

<div class="d1">
<?php
$target_path = "/ffx/update/";
shell_exec('killall plclinux');
if(move_uploaded_file($_FILES['uploadedfile']['tmp_name'], $target_path . basename($_FILES['uploadedfile']['name'])))
{
//    $fsrc = $target_path . basename( $_FILES['uploadedfile']['name']);
//    $fdst = $target_path . "_license.dat";
//    if(rename($fsrc, $fdst) == TRUE)
//{
      echo "The CPX-CEC package ".  basename( $_FILES['uploadedfile']['name']). " has been uploaded<br/><br/>";
      echo "To <b>INITIATE</b> the update process, you need to ... <br/><br/> <b><a href=\"cec-reboot.php\">REBOOT</a></b> <br/><br/>... the CPX-CEC device";
//    }
//    else
//    {
//      echo "fsrc = " . $fsrc . "<br>";
//      echo "fdst = " . $fdst . "<br>";
//      echo "<h3>The file ".  basename( $_FILES['uploadedfile']['name']). " was not renamed! ERROR !</h3>";
//    }

} else{
    echo "There was an error uploading the file, please try again! (you cannot upload files greater than 8Mb).";
}
 # echo 'Here is some more debugging info:';
 # print_r($_FILES);
?>
</div>
<div class="d1">
<a href="index.html">back</a>
</div>
</body>
</html>