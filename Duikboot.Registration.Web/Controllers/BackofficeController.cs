using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Duikboot.Data.Live.Models;
using Duikboot.Data.Live.Repository;

namespace Duikboot.Registration.Web.Controllers
{
    public class BackofficeController : Controller
    {
        private UserRepository UserRepository;
        public BackofficeController()
        {
            this.UserRepository = new UserRepository();
        }
        // GET: Backoffice 

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login",null,"_AuthLayout");
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var canLogin = UserRepository.Login(user);
            switch (canLogin)
            {
                case true:
                    Session["LoggedinUser"] = UserRepository.GetByUsernameAndPassword(user);
                    return View("Index", null, "_Backoffice");
                case false:
                    ViewBag.Message = "Gebruikersnaam en/of wachtwoord onjuist";
                    break;
            }
            return View("Index", null, "_AuthLayout");
        } 

        
    }
}