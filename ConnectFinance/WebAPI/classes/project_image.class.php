<?php
	class ProjectImage extends DataManager {
		protected $table_name = "project_images";
		
		protected $id;
		protected $url;
		protected $project_id;
		
		public function get_id() {
			return $this->id;
		}
		
		public function get_url() {
			return $this->url;
		}
		
		public function set_url($url) {
			$this->url = $url;
		}
		
		public function get_project() {
			return Project::getById($this->project_id);
		}
		
		public function set_project($p) {
			$this->project_id = $p;
		}
		
		public static function getList() {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name;
			$query = $con->query($sql);
			$query->setFetchMode(PDO::FETCH_CLASS, 'ProjectImage');
			
			return $query;
		}
		
		public static function getById($id) {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name." WHERE id=".$con->quote($id);
			$query = $con->query($sql);
			$query->setFetchMode(PDO::FETCH_CLASS, 'ProjectImage');
			
			return $query->fetch();
		}
		
		public static function getByProject($proj) {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name." WHERE project_id=".$con->quote($proj);
			$query = $con->query($sql);
			$query->setFetchMode(PDO::FETCH_CLASS, 'ProjectImage');
			
			return $query;
		}
		
		public function update($properties) {
			foreach($properties as $key => $value) {
				$this->$key = $value;
			}
		}
	}
?>