using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormValidationLabTask.Models;

namespace FormValidationLabTask.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student s)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Index", "Home");
            return View();
        }
    }
}