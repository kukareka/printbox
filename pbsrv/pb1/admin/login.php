<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf8" />
		<title>PrintBox</title>
		<style type="text/css">
			.center {text-align:center;}
			.err {color:red; font-weight: bold; font-size: 90%;}
		</style>	
	</head>
	<body>
<?php
require_once('../common/db.php');
session_start();
if (isset($_GET['logout']))
{
	session_unset();
}
else if (isset($_POST['login']) && isset($_POST['pwd']))
{
	$login = $_POST['login'];
	$pwd = $_POST['pwd'];
	if (($login == 'root') && ($pwd == $config['root_password']))
	{
		$_SESSION['login'] = $login;
		$_SESSION['role'] = 'root';
		$loginOk = true;
	}
	else
	{
		$result = mysql_query("select id from admins where id = '$login' and pwd = '$pwd'");
		if (mysql_num_rows($result) == 1)
		{
			$_SESSION['login'] = $login;
			$_SESSION['role'] = 'admin';
			$loginOk = true;
		}
		else 
		{
			$loginOk = false;
			$loginError = true;
		}
	}
	if ($loginOk)
	{
		echo "<script>location.href='{$_POST['redir']}';</script>";
		die;
	}
}

$redirUrl = isset($_REQUEST['redir']) ? $_REQUEST['redir'] : 'terminals.php';
?>
		<div class='center'>
			<?php if (isset($loginError)) echo "<span class='err'>Неправильный логин/пароль.</span>"; ?>
			<form method='post' action='login.php'>
			<input type='hidden' name='redir' value='<?php echo $redirUrl ?>'/>
			<input type='text' name='login'/><br/>
			<input type='password' name='pwd'/><br/>
			<input type='submit' value='Вход'/>
			</form>
		</div>
	</body>
</html>