<?php
require_once('../common/db.php');

$ERROR_CODES = 
array(
	'Принтер:Выключен' => 0x1,
    'Принтер:Заминка бумаги' => 0x2,
    'Принтер:Нет бумаги' => 0x4,
    'Принтер:Открыта дверца' => 0x8,
    'Принтер:Другая ошибка' => 0x10,

    'Термопринтер:Нет бумаги' => 0x20,
    'Термопринтер:Другая ошибка' => 0x40,
	'Питание:Батарея' => 0x80,
	
	'Принтер:Нет тонера' => 0x100,
);

function getErrors($errors)
{
	global $ERROR_CODES;
	$ret = array();
	foreach ($ERROR_CODES as $error => $code)
		if ($errors & $code)
		{
			array_push($ret, $error);
			$errors ^= $code;
		}
	if ($errors > 0) array_push($ret, 'Другие ошибки(0x' . dechex($errors) . ')');
	return $ret;
}

function ping_box($box)
{
	mysql_query("update terminals set last_ping = UTC_TIMESTAMP(), ip_addr = '{$_SERVER['REMOTE_ADDR']}' where id = $box");
}

function handleErrors($box, $errorCodes, $user)
{
	$res = mysql_query("select name, errors, paper from terminals where id = '$box'");
	$terminalName = mysql_result($res, 0, 0);
	$prevErrors = mysql_result($res, 0, 1);
	$paper = mysql_result($res, 0, 2);
	if ($prevErrors != $errorCodes)
	{
		mysql_query("update terminals set errors = $errorCodes where id = '$box'");
		if (isset($user)) sendSmsNotification($box, $terminalName, true, $paper, $errorCodes, $user);
		// else cron.php
	}
}

function sendSmsNotification($box, $terminalName, $online, $paper, $errorCodes, $user)
{
	global $config;
	$online = $online ? 1 : 0;
	$query = "update terminals set notify_online = $online, notify_errors = $errorCodes, " . 
		" notify_paper_low = $paper <= {$config['paper_notification_limit']}, notify_time = UTC_TIMESTAMP() where id = $box";
	mysql_query($query);
			
	$smsText = "Box:$terminalName(id=$box)." . ( $online ? "Вкл" : "Выкл" ) . ".Бумага:$paper.Ошибки:";
	$descriptions = getErrors($errorCodes);
	if (count($descriptions) > 0)
	{
		$smsText .= implode(";", $descriptions) . ".";
	}
	else
	{
		$smsText .= "Нет.";
	}
	if (isset($user)) $smsText .= "Клиент:$user";
	
	sendSMS($smsText);
	
	$result = mysql_query("select a.phones phones, a.emails emails from admins a join terminals t on t.admin = a.id where t.id = $box");
	$ap = mysql_result($result, 0, 0);
	 if ($ap != '')
	 {
		$apa = explode(',', $ap);	
		foreach ($apa as $p) sendSMS($smsText, $p);	
	}
	$ae = mysql_result($result, 0, 1);
	 if ($ae != '')
	{
		$aea = explode(',', $ae);
		foreach ($aea as $p) sendEmail($smsText, $p);	
	}
}

function sendSMS($text, $to = null)
{
	global $config;
	if (!isset($to)) $to = $config['sms_admin'];	
	if ($config['sms_test_mode'])
	{
		echo "SMS $to : $text<br/>\r\n";
	}
	else
	{
		$url = sprintf($config['sms_gateway'], $to, urlencode($text));
		$h = @fopen($url, 'r');
		if (FALSE !== $h) fclose($h);	
	}
}

function sendEmail($text, $to)
{
	global $config;
	if ($config['email_test_mode'])
	{
		echo "Email $to : $text<br/>\r\n";
	}
	else
	{
		$url = sprintf($config['email_gateway'], $to, urlencode($text));
		$h = @fopen($url, 'r');
		if (FALSE !== $h) fclose($h);	
	}
}

?>
