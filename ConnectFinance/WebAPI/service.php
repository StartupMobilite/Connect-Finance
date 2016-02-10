<?php
	include('include/configs.inc.php');
	include('classes/data_manager.class.php');
	include('classes/user.class.php');
	include('classes/sector.class.php');
	include('classes/project.class.php');
	include('classes/project_image.class.php');
	include('classes/message.class.php');
	include('classes/match.class.php');
	include('classes/temporary_match.class.php');
	
	$action = $_GET['action'];
	
	switch($action) {
		case 'create_user':
			$user = new User($_POST);
			$user->save();
			
			break;
	}
?>