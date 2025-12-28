using CustomFormValidation.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomFormValidation.Models
{
    public class Student
    {
        [Required]
        [RegularExpression(@"^[A-Za-z\s\.-]+$",ErrorMessage ="name only contains alphabets,dot(.),space and dash(-)")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z\d]+$", ErrorMessage = "username only contains alphabets and numbers")]
        public string UserName {  get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{2}-[0-9]{5}-[1-3]{1}$", ErrorMessage = "ID pattern(22-49172-3)")]
        public string ID {  get; set; }

        [Required]
        [MinimumAge(18,ErrorMessage ="age must be greater than 18 years")]
        public string DateOfBirth {  get; set; }

        [AiubEmail]
        public string Email { get; set; }
    }
}