<?php
	// Important to enable gettability with AJAX.
	header("Cache-Control: no-cache");
	// Includes
	include_once('../includes/generic.php');
	include_once('../includes/ci.php');
	include_once('../includes/ini.php');

	class TimeStamp
	{
		var $time;
		
		// $cpxTimeStamp is an array with 4 int elements (days, hours, minutes, seconds).
		function TimeStamp($cpxTimeStamp)
		{
			$this->time = $cpxTimeStamp;
		}
		
		function UnixTime()
		{
			return $this->time[0] * 864000 + $this->time[1] * 3600 + $this->time[2] * 60 + $this->time[3];
		}
		
		function ToString()
		{
			return $this->time[0] . 'd ' . $this->time[1] . 'h '. $this->time[2] . 'm ' . $this->time[3] . 's';
		}
	}
	
	class TraceInfo
	{
		var $data, $time;
		var $isEnd = false;
		
		function TraceInfo($args)
		{
			$this->data = $args;
			$this->time = new TimeStamp(array_slice($this->data, 0, 4));
		}
		
		// Currently unused.
		function IsFirstAfterPowerOn($value)
		{
			return $this->data[4] & 0x80;
		}
		
		// True 	- trace entry just informs about bootup.
		function IsSystemStart()
		{
			return $this->IsGlobal() & $this->data[7] == 1 & $this->data[8] == 0;
		}
		
		// True	- trace entry doesn't concern a specific module/channel but the whole rack.
		// False - trace entry concerns a specific module/channel.
		function IsGlobal()
		{
			return $this->data[5] == 0;
		}
		
		// True 	- trace entry concerns a specific module not a specific channel.
		// False - trace entry concerns a specific channel.
		function IsModuleSpecific()
		{
			return $this->data[5] != 0 & ($this->data[7] & 0x40);
		}
		
		// Returns O or I for channel specific trace entries.
		function ChannelType()
		{
			return $this->data[7] & 0x80 ? "O" : "I"; 
		}
		
		// Returns the Error number that can be resolved via the ini file.
		function ErrorNumber()
		{
			return $this->data[8]; 
		}
		
		// Humpty dumpty.
		function ModuleCode()
		{
			return $this->data[5];
		}
		
		// Humpty dumpty.
		function ModulePosition()
		{
			return $this->data[6];
		}
		
		// Returns the channel number for channel specific trace entries.
		function ChannelNumber()
		{
			return $this->data[7] & 0x3F;
		}
		
		// Returns the duration (in seconds) of a trace entry if it has 'ended' yet or -1 otherwise.
		function Duration()
		{
			if ($this->end)
			{
				return $this->end->time->UnixTime() - $this->time->UnixTime();
			}
			else
			{
				return -1;
			}
		}
		
		// Compares to another TraceInfo if it is a matching 'end'.
		function CompareEnd($tmp)
		{
			return 
				$this->data[5] == $tmp->data[5] & 
				$this->data[6] == $tmp->data[6] & 
				$this->data[7] == $tmp->data[7] & 
				$this->data[8] != 0 & // Is a beginning trace entry.
				$tmp->data[8] == 0 &  // Is an ending trace entry.
				$this->data[9] == $tmp->data[9]; 
		}
	}
	
	function TimeSpanFormat($unixTime)
	{
		if ($unixTime == -1) return 'still active...';
		$result = "";
		$tmp = 0;
		if ($unixTime >= 86400) // days
		{
			$tmp = $unixTime % 86400;
			$unixTime = $unixTime - $tmp;
			$result = $result . $unixTime / 86400 . "d ";
			$unixTime = $tmp;
		}
		
		if ($unixTime >= 3600) // hours
		{
			$tmp = $unixTime % 3600;
			$unixTime = $unixTime - $tmp;
			$result =$result .  $unixTime / 3600 . "h ";
			$unixTime = $tmp;
		}
		
		if ($unixTime >= 60) // minutes
		{
			$tmp = $unixTime % 60;
			$unixTime = $unixTime - $tmp;
			$result = $result . $unixTime / 60 . "m ";
			$unixTime = $tmp;
		}
		return $result . $unixTime . "s";
	}

	function DateFormat($unixTime)
	{
		return date("F j, Y, g:i a", $unixTime);
	}
	
	// Time
	$tmp = split(',', readCi('T'));
	$sysUptime = new TimeStamp(array_slice($tmp, 0, 4));
	$sysPowerOn = time() - $sysUptime->UnixTime();
	
	// Read trace data
	$traceCount = readCi('TE');
	$traceTable = array();
	for ($i=0; $i < $traceCount; $i++)
		$traceTable[$i] = new TraceInfo(split(',', readCi('T' . $i)));
	
	// Determine which trace entries have 'ended' yet.
	for ($i=$traceCount-1; $i >= 0; $i--)
	{
		if ($traceTable[$i]->IsSystemStart()) continue;
		for($j = $i-1; $j >= 0; $j--) 
		{
			if ($traceTable[$i]->CompareEnd($traceTable[$j]))
			{
				//echo $i . ": " . $j . "|"; // Debug info.
				$traceTable[$i]->end = $traceTable[$j];
				break;
			}
		}
	}
	
	// Update traceCount.
	$traceCount = 0;
	foreach ($traceTable as $tmp)
	{
		if ($tmp->ErrorNumber() != 0 | $tmp->IsSystemStart()) $traceCount++;
	}
?>

<div class="section" id="<?php echo $id; ?>">
	<?php getSectionHead('Trace', $id); ?>
	<div class="sectionContent">
		<table>
			<tr><td colspan="2" class="firstRow">Info</td></tr>
			<tr><td>System time</td><td style="text-align: right"><?php echo date("F j, Y, g:i a"); ?></td></tr>
			<tr><td>System started</td><td style="text-align: right"><?php echo DateFormat($sysPowerOn); ?></td></tr>
			<tr><td>Uptime</td><td style="text-align: right"><?php echo $sysUptime->ToString(); ?></td></tr>
		</table>

		<table>
			<tr><td class="firstRow">Start</td><td class="firstRow">Duration</td><td class="firstRow">Module #</td><td class="firstRow">Channel #</td><td class="firstRow">Message</td></tr>
			<?php if($traceCount == 0) { ?>
			<tr><td colspan="5">Trace table is empty.</td></tr>
			<?php } else { ?>
		
			<?php 
				foreach ($traceTable as $tmp)
				{
					if ($tmp->ErrorNumber() == 0 & !$tmp->IsSystemStart()) continue;
					
					echo '<tr><td>' . DateFormat($sysPowerOn + $tmp->time->UnixTime()) . '</td>';
					if ($tmp->IsSystemStart())
					{
						echo '<td style="text-align: right">-</td><td style="text-align: right">-</td><td style="text-align: right">-</td><td>System start...</td>';
					}
					else
					{
						echo '<td style="text-align: right">' . TimeSpanFormat($tmp->Duration()) . '</td>';
						if ($tmp->IsGlobal())
						{
							echo '<td style="text-align: right">-</td><td style="text-align: right">-</td>';
						}
						else
						{					
							echo '<td style="text-align: right">' . $tmp->ModulePosition() . ' (Code ' . $tmp->ModuleCode() . ')</td>';
							if ($tmp->IsModuleSpecific()) // Concerns whole module
							{
								echo '<td style="text-align: right">-</td>';
							}
							else // concerns specific channel
							{
								echo '<td style="text-align: right">' . $tmp->ChannelNumber() . ' (' . $tmp->ChannelType() . ')</td>';
							}
						}
						echo '<td>' . $cpxErrors[$tmp->ErrorNumber()] . '</td>';
					}
				}
			?> 
		<table>
		<?php } ?>
	</div> <!-- section content -->
</div> <!-- section -->