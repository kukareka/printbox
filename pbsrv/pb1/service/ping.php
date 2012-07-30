<?php
require_once('common.php');
$box = $_GET['box'];
$paper = $_GET['paper'];
$money = $_GET['money'];
$banknotes = $_GET['banknotes'];
$toner = $_GET['toner'];
$errors = $_GET['errors'];
@handleErrors($box, $errors);
mysql_query("update terminals set last_ping = UTC_TIMESTAMP(), paper = $paper, money = $money, banknotes = $banknotes, toner = $toner, ip_addr = '{$_SERVER['REMOTE_ADDR']}' where id = $box");
?>
OK