using CustomFormValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomFormValidation.Controllers
{
    public class RegistrationController : Controller
    {
        public static List<Student> students = new List<Student>() { };


        [HttpGet]
        public ActionResult register()
        {
            return View(new Student());
        }

        [HttpPost]
        public ActionResult register(Student student)
        {
            if(ModelState.IsValid)
            {
                TempData["StudentCreated"] = "New Student Registered";
                students.Add(student);
                return RedirectToAction("Details");
            }
            return View(student);
        }

        public ActionResult Details()
        {
            return View(students);
        }
    }
}