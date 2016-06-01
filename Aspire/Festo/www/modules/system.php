<?php 
	// Important to enable gettability with AJAX.
	header("Cache-Control: no-cache");
	// Includes
	include_once('../includes/ini.php');
	include_once('../includes/generic.php');
	include_once('../includes/cpxsysteminfo.php');
?>

<script type="text/javascript">
	$(document).ready(
		function() { adjustRack(); }
	);
</script>

<div class="section" id="<?php echo $id; ?>">
	<?php getSectionHead('CPX System', $id); ?>
	<div class="sectionContent">
		<div id="rack">
			<div id="innerRack">
				<img style="background: url('images/moduleImages/hintergrund-10-cpx.gif');" src="images/blank.gif" class="firstModuleBmp" />
				<?php
					for ($i = 0; $i<$moduleCount; $i++)
					{
						// Get bitmap.
						if (isset($cpxBitmaps[$moduleInfos[$i]->id])) 
							$bmp = strtolower($cpxBitmaps[$moduleInfos[$i]->id]->bitmap);
						else 
							$bmp = 'unknown';
							
						$bmp = 'images/moduleImages/' . $bmp . '.gif';
						
						// Set bmp as background.
						echo '<img style="background: url(\'' . $bmp . '\'); background-repeat: no-repeat; ';
						
						// Fugly hack :( Pneumatic modules have variable widths.
						if ($cpxBitmaps[$moduleInfos[$i]->id]->type == 'pneumatic')
						{
							$size = getimagesize('../' . $bmp);
							echo 'width: ' . $size[0] . 'px;';
						}
						echo '"';
						
						// See if module has an error
						echo ($moduleInfos[$i]->status != 0 ? 'src="images/alert.gif"' : 'src="images/blank.gif"');
						
						// Determine style
						switch ($cpxBitmaps[$moduleInfos[$i]->id]->type)
						{
							case "valve":
								echo ($i < $moduleCount-1 ? 'class="ModuleBmp" />' : 'class="valveLastModuleBmp" />');
								break;						
							case "pneumatic":
								echo 'class="ModuleBmp" />';
								break;
							case "default":
							default: 
								echo ($i < $moduleCount-1 ? 'class="ModuleBmp" />' : 'class="defLastModuleBmp" />');
								break;
						}
					}
				?>
			</div> <!-- innerRack -->
		</div> <!-- rack -->
		<div style="clear: both;" />
		<table>
			<tr class="firstRow"><td>#</td><td>Module</td><td>Status</td></tr>
			<?php
				for ($i = 0; $i<$moduleCount; $i++)
				{
					echo '<tr><td>' . $i . '</td><td>' . $moduleInfos[$i]->shortText . ' - ' . $moduleInfos[$i]->longText . '</td><td>' . $cpxErrors[$moduleInfos[$i]->status] .'</td></tr>';
				}
			?>
		</table>
	</div> <!-- section content -->
</div> <!-- section -->