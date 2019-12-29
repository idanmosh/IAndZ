using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IandZ.Models
{
    public class Users
    {
        [Required(ErrorMessage = "הכנס שם פרטי המכיל 2 תווים לפחות")]
        [StringLength(50, MinimumLength = 2,ErrorMessage ="הכנס שם פרטי המכיל 2 תווים לפחות")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "הכנס שם משפחה המכיל 2 תווים לפחות")]
        [StringLength(50, MinimumLength = 2,ErrorMessage ="הכנס שם משפחה המכיל 2 תווים לפחות")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="הכנס מספר פלאפון בן 10 ספרות")]
        [RegularExpression("^[0-9]{10}$")]
        public string UserPN { get; set; }

        [Required(ErrorMessage = "הכנס שם משתשמש המכיל 3 תווים לפחות")]
        [Key]
        [StringLength(50, MinimumLength = 3,ErrorMessage ="הכנס שם משתשמש המכיל 3 תווים לפחות")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "הכנס אימייל")]
        [EmailAddress(ErrorMessage ="הכנס אימייל")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "הכנס סיסמא המכילה לפחות 6 תווים")]
        [StringLength(50, MinimumLength = 6,ErrorMessage ="הכנס סיסמא")]
        public string UserPassword { get; set; }
    }
}