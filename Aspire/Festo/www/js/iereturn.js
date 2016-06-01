// This method disables automatic page refresh 
// on pressing RETURN in input forms with IE.
function disableReturnInternetExplorer()
{
	if (window.event)
		return window.event.keyCode != 13;
}