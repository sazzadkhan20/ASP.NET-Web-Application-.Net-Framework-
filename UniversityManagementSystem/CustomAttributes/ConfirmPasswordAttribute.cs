using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DTOs;

namespace UniversityManagementSystem.CustomAttributes
{
    public class ConfirmPasswordAttribute : ValidationAttribute
    {
        //protected override ValidationResult IsValid(Object value, ValidationContext context)
        //{
        //    var obj = context.ObjectInstance as StudentDTO;
        //    if (obj == null || obj.Password == null) return new ValidationResult("Password ...");
        //    return ValidationResult.Success;
        //}
    }
}