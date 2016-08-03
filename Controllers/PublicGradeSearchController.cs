using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Derek.Web.Controllers
{
    public class PublicGradeSearchController : Controller
    {
        // GET: PublicGradeSearch
        public ActionResult FindStudentGrade()
        {
            return View();
        }
    }
}