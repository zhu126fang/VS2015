/*
	
	Loading/removing modules via AJAX.	

*/

var initVar; 					// Copy of the initial cookie on page load.

// Checks if a module is loaded already.
function isLoaded(module)
{
	return $("#"+module).length > 0;
}

// Remove a module.
function removeModule(module)
{
	if (module == 'variables') beforeRemoveVariables();
	$("#"+module).remove();
	updateCookie();
}

// Load a module.
function loadModule(module)
{
	if (!isLoaded(module))
	{
		$.get(
			"modules/" + module + ".php?foo=" + new Date().getTime(), 
			function (sText, sStatus)
			{
				if(sStatus == "success")
				$("#content").prepend(sText);
				updateCookie();
				if (initVar.length == getCookie('openmodules').length)
				{
					var modules = initVar.split("+");
					for (i=0; i<modules.length; i++)
					while($("#content > .section").eq(i).attr("id") != $("#"+modules[i]).attr("id")) moveUpModule(modules[i]);
					$("#loading").css("display", "none");
					$("#content").css("display", "");
				}
			}
		);
	}
}

function refreshModule(module)
{
	if (isLoaded(module))
	{
		$.get("modules/" + module + ".php?foo=" + new Date().getTime(),
			function (sText, sStatus) 
			{ 
				if (sStatus == "success")
				{
					$("#" + module).replaceWith(sText);
					if (module = 'system') adjustRack();
				}					
			}
		);
	}
}

// Move modules up and down
function moveUpModule(module)
{
	$("#"+module).prev().before($("#"+module));
	updateCookie();
}

function moveDownModule(module)
{
	$("#"+module).next().after($("#"+module));
	updateCookie();
}

function loadCpxModuleInfo(index)
{
	$.get(
		"../includes/cpxmoduleinfo.php?i=" + index + "&foo=" + new Date().getTime(), 
		function (sText, sStatus)
		{
			if (sStatus == "success")
				$("#cpxModulesContent").replaceWith(sText);
		}
	);
	setCookie("openCpxModuleInfo", index);
}

/* 

	Cookies
	
*/

// Update the cookie that remembers which modules are open.
function updateCookie()
{
	var cookie = "";
	$("#content").children(".section").each(
		function()
		{
			cookie = cookie + "+" + this.id;
		}
	);
	setCookie('openmodules', cookie.replace(/\+/, ''));
}

// Generic set cookie function.
function setCookie(name, value)
{
	document.cookie = name + "=" + escape(value) +
		";expires=" + new Date(new Date().getTime() + 2592000000).toGMTString() + // Expire in 30 days.
		";path=/" +
		";domain=" + location.hostname;
}

// Generic get cookie function.
function getCookie(name)
{
	var start = document.cookie.indexOf(name + "=");
	var len = start + name.length + 1;
	if ((!start) && (name != document.cookie.substring(0, name.length))) return null;
	if (start == -1) return null;
	var end = document.cookie.indexOf(';', len);
	if (end == -1) end = document.cookie.length;
	return unescape(document.cookie.substring(len, end));
}

/*
	
	Eventing
	
*/

$(document).ready(
	function ()
	{
		// Open modules
		var cookie = getCookie('openmodules');
		$("#content").css("display", "none");
		initVar = cookie;
		if (cookie)
		{
			var modules = cookie.split("+");
			for (i=0; i<modules.length; i++)
				loadModule(modules[i]);
		}
		else
		{
			loadModule('system');
			$("#loading").css("display", "none");
			$("#content").css("display", "");
		}
		
		// Reload settings
		applySettings(
			getCookie('width'), 
			getCookie('showSidebar') ? getCookie('showSidebar') == 'true' : true
		);
	}
);

/* 

	Settings
	
*/
function applySettings(width, showSidebar)
{
	// content width
	if (width)
	{
		width = parseInt(width);
		if (width >= 300)
		{
			$("#main").width(width);
			setCookie('width', width);
		}
	}
	
	// sidebar
	if (showSidebar)
	{
		$("#main").css("right", 185);
		$("body").css("background-image", "url(images/back_right.gif)");
		$("#sidebar").css("display", "");
		setCookie('showSidebar', true);
	}
	else
	{
		$("#sidebar").css("display", "none");
		$("#main").css("right", 10);
		$("body").css("background-image", "none");	
		setCookie('showSidebar', false);
	}
	
	adjustRack();
}

function adjustRack()
{
	// Compute the rackwidth dynamically.
	rackwidth = 0;
	$("#innerRack > img").each(
		function () { rackwidth = rackwidth + parseInt($(this).css('width').replace(/px/, '')); }
	);
	$("#innerRack").css('width', rackwidth);
	if ($("#main").width() <= rackwidth)
		$("#rack").height(138);
	else
		$("#rack").height(120);
}