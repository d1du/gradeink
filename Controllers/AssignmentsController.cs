using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Derek.Web.Controllers
{
    [RoutePrefix("assignments")]
    public class AssignmentsController : Controller
    {
        // GET: Assignments
        [Route("Add")]
        public ActionResult Add()
        {
            return View();
        }

        [Route("List")]
        public ActionResult List()
        {
            return View();
        }

    }
}