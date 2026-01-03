using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DB_Entities;

namespace UniversityManagementSystem.CustomAttributes
{
    public class UniqueIdAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            UMS_DBEntities db = new UMS_DBEntities();
            if (value == null) return false;
            string id = value.ToString();
            var student = (from s in db.AIUBStudents
                            where s.UserID.Equals(id)
                            select s).SingleOrDefault();
            if (student == null) return true;
            return false;
        }
    }
}