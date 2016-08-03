using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Derek.Web.Models.GradebookEntries
{
    public class GradebookEntryUpdateRequest : BaseGradebookEntryAddRequest
    {
        public int Id { get; set; }

    }
}