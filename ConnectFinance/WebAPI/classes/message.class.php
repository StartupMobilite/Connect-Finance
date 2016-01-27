<?php
	class Message extends DataManager {
		protected $table_name = "messages";
		
		protected $id;
		protected $sent_date;
		protected $message;
		protected $user_from_id;
		protected $user_to_id;
		
		public function get_id() {
			return $this->id;
		}
		
		public function get_sent_date() {
			return $this->sent_date;
		}
		
		public function set_sent_date($sd) {
			$this->sent_date = $sd;
		}
		
		public function get_message() {
			return $this->message;
		}
		
		public function set_message($msg) {
			$this->message = $msg;
		}
		
		public function get_user_from() {
			return User::getById($this->user_from_id);
		}
		
		public function set_user_from($user) {
			$this->user_from_id = $user;
		}
		
		public function get_user_to() {
			return User::getById($this->user_to_id);
		}
		
		public function set_user_to($user) {
			$this->user_to_id = $user;
		}
		
		public static function getList() {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name;
			$query = $con->query($sql);
			$list = $query->fetchAll(PDO::FETCH_CLASS, 'Message');
			
			return $list;
		}
		
		public static function getById($id) {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name." WHERE id=".$con->quote($id);
			$query = $con->query($sql);
			$query->setFetchMode(PDO::FETCH_CLASS, 'Message');
			
			return $query->fetch();
		}
		
		public static function getBySender($sender_id) {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name." WHERE mail=".$con->quote($sender_id);
			$query = $con->query($sql);
			$list = $query->fetchAll(PDO::FETCH_CLASS, 'Message');
			
			return $list;
		}
		
		public static function getByRecipient($recipient_id) {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name." WHERE mail=".$con->quote($recipient_id);
			$query = $con->query($sql);
			$list = $query->fetchAll(PDO::FETCH_CLASS, 'Message');
			
			return $list;
		}
		
		public function update($properties) {
			foreach($properties as $key => $value) {
				$this->$key = $value;
			}
		}
	}
?>