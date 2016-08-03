using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Derek.Web.Models.Users
{
    public class UserAddRequest
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string Period { get; set; }

        [Required]
        public int UserType { get; set; } 

        [EmailAddress]
        [MaxLength(128)]
        public string Email { get; set; }

    }
}