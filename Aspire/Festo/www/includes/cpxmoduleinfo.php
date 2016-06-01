<?php
	// Important to enable gettability with AJAX.
	header("Cache-Control: no-cache");
	
	// Includes
	include_once("ci.php");
	include_once("cpxsysteminfo.php");
	include_once("ini.php");
	
	// Module index
	$moduleIndex = $_GET['i'];
	
	// Bitmap
	$bmp = strtolower($cpxBitmaps[$moduleInfos[$moduleIndex]->id]->bitmap);
	if ($bmp == '') $bmp = 'unknown';
	
	// Input channels
	for ($i = 0; $i < $moduleInfos[$moduleIndex]->inputCount; $i++)
	{
		$inputDiag[$i] = readCi("dse" . $moduleIndex . "." . $i);
		$inputValue[$i] = readCi("de" . $moduleIndex . "." . $i);
	}
	
	// Output channels
	for ($i = 0; $i < $moduleInfos[$moduleIndex]->outputCount; $i++)
	{
		$outputDiag[$i] = readCi("dsa" . $moduleIndex . "." . $i);
		$outputValue[$i] = readCi("da" . $moduleIndex . "." . $i);
	}
?>
<div id="cpxModulesContent" style="float: left; width: auto; padding-left: 5px; border-left: 1px solid #D8DCE1">
	
	<table>
		<tr class="firstRow"><td colspan="3" class="firstCell"><?php echo $moduleInfos[$moduleIndex]->shortText . " - " . $moduleInfos[$moduleIndex]->longText; ?></td></tr>
		<tr><td rowspan="4"><img style="background: url('images/moduleImages/<?php echo $bmp ?>.gif'); margin: 0; padding: 0;" class="ModuleBmp" src="images/blank.gif" /></td><td>Module #</td><td style="text-align: right"><?php echo $moduleInfos[$moduleIndex]->index; ?></td></tr>
		<tr><td>Code</td><td style="text-align: right"><?php echo $moduleInfos[$moduleIndex]->code; ?></td></tr>
		<tr><td>Subcode</td><td style="text-align: right"><?php echo $moduleInfos[$moduleIndex]->subCode; ?></td></tr>
		<tr><td>Status</td><td style="text-align: right"><?php echo $cpxErrors[$moduleInfos[$moduleIndex]->status]; ?></td></tr>
	</table>
	<div style="clear: both;" />
	<?php if (count($inputDiag) > 0) { ?>
	<table style="float: left; margin-right: 5px;">
		<tr><td colspan="3" class="firstCell">Input channels</td></tr>
		<tr class="firstRow"><td>#</td><td>Value</td><td>Status</td></tr>
		<?php for ($i = 0; $i < count($inputDiag); $i++)
				{
					echo '<tr><td style="text-align: right">' . $i . '</td><td style="text-align: right">' . $inputValue[$i] . '</td><td>' . $cpxErrors[$inputDiag[$i]] . '</td></tr>';
				}
		?>
	</table>
	<?php } ?>
	
	<?php if (count($outputDiag) > 0) { ?>
	<table style="float: left;">
		<tr><td colspan="3" class="firstCell">Output channels</td></tr>
		<tr class="firstRow"><td>#</td><td>Value</td><td>Status</td></tr>
		<?php for ($i = 0; $i < count($outputDiag); $i++) 
				{
					echo '<tr><td style="text-align: right">' . $i . '</td><td style="text-align: right">' . $outputValue[$i] . '</td><td>' . $cpxErrors[$outputDiag[$i]] . '</td></tr>';
				}
		?>
	</table>
	<?php } ?>
</div>