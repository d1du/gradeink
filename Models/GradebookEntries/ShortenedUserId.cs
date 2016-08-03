using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Derek.Web.Models.GradebookEntries
{
    //this class is used for searching through Gradebook
    public class ShortenedUserId
    {
        [Required MinLength(8, ErrorMessage = "UserId is less than 8 characters")]
        public string UserId {get; set;}
    }
}