<?php 
	// Important to enable gettability with AJAX.
	header("Cache-Control: no-cache");
	include_once('../includes/generic.php');

	// Read device uid.
	$filename = "/proc/config/id";
	$handle = fopen($filename, "r");
	$uid = fread($handle, 50);
	fclose($handle);
	// Read license state
	$licenseState = exec('/ffx/codesys/check_codesys_license');
	// Read license
	$filename = "/proc/license/codesys";
	$handle = fopen($filename, "r");
	$license = fread($handle, 1024);
	fclose($handle);	
?>
<div class="section" id="<?php echo $id; ?>">
	<?php getSectionHead('CoDeSys license', $id); ?>
	<div class="sectionContent">
		<p>Unique Device ID : <?php echo $uid; ?></p>
		<p>Current license state: <?php echo $licenseState; ?></p>
		<p>Current CoDeSys license:<br/>
		<?php echo $license;	?></p>
	</div> <!-- section content -->
</div> <!-- section -->