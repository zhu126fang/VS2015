<?php 
	include_once('../includes/ci.php');
	class moduleInfo
	{
		var 	$index,			// Index in rack
				$code,
				$subCode, 
				$shortText, 
				$longText,
				$inputCount,
				$inputWidth,
				$inputType,
				$outputCount,
				$outputWidth,
				$outputType,
				$id,				// Id for matching to bitmaps etc.
				$status;
		
		function moduleInfo($i, $general, $input, $output, $diag)
		{
			$this->index = $i;
			$tmp = split(',', $general);
			$this->code = $tmp[0];
			$this->subCode = $tmp[1];
			$this->shortText = $tmp[2];
			$this->longText = $tmp[3];
			$tmp = split(',', $input);
			$this->inputCount = $tmp[0];
			$this->inputWidth = $tmp[1];
			$this->inputType = $tmp[2];
			$tmp = split(',', $output);
			$this->outputCount = $tmp[0];
			$this->outputWidth = $tmp[1];
			$this->outputType = $tmp[2];
			$tmp = split('=', $diag);
			$this->status = $tmp[1];
			
			$this->id = 0;
			$tmp = $this->inputCount * $this->inputWidth;
			if ($this->inputWidth > 1) $tmp /= 8;
			$this->id |= $tmp << 24;
			$tmp = $this->outputCount * $this->outputWidth;
			if ($this->outputWidth > 1) $tmp /= 8;
			$this->id |= $tmp << 16 | $this->code << 8 | $this->subCode;			
		}
	}
	
	// Read module info
	$moduleCount = readCi('dm');
	$moduleInfos = array();
	for ($i = 0; $i<$moduleCount; $i++)
	{
		$general = readCi('dm'.$i);
		$input = readCi('dme'.$i);
		$output = readCi('dma'.$i);
		$status = readCi('ds'.$i);
		$moduleInfos[$i] = new moduleInfo($i, $general, $input, $output, $status);
	}
?>