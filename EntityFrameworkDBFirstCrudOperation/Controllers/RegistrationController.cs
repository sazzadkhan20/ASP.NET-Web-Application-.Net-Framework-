using EntityFrameworkDBFirstCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkDBFirstCrudOperation.Controllers
{
    public class RegistrationController : Controller
    {
        TestDBEntities db = new TestDBEntities();
        [HttpGet]
        public ActionResult Register()
        {
            return View(new Student());
        }

        [HttpPost]
        public ActionResult Register(Student s,string Gaming,string Sports,string Travelling)
        {
            string hobbies = "";
            if (Gaming != null) hobbies += Gaming + ", ";
            if (Sports != null) hobbies += Sports + ", ";
            if (Travelling != null) hobbies += Travelling + ", ";
            s.Hobbies = hobbies;
            db.Students.Add(s); // Insert Operation
            db.SaveChanges(); // Return No. of Rows affected
            TempData["StudentCreate"] = "New Student Created";
            return RedirectToAction("Home","Student");
        }
    }
}