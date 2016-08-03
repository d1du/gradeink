using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Derek.Web.Models.Messaging
{
    public class MessagingAddRequests
    {
        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(2000)]
        public string Message { get; set; }
    }
}