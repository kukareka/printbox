<?php
require_once('../service/common.php');
require_once('auth.php');
?>
<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf8" />
		<title>PrintBox</title>
		<link rel="stylesheet" type="text/css" href="style.css" />
	</head>
<?php
	require_once('../common/db.php');
	$terminals_query = "SELECT id, name, admin, errors, paper, money, banknotes, toner, " .
						" TIMESTAMPDIFF(MINUTE, last_ping, UTC_TIMESTAMP()) last_seen, ip_addr FROM terminals";
	$is_root = $_SESSION['role'] == 'root';
	if (!$is_root) $terminals_query .= " WHERE admin = '{$_SESSION['login']}'";
	$terminals = mysql_query($terminals_query); 
?>
	<body vlink="blue">
		<div id='content'>
			<a href='#'>Терминалы</a> | 
			<a href='sessions.php'>Сессии</a> | 
			<a href='login.php?logout=true'>Выход</a>
			<div id='filters'>
				<form method=get>
					<input type='submit' value='Обновить'/>
				</form>
			</div>
			<table id='dataTable' align=center cellpadding=7 cellspacing=0>
				<thead>
					<tr><th>ID</th><th>Имя</th><?php echo $is_root ? '<th>Партнер</th>' : '' ?><th>Онлайн</th><th>Статус</th><th>Бумага</th><th>Деньги</th><th>Купюры</th><th>Тонер</th><th>IP</th></tr>
				</thead>
				<tbody>
				<?php	
						$totalPaper = $totalMoney = $totalBanknotes = 0;
					while ($row = mysql_fetch_array($terminals, MYSQL_ASSOC))
					{
						echo "<tr>";
						echo "<td>{$row['id']}</td>";
						echo "<td>{$row['name']}</td>";
						if ($is_root) echo "<td>{$row['admin']}</td>";
						if ($row['last_seen'] > $config['offline_time']) echo "<td class='err'>Оффлайн</td>";
						else echo "<td class='ok'>Онлайн</td>";
						if ($row['errors'] == 0) echo "<td class='ok'>OK</td>";
						else 
						{
							echo "<td class='err'>";
							$errors = getErrors($row['errors']);
							foreach ($errors as $error) echo "$error<br/>";
							echo "</td>";
						}
						echo "<td>{$row['paper']}стр</td>";
						echo "<td>{$row['money']}грн</td>";
						echo "<td>{$row['banknotes']}шт</td>";
						echo "<td>{$row['toner']}%</td>";
						echo "<td>{$row['ip_addr']}</td>";
						$totalPaper += $row['paper'];
						$totalMoney += $row['money'];
						$totalBanknotes += $row['banknotes'];
						echo "</tr>";
					}
				?>
				</tbody>
				<tfoot>
					<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>
					<td>Итого</td>
					<td><?php echo $totalPaper; ?>стр</td>
					<td><?php echo $totalMoney; ?>грн</td>
					<td><?php echo $totalBanknotes; ?>шт</td>
					
				</tfoot>
			</table>
		</div>
	</body>
</html>