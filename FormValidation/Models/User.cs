using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormValidation.Models
{
    public class User
    {
        [Required(ErrorMessage ="User ID Required")]
        [Range(1,100,ErrorMessage ="Range Must be within 100")]
        public int UserID { get; set; }

        [Required(ErrorMessage ="User Name Required")]
        [StringLength(100,MinimumLength = 5)]
        [RegularExpression(@"^[A-Za-z\s]+$",ErrorMessage ="Contains Only Alphabets")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="User Email Required")]
        [RegularExpression(@"^[^\s@]+@(student\.)?(aiub|gmail|yahoo)\.edu$",ErrorMessage = "Email Pattern Not Match")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage ="User NID Required")]
        [RegularExpression(@"^[0-9]{10}$",ErrorMessage = "NID must be 10 Digits")]
        public string UserNID { get; set; }

        [Required(ErrorMessage = "User Phone Number Required")]
        [RegularExpression(@"^\+?(88)?01[3-9]\d{8}$",ErrorMessage ="Phone Number follow BD Pattern")]
        public string UserPhone { get; set; }

        [Required(ErrorMessage ="User Password Required")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*]).{8,}$", ErrorMessage ="Password must contains at least 1 digit,1 uppper case,1 lower case, 1 specail character and 8+ character long")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage ="Please Choose a Gender")]
        public string UserGender { get; set; }

        [Required(ErrorMessage = "Please Select a Profession")]
        public string UserProfession { get; set; }

        [Required(ErrorMessage = "Please Select Your Hobbies")]
        public string[] UserHobbies { get; set; }

    }
}