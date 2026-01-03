using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.DTOs
{
    public class SignInDTO
    {
        [Required]
        public string UserID { get; set; }

        [Required]
        public string Password { get; set; }
    }
}