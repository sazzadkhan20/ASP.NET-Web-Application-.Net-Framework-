using FormValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormValidation.Controllers
{
    public class RegistrationController : Controller
    {
        public static List<User> allUsers = new List<User>() { };
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.users = allUsers;
            return View(new User());
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                allUsers.Add(user);
            }
            ViewBag.users = allUsers;
            return View(user);
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}