using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValuePassingFromControllerToView.Models;

namespace ValuePassingFromControllerToView.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        Student CreateStudent(int id,String name,double cgpa)
        {
            var s = new Student
            {
                ID = id,
                Name = name,
                CGPA = cgpa
            };
            return s;
        }

        // Use of Model Binding
        public ActionResult Details()
        {
            // Redirect Process
            //if(true)
            //{
            //    return RedirectToAction("About","Home");
            //}
            //if(true)
            //{
            //    return Redirect("https://www.aiub.edu/"); // Get Request
            //}
            List<Student> students = new List<Student>();
            students.Add(CreateStudent(101, "Sazzad", 3.97));
            students.Add(CreateStudent(102, "Oni", 3.97));
            students.Add(CreateStudent(103, "Sadid", 3.55));
            return View(students);
        }

        // Use of ViewData (key value pair (Key type always String))
        //public ActionResult Details()
        //{
        //    ViewData["S1Name"] = "MD. Sazzad Khan";
        //    ViewData["S1CGPA"] = 3.97;
        //    ViewData["S2Name"] = "Saiful Islam Oni";
        //    ViewData["S3Name"] = "Sadid";
        //    ViewData["S3CGPA"] = 3.61;
        //    return View();
        //}

        // Use of ViewBag 
        //public ActionResult Details()
        //{
        //    ViewBag.s1 = "Md. Sazzad Khan";
        //    ViewBag.s2 = "Saiful Islam Oni";
        //    ViewBag.s3 = "Sadid";
        //    return View();
        //}

        public ActionResult Create()
        {
            return View();
        }
    }
}