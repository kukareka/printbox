<!DOCTYPE html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf8" />
		<title>>PrintBox</title>
		<link type="text/css" href="css/smoothness/jquery-ui-1.8.10.custom.css" rel="stylesheet" />	
		<script type="text/javascript" src="js/jquery-1.4.4.min.js"></script>
		<script type="text/javascript" src="js/jquery-ui-1.8.10.custom.min.js"></script>
		<script type="text/javascript" src="js/jquery.ui.datepicker-ru.js"></script>
		<script type="text/javascript">
		$(function(){
			$.datepicker.setDefaults($.datepicker.regional['ru']);
			$('#dateFrom').datepicker({});
			$('#dateTo').datepicker({});
			});
		</script>
		<style type="text/css">
			body { font: 62.5% sans-serif; margin: 24px;}
			#content { text-align:center; }
			#filters { font-size: 110%; padding: 24px; }
			#dataTable { font-size: 130%; }
			#dataTable thead { background: #d0d0d0; font-weight: bold;}
			#dataTable tbody tr:nth-child(even) {background: #f0f0f0;}
			#dataTable tbody tr:nth-child(odd) {background: #ffffff;}
			#dataTable td {padding: 8px 18px 8px 18px;}			
			#dataTable tfoot {background: #ffffff; font-weight: bold;}	
		</style>		
	</head>
	<body vlink="blue">
	<div id='content'>
		<a href='#'>Терминалы</a> | 
		<a href='#'>Сессии</a> | 
		<a href='#'>Выход</a>
		<div id='filters'>
		С&nbsp;&nbsp;<input id='dateFrom' size=12/>&nbsp;&nbsp;&nbsp;&nbsp;По&nbsp;&nbsp;<input id='dateTo'  size=12/><br/><br/>
		<input type='submit' value='Показать'/>
		</div>
		<table id='dataTable' align=center cellpadding=7 cellspacing=0>
			<thead>
				<tr><th>ID</th><th>Имя</th><th>Статус</th><th>Бумага</th><th>Деньги</th><th>Купюры</th></tr>
			</thead>
			<tbody>
				<tr><td>1</td><td>Крок.Библиотека</td><td>ОК</td><td>190стр</td><td>120грн</td><td>15шт</td></tr>
				<tr><td>1</td><td>Крок.Библиотека</td><td>ОК</td><td>190стр</td><td>120грн</td><td>15шт</td></tr>
				<tr><td>1</td><td>Крок.Библиотека</td><td>ОК</td><td>190стр</td><td>120грн</td><td>15шт</td></tr>
				<tr><td>1</td><td>Крок.Библиотека</td><td>ОК</td><td>190стр</td><td>120грн</td><td>15шт</td></tr>
				
			</tbody>
			<tfoot>
				<tr><td>1</td><td>Крок.Библиотека</td><td>ОК</td><td>190стр</td><td>120грн</td><td>15шт</td></tr>
			</tfoot>
		</table>
	</div>
	</body>
</html>