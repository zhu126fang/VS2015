<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<title> CPX-CEC Web Interface </title>
<link rel="stylesheet" type="text/css" href="class.css" />
</head>
<body background="festo.gif">

<div class="headline">
<h1> CPX-CEC WebInterface </h1>
<h3> CPX-CEC information  </h3>
</div>

<div class="d1">
CPX-CEC: <br>
<?php
  readfile("/etc/issue");
?>
<br>
Hardware version:
<?php
  readfile("/proc/config/hardware");
?>
<br><br>
CoDeSys Version: <br>
<?php
  readfile("/ffx/codesys/version.txt");
?>

<br><br>
Unique ID: <br>
<?php
  readfile("/proc/config/id");
?>
</div>

<div class="d1">
Current network settings: <br>
<?php

  echo "Hostname: "; system("hostname"); echo "<br>";

  $dhcp = file("/proc/config/dhcp");
  if(strchr($dhcp[0], "1"))
    {
      echo "DHCP: 1 <br>";
      $neta = file("/tmp/network.conf");
      echo "IP-Address: $neta[1] <br>";
      echo "Netmask: $neta[3] <br>";
      echo "Default Gateway: $neta[5] <br>";
    }
  else
    {
      echo "DHCP: 0 <br>";
      echo "IP-Address: ";
      readfile("/proc/config/ip"); echo "<br>";
      echo "Netmask: ";
      readfile("/proc/config/netmask"); echo "<br>";
      echo "Default Gateway: ";
      readfile("/proc/config/gateway"); echo "<br>";
    }

  // try to get a nameserver
  $ns = exec('cat /etc/resolv.conf | grep nameserver | sed s/nameserver\ //');
  if($ns != "")
    {
      echo "DNS: $ns <br>";
  }

  echo "MAC: ";
  readfile("/proc/config/mac"); echo "<br>";

?>

</div>


<div class="d1">
<a href="index.html">back</a>
</div>

</body>
</html>
