<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<title> CPX-CEC Web Interface </title>
<link rel="stylesheet" type="text/css" href="class.css" />
</head>
<body BGCOLOR="yellow">

<div class="headline">
<h1> CPX-CEC WebInterface </h1>
<h3> CPX-CEC Reboot  </h3>
</div>

<div class="d1">
CPX-CEC is rebooting ... <br> <br>

<b>DURING</b> the automatically system update the ERROR LED is <b>BLINKING FAST</b>. <br><br>

Wait until the system update finished (ERROR LED is not blinking fast any more) and
<b>SWITCH OFF</b> the power supply briefly for the whole CPX-CP terminal.<br><br>

After successful update you may <a href="index.html">RETURN</a> to the main page.
</div>

</body>
<?php
  exec("reboot");
?>
</html>
