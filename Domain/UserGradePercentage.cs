using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Derek.Web.Domain
{
    public class UserGradePercentage
    {
        public int PointsEarned { get; set; }

        public int TotalPoints { get; set; }

        public double Percentage { get; set; }
    }
}