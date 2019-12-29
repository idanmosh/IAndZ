using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace IandZ.Models
{
    public class Products
    {
        [Key]
        [Required(ErrorMessage = "הכנס מזהה מוצר באורך בין 1-10 תווים מספריים")]
        [StringLength(10,MinimumLength = 1,ErrorMessage ="הכנס מזהה מוצר באורך בין 1-10 תווים מספריים")]
        [RegularExpression("^[0-9]*$")]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "הכנס מחיר מוצר")]
        [StringLength(10,MinimumLength = 1,ErrorMessage ="הכנס מחיר מוצר")]
        [RegularExpression("^[0-9]*$")]
        public string Price { get; set; }

        [Required(ErrorMessage = "הכנס שם מוצר")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "הכנס שם מוצר")]
        public string Product_name { get; set; }

        [Required(ErrorMessage = "הכנס קישור לתצוגת המוצר")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "הכנס קישור לתצוגת המוצר")]
        public string Img_url { get; set; }

        [Required(ErrorMessage = "הכנס תיאור מוצר")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "הכנס תיאור מוצר")]
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }
    }
}