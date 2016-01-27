<?php
	class Sector extends DataManager {
		protected $table_name = "sectors";
		
		protected $id;
		protected $name;
		
		public function get_id() {
			return $this->id;
		}
		
		public function get_name() {
			return $this->id_user1;
		}
		
		public function set_name($n) {
			$this->name = $n;
		}
		
		public static function getList() {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name;
			$query = $con->query($sql);
			$list = $query->fetchAll(PDO::FETCH_CLASS, 'Sector');
			
			return $list;
		}
		
		public static function getById($id) {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name." WHERE id=".$con->quote($id);
			$query = $con->query($sql);
			$query->setFetchMode(PDO::FETCH_CLASS, 'Sector');
			
			return $query->fetch();
		}
		
		public function update($properties) {
			foreach($properties as $key => $value) {
				$this->$key = $value;
			}
		}
	}
?>