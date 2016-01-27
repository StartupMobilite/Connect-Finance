<?php
	class Project extends DataManager {
		protected $table_name = "projects";
		
		protected $id;
		protected $name;
		protected $owner_id;
		protected $creation_date;
		protected $amount;
		protected $description;
		protected $sector_id;
		
		public function get_id() {
			return $this->id;
		}
		
		public function get_name() {
			return $this->name;
		}
		
		public function set_name($n) {
			$this->name = $n;
		}
		
		public function get_owner() {
			return User::getById($this->owner_id);
		}
		
		public function set_owner($o) {
			$this->owner_id = $o;
		}
		
		public function get_creation_date() {
			return $this->creation_date;
		}
		
		public function set_creation_date($cd) {
			$this->creation_date = $cd;
		}
		
		public function get_amount() {
			return $this->amount;
		}
		
		public function set_amount($a) {
			$this->amount = $a;
		}
		
		public function get_description() {
			return $this->description;
		}
		
		public function set_description($d) {
			$this->description = $d;
		}
		
		public function get_sector() {
			return Sector::getById($this->sector_id);
		}
		
		public function set_sector($s) {
			$this->sector_id = $s;
		}
		
		public static function getList() {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name;
			$query = $con->query($sql);
			$list = $query->fetchAll(PDO::FETCH_CLASS, 'Project');
			
			return $list;
		}
		
		public static function getById($id) {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name." WHERE id=".$con->quote($id);
			$query = $con->query($sql);
			$query->setFetchMode(PDO::FETCH_CLASS, 'Project');
			
			return $query->fetch();
		}
		
		public function update($properties) {
			foreach($properties as $key => $value) {
				$this->$key = $value;
			}
		}
	}
?>