/*
	The code below parses the hexdump of a binary CoDeSys symbol file. The data is used to 
	display variables in a table. The script generating the hexdump is 
	/ffx/www/variables/dumpSdb. 
	
	Three variables are important to work with the results:
	
	$vars:		The list of variables in the .SDB file. Each list entry is an array containing
					two fields 'type' and 'name'. 'name' is the variable name. 'type' is an integer
					referring to an index in the $types array.
	$types:     A list of types actually used in the .SDB file. The array index equals the file 
					internal index. The values refer to index of the $typeClass array.
	$typeClass: Variable types are enumerated in the .SDB file. The INT obtained from the file 
					can be translated to STRING in this static array.
*/

// These are file internal methods, not that it would hurt anyone to call them.
// But no one needs to really.
var data;

function getUlong(byteNr)
{
	return parseInt(data[byteNr/2+1], 16) << 16 | parseInt(data[byteNr/2], 16)
}

function getChar(byteNr)
{
	if (data[Math.floor(byteNr/2)].substr((byteNr%2-1)*-2, 2) == '00') return '';
	else return unescape("%" + data[Math.floor(byteNr/2)].substr((byteNr%2-1)*-2, 2));
}	

// parseDownloadSdb() is a call back for the AJAX GET request. The parameter
// are the file contents.
function parseDownloadSdb(x)
{
	data = x.split(';');
	
	// Type class definition from the 3S documentation
	// Unsupported data types are commented out.
	var typeClass = new Array();
	typeClass[0] = 'BOOL';
	typeClass[1] = 'INT';
	typeClass[2] = 'BYTE';
	typeClass[3] = 'WORD';
	typeClass[4] = 'DINT';
	typeClass[5] = 'DWORD';
	typeClass[6] = 'REAL';
	typeClass[7] = 'TIME';
	typeClass[8] = 'STRING';
	//typeClass[9] = 'ARRAY';
	//typeClass[10] = 'ENUM';
	//typeClass[11] = 'USERDEF';
	//typeClass[12] = 'BITORBYTE';
	//typeClass[13] = 'POINTER';
	typeClass[14] = 'SINT';
	typeClass[15] = 'USINT';
	typeClass[16] = 'UINT';
	typeClass[17] = 'UDINT';
	typeClass[18] = 'DATE';
	typeClass[19] = 'TOD';
	typeClass[20] = 'DT';
	//typeClass[21] = 'VOID';
	typeClass[22] = 'LREAL';
	//typeClass[23] = 'REF';
	typeClass[28] = 'LWORD';

	// Global header 
	var headerSize = getUlong(4);
	
	// Type list header
	var typeListSize = getUlong(headerSize + 4);
	var typeListCount =  getUlong(headerSize + 12);
	
	// Type elements
	var types = new Array();
	var next = headerSize + 16;
	for (i = 0; i<typeListCount; i++)
	{
		types[i] = getUlong(next + 8);
		next = next + getUlong(next + 4);
	}
	
	// Var list header 
	next = headerSize + typeListSize;
	var varListSize = getUlong(next + 4);
	var varListCount = getUlong(next + 12);
	
	// Var elements
	next = next + 16;
	var vars = new Array();
	for (var i=0; i<varListCount; i++)
	{
		var tmptype = getUlong(next + 8);
		vars[i] = new Array();
		vars[i][0] = tmptype
		var tmpStr = '';
		var tmpSize = parseInt(data[(next + 24)/2], 16);
		for (var j=0; j<tmpSize; j++)
			tmpStr += getChar(next + 26 + j);
		vars[i][1] = tmpStr;
		next = next + getUlong(next + 4);
	}
	
	// Inject results to document
	var result = '';
	for (var i=0; i<vars.length; i++)
	{
		if (typeof(typeClass[types[vars[i][0]]]) != 'undefined') result += '<tr class="varRow"><td>' + vars[i][1] + '</td><td>' + typeClass[ types[ vars[i][0] ] ] + '</td><td><input class="varUse" type="checkbox" /></td></tr>';
	}
	if (result.length > 0)
	{
		$("#replaceMe").replaceWith(result);
		$("#varTable").css("display", "");
		$("#loading").css("display", "none");
	}
	else
	{
		$("#loading").html("<p><img src='../images/Error.gif' style='margin-right: 3px;'/>Symbol file is empty or does not exist!</p>");
	}
}