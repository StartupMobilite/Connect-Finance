using System;
using System.Text;

namespace ConnectFinance_1.Models
{
    public class User
    {
        public string id { get; set; }

        public string nom { get; set; }

        public string prenom { get; set; }

        public string birthday { get; set; }

        public string sexe { get; set; }

        public string latitude { get; set; }

        public string longitude { get; set; }

        public string password { get; set; }

        public string mail { get; set; }

        public string account_type { get; set; }

        public string token_type { get; set; }

        public string token { get; set; }

        public string related_files_dir_uid { get; set; }
    }
}
