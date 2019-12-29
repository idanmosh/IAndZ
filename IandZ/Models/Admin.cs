using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IandZ.Models
{
    public class Admin
    {
        [Required]
        [Key]
        public string AUserName { get; set; }
    }
}