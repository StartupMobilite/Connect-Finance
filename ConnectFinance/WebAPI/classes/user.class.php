<?php
	class User extends DataManager {
		protected $table_name = "users";
		
		protected $id;
		protected $nom;
		protected $prenom;
		protected $birthday;
		protected $sexe;
		protected $tel;
		protected $latitude;
		protected $longitude;
		protected $password;
		protected $mail;
		protected $account_type;
		protected $token_type;
		protected $token;
		protected $related_files_dir_uid;
		
		public function get_id() {
			return $this->id;
		}
		
		public function get_nom() {
			return $this->nom;
		}
		
		public function set_nom($nom) {
			$this->nom = $nom;
		}
		
		public function get_prenom() {
			return $this->prenom;
		}
		
		public function set_prenom($prenom) {
			$this->prenom = $prenom;
		}
		
		public function get_birthday() {
			return $this->birthday;
		}
		
		public function set_birthday($birthday) {
			$this->birthday = sha1($birthday);
		}
		
		public function get_sexe() {
			return $this->sexe;
		}
		
		public function set_sexe($sexe) {
			$this->sexe = $sexe;
		}
		
		public function get_tel() {
			return $this->tel;
		}
		
		public function set_tel($tel) {
			$this->tel = $tel;
		}
		
		public function get_latitude() {
			return $this->latitude;
		}
		
		public function set_latitude($latitude) {
			$this->latitude = $latitude;
		}
		
		public function get_longitude() {
			return $this->longitude;
		}
		
		public function set_longitude($longitude) {
			$this->longitude = $longitude;
		}
		
		public function get_password() {
			return $this->password;
		}
		
		public function set_password($password) {
			$this->password = $password;
		}
		
		public function get_mail() {
			return $this->mail;
		}
		
		public function set_mail($mail) {
			$this->mail = $mail;
		}
		
		public function get_account_type() {
			return $this->account_type;
		}
		
		public function set_account_type($at) {
			$this->account_type = $at;
		}
		
		public function get_token_type() {
			return $this->token_type;
		}
		
		public function set_token_type($tt) {
			$this->token_type = $tt;
		}
		
		public function get_token() {
			return $this->token;
		}
		
		public function set_token($token) {
			$this->token = $token;
		}
		
		public function get_related_files_dir_uid() {
			return $this->related_files_dir_uid;
		}
		
		public function set_related_files_dir_uid($uid) {
			$this->related_files_dir_uid = $uid;
		}
		
		public static function getList() {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name;
			$query = $con->query($sql);
			$list = $query->fetchAll(PDO::FETCH_CLASS, 'User');
			
			return $list;
		}
		
		public static function getById($id) {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name." WHERE id=".$con->quote($id);
			$query = $con->query($sql);
			$query->setFetchMode(PDO::FETCH_CLASS, 'User');
			
			return $query->fetch();
		}
		
		public static function getByMail($mail) {
			$con = $this->connect();
			$sql = "SELECT * FROM ".$table_name." WHERE mail=".$con->quote($mail);
			$query = $con->query($sql);
			$query->setFetchMode(PDO::FETCH_CLASS, 'User');
			
			return $query->fetch();
		}
		
		public function update($properties) {
			foreach($properties as $key => $value) {
				if($key == 'password') {
					$this->$key = sha1($value);
				} else {
					$this->$key = $value;
				}
			}
		}
	}
?>