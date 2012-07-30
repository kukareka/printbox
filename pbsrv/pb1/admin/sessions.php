<?php
require_once('../common/db.php');
require_once('auth.php');
?>
<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf8" />
		<title>PrintBox</title>
		<link type="text/css" href="css/smoothness/jquery-ui-1.8.10.custom.css" rel="stylesheet" />	
		<script type="text/javascript" src="js/jquery-1.4.4.min.js"></script>
		<script type="text/javascript" src="js/jquery-ui-1.8.10.custom.min.js"></script>
		<script type="text/javascript" src="js/jquery.ui.datepicker-ru.js"></script>
		<script type="text/javascript">
		$(function(){
			$.datepicker.setDefaults($.datepicker.regional['ru']);
			$('#dateFrom').datepicker({defaultDate: +0});
			$('#dateTo').datepicker({defaultDate: +0});
			});
		</script>
		<link rel="stylesheet" type="text/css" href="style.css" />	
	</head>
<?php
	date_default_timezone_set('Europe/Helsinki');
	
	$dateFrom = isset($_GET['from']) ? $_GET['from'] : date('d.m.Y');
	$dateTo = isset($_GET['to']) ? $_GET['to'] : date('d.m.Y');
	
	$is_root = $_SESSION['role'] == 'root';
?>
	<body vlink="blue">
		<div id='content'>
			<a href='terminals.php'>Терминалы</a> | 
			<a href='#'>Сессии</a> | 
			<a href='login.php?logout=true'>Выход</a>
			<div id='filters'>
				<form method=get>
					С&nbsp;&nbsp;<input id='dateFrom' name='from' value='<?php echo $dateFrom ?>' size=12/>&nbsp;&nbsp;&nbsp;&nbsp;
					По&nbsp;&nbsp;<input id='dateTo' name='to' value='<?php echo $dateTo ?>' size=12/><br/><br/>
					<?php
					$terminals = mysql_query('select id, name from terminals' . ( $is_root ? '' : " WHERE admin = '{$_SESSION['login']}' " ));
					$selectAllTerminals = true;
					$selectedTerminals = '';
					for ($i = 0; $i < mysql_num_rows($terminals); ++$i)
					{
						$id = mysql_result($terminals, $i, 0);
						$name = mysql_result($terminals, $i, 1);
						$checked = isset($_GET["box$id"]) ? "checked='true'" : "";
						echo "<input type='checkbox' name='box$id' value='1' $checked/> $name ";
						if (isset($_GET["box$id"]))
						{
							if ($selectAllTerminals)
							{
								$selectedTerminals = $id;
								$selectAllTerminals = false;
							}
							else
							{
								$selectedTerminals .= ", $id";								
							}
						}
					}
					?>
					<br/><br/>
					<input type='submit' value='Показать'/>
				</form>
			</div>
			<table id='dataTable' align=center cellpadding=7 cellspacing=0>
				<thead>
					<tr><th>ID</th><th>Время</th><th>Терминал</th><th>Клиент</th><th>Страницы</th><th>Внесено</th><th>Стоимость</th></tr>
				</thead>
				<tbody>
				<?php	
					$dateFromUtc = gmdate('d.m.Y H:i:s', strtotime($dateFrom . ' 00:00:00'));
					$dateToUtc = gmdate('d.m.Y H:i:s', strtotime($dateTo . ' 23:59:59'));
					$query = "SELECT s.id id, s.time time, t.name terminal, s.user user, s.pages_printed pages_printed, s.money_in money_in, s.page_cost page_cost " . 
						" FROM sessions s JOIN terminals t ON s.terminal = t.id WHERE s.time BETWEEN " . 
						" STR_TO_DATE('$dateFromUtc', '%d.%m.%Y %H:%i:%s') " . 
						" AND STR_TO_DATE('$dateToUtc', '%d.%m.%Y %H:%i:%s') " .
						 ( $is_root ? '' : " AND t.admin = '{$_SESSION['login']}'" );
					if (!$selectAllTerminals)
					{
						$query .= " AND s.terminal IN ($selectedTerminals)";
					}
					$query .= " ORDER BY id ASC";
					$sessions = mysql_query($query);
					$totalPages = $totalMoneyIn = $totalCost = 0;
					while ($row = mysql_fetch_array($sessions, MYSQL_ASSOC))
					{
						echo "<tr>";
						echo "<td>{$row['id']}</td>";
						$localTime = new DateTime();
						$localTime->setTimestamp(strtotime($row['time'] . ' GMT'));
						echo "<td>{$localTime->format('Y-m-d H:i:s')}</td>";
						echo "<td>{$row['terminal']}</td>";
						echo "<td>{$row['user']}</td>";
						echo "<td>{$row['pages_printed']}стр</td>";
						echo "<td>{$row['money_in']}грн</td>";
						$price = $row['pages_printed'] * $row['page_cost'] * .01;
						echo "<td>{$price}грн</td>";
						$totalPages += $row['pages_printed'];
						$totalMoneyIn += $row['money_in'];
						$totalCost += $price;
						echo "</tr>";
					}
				?>
				</tbody>
				<tfoot>
					<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>Итого</td>
					<td><?php echo $totalPages; ?>стр</td>
					<td><?php echo $totalMoneyIn; ?>грн</td>
					<td><?php echo $totalCost; ?>грн</td>
					
				</tfoot>
			</table>
			<?php $now = new DateTime(); echo $now->format('Y-m-d H:i:s'); ?>
		</div>
	</body>
</html>