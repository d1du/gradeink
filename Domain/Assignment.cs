using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Derek.Web.Domain
{
    public class Assignment
    {
        public int AssignmentId { get; set; }

        public string AssignmentName { get; set; }

        public int AssignmentTypeId { get; set; }

        public int TotalPoints { get; set; }

        public int Period { get; set; }

        public DateTime DateAdded { get; set; }

    }
}