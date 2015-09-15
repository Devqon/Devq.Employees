using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Environment.Extensions;
using Orchard.Themes;

namespace Devq.Employees.Controllers
{
    [OrchardFeature("Devq.EmployeeChat")]
    [Themed]
    public class ChatController : Controller
    {
        public ActionResult Index() {
            return View();
        }

        public ActionResult IndexAngular() {
            return View("IndexAngular");
        }
    }
}