<?php
require_once('common.php');

$res = mysql_query("select id, name, paper, errors, TIMESTAMPDIFF(MINUTE, last_ping, UTC_TIMESTAMP()) last_seen, notify_online, notify_errors, notify_paper_low, TIMESTAMPDIFF(MINUTE, notify_time, UTC_TIMESTAMP()) last_notify from terminals");
while ($row = mysql_fetch_array($res, MYSQL_ASSOC))
{
	if ($row['last_notify'] >= $config['notification_interval'])
	{
		$changed = false;
		if ($row['errors'] != $row['notify_errors']) $changed = true;
		$online = $row['last_seen'] < $config['offline_time'];
		if ($online != $row['notify_online']) $changed = true;
		$paperLow = $row['paper'] <= $config['paper_notification_limit'];
		if ($paperLow != $row['notify_paper_low']) $changed = true;
		if ($changed)
		{
			sendSmsNotification($row['id'], $row['name'], $online, $row['paper'], $row['errors'], null);			
		}
	}
}
?>

OK
