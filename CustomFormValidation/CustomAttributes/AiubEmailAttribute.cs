using CustomFormValidation.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomFormValidation.CustomAttributes
{
    public class AiubEmailAttribute : ValidationAttribute
    {

        private readonly string _domain;
        public AiubEmailAttribute() { }

        public AiubEmailAttribute(string domain)
        {
            _domain = domain;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Student student = validationContext.ObjectInstance as Student;
            if (student == null || student.Email.IsNullOrWhiteSpace()) return new ValidationResult("Email Address Required");
            if (student.ID.IsNullOrWhiteSpace() || student.ID.Length != 10) return new ValidationResult("First Give me Valid Student ID");
            if (!student.Email.Contains("@student.aiub.edu")) return new ValidationResult("Email not match in Aiub Student Domain");
            if(!student.Email.Contains(student.ID) || student.Email[10] != '@' || student.Email.Length != 27) return new ValidationResult("Not Match in Aiub Student Email"); 
            return ValidationResult.Success;
        }
    }
}