<?php
require_once('common.php');
$box = $_GET['box'];
$errorCodes = $_GET['errors'];
$user = @$_GET['user'];

ping_box($box);
@handleErrors($box, $errorCodes, $user);
?>