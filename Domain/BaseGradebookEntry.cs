using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Derek.Web.Domain
{
    public class BaseGradebookEntry
    {
        public int GradebookEntryId { get; set; }

        public int AssignmentId { get; set; }

        public string AssignmentName { get; set; }

        public int AssignmentTypeId { get; set; }

        public int PointsEarned { get; set; }

        public int TotalPoints { get; set; }

        public DateTime DateAdded { get; set; }

        public string InstructorComments { get; set; }
    }
}