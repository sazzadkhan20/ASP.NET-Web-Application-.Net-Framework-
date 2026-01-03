using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UniversityManagementSystem.CustomAttributes;

namespace UniversityManagementSystem.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }

        [Required]
        [UniqueId(ErrorMessage = "User Id already enlisted,Try Again with New Id")]
        public string UserID { get; set; }

        [Required]
        public string Name { get; set; }

        [AiubEmail(ErrorMessage ="Not Match Aiub Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Password must have at least 1 digit,1 upper case,1 lower case,1 specail character and 8 character long")]
        public string Password { get; set; }

        [Required]
        public string DepartmentName { get; set; }
    }
}