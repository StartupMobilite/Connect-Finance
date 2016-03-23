using System;
using System.Text;
using Newtonsoft.Json;

namespace ConnectFinance_1.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("nom")]
        public string nom { get; set; }

        [JsonProperty("prenom")]
        public string prenom { get; set; }


        [JsonProperty("birthday")]
        public string birthday { get; set; }

        [JsonProperty("sexe")]
        public string sexe { get; set; }

        [JsonProperty("latitude")]
        public string latitude { get; set; }

        [JsonProperty("longitude")]
        public string longitude { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("mail")]
        public string mail { get; set; }

        [JsonProperty("account_type")]
        public string account_type { get; set; }

        [JsonProperty("token_type")]
        public string token_type { get; set; }

        [JsonProperty("token")]
        public string token { get; set; }

        [JsonProperty("related_files_dir_uid")]
        public string related_files_dir_uid { get; set; }
    }
}
