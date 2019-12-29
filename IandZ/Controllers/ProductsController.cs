using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IandZ.Models;
using IandZ.Dal;
using System.Data.Entity.Infrastructure;

namespace IandZ.Controllers
{
    public class ProductsController : Controller
    {

        public ActionResult Dogs()//called when clicking the "dogs" label on page Layout
        {
            ProductsDal dal = new ProductsDal();
            ProductsVM productsV = new ProductsVM();
            productsV.Products_list =
                (from y in dal.products
                 where y.Type.Equals("Dogs")
                 select y).ToList<Products>();
            return View("../Home/ShowHomePage", productsV);// returns Home page with list of products from Dogs type
        }

        public ActionResult Cats()//called when clicking the "cats" label on page Layout
        {
            ProductsDal dal = new ProductsDal();
            ProductsVM productsV = new ProductsVM();
            productsV.Products_list =
                (from y in dal.products
                 where y.Type.Equals("Cats")
                 select y).ToList<Products>();

            return View("../Home/ShowHomePage", productsV);// returns Home page with list of products from Cats type
        }

        public ActionResult AddProducts()//called when manager clicks the Add product to catalog label on page layout and returns a view and sending the view the products that in db
        {
            bool admin = Convert.ToBoolean(Session["isadmin"]);
            if (!admin || admin == null)
            {
                return HttpNotFound();
            }
            return View(new ProductsVM() { Products_list = (new ProductsDal()).products.ToList<Products>() });
        }

        public ActionResult Submit()//action result for submiiting an add product form (only admin)
        {
            Products productobj = new Products();
            ProductsDal dal = new ProductsDal();
            productobj.Product_name = Request.Form["product.product_name"];
            productobj.Img_url = Request.Form["product.img_url"];
            productobj.ProductId = Request["product.productId"];
            productobj.Price = Request.Form["product.price"];
            productobj.Description = Request.Form["product.description"];
            productobj.Type = Request.Form["product.type"];
            if (ModelState.IsValid)
            {
                dal.products.Add(productobj);
                try
                {
                    dal.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    //handle exception
                }
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);// returns the calling view (add products view)
        }

        public ActionResult GetordersJson()
        {
            OrderDal dal = new OrderDal();
            List<Order> orders = dal.order.ToList<Order>();        
            return Json(orders, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Orders()
        {
            bool admin = Convert.ToBoolean(Session["isadmin"]);
            if (!admin || admin == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        public ActionResult Search()
        {
            string product_name = Request.Form["Product_name"];
            ProductsDal dal = new ProductsDal();
            ProductsVM products = new ProductsVM();
            products.Products_list =
                (from y in dal.products
                 where y.Product_name.Contains(product_name) || y.Type.Equals(product_name)  select y).ToList<Products>();
            return View("../Home/ShowHomePage", products);

        }
           
    }
}