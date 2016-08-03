using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Derek.Web.Models.GradebookEntries
{
    public class GradebookEntryAddRequest : BaseGradebookEntryAddRequest
    {
        [Required]
        public string UserId { get; set; }

    }
}