using Derek.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Derek.Web.Controllers
{
    [RoutePrefix("ClientSideRouting")]
    public class ClientSideRoutingController : Controller
    {
        // GET: ClientSideRouting
        [Route("addusers")]
        public ActionResult AddUsers()
        {
            return View();
        }

        [Route("userprofile/{id:int}")]
        public ActionResult UserProfile(int? id = null)
        {
            ItemViewModel<int?> model = new ItemViewModel<int?>();

            model.Item = id;

            return View(model);
        }

        [Route("allusers")]
        public ActionResult AllUsers()
        {
            return View();
        }
    }
}