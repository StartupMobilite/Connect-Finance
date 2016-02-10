<?php 
	class DataManager {
		private $PDO_instance = null;
		private static $instance = null;
		protected $errors;
		protected $exceptions;
		
		private function __construct() {
			$this->PDO_instance = new PDO('mysql:host='.DB_HOST.';dbname='.DB_NAME, DB_USER, DB_PASSWORD) or die('Erreur lors de la connexion');
			$this->PDO_instance->exec('SET NAMES utf8');
			
			$this->exceptions[] = 'errors';
			$this->exceptions[] = 'exceptions';
			$this->exceptions[] = 'PDO_instance';
			$this->exceptions[] = 'instance';
		}
		
		public static function connect() {
			if(is_null(self::$instance)) {
				self::$instance = new DataManager();
			}
			
			return self::$instance;
		}
		
		public function query($query) {
			return $this->PDO_instance->query($query);
		}
		
		public function quote($text) {
			return $this->PDO_instance->quote($text);
		}
		
		public function delete() {
			$con = $this->connect();
			
			$sql = "DELETE FROM ".$this->table_name." WHERE id=".$con->quote($this->id);

			$query = $con->query($sql) or die($sql);
		}
		
		public function reload() {
			$con = $this->connect();
			
			$save_exceptions = $this->exceptions;
			
			$this->exceptions[] = 'exceptions';
			$this->exceptions[] = 'id';
			$this->exceptions[] = 'prix_ht';
			
			foreach($this as $property => $value) {
				if(!in_array($property, $this->exceptions)) {
					if($i > 0) {
						if($i > 1) {
							$sql .= " AND ";
						}
						
						$sql .= $property.'='.$con->quote(str_replace(chr(146), "'", $value));
					} else {
						$sql = "SELECT * FROM `".$value."` WHERE ";
					}
					$i++;
				}
			}
			
			$query = $con->query($sql) or die($sql);
			$data = $query->fetch(PDO::FETCH_ASSOC);
			
			$this->update($data);
			
			$this->exceptions = $save_exceptions;
		}
		
		public function save() {
			$con = self::connect();
			$i = 0;
			$log = "";
			
			if($this->get_id() == "") {
				foreach($this as $property => $value) {
					if(!in_array($property, $con->exceptions)) {
						if($i > 0) {
							if($i > 1) {
								$sql .= ", ";
							}
							
							$sql .= $con->quote(str_replace(chr(146), "'", $value));
						} else {
							$sql = "INSERT INTO `".$value."` VALUES(";
						}
					}
					
					$i++;
				}
				
				$sql .= ")";
			} else {
				$id = $this->get_id();
			
				foreach($this as $property => $value) {
					if(!in_array($property, $this->exceptions)) {
						if($i > 0) {
							if($i > 1) {
								$sql .= ", ";
							}
							
							$sql .= $property.'='.$con->quote(str_replace(chr(146), "'", $value));
						} else {
							$sql = "UPDATE `".$value."` SET ";
						}
					}
					
					$i++;
				}
				
				$sql .= ' WHERE id='.$con->quote($id);
			}
			
			$con->query($sql) or die($sql);
		}
	}
?>