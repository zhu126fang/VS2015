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
		function() 
		{
			var cookie = getCookie('openCpxModuleInfo');
			loadCpxModuleInfo(cookie ? cookie : '0');
		}
	);
</script>

<div class="section" id="<?php echo $id; ?>">
	<?php getSectionHead('CPX modules', $id); ?>
	<div class="sectionContent">
		<div class="cpxModulesNav" style="float: left;">
			<ul>
		<?php	
			for ($i = 0; $i<$moduleCount; $i++)
			{
				echo 
					'<li id="modulesNav' . $i . '">' . $i . 
					': <a href="#" onclick="loadCpxModuleInfo(\'' . $i . 
					'\');">' . $moduleInfos[$i]->shortText . ' - ' . 
					$moduleInfos[$i]->longText . '</a></li>';
			}
		?>
			</ul>
		</div>
		<div id="cpxModulesContent" />
		<div style="clear: both;" />
	</div> <!-- section content -->
</div> <!-- section -->