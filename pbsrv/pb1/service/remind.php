<?php
require_once('common.php');
$box = $_GET['box'];
$user = $_GET['user'];
ping_box($box);
$result = mysql_query("select password from users where user = '$user'");
if (mysql_num_rows($result) == 1)
{
	$password = mysql_result($result, 0, 0);
	sendSMS("ѕароль:$password. «береж≥ть його в над≥йному м≥сц≥.", $user);
	echo "OK";
}
else
{
	echo "FAIL";
}
?>