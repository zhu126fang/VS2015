<?php 
	// Important to enable gettability with AJAX.
	header("Cache-Control: no-cache");
	include_once('../includes/generic.php');
?>
<div class="section" id="<?php echo $id; ?>">
	<script type="text/javascript">
		$("#terminalInput").keypress(
			function (e)
			{
				if (e.which == 13)
					terminalSend($("#terminalInput").val());
			}
		);
	</script>
	<?php getSectionHead('CI Terminal', $id); ?>
	<div class="sectionContent">
		<div id="terminalOutput" />
		<div id="terminalLabel">CI:</div><input onkeydown="disableReturnInternetExplorer()" id="terminalInput" type="text" />
		<div style="padding: 8px;" />
	</div> <!-- section content -->
</div> <!-- section -->