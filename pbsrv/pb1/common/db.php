<?php
require_once('config.php');
@mysql_connect($config['db_server'], $config['db_user'], $config['db_password']);
@mysql_select_db($config['db_database']);
?>