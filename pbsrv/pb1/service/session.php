<?php
require_once('common.php');
$box = $_GET['box'];
$user = $_GET['user'];
$pages = $_GET['pages'];
$money = $_GET['money'];
$pageCost = $_GET['cost'];
$banknotes = $_GET['banknotes'];
$errorCodes = $_GET['errors'];

ping_box($box);
handleErrors($box, $errorCodes, $user);
mysql_query("update users set money = money - $pages * $pageCost / 100 where user = '$user'");
mysql_query("insert into sessions (terminal, user, pages_printed, money_in, time, page_cost) " .
	" values ($box, '$user', $pages, $money, UTC_TIMESTAMP(), $pageCost)");
//mysql_query("update terminals set money = money + $money, banknotes = banknotes + $banknotes, paper = paper - $pages where id = $box");
?>
