using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Derek.Web.Models.Assignments
{
    public class AssignmentUpdateRequest : AssignmentAddRequest
    {
        public int Id { get; set; }
    }
}