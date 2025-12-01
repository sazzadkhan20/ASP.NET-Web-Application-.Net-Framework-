using EntityFrameworkDBFirstCrudOperation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkDBFirstCrudOperation.Controllers
{
    public class StudentController : Controller
    {
        TestDBEntities db = new TestDBEntities();
        [HttpGet]
        public ActionResult Home()
        {
            // List<Student> students = db.Students.ToList();
            var students = db.Students.ToList(); // Fetching All Rows
            return View(students);
        }

        //[HttpPost]
        //public ActionResult Home()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Details()
        //{
        //    return View(new Student());
        //}

        [HttpGet]
        public ActionResult Details(int id)
        {
            Student s = db.Students.Find(id); // Return one Row 
            return View(s);
        }

        //[HttpGet]
        //public ActionResult Edit()
        //{
        //    return View(new Student());
        //}

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student s = db.Students.Find(id);
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            var student = db.Students.Find(s.ID);
            student.Name = s.Name; // Update Operation
            student.Email = s.Email;
            student.Phone = s.Phone;
            student.NID = s.NID;
            student.Profession = s.Profession;
            student.Password = s.Password;
            db.SaveChanges();
            TempData["DataUpdate"] = "Update Successfull";
            return RedirectToAction("Home");
        }

        public ActionResult Delete(int id)
        {
            Student s = db.Students.Find(id);
            if(s != null)
            {
                db.Students.Remove(s); // Delete Operation
                db.SaveChanges();
                TempData["StudentDelete"] = "Student Deleted"; 
            }
            return RedirectToAction("Home");
        }

        public ActionResult Search(string id)
        {
            var student = (from s in db.Students
                           where s.Name.Contains(id)
                           orderby s.ID descending
                           select s).ToList();
            return View(student);
        }

    }
}