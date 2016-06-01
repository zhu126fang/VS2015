<?php
	// Write the config file. Config file has the following format:
	// [varname1]:[vartype1];[varname2]:[vartype2]; and so on.
	// The config file is persistent and will not be deleted by the server.
   if (isset($_POST['txt']))
		exec("echo '" . $_POST['txt'] . "' > /ffx/www/variables/config");
		
	// Write a single new value to a variable in the the PLC task. File has the following format:
	// [varname]:[vartype]=[value];
	// After being parsed and set the config file will be deleted by the server.
	if (isset($_POST['set']))
		exec("echo '" . $_POST['set'] . "' > /ffx/www/variables/mnt/values");
		
	// Relay a command to the variable server prg in CoDeSys. Commands:
	// 0 - Stop
	// 1 - Start
	// 2 - Reinit (parses the config file).
	// 3 - Read the values file and set variable.
	// As soon as the server receives a command it will delete the file.
	if (isset($_POST['cmd']))
		exec("echo '" . $_POST['cmd'] . "' > /ffx/www/variables/mnt/cmd");
		
	// Runs the script that pipes a hexdump of the current DOWNLOAD.SDB  to a text file on the
	// webserver. That textfile can be parsed in Javascript. This work around is necessary since 
	// server side php is too slow to parse big symbol files and Javascript/AJAX are really bad at 
	// handling binary files.
	if (isset($_POST['dump']))
		exec("./dumpSdb");
?>