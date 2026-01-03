using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Auth;
using UniversityManagementSystem.DB_Entities;
using UniversityManagementSystem.DTOs;

namespace UniversityManagementSystem.Controllers
{
    [Logged]
    public class RegistrationController : Controller
    {
        UMS_DBEntities db;

        public RegistrationController(UMS_DBEntities db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Register()
        {
            AIUBStudent student = (AIUBStudent)Session["user"];
            var courses = (from s in db.AIUB_Course
                           where s.DepartmentId == student.DepartmentId
                           select s).ToList();
            return View(courses);
        }

        [HttpPost]
        public ActionResult Register(int[] courseIds)
        {
            if(courseIds != null && courseIds.Length > 0)
            {
                AIUBStudent student = (AIUBStudent)Session["user"];
                var register = new Registration
                {
                    Date = DateTime.Now,
                    Status = "Pre-Registration",
                    StudentId = student.Id
                };
                db.Registrations.Add(register);
                db.SaveChanges();
                foreach(int courseId in courseIds)
                {
                    var course = new CourseStudentRegistration
                    {
                        RegistrationId = register.Id,
                        StudentId = student.Id,
                        CourseId = courseId
                    };
                    db.CourseStudentRegistrations.Add(course);
                }
                db.SaveChanges();
                return RedirectToAction("Home", "Home");
            }
            return RedirectToAction("Register");
        }
    }
}