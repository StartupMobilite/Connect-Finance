<?php
	class TemporaryMatch extends DataManager {
		protected $table_name = "messages";
		
		protected $id;
		protected $id_user1;
		protected $id_user2;
		
		public function get_id() {
			return $this->id;
		}
		
		public function get_user1() {
			return User::getById($this->id_user1);
		}
		
		public function set_user1($user) {
			$this->id_user1 = $user;
		}
		
		public function get_user2() {
			return User::getById($this->id_user2);
		}
		
		public function set_user2($user) {
			$this->id_user2 = $user;
		}
		
		public static function getList() {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name;
			$query = $con->query($sql);
			$list = $query->fetchAll(PDO::FETCH_CLASS, 'TemporaryMatch');
			
			return $list;
		}
		
		public static function getById($id) {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name." WHERE id=".$con->quote($id);
			$query = $con->query($sql);
			$query->setFetchMode(PDO::FETCH_CLASS, 'TemporaryMatch');
			
			return $query->fetch();
		}
		
		public static function getUsers($user1, $user2) {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name." WHERE (id_user1=".$con->quote($user1)." AND id_user2=".$con->quote($user2).") OR (id_user2=".$con->quote($user1)." AND id_user1=".$con->quote($user2).")";
			$query = $con->query($sql);
			$query->setFetchMode(PDO::FETCH_CLASS, 'TemporaryMatch');
			
			return $query->fetch();
		}
		
		public function update($properties) {
			foreach($properties as $key => $value) {
				$this->$key = $value;
			}
		}
	}
?>