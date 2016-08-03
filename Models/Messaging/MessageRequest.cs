using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Derek.Web.Models.Messaging
{
    public class MessageRequest
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string Html { get; set; }
    }
}