using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFinance_1.Models
{
    class Project
    {
        public string id { get; set; }

        public string name { get; set; }

        public User owner { get; set; }

        public string creation_date { get; set; }

        public string amount { get; set; }

        public string description { get; set; }

        public Sector sector { get; set; }

        public Image[] images { get; set; }
    }
}
