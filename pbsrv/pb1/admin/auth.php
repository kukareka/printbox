<?php
session_start();
if (isset($_GET['pin']))
{
	$pin = $_GET['pin'];
	if ($pin == $config['root_pin'])
	{
		$_SESSION['login'] = 'root';
		$_SESSION['role'] = 'root';
	}
	else
	{
		$result = mysql_query("select id from admins where pin = $pin");
		if (mysql_num_rows($result) == 1)
		{
			$_SESSION['login'] = mysql_result($result, 0, 0);
			$_SESSION['role'] = 'admin';
		}
	}
}
$login_role = $_SESSION['role'];
if (($login_role != 'root') && ($login_role != 'admin'))
{
	$redirUrl = urlencode($_SERVER['REQUEST_URI']);
	die("<script>location.href='login.php?redir=$redirUrl';</script>");
}
?>