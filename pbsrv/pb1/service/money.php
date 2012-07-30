<?php
require_once('common.php');
$box = $_GET['box'];
$user = $_GET['user'];
$money = $_GET['money'];

ping_box($box);
mysql_query("update users set money = money + $money where user = '$user'");
?>