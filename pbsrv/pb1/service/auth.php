<?php
header('Content-type: text/plain');
require_once('common.php');
$box = $_GET['box'];
$user = $_GET['user'];

ping_box($box);
$result = mysql_query("select password, money from users where user = '$user'");
if (mysql_num_rows($result) == 0)
{
	//new user
	$newUser = 1;
	$password = rand(1000000, 9999999);
	$balance = 0.0;
	mysql_query("insert into users (user, password, money) values ($user, $password, $balance)");
	sendSMS("ѕароль:$password. ƒ€куЇмо за реЇстрац≥ю!", $user);
}
else
{
	$newUser = 0;
	$password = mysql_result($result, 0, 0);
	$balance = mysql_result($result, 0, 1);	
}
$passwordMD5 = md5($password);
echo "$passwordMD5\n";
echo "$newUser\n";
echo "$balance\n";
?>
