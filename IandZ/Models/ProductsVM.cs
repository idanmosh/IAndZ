using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IandZ.Models
{
    public class ProductsVM
    {
        public Products Product { get; set; }
        public List<Products> Products_list { get; set; }
    }
}