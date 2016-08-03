using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Derek.Web.Models.GradebookEntries
{
    public class BaseGradebookEntryAddRequest
    {
        [Required]
        public int AssignmentId { get; set; }

        [Required Range(0, double.MaxValue)]
        public int PointsEarned { get; set; }

        public string InstructorComments { get; set; }
    }
}