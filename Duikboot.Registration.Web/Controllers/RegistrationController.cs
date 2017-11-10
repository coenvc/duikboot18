using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Duikboot.Data.Models;
using Duikboot.Registration.Web.Models;

namespace Duikboot.Registration.Web.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(MeerijderDay meerijderDay)
        {
            return View();
        }
    }
}