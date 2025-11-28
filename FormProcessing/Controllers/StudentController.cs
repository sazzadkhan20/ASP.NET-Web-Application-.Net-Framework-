using FormProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormProcessing.Controllers
{
    public class StudentController : Controller
    {
        public static List<Student> students = new List<Student>() { };
        public void addStudent(Student student)
        {
            students.Add(student);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // Model Binding
        [HttpPost]
        public ActionResult Index(Student student)
        {
            if(student != null)
            {
                students.Add(student);
                TempData["StudentCreate"] = "New Student Created";
                // ViewBag or ViewData Not accepting Here
                return RedirectToAction("Details");
            }
            return View();
        }

        //[HttpGet]
        public ActionResult Details()
        {
            return View(students);
        }


        // Variable Name Mapping Form Processing
        //[HttpPost]
        //public ActionResult Index(string ID,string UserName)
        //{
        //    ViewBag.name = UserName;
        //    return View();
        //}

        // FormCollection Object Form Processing
        //[HttpPost]
        //public ActionResult Index(FormCollection fc)
        //{
        //    ViewBag.name = fc["UserName"];
        //    return View();
        //}


        // Request Form Processing
        //public ActionResult Index()
        //{
        //    ViewBag.name = Request["UserName"];
        //    return View();
        //}
    }
}