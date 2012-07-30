<?php
header('Content-type: text/plain');
require_once('common.php');
$card = strtoupper($_GET['card']);
$user = $_GET['user'];

$query = "update cards set activated = true, user = '$user' where UPPER(card) = '$card' and activated = false;";
$result = mysql_query($query);
if (mysql_affected_rows() == 0)
{
	echo "FAIL";
}
else
{
	$result = mysql_query("select price from cards  where card = '$card'");
	$price = mysql_result($result, 0, 0);
	echo "<price>$price</price>";	
	$result = mysql_query("select password, money from users where user = '$user'");
	if (mysql_num_rows($result) == 0)
	{
		//new user
		$newUser = 1;
		$password = rand(1000000, 9999999);
		$balance = 5.0 + $price;
		mysql_query("insert into users (user, password, money) values ('$user', '$password', $balance)");
		sendSMS("ѕароль:$password.ƒ€куЇмо за реЇстрац≥ю!¬аш бонус 5грн+{$price}грн", $user);
	}
	else
	{
		mysql_query("update users set money = money + $price where user = '$user';");
	}
}
?>
