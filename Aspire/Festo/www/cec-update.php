<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<title>CPX-CEC Web Interface </title>
<link rel="stylesheet" type="text/css" href="class.css" />

<script type="text/javascript">

var i, dir;

function prog()
{
//  document.getElementById("d1").innerHTML="";	
  document.getElementById("d2").style.width=0;  
  i=0;
  dir = 0;
  progBar(); 
}

function progBar()
{

    document.getElementById("d2").style.width=i+"px";
    
    if(dir == 0)
    {
      i+=10;   
      if(i > 300)
      {
        dir = 1;
        i = 290;
      }
      
    }
    else
    {
      i-=10;   
      if(i < 0)
      {
        dir = 0;
        i = 10;
      }
    }
    
//      i+=10;   
//      if(i>300)
//        i = 0;
      setTimeout("progBar();", 100); 
    
}
</script>


<body background="festo.gif">
<div class="headline">
<h1> CPX-CEC WebInterface </h1>
<h3> CPX-CEC Update  </h3>
</div>

<div class="disclaimer">
<h2> Important Note: </h2>
Controller will be shut down! <br>
Firmware download may take several minutes! <br>
(theoretically up to 10 minutes)<br>
Do not switch off the device until you see the reboot screen!<br>
After reboot the ERROR LED will blink until<br> the complete firmware is loaded into flash!<br>
Do not switch off the device while <br>the ERROR LED is blinking!<br>
<br>
</div>

<div class="d1">
<form enctype="multipart/form-data" action="cec-uploader.php" method="POST">
<input type="hidden" name="MAX_FILE_SIZE" value="8388608" />
Choose a cec file: <input name="uploadedfile" type="file" /><br /> <br />
<input type="submit" value="perform CPX-CEC update" onclick="prog();"/><br/>
</form>
<br>
<center>
<div id="d2" style="position:relative;top:0px;left:0px;background-color:#333333;height:5px;width:0px;padding-top:5px;padding:0px;">
</div>
</center>
</div>

<div class="d1">
<a href="index.html">back</a>
</div>
</body>
</html>