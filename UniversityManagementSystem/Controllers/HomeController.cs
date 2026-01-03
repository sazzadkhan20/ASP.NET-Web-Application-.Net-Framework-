using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Auth;
using UniversityManagementSystem.DB_Entities;
using UniversityManagementSystem.DTOs;

namespace UniversityManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        UMS_DBEntities db;
        public HomeController(UMS_DBEntities db)
        {
            this.db = db;
        }

        int DepartmentID (string dept)
        {
            if (dept.Equals("FST")) return 5;
            else if (dept.Equals("FE")) return 6;
            else if (dept.Equals("English")) return 7;
            else if (dept.Equals("FBA")) return 8;
            else return 9;
        }
        AIUBStudent mapper(StudentDTO studentDto)
        {
            AIUBStudent student = new AIUBStudent
            {
                UserID = studentDto.UserID,
                Name = studentDto.Name,
                Email = studentDto.Email,
                Password = CreateMD5(studentDto.Password),
                DepartmentId = DepartmentID(studentDto.DepartmentName)
            };
            return student;
        }

        public static string CreateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2")); // "x2" ensures lowercase hex format
                }
                return sb.ToString();
            }
        }

        [HttpGet]
        public ActionResult Home()
        {  
            if (Session["user"] != null)
            {
                AIUBStudent student = (AIUBStudent) Session["user"];
                var courses = (from s in db.CourseStudentRegistrations
                               where s.Id == student.Id
                               select s).ToList();
                ViewBag.userName = student.Name;
                return View(courses);
            }
            return View();
        }

        [Logged]
        [HttpPost]
        public ActionResult Home(string status)
        {
            if ("logout".Equals(status))
                Session["user"] = null;
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            
            return View(new StudentDTO { });
        }

        [HttpPost]
        public ActionResult SignUp(StudentDTO studentDto)
        {
            if(ModelState.IsValid)
            {
                AIUBStudent student = mapper(studentDto);
                db.AIUBStudents.Add(student);
                db.SaveChanges();
                return RedirectToAction("Home");
            }
            return View(studentDto);
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInDTO signInDTO)
        {
            if(ModelState.IsValid) 
            {
                var student = (from s in db.AIUBStudents
                               where s.UserID.Equals(signInDTO.UserID)
                               select s).SingleOrDefault();
                if(student != null)
                {
                    string pass = CreateMD5(signInDTO.Password);
                    if(student.Password == pass)
                    {
                        Session["user"] = student;
                        return RedirectToAction("Home");
                    }
                }
            }
            return View();
        }
    }
}