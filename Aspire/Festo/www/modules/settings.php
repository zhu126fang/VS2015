<?php
	// Important to enable gettability with AJAX.
	header("Cache-Control: no-cache");
	// Includes
	include_once('../includes/generic.php');
?>

<script type="text/javascript">
	$("#applySettings").click(
		function (e)
		{
			applySettings($("#widthInput").val(), $("#showSidebarInput:checked").val());
		}
	);
	
	$(document).ready(
		function() 
		{
			var cookie = getCookie('width');
			$("#widthInput").val(cookie ? cookie : 600);
			cookie = getCookie('showSidebar');
			$("#showSidebarInput").attr('checked', (cookie ? (cookie == 'true' ? cookie : 'false') : 'true'));
		}
	);
</script>

<div class="section" id="<?php echo $id; ?>">
	<?php getSectionHead('Settings', $id); ?>
	<div class="sectionContent">
		<div class="inputRow"><span class="inputLabel">Content width:</span><input id="widthInput" class="inputBox" type="text" onkeydown="disableReturnInternetExplorer()" />px (>= 300)</div>
		<div class="inputRow"><span class="inputLabel">Show sidebar:</span><input id="showSidebarInput" type="checkbox" /></div>
		<div style="clear:both;" />
		<div class="inputRow"><input class="inputButton" id="applySettings" value="Ok" type="button" /></div>
	</div> <!-- section content -->
</div> <!-- section -->