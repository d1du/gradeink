using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Derek.Web.Models.Assignments
{
    public class AssignmentAddRequest
    {
        public string AssignmentName { get; set; }

        public int AssignmentTypeId { get; set; }

        public int TotalPoints { get; set; }

        public int Period { get; set; }
    }
}