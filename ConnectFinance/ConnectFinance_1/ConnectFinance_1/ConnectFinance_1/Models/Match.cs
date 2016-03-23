using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFinance_1.Models
{
    class Match
    {
        public string id { get; set; }

        public Project project { get; set; }

        public User user { get; set; }
    }
}
