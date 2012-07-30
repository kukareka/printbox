<?php
$config = array(
	'db_server' => 'localhost',
	'db_user' => 'root',
	'db_password' => '',
	'db_database' => 'pb_world1',

	'root_password' => 'root',
	'root_pin' => '2345',
	
	'offline_time' => 45, //minutes
	'notification_interval' => 10, //minutes
	'paper_notification_limit' => 70, //minutes
	
	'sms_test_mode' => false,
	'sms_admin' => '380672382496',
	'sms_gateway' => 
		'http://smsukraine.com.ua/api/http.php?version=http&login=380988525062&password=kmt45px0&command=send&from=PrintBox&to=%s&message=%s',
		//'http://localhost/sms?to=%s&text=%s',
	'email_test_mode' => false,
	'email_gateway' => 'http://printbox.kiev.ua/mgate/mgate.php?to=%s&text=%s'
);
?>
