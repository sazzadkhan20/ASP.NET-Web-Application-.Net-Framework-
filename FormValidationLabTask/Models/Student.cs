using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormValidationLabTask.Models
{
    public class Student
    {
        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [Required]
        [MaxLength(70)]
        public string userName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("")]
        public string id { get; set; }

        [Required]
        public string dob { get; set; }

        [Required]
        [EmailAddress]
        public string email {  get; set; }
    }
}