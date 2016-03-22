using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFinance_1.Models
{
    class Message
    {
        public string id { get; set; }

        public string sent_date { get; set; }

        public string message { get; set; }

        public User user_from { get; set; }

        public User user_to { get; set; }
    }
}
