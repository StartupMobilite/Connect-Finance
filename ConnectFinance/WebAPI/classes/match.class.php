<?php
	class Match extends DataManager {
		protected $table_name = "match";
		
		protected $id;
		protected $project_id;
		protected $user_id;
		
		public function get_id() {
			return $this->id;
		}
		
		public function get_project() {
			return Project::getById($this->project_id);
		}
		
		public function set_project($p) {
			$this->project_id = $p;
		}
		
		public function get_user() {
			return User::getById($this->user_id);
		}
		
		public function set_user($u) {
			$this->user_id = $u;
		}
		
		public static function getList() {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name;
			$query = $con->query($sql);
			$list = $query->fetchAll(PDO::FETCH_CLASS, 'Match');
			
			return $list;
		}
		
		public static function getById($id) {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name." WHERE id=".$con->quote($id);
			$query = $con->query($sql);
			$query->setFetchMode(PDO::FETCH_CLASS, 'Match');
			
			return $query->fetch();
		}
		
		public function update($properties) {
			foreach($properties as $key => $value) {
				$this->$key = $value;
			}
		}
	}
?>